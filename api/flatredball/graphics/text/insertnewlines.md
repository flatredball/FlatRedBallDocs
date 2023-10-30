# insertnewlines

The InsertNewLines method modifies the Text's DisplayText property by inserting the newline character ('\n') to prevent the text from exceeding the argument maxWidth. The maxWidth property is in absolute world units.

Add the following using statements:

```
using FlatRedBall.Graphics;
using FlatRedBall.Math.Geometry;
```

Add the following to Initialize after initializing FlatRedBall:

```
AxisAlignedRectangle axisAlignedRectangle =
    ShapeManager.AddAxisAlignedRectangle();
axisAlignedRectangle.ScaleX = 5;
axisAlignedRectangle.ScaleY = 5;

Text text = TextManager.AddText(
    "Hello.  I am a Text object.  My DisplayText is pretty long.  It's likely " +
    "that FlatRedBall users will want to wrap this text.  Fortunately, there's a " +
    "way to do this that's fairly easy with the InsertNewLines method." +
    "I'll fit inside an AxisAlignedRectangle to show how nice I word wrap.");
text.X = axisAlignedRectangle.Left;

float maxWidth = axisAlignedRectangle.ScaleX * 2;
text.InsertNewLines(maxWidth);
```

![InsertNewLines.png](../../../../../media/migrated_media-InsertNewLines.png)

### Additional Information

* [FlatRedBall.Graphics.BitmapFont](../../../../../frb/docs/index.php) - See the BitmapFont class for determining the unit-size of your text.
