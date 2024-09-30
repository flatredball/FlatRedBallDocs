# Circle Collision

### Introduction

Although FlatRedBall XNA provides a [Circle](../../frb/docs/index.php) class for collisions, you may be interested in writing your own custom circle collision code for customizable behavior. What follows is a conceptual discussion of circle collision.

### Detecting Collision

The most basic form of collision returns true or false to indicate if two circles are touching. To keep things lightweight, consider a class Circle with three properties:

* X
* Y
* Radius

These properties are all we need to perform collisions between two circles. By definition circles are perfectly uniform. No point on the edge of a circle is any further from the center than any other point, and all points on the edge are the distance of the radius away from the center. This makes collision very simple. Conceptually, to perform a circle collision we compare the distance from the centers of the two circles and see if it's greater than the sum of the two radii (plural of radius). Given two circles, the following code determines whether they are touching:

```
// assume circle1 and circle2 are defined
float distanceBetweenCircles = 
  (float)System.Math.Sqrt(
    (circle2.X - circle1.X) * (circle2.X - circle1.X) + 
    (circle2.Y - circle1.Y) * (circle2.Y - circle1.Y)
  );

if(distanceBetweenCircles > circle1.Radius + circle2.Radius)
{
   // collision occurred!
}
```

That works well, but efficiency-minded programmers might realize the usage of the Sqrt function when calculating the distanceBetweenCircles. We could do the following to speed things up slightly:

```
// assume circle1 and circle2 are defined
float distanceBetweenCirclesSquared = 
    (circle2.X - circle1.X) * (circle2.X - circle1.X) + 
    (circle2.Y - circle1.Y) * (circle2.Y - circle1.Y);

if(distanceBetweenCirclesSquared > 
       (circle1.Radius + circle2.Radius)*(circle1.Radius + circle2.Radius))
{
   // collision occurred!
}
```

We simply square the sum of the circles' radii to avoid calling the more expensive square root method System.Math.Sqrt.

### Circle Move Collision

The next most common behavior performed when conducting collisions is known as "move" collisions in FlatRedBall. These collisions move objects when a collision occurs so that they no longer overlap. The first step is to understand the concept of how this works with circle collision. ![CircleMoveCollision.png](../../.gitbook/assets/migrated\_media-CircleMoveCollision.png)&#x20;

The image above shows a circle move collision before and after the repositioning occurs. In this example, the top circle stays static while the bottom circle moves to solve the overlapping. The blue dotted line is the line between the center of the two circles and the black line with arrows on the end outlines the distance which must be moved to solve the overlapping. To keep the circles from overlapping we need to find out the properties of the black line. More specifically we need to know the length and direction of that line. The most obvious relationship is that the black line lies directly on top of the line connecting the center of the two circles. In other words, the direction or angle of that line is the same as the direction or angle of the line connecting the center of the two circles. To calculate an angle, we'll use the System.Math.Atan2 method:

```
double angle = System.Math.Atan2( circle2.y - circle1.y, circle2.x - circle1.x);
```

Now we have our angle stored. Next, we need to calculate the distance that the circles need to move over. Remember from the previous example that if the distance between two circles is less than the sum of the radii, there is a collision. If the distance between two circles equals the sum of their radii, then the two circles will be barely touching, as in the image on the right. The following relationship is true as well:

```
distanceToMove = sumOfRadii - circleDistanceFromEachother;
```

If the distance between the circles is equal to the sum of the radii, notice that distanceToMove is 0. Therefore, to calculate the distance by which to move:

```
float distanceBetweenCircles = 
  (float)System.Math.Sqrt(
    (circle2.X - circle1.X) * (circle2.X - circle1.X) + 
    (circle2.Y - circle1.Y) * (circle2.Y - circle1.Y)
  );

float distanceToMove = circle1.Radius + circle2.Radius - distanceBetweenCircles;
```

At this point we have the angle and the distance by which to move the circles. To keep things simple, I'll just move circle2:

```lang:c#
circle2.X += (float)(System.Math.Cos(angle) * distanceToMove);
circle2.Y += (float)(System.Math.Sin(angle) * distanceToMove);
```

### Circle Bounce Collision

Circle bouncing is a simple way to introduce basic physics into your game. While circle bouncing can be calculated with only trigonometry, linear algebra provides us with a cleaner and faster solution. Circle vs. circle bouncing collision is actually very similar to circle vs. flat surface collision. How is this so? Consider the following image:

![BouncingCircle.png](../../.gitbook/assets/migrated\_media-BouncingCircle.png)

If the moving circle bounces off of the circle at the bottom at the very top point, it will bounce as if it hit a flat surface. The same is true for any other point. Don't believe me? Look at the image and turn your head sideways. In more mathematical terms, the circle on top bounces off of the circle on the bottom as if it collided with a flat surface whose slope is defined by the [tangent](http://www.mathopenref.com/tangent.html) of the circle at the point of impact. Once we find the tangent at the point of collision, all we have to do is reflect the velocity on that tangent then assign the velocity to the bouncing circle. Now our problem is split into two smaller problems. Note that the previous two sections on determining collision and performing move collision will likely be used prior to performing the bouncing code. That is, you'll want to make sure your circles actually have collided, and you'll also want to separate them so that they don't get "stuck" together. Since we'll be using linear algebra to solve this problem, we'll define our tangent as a vector rather than a angle. There are a few ways to identify the point of impact for the collision, but for this example we'll simply assume the point of impact lies where a line drawn between the two circles touches the either of the circles. Since we've already performed our move, our scenario may look like this: ![PointOfImpact.png](../../.gitbook/assets/migrated\_media-PointOfImpact.png) Fortunately, the actual point of impact doesn't matter to us. Only the vector that is parallel to the tangent at that point. This is simple to calculate. The tangent is perpendicular to the line drawn between the center of two points. I will use XNA's Vector2 syntax for all Vector2's.

```
Vector2 tangentVector;

// Vector perpendicular to (x, y) is (-y, x)
tangentVector.Y = -( circle2.X - circle1.X );
tangentVector.X = circle2.Y - circle1.Y;
```

Once we have the vector parallel to the tangent of the circle at the point of impact we can reflect the velocity on this vector. To do this, we need to break the velocity vector into two vectors - the vector perpendicular to the tangent and the vector parallel to the tangent as shown in the following diagram. ![VelocityAsComponents.png](../../.gitbook/assets/migrated\_media-VelocityAsComponents.png) Finally, we take the component of the velocity vector that is perpendicular to the tangent, then subtract it twice from the original vector to get the new bounce vector as shown by the green line in the following diagram. ![VelocityVectorAfterBounce.png](../../.gitbook/assets/migrated\_media-VelocityVectorAfterBounce.png) If you're not familiar with linear algebra you may be wondering how to calculate the component of the velocity vector that is perpendicular to the tangent (the red line). Fortunately, this is relatively easy. We simply need to "project" the velocity vector on the tangent and that will give us the velocity vector component parallel to the tangent vector (orange line). For our projection to work correctly, the tangent vector must be normalized (have a length of 1).

```
Vector2.Normalize(ref tangentVector, out tangentVector);
```

Although the example I've shown so far highlights one circle which is moving bouncing off of another which is (and remains) stationary, this is not always the case. In fact, either circle could be moving. Fortunately we can generalize the code so that it will work regardless of who is moving and who is stationary:

```
Vector2 relativeVelocity = 
 new Vector2(circle2.Velocity.X - circle1.Velocity.X, 
             circle2.Velocity.Y - circle1.Velocity.Y);
```

Now performing the dot product of the relative velocity vector and the tangent vector gives us the length of the velocity component parallel to the tangent (the length of the orange).

```
float length = Vector2.Dot(relativeVelocity, tangentVector);
```

And we simply multiply the normalized tangent vector by the length to get the vector component parallel to the tangent (orange line).

```
Vector2 velocityComponentOnTangent;
Vector2.Multiply(ref tangentVector, length, out velocityComponentOnTangent);
```

Simply subtracting the velocity component parallel to the tangent (orange) from the relative velocity gives us the velocity component perpendicular to the tangent (red).

```
Vector2 velocityComponentPerpendicularToTangent =
    relativeVelocity - velocityComponentOnTangent;
```

Now we have all of the information necessary to perform the collision. At this point we can make some choices regarding how we want the collision to affect the circles. To make both circles bounce off of each other like pool balls after a collision, the velocity component perpendicular to the tangent (red line) should be applied to both. To make one circle move, it should be applied to it twice.

```
// This code makes both circles move.
circle1.Velocity.X -= velocityComponentPerpendicularToTangent.X;
circle1.Velocity.Y -= velocityComponentPerpendicularToTangent.Y;

circle2.Velocity.X += velocityComponentPerpendicularToTangent.X;
circle2.Velocity.Y += velocityComponentPerpendicularToTangent.Y;
```

To make just one circle move:

```
// This code makes just circle1 move.
circle1.Velocity.X -= 2 * velocityComponentPerpendicularToTangent.X;
circle1.Velocity.Y -= 2 * velocityComponentPerpendicularToTangent.Y;
```
