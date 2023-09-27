## Introduction

The acceleration property can be used to apply force to your objects in a physically realistic way. A force is anything which continually makes your object move faster and faster (or slower and slower if the force is in the opposite direction of the object's current Velocity). Examples of forces include:

-   Gravity
-   Car gas pedal
-   Car brake pedal
-   Space ship rockets
-   Magnetism (varies according to distance)

Acceleration can also be used to create smooth speed-up and slow-down movement for platformers and top down games.

## Code example

The following piece of code uses a Circle, sets the acceleration, then applies velocity for jumping and resting. It assumes a screen which contains a Circle called CircleInstance.

Screen's CustomInitialize:

    void CustomInitialize()
    {
        // Normally this is a Glue variable
        const float Gravity = -500;
        CircleInstance.YAcceleration = Gravity;
    }

Screen's CustomActivity:

    void CustomActivity(bool firstTimeCalled)
    {
        const float ground = 0;
        if(CircleInstance.Y - CircleInstance.Radius < ground)
        {
            CircleInstance.Y = ground + CircleInstance.Radius;
            // Resetting the velocity isn't required in this
            // case, but in a real game velocity is often reset
            // to prevent velocity accumulation while on the ground.
            CircleInstance.YVelocity = 0;
        }

        if (InputManager.Keyboard.KeyPushed(Keys.Space))
        {
            // Normally this is a Glue variable
            const float JumpStrength = 400;
            CircleInstance.YVelocity = JumpStrength;
        }
    }

![AccelerationGif.gif](/media/migrated_media-AccelerationGif.gif)

## Additional Information

-   [GetPositionAfterTime](/frb/docs/index.php?title=FlatRedBall.Math.MathFunctions.GetPositionAfterTime.md "FlatRedBall.Math.MathFunctions.GetPositionAfterTime") - This function can be used to predict the position of objects given an object's starting position, velocity, and acceleration.
