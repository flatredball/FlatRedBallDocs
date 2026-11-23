# set-variable-property

### Introduction

`set-variable-property` sets a property of a screen's or entity's variable, the way the editor's Properties tab does with the variable selected. The editor makes the same follow-up changes to derived elements, instances and events.

Properties include `Type` (only for a new variable, not one that exposes or tunnels), `SetByDerived`, `IsShared`, `Scope`, `Category`, `Summary`, `CreatesEvent`, `HasAccompanyingVelocityProperty`, `SourceObject`, `SourceObjectProperty`, `OverridingPropertyType`, `TypeConverter` and `Name`. Setting `Name` renames the variable and what refers to it.

Only the properties the editor shows for that variable can be set. The error lists them. To change the default value, use [set-variable](set-variable.md).

### Usage

```
GlueCli set-variable-property <project> --element <element> --variable <name> --property <name> --value <text> [answers]
```

### Values

`<text>` is converted to the property's type: `true` or `false`, an enum value name (`Public`, `Private`, `Protected` or `Internal` for `Scope`), or text. A property the editor picks from a list (`Type`, `SourceObject`, `OverridingPropertyType`) must be one of the listed values.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that defines the variable. Required. |
| `--variable <name>` | The variable. Required. |
| `--property <name>` | Property name, as the Properties tab lists it. Required. |
| `--value <text>` | New value as text. Required. Pass `""` for empty text. |
| `--change-derived-types` | When changing the `Type` of a `SetByDerived` variable, also change the type of the derived elements' copies. Default: fail. |
| `--remove-instance-values` | When changing `Scope` to `Private` or `Protected`, remove the values objects using the element set for this variable. Default: fail. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

List a variable under a category:

```
GlueCli set-variable-property Beefball --element Entities/PlayerBall --variable JumpSpeed --property Category --value Movement
```

```
Set Category of Entities\PlayerBall.JumpSpeed (string): (none) -> "Movement".
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

Rename a variable, with JSON output:

```
GlueCli set-variable-property Beefball --element Entities/PlayerBall --variable JumpSpeed --property Name --value LeapSpeed --json
```

```json
"edit": {
  "element": "Entities\\PlayerBall",
  "variable": "LeapSpeed",
  "property": "Name",
  "type": "string",
  "oldValue": "JumpSpeed",
  "newValue": "LeapSpeed",
  "answers": [],
  "messages": [],
  "changedElements": [
    "Entities\\PlayerBall"
  ]
},
```

### JSON Output

`edit` holds `{element, variable, property, type, oldValue, newValue, answers, messages, changedElements}`.

* `variable` is the variable's name after the edit.
* `answers` lists `[{question, answer}]` for every question the editor asked.
* `messages` lists what the editor reported.
* `changedElements` lists every screen and entity the edit changed.

### Failure

The run exits with code 1 and saves nothing when the element, variable or property does not exist or is read-only, the text does not convert, a question has no answering option, or the editor undoes the change (an invalid or taken name, or a `Private` variable that is `SetByDerived`). The message lists close matches, the valid values, or what the editor said.

```
GlueCli set-variable-property Beefball --element Entities/PlayerBall --variable LeapSpeed --property Colour --value x
```

```
Edit not applied (1):
  Entities\PlayerBall.LeapSpeed has no property 'Colour'. Available: Category, CreatesEvent, CreatesProperty, DefinedByBase, HasAccompanyingVelocityProperty, IsShared, Name, OverridingPropertyType, PreferredDisplayerTypeName, Scope, SetByDerived, SourceObject, Summary, Type.
1 problem(s).
```
