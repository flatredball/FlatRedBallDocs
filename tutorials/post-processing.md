# Post Processing

### Introduction

Post Processing is a technique used to re-draw a portion or the entire screen, applying either a custom shader or resizing the portion to create a pixelated effect.

Post processing requires the use of RenderTargets - memory which can be the target of rendering which do not automatically draw to the screen.

### RenderTargets

A RenderTarget is a piece of video memory, similar to a Texture2D, which can be used as a temporary storage of rendered graphics before being processed and drawn to the screen. To understand how this works, first we'll consider a game which does not use render targets. This type of game may have visual objects which are added through the FlatRedBall Editor or code. These objects are added to the FlatRedBall Engine, which in turn draws the objects directly to a screen. The following diagram can help visualize this process:

<figure><img src="../.gitbook/assets/image (116).png" alt=""><figcaption><p>Diagram of rendering without a render target</p></figcaption></figure>

Render targets act as "temporary" storage of graphics which can be used to further perform processing on the entire image at once. For example, a render target could be used to apply "bloom" - an effect which applies a glow to the brighter parts of an image.

The following diagram shows how such a render target might be used to apply bloom:

<figure><img src="../.gitbook/assets/image (117).png" alt=""><figcaption><p>Post processing using a render target to apply "bloom"</p></figcaption></figure>

RenderTargets can be drawn to (usually by the FRB engine) and used when drawing to the screen in the same frame. Typically post processing does not add much overhead to a game, so games can use post processing without worrying about reducing frame rate or introducing additional frame lag.

### Drawing to a RenderTarget

Drawing to a RenderTarget can be done using one of the following methods:

1. The entire FlatRedBall draw call can be "wrapped" in a RenderTarget. In other words, every object added to FlatRedBall can be drawn to the screen.
2. Individual Layers in FlatRedBall can draw to a RenderTarget. This is useful if you only want to render a portion of your game to a render target - for example you may want to apply a blur effect to objects in-game, but not to the UI.
3. Similar to layers, entire Cameras can be used to draw to a render target. This technique is considered more advanced than the other two, but can be very effective if you want to control when a render target is updated. For example, you may want to only update a render target when something on-screen changes.

For simplicity this tutorial uses the first approach of rendering the entirety of FlatRedBall to a single layer.

### Rendering to a RenderTarget

We'll begin with a sample platformer project. Note that the contents of this project do not matter, so long as we have something on screen to use for testing.

<figure><img src="../.gitbook/assets/image (118).png" alt=""><figcaption><p>Default platformer project before post processing</p></figcaption></figure>

As mentioned above, we will render the entirety of FlatRedBall to a RenderTarget, which then will be drawn to the screen. Since all of FlatRedBall will have been drawn to the RenderTarget, we must draw the RenderTarget to the screen using objects which are not part of FlatRedBall. We can use a SpriteBatch.

We can add post processing by adding the following code to our Game.

First, add the following using statement:

```csharp
using FlatRedBall.Math;
```

Next, add the following to the Game1 class at class scope:

```csharp
// This is the render target that will hold all of the objects rendered
// in FlatRedBall.
RenderTarget2D renderTarget;

// This is how we'll draw it to the screen:
SpriteBatch spriteBatch;
```

Instantiate the RenderTarget2D and SpriteBatch in Game1's Initialize method after initializing FlatRedBall and after calling GeneratedInitialize:

```csharp
renderTarget = new RenderTarget2D(this.graphics.GraphicsDevice, 
    MathFunctions.RoundToInt(CameraSetup.Data.ResolutionWidth * CameraSetup.Data.Scale/100),
    MathFunctions.RoundToInt(CameraSetup.Data.ResolutionHeight * CameraSetup.Data.Scale / 100));
spriteBatch = new SpriteBatch(this.graphics.GraphicsDevice);
```

Finally we can modify the Draw call as shown in the following code to perform drawing on our RenderTarget:

```csharp
protected override void Draw(GameTime gameTime)
{
    // Set the RenderTarget before drawing anything
    GraphicsDevice.SetRenderTarget(renderTarget);

    // Perform the standard FRB drawing:
    GeneratedDrawEarly(gameTime);
    FlatRedBallServices.Draw();
    GeneratedDraw(gameTime);

    // Set the GraphicsDevice.RenderTarget back to null...
    GraphicsDevice.SetRenderTarget(null);

    // ...and draw the RenderTarget to the screen
    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
    var destinationRectangle = new Rectangle(0, 0,
        renderTarget.Width,
        renderTarget.Height);

    spriteBatch.Draw(renderTarget, destinationRectangle, Color.White);
    spriteBatch.End();

    base.Draw(gameTime);
}
```

The entire Game1.cs class might look like this:

```csharp
using FlatRedBall;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall.Math;

namespace PostProcessingTutorial;

public partial class Game1 : Microsoft.Xna.Framework.Game
{
    GraphicsDeviceManager graphics;

    // This is the render target that will hold all of the objects rendered
    // in FlatRedBall.
    RenderTarget2D renderTarget;

    // This is how we'll draw it to the screen:
    SpriteBatch spriteBatch;
    
    partial void GeneratedInitializeEarly();
    partial void GeneratedInitialize();
    partial void GeneratedUpdate(Microsoft.Xna.Framework.GameTime gameTime);
    partial void GeneratedDrawEarly(Microsoft.Xna.Framework.GameTime gameTime);
    partial void GeneratedDraw(Microsoft.Xna.Framework.GameTime gameTime);

    public Game1() : base()
    {
        graphics = new GraphicsDeviceManager(this);

#if  ANDROID || IOS
        graphics.IsFullScreen = true;
#elif WINDOWS || DESKTOP_GL
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;
#endif
    }

    protected override void Initialize()
    {
        #if IOS
        var bounds = UIKit.UIScreen.MainScreen.Bounds;
        var nativeScale = UIKit.UIScreen.MainScreen.Scale;
        var screenWidth = (int)(bounds.Width * nativeScale);
        var screenHeight = (int)(bounds.Height * nativeScale);
        graphics.PreferredBackBufferWidth = screenWidth;
        graphics.PreferredBackBufferHeight = screenHeight;
        #endif
    
        GeneratedInitializeEarly();

        FlatRedBallServices.InitializeFlatRedBall(this, graphics);

        GeneratedInitialize();

        renderTarget = new RenderTarget2D(this.graphics.GraphicsDevice, 
            MathFunctions.RoundToInt(CameraSetup.Data.ResolutionWidth * CameraSetup.Data.Scale/100),
            MathFunctions.RoundToInt(CameraSetup.Data.ResolutionHeight * CameraSetup.Data.Scale / 100));
        spriteBatch = new SpriteBatch(this.graphics.GraphicsDevice);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        FlatRedBallServices.Update(gameTime);

        FlatRedBall.Screens.ScreenManager.Activity();

        GeneratedUpdate(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Set the RenderTarget before drawing anything
        GraphicsDevice.SetRenderTarget(renderTarget);

        // Perform the standard FRB drawing:
        GeneratedDrawEarly(gameTime);
        FlatRedBallServices.Draw();
        GeneratedDraw(gameTime);

        // Set the GraphicsDevice.RenderTarget back to null...
        GraphicsDevice.SetRenderTarget(null);

        // ...and draw the RenderTarget to the screen
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
        var destinationRectangle = new Rectangle(0, 0,
            renderTarget.Width,
            renderTarget.Height);

        spriteBatch.Draw(renderTarget, destinationRectangle, Color.White);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
```

If we run our game, it looks the same as before. The difference is that we are now drawing our RenderTarget to screen using a SpriteBatch. This allows us to make modifications to the entire screen as we draw it - typically by using a shader.

### Using a Shader

We can draw the RenderTarget to the screen using any shader which works on SpriteBatch. For this example we'll use the AdaptableCrtEffect provided by mfigueirido: [https://github.com/mfigueirido/AdaptableCrtEffect](https://github.com/mfigueirido/AdaptableCrtEffect)

Feel free to clone the entire repo to see how it works, or download the specific files:

