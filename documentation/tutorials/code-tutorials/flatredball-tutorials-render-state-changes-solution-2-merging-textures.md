## Introduction

The previous solution showed how to control the ordering of Sprites as to reduce the number of render breaks. The downside with this approach is that it reduces/eliminates the control over ordering that you get from setting the Z value of Sprites. This tutorial will cover how we can solve the problem by merging multiple textures into one texture.

## Textures and Files

Although the two are closely related, image files and textures are not the same thing. An image file (like a .PNG) is a file that is on disk which can get loaded by FlatRedBall into a texture. A texture (specifically a Texture2D) is an object which is loaded from an image file. The reason we make this distinction is because we have two options.

One option is to combine the two .PNG files into a single file and use texture coordinates on the Sprite to select whether the Sprite is a green or red Sprite.

The other option is to load both .PNGs, but then combine the two resulting Texture2Ds into one Texture2D either through XNA calls or by using [the ImageData class](/frb/docs/index.php?title=FlatRedBall.Graphics.Texture.ImageData.md "FlatRedBall.Graphics.Texture.ImageData").

To keep the code simple, we'll combine the two .PNGs into one.

This can be done in any image manipulation program. I will cover using [Paint.NET](http://www.getpaint.net/).

## Combining images in Paint.NET

To combine the images in Paint.NET:

1.  Open Paint.NET
2.  Drag+drop redball.png into Paint.NET
3.  Select the option to "Open" the image. The redball.png image should show up.
4.  Drag+drop the greenball.png into Paint.NET
5.  Select the option to "Open" the image. The greenball.png image should show up.
6.  With greenball.png showing, select the menu option "Image"-\>"Canvas Size..."
7.  Change the Anchor to "Left" (through the drop-down or by clicking on the middle-left square)
8.  Change width to 64 (verify "Maintain aspect ratio" is not selected)
9.  Click OK![PaintDotNetMerging1.PNG](/media/migrated_media-PaintDotNetMerging1.PNG)
10. Switch back to the redball.png
11. Press CTRL+A to select the entire image
12. Press CTRL+C to copy it
13. Switch to the greenball.png image
14. Press CTRL+V to paste it
15. Use the mouse or arrow keys to slide the pasted image to the right. You can hold the CTRL key and scroll the moue wheel to zoom in![TwoInOneBalls.PNG](/media/migrated_media-TwoInOneBalls.PNG)
16. Save the file as combined.png

## Using combined.png

Now that we have one .PNG file that includes both files we can use it in our code. To do this:

1.  Add combined.png to TextureTestScreen in Glue (just like you did before by either drag+dropping or right-clicking on the Files item)
2.  Modify the CustomInitialize code in TextureTestScreen to read as follows:

&nbsp;

    for (int i = 0; i < 1000; i++)
    {
        Sprite sprite = SpriteManager.AddSprite(combined);
        if (FlatRedBallServices.Random.NextDouble() > .5)
        {
            sprite.LeftTextureCoordinate = 0;
            sprite.RightTextureCoordinate = .5f;
        }
        else
        {
            sprite.LeftTextureCoordinate = .5f;
            sprite.RightTextureCoordinate = 1;
        }
        SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
    }
    // We no longer need to sort by textures - we only have 1 texture we're using

As expected we see a significant boost in performance (and reduction in render breaks):![RenderingUsingCombined.png](/media/migrated_media-RenderingUsingCombined.png) This solution is a very powerful solution because once the initial art and Sprites are set-up there are no restrictions. We can instantiate objects however we want, and we can draw them in any order. Since texture coordinate changes do not require render breaks, then combining textures into larger images can greatly improve performance. This is one of the main reasons why sprite sheets (single files containing multiple images) are so common in games.

## Drawbacks to using sprite sheets

Modern computers and Windows Phones can handle textures up to 2048 x 2048, so a lot of graphics can fit on a single texture. Keep in mind that while this is a great solution for improving performance, it has some drawbacks:

-   Your game may not need all images, so you may be loading additional image data and using more RAM than you would otherwise need to.
-   Some platforms may not support large textures. Android devices, for example, may have a smaller maximum texture resolution.
-   Working with sprite sheets can be more complicated as it requires setting up texture coordinates manually.
-   Filtering can blur Sprite rendering and result in a Sprite rendering adjacent textures. This is very common when using sprite sheets and tile maps.
-   Modifying sprite sheets can be time consuming. Shifting pieces of a sprite sheet may result in changes to code, Glue variables/states, Scenes, and AnimationChains.
-   Retroactively moving a game to use sprite sheets can be a very difficult to do. However, creating a game using sprite sheets from the beginning can also be difficult/impossible unless you and the rest of your team are familiar with the process and unless you have a good sense of how much content your game will use.
