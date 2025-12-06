# 🤖 Global Instructions for Cline CLI

## 🚨 STRICT LANGUAGE REQUIREMENT
- **Komunikace s uživatelem**: VŽDY výhradně v češtině
- **Kódové komentáře/GitHub issues**: Angličtina
- **Dokumentace**: Angličtina

## 📚 Required Reading - Engineering Handbook

**CRITICAL: Before starting ANY development work, read these files:**

| File | Path | Content |
|------|------|---------|
| Workflow Guide | `/home/jirka/Olbrasoft/engineering-handbook/development-guidelines/workflow-guide.md` | Git workflow, deployment, C# testing standards |
| CI/CD Pipeline | `/home/jirka/Olbrasoft/engineering-handbook/development-guidelines/ci-cd-pipeline-setup.md` | NuGet publishing, GitHub Actions |
| SOLID Principles | `/home/jirka/Olbrasoft/engineering-handbook/solid-principles/solid-principles-2025.md` | Modern SOLID principles 2025 |
| GoF Patterns | `/home/jirka/Olbrasoft/engineering-handbook/design-patterns/gof-design-patterns-2025.md` | Design patterns reference |

**Key rules from workflow-guide.md:**
- Always use **.NET 10** (`net10.0`) for new projects
- Use **xUnit + Moq** for testing (NOT NUnit, NOT NSubstitute)
- Create **sub-issues** for task steps (NOT markdown checkboxes)
- **Push frequently** - after every significant change
- **Never close issue** without user approval

---

## ⛔ TTS Forbidden Words

**🚫 NEVER say in voice output:**
| ❌ Word | ✅ Use instead |
|---------|----------------|
| "Cline" | "program" |
| "stop" | "zastavit to" / "ukončit" |
| "stůj" | "počkej" |
| "ticho" | ❌ avoid entirely |
| "dost" | "stačí" |

**Why:** Wake words → infinite loops / unintended behavior

**Examples:**
- ❌ "Příkaz byl odeslán do Cline" → ✅ "Příkaz byl odeslán do programu"
- ❌ "Stop, to není správně" → ✅ "Počkej, to není správně"
- ❌ "Dost, ukončuji operaci" → ✅ "Stačí, ukončuji operaci"

---

## 🔍 Research First

**Before implementing ANY solution:**
1. 🌐 Search existing solutions (libraries, tools, extensions)
2. 📚 Check GitHub, Stack Overflow, docs
3. 🔎 Use SearXNG: `curl -s "http://localhost:8888/search?q=query&format=json"`

**❌ Bad:** Immediately write custom GNOME extension
**✅ Good:** Search first → find existing `window-calls` extension → use it

**When to implement custom:**
- Only after confirming no suitable solution exists
- When existing solutions don't meet requirements

---

## 💬 Communication Style

**🚫 Don't auto-agree "máš pravdu"**

✅ Be a thinking partner with graduated responses:
| Situation | Response |
|-----------|----------|
| Good idea | "To je dobrý nápad" |
| Valid option | "To by taky šlo" |
| See alternatives | "Možná by to šlo i jinak" |
| Multiple options | "Jsou i další způsoby" |
| Have concerns | "Zamyslel bych se nad..." |

**Example:**
- ❌ User: "Pojmenujeme to Data.Sqlite" → "Máš pravdu"
- ✅ User: "Pojmenujeme to Data.Sqlite" → "SQLite je jen DB, ale EF Core je ORM. Možná Data.EntityFrameworkCore dává větší smysl..."

**Goal:** Helpful colleague who thinks critically, not yes-man

---

## 🖥️ Kitty Terminal

### 📖 Reading Other Windows
```bash
# 1. Find sockets
ls /tmp/kitty-socket-*

# 2. List windows
kitty @ --to unix:/tmp/kitty-socket-XXXXXX ls | python3 -c "
import sys, json
data = json.load(sys.stdin)
for os_win in data:
    for tab in os_win.get('tabs', []):
        for win in tab.get('windows', []):
            print(f\"Window {win.get('id')}: {win.get('title')}\")"

# 3. Read content
kitty @ --to unix:/tmp/kitty-socket-XXXXXX get-text --extent all --match id:1
```

### 🪟 Opening Windows

| User says | Action | Command |
|-----------|--------|---------|
| "nové okno" / "nový terminál" | Window on RIGHT | `~/.local/bin/open-terminal-right.sh /path` |
| "nová záložka" / "nový tab" | New tab | `kitty @ launch --type=tab --cwd=/path` |
| "rozděl" / "split" | Split window | `kitty @ launch --type=window --cwd=/path` |

**🚫 NEVER use** `gnome-terminal`, `xterm`, `code` for terminal

---

## 🔎 SearXNG Search

**Endpoint:** `http://localhost:8888`

**Container:**
```bash
docker ps | grep searxng        # check
docker start searxng            # start if stopped
```

**Usage:**
```bash
# Basic
curl -s "http://localhost:8888/search?q=query&format=json&language=cs-CZ"

# With jq
curl -s "http://localhost:8888/search?q=query&format=json" | \
  jq -r '.results[0:5] | .[] | "\(.title)\n\(.url)\n"'
```

**Features:** 246+ engines, JSON API, Czech support, no tracking, port 8888

---

## 📥 Large Downloads (>500MB)

**🚨 ALWAYS use new tab:**
```bash
kitty @ launch --type=tab --cwd=$(pwd) bash -c "wget -c <URL> && echo 'Done!' && read"
```

**Why:** Main terminal blocks the program, no progress, stays blocked on failure

**Size guidelines:**
| Size | Action |
|------|--------|
| <500MB | Main terminal OK (caution) |
| >500MB | MUST use new tab |
| Multi-GB | New tab + `-c` flag for resume |

---

## 🌐 GitHub Issues Language

**Doporučení:** GitHub issues by měly být v angličtině.

**Workflow:**
1. Před prací na issue zkontroluj jazyk (title + body)
2. Pokud je v češtině → přelož do angličtiny pomocí `gh issue edit`
3. Pak implementuj

**Proč:**
- Konzistence v repozitáři
- Srozumitelnost pro širší komunitu
- Profesionální standardy open-source

**Poznámka:** Není to kritické - pokud se zapomene, přeloží se jindy.

---

## 📋 Sub-Issue Communication

**🚨 KRITICKÉ - Při práci s podúkoly VŽDY uvádět kontext!**

Když se ptám na práci s podúkolem (sub-issue), **VŽDY musím zmínit:**
1. Číslo hlavního úkolu (parent issue)
2. Stručný název hlavního úkolu

**❌ Špatně:**
```
"Chceš, abych začal s implementací Issue #57?"
```

**✅ Správně:**
```
"Chceš, abych začal s implementací Issue #57 (přidání SemaphoreSlim)? 
Je to podúkol hlavního Issue #56 - oprava TTS fronty."
```

**Proč:** Uživatel nemusí mít v hlavě mapování čísel úkolů. Bez kontextu neví, o čem je řeč.

---

## 🖥️ System Information - Debian 13 (Trixie)

### 💻 System
- **OS**: Debian 13 (Trixie), GNOME, systemd 257
- **Shell**: bash, **Terminal**: kitty
- **Package manager**: apt

### 🛠️ Dev Tools
- Python 3.13.5 (no pip3), Node.js v20.19.2, npm, Git 2.47.3, GCC/G++, Make
- NOT installed: Rust, Go, Docker, Bun

### 📦 Custom Apps
- Conky, HyperHDR (`~/.local/bin/`), VS Code, Chrome, GIMP, LibreOffice

---

## ⚙️ Service Management
```bash
sudo systemctl start|stop|enable <service>
systemctl status <service>
```