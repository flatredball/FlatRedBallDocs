# Cursor

### Introduction

The Cursor class represents the moving cursor (on desktop) or the touch screen (on touch screens). The Cursor class is similar to the [Mouse](../../input/mouse/) class in its interface, but provides a few additional features:

* The Cursor is a more abstract class supporting a variety of input sources such as Mouse, Xbox360Gamepad, and TouchScreen
* The Cursor works very well with the Window class and IWindow interface. The cursor is automatically used with Gum and FlatRedBall.Forms objects

We recommend using the Cursor class unless you specifically need to inspect the Mouse hardware.

### Cursor and touch screens

The Cursor can handle both mouse and touch screen input. Many games can use the exact same Cursor class whether written for the mouse or touch screen. Games needing more control over touch screen input can use the [TouchScreen](../../input/touchscreen/) class.

### Accessing the Cursor

The Cursor class can be accessed through the [GuiManager's](../guimanager/) Cursor property as follows:

```csharp
var cursor = GuiManager.Cursor;
if(cursor.PrimaryClick)
{
  // do something if it's clicked
}
```

### "Primary" properties

The Cursor is a general-purpose class for handling cross-platform input. It can represent a mouse, touch screen, or visible cursor controlled by the Xbox 360 Gamepad.

|              |                                                                                             |                                                                                           |
| ------------ | ------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| Property     | Mouse                                                                                       | Touch Screen                                                                              |
| PrimaryPush  | The user just pressed the left mouse button down (was not down last frame)                  | The user just touched the touch screen (was not touched last frame)                       |
| PrimaryDown  | The user has the left mouse button down                                                     | The user is touching the touch screen                                                     |
| PrimaryClick | The user has just released the left mouse button (was down last frame, not down this frame) | The user has just lifted off of the touch screen (was touched last frame, not this frame) |

### Cursor visibility

By default the cursor is invisible when moving over a FlatRedBall game. The following code makes the cursor visible when over the game window:

```csharp
FlatRedBallServices.Game.IsMouseVisible = true;
```

### Code Example - Detecting PrimaryPush

The following code creates a Circle wherever the Cursor is pushed:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    if (cursor.PrimaryPush)
    {
        var circle = new Circle();
        circle.X = cursor.WorldX;
        circle.Y = cursor.WorldY;
        circle.Visible = true;
        circle.Radius = 8;
    }
}
```

