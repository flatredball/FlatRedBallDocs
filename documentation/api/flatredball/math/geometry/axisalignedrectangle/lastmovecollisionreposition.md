## Introduction

The LastMoveCollisionReposition is a property that exists for all [Shapes](/frb/docs/index.php?title=Shape.md "Shape"). If using CollisionRelationships, this property is set on any type of collision relationship that moves an object. This includes:

-   Move Collision
-   Bounce Collision
-   Platformer Solid Collision
-   Platformer Cloud Collision

If using manual collision calls, this property is set whenever a shape calls CollideAgainstBounce or CollideAgainstMove and the method test results in an actual collision. The LastMoveCollisionReposition property can then be tested to obtain information about collision.

## Code Example - Determining the Collision Side on a Manual Collision

When two AxisAlignedRectangles collide the collision side can be determined rather easily. The following code determines the side that two rectangles collided on: Add the following using statements:

     using FlatRedBall.Math.Geometry;
     using Side = FlatRedBall.Math.Collision.CollisionEnumerations.Side;

Assuming rectangle1 and rectangle2 are valid AxisAlignedRectangles:

      Side side = Side.None;

      if (rectangle1.CollideAgainstMove(rectangle2, 0, 1))
      {
          if (rectangle1.LastMoveCollisionReposition.X > 0)
              side = Side.Right;
          else if (rectangle1.LastMoveCollisionReposition.X < 0)
              side = Side.Left;
          else if (rectangle1.LastMoveCollisionReposition.Y > 0)
              side = Side.Top;
          else if (rectangle1.LastMoveCollisionReposition.Y < 0)
              side = Side.Bottom;
      }

## Common Usage

### Manual Ground Collision in Platformers

The following code can be used in a platformer to detect if a character is on the ground.

    // Assumes that character is an Entity that has a Collision shape property and
    // that LevelCollision is a valid ShapeCollection
    if(character.Collision.CollideAgainstBounce(LevelCollision, 0, 1, 0))
    {
       // There has been a collision
       bool wasRepositionedUpward = character.Collision.LastMoveCollisionReposition.Y > 0;

       // If the character was repositioned upward, then that means it was on a surface
       character.IsOnGround = wasRepositionedUpward;
    }
    else
    {
       // Since no collision occurred, the player isn't on the ground
       character.IsOnGround = false;
    }

This code uses the [CollideAgainstBounce](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce.md "FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce") method. For more information on this method, see [this page](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce.md "FlatRedBall.Math.Geometry.Circle.CollideAgainstBounce"). Let's look at the individual pieces of code above to see what is happening. The first line is:

    if(character.Collision.CollideAgainstBounce(LevelCollision, 0, 1, 0))

This line of code tests to see if the character's collision (which we assume is a circle) collides against the "LevelCollision" which can be any shape or an entire [ShapeCollection](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.md "FlatRedBall.Math.Geometry.ShapeCollection"). This method does the following:

-   It adjusts the velocity of the calling object (the character in this case) so that it is no longer falling. This prevents gravity accumulation errors.
-   It adjusts the calling shape's (the character.Collision in this case) LastMoveCollisionReposition.
-   It returns whether a collision has occurred.

So, as we can see, this first if-statement does \*a lot\*. Well, the most important thing initially is knowing \*if\* a collision has occurred. If it does, then we proceed to the body of the if-statement to find out if the player is actually on the ground. The next line of code is:

    bool wasRepositionedUpward = character.Collision.LastMoveCollisionReposition.Y > 0;

This line of code tells us whether the collision that occurred should be treated as a ground collision. The reason this works is because "move" and "bounce" collision methods move the calling objects so they no longer overlap. For more information on how this works, check [this page](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove#Understanding_the_CollideAgainstMove_Implementation.md "FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove").![CollideAgainstMoveReposition.png](/media/migrated_media-CollideAgainstMoveReposition.png) If the player is standing on the ground, then gravity will move the player "into the ground", but the CollideAgainstBounce method will separate the two - repositioning the Circle. If the player is on the ground, then this position is vertical; in other words, it has a Y value of greater than 0. By contrast, if the character is jumping and hits the ceiling with his head, then he will be repositioned downward; the Y value will have a value less than 0. Finally we assign this value to our character's IsOnGround property:

    character.IsOnGround = wasRepositionedUpward;

In this code we assume that character is an Entity that you've created that has an IsOnGround property. IsOnGround is a property that you must create in your Entity - either in custom code or as a new variable in Glue. Of course, you can store this information however you'd like; we've just presented the most common way if using Entities.

### Manually recording LastMoveCollisionReposition

The LastMoveCollisionReposition property gives you the reposition of the last shape that a given shape has collided against. This information may not be very useful if you are colliding against a collection of shapes. In this case, you may want to manually keep track of your collision reposition:

    Vector3 positionBefore = myEntity.Position;
    CollideEntityAgainstEverything( myEntity );
    Vector3 collisionReposition = myEntity.Position - positionBefore;
