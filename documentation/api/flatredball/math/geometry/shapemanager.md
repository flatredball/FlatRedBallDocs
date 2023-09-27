## Introduction

The ShapeManager is responsible for managing "Shapes". Shapes are most often used for collision between objects. Objects which belong to the Shape categorization are:

-   [AxisAlignedCube](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedCube.md "FlatRedBall.Math.Geometry.AxisAlignedCube")
-   [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle")
-   [Capsule2D](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Capsule2D.md "FlatRedBall.Math.Geometry.Capsule2D")
-   [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle")
-   [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line.md "FlatRedBall.Math.Geometry.Line")
-   [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon")
-   [Sphere](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Sphere&action=edit&redlink=1.md "FlatRedBall.Math.Geometry.Sphere (page does not exist)")

All of these objects share the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") base class. These are the only objects which the ShapeManager manages. Although there is no "Shape" class, these objects are often referred to as shapes.

## Automatic Add in FlatRedBall Editor

Any shape added to the FlatRedBall Editor (either as part of a Screen or Entity) will also be added to the ShapeManager by default. For example, the Player entity in the following screenshot contains an AxisAlignedRectangle which is automatically added to the ShapeManager.

![](/media/2023-01-img_63bc1a57b884a.png)

## Adding Shapes in Code

The ShapeManager can add any shape through its Add methods. The following code creates a Circle. Add the following using statement:

    using FlatRedBall.Math.Geometry;

Add the following using statement:

    Circle circle = ShapeManager.AddCircle();

![SimpleCircle.png](/media/migrated_media-SimpleCircle.png) If a Shape is added in code, it must be removed in code as well, typically in a Screen or Entity's CustomDestroy.

### Shapes and Visibility

Adding a Shape to the ShapeManager will automatically make the shape visible. For example, the following code results in a **visible** [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle"):

    Circle circle = new Circle();
    circle.Visible = false; // this will get overridden
    ShapeManager.AddCircle(circle); // now our Circle's visible

To properly control visibility, set the value **after** a shape to the ShapeManager:

    Circle circle = new Circle();
    ShapeManager.AddCircle(circle); // now our Circle's visible
    circle.Visible = false; // this applies to the circle since it is already added to the ShapeManager

## Removing Shapes

The ShapeManager can remove shapes that have been previously added to it through its Remove method. Assuming circle is an instance of a Circle that has been created through the ShapeManager:

    ShapeManager.Remove(circle);

## Management Tasks

Aside from addition and removal of shapes, the ShapeManager is responsible for drawing and managing Sprites. Calling AddPolygon, AddAxisAlignedRectangle, and AddCircle results in the ShapeManager managing and drawing the Sprite added or created by the method. It is possible to create manage-only or draw-only as shown by the following code:

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

Note that circle2 is never explicitly added to the ShapeManager, but it will still be drawn. This behavior differs from other FlatRedBall objects such as Sprites which must be added explicitly to their respective manager to be drawn.

## A Deep Dive in Shape Management

Shape Management can be a complicated topic because shapes can be managed in a number of different ways. The reason this complexity exists is because games often include a very large number of shapes for collision. For example, a tile-based game may include hundreds or thousands of shapes as part of a TileShapeCollection. Games with a large number of collidable entities (such as twin stick shooters) may similarly have hundreds or thousands of live shapes. Therefore, shape management can be customized for performance and functionality as necessary. The term *management* can refer to any number of every-frame operations which can be performed on a shape. These can be grouped into a number of categories:

-   Parent/Child Relationship Management - this results in a shape's position being updated according to its parent - usually an Entity instance.
-   Visibility/Drawing Management - this management results in the shape being drawn to the screen
-   Velocity/Physics Management - this management results in a shape's physics values such as Velocity, Acceleration, and Drag being applied every frame

Games which are concerned with performance should only apply every-frame management as necessary for shapes. Unnecessary management can lower the frame rate of your game, in some cases to the point of making the game unplayable. Shape management management can be performed in a number of ways:

-   Adding a Shape to the ShapeManager - this results in all management being applied, which is handy if you need all types, but this is expensive if shapes do not need full management.
-   Setting a shape's Visible to true - this adds a shape to the ShapeManager, but only to be drawn. A visible shape which is not explicitly added to the ShapeManager will only be drawn but other forms of management such as physics are not applied. Note that this is true unless the ShapeManager's SuppressAddingOnVisibilityTrue is set to true. See the SuppressAddingOnVisibilityTrue page for more information.
-   Attaching a shape to a collidable entity - collision functions perform parent/child relationship updates automatically because these types of relationships are very common.
-   Performing management in generated code - the FlatRedBall Editor provides functionality for performing management in generated code. This approach as the benefit of selectively applying updates only to properties which need management.
-   Performing management in custom code - custom code can perform custom management just like generated code. This is effective if you would like complete control over management.

Making shapes visible can be beneficial for debugging collisions. For the final version most games will want shapes to be invisible. Invisible shapes will collide the same as visible ones so in most cases visibility is useful simply during development. Of course, shapes can also be used to draw on-screen line graphics.  

### 

### Unmanaged Shape Behavior

The source of some confusion is what happens when a Shape is attached to a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") (like an Entity), but **not** added to the ShapeManager. If you write code which attaches a shape to an Entity, set the shape's Visible to true, then move the entity, you will notice that the shape does not move. As mentioned above there are two ways to update a shape's parent/child relationship:

1.  By being added to the ShapeManager
2.  By calling one of their collision methods or passing them as arguments to a collision method.

Since the shape is neither part of the ShapeManager nor having any Collision methods called, then its dependencies are never updated - so the position of the parent has no affect on the child Shape. If you are interested in seeing the shape move with its parent, simply add it to the ShapeManager. If this shape is going to be used for collisions, then there is no need to add it to the ShapeManager - calling collision methods will automatically manage the dependency. This behavior will also be present if the shape is not visible, but you depend on the shape's absolute position. If you're depending on the shape's position outside of collision, be sure to add it to the ShapeManager.

## Additional Information

-   [Colliding a list of shapes against itself](/frb/docs/index.php?title=FlatRedBall.Math.Geometry:Colliding_a_list_of_shapes_against_itself.md "FlatRedBall.Math.Geometry:Colliding a list of shapes against itself")
-   [Shapes and 2D Collision](/frb/docs/index.php?title=FlatRedBall.Math.Geometry:Shapes_and_2D_Collision.md "FlatRedBall.Math.Geometry:Shapes and 2D Collision")

## ShapeManager Members

-   [FlatRedBall.Math.Geometry.ShapeManager.AddAxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.AddAxisAlignedRectangle&action=edit&redlink=1.md "FlatRedBall.Math.Geometry.ShapeManager.AddAxisAlignedRectangle (page does not exist)")
-   [FlatRedBall.Math.Geometry.ShapeManager.AddToLayer](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.AddToLayer&action=edit&redlink=1.md "FlatRedBall.Math.Geometry.ShapeManager.AddToLayer (page does not exist)")
-   [FlatRedBall.Math.Geometry.ShapeManager.Remove](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.Remove.md "FlatRedBall.Math.Geometry.ShapeManager.Remove")
-   [FlatRedBall.Math.Geometry.ShapeManager.ShapeDrawingOrder](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.ShapeDrawingOrder.md "FlatRedBall.Math.Geometry.ShapeManager.ShapeDrawingOrder")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
