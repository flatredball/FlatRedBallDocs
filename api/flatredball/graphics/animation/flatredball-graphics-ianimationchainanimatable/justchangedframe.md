## Introduction

The JustChangedFrame property returns whether the frame index was changed this frame. This property can be checked every frame and action can be performed according to whether it has been changed.

## Code Example

The following assumes that SpriteInstance is a valid Sprite which is animating:

    if(SpriteInstance.JustChangedFrame)
    {
       int frameIndex = SpriteInstance.CurrentFrameIndex;
       // do something with frameIndex:
    }
