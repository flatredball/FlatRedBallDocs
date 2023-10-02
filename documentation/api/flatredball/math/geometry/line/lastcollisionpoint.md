# lastcollisionpoint

[FlatRedBall.Math.Geometry.Line](../../../../../../frb/docs/index.php)

### Introduction

The LastCollisionPoint is a property which can tell you the last location where collision occurred. This can be used if you would like to play effects or perform custom physics where collision has occurred.

### Code Example

The following example creates two Lines and calls CollideAgainst between them. It then uses the LastCollisionPoint (if it is valid) to position a circle. One of the lines (Line1) can be controlled with the keyboard, resulting in a changing LastColliisionPoint.

This example is structured for Glue, but can be duplicated in a code-only FlatRedBall project:

Add the following to class scope in a Screen:

```
Circle circle;
Line line1;
Line line2;
```

Add the following to CustomInitialize in a Screen:

```
void CustomInitialize()
{
    circle = ShapeManager.AddCircle();
    circle.Radius = 10;

    line1 = ShapeManager.AddLine();

    line2 = ShapeManager.AddLine();
    line2.RelativePoint2 = new Point3D(100, 100);
}
```

Add the following to CustomActivity in a Screen:

```
void CustomActivity(bool firstTimeCalled)
{
    InputManager.Keyboard.ControlPositionedObject(line1, 100);

    line1.CollideAgainst(line2);

    // If no collision occurred, then LastCollisionPoint's X and Y values will be NaN:
    if (!double.IsNaN(line1.LastCollisionPoint.X) &&
        !double.IsNaN(line1.LastCollisionPoint.Y))
    {
        circle.X = (float)line1.LastCollisionPoint.X;
        circle.Y = (float)line1.LastCollisionPoint.Y;
    }
}
```

![LineLastCollisionPoint.PNG](../../../../../../media/migrated\_media-LineLastCollisionPoint.PNG)
