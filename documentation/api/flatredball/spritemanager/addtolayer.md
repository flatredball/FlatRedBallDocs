# addtolayer

### Introduction

The AddToLayer object adds an existing object instance to the argument [FlatRedBall.Graphics.Layer](../../../../frb/docs/index.php). The first argument object may or may not already be added to the SpriteManager. If the object is an unlayered object then it will be removed from the "world layer" and added to the argument [Layer](../../../../frb/docs/index.php). However, if an object is already part of a different [Layer](../../../../frb/docs/index.php) it will continue to hold that membership after this call as well as being a member of the new [Layer](../../../../frb/docs/index.php). In other words, this method can be called multiple times to have an object be drawn on multiple [Layers](../../../../frb/docs/index.php).

### Overloads

```
static public void AddToLayer(Sprite spriteToAdd, Layer layerToAddTo)
static public void AddToLayer(IDrawableBatch batchToAdd, Layer layerToAddTo)
static public void AddToLayer(SpriteFrame spriteFrame, Layer layerToAddTo)
static public void AddToLayer<T>(AttachableList<T> listToAdd, Layer layerToAddTo)
```

### Code Example

The AddToLayer is very simple to use. Assuming you have a valid [Layer](../../../../frb/docs/index.php) and a valid object that can be added to the [Layer](../../../../frb/docs/index.php), you can add it as follows:

```
// Assume myObject is a valid Sprite or SpriteFrame or IDrawableBatch and
// myLayer is a valid Layer:
SpriteManager.AddToLayer(myObject, myLayer);
```

### Performance

The SpriteManager's AddToLayer method can be useful but suffers a small performance penalty when called on [Sprites](../../../../frb/docs/index.php) which have already been added to the [SpriteManager](../../../../frb/docs/index.php). For example, the following code is functional but suffers a small performance penalty.

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
Layer layer = SpriteManager.AddLayer();
SpriteManager.AddToLayer(sprite, layer);
```

Why is this expensive? The SpriteManager.AddSprite method tells the [SpriteManager](../../../../frb/docs/index.php) that the [Sprite](../../../../frb/docs/index.php) being added should be managed **and drawn** by the SpriteManager. This places the Sprite in the same category as unlayered Sprites. Calling SpriteManager.AddToLayer then places the [Sprite](../../../../frb/docs/index.php) on the argument layer. However, the SpriteManager must then remove the argument sprite from its internal [SpriteLists](../../../../frb/docs/index.php). The following code is more efficient and preferred:

```
Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", "Global");
Layer layer = SpriteManager.AddLayer();
SpriteManager.AddSprite(texture, layer);
```

This code is functionally identical but slightly more efficient.
