# lastframerenderbreaklist

### Introduction

LastFrameRenderBreakList is a list of RenderBreaks which were created last frame. For this to be a non-null list, the [Renderer's RecordRenderBreaks](../../../../../frb/docs/index.php) value must be set to true. This is by default false for performance reasons.

This member can be used to get detailed information about the last frame's render breaks. To simply count the number of render breaks, use the [RenderBreaksAllocatedThisFrame](../../../../../frb/docs/index.php) property. This property is always valid.

### Code Example

The following code will measure the render breaks.

```
protected override void Draw(GameTime gameTime)
{
    // This tells the engine to record the render breaks.
    // It only needs to be set once but we'll do it here to
    // keep the code sample short:
    FlatRedBall.Graphics.Renderer.RecordRenderBreaks = true;
    FlatRedBallServices.Draw();

    var renderBreaks = FlatRedBall.Graphics.Renderer.LastFrameRenderBreakList;
    
    foreach(var renderBreak in renderBreaks)
    {
        // do something with renderBreak, like print it out
    }

    base.Draw(gameTime);
}
```
