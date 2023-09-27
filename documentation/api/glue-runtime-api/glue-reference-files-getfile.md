## Introduction

The GetFile method is a method which lets you get a file using a string instead of directly accessing a file. In other words, if a screen or entity contains a file called Bear.png, GetFile allows you to do this from within the screen or entity:

    Texture2D texture = (Texture2D)GetFile("Bear");

The argument (in the example above "Bear") matches the name of the variable in the screen or entity. This will usually be the name of the file, without any path or extension. The exception to this rule is if the [IncludeDirectoryRelativeToContainer](/frb/docs/index.php?title=Glue:Reference:Files:IncludeDirectoryRelativeToContainer.md "Glue:Reference:Files:IncludeDirectoryRelativeToContainer") value is true. ![](/media/2017-05-img_591898eae0479.png) Similary, GetFile can be called to obtain files from GlobalContent. For example, the following returns a song called BattleSong from GlobalContent:

``` lang:c#
Song song = (Song)GlobalContent.GetFile("BattleSong");
```

## Why use GetFile

Using the example above, you can simply do:

    Texture2D texture = Bear;

However, if you need to dynamically select a texture (such as if you are reading information from a CSV) your code may need to be dynamic. Therefore, you could do:

    // Assuming EnemyInfo is a valid variable with a Texture that is a string 
    string fileName = EnemyInfo.Texture;
    Texture2D texture = (Texture2D)GetFile(fileName);

Another common example is that a game may support loading levels dynamically, as follows:

    // Assuming that LevelNumber is a valid int:
    var level = (Scene)GetFile("Level" + LevelNumber);

## Accessing GetFile from different locations

GetFile will usually work without any additional code most of the time, but not always. We'll look at two different scenarios and discuss what is required for each:

### 1. Calling GetFile with a live instance of the screen/entity that contains the files

The most common - and simplest - scenario is calling GetFile when there is already an instance of the object that holds the files created. This can be done in a number of ways:

-   Calling a screen's GetFile function when the Screen is the active Screen
-   Calling an entity's GetFile function from within the entity's custom Initialize/Activity/[LoadStaticContent](/frb/docs/index.php?title=Glue:Reference:Screens:LoadStaticContent.md "Glue:Reference:Screens:LoadStaticContent") methods
-   Calling an entity's GetFile function through an instance of that entity

In all of the above cases, an instance of that Screen/entity will have been created, meaning that the files will have been loaded and are available to access through GetFile. In short, if an instance is alive, then GetFile should work without any other code.

### 2. Calling GetFile without an instance of the screen/entity that holds the file

It is possible to call GetFile on a screen/entity without having an instance of that screen/entity. However, to do this, you must first tell the screen/entity to load the files so that they are available through GetFile. For example, consider the following code:

    // Assume that this code takes place in a Screen which does not have an instance of the Player entity
    // First, the Player's content must be loaded.
    // We'll use the Screen's ContentManagerName so that the content is unloaded when the
    // Screen is destroyed.
    Player.LoadStaticContent(ContentManagerName);
    // Now we can access the files:
    Texture2D texture = (Texture2D)Player.GetFile("SomeFile");

[LoadStaticContent](/frb/docs/index.php?title=Glue:Reference:Screens:LoadStaticContent.md "Glue:Reference:Screens:LoadStaticContent") can be called multiple times, and this will not reload the content as long as the same content manager is used. For more information, see [the LoadStaticContent page](/frb/docs/index.php?title=Glue:Reference:Screens:LoadStaticContent.md "Glue:Reference:Screens:LoadStaticContent").
