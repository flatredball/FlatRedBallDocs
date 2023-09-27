## Introduction

Gum and the Gum plugin provide a number of options for dealing with various game resolutions. This tutorial will walk you through the different ways to work with resolutions.

## Default Values

When you work with a Gum project, you can specify the resolutions that you're targeting. This can be done as follows:

1.  Go to Edit-\>Project Properties
2.  Change the "DefaultCanvasHeight" or "DefaultCanvasWidth" to the desired values.
3.  Notice the blue dotted line changing in response to the changed values.

![ChangeGumResolution.gif](/media/migrated_media-ChangeGumResolution.gif) If your game is going to run at a fixed resolution, then you can set the resolution of your Gum project and everything will match. For information on how to set the resolution of your project in Glue, see [this page](/frb/docs/index.php?title=Glue:Reference:Menu:Settings:Camera_Settings.md "Glue:Reference:Menu:Settings:Camera Settings").

## Zooming UI

Gum allows you to zoom your entire UI in or out at runtime. This can be useful in a number of situations:

1.  If you are creating a game that targets a lower-resolution device (such as a non-retina iOS device), but you want the game to also run on retina devices. In this case you may want to zoom your UI when running on retina displays.
2.  If you are intentionally creating a low-resolution game to give it a "retro feel".

For this example, I will set my entire game resolution (in Glue) to be 800x600 (the default), but I will make my Gum project use a resolution of 400x300. I will add a single NineSlice in Gum which will take up the entire (400x300) view: ![400x300NSInGum.PNG](/media/migrated_media-400x300NSInGum.PNG) If the game is run now you'll notice that the NineSlice only takes up a quarter of the screen: ![NineSliceBeforeZoom.PNG](/media/migrated_media-NineSliceBeforeZoom.PNG) You can tell the Gum project to zoom everything 2x, which results in the the NineSlice being twice as wide and twice as tall - resulting in it taking up the entire screen. More generally speaking, this makes the bounds of the Gum screen twice as tall and twice as wide, so it will match the resolution of the game at runtime. You can add the following code to your screen's CustomInitialize:

    void CustomInitialize()
    {
        RenderingLibrary.SystemManagers.Default.Renderer.Camera.Zoom = 2;
    }

![ZoomedNineslice.PNG](/media/migrated_media-ZoomedNineslice.PNG)

## Automatic (default) adjustment

If you are setting the resolution of your game through Glue, then the Gum canvas size will automatically adjust to the starting value as set by Glue in generated code. In other words, even though our Gum project was defined as a 400x300 project and our game is 800x600, the Gum canvas will expand to 800x600 automatically. Note that this requires that the game's resolution and orthogonal values are equal, as shown in the following image:

![](/media/2017-01-img_5876ff6c5dc54.png)

For situations where Orthogonal Values do not equal the game's resolution, see the section below. In the previous example the NineSlice still took up 1/4 of the screen even though the Gum canvas expanded. The reason for this is because the NineSlice was using "absolute" width and height values which were set to 400x300. If we change the width and height values to be relative to the container of the NineSlice (which is the entire screen) then the NineSlice will automatically expand to fill the entire Screen. To do this, set the NineSlice's width and height values to be relative to its container (which is the entire screen):

1.  Select the NineSlice instance
2.  Set the "Width Units" to "RelativeToContainer"
3.  Set the "Height Units" to "RelativeToContainer"

![MakeNineSliceRelativeToContainer.gif](/media/migrated_media-MakeNineSliceRelativeToContainer.gif) For this example, remove the code to set the Camera.Zoom value. If we run the game now, the NineSlice will automatically fill up the entire screen: ![NineSliceEntireScreen.PNG](/media/migrated_media-NineSliceEntireScreen.PNG)

## Dynamically changing the canvas dimensions

Although the generated code automatically adjusts the canvas width and height according to the Gum settings, your game may require adjustment of the resolution after launching. Common examples of this may include docking a Windows 8 app, or resizing a Windows desktop app. For this example my Screen will set the resolution to 500x500, and then I'll adjust the Gum canvas to match:

    void CustomInitialize()
    {
        // First we'll set the game window (and FlatRedBall) to be 500x500
        FlatRedBallServices.GraphicsOptions.SetResolution(500, 500);

        // Then we'll tell Gum to set its canvas size to match:
        Gum.Wireframe.GraphicalUiElement.CanvasWidth = 500;
        Gum.Wireframe.GraphicalUiElement.CanvasHeight = 500;

        // Finally we need to redo the layout for the entire Screen.
        // My screen is called "Screen1", so I use Screen1.Element:
        Screen1.Element.UpdateLayout();
    }

![After500Resolution.PNG](/media/migrated_media-After500Resolution.PNG) The CanvasWidth  and CanvasHeight  values can be adjusted in an event reacting to the resizing of a FRB window as follows:

    void CustomInitialize()
    {
        FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += HandleResize;
    }

    private void HandleResize(object sender, EventArgs e)
    {
        var newWidth = FlatRedBallServices.GraphicsOptions.ResolutionWidth;
        var newHeight = FlatRedBallServices.GraphicsOptions.ResolutionHeight;

        Gum.Wireframe.GraphicalUiElement.CanvasHeight = newHeight;
        Gum.Wireframe.GraphicalUiElement.CanvasWidth = newWidth;

        YourGumScreen.Element.UpdateLayout();
    }

    // Unsubscribe when the screen destroys itself to prevent a memory leak:
    void CustomDestroy()
    {
        FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= HandleResize;
    }

## Working with Different Resolution and Orthogonal Values

So far we've looked at situations where the orthogonal value equals the resolution of the game. Games which use an orthogonal camera and target mobile devices may use fixed Orthogonal Width and Orthogonal Height values in Glue, but the resolution depends on the device. We can simulate this on PC by setting the values as shown in the following Glue Camera window (we'll set the resolution to be extra wide to help show the problem):

![](/media/2017-01-img_5877011b71e64.png)

In this case, the Gum rendering engine will expand itself to fill the entire rendering area, but it will maintain its aspect ratio. In other words, our canvas will be 800 units tall (to match the game's resolution), but the width will be limited to the 4:3 aspect ratio as set in the Orthogonal Values.

![](/media/2017-01-img_587701c251ec9-1024x532.png)

In this case we will update the canvas width to match the game's aspect ratio as shown in the following code:

``` lang:c#
var aspectRatio = Camera.Main.AspectRatio;
Gum.Wireframe.GraphicalUiElement.CanvasWidth = Gum.Wireframe.GraphicalUiElement.CanvasHeight * aspectRatio;

Screen1.Element.UpdateLayout();
```

This adjustment will result in the canvas widening to the appropriate aspect ratio. Since the nine slice automatically fills up the screen (when UpdateLayout is called), this will expand the nine slice to the full display width:

![](/media/2017-01-img_587703aaca238-1024x532.png)

     
