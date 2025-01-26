# RemoveSprite

### Introduction

RemoveSprite removes a Sprite from the SpriteManager, any attached parent (such as entities), and any PositionedObjectLists (including SpriteLists). If a Sprite is removed from the SpriteMangaer, it is no longer rendered. Therefore, the Sprite is removed from the unlayered Sprite list as well as all Layers.

This method can be called on any Sprite regardless of whether it belongs to a particular Layer, whether it is automatically or manually updated, or whether it is a particle or regular Sprite.

### Calling RemoveSprite

Usually Sprites do not need to be explicitly removed. The following situations are when Sprites need to be explicitly removed:

* If a Sprite is created and added to the SpriteManager manually in code, such as creating a Sprite background in a Screen's CustomInitialize.&#x20;
* If a particle Sprite needs to be destroyed before the screen has been destroyed. For example a Sprite for a rain drop may need to be destroyed once it hits the ground.

Sprites do not need to be destroyed if the Sprites are:

* Added to Entities in the FRB Editor
* Added to a PositionedObjectList which is defined in the FRB Editor
* Created as particle Sprites - these can be destroyed early, but they will automtaically be destroyed if the current Screen is destroyed
