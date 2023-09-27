## Introduction

The AnimationEditor is a tool which simplifies the creation and editing of AnimationChainList files (.achx files). AnimationChainLists are the standard file format for sprite animations.

## Opening the AnimationEditor

The AnimationEditor is distributed along FRB in the FRBDK.zip file. For info on downloading the FRBDK.zip file, see the [Downloads page](/download/.md). You can open the AnimationEditor by either:

-   Double-clicking a .achx file in the FRB Editor. Note that if you have not set up the Windows file association for .achx files, you may be asked how to open this file. You can select to use the AnimationEditor.exe, which is located in the place shown in the next point: ![](/media/2023-06-img_649226c0a5464.png)
-   Or opening the AnimationEditor.exe in the XNA 4 Tools folder ![](/media/2021-01-img_5ff8eabb97e17.png)

You can also add a new .achx file to your FlatRedBall project in any Screen, Entity, or in Global Content Files:

1.  Right-click on the Files folder in any Screen or Entity, or in Global Content Files

2.  Select **Add File** -\> **New File**

    ![](/media/2023-07-img_64aff8b27d18d.png)

3.  Select **Animation Chain List (.achx)**

4.  Click ****OK****

    ![](/media/2023-07-img_64aff8eb27900.png)

### Troubleshooting the AnimationEditor

If you are seeing a popup that tells you that XNA is not available, then you probably do not have the XNA runtimes installed. The text for this error might look like this: System.IO.FileNotFoundException: Could not load file or assembly 'Microsoft.Xna.Framework.Graphics.dll' or one of its dependencies. The specified module could not be found. To fix this problem, install the XNA 4 redistributable: https://www.microsoft.com/en-us/download/details.aspx?id=27598   Once you run AnimationEditor.exe you will have an empty animation project.

![](/media/2021-01-img_5ff8eb36a9e5c.png)

## Creating an Animation

To create an animation:

1.  Click the + icon on the left-side of the window

    ![](/media/2018-03-img_5ab7d409cee3b.png)

2.  Enter the name "Idle" and click OK

Next we'll add a frame to our animation. To do this:

1.  Right-click on the newly-added Idle animation
2.  Select "Add Frame" ![WithUntexturedFrame.PNG](/media/migrated_media-WithUntexturedFrame.PNG)

## Setting the Texture

Now we have an animation with one frame, but the frame does not yet have a texture associated with it. Textures are image files which are displayed by the frame. To add a texture:

1.  Save this file to your computer. [![](/wp-content/uploads/2016/01/Idle.png.md)](/wp-content/uploads/2016/01/Idle.png.md) The location doesn't matter, but remember where you save it because you will need to find it later. However, if you would like to use this file in a FlatRedBall project, you will want to save this file somewhere in your project's Content folder.
2.  Click the button for the "TextureName" property ![ClickTextureButton.png](/media/migrated_media-ClickTextureButton.png)
3.  Navigate to where you saved the Idle.png file and select it
4.  You may see a window asking you if you want the file copied. In most cases you do; however you may not if in the future you are working with textures which are shared between multiple files which are not in the same location. ![CopyFileWindow.PNG](/media/migrated_media-CopyFileWindow.PNG)

You should now see your art in the AnimationEditor plugin: ![TextureInAE.PNG](/media/migrated_media-TextureInAE.PNG)

## Setting the frame using SpriteSheet values

The FRB editor provides a number of ways to specify the region of a texture which will be displayed by a frame. If you are using separate image files for each frame of animation then you will not need to change the region values. However, if you are using a sprite sheet, then you will need to adjust the region that the frame displays.

**What is a sprite sheet? **In the context of the AnimationEditor plugin, a sprite sheet is a image file which contains multiple frames of animation. Although not necessary, many sprite sheets arrange each animation frame in a grid, and all frames are spread out evenly.

First we'll cover how to create animation frames using sprite sheets. To do this in the AnimationEditor plugin, the frames must be evenly spaced out. The Idle.png file supplied above is evenly spaced out, so it will work fine for this tutorial. First we need to tell the AnimationEditor plugin that we want to use sprite sheet coordinates. To do this:

1.  Set the combo box value at the top of the property grid to "SpriteSheet" ![SpriteSheetCoordinates.png](/media/migrated_media-SpriteSheetCoordinates.png)
2.  Find and select where it says **\<UNTEXTURED\> **in the leftmost menu area. You should then see an option for editing the cell width and cell height of the texture. Set the cell height to "2 cells". Notice that the plugin automatically calculates this value as 64 pixels after the value is selected. ![2CellsHigh.png](/media/migrated_media-2CellsHigh.png)
3.  Set the cell width to "4 cells"
4.  Notice that the preview window now shows the image divided up into its cells according to the values you just selected ![DividedImage.PNG](/media/migrated_media-DividedImage.PNG)

Now that the cells are set up properly, you can select the cell of a frame by clicking on the appropriate cell. Once the cell has been clicked on, it will highlight. The preview window (the window under the editing window) will also show the single frame as it will appear in game. ![SelectedFrameCell.PNG](/media/migrated_media-SelectedFrameCell.PNG)

## Adding Additional Frames

Once a single frame has been added, additional frames are very easy to add. To add another frame:

1.  Right-click on the Animation (which is called Idle)
2.  Select "Add Frame"
3.  The newly-added frame will be selected. Click on the cell that you want the frame to use ![SecondFrame.PNG](/media/migrated_media-SecondFrame.PNG)

Since the FRB editor remembers the cell settings, additional frames can be added with just a few mouse clicks. Try adding more frames so that your animation includes all 8 idle frames.

## Viewing the Animation

Once you have added all frames, you can view the animation as it will play in your game by clicking on the animation itself in the far-left window. The animation will play in the preview window automatically. Clicking on any individual frame will also update the preview window. Similar to other FRB tools, you can use the mouse wheel to zoom in and out, and you can hold the middle mouse button down to pan. These controls are available both in the editing window and the preview window. ![ZoomedIn.PNG](/media/migrated_media-ZoomedIn.PNG)

## Editing in Pixel Coordinates

If you are working with an image file which is not structured in a sprite sheet you can still use this file in the AnimationEditor plugin. In this situation you will need to use the "Pixel" coordinate mode. Next we'll use the Pixel coordinate mode to create a run animation. First, let's set up a frame:

1.  Download the following file to your computer: ![Running.png](/media/migrated_media-Running.png)
2.  Right-click in the far-left window and select "Add Animation"
3.  Enter the name "Run"
4.  Right-click on the newly-added animation and select "Add Frame"
5.  Select the downloaded Running.png image for the new frame's TextureName
6.  If asked, copy the file to the same folder as the AnimationChain

To edit the frame using pixel coordinates, change the "Sprite Sheet" value to "Pixel ![PixelSelectedInAnimationEditor.png](/media/migrated_media-PixelSelectedInAnimationEditor.png) You will now see a white square with 8 circle handles. You can push on the circles and drag to resize the frame. As you do so, you will notice that the preview window at the bottom updates in realtime. Keep in mind that you can pan and zoom by pushing/scrolling the mouse wheel. ![SelectedFramePixelCoordinates.PNG](/media/migrated_media-SelectedFramePixelCoordinates.PNG) Just like when we were using sprite sheets, we can add additional frames to our animation by right-clicking on it and selecting "Add Frame". Do this to add a second frame. The newly added frame will use the same region as the previous frame. You can move the mouse over the region and the cursor will turn into a cross with arrows to indicate that the region can be moved. Push the mouse button to move the frame to the appropriate location for the second frame. ![SecondFramePixelCoords.PNG](/media/migrated_media-SecondFramePixelCoords.PNG) To help keep the tutorial shorter we won't include the steps for creating the rest of the animation, but feel free to do so if you would like a complete running animation.

## Using the Guides

The AnimationEditor plugin provides rulers and guides to help you verify that animations are positioned properly. Next, we'll use guides to align our animations. The animations that we have been working with so far (idle and run) are created for a side-view game (specifically a platformer game). The location of the ground is an important consideration when working on games like these. Therefore, we will use guides to verify that the animations are aligned properly.

**Note: **I intentionally created the animations so that they were of different sizes. Your animations may or may not be set up this way, so keep that in mind when working through the rest of this guide tutorial.

The first step is to decide which animation we want to set up our guides to. I'll use the idle animation since we created it with sprite sheet coordinates, so it is likely more accurate. To do this:

1.  Select the "Idle" animation
2.  Zoom in on the preview of the animation (the bottom display)
3.  Click on the left side of the preview window on the ruler. A guide should appear ![GuideInPreview.PNG](/media/migrated_media-GuideInPreview.PNG)
4.  Push and drag on the guide line to adjust its position. Move the line so that it is just below the feet of the character so it represents the ground. The value of the line will update as the line moves ![AdjustGuideLine.png](/media/migrated_media-AdjustGuideLine.png)

Now that we have a guide which represents the ground we can select the other animation to see how it lines up. Click on the "Run" animation to view it relative to the guide. ![RunRelativeToGuide.PNG](/media/migrated_media-RunRelativeToGuide.PNG) Notice that the character is below the guide line. If we were to use this animation as-is in a platformer game, the character would appear to sink below the ground when running. We can fix this in a number of ways:

1.  Change the source .PNG to have the character positioned higher. This is not a good approach in this particular case because the art was actually created to include equally-spaced frames.
2.  Adjust the pixel coordinates of the frame to be lower, adding more transparent space under the character and shifting up the animation. While this is a good approach, we'll skip over it in favor of the next option.
3.  Set the relative values of each frame to shift the animation upward.

Next we'll cover how to shift each frame.

## Shifting Frames

Each frame can be independently positioned. By default all frames are not shifted at all - frames are positioned with their center at (0,0). To shift the first frame in "Run":

1.  Expand the Run animation
2.  Select the first frame
3.  Change the RelativeY value so that the character is positioned properly relative to the guide ![AdjustedRelativeY.PNG](/media/migrated_media-AdjustedRelativeY.PNG)

Once the RelativeY value (and similarly RelativeX) is changed, the preview window will update immediately, allowing you to update frames appropriately.
