# addsprite

### Introduction

The AddSprite function is one of the most common functions in FlatRedBall. The AddSprite function adds a [Sprite](../../../../frb/docs/index.php) instance to the SpriteManager. It can also create new [Sprite](../../../../frb/docs/index.php) instances depending on which overload is called.

### AddSprite Signatures

```
public static Sprite AddSprite(string texture)

public static Sprite AddSprite(AnimationChainList animationChainList)

public static Sprite AddSprite(AnimationChain animationChain)

public static Sprite AddSprite(string texture, string contentManagerName)

public static Sprite AddSprite(string texture, string contentManagerName, Layer layer)

public static Sprite AddSprite(Texture2D texture)

public static void AddSprite(Sprite spriteToAdd)

public static Sprite AddSprite(Texture2D texture, Layer layer)
```

### Adding Sprites to Layers

To add a Sprite to a Layer, use the [SpriteManager.AddToLayer](../../../../frb/docs/index.php) method.
