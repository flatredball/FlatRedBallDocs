## Introduction

The SpriteManager is a static class which handles [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") addition, removal, and common behavior. The SpriteManager manages behavior for [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [SpriteFrames](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteFrame "FlatRedBall.ManagedSpriteGroups.SpriteFrame").

## Sprites

The SpriteManager provides numerous methods for for working with [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). The following sections provide code samples for working with [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite")-related methods.

### Sprite Addition

Most AddSprite methods both instantiate a new [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") as well as add it to SpriteManager for management. The following methods instantiate and add a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") to the SpriteManager:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp"); // "Global" content manager

    Sprite sprite = SpriteManager.AddSprite("redball.bmp", "Content Manager Name");

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp"); // "Global" content manager
    Sprite sprite = SpriteManager.AddSprite(texture);

For information on content managers, see the [FlatRedBall Content Manager wiki entry](/frb/docs/index.php?title=FlatRedBall_Content_Manager "FlatRedBall Content Manager").

#### Adding Sprites and Layers

Sprites can also be added to [Layers](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer").

    Layer layer = SpriteManager.AddLayer();

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

    Sprite sprite = SpriteManager.AddSprite(texture, layer);

Sprites which have already been created can be moved to layers. This is commonly performed when loading [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene").

    // Assume sprite is a valid Sprite and layer is a valid Layer
    SpriteManager.AddToLayer(sprite, layer);

The Sprite will no longer be an un-layered Sprite. Similarly entire lists can be added:

    // Assume scene is a valid Scene that contains Sprites in its Sprites property
    // and that layer is a valid Layer.
    SpriteManager.AddToLayer(scene.Sprites, layer);

For more information, see the [Layer wiki entry](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer").

### Sprite Removal

The RemoveSprite methods remove [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") from the engine as well as any [two-way](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList#Two_Way_Relationships "FlatRedBall.Math.AttachableList") [AttachableLists](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList "FlatRedBall.Math.AttachableList") (such as [SpriteLists](/frb/docs/index.php?title=FlatRedBall.SpriteList "FlatRedBall.SpriteList")) that the [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") belong to.

    // Assuming sprite is a valid Sprite which has been added to the SpriteManager
    SpriteManager.RemoveSprite(sprite);

RemoveSprite can also remove entire lists:

     SpriteList spriteList = new SpriteList();
     // populate SpriteList by adding Sprites to it.

     // This will remove all Sprites contained in spriteList and also
     // clear spriteList if spriteList is a two-way list.
     SpriteManager.RemoveSprite(spriteList);

For more information see [AttachableLists](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList "FlatRedBall.Math.AttachableList").

## Managing [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject")

See the [PositionedObject wiki entry](/frb/docs/index.php?title=FlatRedBall.PositionedObject#Managing_PositionedObjects "FlatRedBall.PositionedObject").

## Read Only Lists

The SpriteManager provides read only access to its internal lists for debugging. It is not recommended to directly work with objects through these lists. The following lists the read only lists available:

-   AutomaticallyUpdatedSprites
-   DrawableBatches
-   SpriteFrames
-   ManagedPositionedObjects

These are static so you simply access them through the SpriteManager:

    for(int i = 0; i < AutomaticallyUpdatedSprites.Count; i++)
    {
       // do whatever
    }

These lists are used by the ScreenManager to verify that all objects have been destroyed.

## 
