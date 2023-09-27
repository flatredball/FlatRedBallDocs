## Introduction

One of the most important concepts in programming (and using Glue) is exposing and limiting access to object properties and methods appropriately. If you expose too much, then you risk a complex interface, create dependencies which make reuse difficult, eliminate the option of encouraging best practices through interface, and clutter up your auto-complete functionality in your IDE. Of course if you limit too much, you make it difficult for one object to access information that it needs from other objects. This article discusses a very specific yet common case in games: access and ownership of shared [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList").

## The Scenario

For starters let's look at a very common situation where this problem is encountered. You're working on a [shoot 'em up](http://en.wikipedia.org/wiki/Shoot_'em_up) game like [1942](http://en.wikipedia.org/wiki/1942_(video_game)) or [R-Type](http://en.wikipedia.org/wiki/R-Type) which includes a Player Entity (the ship), Bullet Entity (fired by the Player), and a GameScreen. In this type of game you typically would also have an Enemy Entity which we'll mention throughout the discussion, but we won't actually create an Enemy Entity for the sake of simplicity. Typically the GameScreen stores individual instances and [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") of all objects involved. In other words, the Screen may have a PlayerInstance object, EnemyList object, and BulletList object. The GameScreen then performs collision between the different classes of objects: Player vs. Enemies, Bullet vs. Enemies, and so on. This approach makes sense because the GameScreen ultimately "owns" these objects - it creates these objects and it is responsible (either through generated or custom code) for destroying these objects when the Screen is destroyed. Since Glue supports the creation of PositionedObjectList Objects, then it also makes sense to add these objects to your GameScreen through Glue. Therefore, we will have the following situation: ![CreatedByOtherEntities1.png](/media/migrated_media-CreatedByOtherEntities1.png) Specifically, things to note:

-   There is a Player Entity
-   There is a Bullet Entity
-   There is a GameScreen Screen
-   There is a PlayerInstance Object in GameScreen of type Player
-   There is a BulletList Object in GameScreen of type PositionedObjectList\<Bullet\>

## Writing the Bullet creation code...or trying to

Next we'll look at the code that creates bullets. It's best if the Player contains all of its logic, so this function is a method called from the Player's Activity method:

    private void CustomActivity()
    {
        BulletCreationActivity();
    }

    private void BulletCreationActivity()
    {
        // The Space key will fire a bullet
        if (InputManager.Keyboard.KeyPushed(Keys.Space))
        {
            Bullet newBulletInstance = new Bullet(ContentManagerName);

            // but....where do we put the newBulletInstance???
        }
    }

The newly-created Bullet needs to end up in the GameScreen's list, but how? The Player doesn't have a reference to the list, nor does the Screen expose the List publicly. Both of these options would work, but each one introduces some problems. The Player could be given a reference to the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") by the Screen. However, this means that custom code must be written to hook this up, and if multiple objects can create bullets, each one must be given access to the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList"). It may not seem like a big deal in this case because we're only working with one object - the Player - which can create Bullets; however, this tutorial is meant to be a general-purpose discussion about how to share lists, and there are many other situations where multiple types of objects can create the same kind of Entity. And in such a situation, you need to make sure that you write custom code to receive and use the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") in every type, and you must also make sure that your Screen properly assigns the reference for every instance. Glue offers a solution which requires less work. The other solution mentioned is to publicly expose the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") through the GameScreen. To support this we would either have to pass a GameScreen reference to the Player, or the GameScreen would need to publicly, statically expose its [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") through a singleton-like pattern. But both cases require that the Player code uses the GameScreen class. In other words, the Player code must reference the GameScreen class in its logic. This is undesirable because it means the Player is written to work specifically with the GameScreen class. This causes problems if you decide to add a Player to a different Screen, and it also hurts portability as the Player class can only be used in projects which contain the GameScreen class as well. Again, these may seem like small issues in this particular example, but the pattern promoted in this article solves these problems elegantly, allowing you to create much more reusable and clean code.

## Factories as the Solution

The solution to this problem is to create a middle-man. This middle man will be called "BulletFactory". The BulletFactory is a class which creates Bullet instances, and provides a way for the Player Entity (or any other Entity) to add Bullets to the GameScreens [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList").

## Creating the Factory

Let's start in Glue first. To create a Factory:

1.  Select your Bullet entity
2.  Set the **Created By Other Entities** property to **True** ![SetCreatedByOtherEntities.png](/media/migrated_media-SetCreatedByOtherEntities.png)

That's it! Now your game contains a BulletFactory class which you can use in your code. Note that we won't be worrying about pooling in this tutorial. Pooling requires a little extra work to function properly, and this is beyond the scope of this particular tutorial. For information on pooling check [this page](/frb/docs/index.php?title=Glue:Reference:Entities:PooledByFactory.md "Glue:Reference:Entities:PooledByFactory"). ![SetPooledByFactoryToFalse.png](/media/migrated_media-SetPooledByFactoryToFalse.png)  

## Using the Factory in code

Using a Factory couldn't be easier. Creating a Bullet now takes 1 line to create and then you can modify the bullet (such as set its position)...that's it! Modify your code to match the following snippet:

    private void CustomActivity()
    {
        BulletCreationActivity();
    }

    private void BulletCreationActivity()
    {
        // The Space key will fire a bullet
        if (InputManager.Keyboard.KeyPushed(Keys.Space))
        {
            var newBulletInstance = Factories.BulletFactory.CreateNew();
            newBulletInstance.X = this.X;
            newBulletInstance.Y = this.Y;
        }
    }

 

## That's it, really!

At this point we could end the tutorial because we've accomplished what we've set out to do. Our Player creates Bullets through a factory, and the Bullets are placed in the GameScreen's BulletList. "But wait!" you may be thinking, "How are the Bullets being added to the GameScreen's [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList")? I don't see any code that does that." You're right, the code that does all of this is happening behind the scenes; however, we should explain how this all works so you're not left scratching your head.

## How does this all work?

The reason this works with so little hookup on your part is because of assumptions Glue makes regarding this pattern. There are a few things which must happen for this to work correctly:

1.  The Bullet Entity that is to be put in a List must have "Created By Other Entities" set to True
2.  Any code that creates the Bullet Entity must do so through the Bullet Factory
3.  There must be a PositionedObjectList for Bullets in the current Screen

The third point is the critical element that Glue requires to do the hookup. Whenever you create a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") of an Entity which is Created By Other Entities, Glue assumes that you want that [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") to be the "master List". In other words, it assumes that you will only have one [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") in a given Screen created in Glue for this type, and that this [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") is the one that will be used for collision and any other behavior. Therefore, the generated code for your Screen tells the BulletFactory that this [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") should be filled whenever a new instance is created. You can check this if you look in the GameScreen.Generated.cs in side the Initialize method:

    BulletFactory.Initialize(BulletList, ContentManagerName);

You'll notice that the BulletFactory's Initialize method does two things:

1.  It takes a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") which it will stuff any new Bullets into. This is the BulletList that we created in Glue.
2.  It takes a content manager. This simplifies the interface so that you don't have to pass any arguments to the CreateNew method on the BulletFactory.

If you're really curious how this works internally, you can look in the BulletFactory.Generated.cs file. Note this code in the CreateNew method:

    if (mScreenListReference != null)
    {
        mScreenListReference.Add(instance);
    }

This line of code stuffs the newly-created Bullet (named "instance") in the mScreenListReference, which is a reference to the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") passed in the Initialize method. If you want to know more about how lists and factories work, especially if you are using inheritance, check [the page on the Factory.Initialize method here](/frb/docs/index.php?title=Glue:Reference:Factory:Initialize.md "Glue:Reference:Factory:Initialize").

## This works in any Screen

Now that you have set this up, all you have to do is add a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") of type Bullet to any Screen (through Glue) and any object that uses the BulletFactory will automatically populate this list. There is no extra hookup required, and your Entities do not need to know about the Screen that they are working with.
