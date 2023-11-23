# CameraControllingEntity

### Introduction

The CameraControllingEntity provides a standardized way to control camera position in games which contain a moving character or which use Tiled for maps.

### Default Implementation

If your game was created with the wizard, then your GameScreen has an instance called CameraControllingEntityInstance.

![](../../../media/2022-02-img\_620bf5aba5c04.png)

This instance targets the PlayerList (averages the position of all Players in the PlayerList) and will restrict the visible area to the Map object.

![](../../../media/2022-02-img\_620bf5d1efe32.png)

The **Extra Map Padding** property adds a number of pixels of offset between the edge of the actual map and the desired visible edge. A positive value adds padding, effective shrinking the available area that the camera can view. A negative value allows the camera to move outside of the map. Note that the property on the CameraControllingEntity is called **Map** since this is the most common type of object used to control bounds, but it doesn't have to be a map.

### Example: Adding a New CameraControllingEntity Instance

You can manually add a new instance to your game if you do not already have an instance in the GameScreen. Keep in mind this may have already been done for you if your game was created using the new project Wizard. To add a CameraControllingEntity to a game that has not used the Wizard:

1. Select your **GameScreen**
2. Select the **Quick Actions** tab
3.  Click the **Add Object to GameScreen** button

    ![](../../../media/2021-07-img\_60f9bf043445f.png)
4. Select the **Camera Controlling Entity** option
5.  Click OK

    ![](../../../media/2021-07-img\_60f9bf39e861f.png)

Once you have created the instance, you can assign it the object to follow and the map to use as the visible bounds. To set which object the camera will follow:

1. Select the newly-created CameraControllingEntityInstance
2. Click the Variables tab
3. Select which object to follow in the Targets list. Notice that you can select entire lists of objects too, which will result in the CameraControllingEntity using the center position for all objects.

![](../../../media/2021-07-img\_60f9bfd410148.png)

Similarly, the Map object can be set to control the visible bounds of the camera using the Map dropdown.

![](../../../media/2021-07-img\_60f9c00a8b0c6.png)

At runtime the Camera will automatically follow the target with no additional code required.

<figure><img src="../../../media/2021-07-2021_July_22_130201.gif" alt=""><figcaption></figcaption></figure>

### Immediately Moving Camera

By default the CameraControllingEntity _interpolates_ from its current position to the target. This is normally desired as it can make the camera move smoothly. At times the Camera may need to be moved immediately to its target.&#x20;

The following code results in the CameraControllingEntity moving immediately.

```csharp
var target = CameraControllingEntityInstance.GetTarget();
// If true, the camera controlling entity will interpolate to its target
// position. If false, the camera controlling entity sets its position immediately.
var lerpSmooth = false;
CameraControllingEntityInstance.ApplyTarget(target, lerpSmooth);
```

Keep in mind that setting the Camera.Main's position to the target location will not immediately move the camera to the target position. If using a CameraControllingEntity, then the Camera's position becomes _read only_, so any changes to the camera position must be done through the CameraControllingEntity.
