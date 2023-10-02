## Introduction

The FlatRedBall Cursor object uses mouse or touch screen input by default. This default behavior can be changed with the SetControllingGamepad method, which switches a Cursor to be used by an Xbox360GamePad instance. When using an Xbox360GamePad for cursor control, the following input is applied:

-   Cursor position is controlled by the left analog stick and d-pad. Position is kept inside of the screen automatically.
-   The primary action (usually left mouse button) is controlled by the A button
-   The secondary action (usually the right mouse button) is controlled by the X button
-   Scrolling is controlled by the right analog stick’s Y (vertical) position

When using an Xbox360GamePad, the native (Windows) cursor will not move in response to gamepad controls, so a visual representation must be manually added.

## Code Example - Using an Xbox360GamePad to Control the Cursor

The following code assumes a Circle has been added to the current Screen:

    void CustomInitialize()
    {
        var cursor = GuiManager.Cursor;
        cursor.SetControllingGamepad(InputManager.Xbox360GamePads.First(item => item.IsConnected));
    }

    void CustomActivity(bool firstTimeCalled)
    {
        var worldPosition = GuiManager.Cursor.WorldPosition.ToVector3();
        FlatRedBall.Debugging.Debugger.Write(worldPosition);
        CircleInstance.Position = worldPosition;
    }

[![](/media/2022-10-27_14-38-33.gif)](/media/2022-10-27_14-38-33.gif)
