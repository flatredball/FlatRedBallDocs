## Introduction

The ScreenX and ScreenY properties return the X and Y coordinates of the Cursor in pixel coordinates. These values represent the location of the cursor relative to the top-left of the game screen. These values will not be impacted by properties set on the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"). These values can be used if you are manually handling gestures or if you are converting screen coordinates to world coordinates instead of using the FlatRedBall methods.

## Code Example

The following code uses the Debugger class to display the Cursor's screen coordinates in real time:

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    FlatRedBall.Gui.Cursor cursor = FlatRedBall.Gui.GuiManager.Cursor;

    FlatRedBall.Debugging.Debugger.Write($"{cursor.ScreenX}, {cursor.ScreenY}");
}
```

     
