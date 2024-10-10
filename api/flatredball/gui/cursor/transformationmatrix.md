# TransformationMatrix

### Introduction

The Cursor's TransformationMatrix value provides additional control for transforming the screen's coordinates as reported by the mouse to screen and world coordinates used by the game. This property defaults to the identity matrix and is typically used if your game renders to a RenderTarget which is being scaled up, such as for pixel perfect 2D games.

### Code Example - Setting the Transformation Matrix

Typically the TransformationMatrix is only set if you need to scale or offset your cursor for games which use render targets. For example, if a game is rendering to a render target with resolution of 480x360, but is being rendered at 300% zoom with render targets, then the following code would be used to scale down the larger resolution to the 480x360 resolution:

```csharp
Cursor.Main.TransformationMatrix = Matrix.CreateScale(1 / 3f, 1 / 3f, 1);
```

This code is not necessary if you are performing zoom through the FlatRedBall editor, since that automatically handles Cursor position scaling and offset - it is only necessary if you intend to perform additional screen scaling and offsets outside of the built-in code generation.
