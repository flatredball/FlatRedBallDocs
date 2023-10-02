## Introduction

This tutorial provides a set of steps for creating an entity with platformer behavior.

## Using the Wizard

The FlatRedBall Editor provides a quick setup for creating a platformer project. To create a platformer project:

1.  Launch the FlatRedBall Editor
2.  Create a new project
3.  Wait for the project to finish loading
4.  Wait for the Wizard window to appear
5.  Select the Platformer project option ![](/media/2022-10-img_634748f242105.png)
6.  Wait for the wizard to finish processing
7.  Run the game from either Visual Studio or the FlatRedBall Editor

**If you are using the wizard as shown above, you can skip the remainder of this tutorial series and check out the [other platformer tutorials](/documentation/tutorials.md). If you are interested in how to build a platformer in the editor "from scratch", keep reading.**

## Creating a GameScreen

Although this tutorial is focused on creating a platformer entity, we will first add a GameScreen. Creating a GameScreen first makes it much easier to add an entity after. Note that you may already have a GameScreen in your project. If so, you can skip this section. To add a GameScreen:

1.  Select the **Quick Actions** tab in Glue
2.  Click the **Add Screen/Level** button
3.  Leave the default **GameScreen** name
4.  Check both the **Add SolidCollision ShapeCollection **and **Add CloudCollision ShapeCollection** options
5.  Click **OK**

![](/media/2021-02-img_6031e691c6b63.png)

We will return to the GameScreen in future tutorials, but having one created before we create entities will speed up the process.

## Creating a MainCharacter Entity

To create an entity with platformer behavior:

1.  Select the **Quick Actions** tab in Glue
2.  Click the **Add Entity** button
3.  Enter a name for the entity, such as **MainCharacter**
4.  Check the **AxisAlignedRectangle** checkbox - platformer entities perform collision against their environment
5.  Verify that the **ICollidable** checkbox is checked - this will simplify working with the **MainCharacter** entity
6.  Change the **Input Movement Type** to Platformer
7.  Leave the Tiled options selected to automatically create a list for this new entity in GameScreen
8.  Click **OK**

![](/media/2021-02-img_6031e7e167807.png)

This will create a new platformer entity with a rich set of default functionality. We can verify that the entity is marked as a platformer by checking its **Entity Input Movement** tab to verify that it is marked as a platformer and that it has two movement types:

-   Ground
-   Air

![](/media/2021-02-img_6031e8c27e4d7.png)

## Adding MainCharacter to the GameScreen

Now that we have the **MainCharater** set up with platfomer control values, we can add it to our **GameScreen** by drag+dropping the **MainCharacter** onto the **GameScreen** node. We should already have a **MainCharacterList** in our **GameScreen** so the newly-added object will be inside of that list after the drag+drop.

[![](/media/2018-01-2021_February_20_220001.gif)](/media/2018-01-2021_February_20_220001.gif)

## Adding a CameraControllingEntity Instance (Optional)

This tutorial series primarily focuses on creating a platformer entity. If you would like to control the camera manually, you can do so by modifying Camera.Main. More information about the Camera object can be found on the [Camera documentation page](/documentation/api/flatredball/camera.md). Alternatively, if you would like to have automatic camera control, see the [CameraControllingEntity documentation](/documentation/api/flatredball/entities/cameracontrollingentity.md).  

## Conclusion

If we run our game now we'll see the entity functional - at least, it seems to fall with gravity. In the next tutorial we'll add collision and controls using our entity.
