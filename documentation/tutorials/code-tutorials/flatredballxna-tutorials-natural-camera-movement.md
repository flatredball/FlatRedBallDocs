## Introduction

Making your Camera move naturally can make a lot of difference in the presentation of your game. What makes Camera movement somewhat tricky is that getting it right can be an art, but the actual programming behind it requires some math.

This article will discuss some common techniques used in FlatRedBall games to give your Camera a natural feel.

All of the code that we'll write to apply to the Camera is **not Camera-specific**. In other words, this code can be applied to any PositionedObject. We'll be using common PositionedObject properties.

## The Setup

This example will be written completely inside a [Screen](/frb/docs/index.php?title=Screen.md "Screen"). If you're not familiar with [Screens](/frb/docs/index.php?title=Screen.md "Screen"), you may want to check the [Screens page](/frb/docs/index.php?title=Screen.md "Screen") for more information. Of course, we won't be doing a lot of [Screen](/frb/docs/index.php?title=Screen.md "Screen")-specific stuff beyond the initial setup, so you don't have tor ead much beyond that.

## Creating our Screen

The very first step is to create a new FlatRedBall template using any version of the engine. This article is written for 3D coordinates, so if you are using pixel coordinates, or a version of FlatRedBall that defaults to 2D (such as FlatSilverBall) you may need to perform some conversions between the numbers you see here and what you put in your code.

Once you have an empty template, add a new Screen called CameraMovementScreen. If you need help doing this, check the [How to use Screens page](/frb/docs/index.php?title=Screen.md:How_to_use_Screens#Downloading_the_Screen_Template "Screen:How to use Screens").

Once you do this you should have an empty Screen that is ready to be filled in.

![NewScreen.png](/media/migrated_media-NewScreen.png)

## Using the Screen

The next step in our setup is to get our Screen to be the active Screen. To do this, add the following line in your Game class' Initialize method:

    Type screenType = typeof(CameraMovementScreen);
    ScreenManager.Start(screenType.FullName);

CONTINUE HERE
