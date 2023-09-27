## Introduction

The destination values represent the bounds that the Camera will draw to relative to the top-left of the window. By default the bounds are set to fill up the entire window. Changing these values will result in the area being drawn being smaller. These values can be used to implement a split-screen view. Since the default bounds of a Camera use the full screen, the DestinationRectangle can be used to get the resolution of your game. When setting the DestinationRectangle it is recommended that you use even values for all dimensions. In other words, the Width and Height of the rectangle should be even. Odd-sized DestinationRectangles can make pixel-perfect text render improperly.

## Code Example

The following code shows how changing the destination values impacts drawing. Notice that the background color of the Camera has been set to blue so that its drawn area can easily be identified.

    SpriteManager.AddSprite("redball.bmp");

    Camera.Main.LeftDestination = 100;
    Camera.Main.TopDestination = 200;
    // We'll leave the bottom and right to their default values (the edges of the window)
    Camera.Main.BackgroundColor = Microsoft.Xna.Framework.Graphics.Color.Blue;

![CameraDestinationValues.png](/media/migrated_media-CameraDestinationValues.png)
