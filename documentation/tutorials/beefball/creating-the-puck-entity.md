## Introduction

Now that we have our PlayerBall movement working, we'll add a Puck Entity which the user can hit around. You'll find that the Puck is very similar to the PlayerBall.

## Creating a Puck Entity

To create a Puck Entity:

1.  Click on the Quick Actions tab

2.  Click the **Add Entity** button

3.  Name the Entity **Puck**

4.  Check the **Circle** check box under **Collisions**

5.  Verify that **ICollidable** is checked (it should be checked automatically when **Circle** is checked)

    ![](/media/2021-07-img_60fdc0904b245.png)

6.  Click **OK**

The Puck entity should appear in Glue.

![](/media/2021-07-img_60fdcb7c2a8d0.png)

For more information on how to perform the above steps, you may want to review the tutorial which created the PlayerBall Entity [here](/frb/docs/index.php?title=Tutorials:Beefball:Creating_an_Entity "Tutorials:Beefball:Creating an Entity").

## Differentiating the Puck

Currently our Puck and PlayerBall both have Circle bodies, and by default the Circles will have the same size and color. To differentiate the Puck from the PlayerBall:

1.  Expand the **Puck** entity
2.  Click on the **CircleInstance** object under the Puck Entity
3.  Click the **Variables** tab
4.  Find the **Color** variable
5.  Change the value to **Red** using the drop-down
6.  Change the **Radius** value to **6**

![](/media/2021-07-img_60fdcaad89ad8.png)

**Computer settings matter:** If your computer is set up so the decimal separator is the comma ',' instead of the period '.' then you should enter values using the ',' character. Unlike C# code, Glue obeys your computer's language settings.

## PuckList in GameScreen

By default the FlatRedBall Editor adds lists of newly-created entities to the GameScreen. Therefore, you should already have a PuckList in your GameScreen.

![](/media/2023-08-img_64cbe9fc4ec5c.png)

If you unchecked the option, or if you would like to know how to manually add a PuckList to your GameScreen, the following section shows how to add a list. **This is not necessary if you kept the defaults.**

## (Optional) Adding a PuckList Manually

## 

1.  Click the Puck entity

2.  Select the **Quick Actions** tab

3.  Click the **Add Puck List to GameScreen** button

    ![](/media/2021-07-img_60fdc158af7ad.png)

## Adding a Puck Instance

1.  Select the **Puck** entity

2.  Click the **Add Puck Instance to GameScreen** button

    ![](/media/2021-07-img_60fdc1cc87873.png)

Now the GameScreen has a list and a single Puck.

![](/media/2021-07-img_60fdc2338ca81.png)

## Positioning your objects

If you run your game or view it in GlueView you'll notice that the PlayerBallInstance and PuckInstance are both at the center of the Screen. Let's reposition the PlayerBall1:

1.  Select the PlayerBall1 object under your GameScreen
2.  Change the X value to -180

![](/media/2021-07-img_60fdc27406b6b.png)

## Puck Collision

Now that we have a Puck in our game, we need to create two collision relationships:

1.  Puck vs Walls - this prevents the Puck from moving through the walls.
2.  Puck vs PlayerBall - this allows the PlayerBall to "hit" the puck to try to score a goal. We haven't yet created the handling of goals, but this is the first step towards implementing that feature.

We will create these two collision relationships just like the previou PlayerListVsWall collision relationship. To create a relationship between the PuckList and Wall:

1.  Expand **GameScreen's Objects** folder in Glue
2.  Drag+drop the **PuckList** onto the **Walls** object
3.  Select the new **PuckListVsWalls** collision relationship
4.  Select the **Collisions** tab
5.  Set the **Collision Physics** to **Bounce**
6.  Change the **Puck Mass** to **0**
7.  Optionally adjust the Elasticity value

[![](/media/2016-01-2021_July_25_141703.gif)](/media/2016-01-2021_July_25_141703.gif) To create a relationship between the PuckList and PlayerBallList:

1.  Expand **GameScreen's Objects** folder in Glue
2.  Drag+drop the **PlayerBallList** onto the **PuckList** object
3.  Select the new **PlayerBallListVsPuckList** collision relationship
4.  Select the **Collisions** tab
5.  Set the **Collision Physics** to **Bounce**
6.  Change the **Puck Mass** to **0.3** - this will make it 30% the mass of the PlayerBall
7.  Optionally adjust the Elasticity value

[![](/media/2016-01-2021_July_25_145507.gif)](/media/2016-01-2021_July_25_145507.gif)   Notice that the mass variables for PlayerInstance vs. PuckInstance differ compared to wall collision. The PuckInstance is given a mass of .3 relative to a mass of 1 for the PlayerInstance, resulting in the PuckInstance behaving as if it has 30% of the mass of the PlayerInstance. If you run the game, you should be able to hit the Puck around the level. [![](/media/2016-01-2021_July_25_140010.gif)](/media/2016-01-2021_July_25_140010.gif)

## Adding Drag

Currently the Puck will move indefinitely after being hit. We'll assign the Drag value to the Puck just like we did to PlayerBall:

1.  Select the **Puck** Entity in Glue
2.  Select the **Variables** tab
3.  Click the **Add New Variable** button
4.  Select the **Expose an existing variable** option
5.  Select the value **Drag**
6.  Enter a value of **0.4** for **Drag**

![](/media/2021-07-img_60fdc59ea563f.png)

Now the Puck will slow down over time just like the PlayerBall. [\<- Advanced PlayerBall Controls](/documentation/tutorials/beefball/advanced-playerball-controls.md "Tutorials:Beefball:Advanced PlayerBall Controls") -- [Adding multiple players -\>](/documentation/tutorials/beefball/adding-multiple-players.md "Tutorials:Beefball:Adding multiple players")
