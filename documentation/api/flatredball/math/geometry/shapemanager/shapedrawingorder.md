## Introduction

The ShapeDrawingOrder controls whether all Shapes are drawn under or over other FlatRedBall-drawn objects (for example [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"), [Models](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel "FlatRedBall.Graphics.Model.PositionedModel"), and [Texts](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text")). Currently shape drawing order cannot be controlled by the shape's Z value; however, as of the June 2009 release of FlatRedBall, most shapes can be placed on layers which provides some control over ordering.

The ShapeDrawingOrder has two options:

-   UnderEverything
-   OverEverything (default)

Since the default for the ShapeManager's ShapeDrawingOrder is OverEverything, then all shape drawing will appear on top of other objects.

## Code Example

The following example adds a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and a [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line "FlatRedBall.Math.Geometry.Line"), then sets ShapeDrawingOrder to UnderEverything so that the added [Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line "FlatRedBall.Math.Geometry.Line") appears under the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite").

Add the following using statements:

    using FlatRedBall;
    using FlatRedBall.Math.Geometry;

Add the following to Initialize after initializing FlatRedBall:

     SpriteManager.AddSprite("redball.bmp");

     Line line = ShapeManager.AddLine();
     line.SetFromAbsoluteEndpoints(new Vector3(-3, 0, 0), new Vector3(3, 0, 0));

     ShapeManager.ShapeDrawingOrder = ShapeDrawingOrder.UnderEverything;

![ShapeDrawingOrder.png](/media/migrated_media-ShapeDrawingOrder.png)
