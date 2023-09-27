## Introduction

The ICollidable interface provides a standard collision implementation. Objects which implement ICollidable can collide with all FlatRedBall shapes and other ICollidables. The ICollidable interface requires a [ShapeCollection](/documentation/api/flatredball/flatredball-math/flatredball-math-geometry/flatredball-math-geometry-shapecollection.md) property named Collision. FlatRedBall also offers the following extension methods for ICollidable:

-   CollideAgainst - Simply returns true/false to indicate whether a collision has occured
-   CollideAgainstMove - Returns true/false and separates the two objects involved in the collision
-   CollideAgainstBounce - Returns true/false, separates the two objects involved, and adjusts the velocity of the objects involved to simulate bouncing

## ICollidable Entities

Entities in Glue can be marked as ICollidable. For more information on ICollidable in Glue, see [this page](/frb/docs/index.php?title=Glue:Reference:Entities:Implements_ICollidable "Glue:Reference:Entities:Implements ICollidable").

## ICollidable and Collision

ICollidables provide the same three functions for collision as FlatRedBall shapes. For more information check the following pages:

-   [CollideAgainst](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainst "FlatRedBall.Math.Geometry.Circle.CollideAgainst")
-   [CollideAgainstMove](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove "FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove")
-   [CollideAgainstBounce](/documentation/api/flatredball/flatredball-math/flatredball-math-geometry/flatredball-math-geometry-circle/flatredball-math-geometry-circle-collideagainstbounce.md "FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce")

 
