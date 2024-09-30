# UsePixelCoordinates

### Introduction

The UsePixelCoordinates method is an easy way to set up a traditional 2D camera. Using this method, world units can match up with pixel coordinates. Using the pixel as the unit is effective in pure 2D games where graphics are created to be drawn to-the-pixel. A camera which uses pixel coordinates is referred to as "pixel perfect". For more information on 2D games, see the [2D in FlatRedBall](../../../frb/docs/index.php) article. UsePixelCoordinates is a shortcut method which does the following:

* It sets [Orthogonal](../../../frb/docs/index.php) to true.
* It sets [OrthogonalHeight](../../../frb/docs/index.php) and [OrthogonalWidth](../../../frb/docs/index.php) to match the screen's resolution.

### Code Example

The following code makes the camera a pure 2D camera. A Sprite using its Texture's dimensions for its scale is added to show the resolution. Add the following to Initialize after initializing FlatRedBall:

```
// In 2D you may want to turn off filtering so things don't look "blurry"
FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;

SpriteManager.Camera.UsePixelCoordinates();

Sprite sprite = SpriteManager.AddSprite("redball.bmp");
sprite.PixelSize = .5f;
```

![UsePixelCoordinates1.png](../../../.gitbook/assets/migrated\_media-UsePixelCoordinates1.png)

### Canvas Resolution vs. Screen Coordinates

When programming on Windows, you have [control of the "back buffer resolution"](../../../frb/docs/index.php#Setting\_Resolution). However, on the Xbox 360 the resolution is chosen by the user, either. Usually this is done through the switch on the video cable: ![Cableswitch5ia.jpg](../../../.gitbook/assets/migrated\_media-Cableswitch5ia.jpg) Depending on the setting the user may be running the game in one of the following resolutions:

* Standard Resolution (640 X 480)
* High Definition 720 (1280 X 720)
* High Definition 1080 (1920 X 1080)

If you are developing a 2D game, then you may be faced with the issue of resolution on the 360. If you set your Camera to use pixel coordinates, then the size of your objects on-screen will change depending on the resolution of the game. In other words, a Sprite which takes up the entire screen in standard resolution would take up a little more than half of the screen (vertically) if the user runs the game in high definition 720. Fortunately, the UsePixelCoordinates method provides an overload for changing the coordinate dimension of the screen. This means that you can code your game the same (or very close) for all resolutions if using the overload.

### Overload Code Example

The following modifies the coordinates of the camera so that the entire redball.bmp [Sprite](../../../frb/docs/index.php) takes up the screen. Add the following to Initialize after initializing FlatRedBall:

```
 // Store off the aspect ratio.  The width will use this so that we don't
 // get distortion.
 float aspectRatio = SpriteManager.Camera.AspectRatio;

 // In 2D you may want to turn off filtering so things don't look "blurry"
 FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.None;
 Sprite sprite = SpriteManager.AddSprite("redball.bmp");
 sprite.PixelSize = .5f;

 bool moveBottomLeftToOrigin = false;
 SpriteManager.Camera.UsePixelCoordinates(moveBottomLeftToOrigin, 
     (int)System.Math.Round(sprite.Texture.Width * aspectRatio), sprite.Texture.Height);
```

![UsePixelCoordinates2.png](../../../.gitbook/assets/migrated\_media-UsePixelCoordinates2.png)
