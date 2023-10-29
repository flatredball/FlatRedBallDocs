## Radians and Degrees

The FlatRedBall Engine (along with many graphical APIs and game engines) use radians as a measurement of rotation. This may seem inconvenient if you are familiar with using degrees as a measurement of angle (which is likely if you haven't done much 3D programming).

So why does FlatRedBall use radians? The reason is because radians are a functional measurement. That is, Pi is not some arbitrary number selected to represent half of a circle. It is actually the distance of an arc that is drawn halfway around a circle that has a radius of 1. That's handy!

Another reason that radians are used is because because all .NET math functions that FlatRedBall uses expect radians. For example, all trig functions such as Sin, Cos, and Atan2 that can be found in System.Math take radian arguments. We **could** have used degrees for our rotational values and converted things internally, but we didn't do this because we figure that you may be using functions like these in your code, and having rotational values already in the form of radians can simplify things.

Of course, this choice comes at a cost. If you're used to degrees, then that means you have to learn to use radians.

### Conceptually understanding Degrees and Radians

If you've worked with degrees before, then you're likely used to common values like 360, 180, and 90. These values are very common in Radians. When dealing with radians, you usually use the term "Pi". Pi is a number commonly used in math which is approximately 3.14159265. Therefore, if someone ever says "two PI", that means 2 \* Pi, which is about 2 \* 3.14159265, or about 6.2831853.

You may be wondering "Why does the article say 'about'"? The reason is because PI is what is called an "irrational number". Irrational numbers are numbers which can't be expressed by a fraction or a finite number. In other words, rational numbers are 3, -2, 1/5, and .5 (as a few examples). However, PI is an irrational number meaning any time you write PI down, you are writing an approximation. That is, 3.14159265 is an approximation of PI. A better approximation is 3.141592653589793, but even that is an approximation.

If you are going to deal with Pi, then there should be some values you know:

    360 (degrees) = 2 * pi (radians) = 6.2831853 (radians)
    180 (degrees) = pi (radians) = 3.14159265 (radians)
    90 (degrees) = pi / 2 (radians) = 1.570796325 (radians)

### Converting Degrees to Radians

If you're still looking to use degrees, you can still easily convert between the two units.

XNA provides the following conversion methods:

    Microsoft.Xna.Framework.MathHelpers.ToDegrees
    Microsoft.Xna.Framework.MathHelpers.ToRadians

You can also do it by hand:

    radians = degrees * System.Math.PI / 180;
    degrees = radians * 180 / System.Math.PI;

## Sine and Cosine

The Sine and Cosine (Sin and Cos in C#) functions provide useful information about angles. Given an angle, the Sine function gives the Y component of the vector drawn at that angle and the Cosine function gives the X component of the vector drawn at that angle

### Getting Components From Angle and Magnitude

The Sin and Cos methods provide the X axis and Y axis components of a vector given a direction and a magnitude. The following converts magnitude and angle to component velocity values:

    // assume that angle and magnitude are valid floats
    float xVelocity = (float)System.Math.Cos(angle) * magnitude;
    float yVelocity = (float)System.Math.Sin(angle) * magnitude;

## Angle Between Two Points

The Atan2 method provides the angle between two points. The following example finds the angle that a turret would have to be angled at to fire at an enemy;

    // assume that the point values are valid
    float xDistance = enemy.X - turret.X;
    float yDistance = enemy.Y - turret.Y;

    double angle = System.Math.Atan2( yDistance, xDistance );

    // In FlatRedBall you would set the turret to be angled as follows (assuming it faces right at RotationZ = 0)
    turret.RotationZ = (float)angle;

## Setting position from angle and distance

Let's say that you want to make one object orbit around the center of the world (0,0). To do this, you can simply create an angle function and change it using some time based method. For example:

    // Declare the variable at some convenient scope, like class scope:
    float myAngle = 0;
    // Now in update increase it using time-based increments:
    const float someCoefficient = 1;
    myAngle += TimeManager.SecondDifference * someCoefficient;

Once you do this, you can use the Sin and Cos methods to get the position of the object:

    const float radius = 10;
    float xPosition = radius * (float)System.Math.Cos(myAngle);
    float yPosition = radius * (float)System.Math.Sin(myAngle);

## Setting Rotation from Velocity

The Atan2 method can convert a vector to an angle. This is useful for rotating an object (such as a space ship) to face the direction it is moving.

The following code rotates a PositionedObject so that it faces in the direction that it is moving:

    float angleToFace = 
       (float)System.Math.Atan2(myObject.YVelocity, myObject.XVelocity);

    myObject.RotationZ = angleToFace;
