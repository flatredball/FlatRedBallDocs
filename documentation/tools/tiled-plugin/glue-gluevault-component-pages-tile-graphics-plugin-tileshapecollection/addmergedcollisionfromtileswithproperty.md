# addmergedcollisionfromtileswithproperty

### Introduction

AddMergedCollisionFromTilesWithProperty  adds rectangles to the calling TileShapeCollection  for all tiles in the first argument (LayeredTileMap). Rather than creating individual rectangles for each tile, the rectangles will be _merged_ - all adjacent rectangles in either a row or column will be combined into one to reduce memory consumption and to speed up collision calls. Merging will happen either along rows or columns depending on the SortAxis  property.

### Code Example

The following code creates adds collision to a LayeredTileMap  called SolidCollision  from a LayeredTileMap  called Level1 . It adds collision for all tiles with the property HasCollision .

```lang:c#
SolidCollision.Visible = true;
SolidCollision.AddMergedCollisionFromTilesWithProperty(Level1, "HasCollision");
```

### Visual Example

Consider the following image (from Tiled). In this map all painted tiles have the HasCollision property, so all tiles will create collision. ![](../../../../media/2017-11-img\_5a10673318856.png) At runtime this will produce the following collision if not using merged collision (if calling AddCollisionFromTilesWithProperty ) : ![](../../../../media/2017-11-img\_5a106798b374f.png) If we change the call to use AddMergedCollisionFromTilesWithProperty  then the number of rectangles is significantly reduced, as shown in the following image:

![](../../../../media/2017-11-img\_5a106812bef15.png)

Merging will work even for more complex maps, such as maps with gaps and concave areas, as shown in the following image:

![](../../../../media/2017-11-img\_5a106965ab714.png)

### Row vs. Column Merging

As mentioned above, merging will be performed according to the SortAxis property. By default the SortAxis value is set to X, so collision will be merged along columns, so that the rectangles can be sorted along the X axis.

![](../../../../media/2017-11-img\_5a106bfda5e98.png)

If we change the SortAxis  to Y  prior to adding collision, then merging will happen along rows.

```lang:c#
SolidCollision.Visible = true;
SolidCollision.SortAxis = FlatRedBall.Math.Axis.Y;
SolidCollision.AddMergedCollisionFromTilesWithProperty(Level1, "HasCollision");
```

![](../../../../media/2017-11-img\_5a106d097031e.png)

In general the SortAxis should be X if the map is wider than it is tall, and it should be Y if the map is taller than it is wide. Adjusting the SortAxis according to the map's width or height will allow collision partitioning to operate efficiently.

&#x20;
