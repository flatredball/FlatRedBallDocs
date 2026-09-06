# MonoGame.Extended Particles

### Introduction

[MonoGame.Extended](https://www.monogameextended.net/) includes a particle system with its own editor, [Ember](https://www.monogameextended.net/docs/tools/ember/). You can draw its `ParticleEffect` inside FlatRedBall by wrapping it in an [IDrawableBatch](./). Once you do, the particles move and sort with the FlatRedBall camera like any other FlatRedBall object.

FlatRedBall has its own particle system built on [Emitter](../particle/emitter.md) and `.emix` files. For most games that is the simpler choice. Use MonoGame.Extended when you want Ember or its set of modifiers and interpolators.

The full runnable project is in the FlatRedBall repository at `Samples/MonoGameExtendedParticles`.

### Main Concepts

* Particles simulate in a Y-down space, so you convert coordinates at the boundary
* `Update` runs during FlatRedBall's draw phase
* Render state is not preserved between drawable batches
* `AutoTrigger` is on by default
* MonoGame.Extended 6.1.1 needs MonoGame 3.8.5

### The Drawable Batch

This class is the whole integration. Copy it into your project and hand it a `ParticleEffect`.

```csharp
using System;
using FlatRedBall;
using FlatRedBall.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Particles;

public class ParticleEffectDrawableBatch : PositionedObject, IDrawableBatch
{
    readonly ParticleEffect particleEffect;
    readonly SpriteBatch spriteBatch;

    public BlendState BlendState { get; set; } = BlendState.Additive;

    public ParticleEffect ParticleEffect => particleEffect;

    public bool UpdateEveryFrame => true;

    public ParticleEffectDrawableBatch(ParticleEffect particleEffect)
    {
        this.particleEffect = particleEffect ?? throw new ArgumentNullException(nameof(particleEffect));
        spriteBatch = new SpriteBatch(FlatRedBallServices.GraphicsDevice);
    }

    public void Trigger(float worldX, float worldY)
    {
        particleEffect.Trigger(new Vector2(worldX, -worldY));
    }

    public void Update()
    {
        particleEffect.Update(TimeManager.SecondDifference);
    }

    public void Draw(Camera camera)
    {
        spriteBatch.Begin(
            blendState: BlendState,
            samplerState: SamplerState.LinearClamp,
            transformMatrix: BuildTransform(camera));

        spriteBatch.Draw(particleEffect);

        spriteBatch.End();
    }

    Matrix BuildTransform(Camera camera)
    {
        var destination = camera.DestinationRectangle;
        var zoom = camera.CurrentZoom;

        return
            Matrix.CreateTranslation(this.X - camera.X, camera.Y - this.Y, 0) *
            Matrix.CreateScale(zoom, zoom, 1) *
            Matrix.CreateTranslation(destination.Width / 2f, destination.Height / 2f, 0);
    }

    public void Destroy()
    {
        particleEffect.Dispose();
        spriteBatch.Dispose();
    }
}
```

Add the batch to the engine the same way you add any other drawable batch.

```csharp
var batch = new ParticleEffectDrawableBatch(myEffect);
SpriteManager.AddDrawableBatch(batch);
```

To put the particles on a [Layer](../../layer/), use `SpriteManager.AddToLayer` instead. Call `SpriteManager.RemoveDrawableBatch` when you are done, which calls the batch's `Destroy` method.

### Coordinate Space

MonoGame.Extended simulates and draws particles in SpriteBatch coordinates, where +Y points down the screen. FlatRedBall's world has +Y pointing up.

You could flip Y in the transform matrix, but that also mirrors every particle texture and reverses particle rotation. The code above keeps the simulation in MonoGame.Extended's own space and converts FlatRedBall world coordinates in `Trigger` instead. So you pass normal FlatRedBall coordinates in, and modifiers still read the way they look. A `LinearGravityModifier` pointing at `Vector2.UnitY` falls down the screen.

```csharp
batch.Trigger(
    InputManager.Mouse.WorldXAt(0),
    InputManager.Mouse.WorldYAt(0));
```

`BuildTransform` does not handle camera roll. If your camera rotates, add a `Matrix.CreateRotationZ` between the translation and the scale.

### Update Runs During Draw

FlatRedBall calls `IDrawableBatch.Update` inside its draw phase. That is where you advance the particle simulation, and it is why `UpdateEveryFrame` returns true. Do not change render targets there. See [RenderState](render-state.md).

### Render State

FlatRedBall does not preserve render state between drawable batches, so `Draw` sets its own blend and sampler state every frame.

Blend state also changes how particles fade. MonoGame.Extended multiplies particle color by opacity when the device blend state is `AlphaBlend`, and writes opacity into the alpha channel otherwise. Additive suits fire, sparks, and magic. `AlphaBlend` suits smoke and dust.

### AutoTrigger

`ParticleEffect`'s constructor sets `AutoTrigger` to true. An effect you only want to fire on demand emits once a second on its own until you turn it off.

```csharp
var effect = new ParticleEffect("Burst")
{
    AutoTrigger = false,
    // ...
};
```

### MonoGame Versions

MonoGame.Extended 6.1.1 is compiled against MonoGame 3.8.5 and binds to that exact assembly version. FlatRedBall's net8.0 engine project references MonoGame 3.8.4.1. Reference `MonoGame.Framework.DesktopGL` 3.8.5.1 in your game project so NuGet settles on the higher version. FlatRedBall runs on it fine.

If you leave your project on 3.8.4.1 it still compiles. It then throws a `FileNotFoundException` for `MonoGame.Framework 3.8.5.0` the first time particle code runs.

MonoGame.Extended 6.x ships `net8.0` only, so your game cannot target net6.0.

### Name Collisions

FlatRedBall, MonoGame, and MonoGame.Extended each define a type called `Sprite`, and FlatRedBall and MonoGame each define a `Mouse`. Alias the ones you need instead of importing `MonoGame.Extended.Graphics` wholesale.

```csharp
using Texture2DRegion = MonoGame.Extended.Graphics.Texture2DRegion;
using FrbMouse = FlatRedBall.Input.Mouse;
```

### Using an Ember File

The sample builds its effects in code so it needs no content pipeline. To load an effect you authored in Ember, use `ParticleEffect.FromFile` and pass the result to the drawable batch. Nothing in the batch changes.

```csharp
var effect = ParticleEffect.FromFile("Content/explosion.json", this.Content);
var batch = new ParticleEffectDrawableBatch(effect);
SpriteManager.AddDrawableBatch(batch);
```

### Conclusion

The drawable batch above is all you need to render MonoGame.Extended particles in a FlatRedBall game.
