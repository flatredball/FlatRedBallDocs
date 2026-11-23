# check

### Introduction

`check` loads the project and reports every error the editor finds. Use it after you hand-edit `.gluj`, `.glsj` or `.glej` files.

`check` does not regenerate code or save anything, unlike opening the project in the editor. The one exception is a project that has never had its code generated: plugins such as Gum and Tiled write their generated code while the project loads. Run [regen](regen.md) to bring generated code up to date.

### Usage

```
GlueCli check <project> [--json]
```

### Options

| Option | Description |
|--------|-------------|
| `<project>` | A `.gluj`, a `.csproj`, or a folder containing exactly one `.gluj`. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli check Beefball
```

```
check C:\Games\Beefball\Beefball\Beefball.csproj
Glue started in 2.5s, project loaded in 1.5s, 4.0s total.
No errors.
```

### Exit Codes

| Code | Meaning |
|------|---------|
| 0 | The project has no errors. |
| 1 | The project has errors. They are listed in the output. |
| 2 | Bad arguments, the project could not be loaded, or a plugin failed to start. |
