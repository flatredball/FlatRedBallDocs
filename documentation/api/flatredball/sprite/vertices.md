## Introduction

The Vertices property provides control over setting color values on individual corners of a Sprite. Setting the Red, Green, Blue, or Alpha values changes the values on all four vertices.

## Code Example

Assuming that SpriteInstance is a valid sprite, this sets the top left and top right corners to have a red value of 1:

``` lang:c#
SpriteInstance.Vertices[0].Color.X = 1;
SpriteInstance.Vertices[1].Color.X = 1;
```

## Setting Color

Color values are represented by a Vector4 value, with the following mapping:

-   X = Red
-   Y = Green
-   Z = Blue
-   W = Alpha
