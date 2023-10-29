# common-math-in-2d-games

There are four equations that can solve a large variety of problems in 2D games. But math textbooks or Wikipedia often make it really hard to understand how to \*use \*them. This post explains the usage of these equations without going into detail about how they work, and links to the Wikipedia pages if you want to learn more about the mathematics.

### Pythagorean Theorem

You probably learned the [Pythagorean Theorem](https://en.wikipedia.org/wiki/Pythagorean\_theorem) at some point in school:

```
a² + b² = c²
```

This equation is used to _**find the distance between two game objects**_, the _linear velocity_ of an object, or similar problems where you need to find the length of an angle given X and Y components. The Pythagorean Theorem is the equation to find the hypotenuse of a right triangle, given the length of two sides. Imagine you have two space ships and each of them can fire lasers 200 units. How do you know if they are close enough to hit each other? Using the Pythagorean Theorem, you can find the angular distance (hypotenuse) between the two ships by finding the difference of their vectors and performing the equation on that result (pseudocode):

```
ship1Position = 100, 300
ship2Position = -150, -50

// This is the A variable
xDifference = 100 - -150 = 250

// This is the B variable
yDifference = 300 - -50 = 350

// Solve for C, the distance
distanceSquared = 250^2 + 350^2 = 62,500 + 122,500 = 185,000
distance = SquareRoot(185,000) = 430.116
```

The ships are about 430 units apart, which is beyond the range of their weapons - they will not be able to target each other.

### Atan2

The function [Atan2](https://en.wikipedia.org/wiki/Atan2), or two-argument ArcTangent, is used to _**find the rotation from one object to another object**_. Imagine you have a turret that should always aim at the mouse cursor. How do you find the rotation from the turret's position to the mouse position that will correctly point at the mouse? The Atan2 function in most languages returns this result (pseudocode):

```
turretPosition = 100, 150
mousePosition = -50, -30

// Find the difference, or delta, of the positions.
// Note that the turret position is subtracted FROM the mouse position.
deltaX = -50 - -100 = -150
deltaY = -30 - 150 = -180

// now use the Atan2 function to find the angle
// Note that in almost every language, the Y component is specified before the X component
rotation = Atan2(deltaY, deltaX) = Atan2(-180, -150) = -2.265 radians
```

Most programming languages measure angles in radians: -2.265 radians is approximately 130 degrees. Setting the turret rotation to this value will cause the turret to point at the mouse. Important note: In most programming languages, angle 0 is facing directly to the right. For the math above to work, the sprite must \*also \*face directly right. If your sprite is facing north, for example, you will have to subtract 90 degrees from the result of your math to compensate for the fact that the sprite is already rotated 90 degrees.

### Sin and Cos

[Sin and Cos are trigonometry functions](https://en.wikipedia.org/wiki/Trigonometric\_functions) that are used to _**find X and Y vector components, given an angle and magnitude**._ The Cos function provides the X component of an angle, the Sin function provides the Y component of an angle. More simply, if you have a speed and an angle, and want to know how this translates to grid coordinates, these equations do the job! Imagine you have an object that is going 150 units per second and is rotated at 75 degrees (pseudocode):

```
// Most programming languages use radians to measure rotation
rotation = 75degrees = 1.3 radians
speed = 150
// extract each component
xMovement = Cos(rotation) * speed = Cos(1.3) * 150 = 40.125
yMovement = Sin(rotation) * speed = Sin(1.3) * 150 = 144.534
```

The object will have moved roughly 40 units on the X axis, and 145 units on the Y axis over one second. &#x20;

### Summary

The majority of the problems in 2D gamedev are about figuring out where things are in space, how they are rotated, and how far apart they are. The equations above can combine in powerful ways to implement velocity, perform targeting and chase logic for NPCs, and much more! To see more about trigonometry in game development, check out the [Math:Trigonometry documentation](../tutorials/math/trigonometry.md).
