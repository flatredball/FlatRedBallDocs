# IColorable

### Introduction

The IColorable interface defines properties for interacting with an object which can have its color dynamically modified and which can specify how it "blends" with objects behind it. Common objects which implement the IColorable interface include the [Sprite](../../../../frb/docs/index.php) and [Text](../../../../frb/docs/index.php) object.

### Applying [ColorOperations](../../../../frb/docs/index.php)

[ColorOperations](../../../../frb/docs/index.php) can be used to change the color of a IColorable at runtime. [ColorOperations](../../../../frb/docs/index.php) require two pieces of information: the color specified by three values (Red, Green, and Blue) and the operation to perform with the specified color.

The default [ColorOperation](../../../../frb/docs/index.php) for most IColorables (like [Sprites](../../../../frb/docs/index.php)) is [ColorOperation](../../../../frb/docs/index.php).None. Unless the [ColorOperation](../../../../frb/docs/index.php) is changed, the Red, Green, and Blue properties will have no effect on way the IColorable is rendered. The default [ColorOperation](../../../../frb/docs/index.php) for [Texts](../../../../frb/docs/index.php) is [Modulate](../../../../frb/docs/index.php).

The Red, Green, and Blue properties provide access to the components of the color which is used to change the IColorable's color. The [ColorOperation](../../../../frb/docs/index.php) property specifies how to modify the color.

Color values range between 0 and 1 and are all set to 0 by default.

The exception is the [Text](../../../../frb/docs/index.php) object. The Text object has its Red, Green, and Blue color values set to 1 so that the text appears as white. Furthermore, the [ColorOperation](../../../../frb/docs/index.php) defaults to [ColorOperation](../../../../frb/docs/index.php).Modulate for the [Text](../../../../frb/docs/index.php) object.

The following code will create five Sprites, each with a different [ColorOperation](../../../../frb/docs/index.php).

```csharp
 // To reduce code, add the following #using statement to your Game class
 using FlatRedBall.Graphics;

 // Replace your Initialize method with the following:
 protected override void Initialize()
 {
     FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

     float xPosition = -3;
     float spacing = 2;

     Sprite regularSprite = SpriteManager.AddSprite("redball.bmp");
     regularSprite.X = xPosition;
     // uses default ColorOperation:
     // FlatRedBall.Graphics.ColorOperation.Texture

     xPosition += spacing;

     Sprite blueAdded = SpriteManager.AddSprite("redball.bmp");
     blueAdded.X = xPosition;
     blueAdded.Blue = 1; // between 0 and 1
     blueAdded.ColorOperation = ColorOperation.Add;

     xPosition += spacing;

     Sprite plainColor = SpriteManager.AddSprite("redball.bmp");
     plainColor.X = xPosition;
     plainColor.Green = .7f;
     plainColor.Red = .8f;
     // using the ColorOperation.Color rather than
     // ColorOperation.ColorTextureAlpha will make the
     // entire Sprite the specified color even where normally
     // transparent.
     plainColor.ColorOperation = ColorOperation.ColorTextureAlpha;

     xPosition += spacing;
     Sprite inverseColor = SpriteManager.AddSprite("redball.bmp");
     inverseColor.X = xPosition;
     inverseColor.ColorOperation = ColorOperation.InverseTexture;


     base.Initialize();
 }
```

![ColorOperations.png](../../../../.gitbook/assets/migrated\_media-ColorOperations.png)

For more information on specific [ColorOperation values](../../../../frb/docs/index.php), see the [ColorOperation page](../../../../frb/docs/index.php).

### Color Rates

Color rates are values which change the Red, Green, and Blue values over time. The rates, just like all velocity values, indicate units changed per second. The following code creates 80 Sprites and randomly varies their colors using a [SpriteCustomBehavior](../../../../frb/docs/index.php).

```csharp
 // To reduce code, add the following #using statement to your Game class
 using FlatRedBall.Graphics;

 // Replace your Initialize method with the following:

 protected override void Initialize()
 {
     FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

     // Might as well use it since we have one created
     // for us already.
     Random random = FlatRedBallServices.Random;

     for (int i = 0; i < 80; i++)
     {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
        sprite.ColorOperation = ColorOperation.Add;

        sprite.X = (float)random.NextDouble() * 30 - 15;
        sprite.Y = (float)random.NextDouble() * 20 - 10;

        sprite.RedRate = (float)random.NextDouble() * .7f;
        sprite.GreenRate = (float)random.NextDouble() * .7f;
        sprite.BlueRate = (float)random.NextDouble() * .7f;

        sprite.CustomBehavior += FluctuateColor;
     }
     base.Initialize();
 }

 // Add the following method at class scope
 void FluctuateColor(Sprite sprite)
 {
     if(sprite.Red <= .01f && sprite.RedRate <= 0)
     {
         sprite.RedRate *= -1;
     }
     if(sprite.Red >= .99f && sprite.RedRate >= 0)
     {
         sprite.RedRate *= -1;
     }
 
     if(sprite.Green <= .01f && sprite.GreenRate <= 0)
     {
         sprite.GreenRate *= -1;
     }
     if(sprite.Green >= .99f && sprite.GreenRate >= 0)
     {
         sprite.GreenRate *= -1;
     }
 
     if(sprite.Blue <= .01f && sprite.BlueRate <= 0)
     {
         sprite.BlueRate *= -1;
     }
     if(sprite.Blue >= .99f && sprite.BlueRate >= 0)
     {
         sprite.BlueRate *= -1;
     }
 }
```

![SpritesWithColorRates.png](../../../../.gitbook/assets/migrated\_media-SpritesWithColorRates.png)

### Alpha and BlendOperation

The Alpha and BlendOperation properties are related just as the components of color and [ColorOperation](../../../../frb/docs/index.php) properties. The Alpha property is used to control the transparency of an IColorable.

Unlike the color components, modifying the Alpha value will affect the appearance of an IColorable with its default BlendOperation.

BlendOperations control how IColorables blend with objects behind them. The following code shows two rows of Sprites - the first with the default BlendOperation.Regular and the second with BlendOperation.Add;

```csharp
 // To reduce code, add the following #using statement to your Game class
 // using FlatRedBall.Graphics;

 // Replace your Initialize method with the following:
 protected override void Initialize()
 {
     FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

     for (int i = 0; i < 10; i++)
     {
         Sprite sprite = SpriteManager.AddSprite("redball.bmp");
         sprite.X = -5 + i;
         sprite.Y = 4;
         sprite.Alpha = 1 - (i / 10.0f);
     }

     for (int i = 0; i < 10; i++)
     {
         Sprite sprite = SpriteManager.AddSprite("redball.bmp");
         sprite.X = -5 + i;
         sprite.BlendOperation = BlendOperation.Add;

         sprite.Alpha = 1 - (i / 10.0f);
     }

     base.Initialize();
 }
```

![AlphaAndBlendOperation.png](../../../../.gitbook/assets/migrated\_media-AlphaAndBlendOperation.png)

### AlphaRate

The AlphaRate property modifies the Alpha property similar to the ColorRate properties. AlphaRate can be used to fade an IColorable in and out.

Most IColorables are created with an Alpha value of 1. This generally represents full opacity. AlphaRate can change this value over time. A positive AlphaRate value will increase the Alpha property over time, and a negative AlphaRate value will decrease the Alpha property over time. The formula (which is generally applied automatically for managed objects) is:

```csharp
object.Alpha += object.AlphaRate * TimeManager.SecondDifference;
```

Therefore, a fully opaque object with an AlphaRate of -1 will disappear in 1 second. Increasing the absolute value of the AlphaRate makes the object disappear faster. That is, an AlphaRate of -2 (twice as large in absolute value terms) will make an object disappear after .5 seconds (half as long). The formula is:

```csharp
AmountOfTimeToDisappearIn = - 1/AlphaRate;
```

Therefore, we can see that an AlphaRate value of -2 will cause an object to disappear in

```
-(1/(-2)) = 1/2 = .5
```

### IColorable Members

* [FlatRedBall.Graphics.IColorable.Alpha](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.IColorable.BlendOperation](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.IColorable.Blue](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.IColorable.ColorOperation](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.IColorable.Green](../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.IColorable.Red](../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
