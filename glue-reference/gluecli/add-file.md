# add-file

### Introduction

`add-file` adds an existing file (png, achx, tmx, csv, wav and others) to a screen, an entity or Global Content. It works the way dragging the file onto the element in the editor's tree does: the file gets the same name, the same `.csproj` entry and the same CSV data class, and plugins (Tiled, animation chains, Gum, CSV) react the same way.

The editor names the file by its path relative to the content folder (`Screens/GameScreen/Background.png`). Code uses its name without the extension (`Background`).

A file outside the content folder must be copied in. Pass `--copy` and the file goes into the element's content folder (`Content/Screens/GameScreen/` or `Content/GlobalContent/`). Files it references, such as an `.achx` file's images or a `.tmx` file's tilesets, are copied next to it, as the editor does.

Creating new files (the editor's **New File** dialog) and files handled by a build tool are not supported yet.

### Usage

```
GlueCli add-file <project> (--element <element> | --global) --file <path> [--copy] [--allow-unknown-type]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to add the file to. |
| `--global` | Add the file to Global Content instead of an element. |
| `--file <path>` | The file to add. Required. A relative path is tried against the current folder, then the project's content folder. |
| `--copy` | Copy a file outside the content folder into the element's content folder first. |
| `--allow-unknown-type` | Add a file whose extension the editor does not recognize (the editor's "add it anyway?"). No code is generated for it. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

Copy a png into GameScreen's content folder and add it:

```
GlueCli add-file Beefball --element GameScreen --file C:/Art/Logo.png --copy
```

```
Added Screens/GameScreen/Logo.png (Microsoft.Xna.Framework.Graphics.Texture2D) to Screens\GameScreen, copied from C:/Art/Logo.png.
Files written (4):
  Beefball.csproj
  Content/Screens/GameScreen/Logo.png
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

### JSON Output

`edit` holds `{element, name, filePath, runtimeType, csvRowType, copiedFrom}`.

* `element` is null for Global Content.
* `name` is the editor's name for the file, and `filePath` is its absolute path.
* `runtimeType` is the type the file loads as. It is null for CSVs and unknown types.
* `csvRowType` is a CSV's row class.
* `copiedFrom` is the original path when `--copy` copied the file.

### Failure

The run exits with code 1 and saves nothing when:

* The file does not exist.
* The file is outside the content folder and `--copy` was not passed.
* `--copy` would overwrite a file already there.
* The element (or Global Content) already references the file.
* The file's name is taken or invalid.
* The editor does not know the file type and `--allow-unknown-type` was not passed.

```
GlueCli add-file Beefball --element GameScreen --file C:/Art/Logo.png
```

```
Edit not applied (1):
  C:/Art/Logo.png is outside the content folder C:/Games/Beefball/Beefball/Content/. Pass --copy to copy it to C:/Games/Beefball/Beefball/Content/Screens/GameScreen/Logo.png and add the copy.
1 problem(s).
```
