#!/bin/bash
# voice-vibing.sh - VoiceVibing startup script
# Spouští voice assistant služby a OpenCode


echo "2. Startuji push-to-talk-dictation..."
systemctl --user start push-to-talk-dictation.service

echo "3. Startuji transcription-indicator..."
systemctl --user start transcription-indicator.service

echo ""
echo "=== Služby spuštěny, spouštím OpenCode ==="
sleep 0.5

# 2. Spustit kitty s OpenCode a přesunout doleva
kitty --title "VoiceVibing" bash -c '
    exec ~/.local/bin/opencode-fixedport
' &

# 3. Počkat na okno a přesunout doleva
sleep 2
~/.local/bin/move-window-left.sh
