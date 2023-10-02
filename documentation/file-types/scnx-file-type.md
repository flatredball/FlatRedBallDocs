# scnx-file-type

### Introduction

A Scene is simply a collection of different types of objects which can be added as a group. Usually scene creation begins in a tool like the [SpriteEditor](../../frb/docs/index.php) or TileEditor. The default file type of a scene is .scnx. These are XML files which describe a scene. These scene files can be loaded by FlatRedBall XNA applications either through the content pipeline or directly from file. Scenes can include the following objects:

* [Sprites](../../frb/docs/index.php) of type [SpriteList](../../frb/docs/index.php)
* [SpriteFrames](../../frb/docs/index.php)
* [SpriteGrids](../../frb/docs/index.php)
* [Texts](../../frb/docs/index.php)
* [PositionedModels](../../frb/docs/index.php)

### File Placement

For information on file placement when loading from file, see the [Managing Files tutorial](../../frb/docs/index.php).

### Loading a Scene From File

You can load a Scene just like any other file (such as a .png) though the FlatRedBallServices class: Files Used: [SplashScreen.zip](../../frb/docs/images/2/2e/SplashScreen.zip)

```
 string fileName = "SplashScreen\SplashScreen.scnx";
 string contentManagerName = "SomeContentManagerName"; // use the Screen's ContentManager if in a Screen
 Scene scene = FlatRedBallServices.Load<Scene>(fileName, contentManagerName );

 scene.AddToManagers();
```

![SplashScreen.png](../../media/migrated\_media-SplashScreen.png) The Scene adds all of its contained objects to the appropriate managers through the AddToManagers method. Prior to calling AddToManagers all objects referenced by the Scene are stored in memory but they are not managed or drawn. Notice that the last line calls the Clear method. The reason for this is because Scenes holds most referenced instances in [AttachableLists](../../frb/docs/index.php) which have two way relationships. If the reference to the scene object is lost but it is not cleared, all referenced [IAttachables](../../frb/docs/index.php) will continue to reference all [AttachableLists](../../frb/docs/index.php) held in the Scene. While this is not a critical problem, it can increase memory use slightly and reduce the speed of the garbage collector. For more information on two-way relationships and an explanation on why [AttachableLists](../../frb/docs/index.php) must be cleared, see the [AttachableList entry](../../frb/docs/index.php). Calling the Clear method **will not remove all objects from the engine**, so you can call this after adding eveything to the engine with the AddToManagers call.

**Note:** For more information on how to add files to Visual Studio and how to control how they are built, see the ["adding files to your project" page](../../frb/docs/index.php).

#### Using the Content Pipeline

For information on loading Scenes through the content pipeline, see the [Using the FlatRedBall XNA Content Pipeline](../../frb/docs/index.php) wiki entry.

### Scenes and PositionedModels

The Scene class can contain references to PositionedModels. To load a .scnx that includes model references (.x or .fbx) the .scnx must be loaded through the [Content Pipeline](../../frb/docs/index.php) instead of from-file.

### Removing a Scene

Previously removal was done through the [SpriteManager](../../frb/docs/index.php) As of September 2007 Scenes can remove all contained items from the engine by calling RemoveFromManagers. The following code would remove all items contained in myScene:

```
myScene.RemoveFromManagers();
```

### Saving a Scene

See the [Saving a .scnx wiki entry](../../frb/docs/index.php#Saving\_a\_.scnx).

### Getting References to Objects Inside Scenes

After creating a Scene in the SpriteEditor, a common task is to store some of the objects contained in the Scene as class-level instances for easy access. For example, a Scene may contain a [Text object](../../frb/docs/index.php) which will needs to be modified to display the player's score as he earns points. Or perhaps a Scene contains a [Sprite](../../frb/docs/index.php) which represents a door that the player must touch to move to the next level. To retrieve references to objects in a Scene in code, the FindByName method can be used. The FindByName method as a method in the list properties of the Scene. The following code shows examples of how to get a reference to various objects in the Scene:

```
// Assumes that mScene is a valid Scene
Sprite doorSprite = mScene.Sprites.FindByName("Door");
SpriteFrame button = mScene.SpriteFrames.FindByName("Button");
Text scoreText = mScene.Texts.FindByName("Score");
```

Of course, the Scene must contain objects with the same name as what is passed in the FindByName method. These names will be set in the SpriteEditor.

### Scene Members

* [FlatRedBall.Scene.AddToManagers](../../frb/docs/index.php)
* [FlatRedBall.Scene.ConvertToManuallyUpdated](../../frb/docs/index.php)
* [FlatRedBall.Scene.MakeOneWay](../../frb/docs/index.php)
* [FlatRedBall.Scene.ManageAll](../../frb/docs/index.php)
* [FlatRedBall.Scene.ManualDeserialization](../../frb/docs/index.php)
* [FlatRedBall.Scene.RemoveFromManagers](../../frb/docs/index.php)
* [FlatRedBall.Scene.ScalePositionsAndScales](../../frb/docs/index.php)
* [FlatRedBall.Scene.Shift](../../frb/docs/index.php)
* [FlatRedBall.Scene.Sprites](../../frb/docs/index.php)

### Related Information

* [FlatRedBall.Content.SpriteEditorScene](../../frb/docs/index.php) - Provides the ability to convert Scenes to .scnx files as well as to to manually load .scnx files.
* [Setting the Camera to match the SpriteEditor](../../frb/docs/index.php) - Discusses how you can make Scenes in your game work exactly like they do in the SpriteEditor.

Did this article leave any questions unanswered? Post any question in our [forums](../../frb/forum.md) for a rapid response.
