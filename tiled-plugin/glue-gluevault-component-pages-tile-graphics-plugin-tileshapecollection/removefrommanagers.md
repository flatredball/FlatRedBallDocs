# removefrommanagers

### Introduction

RemoveFromManagers removes all contained tiles from any managers and other PositionedObjectLists that hold the tiles. Specifically calling RemoveFromManagers will:

* Remove all shapes from the ShapeManager for every-frame management
* Remove all shapes from the ShapeManager for rendering
* Clear the TileShapeCollection
* Remove shapes in the TileShapeCollection from any other PositionedObjectList containing these shapes, including parent/child relationships

### Code Example

The following code will remove the calling TileShapeCollection from all managers and will clear it

```lang:c#
TileShapeCollectionInstance.RemoveFromManagers();
```

&#x20; &#x20;
