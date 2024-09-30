# CustomLoadStaticContent

### Introduction

CustomLoadStaticContent is a code that is part of the default generated code file for every Screen and Entity created by Glue. CustomLoadStaticContent is called once when a Screen is first instantiated, and once for every Entity type when it is instantiated in a Screen. This method is called per Entity if it hasn't been called for that entity ever, or if the content manager that was used when it was called last has since been unloaded.

### Why does CustomLoadStaticContent matter?

If you have been writing a game and have not been using CustomLoadStaticContent, then you may be wondering why this function exists. Before getting into the details of CustomLoadStaticContent, let's mention that **games are not required to use CustomLoadStaticContent**. You can create virtually any type of game and it will work without using CustomLoadStaticContent (this is not true of the other three methods in a Screen/Entity: CustomInitialize, CustomActivity, and CustomDestroy). However, the value of CustomLoadStaticContent is that it can run on a second thread, asynchronously. Because of this characteristic, you can perform actions (usually content loading from disk) during loading screens. Therefore, CustomLoadStaticContent isn't required, but it is often useful for making your game transition between Screens without appearing to freeze.

### Lazy Loaded vs. Pre-loaded

To understand the difference between content that is "lazy loaded" vs. content that is "pre-loaded" we'll use an example: the mushroom object in Super Mario Bros.&#x20;

&#x20;

<figure><img src="../../.gitbook/assets/migrated_media-SuperMarioBros.png" alt=""><figcaption></figcaption></figure>

If Super Mario Bros. were created in Glue, then the Glue project would probably have a Mushroom Entity. The Mushroom Entity would contain either a .scnx file for the Mushroom Sprite, or simply a .png that would be applied to the Mushroom Sprite. In either case, the Mushroom object would have some content that it would need to load from disk. Of course, in Super Mario Bros. the mushroom graphic is very small, but for this example we'll pretend that loading the content for the Mushroom Entity takes some significant amount of time. Conceptually speaking, there are two possible times when the files for the Mushroom Entity can be loaded:

1. When the Screen is first created (this is called pre-loading)
2. When the Mushroom is actually created - probably when Mario jumps and hits the block that makes the mushroom appear (this is called lazy loading)

When referring to FRB content, lazy loading refers to the fact that the content isn't loaded until the time when it is needed. When content is pre-loaded, it will be loaded on a secondary thread, so if you are using loading screens, you will not notice a freeze in frame rate. However, if your content is lazy loaded, then you will likely notice a jump in frame rate. The purpose of CustomLoadStaticContent is to perform pre-loading on content that would normally be lazy loaded.

### Automatic loading of content

Glue will automatically pre-load content that is added to a Screen (unless it is marked as LoadedOnlyWhenReferenced), so in most cases you will not need to use this method. The CustomLoadStaticContent can be useful in situations where Glue does not know if it should load Content, or if the content that should be loaded initially is not loaded until later because Glue does not know if the content is used.

### Example 1: Entities instantiated in custom code

Glue will automatically load static content for Entities which are added as instances to a Screen (or another Entity). For example, consider a situation where you have created a Screen called GameScreen and an Entity called Player. If you add an instance of the Player Entity in the GameScreen through the Glue UI, Glue will recognize that it should load static content on the Player class. But instead let's say you add an instance of Player to your custom code as follows:

```
Player mPlayer;
private void CustomInitialize()
{
   mPlayer = new Player(ContentManagerName);
}
```

In this case, Glue won't know that you are creating a Player instance when it generates code - it doesn't read your custom code when creating generated code. Therefore, it doesn't know that it should load the static content for Player. Therefore, when the Player is instantiated in CustomInitialize (or any place in custom code) the game frame rate may jump slightly. If you are using async loading screens, then the player will no get loaded in the loading screen. This can cause pops or even cause your game to freeze for extended periods of time depending on how much content is being loaded. You can solve this by loading the Player's static content in CustomLoadStaticContent:

```
private static void CustomLoadStaticContent(string contentManagerName)
{
   // Use "Player" instead of "mPlayer" because LoadStaticContent is a static method so it's
   // accessed through the type name.
   Player.LoadStaticContent(contentManagerName);
}
```

### Example 2: Lists of Entities

Let's say you have an Entity called Enemy and you add a PositionedObjectList\<Enemy> to your GameScreen. In this situation you may intend to populate this list by code or CSV or some other method; however, unless instances are explicitly added to this PositionedObjectList in the Glue UI, Glue doesn't know if you will ever actually instantiate any Enemies or not. Therefore, to save memory Glue will not load the Enemy's static content automatically. Of course this isn't terrible behavior: If you never instantiate an Enemy then you have saved that memory, and if you do then the first Enemy instance that is created will lazy load. You may not notice this at all if the first instance is created in the Screen's CustomInitialize code, or if it is created after but the load time is very quick. Of course as hinted above, there are two problems:

1. You may instantiate the first enemy some time after the game begins playing, and the load call may cause a frame rate jump in the game, or even freeze the game for a considerable amount of time depending on how long the content load takes.
2. Even if you instantiate in CustomInitialize, CustomInitialize is called on the primary thread meaning if you are loading your Screen asynchronously, the loading of the Enemy content will not be done on the secondary thread - this may make your loading Screen appear to freeze.

These issues can easily be fixed by simply calling LoadStaticContent on the Enemy type as follows: private static void CustomLoadStaticContent(string contentManagerName) {

```
// Inside GameScreen's CustomLoadStaticContent method
Enemy.LoadStaticContent(contentManagerName);
```

} That's all there is to it! Doing this will:

1. Load the Enemy's content when the GameScreen is first instantiated.
2. Load the Enemy's content asynchronously, which means it will load during your Load sceen if you are using one.
3. Not result in a double-load of the Enemy's content. The Enemy code is smart enough to recognize that the Enemy's content has already been loaded in custom code, so it will not load it again when you instantiate an Enemy.

#### Optionally loading content

You may be working on a game where content is optionally loaded. Keep in mind that CustomLoadStaticContent is a static method, so you will not have access to the Screen's instance members in this method. However, if you have information that is available globally (such as in GlobalData) you can access it here to perform custom loading. For example, you may know that you will only use the "Orc" class in the OrcLevel and the "Troll" class in the TrollLevel. Therefore you could write code in your GameScreen's CustomLoadStaticContent as follows:

```
if(GlobalData.CurrentLevel.LevelType == LevelType.OrcLevel)
{
   Orc.LoadStaticContent(contentManagerName);
}
else if(GlobalData.CurrentLevel.LevelType == LevelType.TrollLevel)
{
   Troll.LoadStaticContent(contentManagerName);
}
```

### Example 3: Optionally Loaded Content

Glue supports optionally loaded content through the use of the LoadedOnlyWhenReferenced property. This property indicates that a particular piece of content should create a getter property, and the content should be loaded the first time the getter is accessed. This feature is often used when creating Entities which may use any number of pieces of content. For example, a racing game may have a large number of pieces of content (ultimately stored in .scnx files). Your game's load times may be extremely long and you may even run out of memory if you load all content that **may** be referenced by your Car Entity. LoadedOnlyWhenReferenced can eliminate this problem. However, using LoadedOnlyWhenReferenced means that Glue will not automatically load content which is LoadedOnlyWhenReferenced. Of course, you can force content to be loaded simply by accessing the property of your content. To continue the example above, let's say that your Car Entity has three .scnx files which are LoadedOnlyWhenReferenced. The names for these three are:

* FordMustangScene
* ChevyCamaroScene
* HyundaiGenesisScene

We'll also assume that you have a PlayerSave instance in GlobalContent which indicates which Scene to load, as follows. In this case you would have enough information to pre-load the given Car that is needed as follows:

```
// In your screen's CustomLoadStaticContent:
Car.CustomLoadStaticContent(contentManagerName); // this tells Car which content manager name to use in subsequent loads
Scene throwawayScene = null;
switch(GlobalData.CurrentPlayerSave.CarType)
{
   case CarType.FordMustang:
       throwAwayScene = Car.FordMustangScene;
       break;
   case CarType.ChevyCamaro:
       throwAwayScene = Car.ChevyCamaroScene;
       break;
   case CarType.HyundaiGenesis:
       throwAwayScene = Car.HyundaiGenesis;
       break;
}
```

Notice that there is no need to keep track of the throwAwayScene - simply using the getter will load the content so that when the Car instantiates itself later, the content it needs will already be loaded.

### Example 4: Instantiate without adding to managers

Some objects may take some time to instantiate, but not because they load files but rather because they require significant up-front processing. The CustomLoadStaticContent method can be used to do this on a secondary thread. However there are a few requirements which must be met for this to be possible:

* The instance must be added as a static object to the Screen
* The instance must be of a type that can be instantiated without being added to any FRB managers
* The instance should be nulled-out when the containing Screen is destroyed. It is possible to do this with Entities, but it's more complicated so we'll focus on Screens for this example.

If you are instantiating an Entity, then the 2nd requirement (instantiation without adding to managers) will be met for you automatically. If you have constructed your own object, then you should consider having separate Initialize and AddToManagers methods. We'll assume that the object being added is of type LargeEntityObject. To instantiate this in CustomLoadStaticcontent:

1.  Add the following to the Screen's custom code class:

    ```
    static LargeEntityObject mLargeEntityObjectInstance;
    ```
2.  Add the following to the Screen's CustomLoadStaticContent (2nd argument specifies whether to add to managers):

    ```
    mLargeEntityObjectInstance = new LargeEntityObjectInstance(contentManagerName, false);
    ```
3.  Add the following to the Screen's CustomInitialize (argument specifies the Layer):

    ```
    mLargeEntityObjectInstance.AddToManagers(null);
    ```
4.  Add the following to the Screen's CustomDestroy:

    ```
    mLargeEntityObjectInstance.Destroy();
    mLargeEntityObjectInstance = null;
    ```
