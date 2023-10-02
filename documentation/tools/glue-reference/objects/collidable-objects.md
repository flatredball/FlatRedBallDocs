# collidable-objects

### Introduction

If an object is collidable, Glue displays a Collision tab. The following types can be collidable:

* Collidable entity instances (like a single Player entity in a screen)
* Collidable entity lists (like a list of Bullets in a screen)
* TileShapeCollections (like SolidCollision in a screen)
* ShapeCollection (like a ShapeCollection containing trigger zones for ending a level)

The following shows the Collision tab for a BulletList, which is a list of Bullets where the Bullet entity implements the ICollidable interface.

![](../../../../media/2021-03-img\_6040f2f675be3.png)

### Partitioning

If the selected object is a list of collidables, then it can be partitioned. By default partitioning is turned off because incorrect values can cause collision to fail. However, partitioning is critical for games with a large number of objects such as Kosmo Squad. ![](https://cdn.akamai.steamstatic.com/steam/apps/1448070/ss\_61c7bc5936ca829c8ea8da9ba38fd17cdb82b100.1920x1080.jpg?t=1605029685) If a list performs collision partitioning, Glue provides a number of options for partitioning, as shown in the following image:

![](../../../../media/2021-03-img\_6040fe7465256.png)

#### Should Partitioning be Enabled?

Usually the answer is "yes, but maybe not now". Of course, for games with small numbers of objects it may not improve the game's performance much. Games with larger numbers of objects can improve performance by enabling partitioning, but partitioning can also introduce bugs so it's recommended to not turn on partitioning at the beginning of the development process unless you suspect that collision is already causing performance problems.

#### Sort Axis

The **Sort Axis** is used to partition objects. In general we recommend leaving the **Sort Axis** to its default X value unless you are certain that your game will be distributed more along the Y axis than the X axis. If two lists collide against each other, then both lists must have the same sort axis. Therefore, sort axis is usually something you decide for your entire game rather than on a list-by-list basis.

#### Partition Width/Height

This value indicates the maximum width or height of the entity in the current list. Keep in mind that entities in a list may or may not all be the same size. For example, you may have an EnemyList, but the Enemy instances inside the list may be of different size. The **Partition Width/Height** should be set to the **largest** possible width or height of any object in the list.

#### Sort List Every Frame

This option tells Glue whether to sort the list every frame for partitioning or not. If objects within the list can move (such as bullets), then sorting should happen every frame. If objects in a list cannot move (such as doors in a level) then sorting does not need to happen every frame.     &#x20;
