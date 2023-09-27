## Solution 1 - Controlling order

The simplest solution to reducing render breaks is to control the sorting of your Sprites. One way to do this is to control the order in which Sprites are added to the engine. Keep in mind that Z values control sorting by default, so if your Sprites have different Z values then the order in which they are added to the engine will get overwritten when they are sorted by Z.

We can control this by modifying the for loop in TextureTestScreen so it reads:

    for (int i = 0; i < 1000; i++)
    {
        Sprite sprite;
        if (i < 500)
        {
            sprite = SpriteManager.AddSprite(redball);
        }
        else
        {
            sprite = SpriteManager.AddSprite(greenball);
        }
        SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
    }

![ReducedRenderBreaks.png](/media/migrated_media-ReducedRenderBreaks.png)

Despite using multiple textures, our frame rate is still capped at 29. In other words, this seems to have solved our problem; however it has introduced a potentially undesirable problem: all of the green balls are rendered first, then all of the red balls. Our second picture (where frame rate was much lower) displays the balls mixed in with each other.

## Sprite Creation order is not always controllable

Sprites are created in many ways. A typical game may create some Sprites by loading a .scnx file, may create some Sprites in Glue generated code, and may create some Sprites long after the Screen has initialized - such as bullets fired by the player. So despite the fact that the above code solved our problem a large number of render breaks, it's not a very practical solution.

So far we've identified two problems:

1.  The order of creation is hard to control
2.  The order that Sprites are rendered is fixed - all Sprites of a certain type must be rendered at the same time.

Let's simulate a situation where the order of Sprites is undetermined, but where order does not matter. In other words, let's look at a situation where we don't care about the 2nd point. To get this, change the CustomInitialize code in TextureTestScreen so it reads:

    for (int i = 0; i < 1000; i++)
    {
        Sprite sprite;
        if (FlatRedBallServices.Random.NextDouble() > .5)
        {
            sprite = SpriteManager.AddSprite(redball);
        }
        else
        {
            sprite = SpriteManager.AddSprite(greenball);
        }
        SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
    }

Now our Sprite textures will be created randomly to simulate a situation where we don't control the order of creation, but all Z values will still be the same, to simulate an ability for us to control the ordering and not be impacted by the Z value of Sprites. As we might expect the number of render breaks will increase, and performance will decrease:

![RandomSpritesWithRenderBreaks.png](/media/migrated_media-RandomSpritesWithRenderBreaks.png)

As expected the numbers reflect lower performance and more render breaks, but not quite as severe as when we were intentionally alternating between textures.

Next we'll show how to order by texture after the Sprites have been created.

## Sorting by Texture

FlatRedBall has a built-in method for sorting Sprites by their Texture. This method is especially useful because it obeys the Z ordering of Sprites, so it only sorts Sprites with the same Z values by their textures. This means that this method can be called even if some of your Sprites use different Z values.

To sort by texture, add the following code after the for-loop that creates all Sprites:

    SpriteManager.SortTexturesSecondary();

This essentially gets us back to where we were before - all Sprites with one texture will be drawn first, then all Sprites with the the other Texture. We are able to get great framerate despite not controlling the order in which Sprites are created:

![AfterSortedByTexture.png](/media/migrated_media-AfterSortedByTexture.png)

## When is sorting by texture valuable?

The general answer is - if you have a lot of Sprites that use the same render states on the same Z, and they are mixed with other Sprites on the same Z then SortTexturesSecondary can be very effective in reducing render breaks. Common examples include systems where multiple particles are being rendered, or tile maps.
