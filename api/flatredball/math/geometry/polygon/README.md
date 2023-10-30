# polygon

### Introduction

The Polygon class is used to draw line polygons (as opposed to solid colored or textured polygons) as well as for 2D collisions. This wiki entry will cover common usage of the Polygon class. The Polygon class sits in the FlatRedBall.Math.Geometry namespace, so adding

```
using FlatRedBall.Math.Geometry;
```

can reduce the amount of required code. Also, Polygons use the FlatRedBall.Math.Geometry.Point struct, so the following code will solve ambiguities:

```
using Point = FlatRedBall.Math.Geometry.Point;
```

### Creating a Rectangle Polygon

The Polygon class provides the CreateRectangle  shortcut methods for creating common Polygons:

```
// Parameters are "ScaleX" and "ScaleY" which is the distance from 
// center to edge. Therefore, to make a 32x32 rectangle, we'd use 
// 16 for each dimension:
Polygon rectangle = Polygon.CreateRectangle(32/2, 32/2);
// To have the Polygon drawn and managed, add it to the ShapeManager
ShapeManager.AddPolygon(rectangle);
```

You can also assign the Points object. **For more information, see the** [**Points page**](../../../../../../frb/docs/index.php)**.**

### Creating a Polygon From Points

```lang:c#
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

![](../../../../../../media/2017-06-img_593f455263322.png)

### Polygon as a PositionedObject

The Polygon class inherits from the [FlatRedBall.PositionedObject](../../../../../../frb/docs/index.php) class. See the [FlatRedBall.PositionedObject](../../../../../../frb/docs/index.php) wiki entry for editing properties.

### Polygon Collision

The Polygon class provides collision methods and properties to simplify common game programming tasks. The following code creates two Polygons which turn red when they collide. Note that this uses input code. For information on using FlatRedBall input, see [FlatRedBall.Input.InputManager](../../../../../../frb/docs/index.php).

```
 // At class scope:
 Polygon firstPolygon;
 Polygon secondPolygon;

 // In Initialize after initializing FlatRedBall:
 firstPolygon = Polygon.CreateRectangle(3, 3);
 firstPolygon.X = 7;
 ShapeManager.AddPolygon(firstPolygon);

 secondPolygon = Polygon.CreateRectangle(3, 3);
 ShapeManager.AddPolygon(secondPolygon);

 // In Update after FlatRedBall's Update methods
 FlatRedBall.Input.InputManager.Keyboard.ControlPositionedObject(secondPolygon, 5);
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

#### SimulateCollideAgainstMove

This method repositions a Polygon or its TopParent if it has one, changes the LastMoveCollisionReposition property, and finally updates all attachments. This code performs all of the updates which would happen on a successful CollideAgainstMove call. This method is rarely used. It can be used if collision is handled outside of the polygon class but the LastMoveCollisionReposition property is still used in other parts of code. If collision that repositions a polygon calls this method rather than simply changing its Position values, then code that uses the LastMoveCollisionReposition property (such as ProjectParentVelocityOnLastMoveCollisionTangent) will still work correctly.

### Additional Information

* [FlatRedBall.Math.Geometry.Polygon:Thin Polygon Problem](../../../../../../frb/docs/index.php)

\[subpages depth="1"]
