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

This concept is important for two reasons. First, comparing "opposite" edges is ultimately how we can detect if collisions occurred. Seconc, we will use these "opposite" edge distances later to determine how to separate rectangles.

Of course, we cannot detect a collision only by using one edge. The right-side of the blue rectangle could be further to the right (have a greater X value) than the left-side of the pink, but there may not be a collision, as shown in the following image:

CONTINUE HERE
