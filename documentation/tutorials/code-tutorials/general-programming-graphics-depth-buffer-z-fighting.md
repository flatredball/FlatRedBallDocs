## Introduction

z fighting is a term which describes an artifact which occurs when two surfaces are parallel (or near parallel) and are close enough to one another that the depth buffer resolution cannot accurately resolve overlapping. This is often seen as a striped or zig-zag pattern. Often this effect can flicker if the camera or objects are moving.

## Example

The following image shows two Sprites which are very close to each other - one blue and one white - rotated on the X axis so that they lie flat. The z fighting causes the white and blue bands.

![ZFighting.png](/media/migrated_media-ZFighting.png)

### Source

    Texture2D texture = null;
    Sprite sprite1 = SpriteManager.AddZBufferedSprite(texture);
    sprite1.ColorOperation = ColorOperation.Color;
    sprite1.Red = 1;
    sprite1.Green = 1;
    sprite1.Blue = 1;
    sprite1.ScaleX = 30;
    sprite1.ScaleY = 200;
    sprite1.Y = -4;
    sprite1.RotationX = (float)Math.PI / 2.0f;

    Sprite sprite2 = SpriteManager.AddZBufferedSprite(texture);
    sprite2.ColorOperation = ColorOperation.Color;
    sprite2.Red = 0;
    sprite2.Green = 0;
    sprite2.Blue = 1;
    sprite2.ScaleX = 30;
    sprite2.ScaleY = 200;
    sprite2.Y = -3.999999f;
    sprite2.RotationX = (float)Math.PI / 2.0f;

## How to resolve Z Fighting

Since z fighting occurs because there isn't enough resolution in the depth buffer to handle the proximity of the surfaces accurately, there are two solutions:

1\. Increase the distance between the surfaces 2. Increase the resolution

### Increase the distance between the surfaces

The first option is fairly simple. For example, if the Y value of Sprite2 were changed to -3.999400f, then there is no more z fighting (at least for this particular camera setup).

![NoZFighting.png](/media/migrated_media-NoZFighting.png)

Notice that this is a fairly small change of .000599f;, which is less than 0.02% (that's two-hundredths of a percent).

### Increase the resolution

Increasing the resolution of the depth buffer can be done in one of two ways. One is to increase the bit depth of the z buffer. Just as a number stored as a double has more precision than a float, a 64-bit depth buffer has more resolution than a 32-bit depth buffer. Unfortunately at the time of this 64 bit depth buffers are not very common and FlatRedBall does not support this format.

The other way to increase the resolution is to reduce the near and far clip planes of the FlatRedBall Camera. In the above example, the default near and far clip planes for the Camera were used. If the far clip plane is pulled in from the default value of 1000 to 240 (to contain the Sprite extending 200 units into the distance centered 40 units away from the camera), then the necessary separation value becomes -3.999600f instead of -3.999400f. In this case it may not seem like a huge difference, but intelligently setting the far clip plane can help you avoid having to fine-tune your positions.
