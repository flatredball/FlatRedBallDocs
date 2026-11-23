# check

### Introduction

`check` loads the project the way the editor's **File > Load Project** does and reports every error the editor finds. Use it after you hand-edit `.gluj`, `.glsj` or `.glej` files.

Loading writes what opening the project in the editor writes (generated code and the `.csproj`), and nothing else.

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
Glue started in 4.4s, project loaded in 4.4s, 10.5s total.
Files written (14):
  Beefball.csproj
  Entities/Goal.Generated.cs
  Entities/PlayerBall.Generated.cs
  ...
No errors.
```

### Exit Codes

| Code | Meaning |
|------|---------|
| 0 | The project has no errors. |
| 1 | The project has errors. They are listed in the output. |
| 2 | Bad arguments, the project could not be loaded, or a plugin failed to start. |
