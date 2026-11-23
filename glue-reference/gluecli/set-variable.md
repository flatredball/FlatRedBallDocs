# set-variable

### Introduction

`set-variable` sets a variable the way the editor's Variables tab does. It stores the same value, and plugins and code generation react the same way.

* Without `--object`, it sets the default value of a variable the screen or entity defines.
* With `--object`, it sets a variable on that object, at any depth. Objects inside lists and ShapeCollections work too. An entity instance only has the variables its entity defines or exposes.

Object properties such as `LayerOn`, `AttachToCamera`, `IsContainer` and `SourceClassType` are not variables. Use [set-property](set-property.md) for those.

### Usage

```
GlueCli set-variable <project> --element <element> [--object <name>] --variable <name> --value <text>
```

### Values

`<text>` is converted to the variable's type with invariant culture, such as `1.5`, `true` or an enum value name. Files, colors, states and CSV values are stored as text, as the editor stores them. For example, use `--value Red` for a Color and a state's name for a state. `--value "<NONE>"` clears a Sprite or AnimationChainList reference.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that holds the variable or the object. Required. |
| `--object <name>` | Object in the element whose variable to set. Default: the element's own variable. |
| `--variable <name>` | Variable name. Required. |
| `--value <text>` | New value as text. Required. Pass `""` for an empty string. |
| `--move-objects` | When setting a screen's `DefaultLayer`, move the objects on the old layer to the new one. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Move a Sprite in GameScreen:

```
GlueCli set-variable Beefball --element GameScreen --object Background --variable X --value 120.5
```

```
Set Background.X in Screens\GameScreen (float): (default) -> 120.5.
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Override an entity variable on one instance:

```
GlueCli set-variable Beefball --element GameScreen --object PlayerBall1 --variable MovementSpeed --value 450
```

Set a Color:

```
GlueCli set-variable Beefball --element Entities/PlayerBall --object CircleInstance --variable Color --value Red
```

### Moving Objects to a New Default Layer

Setting a screen's `DefaultLayer` makes the editor ask whether to move the objects on the old layer to the new one. Pass `--move-objects` to move them. Without it, the question goes unanswered and the run fails. The editor only asks when objects are on the old layer, so the first time you set `DefaultLayer` no answer is needed:

```
GlueCli set-variable Beefball --element GameScreen --variable DefaultLayer --value HudLayer
```

```
Set Screens\GameScreen.DefaultLayer (string): (default) -> "HudLayer".
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

### JSON Output

`edit` holds `{element, object, variable, type, oldValue, newValue, movedObjects}`.

* `object` is null for an element's own variable.
* `oldValue` is null when the variable was not set (the object used its default).
* `movedObjects` lists the objects `--move-objects` put on the new layer.

### Failure

The run exits with code 1 and saves nothing when the element, object or variable does not exist, or the text does not convert to the variable's type. The message lists close matches or names the expected type.

```
GlueCli set-variable Beefball --element GameScreen --object Background --variable Xx --value 1
```

```
Edit not applied (1):
  Background (FlatRedBall.Sprite) has no variable 'Xx'. Did you mean: X?
1 problem(s).
```
