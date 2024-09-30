# GetStringTyped

### Introduction

The Keyboard class can be used for text input. Unfortunately, at the time of this writing the keyboard only understands the English keyboard. The GetStringTyped method returns the string that was typed during the last frame. It is possible for multiple keys to be pressed during a frame and the GetStringTyped method also considers whether the Shift key is pressed.

### Code Example

The following code creates a Text object which displays the string typed.

Add the following using statement:

```
using FlatRedBall.Input;
using FlatRedBall.Graphics; // for Text
using Microsoft.Xna.Framework.Input; // for the Keys enum
```

in your Game class scope:

```
Text text;
```

Replace Initialize with the following:

```
protected override void Initialize()
{
    base.Initialize();     

    FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);
    
    text = TextManager.AddText("Text:");
}

// Replace Update with the following:
protected override void Update(GameTime gameTime)
{
    FlatRedBallServices.Update(gameTime);

    text.DisplayText += InputManager.Keyboard.GetStringTyped();

    if (InputManager.Keyboard.KeyPushed(Keys.Enter))
        text.DisplayText = "";

    base.Update(gameTime);
}
```

![FlatRedBallIsTheBestText.png](../../../../.gitbook/assets/migrated\_media-FlatRedBallIsTheBestText.png)

### Copy/Paste

GetStringTyped supports ctrl+c and ctrl+v for copy and paste; however, your game must be set to use \[STAThread]. For more information, see [this page](http://stackoverflow.com/questions/1361033/what-does-stathread-do).
