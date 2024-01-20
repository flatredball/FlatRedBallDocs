# ButtonDown

### Introduction

The ButtonDown method returns whether a button is currently being held down. This will be false if the player is not pushing the button, and it will return true every frame that the button is pressed.

### Code Example - Checking Buttons

The following code shows how to perform logic if the player is holding the A or B buttons on the Xbox360GamePad:

Add the following using statements:

```csharp
using FlatRedBall.Input;
```

Later, perform the checks:

```csharp
 if (InputManager.Xbox360GamePads[0].ButtonDown(Button.A))
 {
     // do something when the A button is down
 }
 if (InputManager.Xbox360GamePads[0].ButtonDown(Button.B))
 {
     // do something when the B button is down
 }
```

### Code Example - Checking DPad

The DPad on the Xbox360GamePad acts as four separate buttons. Therefore, each direction can be independently checked just like buttons. For example, the following code moves a character according to the left and right DPad.

```csharp
var gamePad = InputManager.Xbox360GamePads[0];
if(gamePad.ButtonDown(Xbox360GamePad.Button.DPadRight))
{
    PlayerInstance.XVelocity = 100;
}
else if(gamePad.ButtonDown(Xbox360GamePad.Button.DPadLeft))
{
    PlayerInstance.XVelocity = -100;
}
else
{
    PlayerInstance.XVelocity = 0;
}
```

### Code Example - Checking All Buttons

Buttons are represented by enumerations which can be looped through to check. The first enumeration value is 0, and the last value in the enumeration is Button.LeftStickAsDPadRight. Therefore, the following loop will check all buttons:

```csharp
for(int i = 0; i < (int)Xbox360GamePad.Button.LeftStickAsDPadRight + 1; i++)
{
  if(gamePad.ButtonDown( (Xbox360GamePad.Button)i))
  {
    // This button is down, do something
  }
}
```
