## Introduction

The DrawsWorld property controls whether the camera draws objects which are not on any [Layer](/frb/docs/index.php?title=Layer.md "Layer") and objects which are on [Layers](/frb/docs/index.php?title=Layer.md "Layer") that are not Camera-specific. Usually Cameras which are used to draw things in split-screen mode should have this property be true, while Cameras which are used to overlay things such as HUDs should usually set this to false.

## Code Example

The following example creates a situation where two Cameras are used. In this situation, the second Camera is used to draw HUD. The second Camera will not draw the underlying Sprite: Add the following using statement:

    using FlatRedBall.Graphics;

Add the following to Initialize after initializing FlatRedBall:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ScaleX = sprite.ScaleY = 10;

    // We'll use a global content manager if we expect the Camera to be around forever
    Camera hudCamera = new Camera(FlatRedBallServices.GlobalContentManager);
    SpriteManager.Cameras.Add(hudCamera);
    hudCamera.SetSplitScreenViewport(Camera.SplitScreenViewport.FullScreen);
    // Do this so the Camera doesn't draw the Sprite again!
    hudCamera.DrawsWorld = false;

    // Now, add a Text object to the HUD camera.
    Text text = TextManager.AddText("Score: 1000");
    text.X = -19f;
    text.Y = 15;
    //text.Scale = text.Spacing = 2;
    //text.SetPixelPerfectScale(hudCamera);
    TextManager.AddToLayer(text, hudCamera.Layer);

![DrawsWorld.png](/media/migrated_media-DrawsWorld.png)
