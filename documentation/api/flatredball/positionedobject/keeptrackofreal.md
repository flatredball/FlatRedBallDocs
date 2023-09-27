## Introduction

The PositionedObject's Velocity and Acceleration values often dictate the position and movement of a PositionedObject, but sometimes these properties are also used in game code to control other objects. For example, in a physically realistic game if an airplane is flying at a certain speed and fires a bullet, the bullet's world velocity should equal the velocity relative to the barrel where it was fired plus the velocity of the airplane (at least initially if drag is being considered). In these situations it's important to use the accurate velocity or acceleration; but sometimes the value reported in the Velocity and Acceleration properties do not reflect the actual on-screen velocity of an object. For example, if we made a game where our character was standing on a boat, we may simply [attach](/frb/docs/index.php?title=FlatRedBall.PositionedObject.AttachTo "FlatRedBall.PositionedObject.AttachTo") the character to the boat and work with relative positions. If the boat moves, the character moves, but we never explicitly set the character's Velocity property, nor has the engine touched it. If we want to base behavior off of the character's actual world velocity then we can use "real" values. To use real values, the KeepTrackOfReal property must be set to true. After this is done, any PositionedObject which is being managed will report its real velocity and acceleration through its RealVelocity and RealAcceleration properties.

## Code Example

The following code creates two [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and uses the RealVelocity property of the attached Sprite to apply a velocity to newly-created [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). In Initialize after initializing FlatRedBall:

     Sprite parentSprite = SpriteManager.AddSprite("redball.bmp");
     parentSprite.RotationZVelocity = 1;

     Sprite childSprite = SpriteManager.AddSprite("redball.bmp");
     childSprite.X = 3;
     childSprite.AttachTo(parentSprite, true);
     childSprite.KeepTrackOfReal = true;
     childSprite.CustomBehavior += CreateNewSpriteEachFrame;

Later define CreateNewSpriteEachFrame:

    void CreateNewSpriteEachFrame(Sprite sprite)
    {
        if (sprite.RealVelocity.X != 0 || sprite.RealVelocity.Y != 0)
        {
            Sprite newSprite = SpriteManager.AddParticleSprite(sprite.Texture);
            newSprite.Velocity = sprite.RealVelocity;
            newSprite.Position = sprite.Position;
            newSprite.CustomBehavior += 
              FlatRedBall.Utilities.CustomBehaviorFunctions.RemoveWhenOutsideOfScreen;
        }
    }

![RealVelocitySpiral.png](/media/migrated_media-RealVelocitySpiral.png) **Note**: The previous code section uses the [Sprite's](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") [CustomBehavior](/frb/docs/index.php?title=FlatRedBall.SpriteCustomBehavior "FlatRedBall.SpriteCustomBehavior") event. This event exists in the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") class, not in the PositionedObject class. For more information, see the [SpriteCustomBehavior wiki entry](/frb/docs/index.php?title=FlatRedBall.SpriteCustomBehavior "FlatRedBall.SpriteCustomBehavior").
