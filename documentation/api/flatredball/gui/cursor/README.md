## Introduction

The Cursor class represents the moving cursor (on desktop) or the touch screen (on touch screens). The Cursor class is similar to the [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse "FlatRedBall.Input.Mouse") class in its interface, but provides a few additional features:

-   The Cursor is a more abstract class supporting a variety of input sources such as Mouse, Xbox360Gamepad, and TouchScreen
-   The Cursor works very well with the Window class and IWindow interface

We recommend using the Cursor class instead of Mouse for games which have any kind of selection system, such as RTS games.

## Cursor and touch screens

The Cursor can handle both mouse and touch screen input. Many games can use the exact same Cursor class whether written for the mouse or touch screen. Games needing more control over touch screen input can use the [TouchScreen](/documentation/api/flatredball/input/touchscreen.md "FlatRedBall.Input.TouchScreen") class.

## Accessing the Cursor

The Cursor class can be accessed through the [GuiManager's](/documentation/api/flatredball/gui/guimanager.md "FlatRedBall.Gui.GuiManager") Cursor property as follows:

    GuiManager.Cursor

## "Primary" properties

The Cursor is a general-purpose class for handling cross-platform input. It can represent a mouse, touch screen, or visible cursor controlled by the Xbox 360 Gamepad (although this is not often used in games).

|              |                                                                                             |                                                                                           |
|--------------|---------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------|
| Property     | Mouse                                                                                       | Touch Screen                                                                              |
| PrimaryPush  | The user just pressed the left mouse button down (was not down last frame)                  | The user just touched the touch screen (was not touched last frame)                       |
| PrimaryDown  | The user has the left mouse button down                                                     | The user is touching the touch screen                                                     |
| PrimaryClick | The user has just released the left mouse button (was down last frame, not down this frame) | The user has just lifted off of the touch screen (was touched last frame, not this frame) |

## Cursor visibility

By default the cursor is invisible when moving over a FlatRedBall game. The following code will make the cursor visible when over the Window:

``` lang:c#
FlatRedBallServices.Game.IsMouseVisible = true;
```

## Code Example - Detecting PrimaryPush

The following code creates a Circle wherever the Cursor is pushed:

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

## Additional Information

-   [Customizing Cursor Visuals](/frb/docs/index.php?title=Customizing_Cursor_Visuals "Customizing Cursor Visuals")

  \[subpages depth="1"\]

## 
