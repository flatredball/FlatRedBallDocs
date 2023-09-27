## Introduction

The ShapeMerger can be used to merge shapes together to create one larger shape. This is used by the TileEditor to create level collision.

## Code Example

The following code creates two Polygons - one is the shape of a rectangle, the other is a hexagon. The rectangle is offset, then the two shapes are merged into one. Add the following using statement:

    using FlatRedBall.Math.Geometry;

Add the following to Initialize after initializing FlatRedBall:

    Polygon firstPolygon = Polygon.CreateEquilateral(
        6, // Number of sides
        5, // radius
        0); // angle of first point

    Polygon secondPolygon = Polygon.CreateRectangle(
        4, // ScaleX
        4); // ScaleY

    secondPolygon.X = 5;
    secondPolygon.Y = 5;

    // This call modifies the first polygon
    ShapeMerger.Merge(firstPolygon, secondPolygon);
    ShapeManager.AddPolygon(firstPolygon);

![ShapeMergerExample.png](/media/migrated_media-ShapeMergerExample.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
