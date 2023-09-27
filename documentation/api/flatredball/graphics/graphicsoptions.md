## Introduction

The GraphicsOptions class provides high-level control over the graphical presentation of FlatRedBall. As a user **you do not need to create an instance of GraphicsOptions**, it is done automatically when the engine is created. It is exposed through the [FlatRedBallServices](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.md "FlatRedBall.FlatRedBallServices") class. However, you can explicitly instantiate a GraphicsOptions to make changes prior to the initialization of FlatRedBall. This is useful for setting resolution or fixing compatibility issues. Of course, if this is done you need to suspend and resume the device resets, as explained below.

## SuspendDeviceReset and ResumeDeviceReset

Whenever a property is changed on the GraphicsOptions, the FlatRedBall Engine attempts to implement the changes immediately. However, this can cause problems when properties are changed on a GraphicsOptions instance prior to the initialization of FlatRedBall. If this occurs, the graphics device is not yet created so the setting of the property will raise an exception. This exception can be avoided by suspending device resets. If device resetting is suspended then the properties of a GraphicsOptions instance will be updated, but the device will not be reset. If the changed instance is then used to initialize FlatRedBall then the changed properties will be applied to the graphics device when it is first created. The following code tells the engine to initialize the engine in full-screen:

     GraphicsOptions graphicsOptions = new GraphicsOptions();

     // So the engine doesn't auto-update
     graphicsOptions.SuspendDeviceReset();

     // This property will be used when the engine is initialized
     graphicsOptions.IsFullScreen = true;

     // We want the engine to auto-update after it's initialized
     graphicsOptions.ResumeDeviceReset();

     FlatRedBallServices.InitializeFlatRedBall(this, this.graphics, graphicsOptions);

## 
