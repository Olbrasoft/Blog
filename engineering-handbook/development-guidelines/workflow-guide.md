# .NET Development Workflow

## Standards

| Item | Value |
|------|-------|
| .NET Version | **net10.0** (always) |
| Test Framework | xUnit + Moq |
| Test Pattern | `[Method]_[Scenario]_[Expected]` |

## Behavior Rules

**DO:** Start implementing immediately, use sensible defaults, add dependencies when needed.
**DON'T:** Ask unnecessary questions ("Use .NET 10?", "Add EF?", "Want tests?").

## GitHub Issues

When user says "create task/issue/new task" → Create GitHub Issue via `gh issue create`.

**Issue format:**
```markdown
## Problem
[Description]

## Notes
[Additional info]
```

**Rules:**
- Never use checkboxes (`- [ ]`) for steps → use sub-issues instead
- Always create sub-issues for multi-step tasks
- Close sub-issues immediately when done

## Testing Standards

```csharp
[Fact]
public void Method_Scenario_Expected()
{
    // Arrange
    var mock = new Mock<IService>();
    
    // Act
    var result = sut.Method();
    
    // Assert
    Assert.True(result);
}
```

**Required packages:** `xunit`, `xunit.runner.visualstudio`, `Moq`, `coverlet.collector`

## Deployment Workflow

1. **Check project AGENTS.md** for specific rules
2. **Run tests:** `dotnet test` (must pass)
3. **Build:** `dotnet publish -c Release -o ~/target --no-self-contained`
4. **Restart service:** `systemctl --user restart service.service`
5. **Verify:** `systemctl --user status service.service`

## Git Workflow

**Branch naming:** `fix/issue-N-desc`, `feature/issue-N-desc`, `refactor/issue-N-desc`

**Commit often:** After every significant change → `git commit` + `git push`

**Merge flow:**
```bash
git checkout main
git merge feature/issue-N-desc
git push origin main
```

## Task Format for Claude

When preparing tasks for Claude Code, keep it **brief**:

```markdown
## Task: [Short description] (#issue-number)

Issue: [link]

### What to do
[2-3 sentences max - Claude reads the issue for details]

### Key points
- [Important constraint 1]
- [Important constraint 2]

### Testing & Deploy
[Standard: build, test, deploy, ask user to restart]
```

**Rules:**
- Don't repeat issue details - Claude reads the issue
- No SQL/code snippets - those belong in the issue
- Focus on "what" not "how" - Claude figures out implementation
- Keep under 20 lines total

**Bad:** Listing exact SQL commands, full code examples, step-by-step instructions
**Good:** "Add session_id column, create logging table, see issue for schema"

## Issue Closure Rules

**NEVER close issue until:**
1. All sub-issues closed
2. All tests pass
3. Code deployed
4. User verified and approved

**Always ask:** "Can you test that [feature] works correctly?"
