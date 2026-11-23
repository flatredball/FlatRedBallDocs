# GlueCli

### Introduction

**GlueCli** (`GlueCli.exe`) is a command-line tool that makes the same edits the FlatRedBall Editor makes. It runs the editor's own code with no window, so plugins react exactly as they do in the editor and code is generated the same way.

Use GlueCli when:

* You are an AI agent editing a FlatRedBall project. See [GlueCli for AI Agents](gluecli-for-ai-agents.md).
* You want to script changes to a project, such as adding many objects or setting many variables.
* You hand-edited a `.gluj`, `.glsj` or `.glej` file and want to check it for errors or regenerate code.

GlueCli runs on Windows only, like the editor.

### Getting GlueCli

`GlueCli.exe` ships next to the editor's exe (`GlueFormsCore.exe`). In the FRBDK download it is in the `Xna 4 Tools` folder. In the daily build zip it is in the root folder. Run it from that folder, or add the folder to your `PATH`.

If you build FlatRedBall from source, build the editor solution:

```
dotnet build "FRBDK/Glue/Glue with All.sln"
```

This writes `GlueCli.exe` to `FRBDK/Glue/Glue/bin/Debug/`, next to `GlueFormsCore.exe`. GlueCli loads plugins from the `Plugins` folder next to it, so build the whole solution rather than only `GlueCli.csproj`. Otherwise GlueCli runs with plugins left over from an older build.

### How a Run Works

Every command has the same shape:

```
GlueCli <command> <project> [options]
```

`<project>` is one of these:

* A `.gluj` file. GlueCli opens the `.csproj` with the same name next to it, or the only `.csproj` in that folder.
* A `.csproj` file.
* A folder. GlueCli searches it and all its subfolders for `.gluj` files, skipping `bin` and `obj` folders. The search must find exactly one. If it finds more, the run fails and lists them, so pass one of them instead.

A common layout puts the `.gluj` one folder down from the repository root, such as `MyGame/MyGame/MyGame.gluj`. All of these load it:

```
GlueCli check MyGame/MyGame/MyGame.gluj
GlueCli check MyGame/MyGame
GlueCli check MyGame
```

The last one works because the search includes subfolders. It fails if the repository holds a second `.gluj`, such as a copy of the game for another platform.

Each run does the following:

1. Starts the editor with no window and loads the project. Loading reads the project. Unlike **File > Load Project**, it does not regenerate code or save anything.
2. Runs one command, or several with [batch](batch.md).
3. Waits for the editor's queued work, such as plugin reactions and code generation.
4. For edit commands, saves the `.gluj`, the changed screen and entity files and the `.csproj`, and regenerates code for every changed screen and entity.
5. Prints a report and exits.

Run [regen](regen.md) once after cloning or pulling, or whenever generated code is out of date. Edit commands regenerate only what they change, so after a fresh clone, or after project files change outside GlueCli, the game does not build until `regen` runs.

GlueCli reads the editor's settings but never saves them. Plugins load from the `Plugins` folder next to `GlueCli.exe`, plus the project's own `Plugins` folder.

You can leave the project open in the FlatRedBall Editor. The editor sees the changed `.gluj`, `.glsj` and `.glej` files, reloads them, and regenerates code.

Run `GlueCli --help` for the list of commands, and `GlueCli <command> --help` for a command's options and examples.

### Options for Every Command

| Option | Meaning |
|--------|---------|
| `--json` | Print one JSON object to stdout instead of text. See JSON Output below. |
| `--dry-run` | Run the command against a temp copy of the project and report what it would change. The project on disk stays exactly as it was. |
| `--help` | Show the command's options and examples. |

### Previewing an Edit with --dry-run

`--dry-run` works with every command. GlueCli copies the `.csproj` folder (skipping `bin`, `obj`, `.vs` and `.git`) to a temp folder, runs the command there in full, compares the copy with how it started, and deletes it. The edit goes through the same checks and plugin reactions as a real one, and the exit code is the one the real edit would get.

The report lists each file the run would add, change or delete, with a diff of each `.gluj`, `.glsj`, `.glej` and `.json` file:

```
add-object C:\Games\Beefball\Beefball\Beefball.csproj
Glue started in 3.3s, project loaded in 2.4s, 6.7s total.
Added SpriteInstance (FlatRedBall.Sprite) to Screens\GameScreen.
Would change (2):
  modified Screens/GameScreen.Generated.cs
  modified Screens/GameScreen.glsj
    --- a/Screens/GameScreen.glsj
    +++ b/Screens/GameScreen.glsj
    @@ -1065,6 +1065,29 @@
    ...
No new errors.
Dry run: the project on disk was not changed.
```

Art, audio and other large binary files are linked rather than copied, so a dry run stays fast on a game with a lot of content.

### Output

A run prints the command, the project, how long loading took, the files it wrote, and any errors:

```
regen C:\Games\Beefball\Beefball\Beefball.csproj
Glue started in 2.5s, project loaded in 1.5s, 4.4s total.
Files written (14):
  Beefball.csproj
  Entities/Goal.Generated.cs
  ...
No errors.
```

Edit commands report errors the project already had separately, as preexisting errors. These do not fail the run, so you can edit a project that already has problems.

### JSON Output

Pass `--json` to any command to print one JSON object to stdout. Everything else goes to stderr. The object has these properties:

| Property | Meaning |
|----------|---------|
| `command` | The command that ran. |
| `project` | The project's `.csproj` path. |
| `exitCode` | The exit code (see below). |
| `failure` | Why the run stopped, for exit code 2. |
| `editFailures` | Why the edit was not applied. |
| `edit` | What the edit did. Its shape depends on the command, and each command's page lists it. |
| `editSummary` | The same as `edit`, as the text a run prints without `--json`. |
| `errors` | The editor's error list, each with `type` and `details`. |
| `outputErrors` | Errors the editor printed to its output. |
| `dialogMessages` | Messages the editor would have shown in a dialog. |
| `preexistingErrors` | Edit commands only: errors the project had before the edit. These are not counted. |
| `filesWritten` | Files the run wrote, relative to the `.csproj` folder. |
| `startupSeconds`, `loadSeconds`, `elapsedSeconds` | How long starting the editor, loading the project, and the whole run took. |
| `dryRun` | `--dry-run` only: `true`. `filesWritten` is then empty. |
| `changes` | `--dry-run` only: each file the run would change, with `path` (relative to the `.csproj` folder), `kind` (`modified`, `added` or `deleted`) and `diff` (a unified diff for `.gluj`, `.glsj`, `.glej` and `.json` files, otherwise `null`). |

### Exit Codes

| Code | Meaning |
|------|---------|
| 0 | Done, and no new errors. |
| 1 | An edit command could not apply the edit, or the edit left errors the project did not have before. For `check`, `regen` and `describe`, the project has errors. |
| 2 | Bad arguments, the project could not be loaded, or a plugin failed to start. |

### Build Errors

GlueCli checks the project, not the game's code. After editing, build the game and read the compiler errors:

```
dotnet build MyGame/MyGame/MyGame.csproj
```

Each error names a file and a line:

```
C:\Games\Beefball\Beefball\Entities\PlayerBall.cs(34,51): error CS0103: The name 'Speed' does not exist in the current context
```

Where the error is tells you where to fix it:

* **A `.Generated.cs` file.** The generated code comes from the project, so fix the project with a GlueCli command, then run [regen](regen.md). Do not edit the `.Generated.cs` file. The next code generation overwrites it.
* **Any other file.** This is code you wrote. Fix it in the code. A common cause is a [rename](rename.md), which does not change hand-written code.

Build again until there are no errors.

### A Failed Edit Saves Nothing

GlueCli checks an edit before it changes anything. If the name is taken, the element or object does not exist, or a value does not convert to the variable's type, the run exits with code 1 and saves no changes to the project. The message says why and lists close matches:

```
Edit not applied (1):
  'Coin' is not a valid entity name: There is already an entity named Coin
1 problem(s).
```

### Questions Become Flags

The editor sometimes asks a question in the middle of an edit, such as whether to move objects to a new layer or what to do with files a delete leaves behind. GlueCli never shows a dialog. Instead, each question has a flag. For example, [set-variable](set-variable.md) has `--move-objects` and [delete](delete.md) has `--files`.

If a command needs an answer and you did not pass its flag, the run fails and the message names the flag to pass. Any message the editor would have shown in a dialog is reported, and counts as a failure.

### Commands

**Project**

| Command | Description |
|---------|-------------|
| [check](check.md) | Load the project and report every error. |
| [regen](regen.md) | Load the project, regenerate all code, and report errors. |
| [describe](describe.md) | Show what the project or one screen or entity contains. |
| [batch](batch.md) | Run several commands, one per line of a file or stdin, against one load of the project. |

**Screens and Entities**

| Command | Description |
|---------|-------------|
| [add-screen](add-screen.md) | Add a screen, optionally inheriting from another screen. |
| [add-entity](add-entity.md) | Add an entity, with the Add Entity dialog's options. |

**Objects**

| Command | Description |
|---------|-------------|
| [add-object](add-object.md) | Add an object to a screen or entity. |
| [set-variable](set-variable.md) | Set a variable on a screen or entity, or on one of its objects. |

**Files**

| Command | Description |
|---------|-------------|
| [add-file](add-file.md) | Add an existing file to a screen, an entity or Global Content. |

**Variables**

| Command | Description |
|---------|-------------|
| [add-variable](add-variable.md) | Add a variable to a screen or entity. |
| [set-variable-property](set-variable-property.md) | Set a property of a variable, such as its type or category. |
| [remove-variable](remove-variable.md) | Remove a variable from a screen or entity. |

**States**

| Command | Description |
|---------|-------------|
| [add-state-category](add-state-category.md) | Add a state category to a screen or entity. |
| [add-state](add-state.md) | Add a state to a state category. |
| [set-state-variable](set-state-variable.md) | Set or clear the value a state gives a variable. |
| [rename-state](rename-state.md) | Rename a state. |
| [rename-state-category](rename-state-category.md) | Rename a state category. |
| [delete-state](delete-state.md) | Delete a state or a whole state category. |

**Events**

| Command | Description |
|---------|-------------|
| [add-event](add-event.md) | Add an event to a screen or entity. |
| [remove-event](remove-event.md) | Remove an event from a screen or entity. |

**Collision**

| Command | Description |
|---------|-------------|
| [add-collision-relationship](add-collision-relationship.md) | Add a collision relationship between two objects in a screen. |
| [set-collision-property](add-collision-relationship.md#changing-settings-later) | Change a setting of a collision relationship, such as its physics or masses. |

**Rename, Delete and Properties**

| Command | Description |
|---------|-------------|
| [rename](rename.md) | Rename a screen, entity, object or file, and everything that refers to it. |
| [delete](delete.md) | Delete a screen, entity, object or file. |
| [set-property](set-property.md) | Set a property of a screen, entity or object, such as `LayerOn` or `BaseEntity`. |
| [set-file-property](set-file-property.md) | Set a property of a file, such as `LoadedOnlyWhenReferenced` or `RuntimeType`. |
