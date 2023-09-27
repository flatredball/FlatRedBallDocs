## Introduction

RelativePosition (which mirrors the RelativeX, RelativeY, and RelativeZ properties) represents the position of a given PositionedObject relative to its parent. If a PositionedObject does not have a parent, then changing RelativePosition does not modify the PositionedObject. If a PositionedObject does have a parent, changing the RelativePositions will change the absolute Position of the PositionedObject, but not immediately. Dependencies must be updated before absolute positions are changed.

## Relative Position and Glue

Relative position is used in almost every Glue project, but Glue simplifies the process. If an Entity contains an object which is a PositionedObject (such as a Sprite, Circle, or other Entity), then the object will be attached to its containing Entity. Changing the object's X, Y, or Z value will result in Glue ultimately changing the RelativePosition of the object.

## Code Example

The following code changes the relative position of a PositionedObject (such as an Entity, Sprite, or Circle). For RelativePosition to have an impact on an object's actual position, it must be attached to something. RelativePosition can be changed as follows:

    MyPositionedObjectInstance.RelativePosition.X = 100;
    MyPositionedObjectInstance.RelativePosition.Y = 30;

The individual component properties can also be accesed as follows:

    MyPositionedObjectInstance.RelativeX = 100;
    MyPositionedObjectInstance.RelativeY = 30;

These two approaches are identical and result in the same outcome. The two approaches are provided for convenience.

## When to use Relative values

Relative values must be used if you would like to move a PositionedObject which is attached to another PositionedObject. For example, if you are using Glue, you may have a Tank Entity with two Sprites:

1.  Body
2.  Turret

By default both the Body and the Turret Sprite will be attacked to the Tank. If you want to rotate the turret independently, then you must control the Turret. In this particular case you may want to control the RelativeRotationZ or RelativeRotationZVelocity value; however, the general idea is the same: You must use relative values to control an attached PositionedObject.

## Mirrored properties

The following properties mirror each other

|                    |                             |
|--------------------|-----------------------------|
| Float property     | Vector3 Property            |
| instance.RelativeX | instance.RelativePosition.X |
| instance.RelativeY | instance.RelativePosition.Y |
| instance.RelativeZ | instance.RelativePosition.Z |

## Updating Dependencies

In most cases if you modify RelativePosition, you never have to worry about updating dependencies - dependencies are updated right before the engine performs the draw for a given frame - so everything will always appear up-to-date. However, if you are modifying RelativePosition values and you need to have those result in changes to absolute position, you will want to force the dependency update:

    somePositionedObject.RelativePosition.X = 5;
    somePositionedObject.RelativePosition.Y = 3;
    // After this call, somePositionedObject's Position values will be up-to-date
    somePositionedObject.ForceUpdateDependencies();

For more information, see [the ForceUpdateDependencies page](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies "FlatRedBall.PositionedObject.ForceUpdateDependencies").
