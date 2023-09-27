## Introduction

Every Cursor in FlatRedBall belongs to a specific [Camera](/frb/docs/index.php?title=Camera "Camera"). Since multiple [Cameras](/frb/docs/index.php?title=Camera "Camera") can exist at a given time, Cursors must know which [Camera](/frb/docs/index.php?title=Camera "Camera") to use to convert screen space to world space for collision against game objects including UI.

By default the Cursor which can be accessed through GuiManager.Cursor uses the default [Camera](/frb/docs/index.php?title=Camera "Camera") which FlatRedBall creates for you (which can be accessed through SpriteManager.Camera).

## Changing [Camera](/frb/docs/index.php?title=Camera "Camera")

The Cursor's [Camera](/frb/docs/index.php?title=Camera "Camera") property can be changed. To do this simply set the Camera property to the desired [Camera](/frb/docs/index.php?title=Camera "Camera") instance:

    myCursor.Camera = someCameraInstance;

## Where is the Camera property used?

The Cursor uses the Camera property internally when performing checks. Methods which use the Camera include:

-   [FlatRedBall.Gui.Cursor.GetRay](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.GetRay "FlatRedBall.Gui.Cursor.GetRay")
-   [FlatRedBall.Gui.Cursor.IsOn3D](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.IsOn3D "FlatRedBall.Gui.Cursor.IsOn3D")

The Camera property can be changed at any point, and it can be changed multiple times per frame if the Cursor is going to be used to check for whether it is over objects on multiple Cameras.
