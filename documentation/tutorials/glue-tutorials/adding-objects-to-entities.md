## Introduction

Just like Screens, Entities which have no files will not show up in your game. Of course, if you are not interested in the content creation/management support in Glue, then you can handle content through custom code. However, if you are using Glue to set up your content, then you need to add files to your Entities to give them a visible representation and other common functionality. This tutorial covers how to add files and objects to your Entity. As you read through it you will find a lot of similarities between Entities and Screens; however, there are a few extra things that must be done to add objects to Entities beyond simply creating a new file.

## Adding a Scene

First let's start by creating a Scene:

1.  Expand your "Character" entity which we created a few tutorials ago.
2.  Right-click on Files and select "Add File"-\>"New File", just like you did for the Screen in the previous tutorial.
3.  Enter Select "Scene (.scnx)" for the type, and enter the name **VisibleRepresentationFile** for the Scene name.
4.  The new Screen will appear under your Character Entity's "Files" tree item.

**Note:** The July 2011 version of Glue adds some new functionality. If you add a new .scnx or .shcx to Glue you will be asked if you want to create an object out of it. Normally this is very convenient, but for this tutorial we'll walk you through manually adding new objects. So if you see this popup, just say "No" for this tutorial. You will probably want to say "Yes" in the future.

## Adding a Sprite

Now that we have a Scene created, we need to add a Sprite to it. To do this:

1.  Double-click your .scnx file under your Character's "Files" tree item. If you set up the file assocation in the previous tutorial, the SpriteEditor should open.
2.  Add a new Sprite to the SpriteEditor. If you need help working with the SpriteEditor, click [here](/frb/docs/index.php?title=SpriteEditor:Main_Page.md "SpriteEditor:Main Page").
3.  Modify the Sprite so it is different from your level. I'll give mine an "Add" color operation and give it a neon green color At the time of this writing, the Windows Phone 7 version of FlatRedBall does not support the "Add" color operation, so you may want to pick something else to differentiate your objects if using this version of the engine. ![GlueEntitySprite.png](/media/migrated_media-GlueEntitySprite.png)
4.  Save your Scene. **Remember to copy your files locally**

As was mentioned in the previous tutorial, if you modify a .scnx, Glue automatically adds all necessary files to your project. Therefore, you don't need to do anything to Visual Studio to get this Scene to load. However, **you do need to modify your Entity by adding an object.** This is one extra step that has to be done for Entities which you didn't have to do before for Screens. Let's see why:

## Files and Objects

One of the biggest differences between Entities and Screens is that at a given time there is only one instance of a particular Screen in your game. However, there can be any number of a given type of Entity in your game. For example, in any Mario game, there is only one active level (Screen), but a level may contain dozens or even hundreds of coins (Entity). This distinction is very important when talking about Entities and how they interact with files. Since there is only one active Screen in your game at any time, Screens simply load .scnx files that they reference and display them. However, if your coin graphic is represented by a Sprite that sits in a .scnx file, there are two considerations:

1.  The game should not open the .scnx file for every coin in the level. If it did, this would mean that the game would have to go to the hard drive potentially hundreds of times to load the .scnx used by each coin instance! That would be incredibly slow.
2.  The Sprite object is used to draw the actual graphic to the screen. The position of the Sprite relative to the Camera determines where it will appear on Screen. Since each coin (Entity) needs to be in a different location, then each one needs to have its own Sprite.

Because of these two considerations, Entities treat files differently than Screens. Entities will load a file from the disk when the first instance is created. This loaded file will be used as a "blueprint". Each instance of an Entity will get its own copy of the loaded blueprint. This allows each Entity to do as it pleases with its objects (such as Sprites) without having to worry about impacting the appearance or behavior of any other Entity. For you, the Glue user, this means that you have to keep one thing in mind for Entities - if you want an Entity to use something from a file - such as a Sprite - **you must create an "Object" in your Entity which references the Sprite from your .scnx file.**

## Adding an object

Objects can be thought of as "modules" which you can add to your Entity to give it different characteristics. By default, Entities have only properties found in the PositionedObject class. For non-programmers, this means that by default Entities can:

-   Be positioned
-   Be attached to other objects
-   Be moved
-   Be rotated
-   Be created/destroyed

But there are a lot of other things that we may want like creating Entities that can:

-   Be drawn
-   Be animated
-   Have particles
-   Have collision

The way we can achieve this extra behavior is by adding objects. Let's make our Entity visible by adding a Sprite:

1.  Right-click on your Character Entity's "Objects" tree item,
2.  Select "Add Object" ![GlueRightClickAddObject.png](/media/migrated_media-GlueRightClickAddObject.png)
3.  Enter the name "VisibleRepresentation" for your new object ![GlueNewObjectName.png](/media/migrated_media-GlueNewObjectName.png)
4.  Press OK. The new object should appear under your Character Entity's "Objects" tree item ![GlueObjectInGlue.png](/media/migrated_media-GlueObjectInGlue.png)

One thing that may jump out at you is that there are a lot of properties available when you select an object. We won't cover most of these properties in this tutorial. However, keep in mind that these properties give you considerable amount of flexibility and power defining how your objects will behave and what type of code they will generate.

## Connecting an object to a file

Now that we have a Scene (.scnx) file and an object, we simply need to connect the two. By default your new object has its "Source Type" set to "File".![GlueSourceTypeFile.png](/media/migrated_media-GlueSourceTypeFile.png) To finish connecting the object to the file:

1.  Select the drop-down next to "Source File" and select your .scnx file ![GlueSelectedFile.png](/media/migrated_media-GlueSelectedFile.png)
2.  Select the drop-down next to "Source Name" and select the Sprite in your Scene (.scnx) file ![GlueSelectedSprite.png](/media/migrated_media-GlueSelectedSprite.png)

Great! Now we have our object and file connected. This means that from this point on you can make modifications to the Scene (.scnx) and these changes will be reflected in your Entity.

**Note:** When you run your game, your Entity object looks for the Sprite with the "Source Name" name. In the example above, this name is "redball1". If you remove this Sprite from your Scene (.scnx) or if you rename the Sprite in your Scene to a different name, then your object will not be able to find its Sprite. If you do this, be sure to re-set the "Source Name" to the new name in your Scene.

## Adding an Entity to a Screen

Even though we've defined our Entity, given it a file, created an object, and connected the object to the file, our entity won't appear in our game just yet. The reason for this is because so far this tutorial has defined what our Character entity is, but we haven't added a character Entity to our game yet. To use programming terms, we've created and set up our Character "class", but we haven't created an "instance" of it just yet. To create an Entity instance, you need to add it to a Screen. How do you do this? Through objects, of course. To add the Character Entity to your GameScreen:

1.  Expand your GameScreen
2.  Right-click on its "Objects" tree item and select "Add Object" just as you did for the Entity.
3.  Name your new object "CharacterInstance".
4.  Press OK and you should see the "CharacterInstance" object under your GameScreen's Objects tree item.

Now that we have a Character instance, let's set it up to use our Character Entity. To do this:

1.  Select the drop-down next for "Source Type" and change it from "File" to "Entity" ![GlueSourceTypeEntity.png](/media/migrated_media-GlueSourceTypeEntity.png)
2.  Select the drop-down next to "Source Class Type" and select "Entities\Character". ![GlueSourceClassTypeEntity.png](/media/migrated_media-GlueSourceClassTypeEntity.png)

## Viewing your Entity

Now that you've added a Character instance to your GameScreen, you will be able to view your Entity in game. Simply open your project in Visual Studio and Start Debugging. For a reminder on how to do this, check [this page](/frb/docs/index.php?title=Glue:Tutorials:Adding_files_to_Screens#Seeing_it_in_action.md "Glue:Tutorials:Adding files to Screens"). ![EntityInGame.png](/media/migrated_media-EntityInGame.png)

**Where is my Entity?!?** You may have just run your game, but not seen your green Entity. Instead, you might see a red ball. Why is it red and not green? Actually, it is Green...it's just being covered up by a red ball. FRB templates currently have a red ball Sprite automatically added. If you want to get rid of it:

1.  Open your project in Visual Studio
2.  Open the Game1.cs file
3.  Delete the following line of code (around line 48):

&nbsp;

    SpriteManager.AddSprite("redball.bmp");

[To the next tutorial -\>](/frb/docs/index.php?title=Glue:Tutorials:Custom_variables_and_behaviors.md "Glue:Tutorials:Custom variables and behaviors")
