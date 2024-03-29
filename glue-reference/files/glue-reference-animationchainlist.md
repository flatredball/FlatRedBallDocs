# Animation Chain List (.achx)

### Introduction

The AnimationChainList type is the runtime type for the .achx file type. AnimationChainLists are used to store a collection of animations. Examples of AnimationChainLists might be all of the animations for a Player in a game. The easiest way to add an AnimationChainList to your game is to add a new .achx file to a Screen, Entity, or global content:

<figure><img src="../../media/2016-01-20_16_19_33.gif" alt=""><figcaption></figcaption></figure>

For information on how to add a Sprite to your Entity, see [this page](broken-reference/). For information about how to use the AnimationEditor, see [the AnimationEditor documentation](../../documentation/tools/glue-gluevault-component-pages-animationeditor-plugin.md). For more information on using AnimationChainList files in the FlatRedBall Editor, see [this page](broken-reference).

### Viewing an AnimationChainList in game

AnimationChainLists are ultimately lists of textures and texture coordinates. They must be used on an object to be seen in game. Therefore, if you are creating an Entity or Screen which includes an AnimationChainList file, you will likely also need to add a Sprite to view the AnimationChainList.
