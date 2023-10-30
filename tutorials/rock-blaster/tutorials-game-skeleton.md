# Game Skeleton

### Introduction

So far we have created an simple project called Rock Blaster. Next we will create a skeleton for our game.

### A skeleton...with bones?

When we refer to a game skeleton, we mean an initial setup which contains empty or nearly-empty Screens and Entities. We are not referring to an actual skeleton, but rather the simplified structure that a skeleton implies.

![NoSkeleton.png](../../media/migrated\_media-NoSkeleton.png)&#x20;

Creating a skeleton is a great exercise because it can quickly get you to think about what your game will contain. You can add Screens and Entities as you think them up because there is no implementation required. As you become more experienced with making games (especially with Glue) you will find it easier to create skeletons.

### How to start creating a skeleton

The first step is purely conceptual. You can start creating a skeleton with any tool that you find comfortable. You may prefer to use a simple text or spreadsheet document, or perhaps you prefer to write a list on a piece of paper. The point of this step is to create a list of screens and entities which you expect to include in your game. This game will be about flying a space ship, shooting rocks, and attempting to stay alive long enough to earn a high score. The Glue Wizard has already taken care of creating our screens (GameScreen and Level1) so we don't need to do anything with screens fo rnow. We'll create a list of Entities needed for our game:

* Player (already created by the Glue Wizard)
* Rock
* Bullet
* Hud (will be made in Gum)
* HealthBar (will be made in Gum)
* EndGameUi (will be made in Gum)

### What if we don't think of everything?

If you don't think of all of the Screens and Entities that you'll need, that's okay! The purpose of this isn't to fully define the game, but rather to get you to think about the game from a development perspective - something which you may not do immediately when you think up a game idea. Working through the Screen and Entity list may help you realize things that you may need.

### Creating the skeleton

Now that we created a list of things that we need in our game, we will start by adding the entities.

**You are modifying your Visual Studio Project** All of the work that you do in Glue results mainly in code being generated and in your Visual Studio project (.csproj) being modified. Although Visual Studio will automatically reload any changes to any projects, it will also notify you that the project has changed. As you work with Glue you may encounter popups in Visual Studio notifying you that things have changed. Don't worry, this is expected behavior - your projects will continue to work just fine.

Let's start with the Rock entity:

1. Select the **Quick Actions** tab in Glue
2.  Click **Add Entity**

    ![](../../media/2021-03-img\_604cdc3e88ab2.png)
3. Enter the name **Rock**
4. Check the **Circle** option. We check this option to identify that our Rock entity can collide with other objects (such as our Player) and that the collision shape is a circle.
5. Click OK

![](../../media/2021-03-img\_604cdc96adfb4.png)

To add the bullet, repeat the steps above, but this time name the entity **Bullet**. Otherwise, all options should be the same including **Circle** collision.

![](../../media/2021-03-img\_604cdd111f81c.png)

### Adding Entity Lists to GameScreen

Now we have three entities in our game: Player, Bullet, and Rock. Our GameScreen already has a PlayerList - this was added by the Glue Wizard. Next let's add lists for our Bullet and Rock entities. Consider that our game will probably allow the player to shoot more than one bullet at a time, and that our game will have more than one rock on screen at a time. Therefore, we add a list instead of a single instance. Also, as a general rule of thumb, whenever we add lists to the GameScreen, we also need to add a factory for that entity. Factories make it easier to create new entity instances in code, which we'll be doing in a later tutorial. To lists and factories for our Rock and Bullet entities:

1. Select the **Rock** entity
2. Select the **Quick Actions** tab
3.  Click the **Add Rock List to GameScreen** button

    ![](../../media/2021-03-img\_604ce7b4c3013.png)
4.  Click the **Add Rock Factory** button

    ![](../../media/2021-03-img\_604ce81a9c62e.png)

Repeat the steps above for the Bullet entity:

1. Select the **Bullet** entity
2. Select the **Quick Actions** tab
3. Click the **Add Bullet List to GameScreen** button
4. Click the **Add Bullet Factory** button

You should now have a **BulletList** and **RockList** in the GameScreen.

![](../../media/2021-03-img\_604cec80d6343.png)

Notice that we have a PlayerList in the game, which suggests that Rock Blaster is a multi-player game. In practice, we recommend a PlayerList even if you intend to make your game single-player. There's no downside to using a PlayerList and it helps keep code consistent. In short, it's best to always have a PlayerList.

### Conclusion

Wow! Even though our game isn't functional yet, we have done a lot of work defining the skeleton - and it shows in Glue too. Next we'll work on the Player visuals. [<- 02. Setup](tutorials-setup.md) -- [04. Player Entity ->](tutorials-main-ship-entity.md)
