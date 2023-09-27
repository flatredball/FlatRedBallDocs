## Introduction

Velocity is a value that controls how fast an object moves. Setting Velocity on an unattached, managed PositionedObject (including Entities in Glue) will result in that object moving automatically. Velocity is measured in units per second. In other words, setting your object's Velocity.X value to 100 will result in its X value increasing by 100 unit per second - of course, the increase will happen smoothly as opposed to jumping by one unit every second.

## Velocity is a Vector3

Velocity is a Vector3 meaning it has three components:

-   Velocity.X
-   Velocity.Y
-   Velocity.Z

PositionedObjects also provide individual float values for each of the velocity components:

-   XVelocity
-   YVelocity
-   ZVelocity

Setting the values directly on the float properties or on the Velocity values does the same thing, so which you use is a matter of preference. You can also set and get each component individually, or work with the entire vector in mathematical operations. To set the X velocity you can access the X component as follows:

    // set the value on Velocity...
    this.Velocity.X = 3;
    // or set the XVelocity property:
    this.XVelocity = 3;

You can also get individual values. For example:

    // check the value on Velocity...
    bool isFalling = this.Velocity.Y < 0;
    // or check the YVelocity property
    bool isFalling = this.YVelocity;

## Code Example - Assigning Velocity on an Entity

All entities can have their Velocity value assigned. This example shows how to create a bullet and assign its velocity so that it moves to the right whenever the space bar is pressed. This code uses an entity named Bullet.

    using Microsoft.Xna.Framework;
    ...
    float BulletSpeed = 150;
    void CustomActivity(bool firstTimeCalled)
    {
        if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            var bullet = Factories.BulletFactory.CreateNew();

            bullet.Velocity = new Vector3(BulletSpeed, 0, 0);
        }
    }

[![](/wp-content/uploads/2016/01/16_08-10-08.gif.md)](/wp-content/uploads/2016/01/16_08-10-08.gif.md) The code could also be modified to shoot the bullets at angles. For example, the following code shows how to shoot 5 bullets in a spread angle:

    using Microsoft.Xna.Framework;
    ...
    float BulletSpeed = 150;
    void CustomActivity(bool firstTimeCalled)
    {
        if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            var bullet = Factories.BulletFactory.CreateNew();
            bullet.Velocity = new Vector3(BulletSpeed, 0, 0).AtAngle(MathHelper.ToRadians(45));

            bullet = Factories.BulletFactory.CreateNew();
            bullet.Velocity = new Vector3(BulletSpeed, 0, 0).AtAngle(MathHelper.ToRadians(22));

            bullet = Factories.BulletFactory.CreateNew();
            bullet.Velocity = new Vector3(BulletSpeed, 0, 0).AtAngle(MathHelper.ToRadians(0));

            bullet = Factories.BulletFactory.CreateNew();
            bullet.Velocity = new Vector3(BulletSpeed, 0, 0).AtAngle(MathHelper.ToRadians(-22));

            bullet = Factories.BulletFactory.CreateNew();
            bullet.Velocity = new Vector3(BulletSpeed, 0, 0).AtAngle(MathHelper.ToRadians(-45));
        }
    }

##  [![](/wp-content/uploads/2016/01/16_08-14-14.gif.md)](/wp-content/uploads/2016/01/16_08-14-14.gif.md)

## The persistence of Velocity

If the Velocity of an object is set, it will remain until changed. For example, consider the following code:

    if(InputManager.Keyboard.KeyDown(Keys.Right))
    {
       myCharacter.Velocity.X = 100;
    }

If you add this code (assuming you have a myCharacter object which is a PositionedObject), you will notice that your character keeps moving even after you release the Right arrow key. The reason is because the Velocity value will not change back to 0 every frame automatically. You will have to change it back yourself, as follows:

    if(InputManager.Keyboard.KeyDown(Keys.Right))
    {
       myCharacter.Velocity.X = 100;
    }
    else
    {
       myCharacter.Velocity.X = 0;
    }

## Moving from one object toward another

You can make a PositionedObject move from one object to another by using the Velocity and Position code. For example, you may have a bullet which is being fired toward the player. For this example we will use two PositionedObjects: Bullet and Player.

    Vector3 vectorFromBulletToPlayer = Player.Position - Bullet.Position;
    vectorFromBulletToPlayer.Normalize();
    float speedToMoveAt = 30; // this means 30 units per second
    Bullet.Velocity = vectorFromBulletToPlayer * speedToMoveAt;

## Velocity and Parent

If an object has a non-null Parent, then you must use [RelativeVelocity](/frb/docs/index.php?title=FlatRedBall.PositionedObject.RelativeVelocity&action=edit&redlink=1.md "FlatRedBall.PositionedObject.RelativeVelocity (page does not exist)") instead of Velocity.
