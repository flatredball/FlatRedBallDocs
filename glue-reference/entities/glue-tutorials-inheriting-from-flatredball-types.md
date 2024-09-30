# Inheriting from FlatRedBall Types

### Introduction

This tutorial will walk you through how to create entities which inherit from FlatRedBall types. More accurately, the process of having Entities inherit from FlatRedBall types is very simple - all you have to do is change the BaseType to the desired type. However, this tutorial will discuss how to work with entities that inherit from FlatRedBall types, and why taking advantage of this feature can be helpful.

### Setup

First we'll create a simple project with a single Entity that includes a Sprite, and a Screen which includes a large list of instances of this entity.

#### Entity Setup

To create the Entity:

1. Right-click on Entities
2. Select "Add Entity"
3. Name the Entity "SpriteEntity"
4. Right-click on the newly-created Entity's Objects
5. Select "Add object"
6. Select "Sprite" as the type
7. Click OK

Now that we have an Entity, let's set the Sprite to use a Texture:

1. Download the Bear.png image from here:![Bear.png](../../.gitbook/assets/migrated\_media-Bear.png)
2. Go to the location where you saved the file
3. Drag+drop the PNG from the location where you saved it into the SpriteEntity's "Files"
4. Select the SpriteInstance object
5. Set its Texture to "Bear"

#### Screen Setup

Now that we have an Entity, let's create Screen:

1. Right-click on Screens
2. Select "Add Screen"
3. Name your Screen "MainScreen"
4. Click OK

Next let's create a List of SpriteEntites:

1. Right-click on Objects
2. Select "Add Object"
3. Select "PositionedObjectList\<T>" as the type
4. Select "Entities\SpriteEntity" as the List Type
5. Name the list "SpriteEntityList"
6. Click OK

Finally let's populate the List in code:

1. In Glue select the "Project"->"View in Visual Studio" menu option
2. Open MainScreen.cs
3. Add the following in CustomInitialize:

```
 int numberToCreate = 4000;

 for (int i = 0; i < numberToCreate; i++)
 {
     Entities.SpriteEntity newInstance = new Entities.SpriteEntity();
     newInstance.RotationZVelocity = 
         (float)FlatRedBallServices.Random.NextDouble() * 3;
     Camera.Main.PositionRandomlyInView(newInstance, 40, 40);
     SpriteEntityList.Add(newInstance);

 }
```

You should see a large number of spinning bears: ![InheritanceProject1.PNG](../../.gitbook/assets/migrated\_media-InheritanceProject1.PNG)

### Measuring resource usage

If you're running this project on a modern computer then it's likely that you may not be noticing any performance problems. However, despite running without problems on the PC, this same project may have significant performance and memory consumption issues on less powerful devices, such as the iPhone. One solution to this problem would be to make the Entities be manually updated; however that may not be so easy in this particular case. The reason is because our Entities are all spinning and require every-frame logic to have their rotation applied. However, making the Entities inherit from sprite can actually improve performance and memory usage. To understand why this is the case, let's first investigate how many manually updated objects are in the FlatRedBall engine. To do this:

1. Open your MainScreen.cs in Visual Studio
2. Add the following code to CustomActivity:

```
FlatRedBall.Debugging.Debugger.WriteAutomaticallyUpdatedObjectInformation();
```

Now your program will be outputting information about how many automatically updated objects exist in the engine: ![AutomaticallyUpdatedOutput1.PNG](../../.gitbook/assets/migrated\_media-AutomaticallyUpdatedOutput1.PNG) For more information on this method call, see the [WriteAutomaticallyUpdatedObjectInformation](../../api/flatredball/debugging/debugger/writeautomaticallyupdatedobjectinformation.md) page. We can see that we have 4000 Sprites (one for each instance of our SpriteEntity) and also 4000 PositionedObjects (each SpriteEntity inherits from PositionedObject).

### Using Inheritance to reduce automatically-updated object count

Now that we have this set up, let's change our SpriteEntity to inherit from a Sprite. To do this:

1. Select SpriteEntity in Glue
2. Change "BaseEntity" to Sprite

Now we can simply have the SpriteInstance inside of SpriteEntity be a reference to the SpriteEntity itself. To do this:

1. Select SpriteInstance
2. Set "IsContainer" to true

![IsContainer.png](../../.gitbook/assets/migrated\_media-IsContainer.png) Now that the SpriteEntity inherits from a Sprite, and the SpriteInstance is the container, we have essentially eliminated half of our runtime objects. To see this result, run the game again: ![ReducedObjectCountFromInheritance.PNG](../../.gitbook/assets/migrated\_media-ReducedObjectCountFromInheritance.PNG) You can see that since all of the entity instances are Sprites, all PositionedObjects have been removed (the engine reports 0 PositionedObjects).
