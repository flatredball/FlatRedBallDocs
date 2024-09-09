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

* [CollideAgainst](circle/collideagainst.md)
* [CollideAgainstBounce](circle/collideagainstbounce.md)

ShapeCollection

* [CollideAgainst](shapecollection/collideagainst.md)

### ItemsCollidedAgainst and ObjectsCollidedAgainst

Collidables must implement the following four properties:

* ItemsCollidedAgainst
* LastFrameItemsCollidedAgainst
* ObjectsCollidedAgainst
* LastFrameObjectsCollidedAgainst

These serve as an alternative to doing custom collision-related logic, and provide some additional functionality such as detecting when an entity exits collision.

The `Items` property contains the name of items that the IColliable has collided with, while the `Objects` contains a reference to the objects that the ICollidable has collided with. If you are using the FlatRedBall Editor, these properties are automatically generated in your entities, and these are automatically filled through collision relationships. For example, if the Player collides with SolidCollision in the GameScreen, then the items properties would contain the string "SolidCollision". The objects properties contains a reference to the TileShapeCollection.

The following code shows how to check whether the player has exited a collision area with the name PoisonCollision:

```csharp
// assuming IsInPoison is a property that is set to true when collision happens
if(IsInPoison and this.ItemsCollidedAgainst.Contains("PoisonCollision") == false)
{
    HandleExitingPoison();
}
```

Alternatively, the Last properties can be used to identify if a changed was made this frame. For example, the following would detect both entering and exiting poison, and does not require the use of additional properties:

```csharp
var poisonName = "PoisonCollision";
if(this.ItemsCollidedAgainst.Contains(poisonName) && 
    !this.LastFrameItemsCollidedAgainst.Contains(poisonName))
{
    HandleEnteringPoison();
}
else if(this.LastFrameItemsCollidedAgainst.Contains(poisonName) && 
    !this.ItemsCollidedAgainst.Contains(poisonName))
{
    HandleExitingPoison();
}
```
