# mouse

### Introduction

The Mouse class provides functionality for getting input data from the physical mouse. This class is automatically instantiated by and accessible through the [InputManager](../../../../../frb/docs/index.php). The Mouse class is not available on the Xbox360 if using FlatRedBall XNA.

### Detecting Mouse Activity

There are many ways to get data from the mouse. The following section of code is a series of if-statements which could be used to detect input from the mouse.

```
if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.LeftButton))
{
    // Left mouse button pushed - down this frame, not down last frame.
}
if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.MiddleButton))
{
    // Middle mouse button released - not down this frame, down last frame.
    // This is the same as a click.
}
if (InputManager.Mouse.ButtonDown(Mouse.MouseButtons.RightButton))
{
    // Right mouse button down this frame;
}
if (InputManager.Mouse.ButtonDoubleClicked(Mouse.MouseButtons.LeftButton))
{
    // Left button double-clicked.
}
```

#### Mouse Scroll Wheel

The mouse scroll wheel is exposed through the InputManager.Mouse.ScrollWheel property. The ScrollWheel property returns the number of "clicks" that the scroll wheel has moved since last frame. The following code controls the Z position of the camera based on the ScrollWheel property.

```
SpriteManager.Camera.Z -= InputManager.Mouse.ScrollWheel;
```

### Cursor Visibility

See [the showing cursor wiki entry](../../../../../frb/docs/index.php#Showing_Cursor).

### Mouse Pixel Coordinates

The Mouse class provides information about the cursor's pixel coordinates.

```
int pixelXCoordinate = InputManager.Mouse.X;
int pixelYCoordinate = InputManager.Mouse.Y;
```

The mouse coordinates are top left justified, so (0,0) represents the top left corner of the screen. Keep in mind that the pixel coordinates are relative to the top-left of the screen, but not bound by your game screen. That means that if the cursor is to the left (outside of) your game screen, then the X value will be negative. Also, the mouse will continue to return values when the cursor is to the right or below the game screen, resulting in values which are potentially larger than the width or height of the screen.

### Mouse World Coordinates

The Mouse reports the world coordinates of the cursor through the functions WorldXAt and WorldYAt.

```
float zPosition = 0; // or whatever other value, but 0 is the most common

float xWorldPosition = InputManager.Mouse.WorldXAt(zPosition);
float yWorldPosition = InputManager.Mouse.WorldYAt(zPosition);
```

For a more detailed example see [this entry](../../../../../frb/docs/index.php#Creating_Attachments) on moving a [Sprite](../../../../../frb/docs/index.php) by positioning it to the cursor's coordinates.

### Detecting Mouse in Window

Certain activities should only occur if the mouse is in the window. To test for this, use the following code: Add the following using statement:

```
using FlatRedBall.Input;
```

The following code performs the check:

```
if(InputManager.Mouse.IsInGameWindow())
{
   // perform activity
}
```

### Member List

* [FlatRedBall.Input.Mouse.GrabbedPositionedObject](../../../../../frb/docs/index.php)
* [FlatRedBall.Input.Mouse.IsOn3D](../../../../../frb/docs/index.php)
* [FlatRedBall.Input.Mouse.ModifyMouseState](../../../../../frb/docs/index.php)
* [FlatRedBall.Input.Mouse.SetScreenPosition](../../../../../frb/docs/index.php)
* [FlatRedBall.Input.Mouse.WorldXAt](../../../../../frb/docs/index.php)
* [FlatRedBall.Input.Mouse.WorldYAt](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
