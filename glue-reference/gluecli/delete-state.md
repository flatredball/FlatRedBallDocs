# delete-state

### Introduction

`delete-state` deletes a state, or a whole state category, from a screen or entity. It works the way the editor's **Delete** does, and answers the editor's delete dialog from the flags below.

* `--state` deletes that state from the category.
* `--whole-category` deletes the category and its states. Every variable typed as the category, in any screen or entity, goes with it, as in the editor.

### Usage

```
GlueCli delete-state <project> --element <element> --category <category> (--state <state> | --whole-category) [--keep-variables]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the category. Required. |
| `--category <category>` | State category of the state, or the category to delete. Required. |
| `--state <state>` | State to delete. |
| `--whole-category` | Delete the category and its states instead of one state. |
| `--keep-variables` | When deleting a state from an older project's uncategorized state list, keep the variables left with no state. This is the dialog's "Remove the variable X..." option, unchecked. Categorized states never ask this. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Delete one state:

```
GlueCli delete-state Beefball --element Entities/PlayerBall --category Health --state Hurt
```

```
Deleted state Hurt from Health in Entities\PlayerBall.
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

Delete the whole category, with JSON output:

```
GlueCli delete-state Beefball --element Entities/PlayerBall --category Health --whole-category --json
```

```json
"edit": {
  "kind": "category",
  "element": "Entities\\PlayerBall",
  "category": "Health",
  "state": null,
  "alsoRemoved": [],
  "options": [],
  "changedElements": [
    "Entities\\PlayerBall"
  ]
},
```

### JSON Output

`edit` holds `{kind, element, category, state, alsoRemoved, options, changedElements}`.

* `kind` is `state` or `category`.
* `state` is null when deleting a category.
* `alsoRemoved` lists the variables the delete removed with it.
* `options` are the dialog's options, each `{text, checked}`.

### Failure

The run exits with code 1 and saves nothing when the element, category or state does not exist. The message lists close matches.
