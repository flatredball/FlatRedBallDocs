## Introduction

The CurrentFrameIndex gets and sets the current frame that the IAnimationChainAnimatable is displaying. As animation plays this property will automatically increment and cycle. This value will always be between 0 and the count of the current [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain") minus one (inclusive).

## Manually setting CurrentFrameIndex

Assuming that mSprite is a valid Sprite that has a current AnimationChain the following code will manually cycle the Frames:

     // Set Animate to false so that it doesn't automatically animate on its own:
     mSprite.Animate = false;

     if (InputManager.Keyboard.KeyDown(Keys.Up))
     {
         mSprite.CurrentFrameIndex = 
             ( mSprite.CurrentFrameIndex + 1 ) % mSprite.CurrentChain.Count;
     }
     if (InputManager.Keyboard.KeyDown(Keys.Down))
     {
         mSprite.CurrentFrameIndex--;

         if (mSprite.CurrentFrameIndex < 0)
         {
             mSprite.CurrentFrameIndex = mSprite.CurrentChain.Count - 1;
         }
     }

## Restarting an Animation

Restarting the animation can be done either by setting the CurrentFrameIndex to 0 or by setting the CurrentChainName so long as the CurrentChainName differs from the set value. That means if your current animation is "DesiredAnimation" and you want to restart the animation you can either:

    // So long as CurrentChainName differs from "DesiredAnimation"
    someAnimatableObject.CurrentChainName = "DesiredAnimation";

**OR**

    someAnimatableobject.CurrentFrameIndex = 0;
