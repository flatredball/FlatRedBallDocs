# IScalable

### Introduction

The IScalable interface provides an interface for 2D objects which can be resized. IScalable objects have two properties which control size:

* ScaleX
* ScaleY

Note: By default, scale has **nothing** to do with the Texture that an object is displaying. Two objects showing different Textures of different dimensions will be the same size if they have the same scale values.

### What is Scale?

Scale defines the distance from the center of an object to its edge. ![ScaleDiagram.png](../../../../../.gitbook/assets/migrated\_media-ScaleDiagram.png) Scale values are used used instead of "width" and "height" because it simplifies collision and object placement. In other words, the following relationships exist:

```
ScaleX = Width / 2;
ScaleY = Height / 2;
```

OR

```
Width = ScaleX * 2;
Height = ScaleY * 2;
```

### Scale Example

The following code creates 3 [Sprites](../../../../../frb/docs/index.php) with different scales.

```
 Sprite regularSizedSprite = SpriteManager.AddSprite("redball.bmp");
 regularSizedSprite.Y = 4;

 Sprite scaledOnXSprite = SpriteManager.AddSprite("redball.bmp");
 scaledOnXSprite.ScaleX = 3;

 Sprite scaledOnXAndYSprite = SpriteManager.AddSprite("redball.bmp");
 scaledOnXAndYSprite.Y = -7;
 scaledOnXAndYSprite.ScaleX = 3;
 scaledOnXAndYSprite.ScaleY = 3;
```

![ScaledSprites.png](../../../../../.gitbook/assets/migrated\_media-ScaledSprites.png)

### Scale is independent of Texture

The ScaleX and ScaleY values on objects such as Sprites is (by default) independent of the Sprite's [Texture property](../../../../../frb/docs/index.php). Therefore, if two Sprites both have the same ScaleX and ScaleY values, they will appear as the same size on screen regardless of the size of the Textures that they are displaying.

### Tutorials

* [Understanding the 3D Camera tutorial](../../../../../frb/docs/index.php) - Information on Scale and it's relationship to on-screen size
* [Setting a Sprite to Pixel Size](../../../../../frb/docs/index.php#Setting\_a\_Sprite\_to\_Pixel\_Size) - Shows how to set a Sprite's scale so that it appears the same dimensions as its source [Texture](../../../../../frb/docs/index.php).
* [Justifying IScalables](../../../../../frb/docs/index.php)

### More Information

* [FlatRedBall.Graphics.Model.PositionedModel.ScaleX](../../../../../frb/docs/index.php) - Scale and PositionedModels.

### IScalable Members

* [FlatRedBall.Math.Geometry.IScalable.ScaleXVelocity](../../../../../frb/docs/index.php)
* [FlatRedBall.Math.Geometry.IScalable.ScaleYVelocity](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
