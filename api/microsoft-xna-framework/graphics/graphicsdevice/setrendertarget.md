# SetRenderTarget

### Introduction

The SetRenderTarget function can be used to specify  whether rendering will happen on a RenderTarget (if a non-null value is passed) or directly to the screen (if null is passed). By default no render target is set, which means all rendering appears on-screen. Rendering directly to the screen is also referred to as rendering to the _back buffer_. Setting render targets can be used for a number of reasons:

* To create a screen shot of the game to be used elsewhere at runtime
* To save a screen shot to disk
* To perform post processing or screen distortion

Note that SetRenderTarget must be called prior to performing any rendering. Typically this means setting the render target and either:

1. Using FlatRedBallServices.Draw to render everything currently in FlatRedBall to the RenderTarget
2. Explicitly calling Renderer.DrawCamera to render a camera to the render target.

Alternatively, RenderTarget rendering in FlatRedBall can be performed using Layers with RenderTargets. For more information, see the [Layer.RenderTarget](../../../flatredball/graphics/layer/rendertarget.md) page.

### Rendering to RenderTarget, using as Texture2D

Rendering to a RenderTarget enables you to use the resulting RenderTarget as a Texture2D, which can then be re-rendered to the screen. This can be done for a number of reasons:

* To perform post-processing (modifications on the scene after it has been rendered such as bloom or blur)
* To render to a portion of the screen then scale it up to make your game run more efficiently

Add the following at Game1's Class scope:

```csharp
RenderTarget2D _renderTarget;
SpriteBatch _spriteBatch;
```

Add the following to Game1's Initialize. Be sure to add this after `GeneratedInitialize();` so that your DestinationRectangle assignment overrides the assignment in generated code:

```csharp
// We'll only render a 50x50 pixel area:

const int backBufferWidth = 50;
const int backBufferHeight = 50;

// Set the Camera to render within the defined area.

Camera.Main.DestinationRectangle = new Rectangle(0, 0, backBufferWidth, backBufferHeight);

// Create a Sprite so we can see something on screen
// You can comment out the Sprite creation and assignment
// if you already have graphics on screen
var sprite = SpriteManager.AddSprite("redball.bmp");
sprite.TextureScale = 4;

// Make the render target and SpriteBatch which we'll use later
var device = graphics.GraphicsDevice;
_renderTarget = 
    new RenderTarget2D(device, backBufferWidth, backBufferHeight, false, 
    device.DisplayMode.Format, DepthFormat.Depth24);
_spriteBatch = new SpriteBatch(device);
```

Modify Game1's Draw method:

```csharp
// Set the render target before rendering FRB:
graphics.GraphicsDevice.SetRenderTarget(_renderTarget);

// FRB's rendering should be done after the render target has been set
GeneratedDrawEarly(gameTime);
FlatRedBallServices.Draw();
GeneratedDraw(gameTime);

// Finally unset the render target so we can render back to screen:
graphics.GraphicsDevice.SetRenderTarget(null);

// Now use the _renderTarget as a Texture2D:
_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, 
    SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
_spriteBatch.Draw(_renderTarget, new Rectangle(0,0,700, 500), Color.White);
_spriteBatch.End();

base.Draw(gameTime);
```

![RenderTargetRendering.PNG](../../../../.gitbook/assets/migrated\_media-RenderTargetRendering.PNG)

{% hint style="info" %}
This example shows how to modify the Game1 class so that it renders FlatRedBall to a render target. This is a common technique for _pixel perfect_ 2D games, but this setup requires additional work. As of October 2024, a pixel perfect 2D game requires custom code including:

* Modifying the Camera DestinationRectangle, OrthogonalHeight and OrthogonalWidth
* Modifying Gum GraphicalUiElement CanvasWidth and CanvasHeight
* Modifying the SystemManagers Zoom (Gum)
* Modifying the Cursor's TransformationMatrix
* Adjusting the CameraControllingEntity's CustomSnapToPixelZoom value

Future versions of FlatRedBall may automate this process.
{% endhint %}

### Rendering to a RenderTarget, Saving to PNG

This example shows how to render to a render target, then how to save it to disk when pressing the space bar:

Add the at class scope:

```
RenderTarget2D _renderTarget;
```

Add the following to CustomInitialize:

```csharp
_renderTarget = new RenderTarget2D(FlatRedBallServices.GraphicsDevice, 800, 600);
Camera.Main.ClearsDepthBuffer = false;
```

Add the following to Draw:

```csharp
// We'll pull out the default Draw call and replace
// it with some more calls that give us more control
// over how drawing is called:
// FlatRedBallServices.Draw();
FlatRedBallServices.UpdateDependencies();

FlatRedBallServices.GraphicsDevice.SetRenderTarget(_renderTarget);
Renderer.DrawCamera(Camera.Main, null);
FlatRedBallServices.GraphicsDevice.SetRenderTarget(null);

if (InputManager.Keyboard.KeyPushed(Keys.Space))
{
    using (Stream stream = System.IO.File.Create("savedFile.png"))
    {
        _renderTarget.SaveAsPng(stream, mRenderTarget.Width, mRenderTarget.Height);
    }
}
```
