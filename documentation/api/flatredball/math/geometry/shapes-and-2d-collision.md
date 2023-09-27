## Introduction

The 2D shapes in the FlatRedBall.Math.Geometry namespace provide useful methods for detecting and reacting to collisions. The following lists the 2D shapes:

-   [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle")
-   [Capsule2D](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Capsule2D.md "FlatRedBall.Math.Geometry.Capsule2D")
-   [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle")
-   [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line.md "FlatRedBall.Math.Geometry.Line")
-   [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon")

These objects provide methods for performing collision against one another. While these objects can be positioned and in some case rotated in 3D space, the collisions they perform are limited to 2D. When two shapes perform collision methods, they ignore their Z values. Mathematically speaking, shapes are projected onto the XY plane, then the projections perform collision against each other. Therefore, if two shapes may appear to not be touching visibly, their collision methods may still indicate that collisions are occurring if they are overlapping each other.

## Collision Methods

|                      |                    |                                         |                                       |
|----------------------|--------------------|-----------------------------------------|---------------------------------------|
| Collision Method     | Returns true/false | Changes Position to resolve overlapping | Changes Velocity to simulate bouncing |
| CollideAgainst       | X                  |                                         |                                       |
| CollideAgainstMove   | X                  | X                                       |                                       |
| CollideAgainstBounce | X                  | X                                       | X                                     |