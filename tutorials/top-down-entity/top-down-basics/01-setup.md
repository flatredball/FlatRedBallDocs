# Setup

### Introduction

This tutorial sets up an entity with Top Down controls. It provides a default implementation which requires no code. Later tutorials show how to interact with this plugin using code.

### Requirements

The FRB Editor provides support for top-down entities through the Entity Input Movement tab. Any entity can be created as a Top Down entity; however, the most common setup is to have a Player entity which uses top down controls.

Empty projects can use the **Project Setup Wizard** to create a top down player entity. Existing games can add top down controls to new or existing entities with a few clicks. This tutorial shows you how to do both.

### Project Setup Using the New Project Wizard Preset

The simplest way to set your project up is to use the new project wizard. FlatRedBall automatically launches the wizard when creating a new project.

![](../../../.gitbook/assets/2022-03-img\_62309f1815b67.png)

To create a top-down project, select the **Standard Top Down** button.

![](../../../.gitbook/assets/2022-03-img\_62309f5a0d3d3.png)

Now your game should be set up with a fully-functional top-down entity. You can verify this by clicking on the **Player** entity and then clicking on the **Entity Input Movement** tab. The Player should be marked as having **Top-Down** as its **Input Movement Type**.

![](../../../.gitbook/assets/2022-03-img\_6230a056728c2.png)

### Alternative - Manually Creating GameScreen and Player Entity

This section will explain how to manually add a GameScreen and Top-Down entity. You do not need to follow this section if you have used the wizard as shown in the previous step.

1. Select the **Quick Actions** tab
2.  Click the **Add Screen** button

    ![](../../../.gitbook/assets/2020-09-img\_5f599247ae317.png)
3.  Click **OK** to the default GameScreen name (all games should have a single GameScreen)

    ![](../../../.gitbook/assets/2021-03-img\_6043f5877fc5e.png)

To add a Player entity:

1.  Click the **Add Entity** button

    ![](../../../.gitbook/assets/2020-09-img\_5f5995951369d.png)
2. Name the entity **Player**
3. Check:
   1. **Circle** under **Collisions**
   2.  **Top-Down** under **Input Movement Type**

       ![](<../../../.gitbook/assets/13\_06 03 33.png>)
4. Leave the rest of the defaults and click **OK**

If you already have an entity created, you can make it a Top Down entity:

1. Select the entity
2. Click the **Entity Input Movement** tab
3. Click the **Top-Down** option

![](../../../.gitbook/assets/2022-03-img\_6230a056728c2.png)

By default your GameScreen should have a list of Players (it was an option earlier when creating the Player entity). We recommend always creating a list of Players even if you intend to only have one player. This standard appears throughout FlatRedBall's documentation and can make moving from one project to another easier.

If you did not add a PlayerList earlier by keeping the **Include lists in GameScreen,** or if you created your GameScreen after your Player, you can manually add a PlayerList by following these steps:

1. Verify **Player** is selected
2. Click the **Quick Actions** tab
3.  Click the **Add Player List to GameScreen** button

    ![](../../../.gitbook/assets/2021-03-img\_6043f6f354f8c.png)

You will also need a Player instance in the list. To do this, drag+drop the Player onto the GameScreen and it will be added to the Player list.

<figure><img src="../../../.gitbook/assets/2020-09-2021_March_06_144641.gif" alt=""><figcaption></figcaption></figure>

### Moving the Entity

Now that the entity is marked as a Top Down entity and now that we have an instance of the entity in the GameScreen, we can run the game and see the player move. By default the entity uses a gamepad if one is connected. Otherwise, the entity will use WASD keys on the keyboard.

<figure><img src="../../../.gitbook/assets/2020-09-2020_September_09_211313.gif" alt=""><figcaption></figcaption></figure>
