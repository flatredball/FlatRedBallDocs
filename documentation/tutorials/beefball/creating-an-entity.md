## Introduction

This tutorial will cover how to create an Entity, which is the FRB term for a "game object". Examples of entities include:

-   Game characters (like Mario)
-   Projectiles (like a bullet)
-   UI elements (like a button)
-   Text objects (like a score display)

Our first entity will be called "PlayerBall".

## Creating PlayerBall

To create an Entity:

1.  Click the **Add Entity** in the **Quick Actions** tab ****

    ![](/media/2022-01-img_61d3125436c42.png)

    or right-click on the **Entities** folder and select **Add Entity**

    ![](/media/2022-01-img_61d312843f359.png)

2.  Enter the name **PlayerBall**

3.  Check the **Circle** checkbox under the **Collisions** category. This will add a circle object to our entity, which we'll use to test if the **PlayerBall** is touching the walls, goals, or other ball instances.

4.  Notice that the **ICollidable** checkbox is checked - we'll cover this in a later tutorial. We'll leave it checked for now.

5.  Notice that **Create Factory** is also checked. This option simplifies the creation of additional entities in code. We'll leave this checked as well.

6.  Click **OK**

![](/media/2022-01-img_61d312b26d918.png)

Our entity will now be created and have a Circle named **CircleInstance** under its **Objects** folder, as shown in the following image:

![](/media/2022-01-img_61d312e83c316.png)

## Alternative Approach - Adding a Circle

The previous section showed how to create an entity and add a Circle to the entity at the same time. Objects can be added after an entity is created as well. **Note, the following steps are only shown for example, and do not need to be followed if you performed the previous steps.** To add a Circle to an already-created entity:

1.  Click the **Add Object** quick action

    ![](/media/2022-01-img_61d3133fc9c72.png)

    or right-click on **Objects** and select **Add Object**

    ![](/media/2022-01-img_61d31363d6568.png)

2.  Select the **FlatRedBall Or Custom Type** option

3.  Select **Circle** in the list

4.  Enter the name **CircleInstance** and click **OK**

    ![](/media/2022-01-img_61d313aa162c3.png)

## Conclusion

At this point our project has a PlayerBall Entity which is ready to be used in a game. Of course, we haven't yet created an instance of the newly-created Entity, so if you run your game you won't see it (yet). The next tutorial will create a Screen which will contain our PlayerBall Entity. [\<- Create a Glue Project](/documentation/tutorials/tutorials-beefball/tutorials-beefball-creating-a-glue-project.md "Tutorials:Beefball:Creating a Glue project") -- [Create a Screen -\>](/documentation/tutorials/tutorials-beefball/tutorials-beefball-creating-a-screen.md "Tutorials:Beefball:Creating a Screen")
