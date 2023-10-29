# setsplitscreenviewport

### Introduction

The SetSplitScreenViewport method is a method which can be used to set the viewport (also known as the [DestinationRectangle](../../../../frb/docs/index.php)) to a value relative to the current game window. For example, using the SplitScreenViewport.TopHalf as the argument will set the calling Camera's [DestinationRectangle](../../../../frb/docs/index.php) so that it occupies the top-half of the game window regardless of its size. Once SetSplitScreenViewport is called, the camera that called the method will automatically change its [DestinationRectangle](../../../../frb/docs/index.php) if the game window resizes. This behavior will persist until the [DestinationRectangle](../../../../frb/docs/index.php) is manually changed. By default all Cameras will have have SetSplitScreenViewport called when created using the SplitScreenViewport.FullScreen value. In other words, this means that if the game window is resized, the Camera will automatically adjust to fit the screen.

### Stopping automatic adjustments

The Camera will automatically adjust according to window resizing unless the destination rectangle is manually set. This can be done by setting any of the following properties:

* [FlatRedBall.Camera.DestinationRectangle](../../../../frb/docs/index.php)
* [FlatRedBall.Camera.TopDestination](../../../../frb/docs/index.php)
* [FlatRedBall.Camera.BottomDestination](../../../../frb/docs/index.php)
* [FlatRedBall.Camera.LeftDestination](../../../../frb/docs/index.php)
* [FlatRedBall.Camera.RightDestination](../../../../frb/docs/index.php)

Calling SetSplitScreenViewport will resume the automatic destination rectangle changing behavior.
