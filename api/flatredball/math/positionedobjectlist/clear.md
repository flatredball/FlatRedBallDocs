## Introduction

The Clear function is a function that will empty a PositionedObjectList of all contained references - it operates the same way as calling Clear on a normal List. However, although Clear is a very common function when dealing with regular Lists, it is not often used on PositionedObjectLists.

If you are using Clear, make sure you understand the information discussed in this wiki.

## Why should Clear (usually) not be used on PositionedObjectLists made in Glue?

The Clear function should usually not be used when dealing with lists in Glue. Let's investigate why this is the case. For this discussion we'll assume that your game has an Entity called Bullet, and that your Screen has a PositionedObjectList of Bullets which will is called BulletList.

In this example the BulletList will have bullets added to it. Sample code for this might look like:

    if(InputManager.Keyboard.KeyPushed(Keys.Space))
    {
        Entities.Bullet bullet = new Entities.Bullet();
        BulletList.AddBullet(bullet);
    }

You might expect that simply calling BulletList.Clear will remove all bullets from your game; however, this is not the case. To understand this, let's add some comments to the code listed above so we can understand what is happening:

    // The if-statement checks to see if the user pressed the space bar:
    if(InputManager.Keyboard.KeyPushed(Keys.Space))
    {
        // The following line of code creates a bullet.  Note that
        // when a new Bullet is created, it is instantiated and also added
        // to the engine.  That means that if the bullet has a Sprite, it will
        // be drawn, and if the bullet has velocity, it will move.  You do not have
        // to add the bullet to the BulletList for the Engine to have a reference to
        // this new Bullet.
        Entities.Bullet bullet = new Entities.Bullet();
        // The following line of code adds the bullet to the BulletList stored in your
        // Screen.  There are two reasons why this is typically done:
        // 1.  So that you can use the BulletList in your screen to check for collision
        //     or any other custom logic.
        // 2.  So that Glue can generate code to automatically clean up all Bullets when
        //     the Screen is destroyed.
        BulletList.AddBullet(bullet);
    }

The important thing to note here is that calling BulletList.AddBullet **is not required for the bullet to be drawn and updated**. The reason is because the reference to your new bullet is stored in two places:

1.  The FlatRedBall Engine
2.  The BulletList

Since the new Bullet is stored by both the FlatRedBall Engine as well as the BulletList, then to fully-destroy the Bullet it must be removed from both the FlatRedBall Engine as well as the BulletList.

However, the Clear function will **only remove the Bullet from the BulletList**. Calling Clear will result in the BulletList being empty, but the Bullets will still be a part of the engine.

Since this is such common behavior in FlatRedBall, all Entities have a Destroy method. When Destroy is called, the Entity removes itself from **both** the FlatRedBall Engine **and** any PositionedObjectList it is a part of. This is why the preferred method of clearing a list is to call Destroy on the contained objects:

    for(int i = ButtonList.Count - 1; i > -1; i--)
    {
        ButtonList[i].Destroy();
    }
