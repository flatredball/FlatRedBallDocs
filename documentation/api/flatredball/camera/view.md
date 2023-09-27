## Introduction

The Camera's View property is a matrix which contains the "view" matrix commonly used when working with shaders. The View is internally calculated using the Matrix.CreateLookAt method. The View matrix is constructed using the Camera's absolute [Postiion](/frb/docs/index.php?title=FlatRedBall.Camera.Position.md "FlatRedBall.Camera.Position"), its [RotationMatrix](/frb/docs/index.php?title=FlatRedBall.Camera.RotationMatrix.md "FlatRedBall.Camera.RotationMatrix"), and its [UpVector](/frb/docs/index.php?title=FlatRedBall.Camera.UpVector.md "FlatRedBall.Camera.UpVector").

## Code Example

The View matrix can be used when interacting with shaders. For example the following code demonstrates how to assign a BasicEffect's View using the Camera's View property:

    // Assuming BasicEffectInstance is a valid BasicEffect:
    BasicEffectInstance.View = Camera.Main.View;
