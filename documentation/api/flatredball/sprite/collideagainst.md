## Introduction

**Sprite collision methods are obsolete!** The Sprite collision methods were written long before Entities and [Glue](/frb/docs/index.php?title=Glue.md "Glue"). During that time the Sprite was intended to contain its own collision; however, now the Entity pattern has replaced this approach. The collision methods in the Sprite class have been left in but instead we recommend using the Entity pattern for collisions. If you are using Glue, check out the [Beefball tutorials which explain how to create Entities with Collision](/frb/docs/index.php?title=Tutorials:Beefball.md "Tutorials:Beefball").

The Sprite class is designed to work hand-in-hand with shape objects like [AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle"), [Circles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle"), and [Polygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon"). The Sprite class exposes general methods to enable collision to be performed without having to know specifically which types of shapes are being referenced. For example, the following code creates three Sprites - each referencing a different shape. Notice that the calls to assign the collisions or to perform collisions is generic rather than type-specific. **Z position is ignored when performing collision. Only X and Y position is considered.**

## Code Example

Add the following using statement:

    using FlatRedBall.Math.Geometry;

Create the objects:

    AxisAlignedRectangle rectangle = new AxisAlignedRectangle();
    rectangle.ScaleX = rectangle.ScaleY = 1;
    Sprite sprite1 = SpriteManager.AddSprite("redball.bmp");
    sprite1.SetCollision(rectangle);

    Circle circle = new Circle();
    circle.Radius = 1;
    Sprite sprite2 = SpriteManager.AddSprite("redball.bmp");
    sprite2.SetCollision(circle);

    // Creates a rectangular polygon with ScaleX and ScaleY of 1
    Polygon polygon = Polygon.CreateRectangle(1, 1);
    Sprite sprite3 = SpriteManager.AddSprite("redball.bmp");
    sprite3.SetCollision(polygon);

    // Calling CollidesAgainst uses whichever shape is referenced by
    // the Sprite:
    if (sprite1.CollideAgainst(sprite2))
    {
        // perform activity
    }
    if (sprite1.CollideAgainst(sprite3))
    {
        // perform activity
    }
    if (sprite2.CollideAgainst(sprite3))
    {
        // perform activity
    }

### Bounding Box Collision

Bounding Box collision can be performed by creating [AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle").

    Sprite sprite1 = SpriteManager.AddSprite("redball.bmp");
    Sprite sprite2 = SpriteManager.AddSprite("redball.bmp");

    FlatRedBall.Math.Geometry.AxisAlignedRectangle rectangle = 
        new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
    rectangle.ScaleX = sprite1.ScaleX;
    rectangle.ScaleY = sprite1.ScaleY;
    sprite1.SetCollision(rectangle);

    rectangle =
        new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
    rectangle.ScaleX = sprite2.ScaleX;
    rectangle.ScaleY = sprite2.ScaleY;
    sprite2.SetCollision(rectangle);

    // The collide against should probably be called every frame, like
    // in the Game's Update method

    if (sprite1.CollideAgainst(sprite2))
    {
        // perform action
    }
