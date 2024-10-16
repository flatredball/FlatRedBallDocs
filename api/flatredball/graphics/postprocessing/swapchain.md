# SwapChain

### Introduction

SwapChains are containers for two render targets which can be used when rendering post processing effects. SwapChains can be automatically managed by FlatRedBall or can be created and updated manually when resolutions change.

### Creating a SwapChain

The following code creates an automatically managed SwapChain:

```csharp
Renderer.CreateDefaultSwapChain();
```

Alternatively SwapChains can be created explicitly. Typically the internal RenderTargets must be resized when the game's resolution changes, so the game's resize event can be subscribed to with a handler that resizes the SwapChain as shown in the following code.

```csharp
Renderer.SwapChain = new FlatRedBall.Graphics.PostProcessing.SwapChain(
    FlatRedBallServices.Game.Window.ClientBounds.Width,
    FlatRedBallServices.Game.Window.ClientBounds.Height);
    
FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += (_,_) =>
{
    Renderer.SwapChain.UpdateRenderTargetSize(
        FlatRedBallServices.Game.Window.ClientBounds.Width,
        FlatRedBallServices.Game.Window.ClientBounds.Height);
};
```

### SwapChain Concepts

SwapChains are typically used with post processing. For information about adding post processing to your game, see the [Effect (.fx, .fbx)](../../../../glue-reference/files/file-types/effect-.fx.md) documentation.

To understand the purpose of a SwapChain, we must first discuss how rendering works without a swap chain. Whenever graphics are rendered to the screen (also known as the back buffer), the following are required:

* A set of verts, which in FlatRedBall are usually a Sprite, tile in a TileMap, or Gum object
* A shader
* A destination (by default the back buffer)

Even if you do not explicitly use shaders in your game, FlatRedBall uses shaders to draw every visual object, including Sprites which draw to the screen with no visual modification.

<figure><img src="../../../../.gitbook/assets/image (345).png" alt=""><figcaption><p>Typical rendering of a Sprite in FlatRedBall using a default shader</p></figcaption></figure>

Of course, the shader may make additional modifications to the Sprite such as changing its color.

<figure><img src="../../../../.gitbook/assets/image (346).png" alt=""><figcaption><p>Example of a shader modifying the color of a Sprite</p></figcaption></figure>

Although shaders are always used when rendering individual objects, we can also use shaders to modify an entire scene after it has finished rendering. This is referred to as _post processing_. To perform post processing, all FlatRedBall objects must first be drawn to a r_ender target_ which is a temporary storage of all graphics before it is then passed through another shader which performs final modifications.

The following diagram shows what the process might look like if we were to render a sprite to a render target first, and then render that to the final screen with additional processing. Note that we can render multiple sprites to the render target, and then perform one final pass to apply post processing.

<figure><img src="../../../../.gitbook/assets/image (347).png" alt=""><figcaption><p>Example post processing applying a blur effect to the entire screen</p></figcaption></figure>

The example above applies a single post processing effect to the entire screen to produce a blurred effect. The render target becomes the _source_ or _input_ for the post processing shader which renders to the screen.

However, if we have multiple effects, then the output of the post processing shader must become the input to the next shader. For simplicity the next diagram omits the rendering of the sprites and focuses on how multiple render targets are used:

<figure><img src="../../../../.gitbook/assets/image (348).png" alt=""><figcaption><p>Multiple render targets used for a series of post processing</p></figcaption></figure>

The example above shows a situation where four render targets are used. The first is the render target that the default FlatRedBall rendering targets. Each subsequent render target is used for a separate shader, supporting three post processing effects: grayscale, pixellate, and blur.

Notice that **Render Target 1,** which is used as the destination for regular FlatRedBall rendering, is only used when rendering the Grayscale Shader to **Render Target 2**. After that, **Render Target 1** is no longer needed in the series of shader rendering. Similarly, **Render Target 2** is only needed as the destination when rendering the Grayscale shader and the source for Pixellate shader. We can reduce the number of render targets needed by reusing these render targets. Since one render target will be the source and one will be the destination, we need two render targets. Each time a shader is drawn the input and source are _swapped_, which is where the term SwapChain comes from.

<figure><img src="../../../../.gitbook/assets/image (349).png" alt=""><figcaption><p>Rendering multiple post processing effects with a SwapChain</p></figcaption></figure>

The example above uses a SwapChain to perform three post processing passes. Notice that if we were to add additional passes we could still use two render targets since each render target is reused either as a source or destination.
