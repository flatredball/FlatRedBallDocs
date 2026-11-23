# regen

### Introduction

`regen` loads the project the same way as [check](check.md), then regenerates the code for every screen, entity and Global Content, along with the code plugins write for the whole project, such as Gum runtimes, Tiled classes and the camera setup. It waits for queued work, saves the `.csproj`, and reports errors.

Run `regen` once after cloning or pulling, or whenever generated code is out of date. Edit commands regenerate only what they change, and `check` regenerates nothing. Generated files are usually not in source control, so a fresh clone does not build until `regen` runs. The same goes for project files changed outside GlueCli, such as hand edits or a pull.

### Usage

```
GlueCli regen <project> [--json]
```

### Options

| Option | Description |
|--------|-------------|
| `<project>` | A `.gluj`, a `.csproj`, or a folder containing exactly one `.gluj`. |
| `--json` | Print one JSON object to stdout instead of text. `filesWritten` lists the files that changed. |

### Example

```
GlueCli regen Beefball
```

```
regen C:\Games\Beefball\Beefball\Beefball.csproj
Glue started in 2.6s, project loaded in 2.1s, 4.9s total.
No errors.
```

`Files written` lists only files whose contents changed. When the generated code is already current, as here, nothing is listed.

### Exit Codes

| Code | Meaning |
|------|---------|
| 0 | The project has no errors. |
| 1 | The project has errors. They are listed in the output. |
| 2 | Bad arguments, the project could not be loaded, or a plugin failed to start. |
