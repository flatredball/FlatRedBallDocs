## Introduction

The UseAnimationRelativePosition property controls whether the IAnimationChainAnimatable sets its relative values when the current AnimationChain changes its displayed frame. This value is true by default for the Sprite object. If you are applying relative values to an object such as a Sprite and do not want the AnimationChain to interfere, then set this value to false in code:

    SpriteInstance.UseAnimationRelativePosition = false;
