# InputReceiver

### Introduction

The InputReceiver property can be assigned to set the current [IInputReceiver](../../gui/iinputreceiver/). The current IInputReceiver can receive keyboard input and has an ever-frame method raised for processing input. This property can be used to prevent multiple objects from receiving keyboard input. This is useful if multiple game objects respond to keyboard input - such as a a text box and a character in a platformer.

For a detailed discussion of using the InputReceiver property, see the [IInputReceiver](../../gui/iinputreceiver/) page.

### Setting InputReceiver

The InputReceiver can be assigned through custom code. For example, the following might be an event executed when a button is clicked:

```csharp
// assuming that "this" is the container of the click event, and that it implements the IInputReceiver interface:
FlatRedBall.Input.InputManager.InputReceiver = this;
```

### Checking InputReceiver

The InputReciever property can be checked to see if any control is receiving input. For example, the following code runs hotkey activity if there is no InputReceiver:

```csharp
if(FlatRedBall.Input.InputManager.InputReceiver == null)
{
    DoYourHotkeyImplementationHere();
}
```
