[\<- SpriteManager](/frb/docs/index.php?title=FlatRedBall.SpriteManager.md "FlatRedBall.SpriteManager")

## Introduction

The SortYSpritesSecondary performs a sort on all ordered [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") so that sprites with a larger Y are drawn first. The sorting based off of Y is only done on Sprites which have the same Z value. Therefore, Z takes first priority, then [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") with the same Z will be sorted so Sprites at the bottom of the screen (smaller Y values) will be drawn last (on top). If you desire to sort the Sprites by their Y to control drawing order, it is usually better to assign [FlatRedBall.SpriteManager.OrderedSortType](/frb/docs/index.php?title=FlatRedBall.SpriteManager.md.OrderedSortType "FlatRedBall.SpriteManager.OrderedSortType") so that the ordered sort type doesn't conflict with the manual Y-based sorting.

## Code Example - Manually Calling SortYSpritesSecondary

The SortYSpritesSecondary method can be called manually. Note that this is not needed if you have set the [OrderedSortType](/documentation/api/flatredball/flatredball-spritemanager/flatredball-spritemanager-orderedsorttype/.md). To use SortYSpritesSecondary manually, call the method every frame **at the end of Update**. Add the following code at the end of your Update call (or your [Screen's](/frb/docs/index.php?title=Screen.md "Screen") Activity method):

    SpriteManager.SortYSpritesSecondary();
