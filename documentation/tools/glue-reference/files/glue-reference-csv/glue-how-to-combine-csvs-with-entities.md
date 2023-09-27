## Introduction

CSVs are a common way to define game data in FlatRedBall games. Examples of game data include the cost, damage, and rarity of weapons or stats of enemies like Orc, Dragon, and Elf. Usually this information is used in game logic to determine information like the maximum speed of a car or how much damage an attack deals. Fortunately Glue provides a flexible, powerful way to use CSV data in your game. This article provides an example of loading a CSV into an entity to control its movement speed.

## What kind of information can exist in CSVs?

The type of information can be categorized into three groups:

1.  Simple coefficients like HP or AttackDamage for enemies in an RPG, or like Horsepower and Weight for cars in a racing game
2.  Content information such as which .PNG to use for a enemy, or which .scnx to load for a level
3.  Behavioral classes such as ability classes. Usually this feature requires usage of advanced CSV functionality such as lists and inheritance.

## Creating a new Project

You will need a Glue project to follow along this tutorial. For information on how to create Glue projects, see [this page](/frb/docs/index.php?title=Glue:Tutorials:Creating_a_new_project.md "Glue:Tutorials:Creating a new project").

## Creating an Entity

In this tutorial we'll use an Entity called **Animal**. To create the Animal Entity:

1.  Right-click on the **Entities** item in Glue
2.  Select **Add Entity**
3.  Enter the name **Animal** and click **OK**

## Adding a Sprite to the Entity

Next we'll add a Sprite to the Animal Entity so that it can be seen in our game. To do this:

1.  Expand the Animal Entity
2.  Right-click on **Objects**
3.  Select **Add Object**
4.  Select the **Sprite** type
5.  Enter the name **MainSprite** and click **OK**

## Making the Sprite visible

The default Sprite will not have a Texture associated with it, therefore it won't be visible. To make the Sprite visible:

1.  Select the MainSprite object
2.  Set the ColorOperation value to "Color"
3.  Set the Red value to 1
4.  Set ScaleX to 64
5.  Set ScaleY to 64

## Creating a Screen with an Animal

Next we'll create a Screen to verify that our Animal is working properly. To do this:

1.  Right-click on the Screens item in Glue
2.  Select "Add Screen"
3.  Enter the name "GameScreen" and click OK
4.  Move the mouse over the Animal Entity and push/hold the mouse button
5.  Drag the mouse down to the newly-created GameScreen and release the button
6.  Click "Yes" when prompted if you want to add an Animal to GameScreen

We will also want to set up our camera to be 2D. To do this:

1.  Click on the Settings menu item
2.  Select "Camera Settings"
3.  Change "Is 2D" to "True"

Now you can run the game and you should see your Animal appear as a red square:![AnimalSpriteRed.png](/media/migrated_media-AnimalSpriteRed.png)

## Creating a CSV

At this point we have a basic project up and running: We can see our Animal Entity in our screen, although at this point the Animal Entity is simply a red square that doesn't do anything. Next we'll define a few animal types. To do this:

1.  Right-click on the "Global Content Files" item
2.  Select "Add File"-\>"New File"
3.  Select the "Spreadsheet (.csv)" file type
4.  Enter the name AnimalInfo for the file type

Once the file is created, double-click the file to open it in a spreadsheet editor. Modify the file so it contains the following information:

|                 |               |         |
|-----------------|---------------|---------|
| Name (required) | Speed (float) | Texture |
| Bear            | 60            | Bear    |
| Slug            | 20            | Slug    |

Save the file to cause Glue to update the AnimalInfo class to match the new data entered in the CSV file.

## Making AnimalInfo a Dictionary

Next we'll make the AnimalInfo file create a Dictioanry - this will make working with the AnimalInfo easier. To do this:

1.  Select the AnimalInfo.csv file in "Global Content Files"
2.  Change the "CreatesDictionary" property to "True"

## Including the AnimalInfo in the Animal Entity

If you have used Glue before, you may expect the next step to be adding a variable called "Speed" to the Animal Entity which can be assigned from the CSV. Instead of creating a new variable for Speed, we'll instead add a reference to the entire AnimalInfo inside the Animal Entity. To do this:

1.  Expand the Animal Entity
2.  Right-click on the Variables item
3.  Select "Add Variable"
4.  Select the "Create a new variable" radio button
5.  Select "GlobalContent/AnimalInfo.csv" as the type
6.  Enter "AnimalInfo" as the name![AnimalInfoVariable.PNG](/media/migrated_media-AnimalInfoVariable.PNG)
7.  Click "OK"

This new AnimalInfo variable can now be set in code or in Glue. For simplicity we'll set it in Glue; however, CSV variables like AnimalInfo are usually set in code according to player actions or game data. To set the variable:

1.  Select the newly-created AnimalInfo variable
2.  Set the DefaultValue to "Bear" using the drop-down![DefaultValueToBear.png](/media/migrated_media-DefaultValueToBear.png)

## Using AnimalInfo in behavior code

Now we can use the AnimalInfo variable in our Animal's behavior code. To do this, add the following code in the CustomActivity **in Animal.cs**.

     InputManager.Keyboard.ControlPositionedObject(this, this.AnimalInfo.Speed);

Notice that the AnimalInfo and Speed variables are both supported in Visual Studio's autocomplete. Working with these Glue-created types and variables provides full autocomplete support so you know that you're writing the code correctly. Now try running the game and using the arrow keys on the keyboard to move your Animal entity. Also, try changing between the Bear and the Slug and you'll notice the Slug moves much slower. You can also modify the values in the CSV, then run your program again to notice the changes.

**Memory Benefits:** Since the types defined in CSVs are reference types (classes), then the Entity simply points to a reference of an AnimalInfo. While this might seem like a small gain (in the case of one Entity, it may not be a gain at all), consider a situation where you have numerous variables defined in a CSV, and you may have dozens or even hundreds of Entities that use these CSV values. In this case the reference characteristics of the CSV types is very beneficial. Furthermore, these references are not destroyed or recreated, so you will save on memory allocation and garbage collection if you are creating and destroying Entity instances.

## Loading content according to AnimalInfo

Next we'll look at how to load content dynamically according to information in the AnimalInfo CSV. The approach we're going to show is a very powerful approach because it only loads information as needed. We'll be loading a Texture2D to apply to the Animal Sprite, however this approach can be used for any other data such as AnimationChains, Scenes, and ShapeCollections. Also, keep in mind that this is not limited to Entities - you can also use it on Screens to dynamically load data according to information in a CSV that defines level info. To add the textures to your project:

1.  Save the following Bear.png and Slug.png images to your computer![Bear.png](/media/migrated_media-Bear.png)![Slug.png](/media/migrated_media-Slug.png)
2.  Return to Glue
3.  Expand the Animal Entity
4.  Right-click on the Files item under Animal
5.  Select "Add File"-\>"Existing File"
6.  Select the Bear and click OK
7.  Repeat the above 3 steps and add the Slug
8.  Select the newly-added Bear file and set its "LoadedOnlyWhenReferenced" to "True"![LoadedOnlyWhenReferencedBear.png](/media/migrated_media-LoadedOnlyWhenReferencedBear.png)
9.  Select the Slug and also set its "LoadedOnlyWhenReferenced" to "True"

Now we need to write a little bit of code to modify the Sprite according to the AbilityInfo. To do this:

1.  Open Animal.cs and delete the contents of CustomInitialize - we won't need this code anymore now that we're going to use textures.
2.  Select the AnimalInfo variable under Animal in Glue.
3.  Set its "CreatesEvent" variable to "True"![CreatesEventAnimalInfo.png](/media/migrated_media-CreatesEventAnimalInfo.png)
4.  Right-click on the "Events" item under Animal in Glue
5.  Select "Add Event"
6.  Verify "Expose an existing event" is selected
7.  Verify "AfterAnimalInfoSet" is selected as the existing event
8.  Click OK
9.  Expand the Events item and select the "AfterAnimalInfoSet" event
10. Add the following code to the text box which appears on the left:

&nbsp;

    this.MainSprite.Texture = (Texture2D)GetFile(this.AnimalInfo.Texture);

Next we'll modify the Sprite's variables. To do this:

1.  Select the MainSprite object in Glue
2.  Right-click on the "ScaleX" variable and select "Reset to Default"
3.  Right-click on the "ScaleY" variable and select "Reset to Default"
4.  Set the PixelSize varaible to .5
5.  Set the ColorOpeartion to "Texture"

Run the game and you should see either the Slug or the Bear texture as your Entity. ![BearInGame.png](/media/migrated_media-BearInGame.png)

## Order of Variables Matters!

A very common mistake when working with CSVs is to not properly order your variables. If you followed the tutorial above word-for-word, then your project will not have any variable order issues because there is only one variable - the CSV variable. However in larger Entities variable order problems can emerge. For starters, let's consider the example above where we have a single CSV variable which has a script that sets the Texture on a Sprite. The setup may look like this: ![AnimalSetup1.PNG](/media/migrated_media-AnimalSetup1.PNG) Specifically, we have just a CSV variable, and an event that is raised when the CSV variable (called AnimalInfo) is set. Next we'll tunnel in to the Sprite's Texture. To do this:

1.  Right-click on Variables
2.  Select the "Tunnel a variable in a contained object"
3.  Select "MainSprite" as the Object
4.  Select "Texture" as the Variable
5.  Set the Texture to "Slug"
6.  Set the AnimalInfo to "Bear"

At this point your Entity will show the Slug. You can verify this by either running GlueView, or by dropping the Animal Entity in a Screen and running the game. If you change the AnimalInfo variable, you will notice that the enemy continues to display the Slug no matter which value you set on AnimalInfo. The reason for this is because order matters. Since MainSpriteTexture appears **below** the AnimalInfo variable, it is set **after**. A good way to think about it is that variables are set from top to bottom - the same way that code is executed. You can fix this by right-clicking on the AnimalInfo variable and selecting to move it to bottom:![MoveToBottomVariable.png](/media/migrated_media-MoveToBottomVariable.png) This will make the CSV variable be set last. In general you will want to make CSV variables - and for that matter any variable which has events tied to it - as set last in your Entities and Screens.

## Setting the AnimalInfo after initialization

So far we've shown how to set AnimalInfo in Glue. This is very handy for previewing things in GlueView, or for setting initial values; however it is likely that you will want to set values in custom code according to player actions or scripted events. To do this, you can simply access the AnimalInfo variable. To do this:

1.  Create a Screen (you don't need to do this if your game already has a Screen)
2.  Add an instance of Animal in your Screen
3.  Add the following code in your Screen's CustomInitialize:

&nbsp;

    this.AnimalInstance.AnimalInfo = GlobalContent.AnimalInfo[AnimalInfo.Bear];

**Note**:You may need to fully-qualify

    AnimalInfo.Bear

. You can do this with CTRL+dot. More info [here](/frb/docs/index.php?title=Visual_Studio_Tutorials:Qualifying_Types.md "Visual Studio Tutorials:Qualifying Types")

You can change this from Bear to Slug and the AnimalInstance will respond appropriately. Of course, you don't have to do this just in CustomInitialize, you can do this at any point, and on any Entity that supports this pattern, whether it is created in Glue, or [created purely in code](/frb/docs/index.php?title=Glue:Tutorials:Basic_coding_in_Glue#Creating_an_Entity_Programatically.md "Glue:Tutorials:Basic coding in Glue").

## Considerations and moving forward

While this example may seem to be simple, the approach we've taken here is incredibly scalable, efficient, and flexible. However, as with all approaches there are some things to consider:

-   All Entities that are given the same CSV object reference will share the same exact instance. This means that if you change a value (like the Bear's Speed) it will apply to **all bears**. Also, the CSVs are not destroyed when Entities or Screens are destroyed if put in Global Content Files, so **changes will persist until the program is restarted**. This can all cause confusing behavior if you are editing the CSV but not seeing changes that you expect to see. You should never change these values in code unless you have a **very good** reason to do so.
-   If you intend on modifying values, such as allowing each individual instance to have a speed boost according to the Animal's level, you should make a custom property that uses the base value and returns a modified value.
-   The texture for the Bear and Slug will not be loaded until either is needed. Since the AnimalInfo is set after content is done loading, it is done on a primary thread. In other words, this means you may notice a slowdown or freeze when loading content if you are loading a lot of content. For simplicity this tutorial only covers how to load the content on the primary thread, but you may want to pre-load content that you know you will need in CustomLoadStaticContent.
-   Changes in the CSV will immediately show up in code (as long as Glue is open). This means that if you remove a column from the CSV (such as the Speed column), then that variable will be removed from the matching class. Be careful removing or renaming columns as this may break existing code.
