## Introduction

The IsOn3D method is a method which can be used to detect whether the mouse is over a variety of different objects. The reason it is called IsOn3D is because it performs a 3D test (ray cast) so it works regardless of the camera orientation of the orientation of the object being tested.

## IsOn3D and Text

The following code creates a [Text](/frb/docs/index.php?title=Text "Text") object. This text object will turn white when the mouse moves over the [Text](/frb/docs/index.php?title=Text "Text"), but will remain blue if the mouse is not over it.

Add the following using statements:

    using FlatRedBall.Graphics;
    using FlatRedBall.Input;

Add the following at class scope:

    Text text;

Add the following to Initialize after initializing FlatRedBall:

    IsMouseVisible = true;

    text = TextManager.AddText("Hi, I am some text.");
    text.X = .1f; // do this so the text doesn't appear between pixels
    text.Y = .1f;

Add the following to Update:

    bool relativeToCamera = false;

    if (InputManager.Mouse.IsOn3D(text, relativeToCamera))
    {
      text.Red = 1;
    }
    else
    {
       text.Red = 0;
    }

![IsOn3DText.png](/media/migrated_media-IsOn3DText.png)

**Warning**: You should always use the non-generic version of IsOn3D when performing tests on [Text](/frb/docs/index.php?title=Text "Text") objects. Want to know more? Read on!

There are a number of overloads for the IsOn3D method. The two which apply to the [Text](/frb/docs/index.php?title=Text "Text") object are:

    public bool IsOn3D(Text text, bool relativeToCamera)

    public bool IsOn3D<T>(T objectToTest, bool relativeToCamera) where T : IPositionable, IRotatable, IReadOnlyScalable

You may be wondering which to use, why there are two versions, and how you can pick which version you are using.

First, you should use the non-generic version. That is, you should use the version that takes a Text argument.

So why are there two versions? The reason is because the generic IsOn3D is a method that is used to test whether the Mouse is over types such as [Sprites](/frb/docs/index.php?title=Sprite "Sprite") and [SpriteFrames](/frb/docs/index.php?title=SpriteFrame "SpriteFrame"). Since these objects all implement IPositionable, IRotatable, and IReadOnlyScalable, then this generic function works well.

The reason that the Text object can use the generic version of IsOn3D is because it also implements the necessary interfaces; however, even though it implements the IReadOnlyScalable, it is slightly different from the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") and [SpriteFrame](/frb/docs/index.php?title=SpriteFrame "SpriteFrame") classes.

The [Sprite](/frb/docs/index.php?title=Sprite "Sprite") and [SpriteFrame](/frb/docs/index.php?title=SpriteFrame "SpriteFrame") classes both are always centered on their position. This means that the right edge of these objects is always X + ScaleX. However, this is not the case for the [Text](/frb/docs/index.php?title=Text "Text") object due to its VerticalAlignment and HorizontalAlignment properties. These properties can change how the Text is drawn relative to its actual position. For this reason, the assumption that the [Text's](/frb/docs/index.php?title=Text "Text") position is at its center is not valid.

This means that if the [Text](/frb/docs/index.php?title=Text "Text") object is centered both horizontally and vertically, then the generic IsOn3D will accurately determine whether the mouse is over the [Text](/frb/docs/index.php?title=Text "Text"). But if either property is not centered, then the generic IsOn3D will not perform accurately.

The non-generic version of IsOn3D (which has a [Text](/frb/docs/index.php?title=Text "Text") argument) can perform [Text](/frb/docs/index.php?title=Text "Text")-specific logic to accurately determine whether the mouse is over the [Text](/frb/docs/index.php?title=Text "Text") object regardless of the HorizontalAlignment or VerticalAlignment.

This brings us to the third question - how can you pick which you are using? This all depends on how you call the method. The following code shows how to call each version:

    // This calls the generic version:
    InputManager.Mouse.IsOn3D<Text>(myText, false);

    // This calls the non-generic version (the one you should probably call):
    InputManager.Mouse.IsOn3D(myText, false); 

## Working with Multiple Cameras

The following code creates two [Cameras](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"). Both cameras view a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). If the cursor is over the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") on either [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera") then it turns purple.

Add the following using statements:

    using FlatRedBall.Graphics;
    using FlatRedBall.Input;

Add the following at class scope:

    Text text;
    Sprite sprite;

Add the following to Initialize after initializing FlatRedBall:

    IsMouseVisible = true;

    SpriteManager.Camera.SetSplitScreenViewport(Camera.SplitScreenViewport.LeftHalf);

    Camera camera = new Camera();
    SpriteManager.Cameras.Add(camera);
    camera.SetSplitScreenViewport(Camera.SplitScreenViewport.RightHalf);
    camera.Z = 20;

    sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ColorOperation = ColorOperation.Add;

Add the following to Update:

    foreach (Camera camera in SpriteManager.Cameras)
    {
        // The following method is only available in June 2008 and newer
        if (InputManager.Mouse.IsOn(camera))
        {
            if (InputManager.Mouse.IsOn3D(sprite, false, camera))
            {
                sprite.Blue = 1;
            }
        }
    }

## Selecting multiple objects

At the time of this writing there is no method to simply return all of the objects that the Mouse is over - instead you will have to manually loop through all objects to test whether the mouse is over the object. This means there are a few things to consider:

1.  Performance may suffer if you have a lot of objects in your scene. If you are suffering from performance issues you may need to perform some type of higher-level partitioning to reduce calls to this method.
2.  You will need to manually loop through objects and maintain a list of objects which you are over if you are interested in performing multiple-selection.

![MultipleCameraMousePicking.png](/media/migrated_media-MultipleCameraMousePicking.png)
