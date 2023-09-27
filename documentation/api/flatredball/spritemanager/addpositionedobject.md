## Introduction

The AddPositionedObject method is a method which adds an existing PositionedObject instance to the SpriteManager for management. Managed PositionedObjects will have velocity, acceleration, drag, and attachment properties applied automatically every frame. This method should only be called for objects which are otherwise not handled specifically by the FlatRedBall Engine. For example, Sprites are managed by the SpriteManager when they are added to the SpriteManager, so they should not also be added as PositionedObjects to the SpriteManager - doing so would result in update logic being called twice per frame.

## AddPositionedObject and Entities

Entities added to Screens will automatically have AddPositionedObject called by default. The AddPositionedObject call is performed inside of all Entities' AddToManagers call. Therefore, in all but the rarest circumstances you will not need to call AddPositionedObject on an Entity.

## When to use AddPositionedObject

AddPositionedObject can be used if you are creating a custom type which inherits directly from PositionedObject, and which should have every-frame logic called.

## What does the SpriteManager call?

PositionedObjects which are added to the SpriteManager will have the following methods/logic called:

-   [FlatRedBall.PositionedObject.ExecuteInstructions](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ExecuteInstructions&action=edit&redlink=1.md "FlatRedBall.PositionedObject.ExecuteInstructions (page does not exist)")
-   [FlatRedBall.PositionedObject.TimedActivity](/frb/docs/index.php?title=FlatRedBall.PositionedObject.TimedActivity.md "FlatRedBall.PositionedObject.TimedActivity")
-   [FlatRedBall.PositionedObject.Pause](/frb/docs/index.php?title=FlatRedBall.PositionedObject.Pause&action=edit&redlink=1.md "FlatRedBall.PositionedObject.Pause (page does not exist)") (If the engine is paused)
-   [FlatRedBall.PositionedObject.UpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.UpdateDependencies.md "FlatRedBall.PositionedObject.UpdateDependencies")
