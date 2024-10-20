# AxisAlignedCube

### Introduction

The AxisAlignedCube is a geometric shape from the [FlatRedBall.Math.Geometry](../../../../../frb/docs/index.php) class. As a 3D shape, it can be used for detecting collisions with 3D or 2D shapes. The AxisAlignedCube class shares many similarities with other shape classes ([Circle](../../../../../frb/docs/index.php), [Line](../../../../../frb/docs/index.php), [AxisAlignedRectangle](../../../../../frb/docs/index.php), [Polygon](../../../../../frb/docs/index.php), etc). For general information about shapes, see the [ShapeManager wiki entry](../../../../../frb/docs/index.php).

### Creating an AxisAlignedCube

AxisAlignedCubes are created through the ShapeManager. The following code creates an AxisAlignedCube through the ShapeManager and resizes it: Add the following using statement using FlatRedBall.Math.Geometry; Create the instance globally AxisAlignedCube mCube; In the Initialize method

```
mCube = new AxisAlignedCube();
mCube.Visible = true;
mCube.ScaleX = 3;
mCube.ScaleY = 4;
```

Alternatively, you can create an AxisAlignedCube with the Visible property set first by doing this Create the instance globally AxisAlignedCube mCube = ShapeManager.AddAxisAlignedCube(); ![SimpleCube.png](../../../../../.gitbook/assets/migrated\_media-SimpleCube.png)

### Relationship with ShapeManager

See [ShapeManager wiki entry](../../../../../frb/docs/index.php).

### Collisions With AxisAlignedCube

For detecting collisions with AxisAlignedCubes, use the following code: Add the following using statement

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Input;
```

Create the instance globally

```
AxisAlignedCube mCube;
AxisAlignedCube mCube2;
```

In the Initialize method before the base call

```
mCube = new AxisAlignedCube();
mCube.Visible = true;
mCube.Color = Color.Red;
            
mCube2 = new AxisAlignedCube();
mCube2.Visible = true;
mCube2.Color = Color.Red;
mCube2.X = 1;
```

In the Update method before the base calls

```
if (mCube.CollideAgainst(mCube2))
{
  mCube2.Color = Color.Blue;
}

if (mCube2.CollideAgainst(mCube))
{
  mCube.Color = Color.Orange;
}
```

![PreCubeCollision.png](../../../../../.gitbook/assets/migrated\_media-PreCubeCollision.png) ![PostCubeCollision.png](../../../../../.gitbook/assets/migrated\_media-PostCubeCollision.png)

### Determining Collision Side

When two AxisAlignedCubes collide the collision side can be determined rather easily. The following code determines the side that two rectangles collided on: Add the following using statements

```
using FlatRedBall.Math.Geometry;
using Side = FlatRedBall.Math.Collision.CollisionEnumerations.Side3D;
```

Assuming cube1 and cube2 are valid AxisAlignedCubes:

```
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
```

### AxisAlignedCube Members

* [FlatRedBall.Math.Geometry.AxisAlignedCube.CollideAgainstBounce](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
