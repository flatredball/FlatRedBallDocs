# Draw

### Introduction

The Draw function performs all FlatRedBall rendering. This function is automatically part of all FlatRedBall templates, including projects created by the FlatRedBall Editor, so it does not need to be added manually. However, it can be removed to quickly disable rendering of FlatRedBall for debugging and customization.

### Breaking down Draw

The Draw function can be broken down into two calls: UpdateDependencies and [RenderAll](renderall.md). Therefore, the following line:

```csharp
FlatRedBallServices.Draw();
```

could be replaced with:

```csharp
FlatRedBallServices.UpdateDependencies();
FlatRedBallServices.RenderAll();
```

The [RenderAll](renderall.md) function can be further broken-up:

```csharp
FlatRedBallServices.UpdateDependencies();
lock (Renderer.Graphics.GraphicsDevice)
{
    Renderer.Draw(null);
}

Renderer.Texture = null;
GraphicsDevice.Textures[0] = null;
```

The Renderer.Draw method can be further broken-up. By breaking apart the draw calls, each individual camera can be optionally drawn, or it can be drawn to a separate render target:

```csharp
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

The contents of DrawCamera are currently private so this method cannot be broken up further; however, the source for DrawCamera can be inspected by looking at the source code.
