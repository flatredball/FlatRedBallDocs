## Introduction

The ShowLineRectangles value controls whether dotted-line rectangles will be drawn around components. This value can help you debug where components are when they do not have visual elements, or to help you identify the clickable region when testing UI.

## FlatRedBall Editor Example

ShowLineRectangles can be set through the FlatRedBall Editor UI. To change this value in the editor:

1.  Select the gum project file (usually GumProject.gumx in Global Content Files)
2.  Click the **Gum Properties** tab
3.  Check or uncheck **Show Dotted Outlines**

![](/media/2022-01-img_61da76b50b642.png)

## Code Example Setting ShowLineRectangles

This value is applied only when new GraphicalUiElements are created, so changing it will not have an immediate impact on existing GraphicalUiElements. If you would like to turn off line rectangles, set this value to false **before** GlobalContent.Initialize is called in your Game1.cs file. For example, your code might look like this:

            protected override void Initialize()
            {
                FlatRedBallServices.InitializeFlatRedBall(this, graphics);
                CameraSetup.SetupCamera(SpriteManager.Camera, graphics);

                // Set ShowLineRectangles to false...
                GraphicalUiElement.ShowLineRectangles = false;

                // ...before GlobalContent.Initialize
            GlobalContent.Initialize();

                ...
