## Introduction

The CameraCullMode property controls how the Camera *culls* objects such as [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), which means whether objects that are out of view are drawn or not. By default, CameraCullMode is set to CameraCullMode.UnrotatedDownZ, which means that the Camera will not draw objects which are outside of the calculated view of an un-rotated camera. If your game requires a rotating camera (such as a 3D game), then you may need to set CameraCullMode to None. CameraCullMode does not impact whether objects are not drawn because they are too close or too far from the camera. For more information on this type of culling (which is referred to as near and far clipping), see the [FarClipPlane page](/frb/docs/index.php?title=FlatRedBall.Camera.FarClipPlane.md "FlatRedBall.Camera.FarClipPlane").

## Available values

-   UnrotatedDownZ (default)
-   None

## CameraCullMode and multiple Cameras

Camera-based cull is done just before rendering, which means an object can be culled in one Camera and not in another. In other words, culling will work appropriately with multiple Cameras when using split screens.

## Example

FlatRedBall XNA assumes that the current scene is being viewed directly down the negative Z axis (the default). With this assumption the engine culls out Sprites which do not fall in this visible area. The following code creates 200 Sprites which extend down the positive X axis. Because of culling only a few are visible.

    for (int i = 0; i < 200; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
        sprite.X = i * 2;
    }

    Camera.Main.RotationYVelocity = -.1f;

![200SpritesWithCulling.png](/media/migrated_media-200SpritesWithCulling.png) To fix this the Camera's CameraCullMode can be changed to None:

    for (int i = 0; i < 200; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
        sprite.X = i * 2;
    }

    Camera.Main.RotationYVelocity = -.1f;
    Camera.Main.CameraCullMode = CameraCullMode.None;

![200SpritesCullingOff.png](/media/migrated_media-200SpritesCullingOff.png)
