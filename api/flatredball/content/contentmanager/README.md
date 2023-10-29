# contentmanager

### Introduction

Content managers provide functionality for organizing and caching game assets. They can be thought of as a "bucket of assets". When you create an asset through the Content Manager, you give it a name (usually its file name) and decide which Content Manager it goes into. Later if the same name appears, the FlatRedBall Engine will return a reference to that asset instead of loading it from disk. Although MonoGame has a content manager class by the qualified name of Microsoft.Xna.Framework.Content.ContentManager, you do not have to ever explicitly interact with this class when using FlatRedBall. Instead, you simply work with content managers through the [FlatRedBallServices](../../../../../frb/docs/index.php) class.

### Content Manager and the FlatRedBallEditor

If you are using the FlatRedBall Editor, you may not have to directly interact with the ContentManager object. For example, if you add a .png file to the FlatRedBall Editor, it will automatically load the file in generated code using the ContentManager. However, if you would like to work with content in code, or if your game requires advanced handling of content then you may need to work with the ContentManager in custom code.

### What is "caching"?

Computer memory can exist in a variety of locations: On the hard disk, in RAM, or even on the hard disks of other computers which you can access through the Internet (as you are currently doing when viewing this page). Not all types of memory can be accessed with the same speeds. Getting data through the Internet is very slow compared to data that is sitting on your local hard disk, and accessing data on the hard disk is much slower than accessing data in RAM. When the same data needs to be accessed multiple times, making a copy of it and moving it to faster memory can help improve performance. Content such as Textures and Models are copied from the hard disk to RAM to speed up future access to this memory - as well as to prevent duplicate memory in RAM.

### What is a Content Manager?

Content managers simplify the loading of new assets as well as help organize existing assets. Content managers in FlatRedBall store references to a variety of assets. The most common type of reference held by content managers is of type Texture2D. Any FlatRedBall method which can potentially load a Texture2D works with FlatRedBall's internal content managers. Content managers are also useful for organizing data. Any data which has the same lifespan - such as textures, geometry, and sound files in a given level - should belong to the same content manager. When the level ends, simply removing that content manager unloads all memory associated with the level. Content managers make memory management and game state changes much easier.

### Using Content Managers

If you have programed a FlatRedBall application which displays a texture (such as the red ball texture on a [Sprite](../../../../../frb/docs/index.php)) then you have worked with content managers - although you may not realize it. Any method which takes a string file name for a Texture2D also takes a string for a content manager name. Some methods have overloads which do not require a content manager string argument, but those simply use the default "Global" content manager. You may be familiar with the [SpriteManager's](../../../../../frb/docs/index.php) AddSprite method:

```
Sprite someSprite = SpriteManager.AddSprite("redball.bmp");
```

This method has an overload which allows the content manager to be specified. Calling the one-argument version is the same as passing "Global" as the second argument:

```
Sprite someSprite = SpriteManager.AddSprite("redball.bmp", "Global");
```

The Global content manager is used by default by all methods which load Texture2D's when a content manager is not explicitly supplied in the argument list. To specify a different content manager, simply provide the string of the new name - there is no need to instantiate any instances as this is all handled internally. Loading the same asset using the same content manager does not result in multiple copies of the asset in memory and the hard disk is only accessed once. The following code creates only one copy of the redball.bmp texture in memory.

```
SpriteManager.AddSprite("redball.bmp"); // in Global by default
SpriteManager.AddSprite("redball.bmp", "Global");
FlatRedBallServices.Load<Texture2D>("redball.bmp", "Global");
```

While the following creates three separate copies of the redball.bmp texture and also the hard disk is accessed three times:

```
SpriteManager.AddSprite("redball.bmp", "Some Content Manager");
SpriteManager.AddSprite("redball.bmp", "Other Content Manager");
SpriteManager.AddSprite("redball.bmp", "other content manager"); // case sensitive!
```

Or another way to look at it is:

```
Texture2D firstTexture = SpriteManager.AddSprite("redball.bmp", "Some Content Manager");
Texture2D secondTexture = SpriteManager.AddSprite("redball.bmp", "Other Content Manager");
Texture2D thirdTexture = SpriteManager.AddSprite("redball.bmp", "other content manager"); // case sensitive!

if(firstTexture == secondTexture)
{
   // This won't get hit
}

if(secondTexture == thirdTexture)
{
   // This also won't get hit.
}
```

### Content Manager Code Sample

The following code simulates the creation and destruction of 3 levels. Levels can be loaded and unloaded by pressing the 1, 2, and 3 keys. The text object which is created displays the loaded content and the Sprites themselves display the loaded Sprites.

```
 // Add this using statement:
 using FlatRedBall.Graphics;

 // in class scope
 Text debugText;

 bool[] mLevelLoaded;
 SpriteList mLevel1Sprites;
 SpriteList mLevel2Sprites;
 SpriteList mLevel3Sprites;

 // replace Initialize with this:
 protected override void Initialize()
 {
     FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

     base.Initialize();

     debugText = TextManager.AddText("");
     debugText.Y = 13;
     debugText.X = -16;
     debugText.Scale = debugText.Spacing = .5f;

     mLevelLoaded = new bool[3];

     mLevelLoaded[0] = false;
     mLevelLoaded[1] = false;
     mLevelLoaded[2] = false;

     mLevel1Sprites = new SpriteList();
     mLevel2Sprites = new SpriteList();
     mLevel3Sprites = new SpriteList();

 }

 // replace Update with the following:
 protected override void Update(GameTime gameTime)
 {
     FlatRedBallServices.Update(gameTime);

     if(InputManager.Keyboard.KeyPushed(Keys.D1))
     {
         if(mLevelLoaded[0] == false)
         {
             Sprite sprite = SpriteManager.AddSprite("redball.bmp", "Level1");
             sprite.X = 5;
             mLevel1Sprites.Add(sprite);
             
             mLevelLoaded[0] = true;
         }
         else
         {
             mLevelLoaded[0] = false;
             FlatRedBallServices.Unload("Level1");
             SpriteManager.RemoveSpriteList(mLevel1Sprites);
         }
     }
     else if(InputManager.Keyboard.KeyPushed(Keys.D2))
     {
         if(mLevelLoaded[1] == false)
         {
             Sprite sprite = SpriteManager.AddSprite("redball.bmp", "Level2");
             sprite.X = 1;
             mLevel2Sprites.Add(sprite);

             sprite = SpriteManager.AddSprite("redball.bmp", "Level2");
             sprite.Y = 5;
             sprite.X = -2;
             mLevel2Sprites.Add(sprite);
             
             mLevelLoaded[1] = true;
         }
         else
         {
             mLevelLoaded[1] = false;
             FlatRedBallServices.Unload("Level2");
             SpriteManager.RemoveSpriteList(mLevel2Sprites);
         }
     }
     else if(InputManager.Keyboard.KeyPushed(Keys.D3))
     {
         if(mLevelLoaded[2] == false)
         {
             Sprite sprite = SpriteManager.AddSprite("redball.bmp", "Level3");
             sprite.X = -3;
             mLevel3Sprites.Add(sprite);
             
             sprite = SpriteManager.AddSprite("redball.bmp", "Level3");
             sprite.Y = 2;
             sprite.X = 4;
             mLevel3Sprites.Add(sprite);

             sprite = SpriteManager.AddSprite("redball.bmp", "Level3");
             sprite.Y = 6;
             sprite.X = -4;
             mLevel3Sprites.Add(sprite);

             mLevelLoaded[2] = true;
         }
         else
         {
             mLevelLoaded[2] = false;
             FlatRedBallServices.Unload("Level3");
             SpriteManager.RemoveSpriteList(mLevel3Sprites);
         }
     }

     debugText.DisplayText = FlatRedBallServices.GetContentManagerInformation();

     base.Update(gameTime);
 }
```

[Full Source](http://pastebin.ca/498688) ![SpritesAndDifferentContentManagers.png](../../../../../media/migrated\_media-SpritesAndDifferentContentManagers.png)

### Which content manager should I use?

Even if you understand the concept that content managers can be thought of as a "bucket of asset", you may be wondering which content manager to put assets in. The following lists a few conditions to help you decide.

* **Is your content going to live forever?** You may be creating a game with a particular object (such as a [Texture2D](../../../../../frb/docs/index.php) or a second [Camera](../../../../../frb/docs/index.php)) that you never want to unload. If this is the case, then you may want to use the global content manager. You can use the FlatRedBallServices.GlobalContentManager property as the value passed to any method that accepts a content manager.
* **Are you just debugging?** If you are writing code that will not ship with the final game, or if you're just testing something out, then it really doesn't matter what you use. Passing any string will create a new content manager to store the asset. Of course, creating content managers without paying attention to their names can create a buildup of assets if content managers are not cleaned up properly.
* **Are you using** [**Screens**](../../../../../frb/docs/index.php)**?** The base [Screen](../../../../../frb/docs/index.php) class defines a property called ContentManagerName. If the object that you're creating should be destroyed when the [Screen](../../../../../frb/docs/index.php) is destroyed, then you should use the Screen's ContentManagerName.
* **Are you creating an object which will be destroyed at some time in the future?** If you are not using [Screens](../../../../../frb/docs/index.php) but still want to perform your own content management (and destruction) then you should place your object in the same content manager as other objects which will be destroyed at the same time. Of course, we encourage the use of [Screens](../../../../../frb/docs/index.php) as they have been created for this reason and they simplify the management of assets.

### Additional Information

* [Texture caching example](../../../../../frb/docs/index.php#Texture\_Caching) - Shows an example of how Content Managers cache content.
* [FlatRedBall.FlatRedBallServices.AddDisposable](../../../../../frb/docs/index.php) - AddDisposable can be used to add IDisposables to Content Managers.
* [FlatRedBall Content Manager:Multiple Content Managers](../../../../../frb/docs/index.php) - Discusses the purpose of having multiple content managers.
