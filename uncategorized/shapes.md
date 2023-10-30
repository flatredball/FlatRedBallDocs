# shapes

### Introduction

The ShapeManager is responsible for managing "Shapes". Shapes are most often used for collision between objects.

Objects which belong to the Shape categorization are:

* [AxisAlignedCube](../frb/docs/index.php)
* [AxisAlignedRectangle](../frb/docs/index.php)
* [Capsule2D](../frb/docs/index.php)
* [Circle](../frb/docs/index.php)
* [Line](../frb/docs/index.php)
* [Polygon](../frb/docs/index.php)
* [Sphere](../frb/docs/index.php)

All of these objects share the [PositionedObject](../frb/docs/index.php) base class. These are the only objects which the ShapeManager manages. Although there is no "Shape" class, these objects are often referred to as shapes.

### Adding Shapes

The ShapeManager can add any shape through its Add methods. The following code creates a Circle.

Add the following using statement:

```
using FlatRedBall.Math.Geometry;
```

Add the following using statement:

```
Circle circle = ShapeManager.AddCircle();
```

![SimpleCircle.png](../media/migrated_media-SimpleCircle.png)

#### Shapes and Visibility

Adding a Shape to the ShapeManager will automatically make the shape visible. For example, the following code will result in a **visible** [Circle](../frb/docs/index.php):

```
Circle circle = new Circle();
circle.Visible = false; // this will get overridden
ShapeManager.AddCircle(circle); // now our Circle's visible
```

To properly control visibility, set the value **after** a shape to the ShapeManager:

```
Circle circle = new Circle();
ShapeManager.AddCircle(circle); // now our Circle's visible
circle.Visible = false; // this will get overridden
```

### Removing Shapes

The ShapeManager can remove shapes that have been previously added to it through its Remove method.

Assuming circle is an instance of a Circle that has been created through the ShapeManager:

```
ShapeManager.Remove(circle);
```

### Management Tasks

Aside from addition and removal of shapes, the ShapeManager is responsible for drawing and managing Sprites. Calling AddPolygon, AddAxisAlignedRectangle, and AddCircle results in the ShapeManager managing and drawing the Sprite added or created by the method. It is possible to create manage-only or draw-only as shown by the following code:

```
 // This using statement reduces the amount of code necessary
 using FlatRedBall.Math.Geometry;

 // The following circle is both managed and drawn:
 Circle circle1 = ShapeManager.AddCircle();

 // The following circle is only drawn:
 Circle circle2 = new Circle();
 circle2.Visible = true;

 // The following circle is only managed:
 Circle circle3 = ShapeManager.AddCircle();
 circle3.Visible = false;
```

#### Why Limit Shape Management?

Making shapes visible can be beneficial for debugging collisions. For the final version most games will want shapes to be invisible. Invisible shapes will collide the same as visible ones so in most cases visibility is useful simply during development. Of course, shapes can also be used to draw on-screen line graphics.

Clearly, visibility control is important, but why **not** include shapes in the ShapeManager? The ShapeManager provides some behavior that can be helpful, but in many cases this behavior is not necessary.

Shapes should be added to the ShapeManager if any of the following behavior is needed:

* Attachment updates when collision methods are **not** called. **See Note**
* Absolute or relative velocity.
* Absolute or relative acceleration.
* Absolute or relative rotation velocity;
* Instructions
* ScaleVelocity ([AxisAlignedRectangle](../frb/docs/index.php) only)
* Radius Velocity ([Circle](../frb/docs/index.php) only)

**Note about attachments:** Shapes which are attached to parents can have their absolute positions updated one of two ways:

1. By being added to the ShapeManager
2. By calling one of their collision methods or passing them as arguments to a collision method.

If a shape is to be used only for collision and is not visible, then it is not necessary to add it to the ShapeManager. When the collision method is called then it will automatically have its position updated. If a shape is visible, has a parent, and does not have collision methods being called, then it will need to be added to the ShapeManager to have its absolute position updated.

If a shape is to be completely static - like a grid in a tool - then there is no reason to add it to the ShapeManager.

#### Unmanaged Shape Behavior

The source of some confusion is what happens when a Shape is attached to a [PositionedObject](../frb/docs/index.php) (like a [Sprite](../frb/docs/index.php)), but **not** added to the ShapeManager. If you write code which attaches a shape to a [Sprite](../frb/docs/index.php), make the shape visible, then move the parent [Sprite](../frb/docs/index.php) you will notice that the shape does not move. Why is this the case?

Well, again, there are two ways to update a shape's attachments:

1. By being added to the ShapeManager
2. By calling one of their collision methods or passing them as arguments to a collision method.

Since the shape is neither part of the ShapeManager nor having any Collision methods called, then its dependencies are never updated - so the position of the parent has no affect on the child Shape. If you are interested in seeing the shape move with its parent, simply add it to the ShapeManager. If this shape is going to be used for collisions, then there is no need to add it to the ShapeManager - calling collision methods will automatically manage the dependency.

This behavior will also be present if the shape is not visible, but you depend on the shape's absolute position. If you're depending on the shape's position outside of collision, be sure to add it to the ShapeManager.

### Additional Information

* [Colliding a list of shapes against itself](../frb/docs/index.php)
* [Shapes and 2D Collision](../frb/docs/index.php)

### ShapeManager Members

* [FlatRedBall.Math.Geometry.ShapeManager.AddAxisAlignedRectangle](../frb/docs/index.php)
* [FlatRedBall.Math.Geometry.ShapeManager.AddToLayer](../frb/docs/index.php)
* [FlatRedBall.Math.Geometry.ShapeManager.Remove](../frb/docs/index.php)
* [FlatRedBall.Math.Geometry.ShapeManager.ShapeDrawingOrder](../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
