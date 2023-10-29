## Introduction

The Remove method is responsible for removing the argument object from the calling Layer. Remove has the following signatures:

    Remove(Sprite spriteToRemove)

    Remove(SpriteFrame spriteFrame)

    Remove(Text textToRemove)

    Remove(Scene scene)

    Remove(IDrawableBatch batchToRemove)

## When to call Remove

Calling Remove is usually not necessary. The reason is because the internal list that Layers use to keep track of objects is a two-way list. In other words, consider the following code:

    // Assuming layer is a valid Layer
    Sprite sprite = new Sprite();
    SpriteManager.AddToLayer(sprite, layer);
    // At this point the Sprite is part of the Layer
    SpriteManager.RemoveSprite(sprite);
    // Now the Sprite is no longer part of the Layer
    if(layer.Sprites.Count == 0)
    {
      // This will be true
    }

Therefore, you will not need to call Remove to take a Sprite off of a Layer if you are using the SpriteManager to remove it. However, Remove can be useful if you would like to move a Sprite from one Layer to another:

    // Assuming that layer1 and layer2 are valid Layers:
    // Assuming layer is a valid Layer
    Sprite sprite = new Sprite();
    SpriteManager.AddToLayer(sprite, layer1);
    // At this point the Sprite is part of layer1
    layer1.Remove(sprite);
    SpriteManager.AddToLayer(sprite, layer2);
    // Now the Sprite is no longer part of layer1, but it is a part of layer2
