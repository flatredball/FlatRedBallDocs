## Introduction

SetPixelPerfectScale is a method which will adjust a Text object so that it renders pixel-perfect on the argument Camera. This method is automatically called on Text objects when added to the [FlatRedBall.Graphics.TextManager](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.md "FlatRedBall.Graphics.TextManager"). For more information on this behavior, see [the AddText page](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.md.AddText "FlatRedBall.Graphics.TextManager.AddText"). In the simplest situations this function will automatically be called for you and you won't need to do anything to have Text appear properly. For more information on when to call this function, see the next section. SetPixelPerfectScale sets the following properties on the Text instance that calls it:

-   [Scale](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.Scale&action=edit&redlink=1.md "FlatRedBall.Graphics.Text.Scale (page does not exist)")
-   [Spacing](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.Spacing&action=edit&redlink=1.md "FlatRedBall.Graphics.Text.Spacing (page does not exist)")
-   [NewlineDistance](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.NewlineDistance.md "FlatRedBall.Graphics.Text.NewlineDistance")

## Common usage

You will not need to use SetPixelPerfectScale if you create a Text and do not adjust the Text object or the Camera after the Text object has been instantiated. However, you will need to call this method if any of the following modifications are made:

-   The Camera's Z value is changed (assuming the Camera is 3D)
-   The Camera's Orthogonal values are changed (assuming the Camera is Orthogonal)
-   The Text's Z is changed (assuming the Camera is 3D)
-   The Text is attached to an object with a different Z value than the Text (assuming the Camera is 3D)
-   The Text is added to a Layer that uses a custom coordinate system (such as 2D Layers in Glue)

### Glue uses SetPixelPerfectScale

Glue assumes that Text objects should be drawn pixel-perfect, so it calls SetPixelPerfectScale on Text objects after they are initialized in generated code. This means that you don't have to call SetPixelPerfectScale on Texts which are added through Glue, unless modifications are made after the generated code has executed.

## Code Example

The following code shows how to use SetPixelPerfectScale:

    Text text = TextManager.AddText("Hello");
    text.Z = 5; // the Z has been modified, so let's adjust the scale

    // If the Text were added to a Layer, then pass the Layer as the argument instead of the Camera
    text.SetPixelPerfectScale(SpriteManager.Camera);

### Moving 3D Camera Exaple

Text objects are true 3D objects - they can be scaled, rotated, and positioned in 3D space. Similarly, they are affected by their distance from the camera. If a Text object moves closer to a 3D [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera"), or similarly if a 3D [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") moves closer to a Text object, it will apparently change size. This is often undesirable. Therefore, to "counter" the size change of a Text object when a 3D [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") changes its distance (often Z value), the Text's Scale, Spacing, and NewLineDistance must change. The SetPixelPerfectScale greatly simplifies this process. The following code creates 3 Text objects and sets the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") velocity so that it is slowly moving forward. One Text object remains unchanged while the other changes its size every frame by calling SetPixelPerfectScale. Add the following to a Screen's CustomInitialize Initialize method:

    Camera.Main.Orthogonal = false;

    text1 = TextManager.AddText("I'll stay the same size.");
    text1.HorizontalAlignment = HorizontalAlignment.Center;

    text2 = TextManager.AddText("I'll get resized.");
    text2.HorizontalAlignment = HorizontalAlignment.Center;
    text2.Y = 2;
      
    // Make the camera move forward slowly.
    SpriteManager.Camera.ZVelocity = -.6f;

Add the following to the same Screens' CustomActivity:

    text2.SetPixelPerfectScale(SpriteManager.Camera);

![TextResizing.png](/media/migrated_media-TextResizing.png)
