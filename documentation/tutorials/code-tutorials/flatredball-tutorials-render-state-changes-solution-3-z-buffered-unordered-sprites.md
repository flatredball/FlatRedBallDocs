## Introduction

So far we've explored two different options for reducing render breaks. The first was to control the the order in which Sprites are rendered. This approach is in most cases impractical because it impacts the order that Sprites appear on screen. The second approach was to use sprite sheets (combined images) to reduce the number of textures being used (in our case to just one). This approach is very effective but it has some drawbacks including increasing the complexity of maintenance, and difficulty of setting up existing projects.

This tutorial will cover using z buffered (also known as unordered). This approach is useful because it:

-   Preserves z-based ordering
-   Doesn't require any modifications to existing images or texture coordinates

Of course, as we will discuss this approach also introduces its own limitations.

## What is a z buffered Sprite?

The "z buffer", which is also often referred to as the "depth buffer", is a collection of values used by XNA (and for that matter also DirectX and OpenGL) to determine whether one object should be in front of another object when drawing graphics. The depth buffer is used in every 3D commercial game built on these systems (or at least almost all of them). However, since FlatRedBall focuses on 2D, it's not as commonly used.

The z buffer is modified internally whenever an object is drawn if it is turned on prior to rendering. The z buffer allows objects to be rendered in any order, rather than requiring back-to-front rendering as FlatRedBall typically renders.

Since the z buffer frees us from being forced to render back-to-front, we can render our Sprites in any order. This means that we can adjust the order of the rendering to be based off of texture, which will reduce the number of render breaks.

## Using the z buffer

To use the z buffer we simply need to create the Sprites as z buffered Sprites. To do this:

1.  Open TextureTestScreen
2.  Change the code in CustomInitialize to read as follows:

&nbsp;

    for (int i = 0; i < 1000; i++)
    {
        Sprite sprite;
        if (FlatRedBallServices.Random.NextDouble() > .5)
        {
            sprite = SpriteManager.AddZBufferedSprite(redball);
        }
        else
        {
            sprite = SpriteManager.AddZBufferedSprite(greenball);
        }
        SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
        SpriteManager.ZBufferedSortType = FlatRedBall.Graphics.SortType.None;
    }

As expected, since we're not yet doing anything to manage the order in which Sprites render we will see a reduction in performance and an increase in render breaks:![ZBufferedRandomOrder.png](/media/migrated_media-ZBufferedRandomOrder.png)

Now we can simply add the following line of code after the for-loop to re-enable the engine sorting the Sprites by their texture:

    SpriteManager.SortTexturesSecondary();

Since z buffered Sprites do not have any primary form of sorting (regular Sprites primarily sort by their Z value) then the Sprites become sorted only by their Textures. The result is, as we might expect, a boost in performance:![ZBufferedOrderedByTexture.png](/media/migrated_media-ZBufferedOrderedByTexture.png)

## Z Buffered downsides

As you might expect, there are downsides to using z buffered Sprites. The biggest problem is that the the graphics card keeps track of what is in front of something else according to the distance away from the camera for each pixel rendered. This means that if you were to render a Sprite really close to the Camera, then after that render another one further away, the further-away Sprite would not get rendered. Fortunately the z buffer understands fully-transparent pixels and knows not to consider those blocking pixels; however it is not able to effectively deal with half-transparent pixels.

The issue of half transparent pixels is the main reason why the depth buffer is not always used by FlatRedBall. Since FlatRedBall can't predict whether a Sprite will use half-transparency, most FRB calls and tools default to non-z-buffered Sprites.

Our example uses the redball and greenball textures, which do not include any half-transparency. Every pixel is fully opaque, or fully transparent. Furthermore, we don't use any additive blend modes, nor do we modify the Alpha values of the Sprites. Because of this, switching to using a z buffer does not have any adverse graphical impact on our project.

## Conclusion

These tutorials have presented a number of common options for reducing render breaks. Ultimately which will work depends on your project. As always, measure before and after any changes to verify that the result is what you expect it to be.
