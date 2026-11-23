# set-property

### Introduction

`set-property` sets a property of a screen, an entity, or an object in one, the way the editor's Properties tab does. It stores the same value, and the editor makes the same follow-up changes. Properties are an object's or element's own settings. Variables such as `X`, `Width` or a variable the element defines go through [set-variable](set-variable.md).

With `--object`, it sets a property of that object at any depth, such as `LayerOn`, `AttachToCamera`, `AttachToContainer`, `IsContainer`, `ExposedInDerived`, `SetByDerived`, `IncludeInIVisible`, `IncludeInIClickable`, `IncludeInICollidable`, `CallActivity`, `IgnoresPausing`, `HasPublicProperty`, `IsDisabled`, `SourceClassType`, `SourceFile`, `SourceName` and `CurrentState`.

Without `--object`, it sets a property of the screen or entity, such as `BaseEntity`, `BaseScreen`, `NextScreen`, `ImplementsICollidable`, `ImplementsIVisible`, `ImplementsIClickable`, `CreatedByOtherEntities`, `PooledByFactory`, `UseGlobalContent`, and plugin properties such as `ImplementsIDamageable`.

Only properties the editor shows for that target can be set. For example, `AttachToCamera` exists only for objects in a screen. The error lists the properties that can be set. To change a name, use [rename](rename.md).

### Usage

```
GlueCli set-property <project> --element <element> [--object <name>] --property <name> --value <text> [answers]
```

### Values

`<text>` is converted to the property's type: `true` or `false`, an enum value name, a number, or text. A property the editor picks from a list (`LayerOn`, `BaseEntity`, `SourceClassType`, `SourceFile`) must be one of the listed values. Case does not matter and either slash works, so `Entities/Puck` matches `Entities\Puck`. An element may leave out its folder when the name is unique. `<NONE>` clears it.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the property, or holds the object. Required. |
| `--object <name>` | Object in the element whose property to set. Default: the element's own property. |
| `--property <name>` | Property name, as the Properties tab lists it, without spaces. Required. |
| `--value <text>` | New value as text. Required. Pass `""` for empty text. |
| `--json` | Print one JSON object to stdout instead of text. |

### Answers

Some changes make the editor ask a question. Each question has an option that answers it, and each option below states its default. "Default: fail" means the run fails without the option, saves no changes, and names the option to pass. Any other default is what the run does without the option.

| Option | Description |
|--------|-------------|
| `--apply-to-list` | `LayerOn` or `AttachToCamera` on a list: also set it on every object in the list. Default: only the list. |
| `--container-base <set\|ignore>` | `IsContainer` when the object's type is not the entity's base: `set` makes the entity inherit from the object's type, `ignore` leaves it (may not compile). Default: fail. |
| `--ignore-missing-variables` | `SourceClassType`: switch even though the new entity lacks variables this object sets. Default: fail. |
| `--base-object-type <update\|ignore>` | `SourceName` when the base element's object of that name is untyped: `update` gives it this object's type, `ignore` leaves it. Default: fail. |
| `--derived-objects <remove\|keep>` | `SetByDerived` false while derived elements have the object: remove them, or keep them as their own objects. Default: fail. |
| `--reset-variables` | `PooledByFactory`: add reset variables for every object (turning it on) or remove them (turning it off). Default: leave them. |
| `--visible-variable <remove\|keep>` | `ImplementsIVisible` false while the entity exposes a `Visible` variable: remove it, or keep it as a plain variable. Default: fail. |
| `--non-visible-objects <make\|ignore>` | `ImplementsIVisible` true while an object's entity is not IVisible: make that entity IVisible, or leave it. Default: fail. |
| `--lost-variables <keep\|drop>` | `BaseEntity`: variables the new base does not have are kept as the entity's own variables, or dropped. Default: fail. |
| `--orphaned-objects <remove\|keep>` | `BaseEntity` or `BaseScreen`: objects marked defined-by-base that no base has are removed, or kept as the element's own. Default: fail. |
| `--referenced-global <set\|ignore>` | `UseGlobalContent` true: also make every entity its objects use load globally, or leave them (may fail at runtime). Default: fail. |

### Examples

Put an object on a Layer in the same screen:

```
GlueCli set-property Beefball --element GameScreen --object ScoreHud1 --property LayerOn --value HudLayer
```

```
Set ScoreHud1.LayerOn in Screens\GameScreen (string): (none) -> "HudLayer".
  changed elements: Screens\GameScreen
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Make an entity IVisible:

```
GlueCli set-property Beefball --element Entities/Puck --property ImplementsIVisible --value true
```

```
Set Entities\Puck.ImplementsIVisible (bool): false -> true.
  changed elements: Entities\Puck
Files written (2):
  Entities/Puck.Generated.cs
  Entities/Puck.glej
No new errors.
```

Change an entity's base, keeping variables the new base lacks:

```
GlueCli set-property MyGame --element Entities\Boss --property BaseEntity --value Entities\Enemy --lost-variables keep
```

### JSON Output

`edit` holds `{element, object, property, type, oldValue, newValue, answers, messages, changedElements}`.

* `object` is null for an element property.
* `answers` lists `[{question, answer}]` for every question the editor asked.
* `messages` lists what the editor reported while reacting, such as "IWindows must also be IVisible".
* `changedElements` lists every screen and entity the edit changed.

### Failure

The run exits with code 1 and saves nothing when the element, object or property does not exist or is read-only, the text does not convert, or the editor undoes the change (for example, a second `IsContainer` object). The message lists close matches, the valid values, or what the editor said.

```
GlueCli set-property Beefball --element GameScreen --object ScoreHud1 --property LayerOn --value NoSuchLayer
```

```
Edit not applied (1):
  'NoSuchLayer' is not a valid value for LayerOn of ScoreHud1 in Screens\GameScreen. Valid values: <NONE>, Under Everything (Engine Layer), HudLayer, Top Layer (Engine Layer).
1 problem(s).
```
