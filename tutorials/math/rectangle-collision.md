# Rectangle Collision

### Introduction

This page discusses the details of how rectangle collision works in games. If you are using FlatRedBall, then rectangle collision is handled for you automatically through the [AxisAlignedRectangle](../../glue-reference/objects/object-types/glue-reference-axisalignedrectangle.md) object. If you would like more information about how rectangle collision works in FlatRedBall, or if you would like to implement your own rectangle collision, this page provides a deep dive on rectangle collision.

### Defining a Rectangle

For this discussion we will assume that rectangles are _axis aligned_ (not rotated). Also, rectangles can be defined either by their center point (as is the case with FlatRedBall AxisAlignedRectangle) or by their top-left corner (as is the case the MonoGame Rectangle struct).

For this discussion we will use the MonoGame Rectangle struct, although the concepts are similar for FlatRedBall.

Specifically we will be using the following properties:

* Top
* Bottom
* Left
* Right

These properties clear the ambiguity that comes from using X and Y for a Rectangle.

### Detecting Collision

Conceptually two rectangles are colliding if they overlap, otherwise they are considered not overlapping. Two rectangles may touch one another but this is not considered a collision, although in practical terms if rectangles are positioned using `float` values, then whether they overlap or not may be subject to floating point inaccuracy. For this discussion we'll ignore floating point inaccuracy.

<figure><img src="../../.gitbook/assets/image (125).png" alt=""><figcaption><p>Example of rectangle collisions based on position</p></figcaption></figure>

Visually it can be easy to identify if two rectangles are colliding. Logically we need to perform checks to see if they overlap.

To understand the logic, let's focus specifically on the collided case from the image above.

In this case, the right-side of the blue rectangle is further to the right than the left side of the pink rectangle.

<figure><img src="../../.gitbook/assets/image (126).png" alt=""><figcaption><p>Blue right side further to the right than the pink left side</p></figcaption></figure>

In fact, it is impossible for two rectangles to collide without this being the case. Any situation where the two rectangles collide must have the blue rectangle be further to the right than the left side of the pink rectangle.

<figure><img src="../../.gitbook/assets/image (127).png" alt=""><figcaption><p>More rectangle collisions showing right side of blue being further to the right than the left side of pink</p></figcaption></figure>

This concept is important for two reasons. First, comparing "opposite" edges is ultimately how we can detect if collisions occurred. Second, we will use these "opposite" edge distances later to determine how to separate rectangles.

Of course, we cannot detect a collision only by using one edge. The right-side of the blue rectangle could be further to the right (have a greater X value) than the left-side of the pink, but there may not be a collision, as shown in the following image:

<figure><img src="../../.gitbook/assets/image (129).png" alt=""><figcaption><p>Blue right is greater than pink left, but collision does not occur here</p></figcaption></figure>

Therefore, for collision to be checked, we must actually check all four sides. Conceptually the checks are:

* Blue right must to the right of pink left
* Blue left must to the left of pink right
* Blue top must be above pink bottom
* Blue bottom must be below pink top

If all four of these conditions are true, then a collision has occurred. In code, this would look like this:

```csharp
var didCollisionOccur = 
    blue.Right > pink.Left &&
    blue.Left < pink.Right &&
    // XNA rectangle uses positive-Y-points-down
    blue.Top < pink.Bottom &&
    blue.Bottom > pink.Top;
```

As mentioned in the comments notice that positive Y points down when using XNA (MonoGame/FNA) rectangles. If using FlatRedBall shapes, the top/bottom checks would be inverted to account for it using positive Y as up.

### Separating Rectangles

Detecting whether a collision has occurred is the first step in resolving collisions. For many games, the next step is to separate the rectangles so that they no longer overlap.

For this section we will assume that the logic for the code is as follows:

1. Move an object (apply velocity to change its position)
2. Detect whether collision has occurred
3. If collision has occurred, separate the objects to prevent overlapping

Visually, this may look like this:

<figure><img src="../../.gitbook/assets/image (130).png" alt=""><figcaption><p>Visualizing the steps of collision</p></figcaption></figure>

Of course, all of the three steps happen in one frame, so from the user's point of view they only see the rectangle move from position A to position B, as shown in the following image:

<figure><img src="../../.gitbook/assets/image (131).png" alt=""><figcaption><p>What the player sees when a collision occurs</p></figcaption></figure>

We talked about how to detect whether collision has occurred (step 2), so now we need to determine how to reposition the rectangle (step 3).

If we take a look at the collision, it probably makes sense to us that the rectangle is repositioned by moving "up" - after all, the blue rectangle came from above, so it should end up resting on the pink rectangle. But the question is - why should the rectnagle move straight up? In other words, why do we choose to move the rectangle into position A in the diagram below? Note that the rectangle sizes have been made smaller to help with visualization:

<figure><img src="../../.gitbook/assets/image (132).png" alt=""><figcaption><p>Possible repositions</p></figcaption></figure>

There are a few ways to answer this question. The first question is - when separating two shapes, the shapes should be moved by the _shortest distance possible_ to resolve the separation. In other words, moving to A requires moving the blue rectangle the shortest possible distance - moving to B or C requires moving a longer distance.

Another way to look at it is - when we move the blue rectangle, we should move the rectangle _perpendicular_ to the surface with which it collided. In other words, the direction that we move the rectangle should create a _right angle_ with the surface, as shown in the following diagram:

<figure><img src="../../.gitbook/assets/image (133).png" alt=""><figcaption><p>Showing movement perpendicular to the surface</p></figcaption></figure>

Knowing that the rectangle must move perpendicular to the surface means that the rectangle can cannot be moved diagonally, as shown in the diagram above with movements A, B, and C, at least when colliding with a surface that is perfectly vertical or horizontal, as will be the case with an _axis aligned_ (unrotated) rectangle.

Since the rectangle can move only in one of four directions, then that means that any collision can only be resolved by moving the blue rectangle to one of four spots. For example, if the blue rectangle falls inside of the pink rectangle, then there are four possible ways to resolve the overlap as shown in the following diagram:

<figure><img src="../../.gitbook/assets/image (134).png" alt=""><figcaption><p>Four possible collisions</p></figcaption></figure>

Of course we can tell just by looking at the diagram that the correct way to resolve the overlap would be to move the rectangle to A - because that's the shortest distance.

<figure><img src="../../.gitbook/assets/image (135).png" alt=""><figcaption><p>Repositioning the rectangle up since it's the shortest distance</p></figcaption></figure>

Of course, visually identifying the shortest distance is easy, but we need to write code that can do it.

We can modify our code from above to both detect and also provide the _separation vector_ - a vector which can be used to move the blue rectangle so that it no longer overlaps the pink rectangle:

```csharp
// If any of these values are positive, then we have overlap:
var rightOverlap = blue.Right - pink.Left;
var leftOverlap = pink.Right - blue.Left;
var topOverlap = blue.Bottom - pink.Top;
var bottomOverlap = pink.Bottom - blue.Top;

Vector2 repositionVector = Vector2.Zero;

if(rightOverlap > 0 || leftOverlap > 0 || topOverlap > 0 || bottomOverlap > 0)
{
    // let's take a look at which is the smallest:
    var smallest = rightOverlap;
    repositionVector = new Vector2(-rightOverlap, 0);
    
    if(leftOverlap < smallest)
    {
        smallest = leftOverlap;
        repositionVector = new Vector2(leftOverlap, 0);    
    }
    
    if(topOverlap < smallest)
    {
        smallest = topOverlap;
        repositionVector = new Vector2(0, -topOverlap);
    }
    if(bottomOverlap < smallest)
    {
        smallest = bottomOverlap;
        repositionVector = new Vector2(0, bottomOverlap);
    }
    

}

// We can move our object by the repositionVector to resolve the overlap
```

### Repositioning and Tunneling

The method of repositioning explained above is used to reposition an object so that it is pushed back when overlapping. Most of the time this approach is sufficient, but sometimes this approach can result in issues which are referred to as collision tunneling.

Collision tunneling occurs when a moving object moves so fast that it overlaps another object in a way that causes it to be pushed out the other side.

For example, consider the following diagram:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Typical movement and collision reposition</p></figcaption></figure>

The diagram above shows a typical movement and reposition. This results in the blue rectangle being repositioned to the left, so that it rests along the left side of the pink polygon. however, if the blue polygon were moving even faster, it might cross over the halfway point of the pink polygon resulting in collision tunneling, as shown in the following diagram:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Collision tunneling</p></figcaption></figure>

From the player's point of view this all happens in one frame, so the collision seems to "pop" out of the other side.

This problem can be difficult to solve in a general way, especially when dealing with more complex shapes. The following options exist as solutions:

* Limit the movement of your objects to make collision tunneling less likely
* Increase the thickness of collision areas, especially boundaries surrounding your level
* Increase the "physics framerate" so that collision is performed more frequently
* Perform ray-casting or collision between elongated shapes
* Add additional checks such as whether a shape that was repositioned started and ended on the same side (X or Y)
