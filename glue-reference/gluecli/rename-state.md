# rename-state

### Introduction

`rename-state` renames a state the way the editor's Properties tab does, and updates what uses it. Variables whose value is the old state, objects whose `CurrentState` or state variable is the old state, and states in other elements that set it all follow. Hand-written code is not changed.

To rename a state category, use [rename-state-category](rename-state-category.md).

### Usage

```
GlueCli rename-state <project> --element <element> --category <category> --state <state> --to <new name>
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the category. Required. |
| `--category <category>` | State category of the state. Required. |
| `--state <state>` | State to rename. Required. |
| `--to <new name>` | The new name. Required. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli rename-state Beefball --element Entities/PlayerBall --category Health --state Wounded --to Hurt
```

```
Renamed state Wounded in Health of Entities\PlayerBall to Hurt.
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

### JSON Output

`edit` holds `{element, category, oldName, newName, changedElements}`.

### Failure

The run exits with code 1 and saves nothing when the element, category or state does not exist, or the new name is invalid or already used in the category. The message lists close matches.
