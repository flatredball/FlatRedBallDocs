# Add

### Introduction

The Add color operation allows the addition of the Color (Red, Green, Blue) values to the texture drawn by an object. This can be used to "lighten", or simulate light shining on an object.

<figure><img src="../../../../.gitbook/assets/30_08 11 29.gif" alt=""><figcaption><p>Add color operations </p></figcaption></figure>

### Code Usage

The following code can be used to set a Sprite's color operation to Add when the space bar is pressed.

```csharp
private void CustomActivity()
{
    var keyboard = InputManager.Keyboard;
    if(keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        SpriteInstance.ColorOperation = FlatRedBall.Graphics.ColorOperation.Add;
        SpriteInstance.Red = 1;
        SpriteInstance.Green = 1;
        SpriteInstance.Blue = 1;
    }
    else
    {
        // reset the defaults:
        SpriteInstance.ColorOperation = FlatRedBall.Graphics.ColorOperation.Texture;
        SpriteInstance.Red = 0;
        SpriteInstance.Green = 0;
        SpriteInstance.Blue = 0;
    }
}
```
