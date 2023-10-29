## Introduction

AddCollisionFromTilesWithProperty adds rectangles to the calling TileShapeCollection for all tiles which have the argument custom property. This is the most common way to create collisions from a TMX file in code.

## Code Example

``` lang:c#
solidCollision.AddCollisionFromTilesWithProperty(TmxFile, "SolidCollision");
```

Additional Information For more control over which tiles create collisions (for example checking a property and its value), see the AddCollisionFrom method: http://flatredball.com/documentation/tools/tiled-plugin/glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/addcollisionfrom/
