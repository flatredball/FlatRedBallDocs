# 02-adding-camera-code

### Introduction

The previous tutorial created a Screen which holds our world map Sprite. This tutorial will be all code. We'll be modifying the Camera to make it look like we are "falling" into the world map.

### Changing the Camera to 3D

As mentioned before, we will be changing the Camera to 3D in code. The real ActRaiser game would be played with a 2D camera, and only switch to 3D for this one screen. To make the Camera 3D:

1. Open the project in Visual Studio
2. Open the **Mode7Screen.cs** file
3. Change CustomInitialize so that it sets the Camera as a 3D camera:

&#x20;

```
void CustomInitialize()
{
    Camera.Main.Orthogonal = false;

    // This is roughly the starting distance which mimics the real game
    Camera.Main.Z = 750;
}
```

The first line tells the camera to use a 3D projection. By default the camera has **Orthogonal=true** which means it is using a 2D camera. A 3D camera will be necessary so that the ground Sprite will appear larger as the camera gets closer. The starting Z value can be thought of as the **altitude** that the camera starts at. A larger value results in the camera starting higher up. This value of 750 results in the map appearing at a similar height to the real ActRaiser game. This was obtained through iterative changes while comparing the view to the YouTube video in the previous tutorial. The camera will begin at roughly the right height, just like the real game.

![](../../../../media/2021-04-img\_606cf9b6eaddc.png)

### Adding the Falling Logic

Next we'll add code to make the Camera fall. In the real game, the falling doesn't begin immediately. Instead, the screen fades in from black, then the falling begins after the fading in finishes. Therefore, we don't want to have the logic for falling begin immediately. Instead, we'll use the **Call.After** syntax to make the animation happen a little bit later. But first, let's create the function which modifies the Camera behavior.

```
private static void BeginCameraFalling()
{
    var secondsPerRotation = 5.0f;
    var fallingSeconds = 8.0f;

    Camera.Main.Z = 750;
    Camera.Main.RotationZ = 0;
    Camera.Main.ZVelocity = -(Camera.Main.Z / fallingSeconds);
    Camera.Main.RotationZVelocity = MathHelper.TwoPi / secondsPerRotation;
}
```

We can adjust the two values at the beginning to change the rotation speed of the camera, or to change how fast it falls to the ground. These values roughly create the feel of the game. Notice that this function also resets the Camera's Z position to 750 so that we can reset it and test the falling multiple times without restarting the game. Finally, we'll modify the **CustomActivity** method to allow us to start the falling behavior, and to change the camera's Up vector.

```
void CustomActivity(bool firstTimeCalled)
{
    Camera.Main.UpVector = Camera.Main.RotationMatrix.Up;
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        BeginCameraFalling();
    }
}
```

The line which assigns the UpVector is necessary to allow the main Camera to rotate on its Z axis. By default, FlatRedBall Cameras cannot rotate on Z unless this line of code is added. The remainder of the function allows us to start and restart the falling movement. We can now run the game and press the space bar to begin falling. [![](../../../../media/2021-03-2021\_April\_06\_182918.gif)](../../../../media/2021-03-2021\_April\_06\_182918.gif)

### Conclusion

This already looks fairly close to the real game. The next tutorial will add fading in/out to the screen and a little bit of cleanup to make this screen easier to integrate with other screens. &#x20;
