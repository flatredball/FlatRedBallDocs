## Introduction

As the name suggests, the SplineEditor can be used to create and edit Splines; however, you may be wondering what a Spline is. In simple terms, a Spline is a curved line which is created by a number of points. These points which are used to define the Spline may or may not be on the actual Spline. FlatRedBall uses a type of Spline which passes through all of its points. If you're interested in reading more about Splines, check out the [Wikipedia spline page](http://en.wikipedia.org/wiki/Spline_%28mathematics%29).

![SplineInSplineEditor.png](/media/migrated_media-SplineInSplineEditor.png)

**Math Note:** The SplineEditor uses a form of spline similar to the Catmull-Rom spline. The way the spline is calculated is by determining velocity and acceleration values at every defined point and at midpoints between the defined points.

## What are Splines used for?

Splines can be used in a variety of areas in game development. If you're new to using splines, then this section will give you an idea of some common uses of splines.

### Camera Movement

Many games include IGCs (in-game cinematics). These are sequences where the player does not have control over any game objects. The objects in the game are moved by information which can be stored in XML files, a scripting language, or some other custom format. Splines created by the SplineEditor can be used to control camera movement during IGCs.

### Enemy formations

Top-down and side-scrolling shooters (also called [Shoot 'em ups](http://en.wikipedia.org/wiki/Shoot_%27em_up)) often include enemies which move along preset patterns. These patterns can be defined as Splines.
