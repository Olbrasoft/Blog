# OpenCode GitHub Sub-Issues Plugin

OpenCode plugin that automatically syncs TODO items with GitHub sub-issues.

When you mark a TODO as `completed` in OpenCode, the corresponding GitHub issue is automatically closed.

## How It Works

**Convention:** `TODO ID = GitHub Issue Number`

```
todowrite({ id: "42", content: "Implement feature X", status: "completed" })
```
↓
```
gh issue close 42
```

## Installation

1. Clone this repository:
```bash
git clone https://github.com/Olbrasoft/opencode-github-sub-issues-plugin.git
cd opencode-github-sub-issues-plugin
```

2. Install dependencies and build:
```bash
npm install
npm run build
```

3. Copy the plugin to your OpenCode plugins directory:
```bash
cp -r dist ~/.config/opencode/plugins/github-sub-issues/
```

## Usage

### Workflow

1. **Create a parent GitHub issue** for your task
2. **Create sub-issues** for each step (these will be your TODOs)
3. **Use sub-issue numbers as TODO IDs** in OpenCode:

```javascript
// In OpenCode, when working on GitHub issue #42
todowrite({
  todos: [
    { id: "43", content: "Step 1: Design API", status: "pending", priority: "high" },
    { id: "44", content: "Step 2: Implement", status: "pending", priority: "high" },
    { id: "45", content: "Step 3: Write tests", status: "pending", priority: "medium" }
  ]
})
```

4. **Mark as completed** - plugin automatically closes the GitHub issue:
```javascript
todowrite({
  todos: [
    { id: "43", content: "Step 1: Design API", status: "completed", priority: "high" }
  ]
})
// → GitHub issue #43 is now closed!
```

### Configuration

Set environment variables:

| Variable | Description | Default |
|----------|-------------|---------|
| `GITHUB_REPO` | Default repository (owner/repo) | Current repo |
| `DEBUG` | Enable debug logging | `false` |

Example:
```bash
export GITHUB_REPO="Olbrasoft/VoiceAssistant"
export DEBUG=true
```

## Supported Status Transitions

| From | To | GitHub Action |
|------|----|---------------|
| any | `completed` | Close issue |
| any | `cancelled` | Close issue |
| `completed`/`cancelled` | `pending`/`in_progress` | Reopen issue |

## Requirements

- Node.js >= 20.0.0
- GitHub CLI (`gh`) installed and authenticated
- OpenCode with plugin support

## Development

```bash
# Install dependencies
npm install

# Build
npm run build

# Watch mode
npm run watch
```

## License

MIT

## Related

- [OpenCode](https://github.com/sst/opencode) - AI coding agent
- [VoiceAssistant Issue #27](https://github.com/Olbrasoft/VoiceAssistant/issues/27) - Original feature request
