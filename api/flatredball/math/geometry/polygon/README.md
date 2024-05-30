# Polygon

### Introduction

The Polygon class is used to define collidable shapes. Polygons can contain any number of points and can be either convex or concave. Polygons can be drawn to the screen by adding them to the ShapeManager or by setting their Visible property to true.

Polygons are typically used for objects which need complex collision. Polygons can collide with other Polygons as well as other FlatRedBall shapes such as Circle and AxisAlignedRectangle.

Polygon collision is significantly slower than Circle and Rectangle collision, so if your game can use simpler shapes those are recommended for performance reasons.

The Polygon class sits is in the FlatRedBall.Math.Geometry namespace, so adding

```csharp
using FlatRedBall.Math.Geometry;
```

can simplify your code. Also, Polygons use the FlatRedBall.Math.Geometry.Point struct, so the following code can help solve ambiguities:

```csharp
using Point = FlatRedBall.Math.Geometry.Point;
```

### Example: Creating a Rectangle Polygon in Code

The Polygon class provides the CreateRectangle shortcut methods for creating rectangular Polygons:

```csharp
// Parameters are "ScaleX" and "ScaleY" which is the distance from 
// center to edge. Therefore, to make a 32x32 rectangle, we'd use 
// 16 for each dimension:
Polygon rectangle = Polygon.CreateRectangle(32/2, 32/2);
// To have the Polygon drawn and managed, add it to the ShapeManager
ShapeManager.AddPolygon(rectangle);
```

You can also assign the Points object. **For more information, see the** [**Points page**](points.md)**.**

### Example: Creating a Polygon From Points in Code

Polygons can be constructed by assigning the points. Note that points are relative to the center of a polygon, not in absolute coordinates.

```csharp
var polygon = new Polygon();
var points = new List<FlatRedBall.Math.Geometry.Point>
{
    new Point(100, 100),
    new Point(50, -20),
    new Point(-50, -20),
    new Point(-100, 100),
    // repeat the last point to close the shape
    new Point(100, 100)
};

polygon.Points = points;

ShapeManager.AddPolygon(polygon);
```

![Polygon created in code by assigning individual Points](../../../../../media/2017-06-img\_593f455263322.png)

### Clockwise Points

Polygons support points in any order, but adding points clockwise is recommended for performance reasons. Internally, FlatRedBall is able to perform faster collision checks between polygons if both have points added clockwise.

The example above adds points clockwise. We can see this by overlaying the polygon's origin and drawing the order in which points have been added as shown in the following image:



<figure><img src="../../../../../.gitbook/assets/image (123).png" alt=""><figcaption><p>Polygon point order and origin displayed</p></figcaption></figure>

Polygons provide an IsClockwise method which checks if the points are in clockwise order, as shown in the following code:

```csharp
var isClockwise = polygon.IsClockwise();
if(!isClockwise)
{
  // Points are in counterclockwise order, which can affect performance
  // We can make this clockwise by inverting the point order:
  polygon.InvertPointOrder();
}
```

### Polygon Collision

The Polygon class provides collision methods and properties to simplify common game programming tasks. The following code creates two Polygons which turn red when they collide. Note that this uses input code. For information on using FlatRedBall input, see [FlatRedBall.Input.InputManager](../../../input/inputmanager/).

```csharp
// At Screen class scope:
Polygon firstPolygon;
Polygon secondPolygon;

// In your Screen's CustomInitialize
firstPolygon = Polygon.CreateRectangle(32, 32);
firstPolygon.X = 100;
ShapeManager.AddPolygon(firstPolygon);

secondPolygon = Polygon.CreateRectangle(32, 32);
ShapeManager.AddPolygon(secondPolygon);

// your Screen's CustomActivity
FlatRedBall.Input.InputManager.Keyboard.ControlPositionedObject(secondPolygon, 32);
if (secondPolygon.CollideAgainst(firstPolygon))
{
    firstPolygon.Color = Color.Blue;
    secondPolygon.Color = Color.Red;
}
else
{
    firstPolygon.Color = Color.White;
    secondPolygon.Color = Color.White;
}
```

#### Efficiency of Polygon Collision

Each Polygon has a BoundingRadius method which is set when the point list reference is updated. This BoundingRadius is used internally in collision methods. When two Polygons collide, their distances are compared to their BoundingRadius. If the two are too far away to possibly have a collision, then no deeper checks are performed.

This helps reduce the cost of performing polygon collision, especially when polygons are often separated by larger distances.

#### SimulateCollideAgainstMove

This method repositions a Polygon or its TopParent if it has one, changes the LastMoveCollisionReposition property, and finally updates all attachments. This code performs all of the updates which would happen on a successful CollideAgainstMove call. This method is rarely used. It can be used if collision is handled outside of the polygon class but the LastMoveCollisionReposition property is still used in other parts of code. If collision that repositions a polygon calls this method rather than simply changing its Position values, then code that uses the LastMoveCollisionReposition property (such as ProjectParentVelocityOnLastMoveCollisionTangent) will still work correctly.
