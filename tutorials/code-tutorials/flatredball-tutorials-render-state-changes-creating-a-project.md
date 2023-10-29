# flatredball-tutorials-render-state-changes-creating-a-project

### Introduction

The rest of these tutorials will present ideas for reducing render breaks, but we'll do so by working on a real project and measuring the result of our changes.

### Creating a Project

This tutorial assumes you are familiar with how to create a FlatRedBall project. Although the following tutorials will be almost all code (as opposed to being created through Glue), we will still create our project through Glue and add a Screen to contain our tests in Glue.

To set up your project:

1. Open Glue
2. Select to create a new project
3. Select your platform - I'll be using Windows Phone 7 as this platform does not handle render breaks as well as the PC.
4. Enter a name for your project. I'll name mine Wp7Performance.

### Creating a Screen

Once your project is created, add a Screen:

1. Right-click on the Screens tree item
2. Select "Add Screen"
3. Enter the name TextureTestScreen
4. Click OK

### Adding Textures

We'll use two textures to adjust how many render breaks occur per frame. To add the two textures:

1. Download the following two files:![Greenball.png](../../../media/migrated\_media-Greenball.png)![Redball.png](../../../media/migrated\_media-Redball.png)
2. Expand TextureTestScreen
3. Add both files to Glue - either by dropping the files onto the Files tree node from an explorer, or by right-clicking on the Files item and selecting "Add File"->"Existing File"

### Measuring Baseline Performance

First we'll create a project to get some baseline numbers. To do this we'll create 1000 Sprites which all use the same texture. To do this:

1. Open the project in Visual Studio
2. Open TextureTestScreen.cs
3. Add the following to CustomInitialize:

&#x20;

```
for (int i = 0; i < 1000; i++)
{
    Sprite sprite = SpriteManager.AddSprite(redball);
    SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
}
```

Next we need to set up our game to measure performance. To do this:

1. Open Game1.cs in Visual Studio
2. Verify that the Game1 constructor is not setting the project's resolution. Commenting out the lines that set PreferredBackBufferWidth and PreferredBackBufferHeight allow us to run in landscape mode.
3. Add the following two lines of code to the Game1 constructor:

&#x20;

```
 IsFixedTimeStep = false;
 graphics.SynchronizeWithVerticalRetrace = false;
```

Also, when measuring you will want to run the game without being attached to Visual Studio. You can accomplish this by either:

* Pressing CTRL+F5 to run the game
* Selecting the menu option Debug->"Start Without Debugging"

Finally we'll add some reporting output to TextureTestScreen.cs. To do this:

1. Open TextureTestScreen.cs
2. Add the following code to CustomActivity:

&#x20;

```
string debugMessage = "FPS: " + 1 / TimeManager.SecondDifference +
    "\nRender Breaks: " + FlatRedBall.Graphics.Renderer.RenderBreaksAllocatedThisFrame;

FlatRedBall.Debugging.Debugger.Write(debugMessage);
```

This code uses the [TimeManager.SecondDifference](../../../frb/docs/index.php) to measure framerate. This will not return accurate framerate values if you do not turn off fixed time step and vsync (as done above). For more information, see the [TimeManager.SecondDifference page](../../../frb/docs/index.php).

![BaselineRenderBreaks.png](../../../media/migrated\_media-BaselineRenderBreaks.png) Although my screen shot reads 25 fps, the emulator actually was pegged at around 29 fps normally. Also, the engine currently creates two render breaks while rendering this frame. This is likely because of the Sprites creating one and the Text used to render the output creating a second. This small number doesn't matter so much. Render breaks can become an issue when dealing dozens or hundreds of render breaks, as we will show soon.

### Introducing Render Breaks

Next we'll use the second texture (greenball) to introduce render breaks to the system that we have. We will do this by by making every-other Sprite use the greenball texture. Also, to maximize render breaks, we will also adjust the Z of each Sprite so that each Sprite has a smaller Z value than the one before it. The result will be that the Renderer will need to create a new render break for each Sprite. To do this, modify the CustomInitialize method so it looks like this:

```
for (int i = 0; i < 1000; i++)
{
    Sprite sprite;
    if (i % 2 == 0)
    {
        sprite = SpriteManager.AddSprite(redball);
    }
    else
    {
        sprite = SpriteManager.AddSprite(greenball);
    }
    SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);
    sprite.Z = i * -.001f;
}
```

![LotsOfRenderBreaks.png](../../../media/migrated\_media-LotsOfRenderBreaks.png)

Notice that the frame rate which was previously pegged at 29 (the Windows Phone limits it to 30) is now around 5. We're still rendering the same number of Sprites, and they're approximately the same distance away from the camera so fill rate should be about the same. We only introduced a second texture which we switch back and forth between on every Sprite.

\*\*Emulator vs. Phone:\*\*Ultimately when you are measuring performance you will want to measure it on the actual device. Even though the emulator does a fantastic job of allowing you to test Windows Phone 7 games on a PC, it does not mimic every characteristic of the phone. We've also noticed that the emulator is subject to the speed of the computer it is running on, so your PC may also add variability to the measurements.

The above two pieces of code (which ran at 29 fps and 5 fps respectively in the emulator) ran at 29 and 12 fps on my HTC HD7 phone.

Notice that we are pegged at 29 fps when using the same texture. I also tried increasing the Sprite count higher and got the following:

```
3000 Sprites same texture (Emulator): 29 fps
3000 Sprites same texture (Device):  16 fps
3000 Sprites alternating texture (Emulator): 2 fps
3000 Sprites alternating texture (Device): 4.6 fps
```

It's intersting that the emulator is able to handle a large number of Sprites with no state changes better than the actual phone, but the actual phone can handle state changes better than the emulator; however, the point remains that state changes have a very significant impact on performance whether in an emulator or device.

We will continue to use the emulator for screen shots and measurement of performance for the rest of these tutorials; however, we recommend always measuring changes you make to your program on the actual device.
