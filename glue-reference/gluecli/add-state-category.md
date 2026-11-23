# add-state-category

### Introduction

`add-state-category` adds a state category to a screen or entity, the way the editor's **Add State Category** does. The element's code is regenerated with the category's enum and state properties.

A category's states can only set the variables the category includes. Like the editor, a new category includes none of the element's variables.

* `--include` names the variables to include.
* `--exclude` includes every variable except the ones named.

Static (shared) variables and list-typed variables cannot be in a state. `--exclude` skips them, and `--include` fails on them.

After adding a category, add states with [add-state](add-state.md) and set their values with [set-state-variable](set-state-variable.md).

### Usage

```
GlueCli add-state-category <project> --element <element> --name <name> [--include <var,...> | --exclude <var,...>]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to add the category to. Required. |
| `--name <name>` | Name of the new category. Required. |
| `--include <var,...>` | Variables the category's states set, separated by commas. Default: none. |
| `--exclude <var,...>` | Include every variable except these, separated by commas. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli add-state-category Beefball --element Entities/PlayerBall --name Health --include MovementSpeed,Drag
```

```
Added state category Health to Entities\PlayerBall.
  includes: MovementSpeed, Drag
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

### JSON Output

`edit` holds `{element, category, includedVariables, excludedVariables, changedElements}`.

### Failure

The run exits with code 1 and saves nothing when the element does not exist, the name is invalid or already used by a category of the element or its base, or a variable does not exist or cannot be included. The message lists close matches.

```
GlueCli add-state-category Beefball --element Entities/PlayerBall --name Health2 --include MovementSped
```

```
Edit not applied (1):
  Entities\PlayerBall has no variable 'MovementSped'. Did you mean: MovementSpeed?
1 problem(s).
```
