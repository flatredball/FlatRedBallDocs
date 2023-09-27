## Introduction

This tutorial shows how to add ice and water collision. We'll be setting up the TileShapeCollections for these two types of tiles, and creating collision relationships to control the interaction between the Player and these tiles.

## Adding Tile Shape Collections

As shown in the previous tutorial, the Player already collides with the solid collision. This is automatically added by the New Project Wizard, so we don't have to do any setup for ground collision. We'll add ice collision first. To do this:

1.  Click **GameScreen**

2.  Select the **Quick Actions** tab and click the **Add Object to Game Screen** button

    ![](/media/2023-02-img_63e037b075cad.png)

3.  Select **TileShapeCollection**

4.  Enter the name **IceCollision**

5.  Click ****OK****

    ![](/media/2021-04-img_6075038fee823.png)

6.  Select the newly-created **IceCollision** object

7.  Click the **TileShapeCollection Properties** tab

8.  Click the **From Type** option

9.  Change the **Source TMX File/Object** to **Map**

10. Change the **Type** to ****IceCollision****

    ![](/media/2023-02-img_63e03832d521a.png)

We'll repeat the process above to create water collision:

1.  Click **GameScreen**

2.  Select the **Quick Actions** tab and click the **Add Object to Game Screen** button

3.  Select **TileShapeCollection**

4.  Enter the name **WaterCollision**

5.  Click ****OK****

6.  Select the newly-created **WaterCollision** object

7.  Click the **TileShapeCollection Properties** tab

8.  Click the **From Type** option

9.  Change the **Source TMX File/Object** to **Map**

10. Change the **Type** to ******Water******

    ![](/media/2023-02-img_63e03881857da.png)

## Creating Collision Relationships

Now our game has two new collision relationships: IceCollision and WaterCollision. This means that when our game runs, collision shapes are created based on the water and ice tiles, but we haven't yet told the game how to handle collisions between the Player and these collision relationships. First, we'll set up collisions between the Player and IceCollision:

1.  Drag+drop **PlayerList** onto **IceCollision** [![](/wp-content/uploads/2021/04/05_16-16-01.gif.md)](/wp-content/uploads/2021/04/05_16-16-01.gif.md)

The newly-created PlayerVsIceCollision is automatically set up to use **Platformer Solid Collision** physics, so we don't need to make any changes. We also need to create collision between **PlayerList** and **WaterCollision**, but this time we need to disable **Platformer Solid Collision** since the Player should be able to fall into the water. To do this, drag+drop **PlayerList** onto **WaterCollision** and select **No Physics**. [![](/wp-content/uploads/2021/04/05_16-18-42.gif.md)](/wp-content/uploads/2021/04/05_16-18-42.gif.md) Now if we run our game we can collide with the ice tiles and fall through water. [![](/wp-content/uploads/2021/04/05_16-20-22.gif.md)](/wp-content/uploads/2021/04/05_16-20-22.gif.md)

## Conclusion

Now our game has ice and water TileShapeCollections and collision relationships. You may have noticed that the ice currently acts identical to solid collision (bricks). The next tutorial will create new platformer variables for moving on ice and swimming in water, and will switch between them in response to collision.  
