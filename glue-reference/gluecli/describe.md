# describe

### Introduction

`describe` shows what the project, or one screen or entity, contains. It prints names exactly as the edit commands take them, so you can read a project without opening its `.gluj`, `.glsj` or `.glej` files.

`describe` is read-only. It saves nothing. `filesWritten` lists only what loading writes, as for [check](check.md).

### Usage

```
GlueCli describe <project> [--element <element>] [--json]
```

Without `--element`, `describe` lists every screen and entity (name, folder and base), the startup screen, Global Content files, the `.gluj` file version, and the Gum project if there is one.

With `--element`, it shows that screen or entity:

* Its base.
* Its objects as a tree. Lists and ShapeCollections show their children. Each object shows its type and the variables set on it.
* Its variables, with type and default value. A tunneled variable shows the object variable it sets.
* Its states and state categories.
* Its events and files.

Objects and variables a base element defines are marked `definedByBase`. Only what this element sets on them is shown.

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to describe, such as `GameScreen` or `Entities\Player`. Default: the whole project. |
| `--json` | Print one JSON object to stdout instead of text. `edit` holds the description. |

### Examples

Describe the whole project:

```
GlueCli describe Beefball
```

```
File version 42, startup screen: Screens\GameScreen, Gum: none.
Screens (1):
  Screens\GameScreen  (startup)
Entities (4):
  Entities\Goal
  Entities\PlayerBall
  Entities\Puck
  Entities\ScoreHud
Global Content (0):
No errors.
```

Describe one entity:

```
GlueCli describe Beefball --element PlayerBall
```

```
Entities\PlayerBall (entity)
Objects (2):
  CircleInstance  Circle  Radius=16
  CooldownCircle  Circle  Radius=16
Variables (10):
  X float = (unset) [setByDerived]
  Y float = (unset) [setByDerived]
  Z float = (unset) [setByDerived]
  MovementSpeed float = 300 [setByDerived]
  Drag float = 1 [setByDerived]
  DashFrequency float = 2 [setByDerived]
  DashSpeed float = 600 [setByDerived]
  CooldownCircleRadius float = 16  <- CooldownCircle.Radius [setByDerived]
  CircleInstanceColor Color = "White"  <- CircleInstance.Color [setByDerived]
  CooldownCircleColor Color = "White"  <- CooldownCircle.Color [setByDerived]
State categories (1):
  DashCategory: Tired, Rested
Files (0):
No errors.
```

A screen shows its objects as a tree. This is part of Beefball's GameScreen:

```
GlueCli describe Beefball --element GameScreen
```

```
Screens\GameScreen (screen)
Objects (23):
  PlayerBallList  PositionedObjectList<Entities\PlayerBall> [exposedInDerived]
    PlayerBall1  Entities\PlayerBall  X=-180
    PlayerBall2  Entities\PlayerBall  CircleInstanceColor="Cyan" CooldownCircleColor="Cyan" X=180
  ...
  Walls  ShapeCollection [exposedInDerived]
    Wall1  AxisAlignedRectangle  Height=30 Width=800 Y=300
    ...
  PuckVsGoal  ListVsListRelationship<Entities.Puck, Entities.Goal>
Variables (0):
Events (1):
  PuckVsGoalCollided  <- PuckVsGoal.CollisionOccurred
Files (0):
No errors.
```

### JSON Output

With `--json`, `edit` holds the description.

For the project: `{kind: "project", fileVersion, startupScreen, gumProject, screens: [{name, folder, base}], entities: [{name, folder, base}], globalFiles: [{name, runtimeType}]}`. `gumProject` is null when the project has no Gum project.

For an element: `{kind: "element", name, elementType, base, objects, variables, states, stateCategories, events, files}`.

* `elementType` is `screen` or `entity`.
* Each object is `{name, sourceType, type, genericType, sourceFile, sourceName, list, definedByBase, setByDerived, exposedInDerived, isDisabled, variables: [{name, value}], children}`. `sourceType` is `FlatRedBallType`, `Entity`, `File` or `Gum`. `sourceFile` and `sourceName` are set only for objects from a file. `list` is the containing list's name, or null.
* Each variable is `{name, type, defaultValue, sourceObject, sourceObjectProperty, definedByBase, setByDerived, isShared}`.
* `stateCategories` is `[{name, states}]`, events are `[{name, sourceObject, sourceObjectEvent}]`, and files are `[{name, runtimeType}]`.

String properties are null when not set. Values are numbers, booleans or strings.

### Failure

The exit code is the same as [check](check.md): 1 when the project has errors, with the description still printed. An unknown `--element` exits with code 1 and lists close matches.
