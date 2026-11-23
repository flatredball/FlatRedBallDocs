# remove-event

### Introduction

`remove-event` removes an event from a screen or entity, the way the editor's **Delete** does on an event. The element stops generating the event. Removing the element's last event takes its `.Generated.Event.cs` out of the `.csproj`.

The handler method (`On<name>`) stays in the element's hand-written `.Event.cs`. Delete it yourself if you no longer want it.

### Usage

```
GlueCli remove-event <project> --element <element> --name <name>
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen or entity with the event. Required. |
| `--name <name>` | Event to remove. Required. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

```
GlueCli remove-event Beefball --element GameScreen --name PlayerBallVsGoalCollisionOccurred
```

```
Removed event PlayerBallVsGoalCollisionOccurred from Screens\GameScreen; its handler OnPlayerBallVsGoalCollisionOccurred stays in Screens/GameScreen.Event.cs.
Files written (3):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.Generated.Event.cs
  Screens/GameScreen.glsj
No new errors.
```

### JSON Output

`edit` holds `{element, name, handlerFile, handler}`: the handler method left in `handlerFile`, relative to the `.csproj` folder.

### Failure

The run exits with code 1 and saves nothing when the element or event does not exist. The message lists close matches.

```
GlueCli remove-event Beefball --element GameScreen --name NoSuchEvent
```

```
Edit not applied (1):
  Screens\GameScreen has no event named 'NoSuchEvent'. Available: PuckVsGoalCollided.
1 problem(s).
```
