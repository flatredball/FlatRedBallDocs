# textureaddressmode

### Introduction

The TextureAddressMode controls how Sprites display their texture outside of the 0 - 1 range. TextureAddressMode can be used to create tiles and texture scrolling. TextureAddressMode is usually used in combination with [texture coordinates](../../../../frb/docs/index.php). For more information on texture coordinates, see the [texture coordinates page](../../../../frb/docs/index.php).

### Usage Example

The following code creates three sprites. It assumes that the texture **star** is in scope (such as added to the Screen containing the code);

```
Sprite wrapSprite = SpriteManager.AddSprite(star);
// BottomTextureCoordinate of 4 means the texture will "wrap" 4 times vertically
wrapSprite.RightTextureCoordinate = 4;
wrapSprite.BottomTextureCoordinate = 4;
wrapSprite.X = -200;
wrapSprite.TextureAddressMode = 
    Microsoft.Xna.Framework.Graphics.TextureAddressMode.Wrap;
wrapSprite.TextureScale = 1;

// notice that TextureScale accounts for texture coordinates.
// This sprite will be taller than the sprite to its left:
Sprite tallSprite = SpriteManager.AddSprite(star);
tallSprite.RightTextureCoordinate = 4;
// wrap 10 times vertically...
tallSprite.BottomTextureCoordinate = 10;
tallSprite.TextureAddressMode =
    Microsoft.Xna.Framework.Graphics.TextureAddressMode.Wrap;
tallSprite.TextureScale = 1;

Sprite clampSprite = SpriteManager.AddSprite(star);
clampSprite.RightTextureCoordinate = 4;
clampSprite.BottomTextureCoordinate = 4;
// default
clampSprite.TextureAddressMode = 
    Microsoft.Xna.Framework.Graphics.TextureAddressMode.Clamp;
clampSprite.X = 200;
clampSprite.TextureScale = 1;
```

![TextureAddressModes.PNG](../../../../media/migrated_media-TextureAddressModes.PNG) This article uses the [TextureScale property](../../../../frb/docs/index.php) to automatically size the Sprites according to their texture coordinates.

**Note:** The Wrap texture address mode requires that textures are a power of 2 on the Windows Phone.

### Simulating Scrolling

Changing a Sprite's texture coordinate values while using TextureAddressMode.Wrap is an easy way to simulate a scrolling background with one Sprite. The following code creates a single Sprite which appears to be scrolling. **Add the following using statements:**

```
using Microsoft.Xna.Framework.Graphics;
```

**Add the following in Initialize after initializing FlatRedBall:**

```
mSprite = SpriteManager.AddSprite("redball.bmp");
mSprite.TextureAddressMode = TextureAddressMode.Wrap;
mSprite.ScaleX = SpriteManager.Camera.RelativeXEdgeAt(0);
mSprite.ScaleY = SpriteManager.Camera.RelativeYEdgeAt(0);
```

**Add the following in Update:**

```
float scrollSpeed = 1; // 1 means the background will loop one time per second
mSprite.LeftTextureCoordinate += scrollSpeed * TimeManager.SecondDifference;
mSprite.RightTextureCoordinate += scrollSpeed * TimeManager.SecondDifference;
```

![Scrolling.png](../../../../media/migrated_media-Scrolling.png)
