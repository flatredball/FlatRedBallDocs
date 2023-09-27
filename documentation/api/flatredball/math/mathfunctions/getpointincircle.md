## Introduction

The GetPointInCircle method returns a random point inside a circle with the argument radius, centered at 0,0. This method returns an even distribution, as opposed to a "random radius, random angle" approach which returns a higher concentration of points at the center of the circle.

## Code example

Add the following using statements:

    using FlatRedBall.Math;
    using FlatRedBall.Math.Geometry; // for Point

Use this code to get a random point in a unit circle:

    float radius = 1;
    Point point = MathFunctions.GetPointInCircle(radius);
    // Now use Point to position an object or perform some other kind of logic
