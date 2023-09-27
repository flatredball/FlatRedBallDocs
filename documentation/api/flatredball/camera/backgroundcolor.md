## Introduction

The BackgroundColor property specifies what the background color will be cleared to every frame. To prevent the background from clearing every frame, set the Alpha of the BackgroundColor to 0. See more information below on this topic.

## Code Example

The following changes the BackgroundColor in response to user input. Add the following to your Screen's CustomActivity:

    if (FlatRedBall.Input.InputManager.Keyboard.KeyPushed(Keys.Up))
    {
        Camera.Main.BackgroundColor =
            Microsoft.Xna.Framework.Color.Red;
    }
    if (FlatRedBall.Input.InputManager.Keyboard.KeyPushed(Keys.Down))
    {
        Camera.Main.BackgroundColor =
            Microsoft.Xna.Framework.Color.Blue;
    }

![CameraBackgroundColor.png](/media/migrated_media-CameraBackgroundColor.png)

## Transparent Background Color

When a Camera is drawn, the first thing that is done is its DestinationRectangle is painted to the background color. If you have multiple Cameras which overlap and you'd like Cameras which are on top to not write over what's already been drawn by previous Cameras, you can set the BackgroundColor to a color that has an alpha of 0. BackgroundColor for any Cameras except the default one contained in the [SpriteManager](/frb/docs/index.php?title=SpriteManager.md "SpriteManager") is transparent. You will need to change the background color if you are making a split-screen game to something no-transparent.

## Drawing before FlatRedBall is Drawn

If you would like to draw to the screen before FlatRedBall draws, you can do so, but you must do the following:

1.  Set the Camera's Color's Alpha to 0
2.  Turn off [RenderTargets](/frb/docs/index.php?title=FlatRedBall.Graphics.Renderer.md "FlatRedBall.Graphics.Renderer").
