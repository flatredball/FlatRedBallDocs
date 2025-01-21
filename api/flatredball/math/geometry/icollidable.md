# ICollidable

### Introduction

The ICollidable interface provides a standard collision implementation. Objects which implement ICollidable can collide with all FlatRedBall shapes and other ICollidables. The ICollidable interface requires a [ShapeCollection](shapecollection/) property named Collision. FlatRedBall also offers the following extension methods for ICollidable:

* CollideAgainst - Simply returns true/false to indicate whether a collision has occurred
* CollideAgainstMove - Returns true/false and separates the two objects involved in the collision
* CollideAgainstBounce - Returns true/false, separates the two objects involved, and adjusts the velocity of the objects involved to simulate bouncing

### ICollidable Entities

Entities in the FRB Editor can be marked as ICollidable. For more information on ICollidable in the FRB Editor, see [this page](../../../../glue-reference/entities/glue-reference-implements-icollidable.md).

### ICollidable and Collision

ICollidables provide the same three functions for collision as FlatRedBall shapes. The details of the collision behavior depend on the specific shape, but the concepts are similar in all cases. For more information on how shapes respond to collision methods, check the following pages:

Circle

* [CollideAgainst](circle/collideagainst.md)
* [CollideAgainstBounce](circle/collideagainstbounce.md)

ShapeCollection

* [CollideAgainst](shapecollection/collideagainst.md)

### ItemsCollidedAgainst and ObjectsCollidedAgainst

Classes which implement ICollidable must implement the following four properties:

* ItemsCollidedAgainst
* LastFrameItemsCollidedAgainst
* ObjectsCollidedAgainst
* LastFrameObjectsCollidedAgainst

These serve as an alternative to doing custom collision-related logic, and provide some additional functionality such as detecting when an entity exits collision.

The `Items` property contains the name of items that the IColliable has collided with, while the `Objects` contains a reference to the objects that the ICollidable has collided with. If you are using the FlatRedBall Editor, these properties are automatically generated in your entities, and these are automatically filled through collision relationships. For example, if the Player collides with SolidCollision in the GameScreen, then the items properties would contain the string "SolidCollision". The objects properties would a reference to the TileShapeCollection.

The instances contained in the Items and Objects lists dare the top-most ICollidable-implementing instances that have been collided against. In short, TileShapeCollections and ShapeCollections appear in these lists, but only individual entity instances (rather than their entire list) appear in these lists. items are:

* TileShapeCollections - Since TileShapeCollection implements ICollidable, the name and reference to the TileShapeCollection are added to the appropriate lists. The individual shapes (AxisAlignedRectangle and Polygon) do do not appear in the lists
* ShapeCollections - The entire ShapeCollection name and reference are added to the appropriate lists. Individual shapes do not appear in the lists, just like with TileShapeCollections
* Collidable Entity Lists - Individual items in collidable name and references appear in the appropriate lists. The entire list is not added to the list since the list itself does not implement the ICollidable interface.

The following code shows how to check whether the player has entered or exited a collision area with the name PoisonCollision:

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

This code could be used as long as the following conditions are true:

* The Player implements ICollidable - this is usually true, and is always true if the game was created using the FRB Editor wizard.
* The GameScreen contains a TileShapeCollection named PoisonCollision
* The GameScreen contains a CollisionRelationship between the PlayerList and PoisonCollision

For example, the GameScreen might be similar to the following image:

<figure><img src="../../../../.gitbook/assets/21_05 37 48.png" alt=""><figcaption><p>Example GameScreen containing the necessary objects for ItemsCollidedAgainst to contain PoisonCollision</p></figcaption></figure>

The properties mentioned above are updated automatically every frame, and contain all of the items that an ICollidable has collided against. This includes TileShapeCollections as well as individual entity instances. For example, the following code can be used to output the names of all items collided against:

```csharp
// in Player.cs
private void CustomActivity()
{
    string collisionInfo = "";

    foreach(var item in this.ItemsCollidedAgainst)
    {
        collisionInfo += item.ToString() + "\n";
    }
    FlatRedBall.Debugging.Debugger.Write(collisionInfo);
}
```

The code above results in the collision info being printed to the screen as shown in the following animation:

<figure><img src="../../../../.gitbook/assets/21_05 51 58.gif" alt=""><figcaption><p>Player displaying names of ItemsCollidedAgainst</p></figcaption></figure>
