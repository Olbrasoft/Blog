# GitHub Issue Guidelines

## Issue Structure

Every issue needs:
- **Title**: Clear, action-oriented (English)
- **Problem**: What's wrong/needed
- **Proposed Solution**: How to fix
- **Acceptance Criteria**: How to verify done

## Labels

| Type | Labels |
|------|--------|
| Priority | `urgent`, `priority`, `blocked` |
| Type | `bug`, `enhancement`, `refactoring`, `documentation` |
| Agent | `agent:claude` (implement), `agent:opencode` (research), `agent:user` (decision) |

**Note:** Issues can have multiple agent labels.

## Sub-Issues

**When:** Task has 3+ steps or needs tracking.

**Rules:**
1. Link to parent: `## Parent Issue\n#123 - Title`
2. Close immediately when done
3. Never use checkboxes (`- [ ]`) for trackable tasks

## Workflow Patterns

| Pattern | Flow |
|---------|------|
| Idea → Code | User → OpenCode structures → Claude implements → User verifies |
| Research | OpenCode researches → reports → User decides |
| Complex | OpenCode plans + sub-issues → Claude implements each → review |

## Quick Reference

| When | Action |
|------|--------|
| New issue | Use structure, add labels |
| Multiple steps | Create sub-issues |
| Ready for Claude | Add `agent:claude` |
| Sub-issue done | Close IMMEDIATELY |
| Implementation done | Wait for user verification |
