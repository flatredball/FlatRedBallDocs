## Introduction

The IMouseOver interface is an interface that is used to standardize checks between an object and the [Cursor](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor "FlatRedBall.Gui.Cursor").

## IsMouseOver Code Example

The following code checks to see if the Cursor is over an [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle"). This example was created inside an Entity which contains an AxisAlignedRectangle instance called AxisAlignedRectangleInstance:

Add the following to CustomInitialize to force the cursor to be visible:

    FlatRedBallServices.Game.IsMouseVisible = true;

Add the following to CustomActivity:

    bool isMouseOver = this.AxisAlignedRectangleInstance.IsMouseOver(
        GuiManager.Cursor, LayerProvidedByContainer);

    if (isMouseOver)
    {
        AxisAlignedRectangleInstance.Color =
            Microsoft.Xna.Framework.Color.Red;
    }
    else
    {
        AxisAlignedRectangleInstance.Color =
            Microsoft.Xna.Framework.Color.White;
    }

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
