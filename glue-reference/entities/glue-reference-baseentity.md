# glue-reference-baseentity

### Introduction

The BaseEntity property controls the inheritance of a given Entity. An Entity can inherit from another Entity, or it can inherit from a FlatRedBall type, like Sprite.

![](../../media/2017-02-img_58b3a85f1cdf9.png)

### Inheriting from other Entities

Entities can inherit from other Entities. Entity inheritance is the current recommended approach for creating a variety of common entities, such as multiple Enemy types in a game. To do this:

1.  Click on the Add Entity quick action

    ![](../../media/2023-07-img_64b09867579c8.png)
2.  Use the **Base Entity** dropdown to select the base entity

    ![](../../media/2023-07-img_64b0988c890c8.png) Note that when a Base Entity is selected, most of the options are hidden since the new entity inherits those properties from its base.
3. Click **OK**

The new entity now inherits from the selected **Base Entity.**

![](../../media/2023-07-img_64b098e3931ba.png)

#### Inheriting when Creating a New Entity

A new entity can be created as a derived entity in the new entity window.

### Inheriting from FlatRedBall Types

Entities can inherit from FlatRedBall types, such as Sprites. By default Entities inherit from PositionedObject, but this inheritance can be modified through Glue. The reason this feature exists is primarily to improve performance and reduce memory consumption. For more information, see the [Inheriting from FlatRedBall Types tutorial](glue-tutorials-inheriting-from-flatredball-types.md).
