# Animation Chain List (.achx)

### Introduction

The AnimationChainList type is the runtime type for the .achx file type. AnimationChainLists are used to store a collection of animations. Examples of AnimationChainLists might be all of the animations for a Player in a platformer game, such as:

* WalkLeft
* WalkRight
* IdleLeft
* IdleRight
* JumpLeft
* JumpRight
* AttackLeft
* AttackRight

The easiest way to add an AnimationChainList to your game is to add a new .achx file to a Screen, Entity, or global content:

<figure><img src="../../.gitbook/assets/2016-01-20_16_19_33.gif" alt=""><figcaption></figcaption></figure>

For information on how to add a Sprite to your Entity, see [this page](../objects/object-types/glue-reference-sprite.md). For information about how to use the AnimationEditor, see [the AnimationEditor documentation](../../glue-gluevault-component-pages-animationeditor-plugin/).

### Viewing an AnimationChainList in game

AnimationChainLists are ultimately lists of textures and texture coordinates. They must be used on an object to be seen in game. Therefore, if you are creating an Entity or Screen which includes an AnimationChainList file, you will likely also need to add a Sprite to view the AnimationChainList.
