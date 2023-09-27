## Introduction

The AutomaticallyUpdatedSprites property in the SpriteManager is a list of all Sprites which the SpriteManager will apply standard behavior to. This includes velocity, rotational velocity, attachment, color rate changes, scale velocity, and animation. This list is made available for debugging and testing. It can be added to a watch window when Visual Studio has hit a breakpoint: ![AutomaticallyUpdatedSpritesInWatchWindow.PNG](/media/migrated_media-AutomaticallyUpdatedSpritesInWatchWindow.PNG)

## Adding and Removing from AutomaticallyUpdatedSprites

AutomaticallyUpdatedSprites is a [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") which is exposed for debugging, tools development, and advanced FlatRedBall programming. Most games do not need to add or remove Sprites directly from this list. This list is added to and removed from using more common FlatRedBall methods.

### Adding to AutomaticallyUpdatedSprites

AutomaticallyUpdatedSprites gets populated whenever a Sprite is added through the SpriteManager. For example:

    SpriteManager.AddSprite("redball.bmp"); // Instantiates a Sprite and adds it to AutomaticallyUpdatedSprites

Adding existing instances also adds the Sprite to AutomaticallyUpdatedSprites:

    Sprite sprite = new Sprite();
    SpriteManager.AddSprite(sprite);

Also adding a Sprite to a Layer will add it to AutomaticallyUpdatedSprites:

    // assuming mySprite and myLayer are valid:
    SpriteManager.AddToLayer(mySprite, myLayer);

### Removing from AutomaticallyUpdatedSprites

AutomaticallyUpdatedSprites is a [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") which means it inherits from [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") so it shares a [two-way relationship](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList#Two_Way_Relationships.md "FlatRedBall.Math.AttachableList") with any Sprite that is added to it. Calling SpriteManager.RemoveSprite is the recommended way of removing a Sprite from this List.
