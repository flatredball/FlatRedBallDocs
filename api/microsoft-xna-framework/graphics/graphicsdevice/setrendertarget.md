## Introduction

The SetRenderTarget function can be used to specify where any rendering code will render to. By default no render target is set, which means all rendering will appear on-screen. Setting render targets can be used for a number of reasons:

-   To use a screen shot of the game at a later time
-   To save a screen shot to disk
-   To perform post processing or screen distortion

## Rendering to RenderTarget, using as Texture2D

Rendering to a RenderTarget enables you to use the resulting RenderTarget as a Texture2D, which can then be re-rendered to the screen. This can be done for a number of reasons:

-   To perform post-processing (modifications on the scene after it has been rendered such as bloom or blur)
-   To render to a portion of the screen then scale it up to make your game run more efficiently

Add the at Game1's Class scope:

    RenderTarget2D mRenderTarget;
    SpriteBatch mSpriteBatch;

Add the following to Game1's Initialize:

    // We'll only render a 50x50 pixel area:

    const int backBufferWidth = 50;
    const int backBufferHeight = 50;

    // Set the Camera to render within the defined area.
    Camera.Main.DestinationRectangle = new Rectangle(0, 0, backBufferWidth, backBufferHeight);

    // Create a Sprite so we can see something on screen
    var sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.TextureScale = 4;

    // Make the render target and SpriteBatch which we'll use later
    var device = graphics.GraphicsDevice;
    mRenderTarget = 
        new RenderTarget2D(device, backBufferWidth, backBufferHeight, false, 
        device.DisplayMode.Format, DepthFormat.Depth24);
    mSpriteBatch = new SpriteBatch(device);

Add the following to Game1's Draw:

    // Set the render target before rendering FRB:
    graphics.GraphicsDevice.SetRenderTarget(mRenderTarget);

    // FRB's rendering should be done after the render target has been set
    FlatRedBallServices.Draw();

    // Finally unset the render target so we can render back to screen:
    graphics.GraphicsDevice.SetRenderTarget(null);

    // Now simply use the mRenderTarget as a Texture2D:
    mSpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, 
        SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
    mSpriteBatch.Draw(mRenderTarget, new Rectangle(0,0,700, 500), Color.White);
    mSpriteBatch.End();

![RenderTargetRendering.PNG](/media/migrated_media-RenderTargetRendering.PNG)

## Rendering to a RenderTarget, saving to PNG

This example shows how to render to a render target, then how to save it to disk when pressing the space bar:

Add the at class scope:

    RenderTarget2D mRenderTarget;

Add the following to CustomInitialize:

    mRenderTarget = new RenderTarget2D(FlatRedBallServices.GraphicsDevice, 800, 600);
    Camera.Main.ClearsDepthBuffer = false;

Add the following to Draw:

    // We'll pull out the default Draw call and replace
    // it with some more calls that give us more control
    // over how drawing is called:
    // FlatRedBallServices.Draw();
    FlatRedBallServices.UpdateDependencies();

    FlatRedBallServices.GraphicsDevice.SetRenderTarget(mRenderTarget);
    Renderer.DrawCamera(Camera.Main, null);
    FlatRedBallServices.GraphicsDevice.SetRenderTarget(null);

    if (InputManager.Keyboard.KeyPushed(Keys.Space))
    {
        using (Stream stream = System.IO.File.Create("savedFile.png"))
        {
            mRenderTarget.SaveAsPng(stream, mRenderTarget.Width, mRenderTarget.Height);
        }
    }
