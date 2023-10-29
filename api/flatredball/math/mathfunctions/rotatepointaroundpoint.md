# rotatepointaroundpoint

### Introduction

RotatePointAroundPoint is a method that can easily rotate one point around another. This method uses the [System.Math.Atan2](http://msdn.microsoft.com/en-us/library/system.math.atan2.aspx) method to calculate angles. All functionality provided by this method can also be obtained through [System.Math.Atan2](http://msdn.microsoft.com/en-us/library/system.math.atan2.aspx).

### Code Example

The following code creates a [Sprite](../../../../../frb/docs/index.php) which rotates about the origin when the user holds down the space bar. Add the following at class scope:

```
Sprite sprite;
```

Add the following to Initialize after initializing FlatRedBall:

```
sprite = SpriteManager.AddSprite("redball.bmp");
sprite.X = 3;
```

Add the following to Update:

```
 if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
 {
     const float rotationRate = 10f; // in radians per second
     const float xToRotateAbout = 0;
     const float yToRotateAbout = 0;

     // The starting point is the current location of the Sprite
     float newX = sprite.X;
     float newY = sprite.Y;

     // Rotate the point and store the new position in 
     // newX and newY
     FlatRedBall.Math.MathFunctions.RotatePointAroundPoint(
         xToRotateAbout, yToRotateAbout, 
         ref newX, ref newY, 
         rotationRate * TimeManager.SecondDifference);

     // Set the Sprite's new position to newX and newY
     sprite.X = newX;
     sprite.Y = newY;
 }
```

![RotatePointAroundPoint.png](../../../../../media/migrated\_media-RotatePointAroundPoint.png)
