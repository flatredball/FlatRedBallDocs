## Introduction

The Left, Right, Top, and Bottom properties on AxisAlignedRectangle return the absolute position of the respective side.

## Code Example

The following code shows how to get the four values (Left, Right, Top, and Bottom):

    // This assumes your rectangle is called RectangleInstance
    float left = RectangleInstance.Left;
    float right = RectangleInstance.Right;
    float top = RectangleInstance.Top;
    float bottom = RectangleInstance.Bottom;

    // Now you can use these four values for whatever you need in your code

## Setting values

Setting Left, Right, Top, and Bottom results in the X or Y values of the AxisAlignedRectangle changing. These values will not change the Width or Height of the AxisAlignedRectangle. To change dimensions use the [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width&action=edit&redlink=1 "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width (page does not exist)") and [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height&action=edit&redlink=1 "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height (page does not exist)") values.
