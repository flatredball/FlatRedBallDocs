## Introduction

The Remove method can be used to remove a shape from the ShapeManager. The Remove method will perform the following:

-   Remove the shape from being automatically updated by the ShapeManager (velocity, acceleration, attachments, etc)
-   Remove the shape from being drawn
-   Remove the shape from any PositionedObjectList it is a part of, including any objects that it is attached to

## Code Example

The following shows how to remove a shape:

    // Assuming polygonInstance is a valid Polygon:
    ShapeManager.Remove(polygonInstance);
    // Assuming circleInstance is a valid Circle:
    ShapeManager.Remove(circle);
    // you can remove all of the other shape types as well

## Removing a shape and calling collision methods

One of the most common (incorrect) assumptions about shapes is that a removed shape will not collide with any other shapes. This is incorrect - collision does not require ShapeManager membership. Consider the following code:

    Circle firstCircle = ShapeManager.AddCircle();
    Circle secondCircle = ShapeManager.AddCircle();
    // Both circles will be in the same position, so they will collide
    if(firstCircle.CollideAgainst(secondCircle))
    {
       // This will be true
    }
    // Now remove the circles from the ShapeManager:
    ShapeManager.Remove(firstCircle);
    ShapeManager.Remove(secondCircle);
    if(firstCircle.CollideAgainst(secondCircle))
    {
       // This will still be true!
    }

When a collision between two shapes is performed, the collision code simply checks the shapes positions, rotations (if appropriate), and size values (such as ScaleX or Radius if appropriate) to see if there is any overlap. In the case of a Circle, the position and radius doesn't change when it is removed from the ShapeManager. The same goes for any other shape - removing a shape from the ShapeManager does not modify the shape and collision methods will still work.

## So how do I remove a shape so it doesn't collide?

The behavior described above may seem inconvenient. However, in most cases shapes exist in one of two places:

1.  PositionedObjectLists inside a Screen or collision management class
2.  Objects inside an Entity

### Shapes in a PositionedObjectList

Games may include a PositionedObjectList or ShapeCollection containing shapes. The behavior of Shapes which are removed from the ShapeManager is the same in either case. Remember, PositionedObjectLists and ShapeCollections both have two-way relationships with objects that they contain, so removing a shape from the ShapeManager will result in the shape also being removed from any PositionedObjectList or ShapeCollection that it is a part of.

### Shapes in Entities

If you have an Entity with a shape Object (which may be called "Collision"), removing the shape from the ShapeManager will **not** remove the shape from the Entity. This means that the Entity's Collision member will still be valid and report collisions. In this case, it is up to you to write logic in your Entity to control whether collision should still be performed. For example, you may do something like this:

    if(myEntity.IsAlive && myEntity.Collision.CollideAgainst(someBullet))
    {
       // Respond to the collision here
    }

### References to shapes

If you are storing a reference to a shape in a class (not as a list) and you are performing collision with that shape, you will need to somehow identify that the shape has been removed. For example:

    // At class scope:
    Circle mCircle;

    // Somewhere the Circle may be instantiated:
    mCircle = ShapeManager.AddCircle();

    // To remove the shape you'll want to remove it form the shape manager and mark it as removed,
    // possibly by setting it to null:
    ShapeManager.Remove(mCircle);
    mCircle = null;

    // Then in your collision methods, you'll need to do a null check:
    if(mCircle != null && mCircle.CollideAgainst(someOtherShape))
    {
       // React to the collision
    }
