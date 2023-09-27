## Introduction

The CreatedByOtherEntities property can be used if instances of an Entity will be created at runtime (such as bullets fired by a Spaceship Entity) in a location other than your current screen.

![](/media/2019-07-img_5d38c53bac271.png)

Setting this property to true does the following:

-   Glue will generate a factory for the Entity type which includes a CreateNew method that can be used to create new Entity instances.
-   Glue will automatically add any newly-created instance of the given Entity to any PositionedObjectLists created in any Screens in Glue.
-   Glue will display an additional property "PooledByFactory" which can be used to enable pooling to reduce post-load memory allocation.

For more information on CreatedByOtherEntities, see the [Created by Other Entities tutorial](/documentation/tools/glue-reference/entities/glue-tutorials-created-by-other-entities.md "Glue:Tutorials:Entities Created by Other Entities").
