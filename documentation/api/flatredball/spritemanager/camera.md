**Note:** The preferred way to access the Camera is through [Camera.Main](/frb/docs/index.php?title=FlatRedBall.Camera.Main.md "FlatRedBall.Camera.Main"). This page is left here for historical purposes, but may be removed at some point in the future. Use [Camera.Main](/frb/docs/index.php?title=FlatRedBall.Camera.Main.md "FlatRedBall.Camera.Main") in future code.

## Introduction

The static Camera property in the SpriteManager class represents the main FlatRedBall Camera. This Camera is created automatically when FlatRedBall is initialized, and it is never destroyed. Most games only use one Camera, and this is the Camera that is used. For more information on Cameras in general, see the [Camera page](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera").

## Accessing the Camera

The Camera can be accessed at any point after FlatRedBall has been initialized. For example, the following sets the Camera's XVelocity to 3:

    SpriteManager.Camera.XVelocity = 3;
