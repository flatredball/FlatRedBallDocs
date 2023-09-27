## Introduction

The FarClipPlane value determines the maximum distance from the Camera that objects will be drawn. This value is relative to the Camera. In other words, if the FarClipPlane is 1000 and the Camera's Z is 100, then the furthest the Camera will draw is -900 assuming the Camera is looking down the negative Z axis (default in FlatRedBall XNA).

## Code Example

The following code increases the Camera's far clip plane to 2000:

    Camera.Main.FarClipPlane = 2000;

## Why the FarClipPlane matters

Increasing the FarClipPlane allows the Camera to see further, but it also reduces the accuracy of the Z-Buffer. The larger the distance between the Camera's NearClipPlane and FarClipPlane, the more likely [Z Fighting](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer:Z_Fighting.md "General Programming:Graphics:Depth Buffer:Z Fighting") is. Therefore, if you are experiencing [Z Fighting](/frb/docs/index.php?title=General_Programming:Graphics:Depth_Buffer:Z_Fighting.md "General Programming:Graphics:Depth Buffer:Z Fighting") in your game, you should consider reducing the distance between the NearClipPlane and FarClipPlane if possible. If you are not using any Z-Buffered objects in your game, then you can increase the FarClipPlane without causing any graphical problems.
