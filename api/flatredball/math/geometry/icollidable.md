# ICollidable

### Introduction

The ICollidable interface provides a standard collision implementation. Objects which implement ICollidable can collide with all FlatRedBall shapes and other ICollidables. The ICollidable interface requires a [ShapeCollection](shapecollection/) property named Collision. FlatRedBall also offers the following extension methods for ICollidable:

* CollideAgainst - Simply returns true/false to indicate whether a collision has occured
* CollideAgainstMove - Returns true/false and separates the two objects involved in the collision
* CollideAgainstBounce - Returns true/false, separates the two objects involved, and adjusts the velocity of the objects involved to simulate bouncing

### ICollidable Entities

Entities in the FRB Editor can be marked as ICollidable. For more information on ICollidable in the FRB Editor, see [this page](../../../../glue-reference/entities/glue-reference-implements-icollidable.md).

### ICollidable and Collision

ICollidables provide the same three functions for collision as FlatRedBall shapes. The details of the collision behavior depend on the specific shape, but the concpts are similar in all cases. For more information on how shapes respond to collision methods, check the following pages:

Circle

* [CollideAgainst](https://docs.flatredball.com/flatredball/api/flatredball/math/geometry/circle/collideagainst)
* [CollideAgainstBounce](https://docs.flatredball.com/flatredball/api/flatredball/math/geometry/circle/collideagainstbounce)

ShapeCollection

* [CollideAgainst](https://docs.flatredball.com/flatredball/api/flatredball/math/geometry/shapecollection/collideagainst)

### ItemsCollidedAgainst and ObjectsCollidedAgainst

Collidables must implement the following four properties:

* ItemsCollidedAgainst
* LastFrameItemsCollidedAgainst
* ObjectsCollidedAgainst
* LastFrameObjectsCollidedAgainst

These serve as an alternative to doing custom collision-related logic, and provide some additional functionality such as detecting when an entity exits collision.

The `Items` property contains the name of items that the IColliable has collided with, while the `Objects` contains a reference to the objects that the ICollidable has collided with. If you are using the FlatRedBall Editor, these propertes are automatically generated in your entities, and these are automatically filled through collision relationships.

