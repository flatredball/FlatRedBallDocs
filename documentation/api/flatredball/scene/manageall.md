[Back to Scene](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene")

## Introduction

The ManageAll method calls the Manage method on all contained SpriteGrids. If there are no SpriteGrids contained in the Scene, then this method does nothing. In most cases if your Scene contains SpriteGrids you should call ManageAll. If not, you may have bugs where SpriteGrids seem to be missing Sprites when moving the Camera or when zooming out.

This method should be called every frame if you have a moving camera or at least once after setting the final position of your Camera if using a static Camera.

For more information on Manage, see [this page](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteGrid.Manage.md "FlatRedBall.ManagedSpriteGroups.SpriteGrid.Manage").
