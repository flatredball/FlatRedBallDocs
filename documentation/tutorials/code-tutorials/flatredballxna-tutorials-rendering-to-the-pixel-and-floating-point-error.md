## Introduction

If you've read the tutorial on [2D in FlatRedBall](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:2D_In_FlatRedBall.md "FlatRedBallXna:Tutorials:2D In FlatRedBall") then you're aware that FlatRedBall can handle pure 2D graphics. Unfortunately, even if you follow the information in that article it's still possible to experience graphical issues related to rendering 2D images which should be pixel-perfect.

These issues arise due to floating point inaccuracies. This article will discuss why these issues happen and how to resolve them.

## Our scenario - A Sprite with a checkered Texture

Let's say that you've created a Sprite that you want to be drawn to-the-pixel in your 2D game. You're going to have your Sprite use the following image for its Texture:

![BlueGreenCheckers.png](/media/migrated_media-BlueGreenCheckers.png)

Let's zoom in a little so we can see more detail:

![BlueGreenCheckersLarge.png](/media/migrated_media-BlueGreenCheckersLarge.png)

So, this texture is one that's highly sensitive to repeating textures because patterns will immediately become evident.

## The code

You start coding your game and in most cases the Sprite renders with no problems. However, you stumble across a situation where there are problems:

    FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.None;
    SpriteManager.Camera.UsePixelCoordinates(false);

    // Using the content pipeline (FRB XNA), so no extension
    Sprite sprite = SpriteManager.AddSprite("Content/BlueGreenCheckers");
    sprite.PixelSize = .5f;
    sprite.X = .0019399f; // This value causes problems for some reason...

![PixelInaccuracy.png](/media/migrated_media-PixelInaccuracy.png)

## The green strip problem

So as you're coding you notice there's a green strip on your Sprite. You double-check the texture. Nope, no green strip there. You double-check your math. Nope, no problems there. In fact, the only thing that you're doing is setting the pixel size and the Camera to use pixel coordinates. So what is causing this?

## Plotting pixels

Whenever FlatRedBall (or any 3D engine or API) renders, each pixel is processed separately. Each pixel on a rendered Sprite determines its texture coordinates, then asks for the value at that texture coordinate. Unfortunately, when working in 3D all values are floats, and these floats are subject to errors. Let's look a little closer at how these errors can happen.

The following is an illustration of how the rendering works. We're going to ignore a few details to isolate the cause of the rendering error shown above.

The outlines on top represents pixels on screen, while the blue/green pattern represents a row of pixels from the texture. Keep in mind for this example we're assuming **no filtering**.

![RenderingProblem1.png](/media/migrated_media-RenderingProblem1.png)

During rendering, the bottom pattern will be "applied" to the pixels above. The arrows show which pixels on the Texture get applied to which pixels on screen. Again, there are more details to how this works in actual rendering, but the arrows represent the concept of how pixels are applied when rendered.

![RenderingProblem2.png](/media/migrated_media-RenderingProblem2.png)

If the Sprite shifts slightly, then we might have the following situation:

![RenderingProblem3.png](/media/migrated_media-RenderingProblem3.png)

Well, even though this might look weird, it's actually ok. The Sprite has shifted, but it's shifted less than the distance of one pixel, so nothing will change. And of course, once the Sprite shifts enough, then the location where the pixels draw will shift over one pixel as well. But what happens if we shift so that the pixels fall right in-between two screen pixels?

![RenderingProblem4.png](/media/migrated_media-RenderingProblem4.png)

This creates a problem, because essentially the rendering API (that is, XNA or DirectX) has to "pick" a side to render on:

![RenderingProblem5.png](/media/migrated_media-RenderingProblem5.png)

## A small clarification

So far we've been talking about colors moving **from** the texture **to** the screen. Actually, in 3D graphics it works slightly different... actually not just slightly, but completely **the opposite!**. So instead of the texture "pushing" its color onto the screen, the screen "pulls" colors from the texture. So we can actually invert the arrows and see how this works:

![RenderingProblem6.png](/media/migrated_media-RenderingProblem6.png)

## Floating point to the ~~rescue~~ failure

Of course, when we look at the image above we can tell what we want to happen: We'd like our graphical API to make up its mind about whether it's going to "go left" or "go right", and stick with it. Unfortunately, there's no such thing as "go left" or "go right" for the rendering API. Instead, it just takes a number and does its best to find where it should pull from according to that.

And to make matters worse, whether to "go left" or "go right" is actually a question of precision! That is, if we had infinite precision, then all arrows would always go the same direction no matter what. Unfortunately, we don't have this kind of precision, which means that in some cases it's possible to get the API to "go left" on some pixels and to "go right" on others:

![RenderingProblem7.png](/media/migrated_media-RenderingProblem7.png)

## The pixels don't match!

Now you can see that even though we tried our best to get the pixels to line up properly, they didn't. We have two blues in a row, which is **not** now the texture is. Notice that in this case, a pixel was lost - the green pixel in the center never gets rendered. It's also possible to insert extra pixels if two screen pixels pull from the same texture pixel. In other words, it's important to note that problems like this can happen both ways.

In our diagram the blue gets drawn twice in a row. In the original image above (the one with the diagonal green stripe), the way that the pixels are lining up is resulting in two green pixels being drawn next to each other.

## The solution

At the time of this writing there is unfortunately not a system-wide solution to these problems. Depending on your situation you may consider one of the following examples. **BE CAREFUL**: These are not very clean solution and should be heavily documented!

-   Slightly "inflate" or "deflate" your object. In other words, slightly increase or decrease the scale of your object so that you don't get these kind of issues. Adjusting the scale of an object may compensate for the inaccuracy introduced by floating point.
-   Adjust the position of your Camera. If you control the position of your Camera, then you may be able to shift the position by a certain value to keep pixels from lining up.
-   Implement alignment fixes at the entity-level. If you are using entities then you can create an additional PositionedObject in the attachment hierarchy which will shift to adjust for these problems as well.
