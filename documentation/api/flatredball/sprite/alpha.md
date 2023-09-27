## Introduction

The Alpha value controls the opacity of a Sprite. A value of 1 (default) results in a fully-opaque Sprite, while a value of 0 is a fully-transparent Sprite. For more information see the [Alpha property on IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.Alpha "FlatRedBall.Graphics.IColorable.Alpha"). Sprite Alpha can be also be set in Glue directly and through states. Sprites can also be made fully invisible by setting the [FlatRedBall.Sprite.Visible](/frb/docs/index.php?title=FlatRedBall.Sprite.Visible "FlatRedBall.Sprite.Visible") property to false.

## Code Example

The following shows how to make a Sprite fully transparent:

    SpriteInstance.Alpha = 0;

The following shows how to make a Sprite fully opaque:

    SpriteInstance.Alpha = 1;

The following shows how to make a Sprite half opaque:

    SpriteInstance.Alpha = .5f;
