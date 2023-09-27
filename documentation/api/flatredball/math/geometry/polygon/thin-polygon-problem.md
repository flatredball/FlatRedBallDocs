## Introduction

The "thin Polygon problem", also known as collision tunneling, is a collision bug that is very commonly collision problem. As the name suggests, this bug occurs when dealing with thin shapes. Although we use Polygons in this discussion, it applies to AxisAlignedRectangles as well. This bug manifests itself in one of three ways:

1.  Moving objects completely pass through Polygons. This is known as "tunneling".
2.  Moving objects becoming stuck inside polygons.
3.  Moving objects touching and being moved to an unexpected location on the surface of the Polygon.

**Tunneling also exists with other shapes:** Although this article talks specifically about Polygons, tunneling is a problem that exists with all other shape types and is not limited to Polygons. In fact, the incremental movement that is used in FlatRedBall which leads to tunneling is a general problem in game development, and the term "tunneling" is not a term which is simply used in FlatRedBall. If you are experiencing objects falling-through or passing-through other objects, this article may help you solve your problems - even if you're not using Polygons.

Of course you may be wondering "what defines thin?" Whether a Polygon is thin or not depends on the distance between lines of a Polygon relative to the velocity of objects that will collide against the Polygon. For example, if you have have a rectangle-shaped Polygon that is 1 unit thick, you probably will not experience any collision problems when an object moving at .1 units per second collides against your Polygon. If, on the other hand, the moving object is moving at 60 units per second, you will almost certainly see this bug.

## Why the thin Polygon problem exists

The FlatRedBall collision system is a "historyless" collision system. This means that the collision performed at any given time does not consider the previous positions of objects. This approach has its benefits - it uses less memory, is slightly faster, and is very flexible. Of course, this can result in the bug discussed in this article. Let's look at an example of why a historyless collision system can result in tunneling ![TunnelingA.png](/media/migrated_media-TunnelingA.png) Frame A shows a yellow ball (could be any shape really) falling towards a light-blue surface. In this example we'll assume that the ball is traveling at a very high speed. There is no collision for frame A, so the ball continues to fall normally. ![TunnelingB.png](/media/migrated_media-TunnelingB.png) Because the ball traveled so quickly, it has nearly moved completely through the surface in one frame. Since FlatRedBall does look at the ball's position in frame A (it's historyless), the collision that it performs results in what we see in frame C: ![TunnelingC.png](/media/migrated_media-TunnelingC.png) If you were to look only at frame B without looking at frame A, you may also prefer the end-position resulting in C.

## Solutions to the thin Polygon problem

Fortunately there are a number of solutions to the thin polygon problem. Which you employ depends on the type of problem you're seeing and what kind of options you have from the genre of game you're developing.

### Wider Polygons

The first solution to the thin polygon problem is to simply make your objects not move as fast. This will resolve tunneling in almost every situation. However, this may not be an option for you because of the type of game you are developing. If you are making a racing game, then you may not want to slow the cars down just to resolve this issue (and you shouldn't either!). Of course, as we mentioned above, these problems occur when the speed of the colliding object is high relative to the \*width\* of the polygon. In other words, you can usually solve these problems by simply making your collision areas wider. This is especially effective if the borders of your game mark the absolute boundaries that the player can occupy. In other words, if your game takes place inside a room and the player can't walk outside of the room, then you can widen the walls to virtually any size you'd like to prevent tunneling.

### Increasing the frame rate

Increasing the frame rate of your game by reducing the [Game's TargetElapsedTime](/documentation/api/microsoft-xna-framework/microsoft-xna-framework-game/microsoft-xna-framework-game-targetelapsedtime.md "Microsoft.Xna.Framework.Game.TargetElapsedTime") is an effective but very expensive approach to solving this problem. More information on this can be found [here](/frb/docs/index.php?title=Microsoft.Xna.Framework.Game.TargetElapsedTime "Microsoft.Xna.Framework.Game.TargetElapsedTime").

### Multiple collision calls per frame

One solution which simulates increasing the frame rate, but isolates the performance impact to the code you are working with is to have your colliding objects (Entities) keep track of their last-frame position, then subdivide the distance they've traveled in one frame into smaller segments, and performing collision tests at each point. At a high level here are steps on how to do the collision tests:

1.  In your Entity object which must perform multiple collisions, mark its position at the end of the Update method.
2.  At the beginning of the frame, compare subtract the last position from the current position to identify the distance traveled.
3.  Determine how much you want to subdivide your frame.
4.  Write a loop as follows:

&nbsp;

    for(int i = 0; i < numberOfSubdivisions; i++)
    {
      float ratioIntoFrame = i / (float) numberOfSubdivisions;
      Vector3 positionAtRatio = entityTesting.LastFramePosition + ratioIntoFrame * distanceTraveled;
      entityTesting.Position = positionAtRatio;
      // perform your collision now  
    }

### Limiting movement speed

One of the most common situations where tunneling exists is in platformers that use YAcceleration for gravity. The reason this can cause so many problems is because the speed that the distance that the game character falls impacts how fast the character hits the ground. If your game includes large drops, you may notice that the character sometimes falls through the world when falling long distances. Most professionally-made platformers include a maximum falling speed for game play reasons. Implementing this maximum falling speed (also known as "terminal velocity") can both improve the feel of your game as well as possibly solve tunneling. For a discussion on how to limit falling speed, [see this article](/frb/docs/index.php?title=Tutorials:Platformer:Limiting_Falling_Speed "Tutorials:Platformer:Limiting Falling Speed").

## Sweeping Shape Collision

Depending on the shape of your object you may be able to create a swept shape. The Capsule2D class is a useful shape for testing collisions of circles. You can also create your own Polygons or Lines to check if a collision occurred between two frames. If a collision did occur you may need to "rewind time" and subdivide the last frame to get more accurate results.

### Subdividing your Polygon

So far we've talked about tunneling issues, but there are also situations where two polygons may report a collision, but not separate correctly. This occurs in the [example that uses the smiley polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon#Loading_Polygons_from_File_.28.plylstx.29 "FlatRedBall.Math.Geometry.Polygon") if you move the moving Polygon to the edges of the mouth polygon. To solve this, you can add additional points to the smiley polygon in the PolygonEditor as described [here](/frb/docs/index.php?title=PolygonEditor:Tutorials:Tools_Window#Add_Point_Button "PolygonEditor:Tutorials:Tools Window").

## Using simpler shapes

The section above describes a situation where polygon collision error occurs even if the speed of the moving Polygon is very low. In general the simpler shapes have more accurate collision than Polygons. Therefore, replacing the moving Polygon with a Circle will improve the accuracy of collision - while improving performance at the same time.
