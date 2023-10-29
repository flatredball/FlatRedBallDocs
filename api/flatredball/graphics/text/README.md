# text

### Introduction

The Text object provides functionality for drawing bitmap fonts in 2D and 3D space. It inherits from the [PositionedObject](../../../../frb/docs/index.php) class and shares many similarities with the [Sprite](../../../../frb/docs/index.php) class. Just as the [Sprite](../../../../frb/docs/index.php) class is associated with the [SpriteManager](../../../../frb/docs/index.php), the Text object is associated with the [TextManager](../../../../frb/docs/index.php). Note that most games which use Text do so through Gum instead of using the FlatRedBall Text object.

### Creating a Text Instance in Code

The FlatRedBall engine stores a default [BitmapFont](../../../../frb/docs/index.php) internally. Any Text object created will use this default [BitmapFont](../../../../frb/docs/index.php). To create a Text object in code, add the following to your Screen's CustomInitialize, or Game1.cs Initialize after initializing FlatRedBall:

```lang:c#
Text text = FlatRedBall.Graphics.TextManager.AddText("Hello");
```

#### A note about persistence

The Text object behaves the same as other FlatRedBall objects which have been added to their respective managers. This means that when you add a Text object, it will be drawn and updated automatically for you until it is removed.

#### You **should not add text every frame**

A common mistake is to add and remove text every frame to change what it displays. Instead of doing this, you should set a text's DisplayText property to change what it says. For example:

```
myText.DisplayText = CurrentScore.ToString();
```

For more information on the persistence of objects, see [this article](../../../../frb/docs/index.php#A\_note\_about\_persistence). For code example comparing the approach of creating a new text vs. setting the DisplayText, see the [DisplayText page](../../../../frb/docs/index.php).

### DisplayText Property

The DisplayText property allows for changing the string that a Text object renders. The following code sets the text depending on whether the user has a gamepad connected: **Add the following include statements:**

```
using FlatRedBall.Input;
using FlatRedBall.Graphics;
```

**Add the following to the Initialize method after initializing FlatRedBallServices:**

```
 Text text = TextManager.AddText(""); // empty string for now

 if (InputManager.Xbox360GamePads[0].IsConnected == false)
 {
     text.DisplayText = "Gamepad at index 0 is disconnected";
 }
 else
 {
     text.DisplayText = "Gamepad at index 0 is connected";
 }
```

![DisconnectedText.png](../../../../media/migrated\_media-DisconnectedText.png)

### Text Object as PositionedObject

Text objects can be positioned just like any PositionedObject. For example, a text object's X and Y values can be set:

```lang:c#
myTextObject.X = 50;
myTextObject.Y = -20;
```

For more information on [PositionedObject](../../../../documentation/api/flatredball/positionedobject.md) fields and properties, see the [PositionedObject entry](../../../../documentation/api/flatredball/positionedobject.md).

### Text Size

By default Text objects added through the FRB editor are sized to be _pixel perfect_ given the game's resolution. The Text object provides a number of properties for changing size.

#### TextureScale

TextureScale controls the size of the text relative to its source texture. A TextureScale of 1 results in the text drawing pixel perfect if the game is running at 100% scale. If the game runs at larger scale, then Text using a fixed TextureScale will drawn larger.

#### SetPixelPerfectScale

The SetPixelPerfectScale function sets the text size to be pixel perfect given the argument camera or layer. The following code sets the Text to be pixel perfect to the main camera:

```
TextInstance.SetPixelPerfectScale(Camera.Main);
```

Note that pixel-perfect text will not appear zoomed if the game settings are zoomed. &#x20;

#### Individual Scale Values

The Text object provides three different variables for changing the size of text. These properties are:

* Scale
* Spacing
* NewLineDistance

The following code creates three text objects which have non-default values for these three properties.

```
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
```

![ThreeTextObjects.png](../../../../media/migrated\_media-ThreeTextObjects.png)

### Text Members

* [FlatRedBall.Graphics.Text.AdjustPositionForPixelPerfectDrawing](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.Alpha](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.ColorOperation](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.DisplayText](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.Font](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.HorizontalAlignment](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.InsertNewLines](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.MaxWidth](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.MaxWidthBehavior](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.NewlineDistance](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.NumberOfLines](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.ScaleX](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.ScaleY](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.SetColor](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.SetPixelPerfectScale](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.VerticalAlignment](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Text.Width](../../../../frb/docs/index.php)

### Inherited Classes and Implemented Interfaces

* [FlatRedBall.Graphics.IColorable](../../../../frb/docs/index.php) - Properties for changing a Text's color.

### Related Articles

* [Adding Text to Layers](../../../../frb/docs/index.php#Adding\_Text\_to\_Layers)
* [IAttachable Wiki Entry](../../../../frb/docs/index.php) - Text implements the IAttachable interface.

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
