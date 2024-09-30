# ScaleX

### Introduction

The ScaleX and ScaleY properties are read-only properties in the Text class. You may be familiar with these properties through classes such as [Sprite](../../../../frb/docs/index.php) or [AxisAlignedRectangle](../../../../frb/docs/index.php). Unlike those classes, the Text class's ScaleX and ScaleY properties are only used to read the dimensions of the Text object, not to set it. To set the size of your Text, you need to use the Scale, Spacing, and NewlineDistance properties. You can find out more about them [here](../../../../frb/docs/index.php#Text\_Size).

### Scale and Position

If you've read about the [IScalable](../../../../frb/docs/index.php) interface, then you're likely familiar with the concept of Scale. To help you remember, Scale is the measure from the center of an object to its edge. Another way to put it is ScaleX is half of an object's width and ScaleY is half of an object's height. In most cases, the center of an object is the same as its Position. Therefore, adding or subtracting Scale from an object's position will give you its edges. This is not the case with Text objects because of the [HorizontalAlignment](../../../../frb/docs/index.php) and [VerticalAlignment](../../../../frb/docs/index.php) properties. Therefore, to find the center of your Text object, you should use the [HorizontalCenter](../../../../frb/docs/index.php) and [VerticalCenter](../../../../frb/docs/index.php) properties.

### Code example

The following code creates two Text objects. It then creates two [AxisAlignedRectangles](../../../../frb/docs/index.php) which show the bounds of the Text object using ScaleX/ScaleY and HorizontalCenter/VerticalCenter properties. Add the following include statements:

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Graphics;
```

Add the following to the Initialize method after initializing FlatRedBallServices:

```
 Text text1 = TextManager.AddText("Short text");

 Text text2 = TextManager.AddText("Some longer text");
 text2.Y = -4;

 // Now create the AxisAlignedRectangles using the scale and position of the
 // texts we just created:
 AxisAlignedRectangle aaRect1 = ShapeManager.AddAxisAlignedRectangle();
 aaRect1.X = text1.HorizontalCenter;
 aaRect1.Y = text1.VerticalCenter;
 aaRect1.ScaleX = text1.ScaleX;
 aaRect1.ScaleY = text1.ScaleY;

 AxisAlignedRectangle aaRect2 = ShapeManager.AddAxisAlignedRectangle();
 aaRect2.X = text2.HorizontalCenter;
 aaRect2.Y = text2.VerticalCenter;
 aaRect2.ScaleX = text2.ScaleX;
 aaRect2.ScaleY = text2.ScaleY;
```

![TextScaleAndCenter.png](../../../../.gitbook/assets/migrated\_media-TextScaleAndCenter.png)
