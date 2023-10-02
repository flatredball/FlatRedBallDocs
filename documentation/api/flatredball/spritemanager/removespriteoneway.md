# removespriteoneway

### Introduction

The RemoveSpriteOneWay method removes the argument Sprite from the SpriteManager (for both rendering and automatic updates) but does not modify any relationships between the Sprite and objects outside of the game engine. Specifically, RemoveSpriteOneWay will remove a Sprite from:

* Rendering
  * Ordered rendering
  * Z-Buffered rendering
  * Layered rendering
* Automatic engine updates

RemoveSpriteOneWay will not remove a Sprite from:

* Glue entities and other game-level [PositionedObjectLists](../../../../frb/docs/index.php)
* Parent/child relationships

### Code Example

The following code will remove a Sprite from the SpriteManager, but will preserve any game-level relationships:

```
SpriteManager.RemoveSpriteOneWay(SpriteInstance);
```

### Example - Moving Entity Sprites to Layers

RemoveSpriteOneWay can be used to move a Sprite from an entity to a different layer. Keep in mind that if the entire entity should be moved from one entity to another, call [MoveToLayer](../../../tools/glue-reference/entities/movetolayer.md). However, to move an individual Sprite which is a part of an entity (such as a Sprite used to render glowing light), it needs to first be removed from the engine, then added to a different layer. The following code moves a Sprite which is part of a TorchInstance entity to a layer called LightLayer:

```lang:c#
SpriteManager.RemoveSpriteOneWay(TorchInstance.LightSprite);
SpriteManager.AddToLayer(TorchInstance.LightSprite, LightLayer);
```

Note that the code above assumes that LightSprite is publicly available. If the Sprite is part of a Glue entity, this can be made public in Glue by setting [HasPublicProperty](../../../tools/glue-reference/objects/glue-reference-haspublicproperty.md) to true.
