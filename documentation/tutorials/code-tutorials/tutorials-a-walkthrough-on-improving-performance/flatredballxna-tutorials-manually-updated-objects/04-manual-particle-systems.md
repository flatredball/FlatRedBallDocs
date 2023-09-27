## Introduction

Particles may require a large number of FlatRedBall Sprite instances. This guide shows how to create an incredibly efficient particle system using manual particle sprites.

## What is a Manual Particle Sprite?

Manual sprites are sprites which the engine does not automatically update every frame. Manual sprites are an efficient alternative to automatically-updates sprites (the default) if:

-   The sprite does not change often (such as a static background object)
-   The sprite changes frequently, but only uses a subset of variables that change every frame

The term "particle sprite" implies it is used for particle effects, but technically a particle sprite is pooled - supporting rapid addition and removal without any memory allocation.

## Code Example

The following code is written in a screen which has access to a Texture2D called Texture. Notice that it creates sprites very quickly (60 per second), and even at large numbers the game will run at a reasonable speed:  

``` lang:c#
public partial class GameScreen
{
    // Keep track of the sprites created, these need to be destroyed...somewhere
    List<Sprite> sprites = new List<Sprite>();
    void CustomInitialize()
    {

    }

    void CustomActivity(bool firstTimeCalled)
    {
        // We'll create sprites when the space bar is down - 60 sprites per second
        if(InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            CreateSprite();
        }
        ManageSprites();

        FlatRedBall.Debugging.Debugger.Write(sprites.Count);
    }

    private void CreateSprite()
    {
        var sprite = SpriteManager.AddManualParticleSprite(Texture);
        sprite.X = FlatRedBallServices.Random.Between(-200, 200);
        sprite.Y = 200;

        sprite.RotationZ = FlatRedBallServices.Random.AngleRadians();
        sprite.Velocity.Y = -15;
        sprite.RotationZVelocity = 1;
        sprite.TextureScale = 1;

        sprites.Add(sprite);
    }

    private void ManageSprites()
    {
        var count = sprites.Count;
        for(int i = 0; i < count; i++)
        {
            var sprite = sprites[i];
            // We limit what we apply to what we need for maximum performance.
            // Specifically, this means only velocity for Y position and Z rotation
            sprite.Position.Y += sprite.Velocity.Y * TimeManager.SecondDifference;
            sprite.RotationZ += sprite.RotationZVelocity * TimeManager.SecondDifference;

            SpriteManager.ManualUpdate(sprite);
        }
    }

    void CustomDestroy()
    {
    }

    static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

 

![](/media/2017-06-img_59495601556b0.png)
