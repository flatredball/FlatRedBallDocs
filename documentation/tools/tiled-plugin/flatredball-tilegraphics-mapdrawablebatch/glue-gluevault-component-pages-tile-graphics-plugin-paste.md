## Introduction

This article shows how to use the MapDrawableBatch to render a large number of Sprites very efficiently. The MapDrawableBatch is less flexible than using individual Sprites; however, in exchange for giving up that flexibility the MapDrawableBatch can be extremely efficient. In fact regardless of optimizations the FlatRedBall Engine will likely never be able to render a large number of Sprites faster than MapDrawableBatch because of the flexibility it supports. Keep in mind that the MapDrawlableBatch is used for Sprites which do not move. Once they have been pasted, they will be there until MapDrawableBatch is either made invisible or removed completely from the engine. This makes the MapDrawableBatch ideal for tile maps and static environments; although it could be used for other static objects such as backgrounds and static UI/HUD components.

## Paste and Sprites

Internally MapDrawableBatches do not store references to Sprites. Instead they store a list of vertices which are used for rendering, much like model objects when dealing with 3D rendering. The Paste method will create a new set of vertices to match the argument Sprite; however, the Sprite itself is not held by the MapDrawableBatch. This means that the same Sprite can be used over and over to reduce allocation during the creation of a MapDrawableBatch.

## Code Example

The following code shows how to create a 4096 (that's 64x64) MapDrawableBatch using the Paste method. Despite the large number of Sprites, the MapDrawableBatch will render efficiently - even on mobile platforms such as the Windows Phone 7.

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", ContentManagerName);
    int numberOfSprites = 64 * 64;

    MapDrawableBatch map = new MapDrawableBatch(numberOfSprites, texture);

    // This is the Sprite that we'll reuse
    Sprite sprite = new Sprite();
    sprite.Texture = texture;

    for (int i = 0; i < numberOfSprites; i++)
    {
        sprite.X = 2 * (i % 64);
        sprite.Y = 2 * (i / 64);
        map.Paste(sprite);
    }
    SpriteManager.AddDrawableBatch(map);

You will need to add the following using statement for MapDrawableBatch to be resolved:

    using FlatRedBall.TileGraphics;

![MapDrawableBatch1.PNG](/media/migrated_media-MapDrawableBatch1.PNG)

## Paste does not reference Sprites

The Paste method adds vertices to the MapDrawableBatch class. The Sprite which is passed in the map method is \*not\* stored by the MapDrawableBatch. This means a few things:

-   Changes to the Sprite after paste will not be reflected in the map. This means that if you move the Sprite around, it will not change on the map. The map is static.
-   Since the Sprite reference is not used internally in the MapDrawableBatch, the same Sprite can be used over and over. This reduces the amount of allocation needed when creating a MapDrawableBatch.
