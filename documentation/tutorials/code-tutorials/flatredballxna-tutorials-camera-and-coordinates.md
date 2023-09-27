## Introduction

At this point the tutorials have covered placing objects and moving them using Velocity. This tutorial covers the coordinate system of FlatRedBall and shows how camera position can impact how things look.

## 

## 3D coordinates

If using a 3D camera, the coordiantes viewed on screen depend on the Z value. For example, if the Z of the camera is set to 40, the following coordinates would roughly match what is on screen: ![DefaultCoordinates.png](/media/migrated_media-DefaultCoordinates.png) The image above shows shows a coordinate system roughly between -20 to positive 20 on the X, and -15 to + 15 on the Y. You may be asking a few questions while looking at the above image such as:

1.  Why do values differ from pixel coordiantes?
2.  Why is the width and height not an easy-to-identify number like 20 or 15? Why is there a small border making the edges have an odd number like 17.56?
3.  Why is the origin at the center instead of the bottom left or top left?

The short answer to all three questions is because the camera is displaying a 3D view. The 3D view has a number of benefits, but also presents a number of challenges - the first of which is understanding the coordinate system. We will be covering the details of a 3D camera in a [later tutorial](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Understanding_the_3D_Camera "FlatRedBallXna:Tutorials:Understanding the 3D Camera"). Simply keep in mind that the default setup can simplify or enable the implementation of features like parallax scrolling, zooming, and other powerful features. Also, if you are not interested in a 3D [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"), it is possible to use a simplified [2D setup](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:2D_In_FlatRedBall "FlatRedBallXna:Tutorials:2D In FlatRedBall").

## World Space

World space refers to a position inside the "virtual world" that you create when you run FlatRedBall. As shown in [a previous tutorial on Sprites](/frb/docs/index.php?title=Working_with_Sprites#A_note_about_persistence "Working with Sprites"), it can be useful to think of FlatRedBall as a real simulation where objects exist and continue to exist until their state or presence is changed by the logic of your application. If we consider the application to be a virtual world, then the Camera is our view of this world. To carry this analogy forward, consider watching a television program about the [Eiffel Tower](http://en.wikipedia.org/wiki/Eiffel_Tower). ![EiffelTower.jpg](/media/migrated_media-EiffelTower.jpg) If asked where the Eiffel Tower is, you might say one of two things:

-   "It's in Paris, France."
-   "It's in the center of my television screen."

While the second answer might not seem appropriate (or might be seen as poor humor), it's technically accurate. It really depends what question you are answering. In other words, to make each answer appropriate, we can add questions as follows:

-   "Where in world space is the Eiffel Tower?" "It's in Paris, France."
-   "Where in screen space is the Eiffel Tower?" "It's in the center of my television screen."

This distinction is very important because similarly, objects in FlatRedBall can have two locations, world space and screen space. The way that world space ties to screen space depends on the position of the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera").

## Camera modifying screen space

To illustrate the difference between world space and screen space, consider the above graph where the origin (0,0) is at the center of the screen. If the camera moves, the origin will no longer be at the center of the screen. For example, if we set the Camera's position as follows:

    SpriteManager.Camera.X = 10;
    SpriteManager.Camera.Y = 10;

The coordinates would be seen as follows: ![MovedCamera.png](/media/migrated_media-MovedCamera.png) Now the center of the screen is focused at 10,10. Therefore, as you can see, it's often misleading to describe the position of an object using screen coordinates as they can change. Many FlatRedBall games use a moving camera as it is an effective way to implement scrolling. Keep this in mind, both when defining the position of your objects as well as when considering ways to implement scrolling.
