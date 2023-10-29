## Introduction

RemoveSprite removes a Sprite from the SpriteManager. It also removes the Sprite from any rendering that may be done by the engine (such as if the Sprite is part of a Layer. This method can be called on any Sprite regardless of whether it belongs to a particular Layer, whether it is automatically or manually updated, or whether it is a particle or regular Sprite. Since Sprites have a two-way relationship with any PositionedObjectList or SpriteList that they are a part of, this method will also remove the Sprite from those lists.
