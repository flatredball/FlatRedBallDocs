## Introduction

The AnimationSpeed property controls the speed at which an Animation is playing. The default value for AnimationSpeed is 1, which means the amount of time that each [AnimationFrame](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationFrame "FlatRedBall.Graphics.Animation.AnimationFrame") displays is equal to its [FrameLength](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationFrame.FrameLength&action=edit&redlink=1 "FlatRedBall.Graphics.Animation.AnimationFrame.FrameLength (page does not exist)") property.

-   Increasing this value above 1 will make animations play faster.
-   Setting this value between 0 and 1 will make animations play slower.
-   Setting this value to 0 will make animations stop (similar to setting Animate to false).
-   Setting this value to a negative number will make animations play in reverse.

## Example - Setting AnimationSpeed in FlatRedBall Editor

A Sprite's AnimationSpeed can be changed in the FlatRedBall Editor in the Variables tab.

![](/media/2022-07-img_62e69faa9b168.png)

## 
