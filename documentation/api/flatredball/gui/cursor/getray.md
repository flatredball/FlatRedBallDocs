## Introduction

The GetRay method can be used to get a Ray representing objects which the Cursor is over. This Ray can be used for complex object picking, and will work even when the Camera is rotated, unlike the [WorldXAt](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.WorldXAt "FlatRedBall.Gui.Cursor.WorldXAt") and [WorldYAt](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.WorldXAt "FlatRedBall.Gui.Cursor.WorldXAt") methods.

## Code Example

The following code shows how the GetRay function can be used to get a Ray representing the Cursor's current position and direction of the camera. The following code is implemented in the CustomInitialize and CustomActivity of an otherwise empty screen.

    void CustomInitialize()
    {
        // Add a circle for reference:
        Circle circle = ShapeManager.AddCircle();
        circle.Radius = 64;

        // so we can see the cursor:
        FlatRedBallServices.Game.IsMouseVisible = true;
    }

    void CustomActivity(bool firstTimeCalled)
    {
        var ray = GuiManager.Cursor.GetRay();

        FlatRedBall.Debugging.Debugger.Write(
            "Ray Position: " + ray.Position + "\n" +
            "Ray Direction: " + ray.Direction);

        // let's move the camera around too to make sure this works:
        const float velocity = 50;
        InputManager.Keyboard.ControlPositionedObject(Camera.Main, velocity);

    }

![GetRay.png](/media/migrated_media-GetRay.png)

## Community Code

[Mouse world coordinates for a rotated Camera by Scott Dancer](/frb/docs/index.php?title=ScottDancer:Mouse_World_Coordinates_for_a_Rotated_Camera "ScottDancer:Mouse World Coordinates for a Rotated Camera")
