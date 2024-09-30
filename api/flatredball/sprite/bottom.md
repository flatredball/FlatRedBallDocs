# Bottom

### Introduction

The Top, Bottom, Left, and Right properties return the X or Y values (as appropriate) of the edges of the Sprite in absolute coordinates. These values are equal to adding half of the width or height to the X or Y of the Sprite, but are provided for convenience.

### Getting values

The following code example shows how to use the four edge values to position four Sprites. It assumes a Sprite named LogoSprite:

```
Circle topCircle = ShapeManager.AddCircle();
topCircle.Radius = 16;
topCircle.Y = LogoSprite.Top;

Circle bottomCircle = ShapeManager.AddCircle();
bottomCircle.Radius = 16;
bottomCircle.Y = LogoSprite.Bottom;

Circle leftCircle = ShapeManager.AddCircle();
leftCircle.Radius = 16;
leftCircle.X = LogoSprite.Left;

Circle rightCircle = ShapeManager.AddCircle();
rightCircle.Radius = 16;
rightCircle.X = LogoSprite.Right;
```

![SpriteEdges.PNG](../../../.gitbook/assets/migrated\_media-SpriteEdges.PNG)
