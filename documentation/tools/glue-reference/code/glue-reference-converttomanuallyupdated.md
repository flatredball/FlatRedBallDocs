## Introduction

Every Entity in Glue has a ConvertToManuallyUpdated method in generated code. This method will remove all contained objects in the Entity from their managers - including removing the Entity itself from being a managed [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). ManuallyUpdated Entities with visible objects (such as [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") will still be rendered. This method is not the equivalent to Destroy, so it should not be used as a substitute for this method. This method also recursively call ConvertToManuallyUpdated on any contained Entity instances. Note that manually-updated Entities will still have their CustomActivity called if they are added to other Entities or Screens through Glue, or if they are a part of PositionedObjectLists which have been added to Glue. For information on how to turn this off, see the [CallActivity](/frb/docs/index.php?title=Glue:Reference:Objects:CallActivity.md "Glue:Reference:Objects:CallActivity") property.

## Code Example

Assuming myEntity is valid Entity, you can simply call ConvertToManuallyUpdated on it:

    myEntity.ConvertToManuallyUpdated();

## Call ConvertToManuallyUpdated \*after\* positioning Entities

Once ConvertToManaullyUpdated is called, objects (such as Sprites) within an Entity will no longer respond to position or rotation changes on the Entity. Therefore, if you plan on calling this method, you should do so \*after\* you have finished positioning your Entities. For example, we'll assume an Entity type called Tree which you are placing in your level. You would want to do something like this:

    for(int i = 0; i < 10; i++)
    {
       Tree tree = new Tree();
       tree.X = i * 100;
       tree.ConvertToManuallyUpdated(); // <- Do this *AFTER* setting its position.
       this.TreeList.Add(tree);
    }

## When to use ConvertToManuallyUpdated

ConvertToManuallyUpdated is usually called in CustomInitialize of other Entities or containing Screens. ConvertToManuallyUpdated should be used on Entities which either have no every-frame activity (such as movement),or Entities which are manually updated to improve performance. For example, if an Entity has a large number of contained objects, but only one of them has any activity, it may be beneficial to call ConvertToManuallyUpdated, then manually update the single objects that are moving in the Entity's CustomActivity.

## Manually Updating Entities

Once an Entity is converted to manually updated, it will not have any automatic properties applied - such as Velocity, Acceleration, or Attachments. If an Entity is manually updated, you can select which updates you care about. For example, if you have an Entity which does not use Acceleration, then you can ignore this property and save some processing time (when compared to automatic FRB updates). This is especially important if you are using a large number of Entities in your game.
