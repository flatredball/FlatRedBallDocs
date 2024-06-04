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

In Progres....
