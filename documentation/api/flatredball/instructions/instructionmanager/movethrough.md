## Introduction

This method creates instructions for moving the argument [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") through a list of points which is created from the list of [IPositionables](/frb/docs/index.php?title=FlatRedBall.Math.IPositionable&action=edit&redlink=1 "FlatRedBall.Math.IPositionable (page does not exist)") passed as the second argument. This method can be used in combination with the [NodeNetwork](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.NodeNetwork "FlatRedBall.AI.Pathfinding.NodeNetwork") class to automatically move objects along a path.

## Code Example

The following creates five [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). The four in the corners represent points that the fifth will move through. Add the following using statements:

    using FlatRedBall.Instructions;
    using FlatRedBall.Math;

Add the following to Initialize after initializing FlatRedBall:

    PositionedObjectList<Sprite> list = new PositionedObjectList<Sprite>();

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.X = 5;
    sprite.Y = 5;
    list.Add(sprite);

    sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.X = -5;
    sprite.Y = -5;
    list.Add(sprite);

    sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.X = -5;
    sprite.Y = 5;
    list.Add(sprite);

    sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.X = 5;
    sprite.Y = -5;
    list.Add(sprite);

    sprite = SpriteManager.AddSprite("redball.bmp");
    float velocity = 3;
    InstructionManager.MoveThrough<Sprite>(sprite, list, velocity );

![MoveThrough.png](/media/migrated_media-MoveThrough.png)
