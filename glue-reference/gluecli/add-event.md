# add-event

### Introduction

`add-event` adds an event to a screen or entity, the way the editor's **Add Event** window does. The window has three choices, and each has its own options:

* **Expose an existing event.** `--expose <event>` takes one of the events the element can expose, such as `InitializeEvent`, `ResolutionOrOrientationChanged`, `BeforeCollision` on a screen, `Click` on an IWindow entity, `AfterVisibleSet` on an IVisible entity, or `After<Variable>Set` for a variable with `CreatesEvent`. `--variable <variable> [--when before|after]` does the same for a variable's change event. The event keeps its own name.
* **Tunnel an event from another object.** `--object <object> --object-event <event>`, for example a collision relationship's `CollisionOccurred`. The name defaults to `<object><event>`, as in the window.
* **Create a new event.** `--custom --name <name>` adds an event you raise from your own code.

The editor writes the event into the element's `.Generated.Event.cs` and adds an empty handler, `On<name>`, to the element's hand-written `.Event.cs`. It creates either file if needed.

### Usage

```
GlueCli add-event <project> --element <element> (--expose <event> | --variable <variable> [--when before|after] | --object <object> --object-event <event> | --custom --name <name> [--delegate-type <type>] [--args-type <type>]) [--name <name>]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity to add the event to. Required. |
| `--name <name>` | Event name. Required with `--custom`. Defaults to `<object><event>` with `--object`. An exposed event keeps its own name. |
| `--expose <event>` | Expose this event of the element. |
| `--variable <variable>` | Expose the change event of this variable (`Visible`, or one with `CreatesEvent`). |
| `--when <before\|after>` | With `--variable`: raise the event before or after the variable is set. Default: `after`. |
| `--object <object>` | Tunnel an event of this object. |
| `--object-event <event>` | With `--object`: the object's event, such as `CollisionOccurred`. |
| `--custom` | Create a new event. Needs `--name`. |
| `--delegate-type <type>` | With `--custom`: `System.EventHandler` (default), `FlatRedBall.Gui.WindowEvent` or `System.Action<T>`. Short names work too. |
| `--args-type <type>` | With `--custom`: the type `T` for `System.Action<T>`, such as `int` or `Entities.Enemy`. Picks `System.Action<T>` when `--delegate-type` is not given. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Handle a collision relationship's `CollisionOccurred` in GameScreen:

```
GlueCli add-event Beefball --element GameScreen --object PlayerBallVsGoal --object-event CollisionOccurred
```

```
Added event PlayerBallVsGoalCollisionOccurred (PlayerBallVsGoal.CollisionOccurred) to Screens\GameScreen; handler OnPlayerBallVsGoalCollisionOccurred in Screens/GameScreen.Event.cs (added).
Files written (4):
  Screens/GameScreen.Event.cs
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.Generated.Event.cs
  Screens/GameScreen.glsj
No new errors.
```

Write your code in the `OnPlayerBallVsGoalCollisionOccurred` method in `GameScreen.Event.cs`.

Add a new event of type `System.Action<int>`, with JSON output:

```
GlueCli add-event Beefball --element Entities/PlayerBall --custom --name Died --args-type int --json
```

```json
"edit": {
  "element": "Entities\\PlayerBall",
  "name": "Died",
  "kind": "custom",
  "sourceObject": null,
  "sourceObjectEvent": null,
  "sourceVariable": null,
  "when": null,
  "delegateType": "System.Action<int>",
  "generatedFile": "Entities/PlayerBall.Generated.Event.cs",
  "handlerFile": "Entities/PlayerBall.Event.cs",
  "handler": "OnDied",
  "handlerAdded": true
},
```

### JSON Output

`edit` holds `{element, name, kind, sourceObject, sourceObjectEvent, sourceVariable, when, delegateType, generatedFile, handlerFile, handler, handlerAdded}`.

* `kind` is `exposed`, `variable`, `tunneled` or `custom`.
* `generatedFile` and `handlerFile` are relative to the `.csproj` folder.
* `handlerAdded` is true when the handler method was added to `handlerFile`.

### Failure

The run exits with code 1 and saves nothing when the element, object, object event or variable does not exist, the name is taken or not a valid C# name, or the object's event already has an event in the element. The message lists close matches or the valid choices.

```
GlueCli add-event Beefball --element GameScreen --object PuckVsGoal --object-event CollisionOccurred
```

```
Edit not applied (1):
  PuckVsGoal.CollisionOccurred already has the event PuckVsGoalCollided in Screens\GameScreen.
1 problem(s).
```
