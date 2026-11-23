# add-state

### Introduction

`add-state` adds a state to a state category of a screen or entity, the way the editor's **Add State** does. The new state sets no variables. Set them with [set-state-variable](set-state-variable.md).

### Usage

```
GlueCli add-state <project> --element <element> --category <category> --name <name>
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the category. Required. |
| `--category <category>` | State category to add the state to. Required. |
| `--name <name>` | Name of the new state. Required. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli add-state Beefball --element Entities/PlayerBall --category Health --name Wounded
```

```
Added state Wounded to Health in Entities\PlayerBall.
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

### JSON Output

`edit` holds `{element, category, state, changedElements}`.

### Failure

The run exits with code 1 and saves nothing when the element or category does not exist, or the name is invalid or already used by a state in the category (or the same category of the element's base). The message lists close matches.
