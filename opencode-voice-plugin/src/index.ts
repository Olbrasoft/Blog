import type { Plugin } from "@opencode-ai/plugin"
import { tool } from "@opencode-ai/plugin"
import { appendFileSync } from "fs"

const LOG_FILE = "/tmp/voice-plugin-debug.log"

function logToFile(message: string): void {
  try {
    const timestamp = new Date().toISOString()
    appendFileSync(LOG_FILE, `[${timestamp}] ${message}\n`)
  } catch {
    // Silent fail
  }
}

/**
 * Configuration for the TTS service
 */
interface TTSConfig {
  /** TTS API endpoint URL */
  apiUrl: string
  /** Can-speak check endpoint URL */
  canSpeakUrl: string
  /** Fallback shell script path (optional, null = no fallback) */
  fallbackScript: string | null
  /** Whether to announce when session becomes idle */
  announceOnIdle: boolean
  /** Default idle announcement message */
  idleMessage: string
  /** API endpoint for storing AI responses to discussion */
  discussionApiUrl: string
  /** Whether to store AI responses to database */
  storeAiResponses: boolean
}

/**
 * Default configuration
 */
const defaultConfig: TTSConfig = {
  apiUrl: "http://localhost:5555/api/speech/speak",
  canSpeakUrl: "http://localhost:5555/api/speech/can-speak",
  fallbackScript: null,
  announceOnIdle: false,
  idleMessage: "Úkol dokončen.",
  discussionApiUrl: "http://localhost:5051/api/discussions/active/ai-response",
  storeAiResponses: false, // DISABLED by default - must be explicitly enabled via OPENCODE_STORE_AI_RESPONSES=true
}

/**
 * Load configuration from environment or use defaults
 */
function loadConfig(): TTSConfig {
  return {
    apiUrl: process.env.OPENCODE_TTS_API_URL ?? defaultConfig.apiUrl,
    canSpeakUrl: process.env.OPENCODE_TTS_CAN_SPEAK_URL ?? defaultConfig.canSpeakUrl,
    fallbackScript: process.env.OPENCODE_TTS_FALLBACK_SCRIPT || null,
    announceOnIdle: process.env.OPENCODE_TTS_ANNOUNCE_IDLE === "true",
    idleMessage: process.env.OPENCODE_TTS_IDLE_MESSAGE ?? defaultConfig.idleMessage,
    discussionApiUrl: process.env.OPENCODE_DISCUSSION_API_URL ?? defaultConfig.discussionApiUrl,
    storeAiResponses: process.env.OPENCODE_STORE_AI_RESPONSES === "true", // Must be explicitly enabled
  }
}

/**
 * Check if we can speak (no active speech lock)
 */
async function canSpeak(config: TTSConfig): Promise<boolean> {
  try {
    const response = await fetch(config.canSpeakUrl, {
      method: "GET",
      signal: AbortSignal.timeout(1000), // 1 second timeout
    })
    
    if (response.ok) {
      const data = await response.json() as { canSpeak: boolean }
      return data.canSpeak
    }
    
    // On error, allow speaking (fail open)
    return true
  } catch (error) {
    // Network error or timeout - allow speaking (silent)
    return true
  }
}

/**
 * OpenCode Voice Plugin
 * 
 * Provides text-to-speech functionality for OpenCode through:
 * - A `speak` tool that the AI can call to speak text aloud
 * - Optional automatic announcements on session events
 * - Speech lock checking to prevent speaking while user is recording
 * - Automatic storage of AI responses to discussion database
 * 
 * @example
 * // The AI can use the speak tool like this:
 * // speak({ text: "Úkol byl dokončen." })
 */
export const VoicePlugin: Plugin = async ({ $, client }) => {
  const config = loadConfig()
  
  // Log plugin initialization
  logToFile(`PLUGIN INIT: storeAiResponses=${config.storeAiResponses}, discussionApiUrl=${config.discussionApiUrl}`)
  logToFile(`ENV: OPENCODE_STORE_AI_RESPONSES=${process.env.OPENCODE_STORE_AI_RESPONSES}`)
  
  // Track which sessions we've already processed to avoid duplicates
  let lastProcessedMessageId: string | null = null
  // Lock to prevent concurrent processing of the same idle event
  let isProcessingIdle = false

  /**
   * Speak text using the TTS API or fallback script
   */
  async function speak(text: string): Promise<boolean> {
    // Check if we can speak (user not recording)
    const allowed = await canSpeak(config)
    if (!allowed) {
      // Silent skip - no log output
      return true // Return success but don't speak
    }

    try {
      // Try HTTP API first
      const response = await fetch(config.apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ text }),
      })

      if (response.ok) {
        return true
      }

      // API failed, try fallback (silent)
    } catch (error) {
      // Network error, use fallback (silent)
    }

    // Fallback to shell script (only if configured)
    if (config.fallbackScript) {
      try {
        await $`${config.fallbackScript} ${text}`
        return true
      } catch (error) {
        // Fallback failed (silent)
        return false
      }
    }
    return false
  }

  /**
   * Store AI response via Discussion API endpoint
   * Completely silent - no output to terminal ever
   */
  async function storeAiResponse(content: string): Promise<void> {
    if (!config.storeAiResponses || !content.trim()) {
      return
    }

    try {
      const response = await fetch(config.discussionApiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ content }),
        signal: AbortSignal.timeout(5000), // 5 second timeout
      })

      if (response.ok) {
        const data = await response.json() as { messageId: number; discussionId: number }
        logToFile(`AI response stored: messageId=${data.messageId}, discussionId=${data.discussionId}`)
      } else {
        logToFile(`API error: ${response.status} ${response.statusText}`)
      }
    } catch (err) {
      // Silent fail - log to file only
      logToFile(`storeAiResponse error: ${err}`)
    }
  }

  /**
   * Extract text content from message parts
   * Handles multiple content types: text, markdown, content
   */
  function extractTextFromParts(parts: Array<{ type: string; text?: string; content?: string }>): string {
    return parts
      .filter((part) => (part.type === "text" || part.type === "markdown") && (part.text || part.content))
      .map((part) => part.text || part.content || "")
      .join("\n")
  }

  return {
    /**
     * Event handler for OpenCode events
     */
    event: async ({ event }) => {
      // Log every event for debugging
      logToFile(`EVENT: ${event.type}, storeAiResponses=${config.storeAiResponses}, announceOnIdle=${config.announceOnIdle}`)
      
      // Announce when session becomes idle (if enabled)
      if (event.type === "session.idle" && config.announceOnIdle) {
        await speak(config.idleMessage)
      }

      // Store AI response when session becomes idle (only if explicitly enabled)
      if (event.type === "session.idle" && config.storeAiResponses) {
        // Prevent duplicate processing from concurrent events
        if (isProcessingIdle) {
          logToFile("skipping - already processing idle event")
          return
        }
        isProcessingIdle = true
        
        logToFile("session.idle event - storeAiResponses enabled")
        if (!client) {
          logToFile("client is null")
          return
        }
        try {
          const sessionId = (event.properties as { sessionID: string }).sessionID
          logToFile(`sessionId: ${sessionId}`)
          const messagesResponse = await client.session.messages({
            path: { id: sessionId },
          })

          // Find the last assistant message
          const messages = messagesResponse.data ?? []
          logToFile(`messages count: ${messages.length}`)
          
          // Find the last assistant message that actually has text/markdown content
          // (not just step-start/step-finish metadata)
          const lastAssistantMessageWithContent = [...messages]
            .reverse()
            .find((m) => {
              if (m.info.role !== "assistant") return false
              const parts = m.parts as Array<{ type: string; text?: string; content?: string }>
              return parts?.some(p => 
                (p.type === "text" || p.type === "markdown") && (p.text || p.content)
              )
            })

          logToFile(`lastAssistantMessageWithContent found: ${!!lastAssistantMessageWithContent}`)
          logToFile(`lastProcessedMessageId: ${lastProcessedMessageId}`)
          logToFile(`new message id: ${lastAssistantMessageWithContent?.info?.id}`)

          if (lastAssistantMessageWithContent && lastAssistantMessageWithContent.info.id !== lastProcessedMessageId) {
            lastProcessedMessageId = lastAssistantMessageWithContent.info.id
            
            // Debug: log parts info
            const parts = lastAssistantMessageWithContent.parts as Array<{ type: string; text?: string; content?: string }>
            logToFile(`parts count: ${parts?.length ?? 0}`)
            if (parts) {
              for (let i = 0; i < Math.min(parts.length, 5); i++) {
                const p = parts[i]
                const textLen = p.text?.length ?? p.content?.length ?? 0
                logToFile(`part[${i}] type=${p.type}, textLen=${textLen}`)
              }
            }
            
            const textContent = extractTextFromParts(parts)
            logToFile(`textContent length: ${textContent?.length ?? 0}`)
            if (textContent) {
              logToFile("calling storeAiResponse")
              await storeAiResponse(textContent)
              logToFile("storeAiResponse done")
            }
          } else {
            logToFile("skipping - already processed or no message with content")
          }
        } catch (err) {
          logToFile(`error: ${err}`)
        } finally {
          isProcessingIdle = false
        }
      }
    },

    /**
     * Custom tools provided by this plugin
     */
    tool: {
      /**
       * Speak text aloud using text-to-speech
       */
      speak: tool({
        description:
          "Speak text aloud using text-to-speech. Use this for voice confirmations, " +
          "task acknowledgments, and summaries. Text should be in Czech language, " +
          "natural and conversational. Keep it brief (1-3 sentences).",
        args: {
          text: tool.schema.string().describe("The text to speak aloud (Czech language preferred)"),
        },
        async execute(args) {
          const success = await speak(args.text)
          if (success) {
            return `„${args.text}"`
          } else {
            return `[TTS error] „${args.text}"`
          }
        },
      }),
    },
  }
}

// Default export for convenience
export default VoicePlugin
