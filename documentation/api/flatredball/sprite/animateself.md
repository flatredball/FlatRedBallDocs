## Introduction

The AnimateSelf function updates advances a Sprite through its animation (if it is animated) and updates the Sprite's Texture and texture coordinates according to its current animation. Sprites which are updated automatically (default) will automatically have this function called by the SpriteManager. Typically you only need to manually call this if a Sprite has been converted to manually updated, but it should still be animated.

## Code Example

Typicalily the AnimateSelf function takes the [TimeManager.CurrentTime](/frb/docs/index.php?title=FlatRedBall.TimeManager.CurrentTime "FlatRedBall.TimeManager.CurrentTime") value. The following code would animate a Sprite:

    // assuming the Sprite SpriteInstance exists:
    SpriteInstance.AnimateSelf(TimeManager.CurrentTime);
