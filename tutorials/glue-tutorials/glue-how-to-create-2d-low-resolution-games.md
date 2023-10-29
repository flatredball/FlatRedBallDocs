# glue-how-to-create-2d-low-resolution-games

### Introduction

FlatRedBall is well-suited to make 2D games; however, due to the lower resolution of older games (such as on the NES and SNES), you may need to make some modifications to your game to get a 8-bit or 16-bit look.

For this tutorial we'll use the following image, which matches the default resolution of the NES (256x240):

![MountainsAndOcean.png](../../../media/migrated\_media-MountainsAndOcean.png)

### Setup

This tutorial will use Glue. To begin:

1. Create a new project in Glue for XNA 4 PC. I'll call it LowResDemo
2. Add a new Screen called GameScreen
3. Download the MountainsAndOcean file from above
4. Drag+drop the downloaded .PNG into your Screen's "Files"

![MountainsAndOceanInGlue.png](../../../media/migrated\_media-MountainsAndOceanInGlue.png)

### Creating a Sprite

Next we'll add a Sprite to view this graphic. In a typical game you might have many objects (including other Entities) in a Screen; however, since we're focusing on the game resolution we'll simply use a single Sprite to simulate a more complicated game. To do this:

1. Right-click on your Screen's "Objects"
2. Select "Add Object"
3. Select "FlatRedBall or Custom Type"
4. Select the Sprite type in the list box that appears
5. Click OK
6. Select the newly-created SpriteInstance object
7. Change its Texture to "MountainsAndOcean"

![SpriteWithMountainTexture.PNG](../../../media/migrated\_media-SpriteWithMountainTexture.PNG)

### Running the game

At this point if we run the game we'll see that the Sprite is visible and rendered; however, there is a lot of black space around the Sprite.

![LowResDemo1.PNG](../../../media/migrated\_media-LowResDemo1.PNG)

### Setting the game's resolution

First we'll solve this problem by fixing the resolution of the game in Glue. Instead of running the game at the default resolution of 800x600, we'll tell Glue to run the game at 256x240.

To do this:

1. In Glue, click "Settings"->"Camera Settings"
2. Click the "Set Resolution" check box
3. Enter 256 as the width and 240 as the height

![CameraSettingsForLowResDemo1.PNG](../../../media/migrated\_media-CameraSettingsForLowResDemo1.PNG)

Close the window and run the game again, and you should see that the game runs at a much smaller resolution:

![LowResDemo2.PNG](../../../media/migrated\_media-LowResDemo2.PNG)

### Making the window bigger

At this point you may be satisfied with the game; however, some users may not like how small the game window is - especially when played on a high-resolution monitor. We can address this by adjusting the resolution and orthogonal values.

First, we'll adjust the resolution values by setting them to a higher value. They were 800x600, then we reduced them to 256x240. We'll double the width and height:

1. Set the Camera Settings Resolution Width to 512
2. Set the Camera Settings Resolution Height to 480

Of course, increasing the resolution will also increase how many units wide our visible area is (from 256 to 512). To fix this, we can manually tell our game to run with a certain number of units wide/tall - this is referred to as the "Orthogonal Values" in Glue. To change the Camera's Orthogonal Values:

1. Open the Camera Settings
2. Check the "Set Values to:" under "Orthogonal Values"
3. Set the Width to 256
4. Set the Height to 240

![ResolutionAndOrthoSet.PNG](../../../media/migrated\_media-ResolutionAndOrthoSet.PNG)

Now if you run the game you'll notice that the game window is much larger, but there are no black borders:

![LargerWindowLowResDemo3.PNG](../../../media/migrated\_media-LargerWindowLowResDemo3.PNG)

### The game is "blurry"

You may notice that the game is blurry. The reason for this is because the game is actually running in higher resolution than 256x240, and the engine is applying "filtering", which smooths out or "blurs" Sprites. We can turn this off to make the game feel like a classic game. To do this:

1. Open the project in Visual Studio
2. Navigate to Game1.cs
3. Navigate to the Initialize function
4. After FlatRedBallServices.Initialize, add the following line of code:

&#x20;

```
FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;
```

Now if you run the game you will see sharp pixels:

![LowResDemo4.PNG](../../../media/migrated\_media-LowResDemo4.PNG)
