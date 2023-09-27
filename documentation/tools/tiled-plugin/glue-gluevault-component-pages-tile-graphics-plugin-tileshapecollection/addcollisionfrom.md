## Introduction

The AddCollisionFrom method can be used to add AxisAlignedRectangle instances to the TileShapeCollection from a tile map (MapDrawableBatch).

## Code Examples

AddCollisionFrom provides lots of flexibility for adding collision. The simplest form is to add collision from a tile by the tile name. The following code adds collision for all tiles named "CollisionTile":

``` lang:c#
SolidCollisions.AddCollisionFrom(CurrentTileMap,"CollisionTile");
```

Using names is simple, but can also be restrictive. For example, we can check a tile to see if any of its properties are named "IsSpikes":

``` lang:c#
SpikeCollisions.AddCollisionFrom(CurrentTileMap,(list => 
                 list.Any(item => item.Name == "IsSpike" && item.Value == "true")));
```

Note that if adding collision based on tile property names alone (not the value), see the AddCollisionFromTilesWithProperty  method: [/documentation/tools/tiled-plugin/glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/addcollisionfromtileswithproperty/.md](/documentation/tools/tiled-plugin/glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/addcollisionfromtileswithproperty/.md)
