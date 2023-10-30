## Introduction

The WindowPushed property returns the IWindow that the Cursor was over when a push last occurred. This property will remain valid while the cursor is down, and will continue to remain valid the frame when the cursor is clicked (released). After the frame where a click has occurred, the property is returned to null until the next push. WindowPushed is often used to push+drag off of a UI element.

## Code Example

The following code example shows how to create Circle and AxisAlignedRectangle instances by push+dragging off of two IWindows. These can be Glue entities implementing IWindow, Gum components, or hand-written IWindow-implementing objects. The following code assumes that the screen contains two IWindow-implementing objects:

1.  RectangleButton
2.  CircleButton

Note that this code creates circles and rectangles, but does not add them to any list. In a real game these shapes would need to be added to some list (probably a list created in Glue for the screen) so that they would get properly disposed when the screen is destroyed. This additional code has been omitted for this sample.

``` lang:c#
void CustomInitialize()
{
    FlatRedBallServices.Game.IsMouseVisible = true;
}

void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;
    
    // This code is not necessary, but displays the WindowPushed in real time, which
    // can help with debugging.
    FlatRedBall.Debugging.Debugger.Write(cursor.WindowPushed);

    if(cursor.PrimaryClick)
    {
        float worldX = cursor.WorldXAt(0);
        float worldY = cursor.WorldYAt(0);

        if(cursor.WindowPushed == RectangleButton)
        {
            var rectangle = new AxisAlignedRectangle();
            rectangle.X = worldX;
            rectangle.Y = worldY;
            rectangle.Width = 32;
            rectangle.Height = 32;
            rectangle.Visible = true;
        }
        else if(cursor.WindowPushed == CircleButton)
        {
            var circle = new Circle();
            circle.X = worldX;
            circle.Y = worldY;
            circle.Radius = 16;
            circle.Visible = true;
        }
    }
}
```



<figure><img src="/media/2017-10-2017-10-25_08-24-45.gif" alt=""><figcaption></figcaption></figure>


