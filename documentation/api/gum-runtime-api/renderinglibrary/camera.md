## Introduction

The RenderingLibrary.Camera object provides control over the viewable area when rendering Gum objects (and any other non-Gum object added directly to the rendering library). In many cases FlatRedBall games do not interact with this object. If the RenderingLibrary.Camera is not modified, then the top-left corner is (0,0) and all objects render at 1:1 scale. Strictly speaking, the Camera object belongs to the RenderingLibrary, which is a basic rendering engine used by Gum. However, most FlatRedBall games use the RenderingLibrary to render Gum, so in many cases it can be thought of as the "Gum camera". The RenderingLibrary.Camera enables simple modifications to how Gum objects are rendered, such as adjusting zoom and offset values.

## Accessing the Camera

By default, games that use Gum rely on the **Default** set of RenderingLibrary objects. Therefore, the following code can be used to access the camera:

``` lang:c#
var gumCamera = RenderingLibrary.SystemManagers.Default.Renderer.Camera;
```

## Moving the Camera

The Camera can be moved by changing its X and Y values. Moving the Camera will adjust the position of all on-screen Gum objects. The following code can be used to move the Camera up and down with up and down arrow keys:

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;

    var gumCamera = RenderingLibrary.SystemManagers.Default.Renderer.Camera;

    if(keyboard.KeyPushed(Keys.Up))
    {
        gumCamera.Y-=5;
    }
    if (keyboard.KeyPushed(Keys.Down))
    {
        gumCamera.Y+=5;
    }
}
```

         
