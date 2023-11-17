# Acceleration

### Introduction

The acceleration property can be used to apply force to your objects in a physically realistic way. A force is anything which continually makes your object move faster and faster (or slower and slower if the force is in the opposite direction of the object's current Velocity). Examples of forces include:

* Gravity
* Car accelerator pedal
* Car brake pedal
* Space ship rockets
* Magnetism (varies according to distance)

Acceleration can also be used to create smooth speed-up and slow-down movement for platformers and top down games.

If acceleration is constant (such as gravity in a platformer), it only needs to be assigned once. Acceleration should only be assigned in Custom Activity if it changes every frame, such as the gravity on an orbiting body.

### Code example

The following piece of code uses a Circle, sets the acceleration, then applies velocity for jumping and resting. It assumes a screen which contains a Circle called CircleInstance.

Screen's CustomInitialize:

```
void CustomInitialize()
{
    // In a full game, Gravity should probably be assigned as a variable in a Screen or on an Entity
    const float Gravity = -500;
    CircleInstance.YAcceleration = Gravity;
}
```

Screen's CustomActivity:

```
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
```

![AccelerationGif.gif](../../../media/migrated\_media-AccelerationGif.gif)

### Acceleration and Velocity

By itself, Acceleration has no impact on an object. Acceleration is applied to the Velocity of managed objects. This velocity is then used to modify the Position, which results in an object moving.

By default, objects (such as entities) are managed, so Acceleration is applied automatically.

### Additional Information

* [GetPositionAfterTime](../../../frb/docs/index.php) - This function can be used to predict the position of objects given an object's starting position, velocity, and acceleration.
