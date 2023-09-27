## Introduction

The PrimaryClick property returns whether the Cursor has been clicked this frame. A click is defined as:

-   [PrimaryDown](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.PrimaryDown&action=edit&redlink=1.md "FlatRedBall.Gui.Cursor.PrimaryDown (page does not exist)") was true last frame and...
-   PrimaryDown is false this frame

This occurs if the user pushes and releases the left moue button or touches and lifts on the touch screen. If developing games which may use a touch screen, you should consider [PrimaryClickNoSlide](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.PrimaryClickNoSlide.md "FlatRedBall.Gui.Cursor.PrimaryClickNoSlide") to differentiate between when the user touches and releases in the same spot vs. when the user touches, slides, then releases.

## Example

The cursor can be checked to see if a click occurred in any CustomActivity code. The following code creates a Circle wherever the user clicks:

``` lang:c#
if(GuiManager.Cursor.PrimaryClick)
{
    var circle = new Circle();
    circle.X = GuiManager.Cursor.WorldXAt(0);
    circle.Y = GuiManager.Cursor.WorldYAt(0);
}
```

[![](/wp-content/uploads/2016/01/2017-12-14_08-49-02-1.gif.md)](/wp-content/uploads/2016/01/2017-12-14_08-49-02-1.gif.md)