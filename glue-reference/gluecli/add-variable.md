# add-variable

### Introduction

`add-variable` adds a variable to a screen or entity the way the editor's **Add Variable** window does, with the window's defaults and checks. It supports the window's three kinds of variable:

* `--name N --type T` adds a new variable. `T` is a type the window lists: `float`, `int`, `bool`, `string`, `double`, `decimal`, `byte`, `long`, the nullable ones (`float?`), `Color`, `Texture2D`, `Keys`, a CSV's class, or a state category (`Entities\Enemy.Movement` or the category's name).
* `--tunnel Obj.Var` adds a variable that sets `Var` on the object `Obj`, at any depth. Its name defaults to `ObjVar`, as in the window, and `--name` overrides it. Its default is the value the object has for `Var`.
* `--expose Var` exposes a built-in variable of the element, such as `X`, `Visible` or `Enabled`.

### Usage

```
GlueCli add-variable <project> --element <element> (--name <name> --type <type> | --tunnel <object>.<variable> [--name <name>] | --expose <variable>) [options]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to add the variable to. Required. |
| `--name <name>` | Variable name. Required with `--type`. Optional with `--tunnel`. |
| `--type <type>` | Type of a new variable. |
| `--tunnel <object.variable>` | Tunnel into this object's variable. |
| `--expose <variable>` | Expose this built-in variable of the element. |
| `--default <text>` | Default value, converted to the variable's type as [set-variable](set-variable.md) does. |
| `--set-by-derived <true\|false>` | Whether derived elements can set it. Ignored when the variable is static. Default: `true`. |
| `--static <true\|false>` | Whether the variable is static (shared). Default: `true` when every other variable except X, Y and Z is static, unless tunneling. |
| `--list` | Make a new variable a `List` of its type. Works for `string`, and for `float` and `int` in JSON projects. |
| `--category <name>` | Category to list it under. For a tunneled variable, the window replaces this with the object's category. |
| `--summary <text>` | Summary, written as the XML doc comment in generated code. |
| `--overriding-type <type>` | Tunneled variables only: expose the variable as another type. |
| `--type-converter <name>` | Tunneled variables only, with `--overriding-type`: the converter. Default: the window's first converter. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Add a new float variable with a default:

```
GlueCli add-variable Beefball --element Entities/PlayerBall --name JumpSpeed --type float --default 250
```

```
Added new variable Entities\PlayerBall.JumpSpeed (float), default 250.
  SetByDerived: True, static: False
  changed elements: Entities\PlayerBall
Files written (3):
  Content/TiledObjects.Generated.xml
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

Tunnel into an object's variable, with JSON output:

```
GlueCli add-variable Beefball --element Entities/Coin --tunnel SpriteInstance.Visible --name SpriteVisible --json
```

```json
"edit": {
  "element": "Entities\\Coin",
  "name": "SpriteVisible",
  "kind": "tunneled",
  "type": "bool",
  "sourceObject": "SpriteInstance",
  "sourceObjectProperty": "Visible",
  "defaultValue": true,
  "setByDerived": true,
  "isShared": false,
  "category": "Appearance",
  "changedElements": [
    "Entities\\Coin"
  ]
},
```

### JSON Output

`edit` holds `{element, name, kind, type, sourceObject, sourceObjectProperty, defaultValue, setByDerived, isShared, category, changedElements}`.

* `kind` is `new`, `tunneled` or `exposed`.
* `changedElements` lists every screen and entity the add changed. Derived elements get the variable too.

### Failure

The run exits with code 1 and saves nothing when the element, type, object or variable does not exist, the name is taken or invalid, the object's variable is already tunneled, or the default does not convert. The message says why and lists close matches.

```
GlueCli add-variable Beefball --element Entities/PlayerBall --name Drag --type float
```

```
Edit not applied (1):
  Cannot add Drag to Entities\PlayerBall: This Entity already has a variable named Drag. Pick another --name.
1 problem(s).
```
