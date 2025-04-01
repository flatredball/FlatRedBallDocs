# Sorting and Overlapping

### Introduction

Many games require Sprites to overlap to create realistic scenes. FlatRedBall offers a number of ways to control sorting. This article will discuss and link to various methods of controlling how Sprites (and other objects) overlap.

### What are the methods?

There are a number of methods of controlling overlapping Sprites. Keep in mind that these methods are not just used for Sprites, but for [Texts](../graphics/text/) as well. [DrawableBatches](../graphics/drawablebatch/) also use many of the methods mentioned below. These methods are:

* Setting Z value
* Using the depth buffer (also known as the z buffer)
* Using [Layers](../graphics/layer/)
* Using multiple [Cameras](../camera/)

### Setting Z Value

Setting the Z value of objects is an easy way to control sorting of objects. Of course, this method is mostly used when the Camera is in its default, unrotated state. Sprites and Texts are, by default, created as "ordered" objects. This means that FlatRedBall sorts these objects by their Z values every frame, then draws them "back-to-front" so that objects in back are overlapped by objects in front. This method of sorting is very common and is acceptable for many games. Often if the Camera is not [orthogonal](../camera/orthogonal.md), then the Z value can also be used to place objects in the distance, making them smaller due to the natural perspective of a 3D Camera. In this case, the Z value has the dual purpose of making objects seem like they are in the distance due to on-screen size changes as well as controlling the sorting. If the Camera is orthogonal (also known as a 2D Camera), then the Z value won't impact the on-screen size of an object, but it will still impact its sorting. In these cases, the Z value is used purely to control sorting. It is also common when using a 3D Camera to use very small differences in the Z value between objects to force a particular sorting. For example, if you are making a 2D platformer which has a player and grass Sprites both on the ground, you may set the player's Z to 0 and the grass Sprites to -.0001 so that they are drawn in front of the player.

#### Objects with the same Z

If two objects have the same Z value, their sorting priority is undefined. While there technically is a method to how FlatRedBall picks the order, this order is subject to performance optimizations and can vary between different versions of the engine. The bottom line is, **you should never rely** on the particular sorting order that you see for two objects that have the same Z value. If you require a particular sorting order, enforce it by explicitly setting different Z values, or by using one of the other sorting methods mentioned below.

#### Sorting on Y

Many top-down games have objects that should overlap each other depending on their Y positions. This functionality is built-in to FlatRedBall. For more information see the [SpriteManager's SortYSpritesSecondary article](../spritemanager/sortyspritessecondary.md).

### Using the depth buffer

The depth buffer can be used when more complex sorting is needed. Simple sorting by Z values always results in an object being drawn in full over all objects which are behind it. It is impossible to have two objects which intersect each other draw properly without using the depth buffer. Sprites can optionally modify the depth buffer as well. For information on this, see the [AddZBufferedSprite](../spritemanager/addzbufferedsprite.md) article. The Text object cannot modify the depth buffer - but objects that modify the depth buffer will sort properly with Texts. DrawableBatches can use and modify the depth buffer depending on the state values that are set in their Draw method.

### Using Layers

[Layers](../graphics/layer/) can be used to sort all types of objects. Objects on Layers will always draw on top of objects that are not on any layers, or objects that are on lower Layers (unless multiple Cameras are used, which we'll get to in the next section). Objects within a Layer will use Z ordering and the depth buffer to sort, so the Layer provides a hierarchical form of ordering. Layers are also effective in situations where you want to override the natural sorting performed by Z position or the Depth Buffer. For example, you may want a game's HUD to always appear on top of other objects, but you may also have a game where objects move freely towards the camera (if your game is 3D, or if you are using 3D particles). In this situation, Layers can guarantee that the HUD will never be covered by any other objects.

### Using multiple Cameras

FlatRedBall supports multiple Cameras. These cameras can be used to create split-screen views, or Cameras can be overlapped to result in one Camera drawing over another. Camera order is the highest-level form of controlling now objects sort. That is, an object on a second Camera will always draw on top of an another object that is drawn by a first Camera regardless of Z position, depth buffering, or layer membership.

### Diagram

The following diagram shows the order in which objects are drawn. Categories in the same vertical space will sort with each other (such as Depth Buffer and Coordinate Sorting) while categories which appear above will draw on top of categories below. For example, layered objects will always draw on top of unlayered objects.

&#x20;![SortingDiagram.png](../../../.gitbook/assets/migrated_media-SortingDiagram.png)&#x20;

This diagram can best be read bottom-up. The very bottom section (Camera 0, Unlayered) is where objects are added by default when added through managers like the SpriteManager or TextManager. Layers added to the SpriteManager are added as world Layers. Layers added to Cameras are specific to the Camera they are added to. To move objects to specific Layers, call AddToLayer on the appropriate manager for the objectt to be moved.
