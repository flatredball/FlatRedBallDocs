# setting-camera

### Introduction

If you have worked with the [SpriteEditor](../../../../frb/docs/index.php) then you may have noticed that Scenes in the [SpriteEditor](../../../../frb/docs/index.php) may not look the same in your game as they do in the [SpriteEditor](../../../../frb/docs/index.php). This is usually the case if you have moved the Camera in the [SpriteEditor](../../../../frb/docs/index.php) scene or if you have re-sized the [SpriteEditor](../../../../frb/docs/index.php) window.

This article discusses how you can match what you see in the [SpriteEditor](../../../../frb/docs/index.php) with what you see in your game so that the [SpriteEditor](../../../../frb/docs/index.php) can be used to determine both layout as well as size.

### Why does this happen?

First let's look at why Scenes can be sized differently in the [SpriteEditor](../../../../frb/docs/index.php) and your game. When you create a game in FlatRedBall XNA/MDX the Camera is using a 3D perspective setup positioned at 40 units away from the Z = 0 plane. It also has a fixed [field of view](../../../../frb/docs/index.php) of PI/4. The [SpriteEditor](../../../../frb/docs/index.php) also matches this when it is first opened, but this setup will likely not persist.

The [SpriteEditor](../../../../frb/docs/index.php) supports moving the Camera around in the X, Y, and Z directions which can offset and make the Scene appear bigger or smaller. To add to the complexity, when the window is re-sized, the [SpriteEditor](../../../../frb/docs/index.php) changes the field of view to allow for viewing more or less of the Scene. Also, if the aspect ratio of the window changes, then the SpriteEditor also changes the Camera's [AspectRatio](../../../../frb/docs/index.php) property as well.

As you can see, the Camera changes considerably through regular usage of the [SpriteEditor](../../../../frb/docs/index.php). Fortunately, the there are ways to set up the Camera in your game to match desired settings.

### Using the Camera Bounds

We recommend first determining on a Camera setup that you would like your game to use, then building your .scnx files to that setup. The SpriteEditor provides a "Camera Bounds" feature which you can use as a guide when building your Scene. For more information, [click here](../../../../frb/docs/index.php).

### Getting Camera information from the .scnx file

The [SpriteEditor](../../../../frb/docs/index.php) saves the Camera's properties when saving a .scnx file. You can access the information from this by using the [SpriteEditorScene](../../../../frb/docs/index.php) class. To see how to load a .scnx file and get the Camera's properties, check the [Camera save page](../../../../frb/docs/index.php).

### Why using the CameraSave may not be a good idea

Although the .scnx file contains CameraSave information which can be used to easily set-up your Camera, you may not want to use this information in your game.

One reason for this is because the CameaSave is only available in the [SpriteEditorScene](../../../../frb/docs/index.php) class. The SpriteEditorScene is a "save" class which is an intermediary file between the .scnx file and the [Scene](../../../../frb/docs/index.php) which is a "runtime" class. The most common way of loading a Scene is though the FlatRedBallServices.Load method as shown [here](../../../../frb/docs/index.php#Loading\_a\_Scene\_From\_File). If you use this method, then the SpriteEditorScene is not available. Of course, you **could** create a [SpriteEditorScene](../../../../frb/docs/index.php) by loading the file, but this is requires accessing the disk again, which results in the game accessing the hard drive a second time for the .scnx - not very efficient.

Another reason why this may not be desirable is because the Camera in the SpriteEditor is often moved when working with Scenes. A developer may want to make a small modification to a .scnx and he may move the camera to be able to do it with more accuracy or to get a better sense of the entire Scene. If your game uses the information in the .scnx file, then you may find that your Camera changes in reaction to the position of the Camera in the SpriteEditor when the .scnx was last saved.
