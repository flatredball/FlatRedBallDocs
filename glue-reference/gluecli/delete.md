# delete

### Introduction

`delete` deletes a screen, an entity, an object in one, or a file, the way the editor's **Delete** does. It answers the editor's delete dialog from the flags below.

What goes with the target goes as in the editor:

* Deleting an entity removes every object of that entity in other screens and entities.
* Deleting an object removes its collision relationships, tunneled variables and event responses.
* Deleting a screen or entity resets the base of the elements that inherit from it.

To delete a state or state category, use [delete-state](delete-state.md). To delete a variable or event, use [remove-variable](remove-variable.md) or [remove-event](remove-event.md).

### Usage

```
GlueCli delete <project> (--element <element> [--object <object> | --file <file>] | --global --file <file>) [--files <action>] [--keep-inheritance] [--keep-objects] [--keep-gum-screen]
```

`--element` alone deletes that screen or entity. With `--object` it deletes that object in the element, including objects in lists. With `--file` it deletes that file of the element. `--global --file` deletes a Global Content file.

`<file>` is the file's name in the editor (`Screens/GameScreen/Background.png`), its name in code (`Background`), or its path on disk.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | The screen or entity to delete, or that holds the object or file. |
| `--global` | The file is in Global Content. Use with `--file`. |
| `--object <object>` | Delete this object of the element instead of the element. |
| `--file <file>` | Delete this file of the element, or of Global Content with `--global`. |
| `--files <action>` | What happens to files the delete leaves unused (see below). |
| `--keep-inheritance` | Do not reset the base of elements that inherit from a deleted element. They are left with a missing base. This is the dialog's "Reset the inheritance for X", unchecked. |
| `--keep-objects` | When deleting a file, keep the objects that use it. Their file reference is cleared. This is the dialog's "Remove the object X, which references this file", unchecked. |
| `--keep-gum-screen` | When deleting a screen, keep its Gum screen. |
| `--json` | Print one JSON object to stdout instead of text. |

Any other option a plugin adds to the dialog keeps its default, and is listed in the output.

### Left-Over Files

`--files` decides what happens to the files a delete leaves unused, such as the element's `.cs`, `.Generated.cs`, factory and `.glej`/`.glsj`, a removed file itself, or a CSV's data class:

| Value | Result |
|-------|--------|
| `remove-from-project` | Default. Takes them out of the `.csproj` and keeps them on disk. |
| `delete` | Also moves them to the recycle bin. |
| `leave` | Keeps them in the `.csproj` too. |

{% hint style="info" %}
The editor's dialog defaults to deleting the files. GlueCli defaults to keeping them on disk.
{% endhint %}

Deleting an entity always deletes its factory (`Factories/<Name>Factory.Generated.cs`), whatever `--files` says. The editor does the same, because removing the entity removes its factory. That is why the example below lists the factory with `onDisk: false`.

### Examples

Delete an object:

```
GlueCli delete Beefball --element GameScreen --object Sky
```

```
Deleted object Sky from Screens\GameScreen.
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Delete a file, by its name in code:

```
GlueCli delete Beefball --element GameScreen --file Banner
```

```
Deleted file Screens/GameScreen/Banner.png from Screens\GameScreen.
Left-over files (--files remove-from-project):
  Content/Screens/GameScreen/Banner.png: kept on disk, not in the .csproj
Files written (3):
  Beefball.csproj
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Delete an entity, with JSON output. The lists of it in two screens go with it:

```
GlueCli delete Beefball --element Entities/Gem --json
```

```json
"edit": {
  "kind": "entity",
  "name": "Entities\\Gem",
  "element": null,
  "alsoRemoved": [
    "FlatRedBall.Math.PositionedObjectList<Gem> CoinList in Screens\\GameScreen (Screen)",
    "FlatRedBall.Math.PositionedObjectList<Gem> CoinList in Screens\\Level2 (Screen)"
  ],
  "options": [],
  "warnings": [],
  "fileAction": "remove-from-project",
  "files": [
    { "path": "Entities/Gem.cs", "onDisk": true, "inProject": false },
    { "path": "Entities/Gem.Generated.cs", "onDisk": true, "inProject": false },
    { "path": "Factories/GemFactory.Generated.cs", "onDisk": false, "inProject": false },
    { "path": "Entities/Gem.glej", "onDisk": true, "inProject": false }
  ]
},
```

### JSON Output

`edit` holds `{kind, name, element, alsoRemoved, options, warnings, fileAction, files}`.

* `kind` is `screen`, `entity`, `object` or `file`.
* `element` is the containing element. It is null for a deleted screen or entity, or a Global Content file.
* `alsoRemoved` lists what the delete removed with the target.
* `options` are the dialog's options, each `{text, checked}`.
* `warnings` are what the dialog would have warned about.
* `fileAction` is the `--files` value.
* `files` lists each left-over file as `{path, onDisk, inProject}` after the delete, with `path` relative to the `.csproj` folder.

### Failure

The run exits with code 1 and saves nothing when the element, object or file does not exist, or when the object is defined by a base element that exposes it to derived elements. The message lists close matches.

```
GlueCli delete Beefball --element Entities/Gem
```

```
Edit not applied (1):
  No screen or entity named 'Entities/Gem'. Available: Entities\Goal, Entities\PlayerBall, Entities\Puck, Entities\ScoreHud, Screens\GameScreen, Screens\Level2, Screens\TitleScreen.
1 problem(s).
```
