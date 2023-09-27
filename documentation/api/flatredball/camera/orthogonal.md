## Introduction

The Orthogonal setting controls whether the camera is using a perspective or orthogonal view. The following describes some differences between the two modes:

|                                                                                                                                                                                                                                                                                                                    |                                                                                                                                                                       |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Orthogonal                                                                                                                                                                                                                                                                                                         | Perspective (non-Orthogonal)                                                                                                                                          |
| Moving objects further from the camera does not change their visible size                                                                                                                                                                                                                                          | Moving objects further from the camera makes them appear smaller                                                                                                      |
| Moving the Camera forward and backward does not create a "zoom" effect                                                                                                                                                                                                                                             | Moving the Camera forward and backward does create a "zoom" effect                                                                                                    |
| The camera uses the [OrthogonalHeight](/frb/docs/index.php?title=FlatRedBall.Camera.OrthogonalHeight.md "FlatRedBall.Camera.OrthogonalHeight") and [OrthogonalWidth](/frb/docs/index.php?title=FlatRedBall.Camera.OrthogonalWidth.md "FlatRedBall.Camera.OrthogonalWidth") properties to control the visible area. | The camera uses the [FieldOfView](/frb/docs/index.php?title=FlatRedBall.Camera.FieldOfView.md "FlatRedBall.Camera.FieldOfView") property to control the visible area. |

When the camera is in Orthogonal mode, the Z value of objects impacts drawing order. Objects with a larger Z value will be drawn in front of objects with a smaller Z value. Also, objects may disappear if they are moved too far away from the camera or if the objects have a Z value large enough to be placed behind the Camera. This is affected by the rotation of the camera. Camera Orthogonal can be set through the FlatRedBall Editor's Camera settings. For more information, see the [FlatRedBall Editor Camera page](/documentation/tools/glue-reference/camera/.md).

![](/media/2021-12-img_61ad4e82c644a.png)

## 2D vs. 3D Object Size

By default the 2D camera in FlatRedBall will make objects such as sprites appear the same size on screen as the source texture. For example, the following screenshot shows the FlatRedBall icon (which is 85x88 pixels) drawn in a project with a default 2D camera:

![](/media/2017-02-img_589b4ba326296.png)

Setting Camera.Main.Orthogonal = false results in the camera being 3D, drastically changing the size of the icon on screen:

![](/media/2017-02-img_589b4bdab0c65.png)

This occurs because the size of the object now depends both on its Width and Height values, as well as the Z value of the camera. By default, the main camera has a Z value of 40. This can be changed in code. Increasing the Z value makes the camera move "backward", which allows it to see more of the sprite.

``` lang:c#
Camera.Main.Z = 500;
```

![](/media/2017-02-img_589b4c37477c4.png)

A 3D camera can be positioned so that objects at Z=0 appear the same size as on a 2D camera using GetZDistanceForPixelPerfect .

``` lang:c#
Camera.Main.Z = Camera.Main.GetZDistanceForPixelPerfect();
```

![](/media/2017-02-img_589b4cb559766.png)

 

## 

## Zooming in Orthogonal Mode

For information on Zooming, see the [OrthogonalWidth and OrthogonalHeight entries](/frb/docs/index.php?title=FlatRedBall.Camera.OrthogonalWidth.md "FlatRedBall.Camera.OrthogonalWidth").
