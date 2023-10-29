# glue-reference-globalcontent

### Introduction

GlobalContent is a category of content which is available anywhere in your project as opposed to being tied to a specific Screen or Entity. All content that is added as GlobalContent is available at all times. Globalcontent doesn't have a lifespan tied to any ContentManager - normally content is loaded and tied to a ContentManager associated with the active Screen which is unloaded when the current Screen is Destroyed. Content can also be globally loaded if an Entity's [UseGlobalContent](../../../../frb/docs/index.php) property is true. For information on this property and also on how it interacts with GlobalContent, see [this page](../../../../frb/docs/index.php).

### Using Global Content

Adding GlobalContent to your game is the same as adding content to any Screen or Entity. To do this:

1. Right-click on "Global Content Files" in Glue
2. Select "Add File"->"New file"![AddNewFileGlobalContent.png](../../../../media/migrated\_media-AddNewFileGlobalContent.png)
3. Enter the type and name just like a regular file
4. Repeat this for as many files as you'd like![FilesInGlobalContentFiles.png](../../../../media/migrated\_media-FilesInGlobalContentFiles.png)

### Accessing Global Content Files

Once a file has been added to the "Global Content Files" tree item, it can be accessed anywhere in code at any time after GlobalContent has been initialized. To do this, simply use the same name as the file name after "GlobalContent."![GlobalContentIntellisense.png](../../../../media/migrated\_media-GlobalContentIntellisense.png)

### When to use Global Content Files

Global Content Files are usually used:

* For data that is needed across multiple Screens, like [a localization database](../../../../frb/docs/index.php).
* For data that is not tied to any particular Screen or Entity.

### Async content loading

The GlobalContent object may take a while to load depending on your game. This can both be inconvenient for players and it can also cause to fail meeting requirements for certain platforms - for example something must render to the screen within 5 seconds of a game's launch on Windows Phone 7. Fortunately you can make GlobalContent load asynchronously. To do this:

* Select the "Global Content Files" tree node
* Change the "LoadAsynchronously" property to "True"![LoadGlobalContentAsync.png](../../../../media/migrated\_media-LoadGlobalContentAsync.png)

That's all you need to do - your GlobalContent will now load asynchronously.

### The problem of lock contention

"Lock contention" occurs when one thread has to sit and wait because another thread has locked a piece of code. This can commonly occur when dealing with async GlobalContent Initialization. Let's look at why this is the case. Imagine a situation where you have 10 CSV files, each representing a level in your game. You've decided to put them in "Global Content Files". You've also decided to put a click sound effect in your game for when the user clicks on a button. For this example we'll say that the Click sound effect will get loaded **after** the 10 level CSV files. To help the example, we'll also say that the CSV files take a long time to load, and that the first Screen contains a button that the user must click on to proceed. It is possible for the user to click on the button before the level CSVs are loaded. Of course, this would mean that the click sound effect must play; however, since it's loaded after the level CSVs, it won't be ready to play. So what happens in this case? The generated code for GlobalContent recognizes that you are trying to access a property (specifically the click sound effect) which hasn't been loaded yet. But since this content will be loaded, the primary thread waits for the sound to be loaded before playing it. Of course, this means your entire game will appear to freeze until the sound is loaded. This may not be an issue at all depending on how quickly your content loads and depending on how quickly the user can get to the button to click; however, when dealing with very large projects you may have dozens of files under Global Content, and if you encounter a data contention, this can make your application appear to stall. The worst case would be a situation where you are trying to access the very last-loaded property in a starting Screen. This may result in a contention that freezes your application as long as it would freeze if you didn't even use async loading. Fortunately, Glue can generate code to help you solve this.

### RecordLockContention

The RecordLockContention property can be very useful on larger projects when you are trying to improve load times by eliminating lock contention. To use this to improve load times:

1. Select the "Global Content Files" tree node
2. Change "RecordLockContention" to "True" (make sure "LoadAsynchronously" is also set to "True")![RecordLockContention.png](../../../../media/migrated\_media-RecordLockContention.png)
3. Open your GlobalContent.Generated.cs file in Visual Studio
4. Scroll to the very bottom where the Intialize method ends and place a breakpoint on the last line of AsyncInitialize which should be "IsInitialized = true;"![AddBreakpoint.png](../../../../media/migrated\_media-AddBreakpoint.png)
5. Run your game
6. Once you hit the breakpoint, add "LockRecord" to your watch window![NoLocks.png](../../../../media/migrated\_media-NoLocks.png)

If you notice that it has a count of 0, then congratulations - you are not experiencing any lock contention in your Global Content's initialization. You can easily create a locking case if you'd like to see the result and how to resolve it. To do this, simply access the very last property in GlobalContent right after the GlobalContent.Initialize call in your Game class: ![ShapeCollectionForLock.png](../../../../media/migrated\_media-ShapeCollectionForLock.png) In this case the file "ShapeCollectionFile" is the last property listed under GlobalContent. It is likely that accessing it immediately after the Initialize call will result in a lock contention. Running the game now verifies this: ![LockedThreadCause.png](../../../../media/migrated\_media-LockedThreadCause.png) This case was fabricated, and as a result rather trivial; however, if you have multiple locks, this approach can help you reorganize your global content to improve load times. Speaking of reorganizing, keep reading to see how to do this.

### Controlling GlobalContent load order

Once you've identified lock contentions, you can easily reorder your content to help eliminate - or at least reduce - lock contentions. To do this:

1. Right-click on the "Global Content Files" tree item
2. Select "View File Order"![ViewFileOrderRightClick.png](../../../../media/migrated\_media-ViewFileOrderRightClick.png)
3. A window will appear listing all of the files in "Global Content Files". This window shows the current order of content loading.![GlobalContentFileOrder.png](../../../../media/migrated\_media-GlobalContentFileOrder.png)
4. Right-click and select one of the movement options, or click+drag to reorder the content files.

### Iterating on content order

Depending on the order of your content, you may find that you have a particular file causing data contention. For example, the very last file in "Global Content Files" may be needed early in your game, and this could cause a very long lock contention. Once you resolve this by moving it to the top (so it is loaded first), you may actually see **more, not fewer** lock contentions. Don't worry, the important thing is not the number of contentions, but the amount of time spent in them. As you reorganize and run your code, you may find different contentions. Keep the following in mind:

* Keep running, changing, and re-running your game to minimize the amount of time spent in contentions
* You may not be able to eliminate contentions completely, but you can definitely reduce them. For example, if you have a contention on the very first file in your "Global Content Files", then there's probably nothing else you can do - it's just that the file is needed before it's finished loading.
* Check for contentions from time to time throughout development. As you add more content to Global Content Files you may create a new lock contention that didn't exist before.
