# flatredball-graphics-animationchain

### Introduction

AnimationChains represent a series of [AnimationFrames](../../../../../../frb/docs/index.php) which can be used to animate objects which implement the [IAnimationChainAnimatable](../../../../../../frb/docs/index.php) interface such as [Sprites](../../../../../../frb/docs/index.php). AnimationChains can be created in code, or they can be created using the [AnimationEditor](../../../../../../frb/docs/index.php). The [AnimationEditor](../../../../../../frb/docs/index.php) is installed when running the FlatRedBall installer which can be found on the [downloads page](../../../../../../frb/docs/index.php). The [IAnimationChainAnimatable page](../../../../../../frb/docs/index.php) has more information on how to use AnimationChains, so please check it out after finishing up this page.

### Namespace

The following statement will help reduce code when working with AnimationChains.

```
using FlatRedBall.Graphics.Animation;
```

### Creating AnimationChains

AnimationChains can be created manually by creating the frames individually through code, by loading a .achx file, or through the content pipeline.

#### Creating AnimationChains in Code

```
AnimationChain animationChain = new AnimationChain();
animationChain.Add(new AnimationFrame(@"Animation\Drone_0000.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0001.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0002.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0003.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0004.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0005.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0006.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0007.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0008.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0009.png", .1f, "Global"));
animationChain.Add(new AnimationFrame(@"Animation\Drone_0010.png", .1f, "Global"));
```

Notice that the .1f is the frame length in seconds. For from-file and content pipeline loading, see the [AnimationChainList](../../../../../../frb/docs/index.php) wiki entry.

Note: The AnimationFrame class is used to define individual frames in an AnimationChain. For more information on how to modify your animations, including how to create animations by using parts of a single Texture, see the [AnimationFrame page](../../../../../../frb/docs/index.php).

#### Loading an AnimationChainList from file

For information on loading an AnimationChainList from a .achx file, see [this page](../../../../../../frb/docs/index.php#Loading\_from\_file).

### Accessing [AnimationFrames](../../../../../../frb/docs/index.php)

AnimationChains are also Lists of [AnimationFrames](../../../../../../frb/docs/index.php). Therefore the AnimationChain provides the same interface as a list for accessing frames, such as indexing ( \[index] ), properties like Count, and methods like Add. For example, the following code can be used to change the referenced texture of all frames in an animation chain to NewTexture :

```lang:c#
foreach(var frame in AnimationChainInstance)
{
   frame.Texture = NewTexture;
}
```

&#x20;

### AnimationChain Members

* [FlatRedBall.Graphics.Animation.AnimationChain.FrameToFrame](../../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.AnimationChain.TotalLength](../../../../../../frb/docs/index.php)

### Related Classes

* [FlatRedBall.Graphics.Animation.AnimationFrame](../../../../../../frb/docs/index.php) - AnimationChains represent a list of [AnimationFrames](../../../../../../frb/docs/index.php). When an AnimationChain is applied to an object, the object flips through and uses the [AnimationFrames](../../../../../../frb/docs/index.php) to modify its appearance.
* [FlatRedBall.Graphics.Animation.AnimationChainList](../../../../../../frb/docs/index.php) - [AnimationChainLists](../../../../../../frb/docs/index.php) are lists of AnimationChains. Objects such as [Sprites](../../../../../../frb/docs/index.php) store [AnimationChainLists](../../../../../../frb/docs/index.php), simplifying the process of setting which AnimationChain is currently used.
* [FlatRedBall.Content.AnimationChain.AnimationChainListSave](../../../../../../frb/docs/index.php) - The "save" file for AnimationChainList files. This can be saved to and loaded from .achx files, and can also be converted to and from AnimationChainLists. For more information, see the [FlatRedBall File Types](../../../../../../frb/docs/index.php) wiki entry.
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable](../../../../../../frb/docs/index.php) - The interface that defines properties and members for objects which can be animated by AnimationChains. See this article for information on how to set animations on objects such as [Sprites](../../../../../../frb/docs/index.php).

### Additional Information

* [FlatRedBall.Sprite.PixelSize](../../../../../../frb/docs/index.php) - PixelSize can be used to reactively set scale based off of a changed Texture resulting from playing an AnimationChain.

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../../frb/forum.md) for a rapid response.
