# glue-reference-camera

### Introduction

Objects in Screens and Entities can be of type [Camera](../../../../frb/docs/index.php). A Camera object will (by default) represent the main Camera ([FlatRedBall.Camera.Main](../../../../frb/docs/index.php)). If an object in an Entity is a [Camera](../../../../frb/docs/index.php), then this will (by default) attach the main [Camera](../../../../frb/docs/index.php) to the Entity. If an object in a Screen is a [Camera](../../../../frb/docs/index.php), then this object serves as an alias for [FlatRedBall.Camera.Main](../../../../frb/docs/index.php), but no attachment occurs.

### Example - Adding a Camera to GameScreen

Cameras added to a Screen can be modified in the FlatRedBall Editor. By default, adding a Camera object to a Screen does not create a new Camera, but rather it provides access to the main Camera. For more information, see the IsNewCamera property below. To access the camera in a Screen:

1. Select the Screen to contain the object. To make changes for all levels, select the GameScreen.
2.  Click the **Add Object** button to add a new object to the screen

    ![](../../../../media/2022-03-img\_62323de2907f4.png)
3.  Select Camera as the type and click OK

    ![](../../../../media/2022-03-img\_62323dfe257e0.png)

The new camera appears in the GameScreen. It can be modified to make changes to the game, including in edit mode. For example, the Background Color can be changed from Black to any desired color. 

<figure><img src="../../../../media/2016-01-16\_13-54-48.gif" alt=""><figcaption></figcaption></figure>



### IsNewCamera

The IsNewCamera property is a property which only appears on objects which are of type Camera.

* If this property is false (the default value) then the Camera object is assigned to the main Camera ([FlatRedBall.Camera.Main](../../../../frb/docs/index.php)).
* If this property is true, Glue will create a new Camera instance. This is not often used but can be used for split-screen games.

###

### Example Usage

If you are developing a game which requires logic for initializing or controlling the Camera then you may want to organize this code into an Entity. The Camera object facilitates setting this up in Glue. The process is as follows:

1. Create an Entity which will contain all of the logic. For example an Entity named CameraEntity
2. Right-click on the CameraEntity's objects and add a new object
3. Select Camera as the type

Now you can code logic in the CustomInitialize and CustomActivity of your CameraEntity.
