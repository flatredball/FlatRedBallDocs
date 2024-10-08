# Segment

### Introduction

A segment is a object defined by two [Points](../../../../../frb/docs/index.php). It is not a [PositionedObject](../../../../../frb/docs/index.php) and its points are absolute, which differentiates it from the [Line](../../../../../frb/docs/index.php) class.

### Segment Intersection

The following code creates two [Lines](../../../../../frb/docs/index.php). One line rotates automatically while the other is controlled by input from the [Keyboard](../../../../../frb/docs/index.php). The two [Lines](../../../../../frb/docs/index.php) call the AsSegment method to create Segments that represent the calling [Lines](../../../../../frb/docs/index.php). The segment can then be used to find the point of collision between the two [Lines](../../../../../frb/docs/index.php). If the resulting intersection point has valid coordinates then a collision has occurred. A red ball [Sprite](../../../../../frb/docs/index.php) marks the intersection point between the two [Lines](../../../../../frb/docs/index.php).

Add the following using statements:

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Input;
```

Add the following at class scope:

```
Line firstLine;
Line secondLine;
Sprite sprite;
```

Add the following in Initialize after initializing FlatRedBall:

```
firstLine = ShapeManager.AddLine();
firstLine.RelativePoint1 = new Point3D(-5, 0);
firstLine.RelativePoint2 = new Point3D(5, 0);
firstLine.RotationZVelocity = 1;

secondLine = ShapeManager.AddLine();
secondLine.RelativePoint1 = new Point3D(-3, 0);
secondLine.RelativePoint2 = new Point3D(3, 0);

sprite = SpriteManager.AddSprite("redball.bmp");
sprite.ScaleX = sprite.ScaleY = .5f;
```

Add the following in Update:

```
InputManager.Keyboard.ControlPositionedObject(secondLine);

// To get the collision points, use Segments
Segment firstSegment = firstLine.AsSegment();
Segment secondSegment = secondLine.AsSegment();

// Qualify Point since there is a Microsoft.Xna.Framework.Point
FlatRedBall.Math.Geometry.Point intersectionPoint;

firstSegment.IntersectionPoint(ref secondSegment, out intersectionPoint);

if (double.IsNaN(intersectionPoint.X))
{
    sprite.Visible = false;
}
else
{
    sprite.Visible = true;
    sprite.X = (float)intersectionPoint.X;
    sprite.Y = (float)intersectionPoint.Y;
}
```

![Intersection.png](../../../../../.gitbook/assets/migrated\_media-Intersection.png)

### Segment Members

* [FlatRedBall.Math.Geometry.Segment.ClosestPointTo](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
