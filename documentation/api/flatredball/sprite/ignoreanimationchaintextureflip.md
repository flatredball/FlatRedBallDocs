## Introduction

The IgnoreAnimationChainTextureFlip property can be used to control whether a Sprite's [FlipHorizontal](/frb/docs/index.php?title=FlatRedBall.Sprite.FlipHorizontal&action=edit&redlink=1 "FlatRedBall.Sprite.FlipHorizontal (page does not exist)") and [FlipVertical](/frb/docs/index.php?title=FlatRedBall.Sprite.FlipHorizontal&action=edit&redlink=1 "FlatRedBall.Sprite.FlipHorizontal (page does not exist)") values are changed by the current [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain"). This value defaults to true, meaning that a Sprite's current [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain") will overwrite the Sprite's [FlipHorizontal](/frb/docs/index.php?title=FlatRedBall.Sprite.FlipHorizontal&action=edit&redlink=1 "FlatRedBall.Sprite.FlipHorizontal (page does not exist)") and [FlipVertical](/frb/docs/index.php?title=FlatRedBall.Sprite.FlipHorizontal&action=edit&redlink=1 "FlatRedBall.Sprite.FlipHorizontal (page does not exist)") when the frame changes. In other words, if IgnoreAnimationChainTextureFlip is true (default value), and a Sprite is using an [AnimationChain](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChain "FlatRedBall.Graphics.Animation.AnimationChain"), then the FlipHorizontal and FlipVertical will be overwritten by the AnimationChain so they should not be manually set.

## Code Example

The following code assigns a Sprite  instance's CurrentChainName  property to "Walk" , but tells the sprite to not apply the AnimationFrame.FlipHorizontal  value:

``` lang:c#
// assume SpriteInstance is a valid Sprite with AnimationChains containing "WalkRight"

SpriteInstance.IgnoreAnimationChainTextureFlip = true;
SpriteInstance.CurrentChainName = "WalkRight";
```

## Usage Discussion

The IgnoreAnimationChainTextureFlip  value is often used to prevent an AnimationChain from controlling a Sprite instance's FlipHorizontal  value. It also prevents the FlipVertical  value from being modified, but FlipHorizontal  value is more commonly used to face a character left or right in a side-view game. Games including characters which can face to the left or right have two options for flipping the visuals:

1.  Create two AnimationChains - one facing left and one facing right. Since each frame can flip the sprite, the left and right-facing animations can use the same source images/sprite sheets.
2.  Create a single AnimationChain, but control Sprite.FlipHorizontal  in code.

The first approach lets the AnimationChain (.achx) file fully control the visuals of the sprite. This means that the walk left vs. walk right may simply be flipped, or it means that different animations can be created for each direction. For example, if the character carries a sword, the sword may be in front of the character when walking one direction, but behind the character when walking the other direction. The second approach can be easier to implement in code since it does not require additional content (modifications to the .achx file). Developers are encouraged to use the first approach as it does not introduce any performance penalty, and allows content to be modified without any code at a future time.
