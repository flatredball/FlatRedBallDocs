# flatredball-graphics-animationchainlist

### Introduction

Represents a list of [AnimationChains](../../../../../frb/docs/index.php). This object can be loaded from file and saved to file as well. This object is associated with the .achx file. For information on how to use AnimationChainLists in Glue, see [this article](../../../../../frb/docs/index.php). AnimationChains can be displayed by [IAnimationChainAnimatables](../../../../../frb/docs/index.php) such as [Sprites](../../../../../frb/docs/index.php) and [SpriteFrames](../../../../../frb/docs/index.php). For more information on how to work with AnimationChains in code, see the [IAnimationChainAnimatables page](../../../../../frb/docs/index.php).

### Loading from file

AnimationChains can be loaded from .achx files which are created in the [AnimationEditor](../../../../../AnimationEditorWiki.md). The following code creates an AnimationChain and assigns it to a Sprite. Add the following using statements to reduce code:

```
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Content.AnimationChain;
```

In Initialize after FlatRedBallServices.InitializeFlatRedBall:

```
// If loading from file:
AnimationChainList list = 
    FlatRedBallServices.Load<AnimationChainList>("animation.achx", "Global");
// Or if loading through the content pipeline:
AnimationChainList list = 
    FlatRedBallServices.Load<AnimationChainList>(@"Content\animation", "Global"); 

Sprite sprite = SpriteManager.AddSprite(list);
```

For information on loading through the Content Pipeline, see the [FlatRedBall XNA Content Pipeline](../../../../../frb/docs/index.php) wiki entry.

### Saving AnimationChainLists

To save an AnimationChainList to file, you can use the [AnimationChainListSave](../../../../../frb/docs/index.php) object. For more information, see [this page](../../../../../frb/docs/index.php).

### AnimationChainList Methods

* [FlatRedBall.Graphics.Animation.AnimationChainList.Clone](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
