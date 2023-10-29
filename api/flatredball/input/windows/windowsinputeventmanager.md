# windowsinputeventmanager

### Introduction

The WindowsInputEventManager is a class which can be used to read character-based input from the keyboard (as opposed to key-based input, as provided by the [FlatRedBall Keyboard class](../../../../documentation/api/flatredball/input/keyboard.md)). Character based input (where character refers to the char  type) is useful for games which need to read string input from the keyboard. For example, games may need input for entering a player's name.

### WindowsInputEventManager is Platform-Specific

The WindowsInputEventManager class is currently only available in the FlatRedBall XNA PC projects. Eventually other platforms will have their own platform-specific classes.

### Code Example

Once added, the WindowsInputEventManager  can be accessed in any class because it is static . In this example the code to handle input events exists in a Glue screen.

```lang:c#
void CustomInitialize()
{
    WindowsInputEventManager.Initialize(FlatRedBallServices.Game.Window);
    WindowsInputEventManager.CharEntered += HandleCharEntered;
    WindowsInputEventManager.KeyDown += HandleKeyDown;
}

private void HandleKeyDown(object sender, KeyEventArgs e)
{
    // Handle characters entered, like backspace or arrow keys...
}

private void HandleCharEntered(object sender, CharacterEventArgs e)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(e.Character);
}

void CustomActivity(bool firstTimeCalled)
{
}

void CustomDestroy()
{
    WindowsInputEventManager.CharEntered -= HandleCharEntered;
    WindowsInputEventManager.KeyDown -= HandleKeyDown;
}

static void CustomLoadStaticContent(string contentManagerName)
{
}
```

![](../../../../media/2017-09-img\_59b58514dd33d.png)

Notice that CustomDestroy  unsubscribes from the events subscribed to in CustomInitialize .
