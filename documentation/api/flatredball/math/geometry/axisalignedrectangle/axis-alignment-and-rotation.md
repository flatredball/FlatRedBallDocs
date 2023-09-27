## Introduction

Although AxisAlignedRectangles inherit from the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") class, which inherits from the [IRotatable](/frb/docs/index.php?title=FlatRedBall.Math.IRotatable "FlatRedBall.Math.IRotatable") interface, AxisAlignedRectangles cannot be visibly rotated. This article discusses how rotation values are applied to AxisAlignedRectangles.

## AxisAlignment and the collision/visible representation of an AxisAlignedRectangle

As far as the visible representation and collision behavior of an AxisAlignedRectangle, rotation will have no impact on an AxisAlignedRectangle. For more information, see [this section](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle#What_does_.22axis_aligned.22_mean.3F "FlatRedBall.Math.Geometry.AxisAlignedRectangle").

## How do children of AxisAlignedRectangles behave?

All positions in FlatRedBall are defined by a combination of X, Y, and Z values. These values, when measuring absolute space, represent the distance from the origin along each axis by the same name as the component (X axis, Y axis, and Z axis). In FlatRedBall, when using an unrotated [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"), positive X points to the right and positive Y points up. The "axis aligned" part of AxisAlignedRectangles simply means that the edges of the rectangle are parallel (line up with) the X and Y axes. This is always true for AxisAlignedRectangles - even if they are rotated. However, that doesn't mean that the underling rotation values are always 0. In other words, if another [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") is attached to an AxisAlignedRectangle, and the (parent) AxisAlignedRectangle is rotated, then the child [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") will react to the rotation.
