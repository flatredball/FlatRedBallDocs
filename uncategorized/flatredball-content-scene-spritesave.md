## Introduction

The SpriteSave class is the ["save" class](/frb/docs/index.php?title=Tutorials:Save_Classes.md "Tutorials:Save Classes") for the Sprite object. The SpriteSave class is usually associated with the [SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene.md "FlatRedBall.Content.SpriteEditorScene") class ([SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene.md "FlatRedBall.Content.SpriteEditorScene") contains a list of SpriteSaves). The SpriteSave class is a useful class if you plan on manually loading or saving .scnx files.

## Code Example

The SpriteSave is a ["save" class](/frb/docs/index.php?title=Tutorials:Save_Classes.md "Tutorials:Save Classes") which means it can be used to save the information of a Sprite to XML, or it can be used to retrieve information from an XML file and create a fully-usable Sprite. This code shows how to create a SpriteSave from a Sprite, and then how to create another Sprite from the given SpriteSave:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    // the Sprite can be modified:
    sprite.ScaleY = 3;
    sprite.X = 4;
    sprite.Alpha = .5f;
    // Now you can make a SpriteSave out of the Sprite:
    SpriteSave spriteSave = SpriteSave.FromSprite(sprite);
    // The SpriteSave fully represents the information of the Sprite, so we can 

    // Now we can remove the original Sprite and create a new one, then add it to the engine, and everything should appear the same:
    SpriteManager.RemoveSprite(sprite);
    Sprite newSprite = spriteSave.ToSprite(ContentManagerName); // <- ContentManagerName usually comes from the Screen or containing Entity
    // Now that we have a new Sprite, we can add it to the engine:
    SpriteManager.AddSprite(newSprite);

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
