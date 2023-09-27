## Introduction

Files added to the FlatRedBall Editor will be managed for you automatically, simplifying the game development process. When a file is added to the FRB Editor the following occurs:

-   The file is listed in the tree view
-   The file is added to the proper Visual Studio project
-   A static member is added for the file in the appropriate screen, entity, or global content
-   Code for loading the file is generated automatically

## Supported File Types

-   png (image files)
-   achx (animation files)
-   nntx (node network files)
-   tmx (tiled map files)
-   gusx (glue screen files, usually automatically added by Glue)
-   mp3 (music)
-   ogg (music)
-   wav (sound)
-   csv (spreadsheet files for data)

The following types are also supported, but  are not commonly used in modern FlatRedBall game development

-   scnx
-   shcx
-   emix
-   splx

## Accessing Files in Code

Files in Glue can be accessed in code. Files added to global content can be accessed in any location. Files added to screens and entities can safely be accessed within the respective screen or entity's custom code. Files from other screens or entities can be accessed so long as the owning screen or entity has had its LoadStaticContent method called.

### Accessing Files in Their Screen or Entity

Files added to a Screen or Entity create a member which can be accessed in code. For example, if a .png file is added to an Entity, it can be used to assign a texture on a sprite. In the example below, Glue will generate code for a Texture2D  called MonsterTexture .

![](/media/2016-12-img_5862826fb04fe.png)

![](/media/2016-12-img_586282b3a3374.png)

### Accessing Global Content Files

Global content files are loaded when the game first starts, and remain in memory for the remainder of a game's execution, so they can be accessed at any time. For example, the following CSV named EnemyInfo is part of global content:

![](/media/2016-07-img_5788253c028d8.png)

This can be accessed anywhere in a game with the following code:

``` lang:c#
var goblinInfo = GlobalContent.EnemyInfo["Goblin"];
var health = goblinInfo.Health;
```

## Shared Files

Single files can be shared across multiple Screens, Entities, and Global Content. For example, a file may be added to Global Content Files, but then also added to an Entity to be accessible by that Entity in Glue: ![SharedGlueFiles.gif](/media/migrated_media-SharedGlueFiles.gif) Files can also be shared between entities and screens. For example, the following shows a single file shared between two entities: [![](/wp-content/uploads/2016/02/2019-05-27_06-48-58.gif.md)](/wp-content/uploads/2016/02/2019-05-27_06-48-58.gif.md) Notice that the file added to Player has a name of **Entities/Enemy/MainImage.png. **Glue will not duplicate the file on disk, and will only load the image once if both Player and Enemy are created in the same screen.

## File Folders

The "Files" tree node supports folders. To add a folder:

1.  Right-click on the "Files" node
2.  Enter the name of the folder
3.  Click OK

This will create a folder both in Glue as well as on the file system. ![FileFoldersGlueAndWindows.PNG](/media/migrated_media-FileFoldersGlueAndWindows.PNG)

## Name and Location

The Name of a file in Glue will reflect its location. For example, the following shows a file located in the Animations folder of a Ball entity: ![GlueFileNameWithFolders.png](/media/migrated_media-GlueFileNameWithFolders.png) Shared files will display the name of their location on disk. For example the following shows a file which is located in Global Content, but shared with an entity. When the shared copy is selected the file's actual location is show in the Name property: ![GlueSharedBallName.png](/media/migrated_media-GlueSharedBallName.png) Notice that the file above is located in **GlobalContent/ball.png**, but it appears in both the **Global Content Files** folder and the **Files** folder of **BallEntity**. To view a file in its location on disk, right-click and select **View in Explorer**. [![](/wp-content/uploads/2016/02/2019-05-02_06-48-09.gif.md)](/wp-content/uploads/2016/02/2019-05-02_06-48-09.gif.md)
