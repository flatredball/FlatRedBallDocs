# AnimationChainList

### Introduction

Represents a list of [AnimationChains](../../content/animationchain/). This object can be loaded from file and saved to file as well. This object is associated with the .achx file. For information on how to use AnimationChainLists in the FlatRedBall Editor, see the [.achx page](../../../../glue-reference/files/file-types/glue-reference-animationchainlist.md). AnimationChains are typically used with Sprites.

### Loading from file

AnimationChains can be loaded from .achx files which are created in the [AnimationEditor](../../../../AnimationEditorWiki.md). The following code creates an AnimationChain and assigns it to a Sprite. Add the following using statements to reduce code:

```csharp
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Content.AnimationChain;
```

In Initialize after FlatRedBallServices.InitializeFlatRedBall:

```csharp
// If loading from file:
AnimationChainList list = 
    FlatRedBallServices.Load<AnimationChainList>("animation.achx", "Global");
// Or if loading through the content pipeline:
AnimationChainList list = 
    FlatRedBallServices.Load<AnimationChainList>(@"Content\animation", "Global"); 

Sprite sprite = SpriteManager.AddSprite(list);
```

### Saving AnimationChainLists

To save an AnimationChainList to file, you can use the [AnimationChainListSave](../../content/animationchain/flatredball-content-animationchainlistsave.md) object.
