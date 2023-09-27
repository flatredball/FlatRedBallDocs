## Introduction

The SmoothScrollingContainer is an Entity which can be used to allow objects in your games to scroll kinetically (like the Metro UI in Windows Phone 7). The SmoothScrollingContainer is intended to be used as a base Entity for other Entities in your game.

## Example: Creating scrolling text

This example will show how to create a scrolling Text object. This example will cover:

-   How to import the SmoothScrollingContainer
-   How to create a new Entity that uses SmoothScrollingContainer as its base
-   How to add text to the new Entity
-   How to control scrolling behavior
-   How to add an instance of the new Entity to a Screen
-   How to use a Layer to clip the area where the Text will draw.

### How to import the SmoothScrollingContainer

The first step is to download the SmoothScrollingContainer.entz file which can be found [here](http://www.gluevault.com/entity/42-smooth-scrolling-container). Once you have downloaded the file, open Glue and import the file. For information on how to import Entities, see [this article](/frb/docs/index.php?title=Glue:Reference:Entities:Import_Entity.md "Glue:Reference:Entities:Import Entity").

![SmoothScrollingInWiki.PNG](/media/migrated_media-SmoothScrollingInWiki.PNG)

### How to create a new Entity that uses SmoothScrollingContainer as its base

Next we will create a new Entity which will use the SmoothScrollingContainer as its base. To do this:

1.  Right-click on the Entities tree item and select "Add Entity"
2.  Name the new Entity "ScrollingText" and click OK
3.  Select the newly-created Entity and set its BaseEntity property to "Entities\SmoothScrollingContainer". For more information on the BaseEntity property and the concept of inheritance, see [the Entity Inheritance article](/frb/docs/index.php?title=Glue:Tutorials:Entity_Inheritance.md "Glue:Tutorials:Entity Inheritance").

![SmoothScrollingAsBase.PNG](/media/migrated_media-SmoothScrollingAsBase.PNG)

### How to add text to the new Entity

### How to control scrolling behavior

### How to add an instance of the new Entity to a Screen

### How to use a Layer to clip the area where the Text will draw
