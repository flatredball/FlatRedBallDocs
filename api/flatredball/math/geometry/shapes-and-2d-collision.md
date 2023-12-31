# Shapes and 2D Collision

### Introduction

The 2D shapes in the FlatRedBall.Math.Geometry namespace provide useful methods for detecting and reacting to collisions. The following lists the 2D shapes:

* [AxisAlignedRectangle](../../../../frb/docs/index.php)
* [Capsule2D](../../../../frb/docs/index.php)
* [Circle](../../../../frb/docs/index.php)
* [Line](../../../../frb/docs/index.php)
* [Polygon](../../../../frb/docs/index.php)

These objects provide methods for performing collision against one another. While these objects can be positioned and in some case rotated in 3D space, the collisions they perform are limited to 2D. When two shapes perform collision methods, they ignore their Z values. Mathematically speaking, shapes are projected onto the XY plane, then the projections perform collision against each other. Therefore, if two shapes may appear to not be touching visibly, their collision methods may still indicate that collisions are occurring if they are overlapping each other.

### Collision Methods

| Collision Method     | Returns true/false | Changes Position to resolve overlapping | Changes Velocity to simulate bouncing |
| -------------------- | ------------------ | --------------------------------------- | ------------------------------------- |
| CollideAgainst       | X                  |                                         |                                       |
| CollideAgainstMove   | X                  | X                                       |                                       |
| CollideAgainstBounce | X                  | X                                       | X                                     |

### CollideAgainst Methods

All shapes provide various CollideAgainst methods which can be used to check if two shapes are colliding and to adjust their position and velocity values to resolve the collision (to apply physics).

In most cases these methods are not called explicitly. Rather, these methods are called by CollisionRelationships which are created through the FlatRedBall Editor. However, there are times when these methods may be called directly in custom code. Common examples include:

1. To do additional checks inside a collision event handler for custom sub-collision. For example, to determine if a bullet has hit an enemy's weak point.
2. To perform collision in custom code where no collision relationships exist. For example, in a code-only project, or in a test project which is not using the FlatRedBall editor for most of its setup.
3. When modifying the FlatRedBall Engine, or when performing very high-performance logic.

Collision methods can be performed between collision shapes of the same type, or of mixed type. The most efficient form of collision is Circle vs Circle and AxisAlignedRectangle vs AxisAlignedRectangle. Mixing types, such as Circle vs AxisAlignedRectangle, is a slower form of collision. Polygon collision is slower than Circle and AxisAlignedRectangle regardless of whether it is mixed or Polygon vs Polygon.

Of course, even the slower collision methods tend to be fast enough for most real-world game development scenarios, especially when used in CollisionRelatoinships which are partitioned.&#x20;
