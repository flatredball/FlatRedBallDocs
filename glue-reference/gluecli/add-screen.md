# add-screen

### Introduction

`add-screen` adds a screen the way the editor's **Add Screen** dialog does. It creates the same files, generates the same code, and plugins react the same way. For a project with Gum, the Gum plugin also adds a paired `<Name>Gum` screen. The first screen in a project becomes the startup screen.

The dialog's level options (tile map, collision, copying another level's entities, startup screen) are not applied. Add those objects afterwards with [add-object](add-object.md).

### Usage

```
GlueCli add-screen <project> --name <name> [--folder <folder>] [--base <screen>]
```

### Options

| Option | Description |
|--------|-------------|
| `--name <name>` | Screen name without folders, such as `Level2`. Required. |
| `--folder <folder>` | Folder under `Screens`, such as `Levels`. Default: `Screens` itself. |
| `--base <screen>` | Screen to inherit from, such as `GameScreen` or `Screens\GameScreen`. The new screen gets that screen's objects and files. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Add a screen that inherits from GameScreen:

```
GlueCli add-screen Beefball --name Level2 --base GameScreen
```

```
Added screen Screens\Level2, inheriting Screens\GameScreen. Objects: PlayerBallList, PuckList, GoalList, ScoreHudList, CoinList, Walls.
Files written (6):
  Beefball.csproj
  Beefball.gluj
  Screens/Level2.cs
  ...
No new errors.
```

Add a screen with JSON output:

```
GlueCli add-screen Beefball --name TitleScreen --json
```

```json
"edit": {
  "name": "Screens\\TitleScreen",
  "baseScreen": null,
  "isStartupScreen": false,
  "objects": []
},
```

### JSON Output

`edit` holds `{name, baseScreen, isStartupScreen, objects}`. `objects` lists the screen's own object names, such as the Gum screen object.

### Failure

The run exits with code 1 and saves nothing when the name is invalid or already used by a screen, entity or file, the folder name is invalid, or the base screen does not exist. The message lists close matches.
