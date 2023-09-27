## Introduction

The KeepSpriteInScreen method adjusts the absolute position of the argument Sprite so that it is fully in-view. This method makes a few assumptions:

-   The Camera is not rotated
-   The Sprite is in front of the Camera (has a smaller Z value than the Camera)

## Syntax

    public void KeepSpriteInScreen(Sprite sprite)

## Code Example

The following code creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which is moved around the screen by the [Keyboad](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard "FlatRedBall.Input.Keyboard") with the arrow keys. Add the following using statement:

    using FlatRedBall.Input;

Add the following at class scope:

    Sprite mSprite;

Add the following to Initialize after initializing FlatRedBall:

     mSprite = SpriteManager.AddSprite("redball.bmp");
     mSprite.ScaleX = 10;
     mSprite.ScaleY = 10;

Add the following to Update:

    // This moves the Sprite around
    InputManager.Keyboard.ControlPositionedObject(mSprite);
    // But this positions it so it stays in screen
    SpriteManager.Camera.KeepSpriteInScreen(mSprite);

![CameraKeepSpriteInScreen.png](/media/migrated_media-CameraKeepSpriteInScreen.png)

## KeepSpriteInScreen and Entities

As of the July 2010 release of FlatRedBall, the KeepSpriteInScreen method works properly even if the argument Sprite has a parent (a common setup when using Entities).
