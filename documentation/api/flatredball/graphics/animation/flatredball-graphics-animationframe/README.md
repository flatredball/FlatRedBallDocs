## Introduction

AnimationFrames represent the state of an [IAnimationChainAnimatable](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.IAnimationChainAnimatable "FlatRedBall.Graphics.Animation.IAnimationChainAnimatable"). The following properties can be set by an AnimationFrame:

-   Texture
-   RelativeX/Y Position
-   Texture Coordinates
-   Horizontal/Vertical Flipping

AnimationFrames usually exist inside [AnimationChains](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain").

## Creating an AnimationFrame

AnimationFrame instances are typically contained in AnimationChains, and are created by loading a .achx file. AnimationFrames can be constructed in code, and can be added to AnimationChains (see below).

## Creating an AnimationFrame in Code

Although .achx files are the most common way to create AnimationFrames and AnimationChains, these objects can also be constructed in code. The following code shows how to construct an AnimationChain and AnimationFrame in code, assign it to an existing Sprite, and update the Sprite to the AnimationChain:

``` lang:c#
void CustomInitialize()
{
    // This code assumes SpriteInstance is a valid Sprite,
    //  TextureFile is a valid Texture2D. These can be created in Glue
    AnimationChain animationChain = new AnimationChain();

    AnimationFrame animationFrame = new AnimationFrame();
    animationFrame.Texture = TextureFile;
    animationFrame.LeftCoordinate = 0;
    animationFrame.RightCoordinate = 1;
    animationFrame.TopCoordinate = 0;
    animationFrame.BottomCoordinate = .5f;

    animationChain.Add(animationFrame);

    SpriteInstance.SetAnimationChain(animationChain);

    SpriteInstance.UpdateToCurrentAnimationFrame();
}
```

![](/media/2017-05-img_591e26d7460e5.png)

## FrameLength

The FrameLength property defines how long an AnimationFrame is displayed. Adding the FrameLengths of all AnimationFrames in an [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain") results in the length of the entire animation. FrameLength - like all timing in FlatRedBall - is performed in seconds. Therefore, if an AnimationFrame has a FrameLength of 1, the AnimationFrame will show for 1 second. If you are familiar with working in milliseconds, then simply divide the desired value by 1,000. For example, to set the FrameLength to 600 millseconds, simply divide 600 by 1,000 and set that value to your FrameLength:

    myFrame.FrameLength = 600/1000.0f;
    // OR
    myFrame.FrameLength = .6f;

##  AnimationFrame Members

\[subpages\]
