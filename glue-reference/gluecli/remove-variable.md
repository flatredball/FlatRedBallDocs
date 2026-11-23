# remove-variable

### Introduction

`remove-variable` removes a variable from a screen or entity the way the editor's **Delete** does on a variable. It works for new, tunneled and exposed variables. What goes with the variable goes as in the editor: events the variable raises are removed, and derived elements lose their copy of it.

The editor only asks "Are you sure?", which GlueCli answers yes, so this command has no answer flags.

Objects in other elements that set the variable on an instance keep that value, as in the editor. The run reports them, and fails if that leaves errors.

### Usage

```
GlueCli remove-variable <project> --element <element> --variable <name>
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that defines the variable. Required. |
| `--variable <name>` | The variable to remove. Required. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli remove-variable Beefball --element Entities/PlayerBall --variable LeapSpeed
```

```
Removed Entities\PlayerBall.LeapSpeed (float).
  changed elements: Entities\PlayerBall
Files written (3):
  Content/TiledObjects.Generated.xml
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

### JSON Output

`edit` holds `{element, variable, type, removedEvents, instancesSettingIt, changedElements}`.

* `removedEvents` lists the events removed with the variable.
* `instancesSettingIt` lists the `Element.Object` pairs that still set it.
* `changedElements` lists every screen and entity the removal changed.

### Failure

The run exits with code 1 and saves nothing when the element or variable does not exist, or when the variable comes from a base element. Remove it from the base element instead. The message lists close matches.

```
GlueCli remove-variable Beefball --element Entities/PlayerBall --variable LeapSpeed
```

```
Edit not applied (1):
  Entities\PlayerBall has no variable 'LeapSpeed'. Available: CircleInstanceColor, CooldownCircleColor, CooldownCircleRadius, DashFrequency, DashSpeed, Drag, MovementSpeed, X, Y, Z.
1 problem(s).
```
