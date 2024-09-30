# CameraControllingEntity

### Introduction

The CameraControllingEntity provides a standardized way to control camera position in games which contain a moving character or which use Tiled for maps.

This page discusses working with the CameraControllingEntity in the FRB Editor. For information about how to work with it in code, see the [CameraControllingEntity API Documentation](../../../api/flatredball/entities/cameracontrollingentity.md).

### Default Implementation

If your game was created with the wizard, then your GameScreen has an instance called CameraControllingEntityInstance.

![](../../../.gitbook/assets/2022-02-img\_620bf5aba5c04.png)

This instance targets the PlayerList (averages the position of all Players in the PlayerList) and will restrict the visible area to the Map object.

![](../../../.gitbook/assets/2022-02-img\_620bf5d1efe32.png)

The **Extra Map Padding** property adds a number of pixels of offset between the edge of the actual map and the desired visible edge. A positive value adds padding, effective shrinking the available area that the camera can view. A negative value allows the camera to move outside of the map. Note that the property on the CameraControllingEntity is called **Map** since this is the most common type of object used to control bounds, but it doesn't have to be a map.

### Example: Adding a New CameraControllingEntity Instance

You can manually add a new instance to your game if you do not already have an instance in the GameScreen. Keep in mind this may have already been done for you if your game was created using the new project Wizard. To add a CameraControllingEntity to a game that has not used the Wizard:

1. Select your **GameScreen**
2. Select the **Quick Actions** tab
3.  Click the **Add Object to GameScreen** button

    ![](../../../.gitbook/assets/2021-07-img\_60f9bf043445f.png)
4. Select the **Camera Controlling Entity** option
5.  Click OK

    ![](../../../.gitbook/assets/2021-07-img\_60f9bf39e861f.png)

Once you have created the instance, you can assign it the object to follow and the map to use as the visible bounds. To set which object the camera will follow:

1. Select the newly-created CameraControllingEntityInstance
2. Click the Variables tab
3. Select which object to follow in the Targets list. Notice that you can select entire lists of objects too, which will result in the CameraControllingEntity using the center position for all objects.

![](../../../.gitbook/assets/2021-07-img\_60f9bfd410148.png)

Similarly, the Map object can be set to control the visible bounds of the camera using the Map dropdown.

![](../../../.gitbook/assets/2021-07-img\_60f9c00a8b0c6.png)

At runtime the Camera will automatically follow the target with no additional code required.

<figure><img src="../../../.gitbook/assets/2021-07-2021_July_22_130201.gif" alt=""><figcaption></figcaption></figure>
