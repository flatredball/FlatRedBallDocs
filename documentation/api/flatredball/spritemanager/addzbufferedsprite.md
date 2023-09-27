## Introduction

A Z-buffered [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") uses the [Z buffer](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") (also known as a [depth buffer](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer")) to perform proper overlapping. Since the [Z buffer](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") does not consider partial transparency, creating [Z buffered](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") with transparency can create graphical artifacts. Z-Buffered Sprites are not currently available in FlatSilverBall.

## Code Example

The following code creates two [Z buffered](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite").

     Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

     Sprite sprite1 = SpriteManager.AddZBufferedSprite(texture);
     sprite1.X = -2;
     sprite1.Y = 6;
     sprite1.ScaleX = 13;
     sprite1.ScaleY = 4;
     sprite1.RotationY = (float)Math.PI / 3.0f;

     Sprite sprite2 = SpriteManager.AddZBufferedSprite(texture);
     sprite2.X = 2;
     sprite2.Y = 6;
     sprite2.ScaleX = 13;
     sprite2.ScaleY = 4;
     sprite2.RotationY = -(float)Math.PI / 3.0f;

![ModifiedZBuffered.png](/media/migrated_media-ModifiedZBuffered.png)

### Example without Z Buffer

The following code creates two Sprites with the same properties as above, but the [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") are created as regular (ordered) [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") instead of [Z buffered](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"). Notice that one [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") completely overlaps the other.

     Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

     Sprite sprite1 = SpriteManager.AddSprite(texture);
     sprite1.X = -2;
     sprite1.Y = 6;
     sprite1.ScaleX = 13;
     sprite1.ScaleY = 4;
     sprite1.RotationY = (float)Math.PI / 3.0f;

     Sprite sprite2 = SpriteManager.AddSprite(texture);
     sprite2.X = 2;
     sprite2.Y = 6;
     sprite2.ScaleX = 13;
     sprite2.ScaleY = 4;
     sprite2.RotationY = -(float)Math.PI / 3.0f;

![OrderedLayeredSprites.png](/media/migrated_media-OrderedLayeredSprites.png)

## Overlapping Problems

File used:![WhiteGradient.png](/media/migrated_media-WhiteGradient.png)[WhiteGradient.png](/frb/docs/images/1/1b/WhiteGradient.png.md "WhiteGradient.png") Since [Z buffered](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer") Sprites write to the [depth buffer](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer.md "General Programming:Graphics:Depth Buffer"), partial transparency can block things behind it. For example, consider the following code: ![UnorderedProblems.png](/media/migrated_media-UnorderedProblems.png)

### Z Buffered Sprites and Transparency

Z Buffered Sprites with transparency may not draw correctly. The reason for this is because the depth buffer does not necessarily know how to treat transparent pixels. FlatRedBall XNA attempts to resolve this issue by setting an alpha threshold for what gets drawn to the depth buffer (see below). If you are experiencing issues with transparency, consider the following:

-   If some of your [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") have transparency while others are solid, try to make only the solid [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") Z Buffered. Sprites that do not use the Z Buffer will still sort properly with the Z Buffer. Therefore, you may be able to mix Z Buffered with non-Z Buffered Sprites and still achieve the desired overlapping result.
-   Eliminate transparency - this may not be preferred, but if you can eliminate transparency from your source image, you may be able to avoid this artifact.
-   Reposition objects or your camera to avoid the undesired graphical issues.

### Alpha Threshold

The Alpha Threshold (also known as ReferenceAlpha in XNA terms) is a value that defines the minimum alpha that will be rendered. FlatRedBall uses this value to prevent fully-transparent pixels from rendering to the depth buffer. The end result is that if you have an image which has either fully-opaque or fully transparent pixels, then you can use this image as a Z-Buffered Sprite without any problems. More specifically, the RenderState's ReferenceAlpha property is set to 1 (in a range of 0-255). This means that anything with an alpha value of 1 or greater will be rendered while pixels with an alpha of 0 will not be rendered, and more importantly will not modify the depth buffer.

## More Information

-   [Object Sorting Tutorial](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Object_Sorting.md "FlatRedBallXna:Tutorials:Object Sorting")
