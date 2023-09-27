## Introduction

The optionally-loaded content features in Glue enable creating single Screens which can support multiple levels. Multiple-level Screens are an alternative to creating one base Screen, then creating individual Screens for each level - each one inheriting from the base.

## Benefits

Each approach has its own benefits, and which approach you take ultimately depends on the needs of the game you are developing.

### Benefits of Multiple-Screens

Multiple Screens have a number of benefits over single-screen levels:

-   Full compatibility with GlueView
-   No code required to run a particular level - just set it as the StartUp Screen and play the game
-   High-level separation of content - each Screen contains only the files that it uses

### Benefits of Single-Screen

-   Reduces the amount of hookup required to create new levels - designers can simply drop files in a Screen
-   Improves scalability - fewer Screens will be needed to support a large number of levels

## Creating a Base Screen

The first step in creating a multiple-level Screen is to create a Screen which will hold all the different files for each level as well as the general-purpose logic. Keep in mind that using a multiple-level Screen **does not** prevent you from inheriting from this Screen for level-specific logic. However, limiting the amount of inheritance can be beneficial, and can be done by writing general-purpose code in your level Screen and moving any specific logic into Entities when appropriate. We'll start with an empty Glue project and add a single Screen called GameScreen:

-   Right-click on Screens
-   Select "Add Screen"
-   Enter the name "GamePlayScreen"
-   Press OK

![GamePlayScreen.png](/media/migrated_media-GamePlayScreen.png)

## Defining Objects

Next we'll define the types of objects our Screen will have. If you've worked with Screens before, you may have simply added files (such as .scnx or .shcx) to your Screen and worked with those references. When making a Screen that can support multiple levels, you will be adding multiple files to your Screen. In this tutorial we'll create a Screen that has both a collision object (ShapeCollection) as well as graphics (Scene). To create the graphics (often also referred to as "visible representation"):

1.  Right-click on your Screen's Objects tree item
2.  Select "Add Object"
3.  Enter the name "VisibleRepresentation"
4.  Change the SourceType to FlatRedBall Type (the file association will be done in code, not Glue)
5.  Change the SourceClassType to Scene

To create the collision:

1.  Right-click on your Screen's Objects tree item
2.  Select "Add Object"
3.  Enter the name "Collision"
4.  Change the SourceType to FlatRedBall Type (the file association will be done in code, not Glue)
5.  Change the SourceClassType to ShapeCollection

![VisibleRepresentationAndCollision.png](/media/migrated_media-VisibleRepresentationAndCollision.png) Now you have 2 objects which will represent the current visible representation and collision. When you write your logic in your game (such as collision logic) you will use these objects.

## Creating Folders

The next step is to create folders for your content. The folder structure may depend on the specific game you're making. For example, if you are making a game like Super Mario Bros., you may want to make one folder for each World (World1, World2, World3, etc), then have each World folder contain a Level folder (Level1, Level2, Level3, etc). In this case, your folder structure may look like this:

-   World1
    -   Level1
    -   Level2
    -   Level3
    -   Level4
-   World2
    -   Level1
    -   Level2
    -   Level3
    -   Level4
-   World3
    -   Level1
    -   Level2
    -   Level3
    -   Level4

Keep in mind that each level may contain multiple files. In this tutorial each level will contain a visible representation and a collision file. Therefore, you'll probably want to make a new folder for each level. For this tutorial we'll create three levels. To do this:

1.  Expand your GamePlayScreen
2.  Right-click on the Files tree item
3.  Select "Add Folder"
4.  Enter the name "Forest" to represent a forest level
5.  Repeat the steps above to also create "Desert" and "Arctic" folders

![ThreeLevelFolders.png](/media/migrated_media-ThreeLevelFolders.png)

## Creating files

Next we'll be creating files for our levels. To do this:

1.  Expand your Files tree item under your Screen.
2.  Right-click on the "Forest" folder and select "Add File"-\>"New File"
3.  Select the "Scene (.scnx)" file type
4.  Enter the name ForestScene
5.  Repeat the above steps, but select "ShapeCollection (.scnx)" and name it ForestCollision

![ForestLevelFiles.png](/media/migrated_media-ForestLevelFiles.png) Next, repeat the steps above in the Desert and Arctic folders as well. In total you should have 6 files: ![SixFiles.PNG](/media/migrated_media-SixFiles.PNG)

## Making the files optionally loaded

At this point we have six files in our game, but they are not treated as optionally loaded. In other words, if we were to run our game, all six files would get loaded in the same Screen. Instead, we want to only pick one pair of files (arctic, forest, or desert). To make them optionally loaded:

1.  Select ArcticScene.scnx
2.  Change its LoadedOnlyWhenReferenced to True![ArcticLoadedOnlyWhenReferenced.png](/media/migrated_media-ArcticLoadedOnlyWhenReferenced.png)
3.  Repeat this for the other five files so that all of the files have LoadedOnlyWhenReferenced set to true.

## Writing the code

At this point the Glue project is set up in such a way that it is ready for code. You'll want to open Visual Studio and open GamePlayScreen.cs. Once this is open, add the following method:

     void SetLevelByName(string levelName)
     {
         VisibleRepresentation = (Scene)GetMember(levelName + "Scene");
         Collision = (ShapeCollection)GetMember(levelName + "Collision");
         // At this point both VisibleRepresentation and Collision are
         // loaded from file and in-memory, but the FlatRedBall Engine doesn't
         // know about them.  We will only add the VisibleRepresentation to the
         // engine, but the Collision object could be added too if you need it drawn
         // for debugging.
         VisibleRepresentation.AddToManagers();
     }

This method assumes that it will be passed a name such as "Forest" which will then used to load the Scene and ShapeCollection by appending "Scene" and "Collision". If you have additional files you want to load, you can load them here as well. Keep in mind that file names are very important. The GetMember method is case-sensitive. Therefore if you looked for "desertScene" but your file was actually called "DesertScene" then GetMember would not be able to find the file. As mentioned in the comments, we call AddToManagers to so that the Scene can be rendered. For more information see the [AddToManagers page](/frb/docs/index.php?title=FlatRedBall.Scene.AddToManagers.md "FlatRedBall.Scene.AddToManagers"). As mentioned above, you will want to use the Collision object in your game logic. If you have a Collision ShapeCollection in your Screen then you will likely be performing collision between Entities and this ShapeCollection. Therefore in your CustomActivity you will be using this as follows:

    // assuming you have an Entity called Player
    if(Player.Collision.CollideAgainstMove(this.Collision, 0, 1))
    {
       // do your logic here
    }

## Setting the Level

Finally you'll need to set the level. As a test, you could add the following to CustomInitialize:

    SetLevelByName("Desert");

But this means that whenever you run the game, you'll always play the "Desert" level. Instead, you'll want to change the code so that it can select any level that you want. Instead, we'll need a way to change which level is loaded. The most common way to do this is to put something in GlobalData which defines which level to load. To do this, we'll first create a class called CurrentLevelInfo:

1.  Create a class called CurrentLevelInfo
2.  Give CurrentLevelInfo a public property with a getter and setter called LevelName. For example, it would look like:

&nbsp;

    public string LevelName
    {
       get;
       set;
    }

**What is GlobalData?** GlobalData is a way to store information at runtime which is not associated with a particular Screen or Entity, or which should exist despite Screens and Entities being destroyed. If you're unfamiliar with GlobalData, see [this page](/frb/docs/index.php?title=Glue:Tutorials:Proper_Information_Access#GlobalData.md "Glue:Tutorials:Proper Information Access").

Now let's add an instance of CurrentLevelInfo to GlobalData.cs

1.  Open (or create) GlobalData.cs
2.  Add a CurrentLevelInfo instance. It might look like this:

&nbsp;

    static CurrentLevelInfo mCurrentLevelInfo = new CurrentLevelInfo();
    public static CurrentLevelInfo CurrentLevelInfo
    {
       get { return mCurrentLevelInfo;}
    }

Once this is done, you will be able to set the next level to load as follows:

    GlobalData.CurrentLevelInfo.LevelName = "Desert";

You'd then want to have the following code in GamePlayScreen's CustomInitialize:

    SetLevelByName(GlobalData.CurrentLevelInfo.Levelname);

## Where does GlobalData.CurrentLevelInfo.LevelName get set?

The section above mentions to set the LevelName to "Desert". In a full game you may set this value in a number of places:

-   You may set it initially in your Game1.cs so that it has a starting value
-   You may set this value according to some value stored in data that you have saved to keep track of the player's progress in the game
-   You may set this according to UI pressed in another screen such as a level select screen

## Conclusion

Now that you have this system set up, adding new files is very easy. You simply have to add new .scnx and .shcx files (or whatever file types your game happens to use). Then modify the code that selects the level to play and your Screen will load that content.
