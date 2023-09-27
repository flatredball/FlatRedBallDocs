## Introduction

The RenderAll function performs rendering of all visual FlatRedBall objects on all Layers. This method is normally not manually called by code outside of FlatRedBall - it is automatically called by [FlatRedBallServices.Draw](/documentation/api/flatredball/flatredball-flatredballservices/flatredball-flatredballservices-draw/.md "FlatRedBall.FlatRedBallServices.Draw") - a method which is automatically included in all FlatRedBall templates. This method is exposed so that it can be called independent of [FlatRedBallServices.UpdateDependencies](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.UpdateDependencies&action=edit&redlink=1.md "FlatRedBall.FlatRedBallServices.UpdateDependencies (page does not exist)") for performance and customization reasons. The Render call is responsible for the following:

-   Calling [Renderer.Draw](/documentation/api/flatredball/flatredball-graphics/flatredball-graphics-renderer/flatredball-graphics-renderer-draw/.md "FlatRedBall.Graphics.Renderer.Draw") to perform the rendering. This call is made inside a lock on the [Renderer.GraphicsDevice](/frb/docs/index.php?title=FlatRedBall.Graphics.Renderer.GraphicsDevice&action=edit&redlink=1.md "FlatRedBall.Graphics.Renderer.GraphicsDevice (page does not exist)"). The reason for this lock is to prevent the graphics device from being used in rendering while a separate thread is attempting to load a Texture2D. Since Glue easily allows the creation of loading screens, loading on separate threads is quite common.
-   Resetting the textures on the device.

As mentioned above, this method is normally not called manually in games; however you can call it manually if you are debugging, or performing advanced rendering with render targets. The RenderAll function can be replaced with the following code:

    lock (Renderer.Graphics.GraphicsDevice)
    {
        Renderer.Draw(section);
    }
    Renderer.Texture = null;
    FlatRedBallServices.GraphicsDevice.Textures[0] = null;
