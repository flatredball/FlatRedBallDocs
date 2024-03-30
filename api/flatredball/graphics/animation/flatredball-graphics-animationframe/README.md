# AnimationFrame

### Introduction

AnimationFrames represent the state of an [IAnimationChainAnimatable](../../../../../frb/docs/index.php). The following properties can be set by an AnimationFrame:

* Texture
* RelativeX/Y Position
* Texture Coordinates
* Horizontal/Vertical Flipping

AnimationFrames usually exist inside [AnimationChains](../../../content/animationchain/).

### Creating an AnimationFrame

AnimationFrame instances are typically contained in AnimationChains, and are created by loading a .achx file. AnimationFrames can be constructed in code, and can be added to AnimationChains (see below).

### Creating an AnimationFrame in Code

Although .achx files are the most common way to create AnimationFrames and AnimationChains, AnimationFrames can also be constructed in code. The following code shows how to construct an AnimationChain and AnimationFrame in code, assign it to an existing Sprite, and update the Sprite to the AnimationChain:

```csharp
void CustomInitialize()
{
    // This code assumes SpriteInstance is a valid Sprite,
    //  TextureFile is a valid Texture2D.
    AnimationChain animationChain = new AnimationChain();

    AnimationFrame animationFrame = new AnimationFrame();
    animationFrame.Texture = TextureFile;

    // TextureCoordinates are normalized. In other
    // words:
    // * 0 represents the left or top edge of the texture
    // * 1 represents the right or bottom edge of the texture
    animationFrame.LeftCoordinate = 0;
    animationFrame.RightCoordinate = 1;
    animationFrame.TopCoordinate = 0;
    // A value of .5 means halfway down the texture. 
    // By setting the BottomCoordinate to .5f, only the top
    // half of the Sprite gets drawn.
    animationFrame.BottomCoordinate = .5f;

    animationChain.Add(animationFrame);

    SpriteInstance.SetAnimationChain(animationChain);

    SpriteInstance.UpdateToCurrentAnimationFrame();
}
```

![](../../../../../media/2017-05-img\_591e26d7460e5.png)

### FrameLength

The FrameLength property defines how long an AnimationFrame is displayed. Adding the FrameLengths of all AnimationFrames in an [AnimationChain](../../../../../frb/docs/index.php) results in the length of the entire animation. FrameLength - like all timing in FlatRedBall - is performed in seconds. Therefore, if an AnimationFrame has a FrameLength of 1, the AnimationFrame will show for 1 second. If you are familiar with working in milliseconds, then simply divide the desired value by 1,000. For example, to set the FrameLength to 600 millseconds, simply divide 600 by 1,000 and set that value to your FrameLength:

```csharp
myFrame.FrameLength = 600/1000.0f;
// OR
myFrame.FrameLength = .6f;
```
