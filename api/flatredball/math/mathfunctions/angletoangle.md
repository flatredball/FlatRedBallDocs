# angletoangle

### Introduction

Returns the shortest distance to rotate from the first argument angle to the second argument angle. All values are in radians. The absolute value of the return value will never be greater than PI (half of a circle). If the value is positive then the shortest distance is achieved by rotating counterclockwise. If the value is negative then the shortest distance is achieved by rotating clockwise.

### Turning towards angle

The AngleToAngle method can be used to turn one object toward a direction. The following code creates a Sprite which will turn toward the point where the cursor is located. Add the following using statements:

```
 using FlatRedBall.Math;
 using FlatRedBall.Gui;
```

Add the following at class scope:

```
 Sprite sprite;
```

Add the following to Initialize after initializing FlatRedBall:

```
 sprite = SpriteManager.AddSprite("redball.bmp");
 sprite.ScaleX = 4;
```

Add the following to Update:

```
 float cursorX = GuiManager.Cursor.WorldXAt(0);
 float cursorY = GuiManager.Cursor.WorldYAt(0);

 float differenceX = cursorX - sprite.X;
 float differenceY = cursorY - sprite.Y;

 if (differenceX != 0 || differenceY != 0)
 {
     double angle = Math.Atan2(differenceY, differenceX);
 
     float angleDifference = (float)MathFunctions.AngleToAngle(
         sprite.RotationZ, angle);
 
     const float minDifferenceForSmoothing = .04f;
 
     if (Math.Abs(angleDifference) < minDifferenceForSmoothing)
     {
         sprite.RotationZ = (float)angle;
     }
     else
     {
         const float rotationSpeed = 2;
         sprite.RotationZVelocity = Math.Sign(angleDifference) * rotationSpeed;
     }
 }
```

![AngleToAngle.png](../../../../../media/migrated_media-AngleToAngle.png)

### Range Checks

The AngleToAngle can be used to check if one object is within an angle range. For example, you may be making a stealth game where the player must avoid being seen by enemies. We'll assume that the enemies have a property called ViewAngle which represents the edge-to-edge angle that the enemies can see. We'll also assume that this code has calculated the angle from the enemy to the player. For information on how to calculate this, see [this page](../../../../../frb/docs/index.php#Angle_Between_Two_Points).

```
// angleToPlayer is the angle from the enemy to the player
// enemy.RotationZ is the angle that the enemy is facing (assuming that the enemy is facing right when RotationZ = 0)

float angleToAngle = FlatRedBall.Math.MathFunctions.AngleToAngle(enemy.RotationZ, angleToPlayer);

// Since enemy.ViewAngle is edge-to-edge, center to edge is enemy.ViewAngle/2.0f
float angleFromCenterToEdge = enemy.ViewAngle/2.0f;

// If the absolute value of the angleToAngle is less than angleFromCenterToEdge, then the player is in view
bool playerIsInView = System.Math.Abs(angleToAngle) < angleFromCenterToEdge;
```
