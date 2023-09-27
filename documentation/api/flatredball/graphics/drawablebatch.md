## Introduction

Although the feature set for FlatRedBall is rapidly expanding, it is impossible for the engine to handle every graphical possibility. DrawableBatches are a solution to this problem as they allow custom rendering in the engine. A DrawableBatch is a class that implements the IDrawableBatch interface, which allows user-specified rendering through XNA/MonoGame. For a full API reference of MonoGame, see the [MonoGame Class Reference](http://www.monogame.net/documentation/?page=api).

## Code Example

The following code shows how to create a class that implements IDrawableBatch . This class draws a triangle which uses vertex colors - each point on the triangle is a different color.

``` lang:c#
public class DrawableBatchExample : PositionedObject, IDrawableBatch
{
    // Even though this IDB doesn't use textures, we'll use a textured vert
    // to make it easier to expand
    VertexPositionColorTexture[] verts;
    BasicEffect effect;

    public bool UpdateEveryFrame
    {
        get
        {
            return true;
        }
    }

    public DrawableBatchExample()
    {
        verts = new VertexPositionColorTexture[3];

        verts[0].Position = new Microsoft.Xna.Framework.Vector3(-200, -200, 0);
        verts[1].Position = new Microsoft.Xna.Framework.Vector3(0, 150, 0);
        verts[2].Position = new Microsoft.Xna.Framework.Vector3(200, -200, 0);

        verts[0].Color = Color.Red;
        verts[1].Color = Color.Green;
        verts[2].Color = Color.Blue;

        effect = new BasicEffect(FlatRedBallServices.GraphicsDevice);
        // The effect controls which properties are considered when DrawUserPrimitives
        // is called below. VertexColorEnabled must be set to true to get the triangle's
        // vertex colors to show up. If this is false, the triangle will be white.
        effect.VertexColorEnabled = true;
    }

    public void Destroy()
    {

    }

    public void Draw(Camera camera)
    {
        var graphicsDevice = FlatRedBallServices.GraphicsDevice;

        // Setting the view and projection makes the IDrawableBatch
        // render using FRB's camera settings. Usually IDrawableBatches
        // should use the argument camera's view and projection matrices
        effect.View = camera.View;
        effect.Projection = camera.Projection;

        foreach (var pass in effect.CurrentTechnique.Passes)
        {
            pass.Apply();

            graphicsDevice.DrawUserPrimitives(
                // Render a triangle:
                PrimitiveType.TriangleList,
                // The array of verts that we want to render
                verts,
                // The offset, which is 0 since we want to start 
                // at the beginning of the verts array
                0,
                // The number of triangles to draw
                1);
        }
    }

    public void Update()
    {

    }
}
```

The following code shows how the DrawableBatchExample  can be used in a screen:

``` lang:c#
public partial class GameScreen
{
    DrawableBatchExample drawableBatch;
    void CustomInitialize()
    {
        drawableBatch = new DrawableBatchExample();
        SpriteManager.AddDrawableBatch(drawableBatch);
    }

    void CustomActivity(bool firstTimeCalled)
    {

    }

    void CustomDestroy()
    {
        // This calls the IDrawableBatch's Destroy method:
        SpriteManager.RemoveDrawableBatch(drawableBatch);
    }

    static void CustomLoadStaticContent(string contentManagerName)
    {

    }
}
```

The code above produces the following when the game runs:

![](/media/2016-06-img_57616a108d6e8.png)

 

## Invalid IDrawableBatch Actions

The IDrawableBatch interface provides considerable freedom in custom drawing. However, the IDrawableBatch's Draw method is a method which is executed during FlatRedBall's Draw call. This means that it is possible to change the state of the graphics device in such a way that will cause FlatRedBall to render incorrectly or even crash. The following lists actions which should not be performed.

### Changing Viewport

The GraphicsDevice's Viewport should not be changed. IDrawableBatches can be added to [Layers](/frb/docs/index.php?title=Layer.md "Layer") - including [Camera](/frb/docs/index.php?title=Camera.md "Camera")-specific [Layers](/frb/docs/index.php?title=Layer.md "Layer") which inherit the containing [Camera](/frb/docs/index.php?title=Camera.md "Camera")'s viewport. In other words, to render to a portion of the Screen, add the IDrawableBatch to the desired [Camera](/frb/docs/index.php?title=Camera.md "Camera") using the [SpriteManager's AddToLayer](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddToLayer.md "FlatRedBall.SpriteManager.AddToLayer") method.

### Calling SetRenderTarget

FlatRedBall handles render targets under the hood. Changing the RenderTarget can result in unexpected behavior or crashing. For control over render targets, use the [Camera](/frb/docs/index.php?title=Camera.md "Camera")'s RenderOrder property. If you are interested in performing something not currently supported by one of the render modes, please post on the forums.

## Additional Information

-   [Using DrawableBatches to apply custom shaders to Sprites](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Sprite_Effects.md "FlatRedBallXna:Tutorials:Custom Sprite Effects")
-   [SpriteManager.AddToLayer](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddToLayer.md "FlatRedBall.SpriteManager.AddToLayer") - This method can be used to put DrawableBatches on layers for additional sorting control.

## Related Information

-   [Render States and IDrawableBatches](/frb/docs/index.php?title=FlatRedBall.Graphics.DrawableBatch:Render_State.md "FlatRedBall.Graphics.DrawableBatch:Render State")

## IDrawableBatch Members

-   [FlatRedBall.Graphics.IDrawableBatch.Z](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch.Z.md "FlatRedBall.Graphics.IDrawableBatch.Z")

### UpdateEveryFrame

Boolean get-only Property that specifies whether or not the Update() method will be called on this drawable batch. If you don't need to do any updating logic, just return false. For example:

    public bool UpdateEveryFrame
    {
        get { return false; }
    }

### Update

This is where any updating logic goes. This could include updating positions, moving particles, or anything else that your drawable batch might need to do outside of drawing. This method is actually called inside the FlatRedBallServices' Draw method, so you should not be doing any RenderTarget setting here.

### Draw

Executes your drawing code. The *camera* parameter represents the currently drawing camera, and may be used to retrieve camera settings (the SetDeviceViewAndProjection will work with both the BasicEffect and Effect classes, and will set the variables View, Projection, ViewProj, and any variables that have the semantics VIEW or PROJECTION). Any XNA drawing code may be used in this section. However, please note that RenderState is *not* preserved, so you will need to set any RenderState variables at the beginning of this method. This includes anything on the graphics device, such as a vertex declaration. For more information, read the [Render State article](/frb/docs/index.php?title=FlatRedBall.Graphics.DrawableBatch:Render_State.md "FlatRedBall.Graphics.DrawableBatch:Render State").

### Destroy

Here is where you destroy any assets that won't be automatically destroyed when they go out of scope (for example, some types of buffers), and do any other cleanup you might need to perform (removing the batch from some lists, for example).

## Community Source Code

-   [Pie DrawableBatch](/frb/docs/index.php?title=Community_Source_Code:Pie_IDrawableBatch.md "Community Source Code:Pie IDrawableBatch")
-   [Video Rendering](/frb/forum/viewtopic.php?f=24&t=4213.md)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
