## Introduction

GetRectangleAtPosition returns the AxisAlignedRectangle instance at the argument position. This method checks if the position is inside the bounds of the rectangle, so an exact position is not needed. This method also takes advantage of the axis-based partitioning in the TileShapeCollection so this method does not need to check every rectangle. In other words, this method is very fast, even for TileShapeCollections with a lot of rectangles.

## Code Example - Getting Rectangle at Cursor Position

The following code can be used to obtain a rectangle at the Cursor's position:

    var cursorPosition = GuiManager.Cursor.WorldPosition;
    var rectangleAtCursorPosition =
        SolidCollision.GetRectangleAtPosition(cursorPosition.X, cursorPosition.Y);

    if(rectangleAtCursorPosition != null)
    {
        // do something with the rectangle
    }

## 
