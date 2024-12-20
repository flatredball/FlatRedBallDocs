# ColorTextureAlpha

### Introduction

The ColorTextureAlpha color operation can be used to make an object apply a solid color to all opaque pixels, yet retain its transparency. This can be used to create silhouettes or objects which flash, such as enemies taking damage.

### Code Example - Flashing on Key Press

The following code flashes a Sprite white when the Space key is pressed:

```csharp
if(keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
{
    SpriteInstance.ColorOperation = 
        FlatRedBall.Graphics.ColorOperation.ColorTextureAlpha;
    SpriteInstance.Red = 1;
    SpriteInstance.Green = 1;
    SpriteInstance.Blue = 1;
}
else
{
    SpriteInstance.ColorOperation =
        FlatRedBall.Graphics.ColorOperation.Texture;
}
```

<figure><img src="../../../../.gitbook/assets/20_15 25 13.gif" alt=""><figcaption><p>Setting ColorTextureAlpha to flash a sprite white</p></figcaption></figure>
