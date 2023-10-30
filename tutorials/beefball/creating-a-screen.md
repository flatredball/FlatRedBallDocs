# creating-a-screen

### Introduction

Screens and Entities are two common FlatRedBall concepts. A Screen represents a container for game content and other Entities. Screens define the flow of your game. Often game developers will create many screens up-front to help them think through a game's structure. Here are some examples of Screens in a typical game:

* Game play Screen (like the playing Screen in Pong). This is usually called "GameScreen"
* Splash Screen (like a FlatRedBall logo displaying splash Screen)
* Main menu Screen

### Creating a Screen

As you work with Screens you will find that they are very similar to Entities. To create a Screen:

1.  Click on the **Screens** folder and select the **Add Screen** quick action...

    ![](../../media/2022-01-img\_61d31425ed9b7.png)

    ...or right-click on the **Screens** folder and select **Add Screen**

    ![](../../media/2022-01-img\_61d314538a6f1.png)
2. Uncheck **Add Map LayeredTileMap** option - Beefball doesn't use Tiled maps
3.  Accept the other defaults by clicking **OK.**

    ![](../../media/2022-01-img\_61d3149d379e1.png)

Notice that FlatRedBall suggests the name **GameScreen** for your screen. Recommended practice is to always have the screen where your game takes place called GameScreen. If your game has multiple levels, each level would inherit from GameScreen. Since Beefball does not have mutiple levels, we will only create GameScreen.

### PlayerBallList in GameScreen

By default, your GameScreen now has a PlayerBallList - this is a list which will contain all PlayerBall instances in your GameScreen.

![](../../media/2022-01-img\_61d314ff1f447.png)

If you unchecked the **Add Lists for Entities** option, or if you would like to know how to create lists manually, follow these steps:

1. Select the **PlayerBall** entity
2. Click the **Quick Actions** tab
3. Click the **Add PlayerBall List to GameScreen** button

![](../../media/2022-01-img\_61d315ce2af22.png)

The PlayerBallList object will contain all of the PlayerBalls we plan on adding later. Our game is a two-player game, so it will eventually contain two PlayerBall instances. The PlayerBallList object will be used to define _collision relationships_ in a later tutorial. Collision relationships define which objects can collide with each other (such as players vs the walls) and what to do when they collide (such as performing _bounce physics_).

### Adding an Entity Instance to GameScreen

Once you have at least one Screen in your game (GameScreen), you can add Entity instances to that Screen. Entities can be added through the editor or through game code. The editor provides a number of ways to add an entity:

* Drag+drop an entity on a screen to add an instance... 

<figure><img src="../../media/2016-01-03\_08-28-03.gif" alt=""><figcaption></figcaption></figure>


*   ... or add an instance to the GameScreen by selecting **PlayerBall** and clicking the **Add PlayerBall Instance to GameScreen** quick action. Note that this option will only exist if you have a Screen called GameScreen...

    ![](../../media/2022-01-img\_61d3192850b6c.png)
* ... or add an object to a screen by right-clicking on the GameScreen's **Objects** folder:
  * Right-click on your GameScreen's **Objects** folder
  * Select **Add Object**
  * Select **Entity** as the object type
  * Select **PlayerBall** as the type. The name will automatically be changed to **PlayerBallInstance**
  * Click **OK**

![](../../media/2021-07-img\_60fda9a9b4a8b.png)

####

### Running your Game

Now that you have a PlayerBall instance in your GameScreen, you can run the game to see it. You can run the game through either the FlatRedBall Editor or Visual Studio.

*   To run the game through the editor, click the Play button in the toobar at the top

    ![](../../media/2022-01-img\_61d319bb3bbb3.png)
*   To run the game through Visual Studio, click the Visual Studio icon to open the game in Visual Studio and run it like any other desktop project

    ![](../../media/2022-01-img\_61d319d977080.png)

    ![](../../media/2020-07-img\_5f0a3e6ebc1a6.png)

Once the game runs, you should see a circle (the PlayerBall1 instance) in your Screen.

### ![](../../media/2020-07-img\_5f0a421234957.png)

### FlatRedBall Coordinates

Now that we have an object in our screen we can take a moment to understand how the coordinates in FlatRedBall work. By default, our entity exists at X=0 and Y=0. We can observe this by selecting the entity instance and looking at its Variables tab.

![](../../media/2023-09-img\_650449103c08d.png)

By default the center of the screen is at the origin (0,0), and objects are positioned by their center, so the PlayerBall appears at the center of the screen.

![](../../media/2023-09-img\_65044991b53a6.png)

For more information on how to control the screen's resolution and world units, see the FlatRedBall Resolution section: [https://flatredball.com/documentation/tools/glue-reference/camera/](../../glue-reference/camera.md) For more information on how to control the Camera to change the center of the screen, see the Camera code reference: [https://flatredball.com/documentation/api/flatredball/flatredball-camera/](../../documentation/api/flatredball/camera.md)

### Conclusion

To recap we now have an Entity called PlayerBall which has a Circle. We've also created a GameScreen which contains an instance of our PlayerBall. If we run our game, it will show a white circle (our PlayerBall instance).

We're now ready to start adding some code to our project. The next tutorial will cover controlling your Entity's movement.

[<- Creating an Entity](creating-an-entity.md) -- [Controlling an Entity ->](controlling-an-entity.md)
