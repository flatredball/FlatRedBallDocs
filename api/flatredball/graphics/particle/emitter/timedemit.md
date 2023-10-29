# timedemit

### Introduction

The Emitter's Emit method performs one emission of particles. While this is useful and gives a lot of control, it's very common to have Emitters which should emit particles at a given interval. The TimedEmit method can be used to achieve this behavior.

### Code Example

The following code creates an Emitter which emits once every .1 seconds. Add the following using statement:

```
using FlatRedBall.Graphics.Particle;
```

Declare the Emitter at class scope:

```
Emitter emitter;
```

Create the Emitter in Initialize after initializing FlatRedBall:

```
emitter = new Emitter();
SpriteManager.AddEmitter(emitter);

emitter.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", "Global");

emitter.TimedEmission = true; // This is required for TimedEmit to work
emitter.SecondFrequency = .1f;
emitter.RemovalEvent = Emitter.RemovalEventType.OutOfScreen;
```

Simply call the following code every frame (in Update):

```
emitter.TimedEmit(null);
```

![TimedEmitter.png](../../../../../../media/migrated\_media-TimedEmitter.png)

#### Timed Emitters require TimedEmit to be true

Calling TimedEmit on an emitter will do nothing if the Emitter's TimedEmission property is set to false (this is the default value). You must set it to true for the TimedEmit method to emit particles. You might be wondering why this is the case. Shouldn't simply calling TimedEmit be sufficient? The reason for this is to give a higher-level control over the behavior of your emitters. This behavior allows you to add your Emitters to a list of Emitters which will automatically have their TimedEmit method called. Then you can control whether they should be emitting at an individual level by simply flipping the TimedEmit button. For example, if you are using an Emitter for a weapon in a game, you could simply do:

```
mWeaponEmitter.TimedEmit = isSomeButtonPressed;
```

The Emitter will automatically emit when the button is down and not when it is up.

### Adding Custom Logic to Particles

The TimedEmit  method can take a SpriteList  as an optional parameter. TimedEmit  fills this SpriteList  with emitted Sprites. This SpriteList  can be used to perform custom logic on particles. The following code assumes that EmitterInstance  is a valid Emitter :

```lang:c#
SpriteList particles = new SpriteList();

private void CustomInitialize()
{
}

private void CustomActivity()
{
    EmitterIntance.TimedEmit(particles);

    PerformCustomParticleLogic();
}

private void PerformCustomParticleLogic()
{
    // Use a reverse for loop since the list might be modified
    for(int i = particles.Count - 1; i > -1; i--)
    {
        sprite = particles[i];
        // Any logic can be performed on sprite.
        // This could be used to make sprites bounce off
        // a ceiling:
        if(sprite.Y > 100 && sprite.YVelocity > 0)
        {
            sprite.YVelocity *= -1;
        }

        // This logic removes sprites which are below a y of -100:
        if(sprite.Y < -100)
        {
            SpriteManager.RemoveSprite(sprite);
        }
    }
}
```

&#x20;
