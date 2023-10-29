## Introduction

Objects in Glue which reference files can either represent a part of a file (such as a Sprite in a Scene) or the entire file itself. Using the "entire file" option can make it easier to maintain as no changes are required on the Glue side when objects are added or removed from a file. The "entire file" option is often used in entities, which require files to be added as objects before they will show up in game.

## Creating an Entire File Object

The following steps can be used to create an entire file from a .emix (Emitter List) file. It assumes that the Entity already has an .emix file:

1.  Right-click on Objects
2.  Select "Add Object"
3.  Select the "From File" option
4.  Select the .emix file
5.  Use the drop down to set the Source Name to "Entire File (EmitterList)"![EntireFileEmix.PNG](/media/migrated_media-EntireFileEmix.PNG)
6.  Click OK

## Entire Files and Duplication

Objects using the "entire" option behave slightly differently than normal objects. If two named objects reference the same item in a file, then the Entity will receive two copies of that item. However, if one named object references the entire file, and another Entity references an item from inside that file, the second will reference an item in the first, instead of making its own copy. If this is confusing, let's take a look at an example. We'll start with an Entity called "Button" which has a Scene. This Scene may contain any number of objects - a frame for the Button, a highlight Sprite which turns on/off, a Text object, a drop shadow, and so on. ![EntireFileOption.png](/media/migrated_media-EntireFileOption.png) Creating an object using "Entire File" is a quick way to see the entire Entity in game, but how do you add behavior to the Text object? **The answer is, you can simply create a new object and have it reference the Text object in the Scene - Glue will not duplicate the object**. In other words, your new object will reference the same Text object that is held inside the "Entire File" object. ![TextObject.png](/media/migrated_media-TextObject.png) Now you can create variables and states using the new TextObject, and even use it in code.

## Code Results

If you open the generated code file you'll see that the TextObject comes from the EntireScene object:

    EntireScene = SceneFile.Clone();
    TextObject = EntireScene.Texts.FindByName("TextObject");
