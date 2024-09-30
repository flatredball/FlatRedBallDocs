# IInputReceiver

### Introduction

The IInputReceiver interface provides methods and properties common to all UI elements which can receive input from devices such as the [Keyboard](../../input/keyboard/) or [Xbox360GamePads](../../input/xbox360gamepad/). Any object which implements the IInputReceiver can be assigned to the InputManager's InputReceiver.

Only one instance can be assigned as the InputManager.InputReceiver property. If assigned, this instance has a number of methods called upon being assigned as well as in response to input. Its OnFocusUpdate is also called every frame automatically.

### OnFocusUpdate and FlatRedBall.Forms

FlatRedBall.Forms elements typically receive input in one of two ways:

1. In response to Cursor clicks. These events are ultimately raised by the underlying Gum objects (GraphicalUiElement)
2. In response to changes in a keyboard state or Xbox360GamePad which is polled every-frame.

Forms elements which need to poll input every frame should do so by implementing IInputReceiver and checking input in the OnFocusUpdate.

For example, the following code could be used to perform custom actions whenever the A button is pressed on a Forms control which implements IInputReceiver:

```csharp
public void OnFocusUpdate()
{
    var gamepads = GuiManager.GamePadsForUiControl;
    
    for (int i = 0; i < xboxGamepads.Count; i++)
    {
        var gamepad = xboxGamepads[i];
        if(gamepad.ButtonPushed(Button.A))
        {
            // perform logic here
        }
    }
}
```

For a full example of implementation, see the ListBox implementation:

[https://github.com/vchelaru/FlatRedBall/blob/NetStandard/Engines/Forms/FlatRedBall.Forms/FlatRedBall.Forms.Shared/Controls/ListBox.cs](https://github.com/vchelaru/FlatRedBall/blob/NetStandard/Engines/Forms/FlatRedBall.Forms/FlatRedBall.Forms.Shared/Controls/ListBox.cs)

### Preventing multiple objects from receiving input

The IInputReceiver interface is designed to prevent multiple objects from receiving input. The most common way to do this is to have the IInputReceiver process input in its ReceiveInput method, then clear the input. For example, the following code can be used to move an object and clear the input.

```csharp
// This assumes that the code exists in an object (such as a FlatRedBall Entity)
// which implements IInputReceiver
public void ReceiveInput()
{
   // First let's process the input:
   // This assumes that MovementSpeed is a valid variable - like a variable defined on an Entity in Glue
   Keyboard keyboard = InputManager.Keyboard;
   if(keyboard.KeyDown(Keys.Left))
   {
       this.XVelocity = -MovementSpeed;
   }
   else if(keyboard.KeyDown(Keys.Right))
   {
       this.XVelocity = MovementSpeed;
   }
   else
   {
       this.XVelocity = 0;
   }
   // Prevents anything else from getting keyboard input this frame
   keyboard.Clear();
}
```

This method is especially effective because ReceiveInput is called prior to the game's activity. For more information, see [the ReceiveInput page](../../../../frb/docs/index.php).

### TakingInput

IInputReceivers automatically receive input from the keyboard when they have focus. To prevent this from occurring the TakingInput property can be set to false:

```csharp
// assuming the receiver is a valid receiver
receiver.TakingInput = false; // Will not be able to take input from the keyboard
```
