## Introduction

Continuing the series of interface settings in Glue is the "Implements IVisible" property. You can probably guess what this means right away. If you've guessed that it gives your Entity a "Visible" property, then you're right!

## Benefits of IVisible

Just like the IWindow and IClickable properties, the great thing about the IVisible property is that it is reactive and recursive. What do we mean by that:

-   Reactive - If you ever change your Entity, such as by adding another Sprite, or even another Entity to it, then the code will automatically react to that change and update to set the Visible on these new objects. This means that there is no maintenance to the Visible property. If you were to implement this in code by hand, you would have to modify the Visible property whenever you add a new object.
-   Recursive - Since you can set any Entity to be IVisible, you can then set the Visible property on an Entity that contains sub-entities, and all will be set to be visible or invisible as appropriate.

## How to use IVisible

Setting IVisible is as simple as setting the other interface values:

1.  Select the Entity you would like to make IVisible
2.  Change the "Implements IVisible" property to "True"![ImplementsIVisible.png](/media/migrated_media-ImplementsIVisible.png)

At this point you will be able to simply set the Visible property on any instance of the given Entity you have set this to true on, and as always, with the help of auto-complete:![VisibleInVisualStudio.png](/media/migrated_media-VisibleInVisualStudio.png)

## Visible vs. States

While the Visible property is very useful, you may not always want to use it. There are times when States are preferred. If you are not familiar with States, you will want to read through [this tutorial on States](/frb/docs/index.php?title=Glue:Tutorials:States.md "Glue:Tutorials:States") first.

Let's consider a situation where you have an Entity which we'll call GameResults. GameResults is used to tell the user whether Player 1 or Player 2 has won. Instead of using Text objects, you are using Sprites for the "Player 1 Wins!" and "Player 2 Wins!" display. Therefore, GameResults has three Objects (all Sprites):

-   BackgroundFrame
-   PlayerOneWins
-   PlayerTwoWins

![GameResultsInGlue.png](/media/migrated_media-GameResultsInGlue.png)

To continue defining the scenario, the GameScreen Screen has an instance of GameResults. As expected, when this instance is added to the GameScreen and the game is run, the GameResults is showing. To solve this, you decide to make the GameResults "Implement IVisible", then set its Visible to false in CustomInitialize of the GameScreen.

All seems fine, but there is one small problem. When you set Visible = true; when the game ends, the GameResults appears, but shows both the PlayerOneWins and PlayerTwoWins. The reason is because all Objects inside the GameResults get set to Visible - the BackgroundFrame, PlayerOneWins, and PlayerTwoWins.

This can easily be solved using States. Since the GameResults needs to set some things to visible and some things to invisible, we'll want to use States to control visibility. The first thing we need to do is create variables to control the Visibility of the Entity as a whole as well as the Visibility of the PlayerOneWins and PlayerTwoWins Sprites:

1.  Create three states: Invisible, PlayerOneWinsVisible, PlayerTwoVisible. Review [this tutorial on States](/frb/docs/index.php?title=Glue:Tutorials:States.md "Glue:Tutorials:States") for information on how to do this if you're not sure.
2.  Right-click on Variables and select "Add Variable"
3.  Select "Visible" from the drop-down and click OK.
4.  Right-click on Variables again and select "Add Variable"
5.  Select the "Tunneling" tab
6.  Select "PlayerOneWins" for Object
7.  Select "Visible" for Variable
8.  Click OK
9.  Repeat to tunnel in to PlayerTwoWins' Visible property![VisiblePropertiesToUseInStates.png](/media/migrated_media-VisiblePropertiesToUseInStates.png)

Now that the three variables have been created, we can create the three necessary states. First, we'll just define the three empty states:

1.  Right-click on the States item, and select "Add State"
2.  Enter the name "AllInvisible" and click OK
3.  Repeat the steps above to create a state called "PlayerOneVisible" and "PlayerTwoVisible"![EmptyStates.png](/media/migrated_media-EmptyStates.png)

Finally, we can fill in the variables for the states. The AllInvisible one is the easiest:

1.  Select the AllInvisible property
2.  Change the "Visible" variable to "False"![VisibleInStateToFalse.png](/media/migrated_media-VisibleInStateToFalse.png)
3.  Select the "PlayerOneVisible" state
4.  Set the "Visible" to "True" and the "PlayerTwoWinsVisible" to "False"![PlayerOneVisibleState.png](/media/migrated_media-PlayerOneVisibleState.png)
5.  Select the "PlayerTwoVisible" state
6.  Set the "Visible" to "True" and the "PlayerOneWinsVisible" to "False"![PlayerTwoVisibleState.png](/media/migrated_media-PlayerTwoVisibleState.png)

This last section may be a little confusing, so let's cover why we made the states the way we did. The first State (AllInvisible) was the easiest one. This one sets the Visible property on the Entity to false, which sets the Visibility of all contained elements to false.

The second state (PlayerOneVisible) sets the entire Entity's Visible to true, which turns on all Sprites. We then want to turn off the visibility of the PlayerTwoSprite, so we do that by setting PlayerTwoWinsVisible to false. This turns off the PlayerTwoWins Sprite, but leaves the other Sprites untouched.

The PlayerTwoVisible state follows the same pattern as PlayerOneVisible - it turns everything on, then turns the PlayerOneWinsVisible variable to false.

The reason this method works is because States set variables in the order that they appear in Glue. If at some point in the future you come across a situation where you need to re-order variables, you can do so simply by right-clicking on a Variable and selecting the appropriate action to move it up or down![RightClickToReorderVariables.png](/media/migrated_media-RightClickToReorderVariables.png).

## IVisible and Lists

If you are working with Entities which implement the IVisible interface through Glue, then you may appreciate the IVisible property makes all objects in an Entity visible/invisible when the Visible property is set. Furthermore, if you add a new object to an Entity that implements IVisible, Glue will automatically generate the code for making that object visible/invisible in the container's Visible property. Therefore, it may seem as if all you have to do is make an Entity implement IVisible and any object it contains will automatically use its container's Visible property. This is **almost** true, but there is something to keep in mind.

The generated code for the Visible property loops through all contained objects and setting their Visible property and setting a simple bool so the getter works as expected. This means that for an object to be set as visible/invisible, it must be done so in the generated code. You may be thinking "Great, since I add all of my objects through Glue anyway, then everything should work as expected." That's true, but what if you don't add your objects to Glue?

More specifically, you can add PositionedObjectLists in Glue, but you can populate them in custom code. When this happens, what exactly will the Visible property do? The answer depends on the order of how things are called. The Visible property in IVisible Entities will loop through all objects in any contained PositionedObjectLists (assuming they are themselves IVisible) and set their Visible property appropriately. Therefore if the order is:

1.  Add objects to a PositionedObjectList in custom code
2.  Set the Visible property

Then all will work as expected. However if instead you

1.  Set the Visible property (to false)
2.  Add objects to a PositionedObjectList in custom code

All of your newly-added Entities that you've added to your PositionedObjectList will be visible - even though the rest of your Entity is invisible. Let's look at some code examples:

    // This is okay:
    positionedObjectListOfEnemies.Add(new Enemy(ContentManagerName));
    this.Visible = false; // assuming Enemy is also IVisible, this will make the newly-added Entity invisible

    // This is not okay:
    this.Visible = false;
    positionedObjectListOfEnemies.Add(new Enemy(ContentManagerName));

    // But this is okay:
    this.Visible = false
    Enemy newEnemy = new Enemy(ContentManagerName);
    positionedObjectListOfEnemies.Add(newEnemy);
    newEnemy.Visible = this.Visible; // forces the new Entity to use the current visibility
    // And now that the enemy is part of the positionedObjectListOfEnemies, any future calls to Visible will work as expected

## Conclusion

That wraps up the Implements IVisible property. In closing, as you create your Entities, keep in mind whether it's acceptable for the entire Entity to be visible/invisible, or whether you should make States to handle flipping visibility.
