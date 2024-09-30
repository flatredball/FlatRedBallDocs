# RenderTarget

### Introduction

The RenderTarget property can be set so a given Layer renders to the RenderTarget rather than to screen. The RenderTarget property can be used for a number of reasons:

* To create textures used in a multi-pass rendering system, such as to apply layer-wide effects like color tinting or bloom
* To improve the performance of complicated, static visuals on a Layer by eliminating the management of multiple objects and multiple draw calls with a single object and draw call (for a collection of objects which do not require every-frame activity)

If a Layer's RenderTarget is set, then the Layer will does render directly to the screen. The contents of the Layer are rendered to the RenderTarget which must then be rendered to the screen using another graphical object such as a FlatRedBall Sprite, a Gum Sprite, or SpriteBatch.

### Setting RenderTarget in the FRB Editor

To set a RenderTarget in the FRB Editor:

1.  Create a RenderTarget object

    ![RenderTarget instance in the FRB Editor in a Sceen](../../../../.gitbook/assets/2023-09-img\_64fb24b11ded2.png)
2.  Create a Layer instance

    ![](../../../../.gitbook/assets/2023-09-img\_64fb24cd08880.png)
3.  Set the RenderTarget property on the layer to the previously-created RenderTarget

    ![](../../../../.gitbook/assets/2023-09-img\_64fb24ee2132b.png)

As mentioned above, the contents of the Layer are rendered to its RenderTarget instead of the screen. The easiest way to see the contents of the RenderTarget is to add a Sprite and use the RenderTarget as its Texture.

![](../../../../.gitbook/assets/2023-09-img\_64fb2531b979d.png)

### Code Example

The following code shows how a RenderTarget2D can be created and assigned to the Layer.RenderTarget property. This Layer contains a single Circle which is drawn with a separate unlayered Sprite:

```csharp
using Microsoft.Xna.Framework.Graphics;

public partial class GameScreen
{
    // This Layer will contain all of the FRB objects which should be 
    // drawn on the render target:
    Layer layer;
    // This is the render target which will contain the final rendering 
    // of all FRB objects on 'layer'
    RenderTarget2D renderTarget;

    void CustomInitialize()
    {
        // Instantiate the layer:
        layer = SpriteManager.AddLayer();

        // Define the layer. This uses the current game's resolution, but it could be any size
        renderTarget = new RenderTarget2D(
            FlatRedBallServices.GraphicsDevice,
            FlatRedBallServices.GraphicsOptions.ResolutionWidth,
            FlatRedBallServices.GraphicsOptions.ResolutionHeight);
        layer.RenderTarget = renderTarget;

        var circle = new Circle();
        ShapeManager.AddToLayer(circle, layer);
        circle.Visible = true;
        circle.Radius = 40;

        var sprite = SpriteManager.AddSprite(renderTarget);
        // to show that the Sprite is rendering the circle, we'll squash it:
        sprite.Width = 300;
        sprite.Height = renderTarget.Height;
    }

    void CustomActivity(bool firstTimeCalled)
    {
    }

    void CustomDestroy()
    {
        SpriteManager.RemoveLayer(layer);
        renderTarget.Dispose();
    }

    static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

![](../../../../.gitbook/assets/2016-06-img\_5769f95188b7c.png)

Note that the above code creates a Layer in code instead of creating one in the FRB editor. This is done purely to keep the example short - Layer instances created in the FRB editor can be used as well.

### Update Frequency and One-Time Renders

RenderTarget instances can be updated every-frame, or can be rendered just one time (if the contents of the render target never change). The following code example shows how to create a RenderTarget which is used as the target only one time. This example differs in the following ways compared to the previous example:

* The layer is only needed temporarily until the render is done.
* The Renderer needs a temporary camera to perform rendering. While this example only uses a single Layer, multiple layers could be used to sort objects.
* Any rendered objects (such as entities, sprites, or shapes) are only needed for the Draw call and can be destroyed afterwards.

```csharp
public partial class GameScreen
{
    // This is the render target which will contain the final rendering of all FRB objects on 'layer'
    RenderTarget2D renderTarget;

    void CustomInitialize()
    {
        // This layer holds whatever we want drawn
        var temporaryLayer = new Layer();
            
        // Define the layer. This uses the current game's resolution, but it could be any size
        renderTarget = new RenderTarget2D(
            FlatRedBallServices.GraphicsDevice,
            FlatRedBallServices.GraphicsOptions.ResolutionWidth,
            FlatRedBallServices.GraphicsOptions.ResolutionHeight);
        temporaryLayer.RenderTarget = renderTarget;

        // This example renders a rectangle, but the layer could have anything
        var rectangle = new AxisAlignedRectangle();
        rectangle.Visible = true;
        rectangle.Width = 50;
        rectangle.Height = 40;
        ShapeManager.AddToLayer(rectangle, temporaryLayer);

        // Rendering requires a camera. We'll create a temporary one (don't add it to the SpriteManager)
        var temporaryCamera = new Camera(null, renderTarget.Width, renderTarget.Height);
        // We only want the camera to draw the layer
        temporaryCamera.DrawsWorld = false;
        temporaryCamera.UsePixelCoordinates();
        temporaryCamera.Z = 40;
        temporaryCamera.AddLayer(temporaryLayer);

        Renderer.DrawCamera(temporaryCamera, null);

        // Anything which was rendered can be destroyed. In this case it's just a 
        // rectangle, but it could be entities, Gum objects, etc
        ShapeManager.Remove(rectangle);

        // This sprite will render our layer
        var sprite = SpriteManager.AddSprite(renderTarget);
        sprite.TextureScale = 1 ;
        // rotate it to show that the rectangle is drawn on the render target
        // (normally rectangles can't be rotated visually)
        sprite.RotationZ = Microsoft.Xna.Framework.MathHelper.ToRadians(45);
    }

    void CustomActivity(bool firstTimeCalled)
    {
    }

    void CustomDestroy()
    {
        renderTarget.Dispose();
    }

    static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

![](../../../../.gitbook/assets/2018-01-img\_5a6e96a1624c5.png)

#### One-Time Renders and entities

The example above shows how to render an AxisAlignedRectangle using a one-time render to a RenderTarget. If entities (or other objects which have PositionedObject attachments) are rendered to a one-time render target, then dependencies (aka attachments) must be updated prior to rendering the render target. For example, the following snippet shows how multiple Ship instances might be rendered to a RenderTarget:

```csharp
// This layer holds whatever we want drawn
var temporaryLayer = new Layer();
            
// Define the layer. This uses the current game's resolution, but it could be any size
renderTarget = new RenderTarget2D(
        FlatRedBallServices.GraphicsDevice,
        FlatRedBallServices.GraphicsOptions.ResolutionWidth,
        FlatRedBallServices.GraphicsOptions.ResolutionHeight);
temporaryLayer.RenderTarget = renderTarget;

// Create the ships (put them in a list so we can destroy them after drawing):
var temporaryShips = new PositionedObjectList<Ship>();
for(int i = 0; i < 10; i++)
{
    var ship = new Ship();
    ship.MoveToLayer(temporaryLayer);

    // The ship normally would have its dependencies automatically updated prior to
    // the regular FRB Draw method, but since we're doing custom rendering, 
    // the ship doesn't have chance to do so prior to our Draw call.
    // Therefore we'll manually update the dependencies after setting the
    // ship's position:
    ship.X = i * 30;
    ship.Y = 30;

    ship.UpdateDependenciesDeep();
}

// Rendering requires a camera. We'll create a temporary one (don't add it to the SpriteManager)
var temporaryCamera = new Camera(null, renderTarget.Width, renderTarget.Height);
// We only want the camera to draw the layer
temporaryCamera.DrawsWorld = false;
temporaryCamera.UsePixelCoordinates();
temporaryCamera.Z = 40;
temporaryCamera.AddLayer(temporaryLayer);

Renderer.DrawCamera(temporaryCamera, null);

// Anything which was rendered can be destroyed.
for(int i = temporaryShips.Count - 1; i > -1; i--)
{
    temporaryShips[i].Destroy();
}
        
// This sprite will render our layer
var sprite = SpriteManager.AddSprite(renderTarget);
sprite.TextureScale = 1 ;
```

### Render Target Size

The RenderTarget2D constructor takes width and height parameters. These values can be as large as the current game's resolution, but they can also be smaller. If a smaller resolution is used, the Layer will be rendered at lower resolution, but the entire layer will still be drawn. For example, first we will modify the example above to no longer squash the Sprite:

```clike
    void CustomInitialize()
    {
        ...

        var sprite = SpriteManager.AddSprite(renderTarget);
        // Setting the TextureScale is an easy way to make it draw 1:1 on screen:
        sprite.TextureScale = 1;
    }
```

![](../../../../.gitbook/assets/2016-06-img\_5769fc648f937.png)

We can adjust the RenderTarget2D constructor so the RenderTarget is 1/4 the resolution, as shown in the following code snippet:

```csharp
    void CustomInitialize()
    {
        layer = SpriteManager.AddLayer();

        renderTarget = new RenderTarget2D(
            FlatRedBallServices.GraphicsDevice,
            FlatRedBallServices.GraphicsOptions.ResolutionWidth / 4,
            FlatRedBallServices.GraphicsOptions.ResolutionHeight / 4);
        ...
```

Since the Sprite uses a TextureScale of 1, shrinking the RenderTarget2D will also shrink the Sprite:

![](../../../../.gitbook/assets/2016-06-img\_5769fe5a1b19d.png)

To compensate for this, the Sprite.TextureScale property can be changed to 4. This will result in the RenderTarget2D being drawn at the same size as before, but it will be 1/4 the resolution, so it will appear pixellated (or blurred due to linear filtering):

```csharp
    void CustomInitialize()
    {
        ...

        var sprite = SpriteManager.AddSprite(renderTarget);
        // Setting the TextureScale is an easy way to make it draw 1:1 on screen:
        sprite.TextureScale = 4;
    }
```

&#x20;

<figure><img src="../../../../.gitbook/assets/2016-06-img_576a01725c7a7.png" alt=""><figcaption></figcaption></figure>

Rendering to a RenderTarget2D which is smaller than the game's resolution can improve performance, especially if the RenderTarget2D is used with effects which do not need full-resolution images, such as blurring.
