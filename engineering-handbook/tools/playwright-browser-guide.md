# Playwright Browser Guidelines

## Focus Management

**After EVERY `playwright_browser_*` call:** `~/focus-back.sh`

## Tab Workflow

Before opening ANY URL:
1. `playwright_browser_tabs(action: "list")`
2. Check if URL already open → select that tab
3. Check for empty tab (`about:blank`) → use it
4. Otherwise → create new tab

**After navigation:** `~/.local/bin/move-window-right.sh` then `~/focus-back.sh`

## URL Matching

| Scenario | Match? |
|----------|--------|
| Same URL | ✅ |
| Same URL + different query params | ✅ |
| Same domain, different path | ❌ |

## Quick Reference

| Action | Command |
|--------|---------|
| List tabs | `playwright_browser_tabs(action: "list")` |
| New tab | `playwright_browser_tabs(action: "new")` |
| Select tab | `playwright_browser_tabs(action: "select", index: N)` |
| Navigate | `playwright_browser_navigate(url: "...")` |
| Return focus | `~/focus-back.sh` |

## Rules

1. Never open duplicate tabs
2. Reuse empty tabs (`about:blank`)
3. Move window right after navigation
4. Always return focus after operations
5. Don't close browser
