# HandleTab

### Introduction

HandleTab can be used to tab to the previous or next item which can receive focus. This is a manual way to force tabbing rather than relying on the built-in functionality. For information about how to execute automatic tabbing with gamepads, see the [Forms and Xbox30GamePad tutorial](../../../../tutorials/flatredball-forms/forms-and-xbox360gamepad.md).

### Code Example - Tabbing to the Next Button

If a button has focus, it can pass focus to the next button. The following code shows how to do this using the keyboard:

```csharp
// assume MyButton has focus:
var keyboard = InputManager.Keyboard;
if(keyboard.KeyPushed(Keys.Down) ||
    keyboard.KeyPushed(Keys.W) )
{
    MyButton.HandleTab(TabDirection.Down);
}
if(keyboard.KeyPushed(Keys.Up) ||
    keyboard.KeyPushed(Keys.S))
{
    MyButton.HandleTab(TabDirection.Down);
}
```

If your game has multiple elements which can be focused you can handle tabbing regardless of which element has focus as shown in the following code:

```csharp
var keyboard = InputManager.Keyboard;
if (keyboard.KeyPushed(Keys.Up) ||
    keyboard.KeyPushed(Keys.W) )
{
    (InputManager.InputReceiver as FrameworkElement)?.HandleTab(TabDirection.Up);
}
if (keyboard.KeyPushed(Keys.Down) ||
    keyboard.KeyPushed(Keys.S))
{
    (InputManager.InputReceiver as FrameworkElement)?.HandleTab(TabDirection.Down);
}
```
