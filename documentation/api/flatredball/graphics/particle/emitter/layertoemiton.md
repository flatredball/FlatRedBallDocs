## Introduction

The Layer that newly-created particle [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") should be added to. This is null by default.

## Code Example

The following example adds an Emitter to a [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer"). All emitted [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") will appear behind the large, unlayered [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite").

Add the following using statements:

    using FlatRedBall.Content.Particle;
    using FlatRedBall.Graphics;

Add the following at class scope:

    Emitter emitter;

Add the following in Initialize after initializing FlatRedBall:

    // Create the Sprite that would normally cover the particles, but it won't
    // because the Emitter will be on a layer.
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ScaleX = 10;
    sprite.ScaleY = 10;

    emitter = SpriteManager.AddEmitter("redball.bmp", "Global");
    emitter.LayerToEmitOn = SpriteManager.AddLayer();
    // Move it into the distance
    emitter.Z = -10;
    emitter.TimedEmission = true;
    emitter.SecondFrequency = .1f;
    emitter.RemovalEvent = Emitter.RemovalEventType.OutOfScreen;

Add the following to Update:

    emitter.TimedEmit();

![EmitterOnLayer.png](/media/migrated_media-EmitterOnLayer.png)
