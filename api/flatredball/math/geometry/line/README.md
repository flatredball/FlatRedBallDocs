# Line

### Introduction

A line is defined by two endpoints, so in mathematical terms it is actually a segment. Lines can be used to perform 2D collisions against any other shapes.

### Line Sample

The following sample creates a line, a [Circle](../circle/), and an [AxisAlignedRectangle](../shapecollection/axisalignedrectangles.md). The line is controlled with the keyboard and it changes colors when it collides with the other two shapes. Add the following using statements:

```csharp
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall.Math.Geometry;
```

Add the following at class scope:

```csharp
AxisAlignedRectangle rectangle;
Circle circle;
Line line;
```

Add the following in Initialize after Initializing FlatRedBall:

```csharp
rectangle = ShapeManager.AddAxisAlignedRectangle();
rectangle.X = 50;
rectangle.Color = Color.Red;

circle = ShapeManager.AddCircle();
circle.X = -50;
circle.Color = Color.Blue;

// Creates a horizontal line of length 2 by default.
line = ShapeManager.AddLine();
```

Add the following in Update:

```csharp
InputManager.Keyboard.ControlPositionedObject(line);

if (line.CollideAgainst(rectangle))
{
    line.Color = rectangle.Color;
}
else if (line.CollideAgainst(circle))
{
    line.Color = circle.Color;
}
else
{
    line.Color = Color.White;
}
```

![LineTutorial.png](../../../../../.gitbook/assets/migrated\_media-LineTutorial.png) Note that FlatRedBall expects shape colors to be pre-multiplied. Therefore a half-transparent red value would have a R,G,B,A value of (128,0,0,128).

### RelativePoint Properties

A line can be modified by changing both its [PositionedObject](../../../../../frb/docs/index.php) properties as well as through the RelativePoint property. The following code connects two rectangles with a line. Add the following in Update:

```csharp
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall.Math.Geometry;
```

Add the following in Initialize after Initializing FlatRedBall:

```csharp
AxisAlignedRectangle rectangle1 = ShapeManager.AddAxisAlignedRectangle();
rectangle1.Position = new Vector3(-2, 4, 0);
rectangle1.Color = Color.Green;

AxisAlignedRectangle rectangle2 = ShapeManager.AddAxisAlignedRectangle();
rectangle2.Position = new Vector3(4, -1, 0);
rectangle2.Color = Color.Red;

// The most common way to make a connecting line is to set the line's
// positions at one of the end points, then simply calculate the relative
// position of the other endpoint.  That is, the position of the line does
// not have to be the midpoint.
Line connectingLine = ShapeManager.AddLine();
connectingLine.Position = rectangle1.Position;
connectingLine.RelativePoint1 = new Point3D(0, 0, 0);

// Now just get the position of rectangle2 relative to rectangle1
// and put that in RelativePoint2.
connectingLine.RelativePoint2 = new Point3D(
    rectangle2.X - rectangle1.X,
    rectangle2.Y - rectangle1.Y,
    rectangle2.Z - rectangle1.Z); // will be 0 in our case
```

![ConnectedRectangles.png](../../../../../.gitbook/assets/migrated\_media-ConnectedRectangles.png)

### Line limitations

* Lines, just like any other [Shapes](../../../../../frb/docs/index.php), can either be drawn on top of or below types that can sort with each other, such as [Sprites](../../../../../frb/docs/index.php) and [Texts](../../../../../frb/docs/index.php). They will not sort according to their Z value.
* Lines must be one pixel thick. Thicker lines are not supported.
* Lines can only draw solid colors - patterns and gradients are not supported.
