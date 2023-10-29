# insertcollidables

### Introduction

InsertCollidables allows the adding of a list of ICollidable rectangles to a ShapeCollection. This is usually done for collidables which align with a grid and which are used for solid or platformer collision.

### Conceptual Explanation

Often when creating solid collisions, a game uses the [TileShapeCollection type](../../documentation/tools/tiled-plugin/glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection.md). However, at times each collision rectangle should be an entity. This is necessary if the collision has additional behavior beyond collision. For example blocks may play animations, may trigger game actions (such as unlocking a door), or may HP and break (such as when being shot). In situations like these, each block should be an entity to keep track of its state and to provide additional functionality through custom code. TileShapeCollections automatically adjust their contained rectangle RepositionDirections, but collidable lists do not have this functionality built-in. Prior to adjusting reposition directions, a row of blocks may have the following RepositionDirections:

![](../../media/2021-04-img\_606f1937e27db.png)

The purple reposition directions are considered undesirable because they can cause snagging. After fixing this problem using InsertCollidables, the RepositionDirections will only point outward, allowing other entities to collide without snagging.

![](../../media/2021-04-img\_606f1960a1e9c.png)

### Example - Adding Blocks to a ShapeCollection

This example uses a collidable entity named **Block** which has a list called **BlockList** in **GameScreen**.

![](../../media/2021-04-img\_606f1b18938c1.png)

We will use an empty TileShapeCollection to fix the RepositionDirections:

1. Add a new **TileShapeCollection** to the **GameScreen** called **CombinedTileShapeCollection**. The name CombinedTileShapeCollection is a recommended name for TileShapeCollections used specifically for fixing RepositionDirections. ![](../../media/2021-04-img\_606e7af403266.png)
2. Leave the newly-created TileShapeCollection as empty. ![](../../media/2021-04-img\_606e7b17605f1.png)
3. In code, call **InsertCollidables** on the CombinedTileShapeCollection to add the BlockList

&#x20;

```
CombinedTileShapeCollection.InsertCollidables(BlockList);
```

Now all blocks in the BlockList will have their RepositionDirections adjusted for every Block that is already created when the method is called.
