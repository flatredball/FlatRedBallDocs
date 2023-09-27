## Introduction

Destroy method fully removes the LayeredTileMap from the engine. Specifically this method performs the following:

-   Removes the LayeredTileMap from the engine's DrawableBatch list (removes it from being rendered)
-   Removes all TileShapeCollections that have been created when the LayeredTileMap was loaded
-   Removes any ShapeCollections created by shapes included in the LayeredTileMap
-   Removes this object from being managed by the engine (if the map uses velocity, acceleration, or other every-frame variables)

This method is automatically called if the LayeredTileMap is loaded from a TMX in generated code, but must be called manually if the map is created manually in custom code.

## Code Example

The following code destroys the calling LayeredTileMap:

``` lang:c#
LayeredTileMapInstance.Destroy();
```

     
