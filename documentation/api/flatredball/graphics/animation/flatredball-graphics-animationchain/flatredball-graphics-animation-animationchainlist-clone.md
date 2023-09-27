## Introduction

The Clone method can be used to make a copy of the AnimationChainList. This method is useful if your game needs to make copies of AnimationChainLists loaded from file. This is the case if the AnimationChainLists use the same texture coordinates, but simply use different Textures (such as different animation chains for characters in a game).

## Code Example

The following code example assumes that OriginalAnimationChainList is a valid AnimationChainList.

     AnimationChainList copyOfOriginal = OriginalAnimationChainList.Clone();
     copyOfOriginal.Name = OriginalAnimationChainList.Name + "Copy";
     // Adding it to the content manager allows us to get a reference to this later if necessary
     // This is not necessary, it just makes referencing by name easier:
     FlatRedBallServices.AddDisposable(copyOfOriginal.Name, copyOfOriginal, ContentManagerName);

For more information see the [AddDisposable page](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.AddDisposable.md "FlatRedBall.FlatRedBallServices.AddDisposable").
