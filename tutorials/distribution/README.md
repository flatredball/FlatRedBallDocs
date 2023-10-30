# distribution

### Introduction

FlatRedBall games are distributed similar to any other app for a given platform. In some cases (such as iPhone and Android), a dedicated store exists for distribution. In other cases such as PC games, distribution can be done in a number of ways.

### Distributing Windows (Desktop GL) Games

The DesktopGL platform provides the most flexibility for distribution.

#### Distributing Debug Builds

The easiest way to distribute your game is to package it in a .zip file. When you build your game in Visual Studio, the output window displays the location where the built files are located:

![](../../../media/2021-07-img_60ef661acb76b.png)

Note that if you are building your game in Glue, the output directory may differ. The location will be displayed in the Build tab when you build and run your game in Glue:

![](../../../media/2021-07-img_60ef6658f2d1a.png)

To distribute this game, navigate to the folder where the game is built, select all files, and zip them. You may want to exclude .pdb files, as they can increase the size of your zip file.

![](../../../media/2021-07-img_60ef66dc4d0a1.png)

This zip file can be sent to others such as testers or friends.     \[subpages depth="1"]
