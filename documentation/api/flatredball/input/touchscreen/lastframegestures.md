## Introduction

The LastFrameGestures is a List of [GestureSamples](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.input.touch.gesturesample.aspx) representing all gestures read last frame. You can use the LastFrameGestures in your code to respond to gesture input. The LastFrameGestures will only be populated every frame if the [ReadsGestures](/frb/docs/index.php?title=FlatRedBall.Input.TouchScreen.ReadsGestures "FlatRedBall.Input.TouchScreen.ReadsGestures") value is true (default is true). For full documentation on how to use GestureSamples, see the [Microsoft page on GestureSamples](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.input.touch.gesturesample.aspx).

## Code Example

The following code shows how to detect all clicks from the TouchScreen:

    foreach(var gesture in InputManager.TouchScreen.LastFrameGestures)
    {
        if(gesture.GestureType == GestureType.Tap)
        {
            // The user tapped the screen
            float worldX;
            float worldY;
       
            MathFunctions.WindowToAbsolute(
                gesture.Position.X,
                gesture.Position.Y,
                ref worldX,
                ref worldY,
                0,  // The z position
                SpriteManager.Camera,
                CoordinateRelativity.RelativeToWorld);

            // Do whatever is needed with world coordinates here
        }
    }
