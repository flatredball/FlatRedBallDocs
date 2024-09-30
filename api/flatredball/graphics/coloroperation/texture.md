# Texture

### Introduction

The Texture color operation results in an object being drawn with its unmodified texture. Color values (red, green and blue) on the IColorable are completely ignored, unless the object has no texture. The Texture color operation is the default color operation for FlatRedBall types like Sprite and Text.

### Code Example

Texture color operation can be assigned on any IColorable, such as Sprite:

```lang:c#
var sprite = SpriteManager.AddSprite(SpriteTexture);
sprite.ColorOperation = ColorOperation.Texture;
```

![](../../../../.gitbook/assets/2018-07-img\_5b5cb9e76e3c7.png)

### Color Values

As mentioned above, the Red, Green, and Blue values have no impact on an object which uses the Texture color operation.

<figure><img src="../../../../.gitbook/assets/2018-07-2018-07-28_12-47-59.gif" alt=""><figcaption></figcaption></figure>
