# rename-state-category

### Introduction

`rename-state-category` renames a state category the way the editor's State Data tab does, and updates what uses it:

* Variables typed as the category follow, in any screen or entity.
* The category's `Current<Category>State` variable is renamed in the element and in the elements that inherit it. States, events, instance variables and tunneled variables that set it follow too.

Hand-written code is not changed.

### Usage

```
GlueCli rename-state-category <project> --element <element> --category <category> --to <new name>
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the category. Required. |
| `--category <category>` | State category to rename. Required. |
| `--to <new name>` | The new name. Required. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli rename-state-category Beefball --element Entities/PlayerBall --category DashCategory --to DashState
```

```
Renamed state category DashCategory in Entities\PlayerBall to DashState.
  changed elements: Entities\PlayerBall
Files written (3):
  Content/TiledObjects.Generated.xml
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

### JSON Output

`edit` holds `{element, oldName, newName, changedElements}`.

### Failure

The run exits with code 1 and saves nothing when:

* The element or category does not exist.
* The new name is invalid.
* The element, its base or a derived element already has a category with that name.
* `Current<new name>State` is already a variable there.

The message lists close matches.

```
GlueCli rename-state-category Beefball --element Entities/PlayerBall --category DashCategory --to X
```

```
Edit not applied (1):
  Entities\PlayerBall has no state category 'DashCategory'. Available: DashState.
1 problem(s).
```
