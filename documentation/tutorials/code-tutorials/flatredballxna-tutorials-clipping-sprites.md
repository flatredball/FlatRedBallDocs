## Introduction

Clipping is the process of removing part of a Sprite from being rendered by defining a rectangular area which will contain the Sprite. This tutorial will show you how to write code to clip Sprites within a rectangle. This form of clipping has some requirements:

-   The Sprite being clipped must not be rotated
-   The rectangular region which defines how the Sprite will be clipped must not be rotated
-   The original information for the Sprite must be available to the clipping code

This code will show you how to clip a Sprite given a static position. Moving a Sprite within the clip region and having it clip automatically is slightly more complicated; however, that process can be derived from this simpler process.

## Setup

This tutorial will use Glue; however, the majority of what is is discussed here is code, so this tutorial can be followed along in pure code.

For this setup I will use an empty XNA 4 PC project called ClippingTutorial. See [this page](/frb/docs/index.php?title=Glue:Reference:Menu:File:New_Project.md "Glue:Reference:Menu:File:New Project") for information on how to create a new tutorial.

I will also create a Screen called ClippingScreen. See [this page](/frb/docs/index.php?title=Glue:Reference:Screens:Creating_a_new_Screen.md "Glue:Reference:Screens:Creating a new Screen") for information on how to create a Screen.

## Defining the Clip Region

Now that we have a Screen, we can add an [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle"):

1.  Add a new [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle") object to your Screen. See [this page](/frb/docs/index.php?title=Glue:Reference:Objects:AxisAlignedRectangle.md "Glue:Reference:Objects:AxisAlignedRectangle") for information on AxisAlignedRectangles in Glue.
2.  Name the [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle") "ClipRegion"
3.  Set the ClipRegion Width to 200
4.  Set the ClipRegion Height to 200

## Defining the Sprite

Next we'll add a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to our Screen. This [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") will be clipped as it moves around the screen:

1.  Add a new [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to your Screen. See [this page](/frb/docs/index.php?title=Glue:Reference:Objects:Sprite.md "Glue:Reference:Objects:Sprite") for information on Sprites in Glue.
2.  Add a new Texture file to your Screen. For this demo I'll use a bear graphic: ![Bear.png](/media/migrated_media-Bear.png)
3.  Set the newly-added Sprite's Texture to the newly added Texture.

## Setting the Sprite's initial position

By default the Sprite will be positioned in the center of the screen, where it will not be clipped. You will need to modify the starting position of the Sprite to see it get clipped. This can be done in the Screen's CustomInitialize:

    // Change the values to move it in or out of the clip region
    SpriteInstance.X = 100;
    SpriteInstance.Y = 100;

## Clipping - the first pass

First, we'll add some basic logic that controls whether the entire Sprite is visible or not. To do this, add the following code in your Screen's CustomInitialize after modifying your Sprite's position:

    SpriteInstance.Visible = 
       SpriteInstance.Left < ClipRegion.Right &&
       SpriteInstance.Right > ClipRegion.Left &&
       SpriteInstance.Bottom < ClipRegion.Top &&
       SpriteInstance.Top > ClipRegion.Bottom;

At this point the Sprite will disappear when it is fully outside of the ClipRegion AxisAlignedRectangle.

## Modifying the Sprite

Next we'll write the actual meat of clipping. The code needs to do the following:

1.  Identify how much to clip on each side
2.  Make any negative values equal 0 (which indicates there is nothing to clip on a given side)
3.  Adjust the TexturePixel values according to how much to clip
4.  Shift the Sprite

Keep in mind that this code assumes that Sprites use a positive TextureScale value, as opposed to explicit Width and Height values.

    if (SpriteInstance.Visible)
    {
        
        float amountToClipFromRight = SpriteInstance.Right - ClipRegion.Right;
        float amountToClipFromLeft = ClipRegion.Left - SpriteInstance.Left;

        float amountToClipFromTop = SpriteInstance.Top - ClipRegion.Top;
        float amountToClipFromBottom = ClipRegion.Bottom - SpriteInstance.Bottom;


        // If any of the values are negative, that means we don't have
        // to clip off of that particular side.  To make the code that follows
        // simpler, we'll just change antyhing that's less than 0 equal 0
        amountToClipFromRight = Math.Max(amountToClipFromRight, 0);
        amountToClipFromLeft = Math.Max(amountToClipFromLeft, 0);
        amountToClipFromTop = Math.Max(amountToClipFromTop, 0);
        amountToClipFromBottom = Math.Max(amountToClipFromBottom, 0);

        // Now let's take off however many pixels we need:
        // This code assumes a non-zero, positive TextureScale
        SpriteInstance.RightTexturePixel -= amountToClipFromRight / SpriteInstance.TextureScale;
        SpriteInstance.LeftTexturePixel += amountToClipFromLeft / SpriteInstance.TextureScale; // Need to add here

        // Positive moves down on texture coordinates
        SpriteInstance.TopTexturePixel += amountToClipFromTop / SpriteInstance.TextureScale;
        SpriteInstance.BottomTexturePixel -= amountToClipFromBottom / SpriteInstance.TextureScale;

        // Finally, Sprites are positioned by their center, so we need to adjust the position
        // We only need to adjust by half of the amount changed since adjusting the width handles
        // half of the adjustment to make the edges line up
        SpriteInstance.X += (amountToClipFromLeft - amountToClipFromRight) / 2.0f;
        SpriteInstance.Y += (amountToClipFromBottom - amountToClipFromTop  ) / 2.0f;
    }

![ClippedBear.PNG](/media/migrated_media-ClippedBear.PNG)

## Creating a portable function

We can take the above code to make a more portable function. The following code takes the above logic and modifies the variable names so it is a reusable function:

    void ClipSprite(Sprite sprite, float clipLeft, float clipRight, float clipTop, float clipBottom)
    {
        sprite.Visible =
           sprite.Left < clipRight &&
           sprite.Right > clipLeft &&
           sprite.Bottom < clipTop &&
           sprite.Top > clipBottom;



        if (sprite.Visible)
        {
            float amountToClipFromRight = sprite.Right - clipRight;
            float amountToClipFromLeft = clipLeft - sprite.Left;

            float amountToClipFromTop = sprite.Top - clipTop;
            float amountToClipFromBottom = clipBottom - sprite.Bottom;


            // If any of the values are negative, that means we don't have
            // to clip off of that particular side.  To make the code that follows
            // simpler, we'll just change antyhing that's less than 0 equal 0
            amountToClipFromRight = Math.Max(amountToClipFromRight, 0);
            amountToClipFromLeft = Math.Max(amountToClipFromLeft, 0);
            amountToClipFromTop = Math.Max(amountToClipFromTop, 0);
            amountToClipFromBottom = Math.Max(amountToClipFromBottom, 0);

            // Now let's take off however many pixels we need:
            // This code assumes a non-zero, positive TextureScale
            sprite.RightTexturePixel -= amountToClipFromRight / sprite.TextureScale;
            sprite.LeftTexturePixel += amountToClipFromLeft / sprite.TextureScale; // Need to add here

            // Positive moves down on texture coordinates
            sprite.TopTexturePixel += amountToClipFromTop / sprite.TextureScale;
            sprite.BottomTexturePixel -= amountToClipFromBottom / sprite.TextureScale;

            // Finally, Sprites are positioned by their center, so we need to adjust the position
            // We only need to adjust by half of the amount changed since adjusting the width handles
            // half of the adjustment to make the edges line up
            sprite.X += (amountToClipFromLeft - amountToClipFromRight) / 2.0f;
            sprite.Y += (amountToClipFromBottom - amountToClipFromTop) / 2.0f;
        }
    }
