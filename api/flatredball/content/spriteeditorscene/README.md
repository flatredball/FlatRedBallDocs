# spriteeditorscene

### Introduction

A SpriteEditorScene is a "ready to save" or "just loaded" [Scene](../../../../../frb/docs/index.php). It is used to load a Scene from a .scnx file and it can be used to write .scnx files easily. The [FlatRedBallServices](../../../../../frb/docs/index.php) class internally uses the SpriteEditorScene class when you use it to load Scenes.

You will not need to use the SpriteEditorScene class in most cases because you can load .scnx files through the FlatRedBallServices.Load method as shown [here](../../../../../frb/docs/index.php#Loading\_a\_Scene\_From\_File).

### Loading a .scnx into a Scene

Using the SpriteEditorScene can give you additional information and control over how Scenes are created. In most cases you will want to use the [FlatRedBallServices' Load method](../../../../../frb/docs/index.php#Loading\_a\_Scene\_From\_File).

The following code shows how to load a .scnx file using the SpriteEditorScene instead of the FlatRedBallServices method:

Add the following using statement:

```
using FlatRedBall.Content;
```

Add the following to initialize after initializing FlatRedBall:

```
string fileName = "SplashScreen\SplashScreen.scnx";
string contentManagerName = "ContentManagerName";
SpriteEditorScene saveObject = SpriteEditorScene.FromFile(fileName);
Scene scene = saveObject.ToScene(contentManagerName );

scene.AddToManagers();
```

![SplashScreen.png](../../../../../media/migrated\_media-SplashScreen.png)

The **SpriteEditorScene**.FromFile method loads and returns an instance of a **SpriteEditorScene** which is loaded from the argument .scnx. This **SpriteEditorScene** is then converted to a Scene by calling the ToScene method. The ToScene method takes a [content manager](../../../../../frb/docs/index.php) name. For more information on content managers, see the [FlatRedBall content manager](../../../../../frb/docs/index.php) entry.

Next, the Scene adds all of its contained objects to the appropriate managers through the AddToManagers method. Prior to calling AddToManagers all objects referenced by the Scene are stored in memory but they are not managed or drawn.

### Loading a .scnx into a SpriteEditorScene

The example above which loads a .scnx into a Scene has the following compound line:

```
SpriteEditorScene.FromFile(fileName).ToScene(contentManagerName );
```

This could be broken up into:

```
SpriteEditorScene spriteEditorScene = SpriteEditorScene.FromFile(fileName);
Scene scene = spriteEditorScene.ToScene(contentManagerName);
```

The SpriteEditorScene is an "intermediary" type that is used to create a Scene; however there are situations where you may want to use the intermediary SpriteEditorScene in your game.

For example, consider a situation where you want to position Entities inside the SpriteEditor. Unfortunately the spriteEditor only supports the creation of .scnx files; however, you can load the .scnx into a SpriteEditorScene then instantiate Entities according to the position of Sprites in your .scnx. The following example shows what this code would look like assuming you have an Entity called Coin;

```
SpriteEditorScene spriteEditorScene = SpriteEditorScene.FromFile(fileName);
foreach(SpriteSave spriteSave in spriteEditorScene.SpriteList)
{
   Coin coin = new Coin(ContentManagerName);
   coin.X = spriteSave.X;
   coin.Y = spriteSave.Y;
   // perhaps you might add the Coin to a List here:
   CoinList.Add(coin);
}
```

For more information on the [SpriteSave](../../../../../frb/docs/index.php) class, see the [SpriteSave page](../../../../../frb/docs/index.php).

### Saving a .scnx

FlatRedBall provides code to save .scnx files from FlatRedBall applications. This allows the saving of .scnx files for custom scene building and debugging. Any .scnx file created with FlatRedBall will be loadable in the SpriteEditor.

To save a Scene, you must first create a SpriteEditorScene instance. You can create a SpriteEditorScene either from a [Scene](../../../../../frb/docs/index.php) instance, or by manually creating the objects.

The easiest way to save a .scnx file is to first create a Scene, then use the SpriteEditorScene's static FromScene method.

For example, the following code creates and saves a .scnx file.

```
// Assuming myScene is a valid Scene
SpriteEditorScene spriteEditorScene = SpriteEditorScene.FromScene(myScene);
spriteEditorScene.Save("fileName.scnx");
```

### Manually constructing a .scnx

If you would like more control over how your .scnx is created, you can manually construct SpriteEditorScenes to be saved. To do this:

* Instantiate a SpriteEditorScene
* Create "Save" objects which represent FlatRedBall objects ([Sprites](../../../../../frb/docs/index.php), [SpriteGrids](../../../../../frb/docs/index.php), [SpriteFrames](../../../../../frb/docs/index.php), [Texts](../../../../../frb/docs/index.php)) and set their properties and fields appropriately.
* Add the "Save" objects to the SpriteEditorScene.
* Save the SpriteEditorScene (which serializes it to an XML file).

#### Saving Sprites

The following code creates 20 [Sprites](../../../../../frb/docs/index.php) and saves them to a .scnx file.

Add the following using statement:

```
using FlatRedBall.Content.Scene;
```

In Initialize:

```
SpriteEditorScene spriteEditorScene = new SpriteEditorScene();

for (int i = 0; i < 20; i++)
{
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.X = -17 + i * 1.4f;
    sprite.Y = -10 + i;
    sprite.Z = -25 + i * 2;

    sprite.RotationZ = i / 10.0f;

    SpriteSave spriteSave = new SpriteSave();

    spriteSave.X = sprite.X;
    spriteSave.Y = sprite.Y;
    spriteSave.Z = sprite.Z;
    spriteSave.RotationZ = sprite.RotationZ;
    spriteSave.Texture = "redball.bmp";

    spriteEditorScene.SpriteList.Add(spriteSave);
}
spriteEditorScene.Save("fromCode.scnx");
```

First the SpriteEditorScene instance is created. Next 20 [Sprites](../../../../../frb/docs/index.php) are created. These [Sprites](../../../../../frb/docs/index.php) will both appear in the application when it runs as well as saved in the SpriteEditorScene. Next, each [Sprite](../../../../../frb/docs/index.php) is represented by a SpriteSave which has its properties set then is added to the SpriteEditorScene.

Once all [Sprites](../../../../../frb/docs/index.php) have been created the Scene is saved to a .scnx file. Be sure to use a .scnx extension so the SpriteEditor recognizes this file as a valid scene.

Executing the code:![SpritesInCode.png](../../../../../media/migrated\_media-SpritesInCode.png)

.scnx loaded in the SpriteEditor:![FromCodeToSpriteEditor.png](../../../../../media/migrated\_media-FromCodeToSpriteEditor.png)

#### Saving SpriteGrids

The following code creates a [SpriteGrid](../../../../../frb/docs/index.php) with a different Texture2D displayed by the center [Sprite](../../../../../frb/docs/index.php).

Add the following using statements:

```
using FlatRedBall.Content.Scene;
using FlatRedBall.Content.SpriteGrid;
```

In Initialize:

```
 SpriteEditorScene spriteEditorScene = new SpriteEditorScene();

 Sprite blueprint = new Sprite();
 blueprint.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", "Global");
 SpriteGrid spriteGrid = new SpriteGrid(SpriteManager.Camera, SpriteGrid.Plane.XY, blueprint);

 spriteGrid.XLeftBound = -10;
 spriteGrid.XRightBound = 10;
 spriteGrid.YTopBound = 10;
 spriteGrid.YBottomBound = -10;

 spriteGrid.PaintSprite(0, 0, 0,
     FlatRedBallServices.Load<Texture2D>(@"Assets\Scenes\frblogo.png"));

 spriteGrid.PopulateGrid();

 SpriteGridSave spriteGridSave = SpriteGridSave.FromSpriteGrid(spriteGrid);

 spriteEditorScene.SpriteGridList.Add(spriteGridSave);

 spriteEditorScene.Save("spriteGridFromCode.scnx");
```

Executing the code:![SpriteGridCreatedInCode.png](../../../../../media/migrated\_media-SpriteGridCreatedInCode.png)

.scnx loaded in the SpriteEditor:![SpriteGridFromCodeInSpriteEditor.png](../../../../../media/migrated\_media-SpriteGridFromCodeInSpriteEditor.png)

### SpriteEditorScene Members

* [FlatRedBall.Content.SpriteEditorScene.Camera](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
