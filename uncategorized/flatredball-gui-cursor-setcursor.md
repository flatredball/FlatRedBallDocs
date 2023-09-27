**SetCursor is no longer supported:**This method is no longer supported in new versions of FlatRedBall; however its functionality is fully supported through the use of the Cursor class and Sprites. For an example on how to perform equivalent functionality, see [this page](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.WorldXAt#Using_custom_Cursor_graphics.md "FlatRedBall.Gui.Cursor.WorldXAt").

## Introduction

The SetCursor method can be used to customize the look and behavior of the FlatRedBall-drawn Cusor. Specifically this method does the following:

1.  Sets the texture that should be used by the Cursor when it is rendered
2.  Sets the offset from the top-left of the cursor that the Cursor's methods and properties will report.

## Code Example

The following code example changes the Cursor's texture to the redball.bmp texture. It also changes the tip offset for the Cursor to the right. Finally it creates a [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle") that is positioned with the Cursor. Notice that the [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle") is positioned to the right of the Cursor.

Add the following using statements:

    using FlatRedBall.Gui;
    using FlatRedBall.Math.Geometry;

Add the following at class scope:

    Circle circle;

Add the following to Initialize after initializing FlatRedBall:

    GuiManager.DrawCursorEvenIfThereIsNoUI = true;

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

    float xOffsetInUiUnits = 15;
    float yOffsetInUiUnits = 0;
    GuiManager.Cursor.SetCursor(texture, xOffsetInUiUnits, yOffsetInUiUnits);

    circle = ShapeManager.AddCircle();

Add the following to Activity:

     circle.X = GuiManager.Cursor.WorldXAt(0);
     circle.Y = GuiManager.Cursor.WorldYAt(0);

![CursorSetCursor.png](/media/migrated_media-CursorSetCursor.png)
