## Introduction

The CurrentChainName property gets and sets the name of the [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain.md "FlatRedBall.Graphics.Animation.AnimationChain") currently played by the owner of the property. Setting this property is the most common way to change between different animations at runtime, and it can also be set in Glue to control the animation displayed by an IAnimationChainAnimatable (such as a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite")).

## Code Example

The CurrentChainName property is a string, so code can assign animation chains in a way that is not tied to the underlying content. The following code shows how to set the animation of an object according to [pressed keys](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard.md "FlatRedBall.Input.Keyboard").

    // Assuming that SpriteInstance is a valid Sprite, and that SpriteInstance contains animations with the name WalkLeft and WalkRight
    if(InputManager.Keyboard.KeyDown(Keys.Right))
    {
       SpriteInstance.CurrentChainName = "WalkRight";
    }
    else if(InputManager.Keyboard.KeyDown(Keys.Left))
    {
       SpriteInstance.CurrentChainName = "WalkLeft";
    }

## What does ChangingCurrentChainName do?

Changing CurrentChainName does a number of things:

-   Sets the displayed animation to the animation matching the set name.
-   Restarts the animation from the very beginning.
-   Immediately updates the IAnimationChainAnimatable's textures and texture coordinates to reflect the first frame in the animation.

Note that these actions are only taken if the CurrentChainName *changes. *Assigning CurrentChainName to the same value performs no logic, so it can be safely set every frame without restarting the animation from the beginning. To restart the animation from the beginning, set [CurrentFrameIndex](/documentation/api/flatredball/flatredball-graphics/animation/flatredball-graphics-animation-ianimationchainanimatable/flatredball-graphics-animation-ianimationchainanimatable-currentframeindex/.md) to 0.

## What does setting CurrentChainName not do?

Keep in mind that some properties will not change in response to CurrentChainName being set:

-   JustCycled
-   JustChangedFrame
