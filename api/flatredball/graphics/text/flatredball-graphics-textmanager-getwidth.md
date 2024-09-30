# GetWidth

### Introduction

The GetWidth method returns the width of a piece of text. The GetWidth method returns the width of text, and can accept a variety of arguments. The overloads provide flexibility depending on how much information is needed.

### Overloads

```
public static float GetWidth(string text)

public static float GetWidth(string text, float spacing)

public static float GetWidth(string text, float spacing, BitmapFont font)

public static float GetWidth(string text, float spacing, BitmapFont font, int startIndex, int count)

public static float GetWidth(string text, float spacing, BitmapFont font, int startIndex, int count, List<float> widthList)

public static float GetWidth(Text text)
```

### Code Example

The following code creates a Text object and a Line which can be moved between letters with the left and right arrows on the keyboard:

Add the following using statements:

```
using FlatRedBall.Graphics;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Input;
```

Add the following to your Game or Screen's class scope:

```
Text mText;
int mIndex = 0;
Line mLine;
```

Add the following to your Game's Initialize or Screen's CustomInitialize:

```
mText = TextManager.AddText("Hello I am a string");
mLine = ShapeManager.AddLine();
mLine.SetFromAbsoluteEndpoints(
    new Vector3(0, 1, 0),
    new Vector3(0, -1, 0));
```

Add the following to your Game's Update or Screen's CustomActivity:

```
if (InputManager.Keyboard.KeyPushed(Keys.Right))
{
    mIndex++;
    if (mIndex > mText.DisplayText.Length)
    {
        mIndex--;
    }
    UpdateToIndex();
}
if (InputManager.Keyboard.KeyPushed(Keys.Left))
{
    mIndex--;
    if (mIndex < 0)
    {
        mIndex = 0;
    }
    UpdateToIndex();
}
```

Add the following function at class scope:

```
private void UpdateToIndex()
{
    float position = TextManager.GetWidth(
        mText.DisplayText, mText.Spacing, mText.Font, 0, mIndex);

    mLine.X = mText.X + position;
}
```

![TextManagerGetWidth.PNG](../../../../.gitbook/assets/migrated\_media-TextManagerGetWidth.PNG)
