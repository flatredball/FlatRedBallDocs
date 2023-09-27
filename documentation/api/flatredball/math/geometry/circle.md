## Introduction

The Circle represents a PositionedObject which can be used to draw circles or conduct circular collision which is very efficient. Circles are created and removed through the [ShapeManager](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.md "FlatRedBall.Math.Geometry.ShapeManager").

## Creating a Circle in Glue

Glue supports the creation of Circles in Screens and Entities. To create a Circle in Glue:

1.  Expand a Screen or Entity
2.  Right-click on the Objects folder
3.  Select **Add Object**
4.  Select the **Circle** type
5.  Click **OK**

## Simple Circle Example

The following example creates two circles and controls one of them with the [Keyboard](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard.md "FlatRedBall.Input.Keyboard").

Add the following using statement

    using FlatRedBall.Math.Geometry;
    using FlatRedBall.Input;

At Class Scope:

    Circle controlledCircle;
    Circle idleCircle;

In Initialize:

     controlledCircle = ShapeManager.AddCircle();
     controlledCircle.X = 5;

     idleCircle = ShapeManager.AddCircle();
     idleCircle.Radius = 3;

In Update:

    InputManager.Keyboard.ControlPositionedObject(controlledCircle);
    if (controlledCircle.CollideAgainst(idleCircle))
    {
       controlledCircle.Color = Microsoft.Xna.Framework.Graphics.Color.Blue;
    }
    else
    {
       controlledCircle.Color = Microsoft.Xna.Framework.Graphics.Color.Red;
    }

![TwoCirclesOverlapping.png](/media/migrated_media-TwoCirclesOverlapping.png)

## Circle Members

-   [FlatRedBall.Math.Geometry.Circle.CollideAgainst](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainst.md "FlatRedBall.Math.Geometry.Circle.CollideAgainst")
-   [FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainst.mdBounce "FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce")
-   [FlatRedBall.Math.Geometry.Circle.CollideAgainstMove](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove.md "FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove")
-   [FlatRedBall.Math.Geometry.Circle.IsPointInside](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.IsPointInside.md "FlatRedBall.Math.Geometry.Circle.IsPointInside")
-   [FlatRedBall.Math.Geometry.Circle.LastCollisionTangent](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.LastCollisionTangent.md "FlatRedBall.Math.Geometry.Circle.LastCollisionTangent")
-   [FlatRedBall.Math.Geometry.Circle.LastMoveCollisionReposition](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.LastMoveCollisionReposition.md "FlatRedBall.Math.Geometry.Circle.LastMoveCollisionReposition")
-   [FlatRedBall.Math.Geometry.Circle.ProjectParentVelocityOnLastMoveCollisionTangent](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.ProjectParentVelocityOnLastMoveCollisionTangent.md "FlatRedBall.Math.Geometry.Circle.ProjectParentVelocityOnLastMoveCollisionTangent")
-   [FlatRedBall.Math.Geometry.Circle.Visible](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.Visible.md "FlatRedBall.Math.Geometry.Circle.Visible")
-   [FlatRedBall.Math.Geometry.Circle.Z](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.Z.md "FlatRedBall.Math.Geometry.Circle.Z")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
