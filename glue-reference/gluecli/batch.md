# batch

### Introduction

`batch` runs several commands, one per line of a file or of stdin, against one load of the project. Each GlueCli run spends a few seconds starting the editor and loading the project, so making several edits in one batch is much faster than making them one run at a time.

Each command does exactly what it does on its own. An edit regenerates the code of what it changed and saves the project, and its errors are the ones it added to the project as the command before it left it.

### Usage

```
GlueCli batch <project> (--file <path> | --stdin) [--keep-going] [--dry-run] [--json]
```

### Options

| Option | Description |
|--------|-------------|
| `<project>` | A `.gluj`, a `.csproj`, or a folder containing exactly one `.gluj`. Every command in the batch runs on it. |
| `--file <path>` | Read the commands from this file. |
| `--stdin` | Read the commands from standard input. |
| `--keep-going` | Run every command, even after one fails. |
| `--dry-run` | Run the whole batch against one temp copy of the project and report what it would change. |
| `--json` | Print one JSON object to stdout instead of text. |

### Writing a Batch

Each line is one command without the project, the same as you would type after `GlueCli` with the project left out:

```
# Add a sprite and move it.
add-object --element GameScreen --type Sprite --name Background
set-variable --element GameScreen --object Background --variable Z --value -1

add-entity --name Coin --circle
add-object --element Entities\Coin --type Sprite
```

* Arguments split on spaces. Put an argument that has spaces in double or single quotes, such as `--source-name "Entire File (LayeredTileMap)"`.
* A backslash is an ordinary character, so `Entities\Enemy` needs no escaping.
* Blank lines and lines starting with `#` are skipped.
* `--json`, `--dry-run` and `--help` go on the `batch` command line, not on a line of the batch.

GlueCli checks every line before it starts. An unknown command or option, a missing required option, or a project path on a line exits with code 2 and runs nothing.

### When a Command Fails

The batch stops at the first command that does not exit with 0. Pass `--keep-going` to run the rest anyway.

Nothing is rolled back. Commands that ran before the failure stay saved. A failed edit itself saves nothing, the same as when it runs alone.

### Previewing a Batch with --dry-run

With `--dry-run`, the whole batch runs against one temp copy of the project, so each command sees the edits before it. The report lists every file the batch would change, with a diff of each `.gluj`, `.glsj`, `.glej` and `.json` file. The project on disk stays exactly as it was.

### Output

Each command prints its usual report, with how long it took. Then the batch prints a summary. For the batch above:

```
add-object C:\Games\Beefball\Beefball\Beefball.csproj
Ran in 0.3s.
Added Background (FlatRedBall.Sprite) to Screens\GameScreen.
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.

set-variable C:\Games\Beefball\Beefball\Beefball.csproj
Ran in 0.1s.
Set Background.Z in Screens\GameScreen (float): (default) -> -1.
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.

...

batch C:\Games\Beefball\Beefball\Beefball.csproj
Glue started in 1.2s, project loaded in 0.5s, 3.0s total.
Ran all 4 command(s), exit code 0.
```

With `--json`, the batch prints one object:

| Property | Meaning |
|----------|---------|
| `command` | `batch`. |
| `project` | The project's `.csproj` path. |
| `exitCode` | The first non-zero exit code of the commands that ran, or 0. 2 if the batch could not run. |
| `failure` | Why the batch could not run, such as bad syntax or a project that would not load. |
| `commandCount` | How many commands the batch has. |
| `results` | Each command's own JSON object, in order, as described in [JSON Output](README.md#json-output). It is shorter than `commandCount` when the batch stopped early. |
| `dryRun`, `changes` | `--dry-run` only: `true`, and every file the whole batch would change. |
| `startupSeconds`, `loadSeconds`, `elapsedSeconds` | How long starting the editor, loading the project, and the whole batch took. |

### Exit Codes

| Code | Meaning |
|------|---------|
| 0 | Every command ran with exit code 0. |
| 1 | A command could not apply its edit, or added errors. |
| 2 | Bad arguments, a bad line, the project could not be loaded, or a plugin failed to start. |
