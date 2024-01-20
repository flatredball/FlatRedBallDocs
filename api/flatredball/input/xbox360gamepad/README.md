# Xbox360GamePad

### Introduction

The Xbox360GamePad class represents the current state of a physical game pad. The Xbox360GamePad can provide information about its buttons and DPad with ButtonPushed, ButtonDown, and ButtonReleased methods. You can also get information about the analog sticks using the [AnalogSticks](../analogstick/) references. Information about the trigger buttons can be accessed through the [AnalogButton](../analogbutton.md) references. The [InputManager](../inputmanager/) exposes an array of Xbox360GamePads. There are always 4 elements in this array regardless of the number of game pads connected.

### Xbox360GamePad and Gamepad Hardware

The name Xbox360GamePad exists for historical reasons - XNA originally only exposed support for Xbox36 controllers. Modern versions of FlatRedBall provide support for a variety of hardware including:

* Xbox360 and Xbox One controllers
* Switch Pro controllers
* USB Gamecube controllers
* Playstation DualShock
* General PC controllers

### Detecting Button Presses

The Xbox360GamePad class reports whether a button was pushed the last frame, is currently down, or was released. The following code moves a [Sprite](../../sprite/) to the right one unit when the A button is pressed and moves a [Sprite](../../sprite/) to the left when the B button is released:

```csharp
// Assuming mySprite is a valid Sprite
Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
if(gamePad.ButtonPushed(Xbox360GamePad.Button.A))
{
   mySprite.X += 32;
}
if(gamePad.ButtonReleased(Xbox360GamePad.Button.B))
{
   mySprite.X -= 32;
}
```

### Detecting Connected Gamepads

The following code reports the number of game pads connected at a given time:

```csharp
 int numberConnected = 0;

 for(int i = 0; i < InputManager.Xbox360GamePads.Length; i++)
 {
     if(InputManager.Xbox360GamePads[i].IsConnected)
         numberConnected++;
 }
```

### Using the Analog Sticks

The Xbox360GamePad provides two analog sticks:

* LeftStick
* RightStick

Each property provides information about the matching hardware analog stick. For more information on using the analog stick property, see the [AnalogStick](../../../../documentation/api/flatredball/input/analogstick.md) page.

### Using a Keyboard as a Game Pad

See the [ButtonMap property](buttonmap.md).

### Vibrations

The following code sets the vibration on the game pad:

```csharp
 // Values should fall between 0.0f and 1.0f
 float leftMotor = .2f; // the low-frequency motor
 float rightMotor = .2f; // the high-frequency motor

 InputManager.Xbox360GamePads[0].SetVibration(leftMotor, rightMotor);
```

### Frequency of Updates

The Xbox360GamePads which are part of the [InputManager](../inputmanager/) are automatically updated every frame by the engine. This information is not buffered, therefore very rapid button presses may not be ready by the controller.

### Platform Support

The Xbox360GamePad name orignally comes from the fact that XNA supported Xbox 360 controllers. Despite its name, the Xbo360GamePad class can be used on most FlatRedBall platforms. As of the time of this writing, the following platforms and hardware are supported.

* Desktop GL: Xbox 360 controllers, Xbox One controllers, Switch Pro controllers, USB Gamecube controllers, PlayStation DualShock, Generic PC controllers
* Desktop XNA: Xbox 360 controllers, Xbox One controllers
* Android: Bluetooth and wired controllers
* iOS: Untested

###
