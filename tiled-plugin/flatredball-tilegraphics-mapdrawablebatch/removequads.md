# removequads

### Introduction

RemoveQuads can be used to remove quads from the MapDrawableBatch by index. This method is useful in situations where you want to remove tiles from the MapDrawableBatch at runtime, such as when creating Entities from the contents of a tile map.

### Code Example

The following shows how to remove the first three tiles from the MapDrawableBatch:

```
List<int> toRemove = new List<int>();
toRemove.Add(0);
toRemove.Add(1);
toRemove.Add(2);
// assuming MyLevel is a valid LayeredTileMap:
MyLevel.MapLayers[0].RemoveQuads(toRemove);
```

For more information on LayeredTileMap, see the [LayeredTileMap page](../../../../frb/docs/index.php).

### Code Example - Removing Quads With the Cursor

Often the internal quad ordering is unknown. Therefore, the MapDrawableBatch class provides a GetQuadIndex method to convert world X and Y to an index. If no tile is located at the index, a value of null is returned. The following code could be used to remove quads when the user clicks a mouse:

```
var cursor = GuiManager.Cursor;
if(cursor.PrimaryPush)
{
  var quadIndex = MapLayer.GetQuadIndex(cursor.WorldX, cursor.WorldY);

  if(quadIndex != null)
  {
    // RemoveQuads takes an IEnumerable so that multiple quads can be removed at once
    List quads = new List(){quadIndex.Value};
    MapLayer.RemoveQuads(quads);
  }
}
```
