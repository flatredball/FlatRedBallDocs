# texturefilter

### Introduction

Filtering is the process of modifying how a texture is drawn to reduce the effect of pixellation when viewing a texture at a large size on screen. For a more in-depth (conceptual) discussion about filtering, see [the Filtering page](../../../../../frb/docs/index.php). The default value is Linear. The GraphicsOptions.TextureFilter property can be used to control the default project-wide texture filter. Individual [Sprites](../../../../../frb/docs/index.php) can overwrite this value. For more information, see [the Sprite TextureFilter page](../../../../../frb/docs/index.php).

### Code Example

Filtering can be controlled through the GraphicsOptions class. The following code creates a large [Sprite](../../../../../frb/docs/index.php) which takes up the entire screen. Pressing the space key toggles the filtering between Linear (on) and Point (off). **Add the following using statement:**

```
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Input;
```

**Add the following in Initialize after initializing FlatRedBall:**

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
sprite.ScaleX = SpriteManager.Camera.RelativeXEdgeAt(0);
sprite.ScaleY = SpriteManager.Camera.RelativeYEdgeAt(0);
```

**Add the following to Update:**

```
if (InputManager.Keyboard.KeyPushed(Keys.Space))
{
    // If filtering is off
    if (FlatRedBallServices.GraphicsOptions.TextureFilter == TextureFilter.Point)
    {
        // Turn the filtering on so it smooths things
        FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Linear;
    }
    else // If it's on
    {
        // Turn the filtering off so things look pixellated.
        FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;
    }
}
```

TextureFilter.Linear: ![LinearFiltering.png](../../../../../media/migrated_media-LinearFiltering.png) TextureFilter.Point: ![PointFiltering.png](../../../../../media/migrated_media-PointFiltering.png)

### TextureFilter.Point and Tile Maps

If you are using tile maps (such as loading a .tmx file) then you will most likely need to set the texture filter to point. Otherwise you may see lines between your tiles:

```
 FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;
```

### Additional Information

The TextureFilter enumeration is an XNA enumeration. More information on the enumeration can be found [here](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.graphics.texturefilter.aspx). More information on Filtering can be found in the [filtering wiki entry](../../../../../frb/docs/index.php).
