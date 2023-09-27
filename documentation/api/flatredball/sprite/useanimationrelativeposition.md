## Introduction

The UseAnimationRelativePosition value controls whether relative values [from the current AnimationFrame](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationFrame.RelativeX "FlatRedBall.Graphics.Animation.AnimationFrame.RelativeX") are applied to the Sprite. Relative values can be set in code, or can be set in the [AnimationEditor](/frb/docs/index.php?title=AnimationEditor "AnimationEditor"). A Sprite **must be attached to another [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject")** for relative values to have an impact on absolute position. In Glue this value is set to true by default. This means that any Sprite using an AnimationChain will automatically be positioned within its entity using the relative values of the AnimationChain. If this is not desired, the value should be set to false.

## When to use this value

If you are applying offset values in a .achx and you want these offset values to apply to Sprites (usually within an Entity) then this value should be true. If you are using a .acxh file, if the Sprite is part of an Entity, and if you want to manually move the Sprite around (either in code or in Glue), then this value should be set to false.

## Default Values

Sprites which originate from Scenes (.scnx files) will have this property set to true, therefore their relative values will be overridden by their AnimationChain. If you are using Glue, you can set this to false through a tunneled variable, or in custom code if you want to use custom positioning:

    SpriteInstance.UseAnimationRelativePosition = false;
