# set-state-variable

### Introduction

`set-state-variable` sets or clears the value a state gives one of the element's variables, the way a cell of the editor's **State Data** tab does.

A state can only set a variable its category includes. Pass `--include` to include the variable in the category first, as the State Data tab's include button does. Without it, the run fails. Static (shared) variables and list-typed variables can never be in a state.

### Usage

```
GlueCli set-state-variable <project> --element <element> --category <category> --state <state> --variable <name> (--value <text> | --clear) [--include]
```

### Values

`<text>` is converted to the variable's type with invariant culture, such as `1.5`, `true` or an enum value name. Files, colors and states are stored as text, as the editor stores them. `--clear` removes the value, so the state leaves the variable alone.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the category. Required. |
| `--category <category>` | State category of the state. Required. |
| `--state <state>` | State to change. Required. |
| `--variable <name>` | The element's variable. Required. |
| `--value <text>` | New value as text. |
| `--clear` | Remove the state's value for the variable instead of setting one. |
| `--include` | Include the variable in the category when it is excluded. Default: fail. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Make the Wounded state slow the ball down:

```
GlueCli set-state-variable Beefball --element Entities/PlayerBall --category Health --state Wounded --variable MovementSpeed --value 80
```

```
Set Entities\PlayerBall.Health.Wounded.MovementSpeed (float): (not set) -> 80.
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

Include a variable in the category and set it, with JSON output:

```
GlueCli set-state-variable Beefball --element Entities/PlayerBall --category Health --state Wounded --variable DashSpeed --value 100 --include --json
```

```json
"edit": {
  "element": "Entities\\PlayerBall",
  "category": "Health",
  "state": "Wounded",
  "variable": "DashSpeed",
  "type": "float",
  "oldValue": null,
  "newValue": 100,
  "includedVariable": true,
  "changedElements": [
    "Entities\\PlayerBall"
  ]
},
```

### JSON Output

`edit` holds `{element, category, state, variable, type, oldValue, newValue, includedVariable, changedElements}`.

* `oldValue` and `newValue` are null when the state does not set the variable.
* `includedVariable` is true when `--include` added the variable to the category.

### Failure

The run exits with code 1 and saves nothing when the element, category, state or variable does not exist, the category excludes the variable and `--include` was not passed, or the text does not convert to the variable's type. The message lists close matches, names the expected type, or names the flag to pass.

```
GlueCli set-state-variable Beefball --element Entities/PlayerBall --category Health --state Wounded --variable DashSpeed --value 100
```

```
Edit not applied (1):
  Health in Entities\PlayerBall excludes DashSpeed, so its states cannot set it. Pass --include to include it in the category.
1 problem(s).
```
