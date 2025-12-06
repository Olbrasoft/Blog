/**
 * OpenCode GitHub Sub-Issues Plugin
 * 
 * Syncs OpenCode TODO items with GitHub sub-issues.
 * When a TODO is marked as "completed", the corresponding GitHub issue is closed.
 * 
 * Convention: TODO ID = GitHub Issue Number
 * Example: todowrite({ id: "42", status: "completed" }) → closes GitHub issue #42
 */

console.log("[github-sub-issues] ========== MODULE LOADED ==========");

import type { Plugin } from "@opencode-ai/plugin";

// Types for OpenCode events
interface TodoItem {
  id: string;
  content: string;
  status: "pending" | "in_progress" | "completed" | "cancelled";
  priority: "high" | "medium" | "low";
}

interface TodoUpdatedEvent {
  type: "todo.updated";
  properties: {
    sessionID: string;
    todos: TodoItem[];
  };
}

// Track previous todo states to detect changes
const previousStates: Map<string, string> = new Map();

// Configuration - can be overridden via environment variables
const config = {
  // Default repository in format "owner/repo"
  defaultRepo: process.env.GITHUB_REPO || "Olbrasoft/VoiceAssistant",
  // Whether to log debug information
  debug: process.env.DEBUG === "true" || true, // Enable debug for now
};

/**
 * Check if a TODO ID is a valid GitHub issue number
 */
function isGitHubIssueNumber(id: string): boolean {
  return /^\d+$/.test(id);
}

/**
 * OpenCode GitHub Sub-Issues Plugin
 * 
 * Automatically closes GitHub issues when TODOs are marked as completed.
 * Uses gh CLI for GitHub operations.
 */
export const GitHubSubIssuesPlugin: Plugin = async ({ $ }) => {
  console.log("[github-sub-issues] Plugin initialized");

  /**
   * Close a GitHub issue using gh CLI
   */
  async function closeGitHubIssue(issueNumber: string, repo?: string): Promise<boolean> {
    try {
      const repoArg = repo ? `--repo ${repo}` : "";
      const command = `gh issue close ${issueNumber} ${repoArg}`.trim();
      
      if (config.debug) {
        console.log(`[github-sub-issues] Executing: ${command}`);
      }
      
      await $`gh issue close ${issueNumber} ${repoArg}`;
      
      console.log(`[github-sub-issues] ✓ Closed GitHub issue #${issueNumber}`);
      return true;
    } catch (error) {
      console.error(`[github-sub-issues] ✗ Failed to close issue #${issueNumber}:`, error);
      return false;
    }
  }

  /**
   * Reopen a GitHub issue using gh CLI (for cancelled → pending transition)
   */
  async function reopenGitHubIssue(issueNumber: string, repo?: string): Promise<boolean> {
    try {
      const repoArg = repo ? `--repo ${repo}` : "";
      
      if (config.debug) {
        console.log(`[github-sub-issues] Executing: gh issue reopen ${issueNumber} ${repoArg}`);
      }
      
      await $`gh issue reopen ${issueNumber} ${repoArg}`;
      
      console.log(`[github-sub-issues] ✓ Reopened GitHub issue #${issueNumber}`);
      return true;
    } catch (error) {
      console.error(`[github-sub-issues] ✗ Failed to reopen issue #${issueNumber}:`, error);
      return false;
    }
  }

  /**
   * Process todo.updated event
   */
  async function handleTodoUpdated(event: TodoUpdatedEvent): Promise<void> {
    const { todos } = event.properties;
    
    for (const todo of todos) {
      const previousStatus = previousStates.get(todo.id);
      const currentStatus = todo.status;
      
      // Skip if no change
      if (previousStatus === currentStatus) {
        continue;
      }
      
      // Only process if ID is a GitHub issue number
      if (!isGitHubIssueNumber(todo.id)) {
        if (config.debug) {
          console.log(`[github-sub-issues] Skipping non-numeric ID: ${todo.id}`);
        }
        previousStates.set(todo.id, currentStatus);
        continue;
      }
      
      // Handle status transitions
      if (currentStatus === "completed" && previousStatus !== "completed") {
        // TODO marked as completed → close GitHub issue
        await closeGitHubIssue(todo.id, config.defaultRepo || undefined);
      } else if (currentStatus === "cancelled" && previousStatus !== "cancelled") {
        // TODO cancelled → also close GitHub issue
        await closeGitHubIssue(todo.id, config.defaultRepo || undefined);
      } else if (
        (currentStatus === "pending" || currentStatus === "in_progress") &&
        (previousStatus === "completed" || previousStatus === "cancelled")
      ) {
        // TODO reopened → reopen GitHub issue
        await reopenGitHubIssue(todo.id, config.defaultRepo || undefined);
      }
      
      // Update tracked state
      previousStates.set(todo.id, currentStatus);
    }
  }

  return {
    /**
     * Specific handler for todo.updated event
     */
    "todo.updated": async (event: TodoUpdatedEvent) => {
      console.log("[github-sub-issues] todo.updated SPECIFIC handler called!");
      await handleTodoUpdated(event);
    },
    
    /**
     * Generic event handler for all events
     */
    event: async ({ event }: { event: { type: string } }) => {
      console.log("[github-sub-issues] GENERIC event handler:", event.type);
      if (event.type === "todo.updated") {
        await handleTodoUpdated(event as unknown as TodoUpdatedEvent);
      }
    },
  };
};

// Default export for convenience
export default GitHubSubIssuesPlugin;
