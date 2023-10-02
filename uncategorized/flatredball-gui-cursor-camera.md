# flatredball-gui-cursor-camera

### Introduction

Every Cursor in FlatRedBall belongs to a specific [Camera](../frb/docs/index.php). Since multiple [Cameras](../frb/docs/index.php) can exist at a given time, Cursors must know which [Camera](../frb/docs/index.php) to use to convert screen space to world space for collision against game objects including UI.

By default the Cursor which can be accessed through GuiManager.Cursor uses the default [Camera](../frb/docs/index.php) which FlatRedBall creates for you (which can be accessed through SpriteManager.Camera).

### Changing [Camera](../frb/docs/index.php)

The Cursor's [Camera](../frb/docs/index.php) property can be changed. To do this simply set the Camera property to the desired [Camera](../frb/docs/index.php) instance:

```
myCursor.Camera = someCameraInstance;
```

### Where is the Camera property used?

The Cursor uses the Camera property internally when performing checks. Methods which use the Camera include:

* [FlatRedBall.Gui.Cursor.GetRay](../frb/docs/index.php)
* [FlatRedBall.Gui.Cursor.IsOn3D](../frb/docs/index.php)

The Camera property can be changed at any point, and it can be changed multiple times per frame if the Cursor is going to be used to check for whether it is over objects on multiple Cameras.
