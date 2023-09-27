## Introduction

The DrawsShapes property can be used to control whether the Camera will render any shapes (such as [Polygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon") and [Circles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle")). This is on by default, and can be turned off to hide all shape rendering.

## Common Usage

Shapes are often used for collision, and their visible representation can be useful in debugging. Shapes can be easily turned off for non-debug builds as follows:

    #if DEBUG
        SpriteManager.Camera.DrawsShapes = true; // <- This is the default so not necessary, but it's more expressive
    #else
        SpriteManager.Camera.DrawShapes = false;
    #endif
