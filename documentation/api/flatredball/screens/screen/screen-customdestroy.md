# screen-customdestroy

### Introduction

The CustomDestroy (if using Glue) and Destroy (if not using Glue) methods are called when the Screen is going to be removed from your game. This method should never be manually called - the ScreenManager will call this after the Screen's [IsActivityFinished](../../../../../frb/docs/index.php) property is set to true. The purpose of the CustomDestroy/Destroy methods is to remove objects which have been manually added to your Screen. In general, any object which has been added to a FlatRedBall manager must be removed. Entities (which automatically add themselves) must be destroyed.

### Code Example

The following example shows how a [Sprite](../../../../../frb/docs/index.php) and [Entity](../../../../../frb/docs/index.php) can be created and destroyed properly. This uses the Glue custom methods, but the idea is the same. The following are added at your Screen's class scope:

```
Sprite mMySprite;
MyEntityType mMyEntityInstance;
```

The following would be contained in CustomInitialize:

```
mMySprite = SpriteManager.AddSprite("redball.bmp", ContentManagerName);
mMyEntityInstance = new MyEntityType(ContentManagerName);
```

The following would be contained in CustomDestroy:

```
SpriteManager.RemoveSprite(mMySprite);
mMyEntityInstance.Destroy();
```

### For Glue Users

Keep in mind that only objects which are instantiated or added in your custom code need to be destroyed in the CustomDestroy method. In other words, if you make an instance of an [Entity](../../../../../frb/docs/index.php) in a Screen under the Objects item, you do not need to call Destroy on this object. Glue will both instantiate and destroy it automatically.
