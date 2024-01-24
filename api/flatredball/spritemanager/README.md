# SpriteManager

### Introduction

The SpriteManager is a static class which handles [Sprite](../sprite/) addition, removal, and common behavior. The SpriteManager also manages _automatically updated_ PositionedObjects. By default all entity instances are added to the SpriteManager to have their every-frame activity called.

In most cases you will not need to write code to interact with the SpriteManager since most Sprites are created in generated code. However, if you are creating or destroying Sprite instances manually, you will probably need to work with the SpriteMangaer.

### Sprites

The SpriteManager provides numerous methods for for working with [Sprites](../sprite/). The following sections provide code samples for working with [Sprite](../sprite/)-related methods.

#### Sprite Addition

Most AddSprite methods both instantiate a new [Sprite](../sprite/) as well as add it to SpriteManager for management. The following methods instantiate and add a [Sprite](../sprite/) to the SpriteManager:

```csharp
// This loads the texture "content/redball.png" using the global content manager
// then assigns it to the Sprite's Texture property
Sprite sprite = SpriteManager.AddSprite("content/redball.png");

// This loads the texture "content/redball.png" using a content manager named
// "Content Manager Name" then assigns it to the Sprite's Texture property.
Sprite sprite = SpriteManager.AddSprite("content/redball.png", "Content Manager Name");

// This manually loads the texture and then uses the resulting Texture2D to 
// create a Sprite and assigns the Sprite's Texture property.
Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
Sprite sprite = SpriteManager.AddSprite(texture);

// Textures can (and often do) come from generated code, so textures from generated code
// can also be used to instantiate sprites:
Sprite sprite = SpriteManager.AddSprite(TextureFile);
```

For information on content managers, see the [FlatRedBall Content Manager wiki entry](../content/contentmanager/).

**Adding Sprites and Layers**

Sprites can also be added to [Layers](../graphics/layer/).

```csharp
Layer layer = SpriteManager.AddLayer();
Texture2D texture = FlatRedBallServices.Load<Texture2D>("content/redball.png");
Sprite sprite = SpriteManager.AddSprite(texture, layer);
```

Sprites which have already been created can be moved to layers.

```csharp
// Assume sprite is a valid Sprite and layer is a valid Layer
SpriteManager.AddToLayer(sprite, layer);
```

The Sprite will no longer be an un-layered Sprite. Similarly entire lists can be added:

```csharp
// Assume scene is a valid Scene that contains Sprites in its Sprites property
// and that layer is a valid Layer.
SpriteManager.AddToLayer(scene.Sprites, layer);
```

For more information, see the [Layer wiki entry](../graphics/layer/).

#### Sprite Removal

The RemoveSprite methods remove [Sprites](../sprite/) from the engine as well as two way PositionedObjectLists that the [Sprites](../sprite/) belong to.

```csharp
// Assuming sprite is a valid Sprite which has been added to the SpriteManager
SpriteManager.RemoveSprite(sprite);
```

RemoveSprite can also remove entire lists:

```
 SpriteList spriteList = new SpriteList();
 // populate SpriteList by adding Sprites to it.

 // This will remove all Sprites contained in spriteList and also
 // clear spriteList if spriteList is a two-way list.
 SpriteManager.RemoveSprite(spriteList);
```

For more information see [AttachableLists](../math/attachablelist/).

### Managing [PositionedObjects](../positionedobject/)

See the [PositionedObject page](../positionedobject/).

### Read Only Lists

The SpriteManager provides read only access to its internal lists for debugging. It is not recommended to directly work with objects through these lists. The following lists the read only lists available:

* AutomaticallyUpdatedSprites
* DrawableBatches
* SpriteFrames
* ManagedPositionedObjects

These are static so you simply access them through the SpriteManager:

```csharp
for(int i = 0; i < AutomaticallyUpdatedSprites.Count; i++)
{
   // do whatever
}
```

These lists are used by the ScreenManager to verify that all objects have been destroyed.

###
