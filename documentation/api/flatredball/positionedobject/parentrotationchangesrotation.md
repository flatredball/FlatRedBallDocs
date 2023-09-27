## Introduction

The ParentRotationChangesRotation property tells an object whether its rotation should be relative to its parent rotation. This is true by default but it can be set to false.

## Sample Code

This code could be used to tell a health bar to not rotate when whatever it is attached to rotates:

    HealthBarInstance.ParentRotationChangesRotation = false;

## ParentRotationChangesRotation

Attachments create a relationship in which the child is both positioned and rotated relative to the parent. In some cases it is useful to suppress some of this behavior. The ParentRotationChangesRotation property controls whether the rotation of a child is modified by the parents' rotation. In the following example the ship [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") (represented by the red ball) rotates and moves according to input from the keyboard. The [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") is attached to the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") but does not rotate with it. **Declare the ship at class scope:**

    Sprite ship;

**In Initialize:**

     ship = SpriteManager.AddSprite("redball.bmp");
     ship.ScaleX = 2;

     SpriteManager.Camera.AttachTo(ship, true);
     SpriteManager.Camera.ParentRotationChangesRotation = false;

     // Create sprites so motion is visible
     for (int i = 0; i < 30; i++)
     {
         Sprite sprite = SpriteManager.AddSprite("redball.bmp");
         SpriteManager.Camera.PositionRandomlyInView(sprite, 41, 80);
     }

**In Update:**

     // rotate left and right
     if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
     {
         ship.RotationZVelocity = 2;
     }
     else if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
     {
         ship.RotationZVelocity = -2;
     }
     else
     {
         ship.RotationZVelocity = 0;
     }

     // Move forward
     if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
     {
         ship.XVelocity = (float)(System.Math.Cos(ship.RotationZ) * 5);
         ship.YVelocity = (float)(System.Math.Sin(ship.RotationZ) * 5);
     }
     else
     {
         ship.XVelocity = 0;
         ship.YVelocity = 0;
     }

![CameraAttachedToRotatingSprite.png](/media/migrated_media-CameraAttachedToRotatingSprite.png) Notice that although the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") is attached to the ship [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), it does not rotate. Try setting the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") ParentRotationChangesRotation property to true and observe the behavior.
