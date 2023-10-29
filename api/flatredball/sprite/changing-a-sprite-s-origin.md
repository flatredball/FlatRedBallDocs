## Introduction

Many situations in game development can be simplified by changing the origin of an object (such as a Sprite). For example, you may make a tank turret Sprite, but the turret should not necessarily rotate around its center, but rather about the "base" of the turret. Another example may be a game where the player controls a character (such as a 2D platformer). In this situation you may want to make the origin of the Character at his feet. Unfortunatley, Sprites cannot have their origin simply changed. The center of a Sprite defines its rotation and the Scale values measure from the middle of the Sprite outward. However, shifting the origin can easily be simulated by using a PositionedObject as a parent and setting relative values.

## For Glue Users

If you are using Glue, then most of your Sprites are probably already attached to Entities, which are PositionedObjects. Therefore, if you want to re-define the "center" of a Sprite, simply open the SpriteEditor for the given Entity and reposition the Sprite. The Sprite will be positioned with an offset so that the Sprite will be offset from the Entity's position.

## For code users

If you are using code, then you will want to do the following:

1.  Create a PositionedObject
2.  Attach the Sprite to the PositionedObject
3.  Set the offset using relative values
4.  Control using the Entity

For example, your code may look like this:

    // Assuming mySprite is a valid Sprite:
    PositionedObject parent = new PositionedObject();
    mySprite.AttachTo(parent, false);
    mySprite.RelativeX = 3; // this gives the Sprite an X offset of 3 units
    mySprite.RelativeY = 2; // this gives the Sprite a Y offset of 2 units
    SpriteManager.AddPositionedObject(parent); // this makes the PositionedObject updated
    // Now simply control "parent" and the Sprite will follow
