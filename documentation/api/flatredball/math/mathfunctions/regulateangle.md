## Introduction

The RegulateAngle method can be used on a radian value to modify it so that it is always between 0 and 2\*PI. This method is internally used on the PositionedObject class to keep all rotation and relative rotation values between 0 and 2\*PI.

## Method Signature

The method has two overloads: one that returns a modified float, and one that can modify a float passed as a ref:

    public static float RegulateAngle(float angleToRegulate)

    public static void RegulateAngle(ref float angleToRegulate)

## Usage

This method can be used if it is more convenient for you to work with values between 0 and 2\*PI. This method will not modify any values that are between 0 and 2\*PI. It will modify values which are less than 0 and more than 2\*PI.

For the graph below, we will use the following code:

    float returnValue = FlatRedBall.Math.MathFunctions.RegulateAngle(startingValue);

| StartingValue | ReturnValue |
|---------------|-------------|
| 0             | 0           |
| PI            | PI          |
| -PI           | 1.5PI       |
| 2PI           | 0           |
| 3 PI          | PI          |
