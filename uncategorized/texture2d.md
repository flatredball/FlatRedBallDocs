# texture2d

### Introduction

A Texture2D is a 2D array of pixel information which can be used by [Sprites](../frb/docs/index.php), [Text objects](../frb/docs/index.php), and [PositionedModels](../frb/docs/index.php) when drawn.

All FlatRedBall platforms support textures up to a max size of 2048x2048. FlatRedBall PC uses the Reach profile by default, but if switched to HiDef, textures up to 4096x4096 can be used.

### Displaying a Texture

A Texture2D by itself cannot be displayed in FlatRedBall. The Texutre2D must be drawn by a FlatRedBall object. The most common object for displaying Texture2Ds are [Sprite](../frb/docs/index.php). The following code shows how to render a Texture2D using a Sprite.

```
Texture2D texture2D = FlatRedBallServices.Load<Texture2D>("redball.bmp");
// AddSprite will both instantiate a Sprite and add it so it is rendered by FlatRedBall
Sprite sprite = SpriteManager.AddSprite(texture2D);
```

### Different versions of Texture2D

While all versions of FlatRedBall uses a class called Texture2D, there are actually three versions:

| Class                                        | Detail                                                                                           |
| -------------------------------------------- | ------------------------------------------------------------------------------------------------ |
| Microsoft.Xna.Framework.Graphics.Texture2D   | Provided by the Xna Framework.                                                                   |
| FlatRedBall.Texture2D                        | Provided by FlatRedBall MDX to approximate the syntax of the XNA version.                        |
| SilverArcade.SilverSprite.Graphics.Texture2D | Provided by SilverArcade to approximate the syntax of the XNA version when using FlatSilverBall. |

### Creating a Texture2D

The following code loads a Texture2D from a file:

Add the following using statement:

```
using Microsoft.Xna.Framework.Graphics;
```

Call the following sometime after FlatRedBall is initialized

```
 // If loading from file, use the extension:
 Texture2D loadedTexture = FlatRedBallServices.Load<Texture2D>("someGraphic.png");
 // otherwise, if loading through content pipeline, exclude the extension:
 Texture2D loadedTexture = FlatRedBallServices.Load<Texture2D>("someGraphic");
```

For more information on the Texture2D class, see [the MSDN entry](http://msdn2.microsoft.com/en-us/library/microsoft.xna.framework.graphics.texture2d.aspx).

### Transparency

Each pixel in a Texture2D can be fully opaque, completely transparent, or have partial transparency. There are two ways to set the transparency of pixels in a Texture:

1. Save your image in a format that supports transparency, such as .tga or .png. When you save your image, make sure that you have transparent pixels set as transparent in the program that you are using to create or modify the image.
2. Use a color key for your image. You can specify a color that should be transparent when the engine creates a Texture2D out of it. The default value is black. For more information on a color key, see the [TextureLoadingColorKey page](../frb/docs/index.php).

### Creating a Texture2D from a Bitmap Object

The Bitmap object is an object commonly used in Windows programming. It is an object that represents an image loaded in RAM. It does not necessarily need to come from a .bmp image. Its flexibility can at times make it a useful "middle-man" for loading Texture2Ds.

Assuming myBitmap is a valid Bitmap

```
 string uniqueName = "SomeUniqueName";
 string contentManager = "ContentManagerName";

 Texture2D texture = FlatRedBallServices.BitmapToTexture2D(
    myBitmap,
    uniqueName,
    contentManager);
```

### Power of 2

When a texture is loaded into FlatRedBall, the source image width and height should be a [power of two](../frb/docs/index.php). Non-power of two image can be loaded, but they may be up-scaled which can result in blurry textures and wasted memory.

For a list of power of two values, [see this table](../frb/docs/index.php).

### Extra Sections

* [Filtering](../frb/docs/index.php) - Explains why textures become blurry when displayed larger than actual size.
* [Creating New Textures Programatically](../frb/docs/index.php)
* [FlatRedBall.FlatRedBallServices.AddDisposable](../frb/docs/index.php) - Can be used to add a Texture2D to a [FlatRedBall Content Manager](../frb/docs/index.php).

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
