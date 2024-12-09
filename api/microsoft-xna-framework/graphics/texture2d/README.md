# Texture2D

### Introduction

A Texture2D is a 2D array of pixel information which can be used by FlatRedBall [Sprites](../../../../frb/docs/index.php), as well as other types of visual objects such as Tiled maps and Gum elements. All FlatRedBall platforms support textures up to a max size of 2048x2048, and as of 2024 most hardware supports texture sizes of 4096x4096.

### Displaying a Texture

A Texture2D by itself cannot be displayed in FlatRedBall. The Texutre2D must be drawn by a FlatRedBall object. The most common object for displaying Texture2Ds are [Sprite](../../../../frb/docs/index.php). The following code shows how to render a Texture2D using a Sprite.

```csharp
Texture2D texture2D = FlatRedBallServices.Load<Texture2D>("redball.png");
// AddSprite will both instantiate a Sprite and add it so it is rendered by FlatRedBall
Sprite sprite = SpriteManager.AddSprite(texture2D);
sprite.PixelScale = 1;
```

### Creating a Texture2D

The following code loads a Texture2D from a file:&#x20;

Add the following using statement:

```csharp
using Microsoft.Xna.Framework.Graphics;
```

Call the following sometime after FlatRedBall is initialized

```csharp
 // If loading from file, use the extension:
 Texture2D loadedTexture = FlatRedBallServices.Load<Texture2D>("someGraphic.png");
 // otherwise, if loading through content pipeline, exclude the extension:
 Texture2D loadedTexture = FlatRedBallServices.Load<Texture2D>("someGraphic");
```

For more information on the Texture2D class, see [the MSDN entry](http://msdn2.microsoft.com/en-us/library/microsoft.xna.framework.graphics.texture2d.aspx).

### Transparency

Each pixel in a Texture2D can be fully opaque, completely transparent, or have partial transparency. Typically textures are loaded from .PNG files which can include transparency.



### Power of 2

When a texture is loaded into FlatRedBall, the source image width and height should be a power of two. Non-power of two image can be loaded, but they may be up-scaled which can result in blurry textures and wasted memory. The following lists common powers of 2:

* 8
* 16
* 32
* 64
* 128
* 256
* 512
* 1024
* 2048
* 4096
