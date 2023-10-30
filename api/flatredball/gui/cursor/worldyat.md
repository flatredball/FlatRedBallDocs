# worldyat

### Introduction

The WorldXAt and WorldYAt methods are useful for finding the absolute world position of the Cursor at a given Z value. These methods should generally be used only when dealing with an unrotated [Camera](../../../../../frb/docs/index.php). For more information on limitations see below. If you are dealing with a [2D Camera](../../../../../frb/docs/index.php) (the default) then you can use a Z value of 0 in the WorldXAt and WorldYAt functions.

### Code Example

The following code creates a [Circle](../../../../../frb/docs/index.php) which moves with the Cursor.

Add the following using statements:

```
using FlatRedBall.Gui;
using FlatRedBall.Math.Geometry;
```

Add the following at class scope:

```
Circle circle;
```

Add the following to Initialize after initializing FlatRedBall:

```
 FlatRedBallServices.Game.IsMouseVisible = true;
 circle = ShapeManager.AddCircle();
```

Add the following to Update:

```
circle.X = GuiManager.Cursor.WorldXAt(0);
circle.Y = GuiManager.Cursor.WorldYAt(0);
```

![CursorWorldXAt.png](../../../../../media/migrated_media-CursorWorldXAt.png)

### Additional Arguments

The WorldXAt and WorldYAt methods can also be passed Cameras and Layers if the default is not being used. Most commonly when working with HUD in Glue, you may add the HUD element to a 2D Layer, and this 2D Layer may have a settings that differ from your default Camera. In this case, you should use these available overrides. Specifically, if you are working in an Entity, you can use the following:

```
// This represents the Entity assuming this code is in the custom methods of an Entity
float worldX = GuiManager.Cursor.WorldXAt(this.Z, this.LayerProvidedByContainer);
float worldY = GuiManager.Cursor.WorldYAt(this.Z, this.LayerProvidedByContainer);
```

### Using custom Cursor graphics

The WorldXAt and WorldYAt methods can be combined with Sprites and Layers to create a custom cursor. The following code shows how to create a custom cursor using the redball.bmp graphic. This code assumes a 2D coordinate system. You will need to adjust the Sprite size appropriately if using 3D coordinates instead:

Add the following at class scope:

```
Sprite mCursorSprite;
```

Add the following to your game or Screen's Initialize/CustomInitialize:

```
// Hide the cursor so that only our Sprite is invisible:
FlatRedBallServices.Game.IsMouseVisible = false;
// Make the layer 2D
SpriteManager.TopLayer.UsePixelCoordinates();
// Create the Sprite that will be used for the cursor
mCursorSprite = SpriteManager.AddSprite("redball.bmp");
// Add it to the TopLayer so it's always drawn on top of everything else
SpriteManager.AddToLayer(mCursorSprite, SpriteManager.TopLayer);
// Scale it so it's 2D.  This will be different if using a 3D camera
mCursorSprite.PixelSize = .5f;
```

Add the following to your game or Screen's Update/CustomActivity:

```
Cursor cursor = GuiManager.Cursor;
// Make sure to use the TopLayer when calling GetWorldXAt and GetWorldYAt
mCursorSprite.X = cursor.WorldXAt(0, SpriteManager.TopLayer);
mCursorSprite.Y = cursor.WorldYAt(0, SpriteManager.TopLayer);
```

### Method Limitations

The WorldXAt and WorldYAt methods may giave unexpected results if the Camera is rotated. These methods should only be used when the Camera is facing down the Z axis (default orientation). For a rotated [Camera](../../../../../frb/docs/index.php), the [Cursor's GetRay](../../../../../frb/docs/index.php) method should be used. If interested in object picking, you can use the [Cursor's IsOn3D method](../../../../../frb/docs/index.php) or the [IClickable](../../../../../frb/docs/index.php) or [IWindow](../../../../../frb/docs/index.php) interfaces for Entities in Glue.
