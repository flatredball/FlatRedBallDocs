# flatredballxna-tutorials-instantiating-loading-and-adding

### Introduction

If you are familiar with FlatRedBall then you have likely worked with the various managers (such as the [SpriteManager](../frb/docs/index.php)) to create FlatRedBall objects. The managers are designed to do most of the work behind the scenes and provide a simplified interface. In certain situations, however, it is important to understand what the manager is doing when its methods are called - specifically the "Add" methods. Dissecting the Add method can be useful in the following situations:

* [Creating a game entity](../frb/docs/index.php)
* Multi-threaded applications
* Creating objects in a custom tool
* Satisfying curiosity

### What does an Add method do?

One of the first pieces of FlatRedBall code that new users write often includes an Add method. These Add methods (such as [SpriteManager](../frb/docs/index.php).AddSprite) greatly simplify game development by combining many common tasks in one simple call. These tasks are:

* Loading content (if necessary)
* Instantiating a runtime objecct
* Adding the runtime object to an internal manager list
* Returning the newly-created instance

To see this in action, let's consider the following two lines of code:

```
Sprite newSprite = SpriteManager.AddSprite("redball.bmp");
newSprite.XVelocity = 1;
```

This code will create a [FlatRedBall.Sprite](../frb/docs/index.php) showing the redball.bmp graphic and will move along the X axis at 1 unit per second. Now, let's return to the previous points and explain how the above code satisfies each:

* Loading content (if necessary) - The SpriteManager loads the redball.bmp graphic or grabs reference to the texture if it has already been loaded in the given [content manager](../frb/docs/index.php).
* Instantiating a runtime objecct - A [FlatRedBall.Sprite](../frb/docs/index.php) instance is created internally. This makes sense since after this method is called a [FlatRedBall.Sprite](../frb/docs/index.php) will be visible on screen.
* Adding the runtime object to a list - Notice that the XVelocity property is a set-and-forget property. In other words, you as a FlatRedBall programmer do not have to manually update the position of the object. It's done for you every frame. The [SpriteManager](../frb/docs/index.php) automatically moves the object according to its XVelocity. To do this, it must hold a reference to the object. Every manager has a list of objects which it updates every frame. This method adds the [Sprite](../frb/docs/index.php) to that list.
* Returning the newly-created instance - Our code assigns the newSprite reference to the instance returned by the AddSprite method. We can now use this instance to modify the Sprite.

### Breaking apart the Add method

Now that we understand what the Add method does we can break it down and replace some of its functionality with our own code. The following code is functionally identical to the code shown above:

```
// Loading Content
Texture2D texture2D = FlatRedBallServices.Load<Texture2D>(
    "redball.bmp"); // uses the default content manager
// Instantiate the runtime object:
Sprite sprite = new Sprite();
// Set the texture:
sprite.Texture = texture2D;
// Adding the runtime object to an internal manager list
SpriteManager.AddSprite(sprite);
// Setting the velocity to show it's been added to the manager
sprite.XVelocity = 1;
```

Naturally if the individual actions are broken up there is more code to be written, but this also gives us more freedom in controlling the logic of adding objects in more complicated situations.

### Loading Scenes

Loading a FlatRedBall file requires a little more code than creating a [Sprite](../frb/docs/index.php). Understanding the difference between instantiating, loading content, and adding to the engine can help you understand what each line of code is doing when creating an object such as a [Scene](../frb/docs/index.php) from a .scnx file.

Files used: [SplashScreen.zip](../frb/docs/images/2/2e/SplashScreen.zip)

```
// Load the information that will be used to create the
// runtime Scene
SpriteEditorScene spriteEditorScene =
    SpriteEditorScene.FromFile("splashScreen.scnx");
// Create the instance and load the content
Scene scene = spriteEditorScene.ToScene(
    FlatRedBallServices.GlobalContentManager);
// Add the scene to the managers:
scene.AddToManagers();
```

Notice that the creation of the runtime instances (the [FlatRedBall.Scene](../frb/docs/index.php)) and the loading of the content are both done in the same line - the ToScene call. After the [Scene](../frb/docs/index.php) is created it is added to the managers for every-frame management.

One of the reasons for the AddToManagers method being separated from the ToScene is because the ToScene method can be called on any thread while the AddToManagers can only be called on the game's primary thread. For more information on this topic see [the multithreading article.](../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
