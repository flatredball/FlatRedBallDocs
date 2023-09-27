## Introduction

The UnderAllDrawn Layer is a Layer that is automatically created by the FlatRedBall Engine and available through the SpriteManager as a static member. This Layer can be used to render objects which should appear under other objects, such as game backgrounds. This layer can be used if your game already has a large number of un-layered objects and you want to add something that should always be drawn behind these objects. It will likely be much easier to add one (or a few) objects to the UnderAllDrawnLayer than to move all existing objects onto a new Layer.

## Code Example

The following code creates a Sprite and adds it to the UnderAllDrawnLayer:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.AddToLayer(sprite, SpriteManager.UnderAllDrawnLayer);
