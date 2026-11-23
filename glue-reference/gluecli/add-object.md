# add-object

### Introduction

`add-object` adds an object to a screen or entity the way the editor's **Add Object** dialog does. The object gets the same default name and list placement, and the editor generates the same code. An object can be a FlatRedBall type (Sprite, Circle, Layer), a Gum type, an entity instance, a list, or an object from a file.

Without `--list`, an entity instance goes into the element's list of that entity type (or of a base type) if one exists, as in the editor. Everything else goes at the top level.

### Usage

```
GlueCli add-object <project> --element <element> (--type <type> | --source-file <file> --source-name <name>) [options]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to add to, such as `GameScreen`, `Screens\GameScreen` or `Entities\Enemy`. Either slash works. Required. |
| `--type <type>` | What to add: a FlatRedBall type by its editor name or class name (`Sprite`, `Circle`, `AxisAlignedRectangle`, `Text`, `Layer`, `TileShapeCollection`, `FlatRedBall.Sprite`), a Gum type, or an entity (`Enemy`, `Entities\Enemy`). Required unless `--source-file` is given. |
| `--name <name>` | Instance name. Default: the editor's default (`SpriteInstance`, `EnemyInstance`, `EnemyList`), numbered if taken. |
| `--list <list>` | Add into this list or ShapeCollection instead of the default placement. |
| `--no-list` | Add at the top level even if a list of this type exists. |
| `--as-list` | Add a PositionedObjectList of `<type>` instead of a single object. |
| `--source-file <file>` | Add an object from a file the element references, by its name as the editor shows it (`Screens/GameScreen/Map.tmx`) or just `Map.tmx`. Use with `--source-name`. |
| `--source-name <name>` | The object in `--source-file`, as the editor lists it, such as `"Entire File (LayeredTileMap)"` or `"SpriteInstance (Sprite)"`. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Add a Sprite named Background to GameScreen:

```
GlueCli add-object Beefball --element GameScreen --type Sprite --name Background
```

```
Added Background (FlatRedBall.Sprite) to Screens\GameScreen.
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Add a Circle to an entity, with JSON output:

```
GlueCli add-object Beefball --element Entities/Coin --type Circle --name PickupCircle --json
```

```json
"edit": {
  "element": "Entities\\Coin",
  "name": "PickupCircle",
  "sourceType": "FlatRedBallType",
  "type": "FlatRedBall.Math.Geometry.Circle",
  "genericType": null,
  "sourceFile": null,
  "sourceName": null,
  "list": null
},
"editSummary": "Added PickupCircle (FlatRedBall.Math.Geometry.Circle) to Entities\\Coin.",
"filesWritten": [
  "Entities/Coin.Generated.cs",
  "Entities/Coin.glej"
],
```

### JSON Output

`edit` holds the added object: `{element, name, sourceType, type, genericType, sourceFile, sourceName, list}`. `list` is the list the object went into, or null.

### Failure

The run exits with code 1 and saves nothing when the name is taken or invalid, the type or element does not exist, the element would contain itself, or the list cannot hold the type. The message lists close matches.

```
GlueCli add-object Beefball --element GameScreen --type Sprit
```

```
Edit not applied (1):
  No entity or object type named 'Sprit'. Did you mean: Sprite, SpriteFrame?
1 problem(s).
```
