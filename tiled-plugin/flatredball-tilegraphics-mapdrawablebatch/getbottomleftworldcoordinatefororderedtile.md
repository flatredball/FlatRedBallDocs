# GetBottomLeftWorldCoordinateForOrderedTile

### Introduction

The GetBottomLeftWorldCoordinateForOrderedTile method returns the world coordinate for the argument tile index. This can be used to identify the location of a tile based on its index.&#x20;

### Code Example - Displaying Indexes

The following code can be used to location of the first 100 tiles in a MapDrawableBatch:

```csharp
var layer = Map.MapLayers[0];

// only do 100 so we don't have performance problems:
for (int i = 0; i < 100; i++)
{
    layer.GetBottomLeftWorldCoordinateForOrderedTile(i, out float x, out float y);

    EditorVisuals.Text(i.ToString(), new Vector3(x + 8, y + 8, 0));
}
```

<figure><img src="../../.gitbook/assets/image.png" alt=""><figcaption><p>Indexes displayed on a MapDrawableBatch</p></figcaption></figure>
