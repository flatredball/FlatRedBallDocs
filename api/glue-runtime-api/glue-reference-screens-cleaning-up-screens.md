# Cleaning Up Screens

### Introduction

This error can occur if your current Screen is destroyed without cleaning up after itself. More specifically this means that objects were added to the FlatRedBall managers during the Screen's life but were not removed prior to or during the Screen's Destroy method. The error that you see will tell you which member to look at for clues as to which objects are still in the engine. ![ItemsNotCleanedUp.png](../../.gitbook/assets/migrated\_media-ItemsNotCleanedUp.png)

### Identifying what is in the lists

The error that is shown above identifies which lists contain objects which have not been cleaned up. To see what is contained in the lists:

1. Run the game and have the crash occur so the dialog shows.
2. Open a Watch window by selecting "Debug"->"Windows"->"Watch"->"Watch 1"![WatchWindowMenuStrip.png](../../.gitbook/assets/migrated\_media-WatchWindowMenuStrip.png)
3. Copy and paste the name of the list or lists that appear in the exception dialog. For example FlatRedBall.SpriteManager.AutomaticallyUpdatedSprites
4. Expand the list to see which items are in the list ![WatchWindow.png](../../.gitbook/assets/migrated\_media-WatchWindow.png)

Once you've identified the objects that aren't being cleaned up, you will need to remove them from their respective managers, or call Destroy on the container Entities.

### Finding Objects to Clean

Once you have obtained the list of objects which are still being held by the manager, you need to track where the objects are being created. Often, the objects are being created through an entity in custom code. For example, consider the following watch window that displays a Sprite still in the engine at the time of Screen transition:

![](../../.gitbook/assets/2017-03-img\_58b6e2d1f1344.png)

If your watch window indicates that you have multiple objects which need to be cleaned up, you can focus on the first one by adding \[0] to the property being investigated.

![](../../.gitbook/assets/2017-03-img\_58b6e3477ada4.png)

If your game is experiencing this problem due to entities which haven't been cleaned up, the FlatRedBall.SpriteManager.ManagedPositionedObjects list will tell you which type of entity needs to be cleaned up. For example the following image shows that an instance of Entity1 needs to be destroyed:

![](../../.gitbook/assets/2017-03-img\_58b6e3ddac230.png)
