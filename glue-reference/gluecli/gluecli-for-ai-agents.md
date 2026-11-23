# GlueCli for AI Agents

### Introduction

[GlueCli](README.md) is the main way an AI agent should edit a FlatRedBall project. An agent can edit `.gluj`, `.glsj` and `.glej` files by hand, but it does not know the editor's rules, and it cannot tell whether an edit broke something. GlueCli applies each edit through the editor's own code, so plugins react and code is generated exactly as in the editor, and then it reports any new errors.

This page is a recipe for agents. For each command's options, follow the links to the command pages, or run `GlueCli <command> --help`.

### Why It Works Well for Agents

* **JSON output.** Pass `--json` and the run prints one JSON object to stdout. Banners and progress go to stderr.
* **Exit codes.** `0` means the edit applied with no new errors. `1` means the edit was not applied, or it added errors. `2` means bad arguments or a project that would not load. Branch on the exit code instead of reading text.
* **A failed edit saves nothing.** A run that exits with `1` leaves the project as it was, so retrying is safe.
* **Errors name close matches.** A misspelled element, object, variable or type fails with a list of names that do exist, such as `Did you mean: X?`.
* **No dialogs.** Questions the editor would ask become flags. If an answer is needed and the flag is missing, the message names the flag to pass.
* **Existing errors do not block you.** Errors the project had before the edit are reported as `preexistingErrors` and do not fail the run.

### Before You Start

* GlueCli runs on Windows only.
* `GlueCli.exe` is next to the editor's exe (`GlueFormsCore.exe`). See [Getting GlueCli](README.md#getting-gluecli).
* Make sure the project is not open in the FlatRedBall Editor. Both programs write the same files.

### The Agent Loop

#### 1. Read the Project with describe

Run [describe](describe.md) before editing. It lists the project's screens and entities, and for one element it lists the objects, variables, states, events and files, with the exact names other commands take:

```
GlueCli describe MyGame --json
GlueCli describe MyGame --element GameScreen --json
```

Use those names in your edit commands rather than guessing them or reading the JSON files.

#### 2. Edit with One Command per Change

Each change is one GlueCli run. Pick the command that matches what you would do in the editor:

| To do this | Use |
|------------|-----|
| Add a screen or entity | [add-screen](add-screen.md), [add-entity](add-entity.md) |
| Add an object | [add-object](add-object.md) |
| Set a variable on an element or object | [set-variable](set-variable.md) |
| Set a property such as `LayerOn`, `BaseEntity` or `ImplementsICollidable` | [set-property](set-property.md) |
| Add a file | [add-file](add-file.md) |
| Add, change or remove a variable | [add-variable](add-variable.md), [set-variable-property](set-variable-property.md), [remove-variable](remove-variable.md) |
| Work with states | [add-state-category](add-state-category.md), [add-state](add-state.md), [set-state-variable](set-state-variable.md), [rename-state](rename-state.md), [rename-state-category](rename-state-category.md), [delete-state](delete-state.md) |
| Add or remove an event | [add-event](add-event.md), [remove-event](remove-event.md) |
| Rename or delete anything | [rename](rename.md), [delete](delete.md) |

Rename with `rename`, `rename-state` or `rename-state-category` rather than deleting and re-adding. A rename updates everything that refers to the old name. Deleting and re-adding loses those references.

Every edit saves the project and regenerates code for the changed screens and entities, so there is no separate save or codegen step.

#### 3. Read the Result

With `--json`, check `exitCode` first:

* `0`: the edit applied. `edit` says what it did. `filesWritten` lists the files that changed.
* `1`: read `editFailures` for why the edit was not applied, or `errors` for errors the edit added. Fix the command and run it again.
* `2`: read `failure`. The arguments are wrong or the project did not load.

#### 4. Check Hand Edits

If you edit `.gluj`, `.glsj` or `.glej` files by hand, run [check](check.md) afterwards, then [regen](regen.md) to regenerate code. A non-zero exit code means the hand edit has a problem.

#### 5. Build the Game

GlueCli proves the project is valid for the editor. It does not compile the game. After editing, build the game project with `dotnet build` to confirm the generated and hand-written code still compile together.

### Things to Know

* Hand-written code is never changed. A rename updates generated code and project files, but code you wrote that uses the old name must be updated by you.
* Event handlers go into the element's `.Event.cs` file. [add-event](add-event.md) adds an empty `On<name>` method there for you to fill in.
* [delete](delete.md) keeps left-over files on disk by default, unlike the editor. Pass `--files delete` to remove them.
* Element names accept either slash and may leave out the folder when the name is unique: `GameScreen`, `Screens\GameScreen` and `Screens/GameScreen` all work. Property values picked from a list, such as `BaseEntity`, match the same way.
