# Olbrasoft Monorepo

This repository contains two projects: **Stam** (Chrome Extension) and **WakeWordDetection** (.NET 10 service).

# Olbrasoft Monorepo

This repository contains three projects: **Stam** (Chrome Extension), **VoiceAssistant** (.NET 10 platform), and legacy projects.

## VoiceAssistant (C#/.NET 10)

Voice assistant platform with wake word detection and orchestration.

**Location:** `/home/jirka/Olbrasoft/VoiceAssistant/`  
**Build:** `cd VoiceAssistant && dotnet build`  
**Test all:** `cd VoiceAssistant && dotnet test`  
**Deploy WakeWordDetection:** `cd VoiceAssistant && ./deploy.sh`  
**Run Orchestration:** `cd VoiceAssistant/src/Orchestration && dotnet run`

**Projects:**
- **WakeWordDetection** - Offline wake word detection (OpenWakeWord, SignalR WebSocket)
- **Orchestration** - Voice assistant orchestrator (SignalR client, audio responses)

**MANDATORY before commits:** Run `dotnet test` - all 38 tests must pass.

**GitHub:** https://github.com/Olbrasoft/VoiceAssistant

See `/home/jirka/Olbrasoft/VoiceAssistant/AGENTS.md` for detailed instructions.

## Stam (Chrome Extension - Vanilla JS)

**Build:** None (plain JavaScript, no build process)  
**Test:** Manual only - Load unpacked extension at `chrome://extensions/`  
**Code Style:** 2-space indent, camelCase functions, single quotes, `const`/`let`, console logs prefixed with `'STAM:'`

See project-specific `AGENTS.md` files in subdirectories for detailed guidelines.
