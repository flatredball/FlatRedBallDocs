## Introduction

This guide describes how to perform common operations with standard Glue objects. Most of what is described here can also be done through the Glue UI, but using code is sometimes necessary for dynamic behavior.

## The setup

For this article we'll use the following setup:

1.  A Screen which we'll call GameScreen
2.  An Entity which we'll call Character

Some examples may include other types of objects. We will skip over how to create these objects here for the sake of keeping this guide shorter.

## Creating an Entity Programatically

If you've read other tutorials such as Beefball, then you are probably pretty familiar with the process of creating an Entity instance in Glue. Fortunately, you can also create instances in code very easily. For example, the following code would create a Character instance in the GameScreen: Add the following to the GameScreen.cs at class scope:

    Character mCharacter; // You may need to add a using for this, like "using GlueTutorial.Entities;"

Add the following to the GameScreen's CustomInitialize. Note that this call fully instantiates the entity and adds it to the relevant managers for the application of velocity and drawing. This call does not result in the entity's Activity method called (see below):

    mCharacter = new Character();

Add the following to the GameScreen's CustomActivity:

    mCharacter.Activity();

Add the following to the GameScreen's CustomDestroy:

    mCharacter.Destroy(); // remember to remove the Character when the Screen is destroyed

### Optional Parameter: ContentManagerName

The code above instantiates an entity using the no-argument constructor. Alternatively you can provide a content manager as shown in the following code:

``` lang:c#
mCharacter = new Character(ContentManagerName);
```

The ContentManagerName is only necessary if you are providing a content manager that differs from the current screen. If you are not, or if you aren't sure what that means, you can skip this section. If you're used to C#, then you may know that objects which no longer have references to them are automatically cleaned up by the garbage collector. There are some types of objects which are not automatically cleaned up in FlatRedBall. One category is what is referred to as "content". Content is usually information which is loaded from a file (such as a Texture2D being loaded from a .png file). This information is loaded and cached in a ContentManager. The reason this information is cached is to prevent code from loading the same information twice. For more information on ContentManagers, see [FlatRedBall ContentManager page](/frb/docs/index.php?title=FlatRedBall_Content_Manager "FlatRedBall Content Manager"). All Entities and Screens have a ContentManagerName property. The ContentManagerName property is usually set in every Screen in generated code, and it is passed to any Entity instantiated by that Screen. Any Entity contained in another Entity will get its ContentManagerName from the container Entity, and the contaner gets its ContentManagerName from its container, and so on until the "container tree's" root is found. Therefore, in most cases whenever you instantiate an Entity, you simply need to use ContentManagerName as the argument - it will usually be in scope and it will usually give the desired results.

### Adding an Entity to a Layer

If you create an Entity instance in code, then the Entity is automatically instantiated and added to the FRB managers. While this is convenient, you may want to control how the Entity is added to the FRB managers - specifically you may want to control which Layer the Entity is added to. The following code can be used to add a Character to a Layer called GameLayer:

     bool addToManagers = false;
     mCharacter = new Character(ContentManagerName, addToManagers);
     mCharacter.AddToManagers(GameLayer);

### Adding an Entity to another Entity

You may encounter a situation where you need to dynamically add one Entity to another. For example, consider creating an Entity that displays high scores. You may call this Entity "HighScoreFrame", and it may contain a variable number of Entities called "HighScoreDisplay". Whenever you add an Entity to another, you should use the container Entity's [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer") when adding. The HighScoreDisplay object may be created and added to a [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer"), and if this is the case, then each HighScoreDisplay object that you add should also be added to that [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer"). Here's how to properly create contained Entities so that they appear on the same [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer") as their container:

    // assuming numberToCreate is the number of HighScoreDisplays to create:
    for(int i = 0; i < numberToCreate; i++)
    {
       bool addToManagers = false;
       // We don't want the new HighScoreDisplay to add itself to the managers - we want to tell it to do so
       // on a particular Layer
       HighScoreDisplay newDisplay = new HighScoreDisplay(ContentManagerName, addToManagers);

       // Now we can add it using the container's (this) LayerProvidedByContainer
       newDisplay.AddToManagers(this.LayerProvidedByContainer);

       // Assuming you have an Object in 'this' which is a list of HighScoreDisplays:
       this.HighScoreDisplayList.Add(newDisplay);

       // Now you can finish up whatever you need to do with the newDisplay, like setting its position or what to display
    }

## Adding objects to [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList")

If your Screen is using [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList"), you will likely need to interact with them in custom code. We recommend adding [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList") to your Screens and Entities in Glue so you don't have to worry about common tasks such as every-frame management and removal when destroying Screens and Entities. In other words, if you add an Entity to a PositionedObjectList which is defined in Glue, you don't need to call Activity or Destroy on Entities added to the list. Of course, you may want to manually call Destroy if you want the Entity to be destroyed before the Screen is destroyed. To add objects to a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList"): Assuming Enemy is a valid Entity type and EnemyList is a valid List:

    Enemy newEnemy = new Enemy(ContentManagerName);
    EnemyList.Add(newEnemy);

## Performing Collisions between Entities

The recommended way to perform collision between Entities is to use the CollisionManager. For more information see the [CollisionManager page](/documentation/tutorials/glue-tutorials/basic-coding-in-glue.md). Of course you can also manually write collision loops. For example we'll assume we have two Entities: one called Bullet and one called Enemy:

    for(int enemyIndex = EnemyList.Count - 1; enemyIndex > -1; enemyIndex--)
    {
       Enemy enemy = EnemyList[enemyIndex];
       
       for(int bulletIndex = BulletList.Count - 1; bulletIndex > -1; bulletIndex--)
       {
          Bullet bullet = BulletList[bulletIndex];

          if(enemy.Collision.CollideAgainst(bullet.Collision))
          {
              enemy.TakeDamage(); // do whatever is necessary
              bullet.Destroy();
          }
       }
    }

There are a few things to note in the code above:

-   The code uses "enemyIndex" and "bulletIndex" instead of i and j for the index variables. This can help you avoid bugs in nested for-loops.
-   The for loops are reverse loops. This is because removal may happen in the loops. This makes sure every object will be hit once even if there is removal.
-   The bullet.Destroy call will remove the bullet from the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList") because of its two-way relationship with the list. For more information check [this page](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList#Two_Way_Relationships "FlatRedBall.Math.AttachableList").
-   This code assumes that both Bullet and Enemy have Collision objects, and that they are public. Objects in Glue can be made public by changing "Has Public Property" to true.

## Controlling Entity Movement (and other PositionedObject properties)

All Entities inherit from the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") class. This means they have the following commonly-used members:

-   X
-   Y
-   Z
-   Position (mirrors X, Y, and Z)
-   XVelocity
-   YVelocity
-   ZVelocity
-   Velocity (mirrors XVelocity, YVelocity, ZVelocity)
-   RotationZ

So you could make the Character instance control with an Xbox controller as follows: This would be in the Entity's CustomActivity or method called from CustomActivity:

    // If you want to move faster or slower, this would be a great place to create a variable in Glue
    // in the Entity called MovementSpeed, then multiply the LeftStick's Position by that value.
    this.Velocity = InputManager.Xbox360GamePads[0].LeftStick.Position;

The [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") class is a very powerful class with a lot of functionality. Check out the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") page for more information.

## Moving between Screens

To move to a new Screen, you simply call MoveToScreen in the given Screen's code. For example, assuming you had a Screen called MainMenu, you could do this: This would be in CustomActivity or some method called from CustomActivity:

    if (InputManager.Xbox360GamePads[0].ButtonPushed(Xbox360GamePad.Button.Back))
    {
        MoveToScreen(typeof(MainMenu).FullName);
    }

## Community Discussion

There's a lot to learn about Glue when you're just starting out. Here are some posts that may help answer some of your questions:

-   [Helpful post by Jonathan for moving between Screens](/frb/forum/viewtopic.php?f=24&t=4705)
