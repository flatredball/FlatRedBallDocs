# TextureLoadingColorKey

### Introduction

The GraphicsOptions' TextureLoadingColorKey allows you to set the color to ignore when loading .bmp graphics. **The TextureLoadingColorKey value is only applied to .bmp images and not to other images.** The reason for this is because other image formats either:

* Have lossy compression so exact colors are not preserved and color keys are not an effective way to create transparency.
* Include an alpha channel which include the ability to have partial transparency.

### Code Example

The following code creates a [Sprite](../../../../frb/docs/index.php) from a graphic which has a magenta background. The bool ifUsingColorKey controls whether the color key is set to Magenta or not - the default color is Black. Files used:![RedballWithMagenta.bmp](../../../../media/migrated\_media-RedballWithMagenta.png) Add the following to Initialize after initializing FlatRedBall:

```
bool ifUsingColorKey = true;

if (ifUsingColorKey)
{
    // Set the color key to Magenta:
    FlatRedBallServices.GraphicsOptions.TextureLoadingColorKey =
        Microsoft.Xna.Framework.Graphics.Color.Magenta;
}

// Create a Sprite
SpriteManager.AddSprite("redballWithMagenta.bmp");
```

Setting the ifUsingColorKey to false will result in a magenta box being drawn around the redball graphic. ![ColorKey.png](../../../../.gitbook/assets/migrated\_media-ColorKey.png)

### ColorKey and Texture caching

You may be wondering why the above tutorial requires a recompile and a change of the bool instead of simply creating two [Sprites](../../../../frb/docs/index.php) with a change in the TextureLoadingColorKey between the creation of the two [Sprites](../../../../frb/docs/index.php). The reason for this is because [FlatRedBallServices](../../../../frb/docs/index.php) [caches](../../../../frb/docs/index.php). Therefore an actual load is only performed the **first** time that the redball.bmp graphic is referenced. Every subsequent time, the texture reference to the cached texture data is returned. The exception to this is if different [content managers](../../../../frb/docs/index.php#Content\_Manager\_Code\_Sample) are used.
