## Introduction

ManualUpdate "applies" any changes to a manually-updated Sprite. Sprites are often made manually-updated for performance reasons. If you convert an entire [FlatRedBall.Scene](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene") to be manually-updated, but you want parts of the Scene to have activity (such as rotational velocity), then you will need to call ManualUpdate on any Sprite which should be updated. Manually-updated Sprites must also have ManualUpdate called on them to have any render changes applied, such as changes to [ColorOperations](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.ColorOperation "FlatRedBall.Graphics.IColorable.ColorOperation").

## Code Example

To update a Sprite, simply call ManualUpdate on it:

    SpriteManager.ManualUpdate(SpriteInstance);
