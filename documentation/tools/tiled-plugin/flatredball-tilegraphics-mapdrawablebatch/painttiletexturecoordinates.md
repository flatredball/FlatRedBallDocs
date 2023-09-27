## Introduction

PaintTileTextureCoordinates can be used to change the texture coordinates on a tile by its ordered index. This method can specify all four coordiantes (left, top, right, bottom) or just the top and left. If only the top and left are specified, the bottom and right are automatically determined based on the tileset's tile dimensions.

## Code Example

Note that this requires the ordered tile index. This sample assumes that tiles have been added manually, and then painted later.

``` lang:c#
// assuming map is a valid MapDrawableBatch:

var position = new Vector3(0,0,0);
var size = new Vector2 (16, 16);

// Note that AddTile uses pixels for the texture...
var index = map.AddTile(position, size, 0,0, 16, 16);

// now the index can be used to paint a different texture coordinate.
// Note that this uses texture coordinates not pixel coordinates:
// Here we use consts for the texture size to keep things simple but
// your code should use your actual texture size.
const float textureWidth = 1024;
const float textureHeight = 1024;
map.PaintTileTextureCoordinates(index, 32/textureWidth, 32/textureHeight);
```

 
