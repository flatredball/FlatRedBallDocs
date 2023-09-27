## Introduction

The CreateRectangle method creates a Polygon that is in the shape of a rectangle. Polygons created through the CreateRectangle method are no different than any other Polygon - the CreateRectangle method is simply a method that simplifies a common task.

Since Polygons and [AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") have the same methods for performing collision and both inherit from the [PositionedObject](/frb/docs/index.php?title=PositionedObject "PositionedObject") class, the decision of whether to use the Polygon or [AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") depends on whether you need rotation support.

If you need to have rotation support, you should use the Polygon class. [AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") do not consider rotation when drawn or when performing collision. However, because of this, [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") collision is faster than Polygon collision. If rotation is not needed, you should consider using the [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") class for performance reasons.

## Code Example

The following code creates a Polygon using the CreateRectangle method. The Polygon is then added to the ShapeManager to be visible.

Add the following using statements:

    using FlatRedBall.Math.Geometry;

Add the following to Initialize after initializing FlatRedBall:

    float scaleX = 2;
    float scaleY = 3;
    Polygon polygon = Polygon.CreateRectangle(scaleX, scaleY);
    // It won't be visible if you don't add it to the ShapeManager
    ShapeManager.AddPolygon(polygon);

![PolygonCreateRectangle.png](/media/migrated_media-PolygonCreateRectangle.png)

## Value Explanation

Notice that the values used in the above line of code are "scale" values. Scale values in FlatRedBall represent the distnace from the center to the edge of an object. For example, an object which has a ScaleX of 2 will have a width of 4. Therefore, the rectangle created in the code above will have a width of 4 units and a height of 6 units.

Although the Polygon object itself is not an IScalable, the CreateRectangle uses scale values. For more information on how scale values are used elsewhere in the FlatRedBall engine, see the [IScalable page](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.IScalable "FlatRedBall.Math.Geometry.IScalable").
