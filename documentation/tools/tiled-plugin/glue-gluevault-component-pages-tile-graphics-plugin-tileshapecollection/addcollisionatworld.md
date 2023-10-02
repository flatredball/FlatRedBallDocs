## Introduction

AddCollisionAtWorld creates attempts to create a new rectangle at the location specified. If the TileShapeCollection already has an AxisAlignedRectangle at the argument location, then it will not create another. If there is no rectangle at the argument location, then a new one will be created. Newly-created rectangles will automatically be sized and positioned according to the rectangle size and seed of the TileShapeCollection.

## AddCollisionAtWorld Details

AddCollisionAtWorld  adds a collision rectangle at the argument X and Y values. Rather than using the exact X and Y values, the rectangle will be placed at the center of the tile, extending to the edges using the TileShapeCollection.GridSize  value. For example, consider a TileShapeCollection  with a GridSize  of 16. Calling the AddCollisionAtWorld  method with any value between 0 and 16 will result in a rectangle being placed at (8,8). Furthermore, calling AddCollisionAtWorld  inserts a rectangle in the proper index to keep the shape collection ordered along its SortAxis . Therefore, AddCollisionAtWorld  can be called in any order and all rectangles will still be sorted and collision methods will use partitioning.

## Code Example - Creating AxisAlignedRectangles With the Cursor

The following code shows how to create AxisAlignedRectangles with the cursor. The following code assumes that SolidCollision is a valid TileShapeCollection and that it is visible.

    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryDown)
    {
        var solidCollisionAt = SolidCollision.GetRectangleAtPosition(
            cursor.WorldX, cursor.WorldY);

        if(solidCollisionAt == null)
        {
            SolidCollision.AddCollisionAtWorld(cursor.WorldX, cursor.WorldY);
        }
    }

[![](/media/2021-04-2021_April_06_215452.gif)](/media/2021-04-2021_April_06_215452.gif)
