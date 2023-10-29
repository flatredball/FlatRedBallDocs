## Introduction

The ReferenceAlpha is a value that is used to test whether a pixel should be drawn according to its alpha value. The default value for this is 0. This is used in combination with the AlphaFunction property.

## Usage

The following code results in all pixels being drawn:

    FlatRedBallServices.GraphicsDevice.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
    FlatRedBallServices.GraphicsDevice.RenderState.ReferenceAlpha = 0;

In the code above, any alpha value greater than 0 will be drawn. In the following code, only alpha values greater than 128 (out of 255) will be drawn:

    FlatRedBallServices.GraphicsDevice.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
    FlatRedBallServices.GraphicsDevice.RenderState.ReferenceAlpha = 128;

FlatRedBall XNA uses an alpha range of 0 to 1 (inclusive). This gets converted to a 0 to 255 range, so you may need to perform some math to convert between the two systems.
