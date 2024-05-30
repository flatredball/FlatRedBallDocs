# Game Skeleton

### Introduction

So far we have created an simple project called Rock Blaster. Next we will create a skeleton for our game.

### A skeleton...with bones?

When we refer to a game skeleton, we mean an initial setup which contains empty or nearly-empty Screens and Entities. We are not referring to an actual skeleton, but rather the simplified structure that a skeleton implies.

![No, not that kind of skeleton...](../../media/migrated\_media-NoSkeleton.png)

Creating a skeleton is a great exercise because it can quickly get you to think about what your game will contain. You can add Screens and Entities as you think them up because there is no implementation required. As you become more experienced with making games (especially with FlatRedBall) you will find it easier to create skeletons.

### How to start creating a skeleton

The first step is purely conceptual. You can start creating a skeleton with any tool that you find comfortable. You may prefer to use a simple text or spreadsheet document, or perhaps you prefer to write a list on a piece of paper. The point of this step is to create a list of screens and entities which you expect to include in your game.

This game will be about flying a space ship, shooting rocks, and attempting to stay alive long enough to earn a high score. The Wizard has already taken care of creating our screens (GameScreen and Level1) so we don't need to list Screens as we think about our game skeleton. We'll create a list of Entities needed for our game:

* Player (already created by the Wizard Wizard)
* Rock
* Bullet
* Hud (will be made in Gum)
* HealthBar (will be made in Gum)
* EndGameUi (will be made in Gum)

### What if we don't think of everything?

If you don't think of all of the Screens and Entities that you'll need, that's okay! The purpose of this isn't to fully define the game, but rather to get you to think about the game from a development perspective - something which you may not do immediately when you think up a game idea. Working through the Screen and Entity list may help you realize things that you may need.

### Creating the skeleton

Now that we created a list of things that we need in our game, we will start by adding the entities.

**Remember, you are modifying your Visual Studio Project.** All of the work that you do in the FlatRedBall Editor results mainly in code being generated and your Visual Studio project (.csproj) being modified. Normally this "just works" - when you add things to FRB, they automatically show up in Visual Studio. However, keep in mind that any changes made in Visual Studio (such as adding new classes) will not be picked up by FlatRedBall until you save your project. It's best to get in the habit of saving your Visual Studio project after you add any new files.

For now, we'll work in the FRB Editor to add our entities. Let's start with the Rock entity:

1. Select the **Quick Actions** tab in FlatRedBall
2.  Click **Add Entity**

    ![](<../../.gitbook/assets/18\_05 14 43.png>)
3. Enter the name **Rock**
4. Check the **Circle** option. We check this option to identify that our Rock entity can collide with other objects (such as our Player) and that the collision shape is a circle.
5. Leave the other defaults checked
6. Click OK

![](<../../.gitbook/assets/18\_05 16 14.png>)

To add the Bullet entity, repeat the steps above, but this time name the entity **Bullet**. Otherwise, all options should be the same including **Circle** collision.

![](<../../.gitbook/assets/18\_05 17 11.png>)

Now you should have two new entities - Bullet and Rock.

<figure><img src="../../.gitbook/assets/image (41).png" alt=""><figcaption><p>Bullet and Rock Entities</p></figcaption></figure>

You may have noticed that the window for creating new entities has two options checked

* Create Factory
* Include lists in GameScreen

<figure><img src="../../.gitbook/assets/18_05 18 18.png" alt=""><figcaption></figcaption></figure>

Both of these options are checked by default because they are used in most games.&#x20;

The **Create Factory** option results in FlatRedBall generating a Factory object. Factories are used to simplify the creation of new instances of an entity. They are responsible for adding new instances to their necessary lists, providing events for when new objects are created, and can improve the performance of your game through pooling and better sorting. We will be using Factories in later tutorials when we create bullet Bullet and Rock instances.

The Include lists in GameScreen option results in lists being added automatically to the GameScreen. If you are creating an entity which will collide with other entities, this is almost always handled through lists in GameScreen. We can verify that our GameScreen now has lists by expanding its Objects folder.

<figure><img src="../../.gitbook/assets/image (42).png" alt=""><figcaption></figcaption></figure>

### Conclusion

Now that we have created two new entities (Rock and Bullet), we have the basis for a game. We'll continue in the next tutorial by working on the Player entity.
