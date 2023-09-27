## Introduction

Culling is the process of determining that an object or a part of an object does not need to be drawn, then skipping the drawing logic because of this determination. This is an effective way to improve performance if the process of detecting whether an object should be drawn is significantly faster than just performing the drawing itself, or if it is slightly faster but most objects will fail the draw test.

Some types of culling are performed at the hardware level. XNA and MDX have some options which allow you to cull objects depending on their position or orientation.

Other types of culling are performed at the engine level. FlatRedBall by default culls [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel") which are not in view. [SpriteGrids](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteGrid.md "FlatRedBall.ManagedSpriteGroups.SpriteGrid") perform an even more efficient culling than draw culling. By default [SpriteGrids](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteGrid.md "FlatRedBall.ManagedSpriteGroups.SpriteGrid") remove [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") which are not in view from the engine's memory. This not only saves draw time, but also management time and memory usage.

## RenderState CullMode

FlatRedBall automatically culls the "back faces" of models by setting the RenderState's CullMode to CullMode.CullCounterClockwiseFace. This eliminates the drawing of back-facign polygons which are part of [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel"). In some cases this can double rendering speed.

This behavior happens automatically and requires no special implementation or management.

## RenderState DepthBufferFunction

FlatRedBall uses the depth buffer (also known as the Z-buffer) to both create realistic-looking sorting as well as to improve performance.

The depth buffer is used in the following cases:

-   When drawing [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel").
-   When drawing [Z Buffered Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.AddZBufferedSprite "FlatRedBall.SpriteManager.AddZBufferedSprite").

Depth buffered culling is performed on a per-pixel basis. If a depth buffer check fails, then the renderer does not need to perform the pixel shader code for that pixel.

[PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel") automatically perform depth buffer culling so there is no need for any special implementation or management. [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") perform depth buffer culling if added as [Z Buffered Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.AddZBufferedSprite "FlatRedBall.SpriteManager.AddZBufferedSprite").
