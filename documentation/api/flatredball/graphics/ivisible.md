## Introduction

The IVisible interface is an interface which defines that an object must have a Visible property. Setting Visible to true or false will make the object appear or disappear visually. Most visual FlatRedBall types implement the IVisible property including:

-   [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite")
-   [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text")
-   [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle")
-   [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle")
-   [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon")
-   [SpriteFrame](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteFrame.md "FlatRedBall.ManagedSpriteGroups.SpriteFrame")

## Code Example

The following code shows how to toggle a Sprite's visibility when the mouse is clicked:

    if(FlatRedBall.Gui.GuiManager.Cursor.PrimaryClick)
    {
       // Assuming SpriteInstance is a valid Sprite instance:
       if(SpriteInstance.Visible)
       {
          SpriteInstance.Visible = false;
       }
       else
       {
          SpriteInstance.Visible = true;
       }
    }

## IVisible and Parenting

The Visible property on an IVisible controls whether an object will be drawn, but it also controls whether all of its children will be drawn. Therefore, if an object (such as a Glue Entity) implements IVisible, and if its Visible is set to false, then all attached objects will also be invisible. This behavior simplifies making UI objects (such as Pause menus) which many be made up of multiple levels of UI elements.

This behavior can be modified through the [IgnoresParentVisibility property](/frb/docs/index.php?title=FlatRedBall.Graphics.IVisible.IgnoresParentVisibility.md "FlatRedBall.Graphics.IVisible.IgnoresParentVisibility").

## IVisible Members

-   [FlatRedBall.Graphics.IVisible.IgnoresParentVisibility](/frb/docs/index.php?title=FlatRedBall.Graphics.IVisible.IgnoresParentVisibility.md "FlatRedBall.Graphics.IVisible.IgnoresParentVisibility")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
