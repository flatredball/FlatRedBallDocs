## Introduction

This tutorial covers how to read input to move a platformer entity. We will also be creating a level to test out our platformer entity. To create a level and collision, we will be using a Tiled level. For more detail on how to create Tiled levels, see the [Tiled tutorial](/documentation/tools/tiled-plugin/using-the-tiled-plugin.md).

## Adding a Level

Next we'll add a level. To add a level:

1.  Click on the **Quick Actions** tab in Glue
2.  Click **Add Screen/Level**
3.  Enter the name **Level1**
4.  Check the **Add Standard TMX File** option
5.  Click **OK**

![](/media/2021-02-img_60329d77e6082.png)

Glue will ask you to name the new map. Enter the name **Level1Map** and click **OK**.

![](/media/2021-02-img_60329dfc01022.png)

Now you should have a new screen called Level1 in Glue.

![](/media/2021-02-img_60329e7747e9f.png)

Finally we'll add collision to our level for the MainCharacter to walk on. To do this:

1.  Open Level1Map in Tiled

    ![](/media/2021-02-img_60329f6d60104.png)

2.  Select the top-left tile in the **TiledIcons** tileset

    ![](/media/2021-05-img_609210cca57a1.png)

3.  Once this tile is selected, click on the map to paint this tile. Doing so will add collision to your map.

    ![](/media/2021-05-img_6092105d05917.png)

Now if we run the game, we have our level set up, but the player will still fall through the level. Next we'll add a CollisionRelationship between the player and the solid collision. [![](/media/2018-01-2021_February_21_110609.gif)](/media/2018-01-2021_February_21_110609.gif)

## Adding a Collision Relationship

Currently our game has collision defined through the Level1Map, but we haven't told our game that the MainCharacterInstance should collide against it. To do this:

1.  Expand GameScreen Objects
2.  Drag+drop the **MainCharacterList** onto the **SolidCollision** to create a relationship [![](/media/2018-01-2021_February_21_113719.gif)](/media/2018-01-2021_February_21_113719.gif)
3.  Mark the newly-created CollisionRelationship as ****Platformer Solid Collision****

Now the player will collide with the level.

![](/media/2021-02-img_6032a4dcaa5cc.png)

## Controlling the Entity with Input

By default the platformer entity already supports a default set of controls. To see this, select the MainCharacter, then select the **Entity Input Movement** tab.

![](/media/2021-02-img_6032a55db4f63.png)

By default the platformer will be controllable with a plugged-in Xbox Gamepad. If no Gamepad is detected, then the entity can be controlled with WASD and Space. [![](/media/2018-01-2021_February_21_112625.gif)](/media/2018-01-2021_February_21_112625.gif) If you want to override this functionality, you can change the controls. These controls can be changed in the MovementInput code (to apply to all players) or in the GameScreen. We recommend making the changes in GameScreen so that different characters can have different input in a multi-player game. To change the character to jump with the Enter key and to move with the arrow keys:

1.  Go to GameScreen.cs
2.  Modify the CustomInitialize  function to contain the following input assignment code:

``` lang:c#
void CustomInitialize()
{

    MainCharacter1.JumpInput = InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.Enter);

    MainCharacter1.HorizontalInput = InputManager.Keyboard.Get1DInput(
        Microsoft.Xna.Framework.Input.Keys.Left, Microsoft.Xna.Framework.Input.Keys.Right);
}
```

The code above added keyboard controls so that the main character can be moved horizontally with the A and D keys and jumps using the space bar.

## Conclusion

Now our platformer character reacts to input and collides with the environment. We can change the environment by opening Level1Map at any time and painting new tiles. The next tutorial takes a deeper look at the control values.
