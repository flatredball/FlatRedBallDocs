# addmergedcollisionfromlayer

### Introduction

AddMergedCollisionFromLayer adds rectangles to the calling TileShapeCollection for all layers in the argument layer which have properties matching the predicate. Rather than creating individual rectangles for each tile, the created rectangles will be _merged_ - all adjacent rectangles in either a row or column will be combined into one to reduce memory consumption and to speed up collision calls. AddMergedCollisionFromLayer is similar to [AddMergedCollisionFromTilesWithProperty](addmergedcollisionfromtileswithproperty.md), but it provides more control over how collisions are created. Note that [AddMergedCollisionFromTilesWithProperty](addmergedcollisionfromtileswithproperty.md) is simpler and may provide enough flexibility for many games.

### Code Example

The following shows how to add collisions for any tile which has a property IsSpike with a value of true.

```lang:c#
myShapecollection.AddCollisionFrom(CurrentTileMap, LayerInCurrentTileMap, 
    (list => list.Any(item => item.Name == "IsSpike" && item.Value == "true")));
```

Note that in this case the Name is the name of the property and the Value is the value of the property. The code above could be modified to check any property or desired value.   &#x20;
