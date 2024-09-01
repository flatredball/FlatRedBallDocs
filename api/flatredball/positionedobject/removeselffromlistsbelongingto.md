# RemoveSelfFromListsBelongingTo

### Introduction

One of the most useful yet least understood features of PositionedObjects is their two-way relationship with [AttachableLists](../../../frb/docs/index.php#Two\_Way\_Relationships). The RemoveSelfFromListsBelongingTo method does essentially what the name says - it removes the calling PositionedObject from any [AttachableLists](../../../frb/docs/index.php) that it belongs to. This can include:

* Internal lists in the engine, like the AutomaticallyUpdatedSprites list in the [SpriteManager](../../../frb/docs/index.php).
* Any lists that you might create, such as lists of Entities in a GameScreen.
* Parent lists. Keep in mind that calling this method will NOT set the calling object's Parent property to null. This usually doesn't matter because the most common practice is to throw this object away (lose its reference) after the method is called. But just in case, remember that this will create a "lost child" relationship.

### When to use RemoveSelfFromListsBelongingTo

The answer is "almost never". RemoveSelfFromListsBelongingTo is ultimately called very frequently, but it is done so through one of the following calls:

* Entities which are Destroyed automatically call their own RemoveSelfFromListsBelongingTo
* Objects inside Entities and Screens have their RemoveSelfFromListsBelongingTo when the Entity or Screen is destroyed. Note that RemoveSelfFromListsBelongingTo is not directly called, but rather the objects inside are removed from their respective managers, which in turn calls RemoveSelfFromListsBelongingTo.

If you have manually created an object that is not an Entity, such as a Sprite for particles, then you would manually call the Remove method from the SpriteManager. Therefore, if you call the manager's remove method, also calling RemoveSelfFromListsBelongingTo is redundant. The only time that this method is really needed is if you have a PositionedObject-inheriting object which is **not being managed by a manager**. In that case you may want to call RemoveSelfFromListsBelongingTo to clear it out of any lists that it may belong to; however, this case is extremely rare.

### RemoveSelfFromListsBelongingTo and Particles

The [SpriteManager](../../../frb/docs/index.php) provides a method to create particle [Sprites](../../../frb/docs/index.php). Particle [Sprites](../../../frb/docs/index.php) behave slightly differently from other managed objects. When Remove is called on them they are not removed from all lists. The [SpriteManager](../../../frb/docs/index.php) stores a list of particle [Sprites](../../../frb/docs/index.php) internally which it cycles to reduce memory allocation and garbage. If RemoveSelfFromListsBelongingTo is called on a particle [Sprite](../../../frb/docs/index.php), then that [Sprite](../../../frb/docs/index.php) will be removed from all lists including the [SpriteManager's](../../../frb/docs/index.php) internal particle list. This can cause difficult to track bugs because this reduces the size of the particle list which can ultimately cause crash bugs if you run out of particles. In short, just as mentioned above, use the appropriate manager's remove method whenever possible instead of calling RemoveSelfFromListsBelongingTo.
