# draw

### Introduction

The Draw function is the function that initiates all FlatRedBall rendering. This function is automatically part of all FlatRedBall templates, including any Glue projects, so it does not need to be added manually. However, it can be removed to quickly disable rendering of FlatRedBall for debugging and customization.

### Breaking down Draw

The Draw function can be broken down into two calls: [UpdateDependencies](../../../../frb/docs/index.php) and [RenderAll](renderall.md). Therefore, the following line:

```
FlatRedBallServices.Draw();
```

could be replaced with:

```
FlatRedBallServices.UpdateDependencies();
FlatRedBallServices.RenderAll();
```

The [RenderAll](renderall.md) function can be further broken-up:

```
FlatRedBallServices.UpdateDependencies();
lock (Renderer.Graphics.GraphicsDevice)
{
    Renderer.Draw(null);
}

Renderer.Texture = null;
GraphicsDevice.Textures[0] = null;
```

The Renderer.Draw method can be further broken-up:

```
FlatRedBallServices.UpdateDependencies();
lock (Renderer.Graphics.GraphicsDevice)
{
    for (int i = 0; i < SpriteManager.Cameras.Count; i++)
    {
        Camera camera = SpriteManager.Cameras[i];
        Renderer.DrawCamera(camera, null);
    }
}

Renderer.Texture = null;
GraphicsDevice.Textures[0] = null;
```

&#x20;
