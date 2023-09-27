## Introduction

Now that you have created a Glue project, the next step is to add Screens and Entities to your game. At this point you may be asking, "What is a Screen? What is an Entity?". Read on!

## What are Screens and Entities?

You can think of Screens and Entities as "containers". Entities usually contain FlatRedBall objects like Sprites and collision Shapes, while Screens contain larger FlatRedBall objects like large scenes and groups of Entities. Let's look at these objects in a little more detail.

### What is a Screen?

A Screen is a part of your game which loads content when it is created, then unloads content when it is destroyed. This may all seem a little technical, so let's give some examples of screens:

-   A title screen in a game
-   A level in a game
-   A credits screen
-   The indoors of a house in an RPG
-   A map in an RTS
-   A race track in a racing game
-   The board in a board game (like chess)

Screens can also be "popup Screens". A popup Screen is a Screen which is created by another screen. The popup Screen can load content when it is created, but it usually does not destroy content - the Screen that creates the popup is responsible for that. Here are some examples of popup Screens:

-   A pause menu
-   Game HUD (score, health, mini-map)

### What is an Entity?

Entities are objects which have one or more of the following properties:

-   Some kind of graphical representation (Sprite, Model, Text, etc.)
-   Collision property (Polygon, Circle, etc.)
-   Every-frame behavior (AI, responding to input, collision reaction)

Here are some examples of Entities:

-   A character in a platformer
-   An enemy in a fighting game
-   A bullet
-   A power-up item
-   A button in a menu
-   A game trigger (something that causes an action, like a transition to a new screen)
-   A car in a racing game

## Creating Screens

A good place to start when making a game is to create a Screen for your game. Initially when you create any object in Glue, you specify only its name. For the rest of the Glue tutorials we'll create a simple game where you can move a ball through a level using the arrow keys on the keyboard. This will all occur in a Screen which we'll call "GameScreen". To create your GameScreen:

1.  Right-click on the Screens item
2.  Select "Add Screen"![GlueAddScreenRightClick.png](/media/migrated_media-GlueAddScreenRightClick.png)
3.  Enter "GameScreen" for the name of your new Screen and press OK![GlueEnterScreenName.png](/media/migrated_media-GlueEnterScreenName.png)
4.  Notice that you can now expand the Screens node in the list on the right and it contains your new Screen![GlueNewScreenExpanded.png](/media/migrated_media-GlueNewScreenExpanded.png)

Now your project has a new Screen called GameScreen. Although it might not seem like you've done much, by adding a new Screen you've actually generated a brand new Screen class (new code), you've added it to your project, and you've modified your project so that this Screen will automatically become active when the game starts. That's a lot for not having written even one line of code!

### Setting StartUp Screen

Notice that the newly-added Screen is red in Glue. This means that it is the Screen that will start the game. If you want to change to a different Screen (once you add more Screens of course), you can right-click on any Screen and select "Set as StartUp Screen".

## Creating Entities

So far you've created a Screen where your game will take place. The next step is to create an Entity that the player can control. We'll call this our "Character". Adding an Entity is very similar to adding a new Screen:

1.  Right-click on the Entities item
2.  Select "Add Entity"![GlueAddEntityScreen.png](/media/migrated_media-GlueAddEntityScreen.png)
3.  Enter "Character" for the name of your new Entity and press OK![GlueEntityName.png](/media/migrated_media-GlueEntityName.png)
4.  Notice that you can now expand the Entities node in the list on the right and it contains your new Entity![GlueExpandedEntityInTreeView.png](/media/migrated_media-GlueExpandedEntityInTreeView.png)

After completing these steps, your game has a new Entity called Character. The addition of the new Entity resulted in a new Entity class (new code) as well modification of your project to add this new code.

## Entity and Screen code

Glue is a tool for programmers and non-programmers alike. In fact, in team-projects, it is possible that every team member does some work in Glue. If you are not a programmer, you will probably not be interested in programmer information. For your convenience, these tutorials will have any programmer-specific information in boxes colored the same as this one. In other words, if you don't know how to program, feel free to skip sections like this.

This section discusses details about the Screen and Entity code generation in Glue. When you make a Screen or Entity, **Glue creates two files:**

-   \<NameOfSceenOrEntity\>.cs
-   \<NameOfScreenOrEntity\>.Generated.cs

![GlueCodePreview.png](/media/migrated_media-GlueCodePreview.png)

This means that there are **two files for every Screen or Entity** in your project. Once Glue creates them, it stuffs them in your Visual Studio project. Let's look at these two files separately.

### \<NameOfScreenOrEntity\>.cs

This class is what we call a "custom code" class. When you first create a new Screen or Entity in Glue, this file is created, **but after that, Glue never touches this file!** That means that you can change this file as much as you want and Glue will never overwrite your changes.

This file has four methods:

-   CustomInitialize - Called once when the Entity is instantiated
-   CustomActivity - Called every frame
-   CustomDestroy - Called one time when the Entity is destroyed
-   CustomLoadStaticContent - Called only once for the entire class - this is where you'd want to pre-load assets that aren't being handled by Glue

These four custom methods provided in the "custom code" .cs file can be used to customize the behavior of your Screen or Entity. You can also add additional methods, properties, and variables to your Screen or Entity in the "custom code" .cs file. Just be sure to not remove or rename the Custom methods. If you do, you will get compile errors because the generated code assumes that those methods exist.

### \<NameOfScreenOrEntity\>.Generated.cs

This file is a Generated file. It contains all of the code generated by Glue. This code is generated automatically, and it is re-generated any time your Screen or Entity changes (as we'll show in later tutorials). You should \*never\* write any code in this class, as it will be lost whenever the given Sceen or Entity is generated, and this happens quite often!

**What's the order of everything?!?** One of the biggest problems when dealing with generated code is knowing the order of when things are called. For example, does Glue create objects in your Entity before your CustomInitialize method or after? This matters if you want to do something with the objects you've created in Glue.

The short answer is:

Custom code comes after generated code

The reason for this is because in most cases you will want to do things **after** generated code. As mentioned above, your CustomInitialize method modify objects that are defined in Glue. Of course, if in doubt, pop open the .Generated.cs file and check out what's going on under the hood.

## Accessing Code

If you are interested in seeing what Glue has done, you can easily investigate an object's code by expanding the "Code" item under any Entity or Screen, then selecting the appropriate .cs file.

Of course, you don't have to settle for Glue's read-only view of the code. You can double-click on a file in the tree view and it will open in the application which is by default associated with the file type (.cs). You can also go to Project-\>View in Visual Studio to view your entire project in Visual Studio, then navigate to the appropriate files through the Solution Explorer.

## Is your project under version control?

If your project is under version control (such as Perforce or Subversion), then you may be wondering which files you should and shouldn't check in. When it comes to code, you need to check in any .cs file that is not a .Generated.cs file. You will want to (of course) check in all other files that you would normally check in if you aren't in Glue, and also make sure to check in your .glux file. If the project is updated on a remote computer, Glue will automatically regenerate all .Generated.cs files. For the sake of avoiding difficult conflicts and cluttering your version history you will want to keep .Generated.cs files out of your project's repository.

## What's next?

At this point you've created a new Screen and Entity. If you are in the planning stages of your game, you could continue to do this, adding all of the necessary Screens and Entities. Since doing this requires doesn't require any code or content, Glue makes for a good planning tool. The great thing about making a "skeleton project" in Glue is that all of your work turns into usable code. You're planning and writing code at the same time!

Next, we'll be adding files to your new Screen so that it loads content.

[To the next tutorial -\>](/frb/docs/index.php?title=Glue:Tutorials:Adding_files_to_Screens.md "Glue:Tutorials:Adding files to Screens")
