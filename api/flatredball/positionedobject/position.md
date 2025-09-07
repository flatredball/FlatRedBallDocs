# Position

### Introduction

The Position field is a PositionedObject's absolute position. It is a Vector3, meaning PositionedObjects can be controlled on the X, Y, and Z axes. Position is absolute even if the PositionedObject is a child (has a non-null Parent).

The following lists common ways that an object's Position values are set:

* Setting values on an Entity instance in the FRB Editor, such as the placement of an exit in a level
* Updating in response to the position of a child, such as an AxisAlignedRectangle moving along with its parent entity instance
* Moving in response to collision physics, such as a block being pushed by a player
* Changes caused by Velocity and Acceleration, such as a platformer entity falling

### Position and X,Y,Z properties

The Position field is another way of getting and setting the individual X, Y, and Z properties. In other words the following two lines are equivalent:

```csharp
// These do the same thing:
positionedObjectInstance.Position.X = 3;
positionedObjectInstance.X = 3;
```

### Position is Effectively Read-Only when Attached to a Parent

If a child PositionedObject is attached to a parent PositionedObject, then the child's Position values (along with the X, Y, and Z values) are effectively read-only. The "relative" counterparts must be used to change the position.&#x20;

By default every PositionedObject (Sprite, Circle, AxisAlignedRectangle, Text) in a child of the parent Entity. Therefore, the relative values must be used when assigning position in code.
