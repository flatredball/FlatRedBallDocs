## Introduction

This walkthrough will show how to directly access tile and object-layer tile properties. So far we have covered how to create collision from properties and how to use properties on objects to assign variables on FRB entities. All of these approaches rely on built-in methods to create collision and entities. This tutorial will perform a deeper dive on how to access tile properties for ultimate flexibility. Note that material covered in this tutorial gives the developer the most flexibility, it is not necessary to create a functional game. If you are interested in the bare minimum to get a game running, feel free to skip this tutorial.

## Accessing Tiles by Name

Each layer in the the tile map can contain its own list of tiles. For performance reasons each tile is not an individual object. In other words, we can't simply loop through a list of tile objects to check for certain properties. Instead, we have to ask each layer for a list of indexes for a given name. Once we've obtained these indexes, we can get the tile positions and perform custom logic. For example, we can create purple circles wherever we have a tile with the name "Goal" . First we'll need to modify our tileset to set one of our tiles to have the "Goal" name:

1.  Open Tiled

2.  Open the StandardTileset.tsx file

3.  Select a tile which will represent the goal tile

4.  Click the + button to add a new custom property

    ![](/media/2021-02-img_603188d1220aa.png)

5.  Enter the name **Name**

6.  Verify the type is **string**

7.  Click ****OK****

    ![](/media/2018-09-img_5b9e9bad2aa34.png)

8.  Set the value for the **Name** property to Goal ****

    ![](/media/2021-02-img_603188f602d54.png)

Note that FlatRedBall treats the **Name** property as the unique identifier for the tile. Therefore, the same name cannot be used for two different tiles - doing so will crash your program. We can modify the GameScreen.cs as shown in the following code:

``` lang:c#
void CustomInitialize()
{
    Camera.Main.X = Camera.Main.OrthogonalWidth / 2.0f;
    Camera.Main.Y = -1 * Camera.Main.OrthogonalHeight / 2.0f;
    CreateCirclesForGoalTiles();
}

private void CreateCirclesForGoalTiles()
{
    // We have to assign it in code beause the tile map doesn't
    // know its own tile width. Technically, tile maps don't have
    // to contain same-sized tiles. But we can set this value here
    // since we made the level and we know the size of the tiles:
    float halfTileDimension = 16 / 2.0f;

    foreach (var layer in Map.MapLayers)
    {
        if (layer.NamedTileOrderedIndexes.ContainsKey("Goal"))
        {
            var goalIndexes = layer.NamedTileOrderedIndexes["Goal"];

            foreach (var index in goalIndexes)
            {
                float tileLeft;
                float tileBottom;
                layer.GetBottomLeftWorldCoordinateForOrderedTile(index, out tileLeft, out tileBottom);

                float tileCenterX = tileLeft + halfTileDimension;
                float tileCenterY = tileBottom + halfTileDimension;

                var circle = ShapeManager.AddCircle();
                circle.X = tileCenterX;
                circle.Y = tileCenterY;
                circle.Radius = halfTileDimension;
                circle.Color = Microsoft.Xna.Framework.Color.Purple;
            }
        }
    }
}
```

If you add goals to your game you will see circles added wherever the goals are located:

![](/media/2021-02-img_60318989140e6.png)

![](/media/2021-02-img_603189f1c4584.png)

**Warning:** The purpose of the code above and much of the code in this guide is to show how to interact with tile properties at a low level. A realistic example would require additional code which would significantly increase the length of this tutorial. Keep in mind that the code above suffers from some serious problems. The created circles are not stored in a list so they cannot be used for any purpose aside from displaying on screen. Furthermore, since the circles are not stored in any list, they cannot be cleaned up. Exiting the screen or switching levels at this point would result in an exception.

## Reading Custom Properties from Tiles

The Name property is built-in to the Tiled Plugin, but we can also read custom properties. For example, we can modify the Goal tile to include a property for coloring the circle:

![](/media/2021-02-img_60318a4b85bb5.png)

This property can be read through the level's Properties . We'll modify the code to define the color value and default it to Green . It will be set to Yellow  if the CircleColor  property is Yellow :

``` lang:c#
private void CreateCirclesForGoalTiles()
{
    // We have to assign it in code beause the tile map doesn't
    // know its own tile width. Technically, tile maps don't have
    // to contain same-sized tiles. But we can set this value here
    // since we made the level and we know the size of the tiles:
    float halfTileDimension = 16 / 2.0f;

    // We assigned the properties for walls in the tileset (tsx) file,
    // so all walls will have the same value for color. Therefore, we
    // can read the value now before we get into the loop. If we were dealing
    // with properties on objects in an object layer, then we could read the properties
    // on the object inside of the loop, assigning a different value to each one.
    var propertiesForGoal = Map.TileProperties["Goal"];
    Microsoft.Xna.Framework.Color color = Microsoft.Xna.Framework.Color.Purple;
    // We could expand this to support more colors, but we'll just test for yellow now:
    var circleProperty = propertiesForGoal.FirstOrDefault(item => item.Name == "CircleColor");
    if ((string)circleProperty.Value == "Yellow")
    {
        color = Microsoft.Xna.Framework.Color.Yellow;
    }

    foreach (var layer in Map.MapLayers)
    {
        if (layer.NamedTileOrderedIndexes.ContainsKey("Goal"))
        {
            var goalIndexes = layer.NamedTileOrderedIndexes["Goal"];

            foreach (var index in goalIndexes)
            {
                float tileLeft;
                float tileBottom;
                layer.GetBottomLeftWorldCoordinateForOrderedTile(index, out tileLeft, out tileBottom);

                float tileCenterX = tileLeft + halfTileDimension;
                float tileCenterY = tileBottom + halfTileDimension;

                var circle = ShapeManager.AddCircle();
                circle.X = tileCenterX;
                circle.Y = tileCenterY;
                circle.Radius = halfTileDimension;
                circle.Color = color;
            }
        }
    }
}
```

We obtain the circle color outside of any loops because the properties set on tiles in a tile set apply to the entire map, so the value will be the same regardless of layer or individual tile. For instance-specific properties we need to use objects on an Object Layer, as we'll show later in this guide. Now our game displays yellow circles:

![](/media/2021-02-img_60318c436a13e.png)

## Removing Tiles

Tiles can be removed dynamically removed using the RemoveQuads  method. For example, we can remove all of the goal tiles used to create circles:

``` lang:c#
private void CreateCirclesForGoalTiles()
{
    // We have to assign it in code beause the tile map doesn't
    // know its own tile width. Technically, tile maps don't have
    // to contain same-sized tiles. But we can set this value here
    // since we made the level and we know the size of the tiles:
    float halfTileDimension = 16 / 2.0f;

    // We assigned the properties for walls in the tileset (tsx) file,
    // so all walls will have the same value for color. Therefore, we
    // can read the value now before we get into the loop. If we were dealing
    // with properties on objects in an object layer, then we could read the properties
    // on the object inside of the loop, assigning a different value to each one.
    var propertiesForGoal = Map.TileProperties["Goal"];
    Microsoft.Xna.Framework.Color color = Microsoft.Xna.Framework.Color.Purple;
    // We could expand this to support more colors, but we'll just test for yellow now:
    var circleProperty = propertiesForGoal.FirstOrDefault(item => item.Name == "CircleColor");
    if ((string)circleProperty.Value == "Yellow")
    {
        color = Microsoft.Xna.Framework.Color.Yellow;
    }

    foreach (var layer in Map.MapLayers)
    {
        if (layer.NamedTileOrderedIndexes.ContainsKey("Goal"))
        {
            var goalIndexes = layer.NamedTileOrderedIndexes["Goal"];

            foreach (var index in goalIndexes)
            {
                float tileLeft;
                float tileBottom;
                layer.GetBottomLeftWorldCoordinateForOrderedTile(index, out tileLeft, out tileBottom);

                float tileCenterX = tileLeft + halfTileDimension;
                float tileCenterY = tileBottom + halfTileDimension;

                var circle = ShapeManager.AddCircle();
                circle.X = tileCenterX;
                circle.Y = tileCenterY;
                circle.Radius = halfTileDimension;
                circle.Color = color;
            }
            layer.RemoveQuads(goalIndexes);
        }
    }
}
```

![](/media/2021-02-img_60318c9cee7ee.png)

## Accessing Object Layer Properties

Tiles on "Object Layers" can contain instance-specific properties, as were used to create the Door instance in an earlier guide. We can also access these properties similar to how we access properties on tiles. We'll write code to look for any tiles that have their "Type" property set to "Door", then manually create a door for every tile we find. To do this, add the following function to GameScreen.cs:

``` lang:c#
private void ManualDoorCreation()
{
    // This returns the names of all tiles and tile objects
    // which use this property:
    var names = TilePropertiesTmx.TileNamesWith("Type").ToArray();

    // Loop through all names...
    foreach (var name in names)
    {
        // ...get all of the properties associated with this name...
        var propertiesForName = Map.TileProperties[name];

        // ... and get the entityToCreate for this name. 
        var typeProperty = propertiesForName.FirstOrDefault(item => item.Name == "Type");

        // We only care about "Door" for this example:
        if ((string)typeProperty.Value == "Door")
        {
            // Doors may be present on any layer
            foreach (var layer in Map.MapLayers)
            {
                // Does this layer have any "Door" creating tiles?
                if (layer.NamedTileOrderedIndexes.ContainsKey(name))
                {
                    var indexes = layer.NamedTileOrderedIndexes[name];

                    foreach (var index in indexes)
                    {
                        // We don't know the dimensions of objects, and we shouldn't assume they are the
                        // same size as our normal tiles. We can obtain the dimensions by getting two opposite
                        // corners
                        var bottomLeftPoint = layer.Vertices[index];
                        var topRightPoint = layer.Vertices[index + 2];

                        var middle = (bottomLeftPoint.Position + topRightPoint.Position) / 2.0f;

                        var door = Factories.DoorFactory.CreateNew();
                        door.Position = middle;
                    }

                    // This removes all found quads:
                    layer.RemoveQuads(indexes);
                }
            }
        }
    }
}
```

Like before, we need to call this method in CustomInitialize :

``` lang:c#
void CustomInitialize()
{
    CreateCirclesForWallTiles();

    ManualDoorCreation();
}
```

  Of course you may not need to actually run code like this since it's automatically handled by generated code, but this can provide some insight into how to create your own entities in code.  
