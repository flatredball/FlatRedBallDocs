# z

### Introduction

All FlatRedBall shapes inherit from the [PositionedObject](../../../../../../frb/docs/index.php) class, so they inherit the X, Y, Z, and Position properties. The Z value of shapes impacts their rendering, but not collision. In other words, shapes will render differently according to their Z value when rendering on a 3D camera, but they will collide as if their Z values are all the same.

### Position relative to the Polygon

The Position of the Polygon is a bit of an abstract concept because it may or may not represent the center of a Polygon. In fact, it may not even lie inside of a Polygon depending on how the Points values are set. If you use the [CreateEquilateral](../../../../../../frb/docs/index.php) or [CreateRectangle](../../../../../../frb/docs/index.php) functions, then the Position will represent the center of the Polygon. If you have constructed the Polygon yourself by setting the Polygon's [Points](../../../../../../frb/docs/index.php), then the Position value relative to points depends on the values you've assigned to [Points](../../../../../../frb/docs/index.php).

### Shape vs. non-Shape sorting

Shapes and non-Shapes which are on the same Layer (or which are all un-Layered) will not sort with each other. For more information see [the ShapeManager.ShapeDrawingOrder page](../../../../../../frb/docs/index.php).
