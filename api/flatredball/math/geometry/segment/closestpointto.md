# ClosestPointTo

### Introduction

The ClosestPointTo returns the closest point on the calling Segment to the argument position. The closest point may be anywhere on the segment including the endpoints.

### Code Example

The following creates a Segment and a [Line](../../../../../frb/docs/index.php) as a visible representation of the Segment. The update method finds the closest point on the Segment to the [Mouse](../../../../../frb/docs/index.php) and positions a [Sprite](../../../../../frb/docs/index.php) there.

Add the following using statements:

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Input;
```

Add the following at class scope:

```
Sprite sprite;
Segment segment;
```

Add the following to Initialize after initializing FlatRedBall:

```
sprite = SpriteManager.AddSprite("redball.bmp");

segment = new Segment(
    -20, // first point X
    -8,  // first point Y
    20,  // second point X
    8);  // second point Y

// Let's make a visible representation of the segment
Line line = ShapeManager.AddLine();
line.RelativePoint1 = new Point3D(
    segment.Point1.X,
    segment.Point1.Y);
line.RelativePoint2 = new Point3D(
    segment.Point2.X,
    segment.Point2.Y);
```

Add the following to Update:

```
FlatRedBall.Math.Geometry.Point cursorPoint =
    new FlatRedBall.Math.Geometry.Point(
        InputManager.Mouse.WorldXAt(0),
        InputManager.Mouse.WorldYAt(0));

FlatRedBall.Math.Geometry.Point closestPoint =
    segment.ClosestPointTo(cursorPoint);

sprite.Position.X = (float)closestPoint.X;
sprite.Position.Y = (float)closestPoint.Y;
```

![ClosestPoint.png](../../../../../.gitbook/assets/migrated\_media-ClosestPoint.png)
