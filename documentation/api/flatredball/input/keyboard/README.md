## Introduction

The Keyboard class provides functionality for getting input data from the physical keyboard. This class is automatically instantiated by and accessible through the [InputManager](/frb/docs/index.php?title=FlatRedBall.Input.InputManager "FlatRedBall.Input.InputManager"). The Keyboard class is accessible both on a PC as well as on the Xbox 360.

## Detecting Keyboard Activity

There are many ways to get data from the keyboard. The following section of code is a series of if-statements which could be used to detect input from the keyboard. **Add the following using statements:**

    using FlatRedBall.Input;
    using Microsoft.Xna.Framework.Input; // for the Keys enum

**In your CustomActivity method:**

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
   if(InputManager.Keyboard.KeyPushed(Keys.A))
   {
       // The A key was just pushed - down this frame, up last frame.
   }

   if(InputManager.Keyboard.KeyDown(Keys.B))
   {
      // The B key is down this frame.
   }

   if(InputManager.Keyboard.KeyReleased(Keys.C))
   {
      // The C key was just released - down last frame, up this frame.
   }

   if(InputManager.Keyboard.KeyTyped(Keys.D))
   {
      // The D key was just typed - either Pushed this frame or typed
      // again because the key was held down.
   }
}
```

## Controlling Objects With the Keyboard

The Keyboard is commonly used to control objects like in-game characters and the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"). The following code can be used to quickly control any [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") **Add the following using statement:**

    using FlatRedBall.Input;

**Assuming positionedObject is a valid [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") (or object inheriting from the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") class like a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") or [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera")) add the following code in Update:**

    float velocityToApply = 10;
    InputManager.Keyboard.ControlPositionedObject(positionedObject, velocityToApply);

For more control over input controlling movement, see the following entry on [controlling the camera with the keyboard](/frb/docs/index.php?title=FlatRedBall.Camera#Controlling_the_Camera "FlatRedBall.Camera").

## 

## 
