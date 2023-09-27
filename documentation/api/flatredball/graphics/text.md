## Introduction

The Text object provides functionality for drawing bitmap fonts in 2D and 3D space. It inherits from the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") class and shares many similarities with the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") class. Just as the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") class is associated with the [SpriteManager](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager "FlatRedBall.SpriteManager"), the Text object is associated with the [TextManager](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.md "FlatRedBall.Graphics.TextManager"). Note that most games which use Text do so through Gum instead of using the FlatRedBall Text object.

## Creating a Text Instance in Code

The FlatRedBall engine stores a default [BitmapFont](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont.md "FlatRedBall.Graphics.BitmapFont") internally. Any Text object created will use this default [BitmapFont](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont.md "FlatRedBall.Graphics.BitmapFont"). To create a Text object in code, add the following to your Screen's CustomInitialize, or Game1.cs Initialize after initializing FlatRedBall:

``` lang:c#
Text text = FlatRedBall.Graphics.TextManager.AddText("Hello");
```

### A note about persistence

The Text object behaves the same as other FlatRedBall objects which have been added to their respective managers. This means that when you add a Text object, it will be drawn and updated automatically for you until it is removed.

### You **should not add text every frame**

A common mistake is to add and remove text every frame to change what it displays. Instead of doing this, you should set a text's DisplayText property to change what it says. For example:

    myText.DisplayText = CurrentScore.ToString();

For more information on the persistence of objects, see [this article](/frb/docs/index.php?title=Working_with_Sprites#A_note_about_persistence.md "Working with Sprites"). For code example comparing the approach of creating a new text vs. setting the DisplayText, see the [DisplayText page](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.DisplayText.md "FlatRedBall.Graphics.Text.DisplayText").

## DisplayText Property

The DisplayText property allows for changing the string that a Text object renders. The following code sets the text depending on whether the user has a gamepad connected: **Add the following include statements:**

    using FlatRedBall.Input;
    using FlatRedBall.Graphics;

**Add the following to the Initialize method after initializing FlatRedBallServices:**

     Text text = TextManager.AddText(""); // empty string for now

     if (InputManager.Xbox360GamePads[0].IsConnected == false)
     {
         text.DisplayText = "Gamepad at index 0 is disconnected";
     }
     else
     {
         text.DisplayText = "Gamepad at index 0 is connected";
     }

![DisconnectedText.png](/media/migrated_media-DisconnectedText.png)

## Text Object as PositionedObject

Text objects can be positioned just like any PositionedObject. For example, a text object's X and Y values can be set:

``` lang:c#
myTextObject.X = 50;
myTextObject.Y = -20;
```

For more information on [PositionedObject](/documentation/api/flatredball/flatredball-positionedobject/.md "FlatRedBall.PositionedObject") fields and properties, see the [PositionedObject entry](/documentation/api/flatredball/flatredball-positionedobject/.md "FlatRedBall.PositionedObject").

## Text Size

By default Text objects added through the FRB editor are sized to be *pixel perfect* given the game's resolution. The Text object provides a number of properties for changing size.

### TextureScale

TextureScale controls the size of the text relative to its source texture. A TextureScale of 1 results in the text drawing pixel perfect if the game is running at 100% scale. If the game runs at larger scale, then Text using a fixed TextureScale will drawn larger.

### SetPixelPerfectScale

The SetPixelPerfectScale function sets the text size to be pixel perfect given the argument camera or layer. The following code sets the Text to be pixel perfect to the main camera:

    TextInstance.SetPixelPerfectScale(Camera.Main);

Note that pixel-perfect text will not appear zoomed if the game settings are zoomed.  

### Individual Scale Values

The Text object provides three different variables for changing the size of text. These properties are:

-   Scale
-   Spacing
-   NewLineDistance

The following code creates three text objects which have non-default values for these three properties.

     Text text = TextManager.AddText("Big letters.");
     text.Scale = 1.5f;
     text.X = -18;
     text.Y = 8;

     Text text2 = TextManager.AddText("Normal letters, large spacing");
     text2.Spacing = 1.8f;
     text2.X = -18;
     text2.Y = 5;

     string multiLineString = "Hello.  I am a string \n" +
         "which spans many lines.  The FlatRedBall Text \n" +
         "object understands the newline character.\n" +
         "That's pretty convenient, huh?";
     Text text3 = TextManager.AddText(multiLineString);
     text3.NewLineDistance = 2.2f;
     text3.X = -18;

![ThreeTextObjects.png](/media/migrated_media-ThreeTextObjects.png)

## Text Members

-   [FlatRedBall.Graphics.Text.AdjustPositionForPixelPerfectDrawing](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.AdjustPositionForPixelPerfectDrawing.md "FlatRedBall.Graphics.Text.AdjustPositionForPixelPerfectDrawing")
-   [FlatRedBall.Graphics.Text.Alpha](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.Alpha.md "FlatRedBall.Graphics.IColorable.Alpha")
-   [FlatRedBall.Graphics.Text.ColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.ColorOperation.md "FlatRedBall.Graphics.Text.ColorOperation")
-   [FlatRedBall.Graphics.Text.DisplayText](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.DisplayText.md "FlatRedBall.Graphics.Text.DisplayText")
-   [FlatRedBall.Graphics.Text.Font](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.Font.md "FlatRedBall.Graphics.Text.Font")
-   [FlatRedBall.Graphics.Text.HorizontalAlignment](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.HorizontalAlignment.md "FlatRedBall.Graphics.Text.HorizontalAlignment")
-   [FlatRedBall.Graphics.Text.InsertNewLines](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.InsertNewLines.md "FlatRedBall.Graphics.Text.InsertNewLines")
-   [FlatRedBall.Graphics.Text.MaxWidth](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.MaxWidth.md "FlatRedBall.Graphics.Text.MaxWidth")
-   [FlatRedBall.Graphics.Text.MaxWidthBehavior](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.MaxWidth.mdBehavior "FlatRedBall.Graphics.Text.MaxWidthBehavior")
-   [FlatRedBall.Graphics.Text.NewlineDistance](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.NewlineDistance.md "FlatRedBall.Graphics.Text.NewlineDistance")
-   [FlatRedBall.Graphics.Text.NumberOfLines](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.NumberOfLines.md "FlatRedBall.Graphics.Text.NumberOfLines")
-   [FlatRedBall.Graphics.Text.ScaleX](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.ScaleX.md "FlatRedBall.Graphics.Text.ScaleX")
-   [FlatRedBall.Graphics.Text.ScaleY](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.ScaleX.md "FlatRedBall.Graphics.Text.ScaleX")
-   [FlatRedBall.Graphics.Text.SetColor](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.SetColor.md "FlatRedBall.Graphics.Text.SetColor")
-   [FlatRedBall.Graphics.Text.SetPixelPerfectScale](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.SetPixelPerfectScale.md "FlatRedBall.Graphics.Text.SetPixelPerfectScale")
-   [FlatRedBall.Graphics.Text.VerticalAlignment](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.VerticalAlignment.md "FlatRedBall.Graphics.Text.VerticalAlignment")
-   [FlatRedBall.Graphics.Text.Width](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.Width.md "FlatRedBall.Graphics.Text.Width")

## Inherited Classes and Implemented Interfaces

-   [FlatRedBall.Graphics.IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") - Properties for changing a Text's color.

## Related Articles

-   [Adding Text to Layers](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer#Adding_Text_to_Layers.md "FlatRedBall.Graphics.Layer")
-   [IAttachable Wiki Entry](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.md "FlatRedBall.Math.IAttachable") - Text implements the IAttachable interface.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
