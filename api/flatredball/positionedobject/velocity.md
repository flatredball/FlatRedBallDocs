# Velocity

### Introduction

Velocity is a value that controls how fast an object moves. Setting Velocity on an unattached, managed PositionedObject (including Entities in created in the FRB Editor) results in that object moving automatically.

Velocity is measured in units per second. In other words, setting your object's Velocity.X value to 100 results in its X value increasing by 100 unit per second. This increase happens incrementally every frame as opposed to jumping by one unit every second.

### Velocity is a Vector3

Velocity is a Vector3 meaning it has three components:

* Velocity.X
* Velocity.Y
* Velocity.Z

PositionedObjects also provide individual float values for each of the velocity components:

* XVelocity
* YVelocity
* ZVelocity

Setting the values directly on the float properties or on the Velocity values does the same thing, so which you use is a matter of preference. You can also set and get each component individually, or work with the entire vector in mathematical operations. To set the X velocity you can access the X component as follows:

```csharp
// set the value on Velocity...
this.Velocity.X = 3;
// or set the XVelocity property:
this.XVelocity = 3;
```

You can also get individual values. For example:

```csharp
// check the value on Velocity...
bool isFalling = this.Velocity.Y < 0;
// or check the YVelocity property
bool isFalling = this.YVelocity < 0;
```

### Code Example - Assigning Velocity on an Entity

All entities can have their Velocity value assigned. This example shows how to create a bullet and assign its velocity so that it moves to the right whenever the space bar is pressed. This code uses an entity named Bullet.

```csharp
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
```

<figure><img src="../../../.gitbook/assets/2016-01-16_08-10-08.gif" alt=""><figcaption></figcaption></figure>

The code could also be modified to shoot the bullets at angles. For example, the following code shows how to shoot 5 bullets in a spread angle:

```csharp
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
```

<figure><img src="../../../.gitbook/assets/2016-01-16_08-14-14.gif" alt=""><figcaption></figcaption></figure>

### The persistence of Velocity

If the Velocity of an object is set, it remains until changed. For example, consider the following code:

```csharp
if(InputManager.Keyboard.KeyDown(Keys.Right))
{
   myCharacter.Velocity.X = 100;
}
```

If you add this code (assuming you have a myCharacter PositionedObject instance), myCharacter keeps moving even after releasing the Right arrow key. Velocity value does not get reset to 0 every frame automatically. To stop movement, it must be changed. For example the following code stops myCharacter if the Right key is not held:

```csharp
if(InputManager.Keyboard.KeyDown(Keys.Right))
{
   myCharacter.Velocity.X = 100;
}
else
{
   myCharacter.Velocity.X = 0;
}
```

### Moving from one object toward another

You can make a PositionedObject move from one object to another by using the Velocity and Position code. For example the following code could be used to fire a bullet at a player:

```
Vector3 vectorFromBulletToPlayer = Player.Position - Bullet.Position;
vectorFromBulletToPlayer.Normalize();
float speedToMoveAt = 30; // this means 30 units per second
Bullet.Velocity = vectorFromBulletToPlayer * speedToMoveAt;
```

### Velocity and Parent

If an object has a non-null Parent, then you must use [RelativeVelocity](relativevelocity.md) instead of Velocity.
