## Introduction

The Destroy method is a method which can be used to destroy an instance of an Entity. The Destroy method is also used in generated code to destroy Entity instances that Glue is aware of. The Destroy method does not need to be called if an Entity was added through Glue, or if an Entity is part of a PositionedObjectList created in Glue - in thee cases Glue will take care of calling Destroy when the containing Screen.

## Understanding when to call Destroy

For information on when to call Destroy, as well as a general discussion of when Glue calls Destroy for you see [the "Destroying Entity Instances" tutorial](/frb/docs/index.php?title=Glue:Tutorials:Destroying_Entity_Instances.md "Glue:Tutorials:Destroying Entity Instances").

## What does Destroy modify/do?

As mentioned above, Destroy needs to be called on all Entities. In many cases generated code will automatically call Destroy on Entities; however, in some cases you may need to call it yourself. The Destroy function is responsible for the following:

-   Removing any visible objects from their respective managers. After Destroy is called, a given Entity will no longer be drawn.
-   Removing attachments. If an Entity is destroyed then it will automatically detach itself from anything it is attached to, and anything that is attached to it will be detached.
-   Removing any updated objects from their managers. This means that any objects which have properties like Velocity or Acceleration will no longer have these properties set.

## Referencing Destroyed Entities

If an Entity is destroyed it will be removed from all FlatRedBall systems; however that does not mean that references to the Entity will be removed. For example consider the following situation:

    // This assumes that Enemy is a valid Entity type and that this code is written in a Screen's custom code:
    // First create the Enemy
    Enemy enemyInstance = new Enemy(ContentManagerName);
    // Then destroy it
    enemyInstance.Destroy();
    // At this point the game will not show enemyInstance; however enemyInstance is still a valid reference:
    enemyInstance.X = 4;
    // This will set otherEnemyInstance's X to 4
    otherEnemyInstance.X = enemyInstance.X;

If you intend to create and destroy an entity instance we recommend one of two approaches:

-   Add the entity instance to a PositionedObjectList of Entities. When it is destroyed, it will automatically be removed from the list. This is a good approach for entities which will be either created and destroyed as the game is played (such as bullets) or entities which are all created at the beginning of a Screen then removed over time (such as pellets in Pac Man).
-   Set the Entity to be invisible. If you simply don't want it drawn or to be clickable with the Cursor, then setting it to invisible will remove it from the player's perspective.
