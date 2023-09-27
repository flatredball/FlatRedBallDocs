## Introduction

The Animate property returns whether the IAnimationChainAnimatable is performing animation (cycling through [AnimationFrames](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationFrame.md "FlatRedBall.Graphics.Animation.AnimationFrame")). This property does not reflect whether the IAnimationChainAnimatable has a CurrentChain. If it does not, this value may still be true indicating that the IAnimationChainAnimatable will animate once a CurrentChain is set.

## Setting Animate

The IAnimationChainAnimatable interface only requires that the Animate property returns a value - it doesn't require a setter; however, common IAnimationChainAnimatable-implementing classes like [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and [SpriteFrame](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteFrame.md "FlatRedBall.ManagedSpriteGroups.SpriteFrame") provide a setter. If the specific implementing class allows, setting this value to false will prevent animation from occurring, and will stop any existing animation. For example, the following code can be used to toggle whether a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") is animating:

    // assuming mySprite is a valid Sprite
    if(GuiManager.Cursor.PrimaryClick)
    {
       mySprite.Animate = !mySprite.Animate;
    }
