## Introduction

ManagedInvisible Sprites are Sprites which the SpriteManager performs every-frame updates on them (such as applying Velocity, Acceleration, and attachment logic). These Sprites are not drawn by the engine. For more information on managed invisible Sprites, see the [AddManagedInvisibleSprite](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddManagedInvisibleSprite "FlatRedBall.SpriteManager.AddManagedInvisibleSprite") method.

## When to use ConvertToManagedInvisible

The most common way of creating managed invisible Sprites is to use [SpriteManager.AddManagedInvisibleSprite](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddManagedInvisibleSprite "FlatRedBall.SpriteManager.AddManagedInvisibleSprite"). However, the [AddManagedInvisibleSprite](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddManagedInvisibleSprite "FlatRedBall.SpriteManager.AddManagedInvisibleSprite") method both instantiates and places the newly-instantiated Sprite in the proper internal lists to make it managed invisible. If you are working with already-created Sprites, then you can use ConvertToManagedInvisible to convert the Sprites to be managed invisible Sprites.

## Code Usage

Method signature:

    public static void ConvertToManagedInvisible(Sprite sprite)

Common usage:

    // assumes mySprite is a valid Sprite
    SpriteManager.ConvertToManagedInvisible(mySprite);

## Undoing ConvertToManagedInvisible

Since ConvertToManagedInvisible removes a Sprite from the engine, this function can be undone by re-adding the Sprite to the engine to be drawn. Specifically the [SpriteManager.AddToLayer](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddToLayer "FlatRedBall.SpriteManager.AddToLayer") method can be used to have the Sprite be drawn by the engine:

    // assuming SpriteInstance is a valid Sprite and LayerInstance is a valid Layer:
    SpriteManager.AddToLayer(SpriteInstance, LayerInstance);

To add the Sprite so it is drawn but not on a Layer, it can be removed from the SpriteManager using [SpriteManager.RemoveSpriteOneWay](/frb/docs/index.php?title=FlatRedBall.SpriteManager.RemoveSpriteOneWay "FlatRedBall.SpriteManager.RemoveSpriteOneWay"), then re-added using [SpriteManager.AddSprite](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddSprite "FlatRedBall.SpriteManager.AddSprite"):

    // assuming SpriteInstance is a valid Sprite
    SpriteManager.RemoveSpriteOneWay(SpriteInstance);
    SpriteManager.AddSprite(SpriteInstance);
