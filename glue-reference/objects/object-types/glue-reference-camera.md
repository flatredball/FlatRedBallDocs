# Camera

### Introduction

Cameras can be added to Screens and Entities. Camera objects (by default) represent the main Camera ([FlatRedBall.Camera.Main](../../../api/flatredball/camera/main.md)). If an object in an Entity is a [Camera](../../../api/flatredball/camera/), then this (by default) attaches the main Camera to the Entity. If an object in a Screen is a Camera, then this object serves as an alias for FlatRedBall.Camera.Main, but no attachment occurs.

{% hint style="info" %}
Cameras which are aliases of Camera.Main are rarely added to FlatRedBall projects for two reasons:

1. Resolution is usually handled by the project's [display settings](../../camera.md)
2. Camera position and zoom is usually handled by a [CameraControllingEntity](cameracontrollingentity.md) instance
{% endhint %}

### Example - Adding a Camera to GameScreen

Cameras added to a Screen can be modified in the FlatRedBall Editor. By default, adding a Camera object to a Screen does not create a new Camera, but rather it provides access to the main Camera. For more information, see the IsNewCamera property below. To access the camera in a Screen:

1. Select the Screen to contain the object. To make changes for all levels, select the GameScreen.
2.  Click the **Add Object** button to add a new object to the screen

    ![Add Object Quick Action](../../../.gitbook/assets/2022-03-img_62323de2907f4.png)
3.  Select Camera as the type and click OK

    ![New Object window selecting Camera type](../../../.gitbook/assets/2022-03-img_62323dfe257e0.png)

The new camera appears in the GameScreen. It can be modified to make changes to the game, including in edit mode. For example, the Background Color can be changed from Black to any desired color.

<figure><img src="../../../.gitbook/assets/2016-01-16_13-54-48.gif" alt=""><figcaption><p>Camera Background Color can be changed in edit mode</p></figcaption></figure>

### IsNewCamera

The IsNewCamera property only appears on Camera objects.

* If this property is false (the default value) then the Camera object represents the main camera (FlatRedBall.Camera.Main).
* If this property is true, this is a new Camera instance. This is not often used but can be used for split-screen games, or games which use multiple overlayed cameras for control over rendering

### Multiple Overlayed Cameras

Multiple cameras can be used for games which have camera-specific post processing. This section assumes that the cameras are added to GameScreen. You can also manage cameras in code if your game needs multiple cameras with lifecycles separate from Screens.

To add a camera:

1. Add a new object
2. Select Camera as the type
3. Enter a name for the new Camera. Usually the name for the camera should indicate its purpose, such as UiCamera
4. Click OK to add the new camera
5. Select the newly-added camera
6. Click on its Properties tab
7. Set the **IsNewCamera** property to true

Now that we have a new Camera we need to initialize the camera. Specifically, we need to update its values according to the game's display settings and we need to update the Camera's position. This section assumes that the overlayed Camera should move along with the main camera.

To initialize the Camera according to display settings, add the following code to your GameScreen's CustomInitialize:

```csharp
CameraSetup.ResetCamera(UiCamera);
```

To attach the camera to the main camera, add the following code to CustomInitialize:

```csharp
UiCamera.AttachTo(FlatRedBall.Camera.Main);
```

If you have specific entities which should appear only on this camera, you can call MoveToLayer.

```csharp
EntityWhichShouldBeOnCamera.MoveToLayer(UiCamera);
```

Alternatively if you've created a Layer in your GameScreen, you can move this Layer to the Camera using the following code:

```csharp
SpriteManager.RemoveLayer(HudLayer);
UiCamera.AddLayer(HudLayer);
```

Overlaying Cameras typically do not draw the world. You can set DrawsWorld to false either in the FRB Editor or in code.

```csharp
UiCamera.DrawsWorld = false;
```

If you are using this Camera to draw post processing, you can add post processing to either the main camera or cameras created in the FRB Editor. For more information see the [.fx file](../../files/file-types/effect-.fx.md#effect-files-in-monogame) page.
