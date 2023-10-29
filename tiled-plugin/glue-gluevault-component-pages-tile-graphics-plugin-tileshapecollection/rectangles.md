## Introduction

The Rectangles property provides access to the list of AxisAlignedRectangles stored in a TileShapeCollection. This list will be ordered based on the TileShapeCollection's SortAxis property.

## Code Example - Performing Logic per AxisAlignedRectangle

The following code shows how to loop through all rectangles in a TileShapeCollection and perform custom logic:

    foreach(var rectnagle in SolidCollision.Rectangles)
    {
        // do something with the AxisAlignedRectangle here:
        // ...
    }
