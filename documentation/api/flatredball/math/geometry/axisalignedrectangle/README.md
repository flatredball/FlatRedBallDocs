## Introduction

The AxisAlignedRectangle is a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") which is used for unrotated bounding box collision. This is preferred over [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon "FlatRedBall.Math.Geometry.Polygon") collision if Sprites are not rotated due to speed and memory usage considerations. AxisAlignedRectangles share many similarities with the other shape classes ([Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle "FlatRedBall.Math.Geometry.Circle"), [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line "FlatRedBall.Math.Geometry.Line"), and [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon "FlatRedBall.Math.Geometry.Polygon")). For general information about shapes, see the [ShapeManager wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager "FlatRedBall.Math.Geometry.ShapeManager"). For information on using AxisAlignedRectangles in Glue, see [this page](/frb/docs/index.php?title=Objects:AxisAlignedRectangle&action=edit&redlink=1 "Objects:AxisAlignedRectangle (page does not exist)"). AxisAlignedRectangles do not support being filled-in. They can only render as an outline. To render a solid rectangle, look at using [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") with the [Color ColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.Color "FlatRedBall.Graphics.ColorOperation.Color")

## What does "axis aligned" mean?

The "AxisAligned" part of AxisAlignedRectangle indicates that the sides of the rectangle are "axis aligned". In other words, the top, bottom, left, and right are all parallel to either the X or Y axes. ![AxisAligned.png](/media/migrated_media-AxisAligned.png) AxisAlignedRectangles are always axis aligned for performance reasons. Therefore, if you rotate an AxisAlignedRectangle (set its RotationZ), this will have no impact on the collision behavior or its visible representation. If your game requires rotation, you should use the [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon "FlatRedBall.Math.Geometry.Polygon") class. Of course, performance will suffer slightly if collision performance is a consideration for your game. For more information on axis alignment and a discussion of axis aligned object rotation and children positions, see [this page](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle:Axis_Alignment_and_Rotation "FlatRedBall.Math.Geometry.AxisAlignedRectangle:Axis Alignment and Rotation").

## AxisAlignedRectangles are [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject")

The AxisAlignedRectangle class inherits from PositionedObject. This means that all properties which are available to [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") (excluding rotation) are available to AxisAlignedRectangles. For more information, see the [PositionedObject page](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject").

## Creating an AxisAlignedRectangle

AxisAlignedRectangles are created through the ShapeManager. The following code creates an AxisAlignedRectangle through the ShapeManager and resizes it: Add the following using statement

    using FlatRedBall.Math.Geometry;

Create the instance:

    // AxisAlignedRectangles added this way are Visible by default and also managed
    // by the ShapeManager.
    AxisAlignedRectangle rectangle = ShapeManager.AddAxisAlignedRectangle();
    rectangle.ScaleX = 5;
    rectangle.ScaleY = 7;

![SimpleRectangle.png](/media/migrated_media-SimpleRectangle.png)

## Relationship with ShapeManager

See [ShapeManager wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager "FlatRedBall.Math.Geometry.ShapeManager").

## Move (Solid) Collision

Solid or moving collision can be performed with AxisAlignedRectangles as well as [Polygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon "FlatRedBall.Math.Geometry.Polygon") and [Circles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle "FlatRedBall.Math.Geometry.Circle"). The following code creates three AxisAlignedRectangles - one controlled by the player, one which can be pushed, and one which is is immovable. Add the following using statements:

    using FlatRedBall.Input;
    using FlatRedBall.Math.Geometry;

Add the following at class scope:

    AxisAlignedRectangle playerRectangle;
    AxisAlignedRectangle movableBlockRectangle;
    AxisAlignedRectangle solidRectangle;

Add the following in Initialize after Initializing FlatRedBall:

     playerRectangle = ShapeManager.AddAxisAlignedRectangle();
     playerRectangle.X = -3;
     playerRectangle.Color = Color.Yellow;

     movableBlockRectangle = ShapeManager.AddAxisAlignedRectangle();
     movableBlockRectangle.Color = Color.Red;

     solidRectangle = ShapeManager.AddAxisAlignedRectangle();
     solidRectangle.ScaleX = solidRectangle.ScaleY = 4;
     solidRectangle.X = 7;

Add the following in Update:

     InputManager.Keyboard.ControlPositionedObject(playerRectangle);

     // player and movable have the same mass
     playerRectangle.CollideAgainstMove(movableBlockRectangle, .5f, .5f);
     // make the solid infinitely more massive than the player
     playerRectangle.CollideAgainstMove(solidRectangle, 0, 1);
     // make the solid infinitely more massive than the movable
     movableBlockRectangle.CollideAgainstMove(solidRectangle, 0, 1);

![SolidCollision.png](/media/migrated_media-SolidCollision.png)

## Determining Collision Side

For information on determining which side an object has collided on, see [this page on LastMoveCollisionReposition](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.LastMoveCollisionReposition "FlatRedBall.Math.Geometry.AxisAlignedRectangle.LastMoveCollisionReposition").

## AxisAlignedRectangle Members

-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Bottom](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainst](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainst "FlatRedBall.Math.Geometry.Circle.CollideAgainst")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainstBounce](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce "FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainstMove](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove "FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainstMoveSoft](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainstMoveSoft "FlatRedBall.Math.Geometry.AxisAlignedRectangle.CollideAgainstMoveSoft")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Color](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Color "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Color")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.GetRandomPositionInThis](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.GetRandomPositionInThis "FlatRedBall.Math.Geometry.AxisAlignedRectangle.GetRandomPositionInThis")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height&action=edit&redlink=1 "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Height (page does not exist)")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.KeepThisInsideOf](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.KeepThisInsideOf "FlatRedBall.Math.Geometry.AxisAlignedRectangle.KeepThisInsideOf")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.LastMoveCollisionReposition](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.LastMoveCollisionReposition "FlatRedBall.Math.Geometry.AxisAlignedRectangle.LastMoveCollisionReposition")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.RepositionDirections](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.RepositionDirections "FlatRedBall.Math.Geometry.AxisAlignedRectangle.RepositionDirections")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Right](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Top](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Left")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width&action=edit&redlink=1 "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Width (page does not exist)")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle.Z](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.Z "FlatRedBall.Math.Geometry.AxisAlignedRectangle.Z")

## Extra Information

-   [Axis Alignment and Rotation](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle:Axis_Alignment_and_Rotation "FlatRedBall.Math.Geometry.AxisAlignedRectangle:Axis Alignment and Rotation")
-   [Tile Collision](/frb/docs/index.php?title=Tile_Collision "Tile Collision")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
