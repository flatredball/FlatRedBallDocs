# Collision Jitter

### Introduction

Bouncing collision is a common behavior which has been implemented in the earliest of games including the ball bouncing off paddles and walls in Pong, the ball bouncing off of blocks in Breakout, and the fireballs bouncing off of terrain in Super Mario Bros. [http://www.ordiworld.com/jargon/fig/pong.gif](http://www.ordiworld.com/jargon/fig/pong.gif) [http://www.consoleclassix.com/info\_img/Breakout\_2600\_ScreenShot2.jpg](http://www.consoleclassix.com/info\_img/Breakout\_2600\_ScreenShot2.jpg) [http://img67.photobucket.com/albums/v205/LBoogie82583/Screenshots/SMB1.jpg](http://img67.photobucket.com/albums/v205/LBoogie82583/Screenshots/SMB1.jpg) While this behavior appeared early in video games it can present some challenges. Collision jitter is one of these challenges which often appears when first implementing bouncing collision behavior. This article discusses what collision jitter is and common solutions.

### Simple Bouncing Collision Example

The first step to understanding collision jitter is to understand bouncing collision code. I will use a simple ball vs. axis aligned rectangle example and ignore the possibility of the ball hitting the corners. I will assume that I have a method which returns the side on which the collision has occurred.

```
if(ball.CollideAgainst(rectangle))
{
   // This is not a FlatRedBall call, but I'll pretend it is for simplicity
   Side side = ball.SideOn(rectangle);
   if(sideOn == Side.Right || sideOn == Side.Left)
   {
       // Collided on the left or right side so invert the XVelocity.
       ball.XVelocity *= -1;
   }

   if(sideOn == Side.Top || Side.Bottom)
   {
       // Collided on the top or bottom side so invert the YVelocity.
       ball.YVelcity *= -1;
   }
}
```

This code seems like it should work but it is possible that it will result in collision jitter especially if the game is not running at a fixed frame rate.

### What Causes Collision Jitter

Collision jitter occurs when a moving object bounces off of another object, but it is either not repositioned after the collision or the following frame is not long enough to move the moving object outside of the other object. This results in another collision the following frame which inverts the velocities so that the moving object is once again moving towards the other object. ![CollisionSecondFrameLongerOrEqual.png](../../.gitbook/assets/migrated\_media-CollisionSecondFrameLongerOrEqual.png) Scenario A and B show two situations in which the collision code works successfully. In scenario A the ball moves inside the rectangle, its velocity is inverted, and the following frame is long enough to move the ball back out of the rectangle. Scenario B is almost the same. The only difference is that the second frame is longer than the first frame. This is not a problem because the ball is again moved out far enough to not trigger another collision next frame. ![CollisionSecondFrameShorter.png](../../.gitbook/assets/migrated\_media-CollisionSecondFrameShorter.png) Scenario C shows how jitter occurs. The first frame moves the ball into the object and its YVelocity is inverted. Unlike scenarios A and B, the next frame happens too quickly for the ball to move out of the square (C1). This results in collision triggering the next frame which again inverts the velocity (C2). Depending on the frame times the ball may jitter for a short amount of time or it may become permanently stuck in the rectangle. Regardless this can be disruptive to gameplay and can even result in the ball passing through the rectangle.

### Solutions for Collision Jitter

The most obvious solution to collision jitter is to have a constant frame rate. While the default FlatRedBall XNA template does provide a constant frame rate which reduces the likelihood that this will occur, it is not a 100% solution. Due to floating point inaccuracies it is still possible to trigger a collision.

#### Repositioning After Collision

One common solution to jitter is to reposition the moving object after collision so that there is no overlap. ![Reposition.png](../../.gitbook/assets/migrated\_media-Reposition.png) The code for this would be as follows:

```
if(ball.CollideAgainst(rectangle))
{
   // This is not a FlatRedBall call, but I'll pretend it is for simplicity
   Side side = ball.SideOn(rectangle);
   if(sideOn == Side.Right)
   {
       ball.X = rectangle.X - rectangle.ScaleX - ball.Radius;
       ball.XVelocity *= -1;
   }

   if(sideOn == Side.Left)
   {
       ball.X = rectangle.X + rectangle.ScaleX + ball.Radius;
       ball.XVelocity *= -1;
   }

   if(sideOn == Side.Top)
   { 
       ball.Y = rectangle.Y - rectangle.ScaleY - ball.Radius;
       ball.YVelcity *= -1;
   }

   if(sideOn == Side.Bottom)
   {
       ball.Y = rectangle.Y + rectangle.ScaleY + ball.Radius;
       ball.YVelcity *= -1;
   }
}
```

#### Selectively Inverting Velocity

Another solution is to invert velocity only when appropriate. Although this doesn't stop two consecutive collisions from being triggered it does prevent the jittering motion. ![InvertingVelocitySelectively.png](../../.gitbook/assets/migrated\_media-InvertingVelocitySelectively.png) Conceptually velocity should only be inverted if the moving object is moving into the other object. The following guarantees that the resulting velocity will move the circle out of the rectangle:

```
if(ball.CollideAgainst(rectangle))
{
   // This is not a FlatRedBall call, but I'll pretend it is for simplicity
   Side side = ball.SideOn(rectangle);
   if(sideOn == Side.Right)
   {
       ball.XVelocity = -1 * System.Math.Abs(ball.XVelocity);
   }

   if(sideOn == Side.Left)
   {
       ball.XVelocity = System.Math.Abs(ball.XVelocity);
   }

   if(sideOn == Side.Top)
   { 
       ball.YVelcity = -1 * System.Math.Abs(ball.YVelocity);
   }

   if(sideOn == Side.Bottom)
   {
       ball.YVelcity = System.Math.Abs(ball.YVelocity);
   }
}
```
