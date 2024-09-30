# IgnoreButtonForOneFrame

### Introduction

The IgnoreButtonForOneFrame method can be used if multiple objects are watching for a particular button to be pushed, but the first one that reacts to it should "consume" it so that no other objects get the button push. This method is very convenient because it does not require any additional logic aside from simply calling this method when consuming the button event.

### Code Example

In this example we have some if statements which increment a number according to button pushes. The first check for the A button will call IgnoreButtonForOneFrame on the A button. The first check for the B button will not. The result is that A will increment the call count by 1, while B will increment the call by 2.

Add the following using statement:

```
using FlatRedBall.Input;
```

Add the following at class scope:

```
int mCount = 0;
```

Add the following in Update:

```
Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];

// Do our first checks.  
if (gamePad.ButtonPushed(Xbox360GamePad.Button.A))
{
    mCount++;
    gamePad.IgnoreButtonForOneFrame(Xbox360GamePad.Button.A);
}

if (gamePad.ButtonPushed(Xbox360GamePad.Button.A))
{
    mCount++;
}

if (gamePad.ButtonPushed(Xbox360GamePad.Button.B))
{
    mCount++;
}

if (gamePad.ButtonPushed(Xbox360GamePad.Button.B))
{
    mCount++;
}

FlatRedBall.Debugging.Debugger.Write(mCount);
```

![IgnoreButtonForOneFrame.png](../../../../.gitbook/assets/migrated\_media-IgnoreButtonForOneFrame.png)
