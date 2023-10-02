# alpha

### Introduction

The Alpha property represents the transparency (or opacity) of a given object. The default value is 1 (full opacity), and setting the value to 0 will make the object fully transparent.

**For FRB MDX users:** Color and alpha values range from 0 to 255 in FlatRedBall MDX.

### Code Example

The following code shows how to use the Alpha property on [Text](../../../../../frb/docs/index.php) objects to control their transparency.

```
int count = 20;
for (int i = 0; i < count; i++)
{
    float maxAlpha = 1.0f;

    float alphaValue = (i + 1) * maxAlpha / count;

    FlatRedBall.Graphics.Text text =
        FlatRedBall.Graphics.TextManager.AddText("Alpha: " + alphaValue);
    text.Alpha = alphaValue;

    text.Y = -100 + i * 15;
}
```

![TextAlpha.PNG](../../../../../media/migrated\_media-TextAlpha.PNG)
