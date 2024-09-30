# LastCollisionAxisAlignedRectangles

### Introduction

The LastCollisionAxisAlignedRectangles property stores a list of AxisAlignedRectangles which collided with the last object to perform collision against a TileShapeCollection. This can change multiple times per frame since multiple objects may collide with a TileShapeCollection. Therefore, this property should be used immediately after a collision occurs. Typically this is accessed in a CollisionRelationship event. This list may contain multiple rectangles if the last collision check resulted in multiple rectangles overlapping.

### Code Example - Printing Collision Information for a Platformer Entity

For this example, consider a platformer entity which is performing solid collision. We can print information about the collision to the screen in an event for the collision relationship, as shown in the following code:

```
void OnPlayerListVsSolidCollisionCollisionOccurred (Entities.Player first, FlatRedBall.TileCollisions.TileShapeCollection second)
{
    string collisionInfo = "Collided with:";
    foreach(var rectangle in second.LastCollisionAxisAlignedRectangles)
    {
        collisionInfo += $"\nRectangle at {rectangle.Position}";
    }
    FlatRedBall.Debugging.Debugger.Write(collisionInfo);
}
```

![](../../.gitbook/assets/2021-03-img\_6064da416af12.png)
