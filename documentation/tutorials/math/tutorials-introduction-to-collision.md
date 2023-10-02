# tutorials-introduction-to-collision

### Introduction

The term "collision" in game development refers to both detecting whether objects are touching as well as changing the state of these objects when this touching occurs. Virtually any game ever made requires some type of collision. For example, Pong used ball vs. paddle collision and Super Mario Bros. performs collision between Mario and the ground to test whether he should fall or not. Even games which might not seem to use collision likely do. For example, mouse-driven adventure games like [King's Quest VI](http://en.wikipedia.org/wiki/Search?search=King%27s%20Quest%20VI%3A%20Heir%20Today%2C%20Gone%20Tomorrow) used collision to detect whether the cursor is overlapping certain areas when clicking. The only games free from collision are pure text-based games, but it's likely that if you're working on one of those you probably won't need to use FlatRedBall.

### FlatRedBall collision terminology

Before we get into how FlatRedBall handles collision, let's cover some basic terminology.

#### Collision

We've already discussed what a collision is, so let's give some examples. The following image shows three situations and labels whether a collision is occurring: ![CollisionExamples.png](../../../media/migrated\_media-CollisionExamples.png) Notice that collision doesn't just occur if the edges of two objects are touching. When FlatRedBall performs collision, it considers objects to be "solid". Therefore, if one object is inside of another, a collision is still occurring.

#### "Move" collision

A move collision is a collision where one or both of the involved shapes are repositioned during the collision to prevent overlap. The term "move" was selected because this type of collision can result in the shapes moving to new positions. The amount that each shape is moved depends on their masses relative to each other. It is very common to make one object static by giving it a non-zero mass and giving the other object a mass of zero. The following image shows the result of a move collision assuming that the rectangle is static and the circle is not. ![MoveCollision.png](../../../media/migrated\_media-MoveCollision.png) To use FlatRedBall terms, move collisions will adjust the position of the involved shape(s) if a collision does occur.

#### "Bounce" collision

A "bounce" collision is a collision which can be used to simulate physics. As the name implies, bounce collisions cause objects to bounce against each other. Just like move collisions, bounce collisions use the masses of two objects to calculate how the forces from the bounce should be applied. Just like with move collisions, it is common to have one object in a bounce collision have a non-zero mass while the other has a mass of zero. This causes one of the shapes (the one with the non-zero mass) to not be affected by the collision. ![BounceCollisionExample.png](../../../media/migrated\_media-BounceCollisionExample.png)

#### Shape

You're probably pretty familiar with the word "shape". In FlatRedBall, shape defines a shape like a square, triangle, or circle. To be a little more precise, a shape is an object which is a [PositionedObject](../../../frb/docs/index.php), has collision methods, and is managed by the [ShapeManager](../../../frb/docs/index.php) class. You may also be expecting there to be a Shape interface or class that all shapes implement. Actually, there isn't such an interface or class. The reason for this is performance. Initial performance measurement tests in FlatRedBall showed that the majority of time spent in collision loops is the actual method calls. In other words, we compared the amount of time required to call collision methods to the amount of time calling "empty" methods and over half of the time was spent in the method call. Of course this ratio can fluctuate depending on the complexity of the collision method and the frequency of collision occurrence. However, making a method virtual makes the method call itself take longer than otherwise, and we decided to give up the convenience of a base class for better performance. FlatRedBall provides a number of shape classes, and this list may continue to grow as more sophisticated collision needs are satisfied. If you'd like to find out which shape classes are available, check out the [ShapeManager](../../../frb/docs/index.php) page.

### Shapes and Visible Objects

Most games use [Shapes](../../../frb/docs/index.php) to detect whether collision is occurring; however, not all games keep collision [Shapes](../../../frb/docs/index.php) visible. Therefore, it is likely that your game will use [Shapes](../../../frb/docs/index.php) for collision and another type of object for drawing (such as [Sprites](../../../frb/docs/index.php) or [PositionedModels](../../../frb/docs/index.php)). In this situation, the [Shapes](../../../frb/docs/index.php) that you use will approximate the collidable area of your visible object. In some cases simple [Shapes](../../../frb/docs/index.php) such as [Circles](../../../frb/docs/index.php) and [AxisAlignedRectangles](../../../frb/docs/index.php) will be sufficient. In cases where more complex collision shapes are needed, the [Polygon](../../../frb/docs/index.php) object is a good alternative. In more complex situations (such as when using [SpriteRigs](../../../frb/docs/index.php)), multiple Shapes can be used.

### Shapes can be Visible

As you'll see in the next sections where we begin writing some sample code, Shapes have a Visible property which can be used to control whether the FlatRedBall Engine draws them. In the following examples the [Shapes](../../../frb/docs/index.php) that are created through the [ShapeManager](../../../frb/docs/index.php) will automatically be set to be Visible. When using Shapes only for collision and attaching them to other objects, it is not necessary to create them through or add them to the [ShapeManager](../../../frb/docs/index.php). Keep this in mind as you read other documentation about [Shapes](../../../frb/docs/index.php).

### CollideAgainst

Collision can be detected between shapes simply by calling CollideAgainst. The following code example creates two [Circles](../../../frb/docs/index.php). One [Circle](../../../frb/docs/index.php) is positioned at the point of the mouse. If a collision occurs, the moving Circle becomes orange. Otherwise, it is blue. Add the following using statements:

```
using FlatRedBall.Math.Geometry;
```

Add the following at class scope:

```
Circle firstCircle;
Circle secondCircle;
```

Add the following to Initialize after initializing FlatRedBall:

```
firstCircle = ShapeManager.AddCircle();
firstCircle.X = -10;
secondCircle = ShapeManager.AddCircle();
```

Add the following to Update:

```
firstCircle.X = InputManager.Mouse.WorldXAt(0);
firstCircle.Y = InputManager.Mouse.WorldYAt(0);

if (firstCircle.CollideAgainst(secondCircle))
{
    firstCircle.Color =
        Color.Orange;
}
else
{
    firstCircle.Color =
        Color.Blue;
}
```

![CollidingCircles.png](../../../media/migrated\_media-CollidingCircles.png)

**WARNING:** The code above may not compile because the Color struct is not qualified (the code doesn't know which namespace it is in). Which "using" statement you add to your code depends on which version of FlatRedBall you are using. For more information, see the [Color](../../../frb/docs/index.php) page.

The CollideAgainst method is a method that only returns whether collision has occurred - it does not modify the calling [Shape](../../../frb/docs/index.php) or the argument [Shape](../../../frb/docs/index.php). The following sections describe methods which do.

### CollideAgainstMove

The CollideAgainstMove method returns a true or false depending on whether the calling [Shape](../../../frb/docs/index.php) and the argument [Shape](../../../frb/docs/index.php) are touching. This method also modifies the Position of one or both [Shapes](../../../frb/docs/index.php). Keep in mind that since this method modifies the Position, we should **not directly modify the Positions** as well. Doing so would result in the CollideAgainstMove and our own code both attempting to control the Position of the involved [Shapes](../../../frb/docs/index.php). While this won't cause a crash, it may result in unexpected or undesirable behavior. In most cases where CollideAgainstMove is used, the [Shapes](../../../frb/docs/index.php) involved (or their Parent [Entities](../../../frb/docs/index.php)) are controlled either by Velocity or Acceleration. We'll use Velocity for the following example: Use the same using statements, class-level declarations, and Initialize code as above, then replace the custom Update logic with the following:

```
InputManager.Keyboard.ControlPositionedObject(firstCircle);

// We use equal masses here so that each is moved the same
// amount.  You can change these values to achieve different
// relative masses.
firstCircle.CollideAgainstMove(secondCircle, 1, 1);

base.Update(gameTime);
```

The first "1" argument is the mass of the first object. The second "1" is the mass of the second object. Try changing the first argument to 0. This will make secondCircle immovable. Then try changing the first argument back to 1, then the second to 0. This will make the moving circle unaffected by secondCircle.

### [CollideAgainstBounce](../../../frb/docs/index.php)

The third method that we'll look at is [CollideAgainstBounce](../../../frb/docs/index.php). The [CollideAgainstBouncegives](../../../frb/docs/index.php) us all of the same functionalty as CollideAgainstMove( true/false return value as well as repositioning), but it also modifies the involved [Shapes'](../../../frb/docs/index.php) Velocity values. For bouncing to behave properly, we have to make sure that we're not controlling the involved [Shapes'](../../../frb/docs/index.php) **position or velocity**. Therefore, this leaves us with controlling acceleration. To use [CollideAgainstBounce](../../../frb/docs/index.php), simply replace your custom Update code with the following:

```
InputManager.Keyboard.ControlPositionedObjectAcceleration(firstCircle, 10);

// We use equal masses here so that each is moved the same
// amount.  You can change these values to achieve different
// relative masses.
firstCircle.CollideAgainstBounce(
    secondCircle,
    1,// firstCircle mass
    1,// secondCircle mass
    1); // elasticity
```

Now the two Circles will collide against each other and bounce. Of course, you will probably notice that this setup results in secondCircle being moved off of the screen very quickly. You may want to change the firstCircle's mass to 0 to keep the secondCircle on screen so you can test multiple collisions.

### Want to learn more?

This article covers a lot of information about collisions; however, this topic has a lot of depth. To find out more, start at the [ShapeManager](../../../frb/docs/index.php) page and follow the links to the information you're interested in.
