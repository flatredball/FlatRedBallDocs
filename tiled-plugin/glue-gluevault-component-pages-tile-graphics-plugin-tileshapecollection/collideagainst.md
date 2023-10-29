# collideagainst

### Introduction

The CollideAgainst function returns a bool value indicating whether the calling TileShapeCollection collides with the argument. CollideAgainst can be used to test collisions against:

* ICollidable (usually Glue entities)
* AxisAlignedRectangle
* Circle
* Line
* Polygon

Note that in most cases CollideAgainst does not need to be called because collision relationships can be created between TileShapeCollections and Glue ICollidable entities.

### Code Example

The following code shows how to test if an entity is colliding with a TileShapeCollection whenever the space bar is pressed. The code assumes that the entity implements ICollidable.

```lang:c#
var keyboard = InputManager.Keyboard;

if(keyboard.KeyPushed(Keys.Space))
{
   // Assuming GroundCollision is a valid TileShapeCollection and
   // CollidableEntityInstance is a valid entity instance
   var collides = GroundCollision.CollideAgainst(CollidableEntityInstance);
   
   // collides can be used here
}
```

&#x20;
