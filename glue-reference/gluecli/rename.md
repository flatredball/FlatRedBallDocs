# rename

### Introduction

`rename` renames a screen, an entity, an object in one, or a file, and updates everything that refers to it. It works the way renaming in the editor's tree does.

* `--element` alone renames that screen or entity. It stays in its folder, so `Entities\Enemies\Slime --to Blob` becomes `Entities\Enemies\Blob`. Its code files move and their class names change. Derived elements, objects of its type, lists of it, collision relationships, variables of its type and the startup screen follow.
* `--element` with `--object` renames an object in that element. Variables and events that use the object, objects on it (for a Layer), and the copies in derived elements follow.
* `--file` renames a file the element (or Global Content, with `--global`) references, and the file on disk. The new name can leave out the extension to keep the old one. The file stays in its folder.

Hand-written code that names the old class or object is not changed.

To rename a state, use [rename-state](rename-state.md). To rename a variable, use [set-variable-property](set-variable-property.md) with `--property Name`.

### Usage

```
GlueCli rename <project> (--element <element> [--object <name>] | --file <file> (--element <element> | --global)) --to <new name> [options]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to rename, or that holds the object or file. |
| `--object <name>` | Rename this object in `--element` instead of the element. |
| `--file <file>` | Rename this file in `--element` or Global Content, by its name as the editor shows it (`Screens/GameScreen/Map.tmx`) or just its file name (`Map.tmx`). |
| `--global` | `--file` is in Global Content. |
| `--to <new name>` | The new name, without folders. Required. |
| `--overwrite` | Screens and entities: when code files with the new name already exist (`Entities\Blob.cs` with no Blob entity), replace them. Default: fail. |
| `--use-existing-file` | Files: when a file with the new name already exists on disk, point the file at it and leave the old one in place. Default: fail. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Rename an object:

```
GlueCli rename Beefball --element GameScreen --object Background --to Sky
```

```
Renamed object Background in Screens\GameScreen to Sky.
  changed elements: Screens\GameScreen
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Rename a file. The `.png` extension is kept:

```
GlueCli rename Beefball --element GameScreen --file Logo.png --to Banner
```

```
Renamed file Screens/GameScreen/Logo.png in Screens\GameScreen to Screens/GameScreen/Banner.png.
  moved Content/Screens/GameScreen/Logo.png -> Content/Screens/GameScreen/Banner.png
  changed elements: Screens\GameScreen
Files written (5):
  ...
No new errors.
```

Rename an entity, with JSON output. Its files move, and the lists of it in two screens follow:

```
GlueCli rename Beefball --element Entities/Coin --to Gem --json
```

```json
"edit": {
  "kind": "entity",
  "element": null,
  "oldName": "Entities\\Coin",
  "newName": "Entities\\Gem",
  "renamedFiles": [
    { "from": "Entities/Coin.glej", "to": "Entities/Gem.glej" },
    { "from": "Entities/Coin.cs", "to": "Entities/Gem.cs" },
    { "from": "Entities/Coin.Generated.cs", "to": "Entities/Gem.Generated.cs" },
    { "from": "Factories/CoinFactory.Generated.cs", "to": "Factories/GemFactory.Generated.cs" }
  ],
  "updatedReferences": [
    "list type of Screens\\GameScreen.CoinList",
    "list type of Screens\\Level2.CoinList"
  ],
  "changedElements": [
    "Entities\\Gem",
    "Screens\\GameScreen",
    "Screens\\Level2"
  ]
},
```

### JSON Output

`edit` holds `{kind, element, oldName, newName, renamedFiles, updatedReferences, changedElements}`.

* `kind` is `screen`, `entity`, `object` or `file`.
* `renamedFiles` is `[{from, to}]`, relative to the `.csproj` folder.
* `updatedReferences` lists what was pointed at the new name.
* `changedElements` lists every screen and entity the rename changed, by name after the rename.

### Failure

The run exits with code 1 and saves nothing when the target does not exist, the new name is invalid or taken, or a question the rename asks is answered no. The message lists close matches or names the flag that answers the question.

```
GlueCli rename Beefball --element GameScreen --object Sky --to HudLayer
```

```
Edit not applied (1):
  Cannot rename Sky in Screens\GameScreen to HudLayer: The name HudLayer is already being used
1 problem(s).
```
