# converttozbufferedsprite

### Introduction

The ConvertToZBufferedSprite method can be used on Sprites which have already been added to the SpriteManager as ordered (not z-buffered). This method assumes:

* That the argument Sprite has already been added to the SpriteManager
* That the Sprite is not on a Layer

### Code Example

The following code adds a Sprite regularly, then converts it to a ZBuffered Sprite:

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
SpriteManager.ConvertToZBufferedSprite(sprite);
```

### Additional Information

Sprites can be converted back to ordered Sprites. For more information, see the [FlatRedBall.SpriteManager.ConvertToOrderedSprite](../../../../frb/docs/index.php) page.
