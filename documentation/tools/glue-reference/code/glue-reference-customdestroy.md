## Introduction

CustomDestroy is a method that is called once on every Screen/Entity instance when it is no longer needed. Any objects that are created in custom code (as opposed to objects added through Glue) need to be removed/destroyed in CustomDestroy.

## Example Usage

Objects which are created in CustomInitialize or CustomActivity must be properly destroyed in CustomDestroy. There are two categories of objects which must be destroyed:

1.  Entities must have their Destroy method
2.  Objects added to the engine (like Sprites) must be removed from the engine

The following example shows a Sprite created in CustomInitialize, then later destroyed in CustomDestroy:

    // At class scope:
    Sprite mSprite;
    void CustomInitialize()
    {
       mSprite = SpriteManager.AddSprite("redball.bmp", ContentManagerName);
    }
    // ...
    void CustomDestroy()
    {
       SpriteManager.RemoveSprite(mSprite);
    }
