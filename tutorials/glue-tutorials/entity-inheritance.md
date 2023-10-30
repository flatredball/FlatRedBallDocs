# entity-inheritance

### Introduction

"Inheritance" is a term borrowed from the programming world. In Glue, just like with programming, it means to create a "base" object that defines characteristics shared by all objects that "derive" or "inherit" from it. For example, if you are making a racing game, you may want to create an Entity called Car. Once you've done this, you'll want to specify a few Custom Variables like:

* float Horsepower
* float Torque
* float Weight

You may also want to define some objects such as:

* Sprite VisibleRepresentation
* Polygon Collision

But what if you want to have 10 different types of cars? Fortunately you can then create those 10 cars, and make each of them use the base Car Entity as their type. Once you do this, every car will have all of the properties defined above; however, you are free to define each separately. That way, you can give your Toyota Corolla its proper Horsepower and the Lamborghini Murcielago a different Horsepower. Of course, even though each derived Entity defines a different value for Horsepower, you can still use this property in your base Entity's code.

### Creating More Entities

Inheritance requires at least two Entities. However, to show the value of inheritance, we'll create two more Entities in addition to our already-created Character Entity - bringing us to a total of three Entities if you've been following along. We'll name one of our newly-created Entities "Player" and one "Enemy. To do this:

1. Right-click on your Entities tree item and select "Add Entity"
2. Name your new Entity "Player"
3. Right-click (again) on your Entities tree item and select "Add Entity"
4. Name your new Entity "Enemy"

Now you should have three Entities![Glue3Entities.png](../../../media/migrated_media-Glue3Entities.png)

### Setting up the inheritance

Now that we have our three Entities, let's make the Player and Enemy inherit from Character. To do this:

1. Select your "Player" Entity
2. Next to "Base Entity", use the drop-down window to select "Entity\Character"![GlueSetCharacterBase.png](../../../media/migrated_media-GlueSetCharacterBase.png)
3. Repeat the two steps above for your "Enemy" Entity by selecting it, and setting its "Base Entity" to "Entity\Character"

### Setting Variables in derived Entities

To review the terminology, if "Enemy" inherits from "Character", then "Character" is the **base** class and "Enemy" is the **derived** class. For this example, we'll use a custom variable called "MovementSpeed". If you don't have a MovementSpeed variable, you can add it to the Character to follow along, or you can use the WalkSpeed variable created in the previous tutorials. At this point the Character Entity defines the MovementSpeed variable, but the other Entities (Player and Enemy) do not have access to this variable. We can give them access so that they can set their own MovementSpeed values as follows:

1. Expand your Character's Variables item and select "MovementSpeed"
2. Set the "Set By Derived" property to "True"![GlueSetByDerived.png](../../../media/migrated_media-GlueSetByDerived.png)
3. If you deselect your "MovementSpeed" variable, you'll notice that the tree item is a darker color to indicate that derived classes can change the value![GlueDimmedVariableItem.png](../../../media/migrated_media-GlueDimmedVariableItem.png)

Now that you've set the variable to be "Set By Derived", you can set the value in any derived class. To do that:

1. Expand your Enemy's Variables tree item. Since it inherits from Character and since "MovementSpeed" is "Set By Derived", then you'll see the "MovementSpeed" variable there. Notice that it's yellow to indicate that it's a variable that's inherited from a base Entity.![GlueInheritedCustomVariable.png](../../../media/migrated_media-GlueInheritedCustomVariable.png)

Now you can simply edit this value just as you would any other normal value, only it can be used in the base or inherited Entity. Very convenient!

### Setting Objects in derived Entities

Objects can be defined in base Entities but set in derived Entities - just like Custom Variables. But why might you want to do this? The reason is because you may want to set up an abstract characteristic for base Entities, such as "All Entities inheriting from Character will have a VisibleRepresentation which is a Sprite, but each Entity that inherits from Character will set the specific values by using a different .scnx file." Therefore, a programmer could write code which makes all Characters flash a red color when hit by a weapon, but the designer still has the freedom to make the Enemy look different from the Player. Of course, this isn't limited to Sprites, but can be used for any type of object, including collision. Let's look at how to define a Collision object in the base Entity and set it in the derived Entities. First we'll create a Collision object in our base Entity:

1. Right-click on your Character's "Objects" tree node.
2. Select "Add Object"
3. Name your object "Collision"

Now the newly-created "Collision" object should be selected. We'll need to set the type of object we'll be using, and also change the properties so that the derived Entities have access to the "Collision" object:

1. Change the "Source Type" to "FlatRedBall Type"![GlueFlatRedBallType.png](../../../media/migrated_media-GlueFlatRedBallType.png)
2. Change the "Source Class Type" to "Circle![GlueCircleType.png](../../../media/migrated_media-GlueCircleType.png)
3. Change the "Set By Derived" property to True![GlueSetByDerivedCircle.png](../../../media/migrated_media-GlueSetByDerivedCircle.png)

Notice that we didn't set this to be set from file. Instead, we said that it's simply going to be a Circle, but the derived Entities will control how it is actually set. Just like before, if you expand your Enemy's (or Player's) Objects item, you should see "Collision" showing up as a yellow item![GlueCollisionInherited.png](../../../media/migrated_media-GlueCollisionInherited.png)

### Setting derived Collision properties

The next step is to set the properties of the Collision object in the derived Entities. To do this:

1. Select the Collision object in your Enemy Entity (make sure it's yellow)
2. Change its SourceType from "FlatRedBall Type" to "File"![GlueCollisionSourceType.png](../../../media/migrated_media-GlueCollisionSourceType.png)
3. We'll use a shortcut feature here. Change the "Source File" to "\<New File...>"![GlueNewFileShortcut.png](../../../media/migrated_media-GlueNewFileShortcut.png)
4. In the new file window, select the type as "ShapeCollection (.shcx)" and set the name as CollisionFile![GlueNewCollisionFile.png](../../../media/migrated_media-GlueNewCollisionFile.png)
5. If you haven't yet, set the file association for .shcx files (different from Scene (.scnx) files) to the PolygonEditor. If you need help with this step, see [this page](../../../frb/docs/index.php#Setting_up_File_Associaton).
6. Double-click the newly-created file under your Enemy Entity's "Files" tree item. This should open the [PolygonEditor](../../../frb/docs/index.php).
7. Add a new Circle. For help on working with the [PolygonEditor](../../../frb/docs/index.php), see [this page](../../../frb/docs/index.php).
8. Save your ShapeCollection in the [PolygonEditor](../../../frb/docs/index.php). Be sure to save a ShapeCollection, not a Scene or Polygon List.![GlueSaveShapeCollection.png](../../../media/migrated_media-GlueSaveShapeCollection.png)
9. Return to your Enemy's "Collision" object and finally set the "Source Name" to the Circle you just created![GlueSetCircleSourceName.png](../../../media/migrated_media-GlueSetCircleSourceName.png)

Now you can repeat the above steps for your Player Entity, but it will have its own .shcx file, and the Circle in that .shcx file can be completely different. Keep in mind that since the source type defines Collision as a Circle, then all classes that inherit that property must assign a Circle to it.

### Things to try

Inheritance is a very powerful feature, but it also can take some getting used to. A project built with proper inheritance can greatly reduce the number of Entities required. A smaller Entity group can result in faster development, greater flexibility and ability to react to changes in design, less memory usage, and easier maintenance of your objects in Glue. Working with inheritance is something that can take some practice, and we encourage you to try a few other cases out in your project. Here are some ideas:

1. Remove the .scnx from your Character Entity's files.
2. Make the VisibleRepresentation a FlatRedBall Type, Sprite and make its "Set By Derived" to true.
3. Try adding a .scnx file to your Player and one to your Enemy.
4. Use different images in each.
5. Set the VisibleRepresentation for each of the derived Entities using the different .scnx files.

If you manage to do this and want to see it in action, you should try the following as well as a review of concepts covered in previous tutorials:

1. Add an instance of Player and an instance of Enemy to your Screen. You may have to remove the Character instance.
2. Use exposed variables to position your Player and Enemy instances so they no longer overlap in the screen.
3. Try creating multiple Enemy instances in your Screen.

### What's next

Now you've see how you can set properties in defined classes. That means that every different "type of Character" can have a different instance. In the next tutorial we start to look at Layers, a key component for creating UI and HUD in your games. [To the next tutorial ->](../../../frb/docs/index.php)
