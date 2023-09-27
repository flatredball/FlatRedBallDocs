## Introduction

**Global Content Files** is a special folder in Glue which can be used to store files which are always available when a game is running.

![](/media/2017-04-img_58efadc624882.png)

**Global Content Files** are loaded right when the game starts running, and are never unloaded when transitioning between screens. By contrast, files which are tied to specific screens or entities may not be available until the screen is created, or until an instance of the entity is created, and these files may get unloaded when the screen is destroyed.  
