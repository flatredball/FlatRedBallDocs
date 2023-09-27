## Introduction

Position is a variable which controls a PositionedObject's absolute position. The PositionedObject is a Vector3, meaning PositionedObjects can be controlled on the X, Y, and Z axes. Position is a value which controls and returns the **absolute** position of a PositionedObject.

## Position and X,Y,Z properties

The Position variable is a "mirror" variable for the X, Y, and Z properties on a PositionedObject. In other words the following two lines are equivalent:

    // These do the same thing:
    positionedObjectInstance.Position.X = 3;
    positionedObjectInstance.X = 3;

## Position is read-only when a PositionedObject is attached

As the title implies, if a PositionedObject is attached to another PositionedObject, then the Position values (along with the X, Y, and Z values) are all read-only. The "relative" counterparts must be used. By default every PositionedObject (Sprite, Circle, AxisAlignedRectangle, Text) in an Entity is attached to that Entity. Therefore, the relative values must be used when assigning position in code.
