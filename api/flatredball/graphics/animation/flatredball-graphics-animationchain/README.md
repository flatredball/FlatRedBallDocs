# AnimationChain

### Introduction

AnimationChains represent a series of [AnimationFrames](../flatredball-graphics-animationframe/) which can be used to animate objects which implement the [IAnimationChainAnimatable](../flatredball-graphics-ianimationchainanimatable/) interface such as [Sprites](../../../sprite/). AnimationChains can be created in code, or they can be created using the [AnimationEditor](../../../../../glue-gluevault-component-pages-animationeditor-plugin/). The AnimationEditor is installed when running the FlatRedBall installer which can be found on the [downloads page](../../../../../). The IAnimationChainAnimatable page has more information on how to use AnimationChains, so please check it out after finishing up this page.

### Namespace

The following statement will help reduce code when working with AnimationChains.

```csharp
using FlatRedBall.Graphics.Animation;
```

### Creating AnimationChains

AnimationChains can be created manually by creating the frames individually through code, by loading a .achx file, or through the content pipeline.

#### Creating AnimationChains in Code

```csharp
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

Notice that the .1f is the frame length in seconds. For information on loading an Animation from-file loading, see the [AnimationChainList](../flatredball-graphics-animationchainlist.md) page.

Note: The AnimationFrame class is used to define individual frames in an AnimationChain. For more information on how to modify your animations, including how to create animations by using parts of a single Texture, see the [AnimationFrame page](../flatredball-graphics-animationframe/).

#### Loading an AnimationChainList from file

For information on loading an AnimationChainList from a .achx file, see [this page](../../../../../frb/docs/index.php#Loading_from_file).

### Accessing AnimationFrames

AnimationChains are also Lists of AnimationFrames. Therefore the AnimationChain provides the same interface as a list for accessing frames, such as indexing ( \[index] ), properties like Count, and methods like Add. For example, the following code can be used to change the referenced texture of all frames in an animation chain to NewTexture :

```csharp
foreach(var frame in AnimationChainInstance)
{
   frame.Texture = NewTexture;
}
```
