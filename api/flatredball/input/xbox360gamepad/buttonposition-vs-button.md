# ButtonPosition vs Button

### Introduction

ButtonPosition can be used to reference a button based in its physical position rather than by letter. Referencing a button by position can be useful if players are playing your game with gamepads which do not necessarily position their buttons identically.

For example, consider the A, B, X, and Y button positions on the Xbox and Switch controllers.

<figure><img src="../../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Switch vs Xbox Button Position</p></figcaption></figure>

You may want your game to use the button positions rather than specific button letters when assigning input to your player.

<figure><img src="../../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Buttons face positions</p></figcaption></figure>

### Code Example - Getting Button by ButtonPosition

Entities typically use [IPressableInput](../ipressableinput.md) instances to control actions like jumping. Rather than inspecting the gamepad type, games cna use the ButtonPosition to assign input. For example, the following code might be used to assign the JumpInput:

```csharp
// The following code assumes JumpInput is a property of type IpressableInput:
this.JumpInput = gamepad.GetButton(ButtonPosition.FaceDown);
```
