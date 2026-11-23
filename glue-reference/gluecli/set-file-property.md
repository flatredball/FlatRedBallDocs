# set-file-property

### Introduction

`set-file-property` sets a property of a file in a screen, an entity or Global Content, the way the editor's Properties tab does when the file is selected. It stores the same value, and the editor makes the same follow-up changes. Then it regenerates the code of the file's screen or entity, or `GlobalContent.Generated.cs` for a Global Content file.

Which properties a file has depends on the file and where it lives. Most files have `LoadedAtRuntime`, `LoadedOnlyWhenReferenced`, `HasPublicProperty`, `IncludeDirectoryRelativeToContainer`, `RuntimeType`, `UseContentPipeline`, `AddToManagers`, `SourceFile`, `BuildTool`, `AdditionalArguments` and `Summary`. Some appear only in certain cases:

* `IsSharedStatic` only for a file in a screen.
* `DestroyOnUnload` only for a `Song` that is not in an entity.
* `CreatesDictionary`, `IsDatabaseForLocalizing`, `UniformRowType` and `CsvDelimiter` only for a CSV.
* `TreatAsCsv` only for a `.txt` file.
* A file that is not `LoadedAtRuntime` has none of the loading properties.

Only properties the editor shows for that file can be set. The error lists the ones that can. To change a file's name, use [rename](rename.md).

### Usage

```
GlueCli set-file-property <project> (--element <element> | --global) --file <file> --property <name> --value <text> [--add-to-managers]
```

`<file>` is the file's name in Glue (`Screens/GameScreen/Background.png`), its name in code when only one file has it (`Background`), or its path on disk.

### Values

`<text>` is converted to the property's type: `true` or `false`, an enum value name, a number, or text. A property the editor picks from a list (`RuntimeType`, `UniformRowType`, `BuildTool`) must be one of the listed values. Case does not matter.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity that has the file. |
| `--global` | The file is in Global Content. Pass this or `--element`. |
| `--file <file>` | The file. Required. |
| `--property <name>` | Property name, as the Properties tab lists it, without spaces. Required. |
| `--value <text>` | New value as text. Required. Pass `""` for empty text. |
| `--add-to-managers` | `IsSharedStatic` true while an object in the screen made from the file has `AddToManagers` off: turn `AddToManagers` on for it. Default: leave it. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Load an entity's png only when code first uses it:

```
GlueCli set-file-property Beefball --element PlayerBall --file BallTexture --property LoadedOnlyWhenReferenced --value true
```

```
Set Entities/PlayerBall/BallTexture.png.LoadedOnlyWhenReferenced in Entities\PlayerBall (bool): false -> true.
  changed elements: Entities\PlayerBall
Files written (2):
  Entities/PlayerBall.Generated.cs
  Entities/PlayerBall.glej
No new errors.
```

Load a .wav as a `SoundEffectInstance`:

```
GlueCli set-file-property Beefball --element GameScreen --file Hit --property RuntimeType --value Microsoft.Xna.Framework.Audio.SoundEffectInstance
```

```
Set Screens/GameScreen/Hit.wav.RuntimeType in Screens\GameScreen (string): "Microsoft.Xna.Framework.Audio.SoundEffect" -> "Microsoft.Xna.Framework.Audio.SoundEffectInstance".
  changed elements: Screens\GameScreen
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

Load a Global Content CSV only when code first uses it:

```
GlueCli set-file-property Beefball --global --file GlobalContent/EnemyInfo.csv --property LoadedOnlyWhenReferenced --value true
```

```
Set GlobalContent/EnemyInfo.csv.LoadedOnlyWhenReferenced in Global Content (bool): false -> true.
Files written (2):
  Beefball.gluj
  GlobalContent.Generated.cs
No new errors.
```

### JSON Output

`edit` holds `{element, file, property, type, oldValue, newValue, answers, messages, changedElements}`.

* `element` is null for a Global Content file.
* `answers` lists `[{question, answer}]` for every question the editor asked.
* `messages` lists what the editor reported while reacting.
* `changedElements` lists every screen and entity the edit changed.

### Failure

The run exits with code 1 and saves nothing when the element, file or property does not exist or is read-only, the text does not convert, or the editor does not keep the value. The message lists close matches or the valid values.

```
GlueCli set-file-property Beefball --element PlayerBall --file BallTexture --property IsSharedStatic --value false
```

```
Edit not applied (1):
  The editor does not show IsSharedStatic for Entities/PlayerBall/BallTexture.png in Entities\PlayerBall, so set-file-property does not set it there. Settable: AddToManagers, CachedInstanceName, HasPublicProperty, IncludeDirectoryRelativeToContainer, LoadedAtRuntime, LoadedOnlyWhenReferenced, OpensWith, RuntimeType, SourceFile, Summary, UseContentPipeline.
1 problem(s).
```
