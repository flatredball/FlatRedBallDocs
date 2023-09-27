## Introduction

The AxisAlignedCube is a geometric shape from the [FlatRedBall.Math.Geometry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry&action=edit&redlink=1.md "FlatRedBall.Math.Geometry (page does not exist)") class. As a 3D shape, it can be used for detecting collisions with 3D or 2D shapes. The AxisAlignedCube class shares many similarities with other shape classes ([Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle"), [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line.md "FlatRedBall.Math.Geometry.Line"), [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle"), [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon"), etc). For general information about shapes, see the [ShapeManager wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.md "FlatRedBall.Math.Geometry.ShapeManager").

## Creating an AxisAlignedCube

AxisAlignedCubes are created through the ShapeManager. The following code creates an AxisAlignedCube through the ShapeManager and resizes it: Add the following using statement using FlatRedBall.Math.Geometry; Create the instance globally AxisAlignedCube mCube; In the Initialize method

    mCube = new AxisAlignedCube();
    mCube.Visible = true;
    mCube.ScaleX = 3;
    mCube.ScaleY = 4;

Alternatively, you can create an AxisAlignedCube with the Visible property set first by doing this Create the instance globally AxisAlignedCube mCube = ShapeManager.AddAxisAlignedCube(); ![SimpleCube.png](/media/migrated_media-SimpleCube.png)

## Relationship with ShapeManager

See [ShapeManager wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.md "FlatRedBall.Math.Geometry.ShapeManager").

## Collisions With AxisAlignedCube

For detecting collisions with AxisAlignedCubes, use the following code: Add the following using statement

    using FlatRedBall.Math.Geometry;
    using FlatRedBall.Input;

Create the instance globally

    AxisAlignedCube mCube;
    AxisAlignedCube mCube2;

In the Initialize method before the base call

    mCube = new AxisAlignedCube();
    mCube.Visible = true;
    mCube.Color = Color.Red;
                
    mCube2 = new AxisAlignedCube();
    mCube2.Visible = true;
    mCube2.Color = Color.Red;
    mCube2.X = 1;

In the Update method before the base calls

    if (mCube.CollideAgainst(mCube2))
    {
      mCube2.Color = Color.Blue;
    }

    if (mCube2.CollideAgainst(mCube))
    {
      mCube.Color = Color.Orange;
    }

![PreCubeCollision.png](/media/migrated_media-PreCubeCollision.png)![PostCubeCollision.png](/media/migrated_media-PostCubeCollision.png)

## Determining Collision Side

When two AxisAlignedCubes collide the collision side can be determined rather easily. The following code determines the side that two rectangles collided on: Add the following using statements

    using FlatRedBall.Math.Geometry;
    using Side = FlatRedBall.Math.Collision.CollisionEnumerations.Side3D;

Assuming cube1 and cube2 are valid AxisAlignedCubes:

    Side side = Side.None;

    if (mCube1.CollideAgainstMove(mCube2, 0, 1))
    {
      if (mCube1.LastMoveCollisionReposition.X > 0)
          side = Side.Right;
      else if (mCube1.LastMoveCollisionReposition.X < 0)
          side = Side.Left;
      else if (mCube1.LastMoveCollisionReposition.Y > 0)
          side = Side.Top;
      else if (mCube1.LastMoveCollisionReposition.Y < 0)
          side = Side.Bottom;
      else if (mCube1.LastMoveCollisionReposition.Z > 0)
          side = Side.Front;
      else if (mCube1.LastMoveCollisionReposition.Z < 0)
          side = Side.Back;
    }

## AxisAlignedCube Members

-   [FlatRedBall.Math.Geometry.AxisAlignedCube.CollideAgainstBounce](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedCube.CollideAgainstBounce.md "FlatRedBall.Math.Geometry.AxisAlignedCube.CollideAgainstBounce")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
