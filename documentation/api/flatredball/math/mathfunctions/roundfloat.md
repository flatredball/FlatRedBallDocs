# roundfloat

### Introduction

The RoundFloat method can be used to round a float to the nearest non-whole argument value (called multipleOf). The following shows the result of using RoundFloat with multipleOf = 1: RoundFloat(1.2f) -> 1 RoundFloat(3.8f) -> 4 RoundFloat(-8.3) -> -8 If your multipleOf = 2, you would see the following results: RoundFloat(1.2) -> 2 RoundFloat(3.8f) -> 4 RoundFloat(-8.3) -> -8 This method is very useful in tile-based games where your tiles are not centered on whole values.

### Code Example

The following shows how to use the RoundFloat method: Add the following using statement:

```
using FlatRedBall.Math;
```

Add the following code wherever you need to use RoundFloat:

```
float valueToRound = 2.1f;
// Notice that multipleOf does not have to be a whole number:
float multipleOf = .481f;

float result = MathFunctions.RoundFloat(valueToRound, multipleOf);
// result will equal 1.924, which is .481 * 4.
```

### Code Example: Using RoundFloat for even-spacing index

RoundFloat can be useful for identifying the index of an object based off of its position. For this example, consider a list of Buttons, stacked vertically. The first button appears at Y = 10, and each button is spaced 35 units away from the next. In this situation, you can convert any absolute Y value to the index of the nearest button as follows:

```
const float startingY = 10;
const float spacingBetweenButtons = 35;
// Assume worldY is the Y value that you want to convert to an index
float indexAsFloat = MathFunctions.RoundFloat(worldY, spacingBetweenButtons, startingY);
// Now we can convert this to an int
int index = MathFunctions.RoundToInt(indexAsFloat);
```

### Code Example: Using RoundFloat to Adjust Camera Offsets

Due to rendering issues in DirectX 9, offsetting the camera by a small amount can correct visual artifacts. The following code shows how to adjust the camera so its position is always offset by .1 pixels (meaning, it X position might be 10.1, 11.1, 12.1, etc):

```lang:c#
// Assuming the Camera is not attached to any object,
// and that its position has already been set to the desired values:

// offset by .1 pixel
const float offset = ..1f;
const float roundingValue = 1;

Camera.Main.X = MathFunctions.RoundFloat(Camera.Main.X, roundingValue, offset);
Camera.Main.Y = MathFunctions.RoundFloat(Camera.Main.Y, roundingValue, offset);
```

&#x20;
