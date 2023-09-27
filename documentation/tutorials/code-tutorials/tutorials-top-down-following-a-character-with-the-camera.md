## Introduction

Top-down games which are played in an area larger than the size of the screen usually require a scrolling Camera. This problem can be solved a number of different ways. This article discusses the approaches and why each may be used.

## Attaching the Camera to the Character

If the Character is a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") (which it will be if using Entities in Glue) then you can simply attach the Camera to the Character as follows:

    Camera camera = Camera.Main;
    camera.AttachTo(CharacterInstance, false);
    camera.RelativeZ = 40;
    camera.RelativeX = 0;
    camera.RelativeY = 0;

This approach can be set up very quickly and will work; however the Camera will be completely fixed on the character. This is problematic if you want to keep the Camera from moving beyond a certain point or if you want to have more natural camera movement. However, this approach can be useful for prototypes or the early stages of a game.

## Fixed Follow Camera

The fixed follow Camera approach is similar to attachment except it allows for min and max values. You can implement a fixed follow Camera as follows:

    Camera camera = Camera.Main;
    camera.X = Character.X;
    camera.Y = Character.Y;
    // assuming CameraMinX, CameraMaxX, CameraMinY, and CameraMaxY are all defined:
    camera.X = Math.Max(CameraMinX, camera.X);
    camera.X = Math.Min(CameraMaxX, camera.X);
    camera.Y = Math.Max(CameraMinY, camera.Y);
    camera.Y = Math.Min(CameraMaxY, camera.Y);

## Velocity Follow Camera

Velocity follow Camera is a behavior where the Camera lags behind a Character when the Character moves, but will slowly approach the Character when the Character stops. This logic would typically be added to a Screen, such as GameScreen's CustomActivity:

    void CustomActivity(bool firstTimeCalled)
    {
      float movementCoefficient = 1;
      Vector3 velocityToSet = Character.Position - Camera.Main.Position;
      velocityToSet.Z = 0;
      Camera.Main.Velocity = movementCoefficient * velocityToSet;
    }

Increasing the movementCoefficient will reduce how far back the Camera lags behind a moving Character. If using Glue then you will want to make movementCoefficient a variable in Glue.
