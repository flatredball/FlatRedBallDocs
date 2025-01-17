# Creating an Entity

### Introduction

This tutorial covers how to create an Entity, which is the FRB term for a "game object". Examples of entities include:

* Game characters (like Mario)
* Projectiles (like a bullet)
* Power-up (like a health pickup)

Our first entity is called "PlayerBall".

### Creating PlayerBall

To create an Entity:

1.  Click the **Add Entity** in the **Quick Actions** tab...

    ![Add Entity quick action button](../../.gitbook/assets/02\_21\_21\_30.png)

    ...or right-click on the **Entities** folder and select **Add Entity**

    ![Add Entity right-click menu item](../../.gitbook/assets/2022-01-img\_61d312843f359.png)
2. Enter the name **PlayerBall**
3. Check the **Circle** checkbox under the **Collisions** category. This adds a circle object to the PlayerBall entity, which we'll use to test if it is touching the walls, goals, or other ball instances.
4. Notice that the **ICollidable** checkbox is checked - we'll cover this in a later tutorial. We'll leave it checked for now.
5. Notice that **Create Factory** is also checked. This option simplifies the creation of additional entities in code. We'll leave this checked as well.
6. Click **OK**

![Add PlayerBall entity dialog](../../.gitbook/assets/2022-01-img\_61d312b26d918.png)

Our entity is now created with a Circle named **CircleInstance** under its **Objects** folder, as shown in the following image:

![CircleInstance in PlayerBall](../../.gitbook/assets/2022-01-img\_61d312e83c316.png)

### Alternative Approach - Adding a Circle

The previous section showed how to create an entity and add a Circle to the entity at the same time. Objects can be added after an entity is created as well. **Note, the following steps are only shown for example, and do not need to be followed if you performed the previous steps.** To add a Circle to an already-created entity:

1.  Click the **Add Object** quick action...

    ![Add Object to Playerball Quick Actions button](../../.gitbook/assets/2022-01-img\_61d3133fc9c72.png)

    ...or right-click on **Objects** and select **Add Object**

    ![Right-click Add Object option](../../.gitbook/assets/2022-01-img\_61d31363d6568.png)
2. Select the **FlatRedBall Or Custom Type** option
3. Select **Circle** in the list
4.  Enter the name **CircleInstance** and click **OK**

    ![Add CircleInstance option](../../.gitbook/assets/2022-01-img\_61d313aa162c3.png)

### Creating an Entity - the Code and Data

When a new Entity or Screen is created, a number of files are created:

* \<EntityName>.glej or \<ScreenName>.glsj
* \<EntityName>.cs
* \<EntityName>.Generated.cs

For example, the PlayerBall entity creates PlayerBall.glej, PlayerBall.cs, and PlayerBall.Generated.cs. These files can be viewed by right-clicking on the entity and selecting **View in Explorer**.

<figure><img src="../../.gitbook/assets/image (181).png" alt=""><figcaption><p>View in Explorer Right-Click option</p></figcaption></figure>

#### PlayerBall.glej

The PlayerBall.glej file is a JSON file which stores all of the information for the PlayerBall. This file does not need to be edited manually in most cases since the FlatRedBall Editor provides controls for making changes. Of course, the file can be edited by hand, and any changes are automatically reloaded by the FlatRedBall Editor if the file changes.

This file should be included in version control so that the project can be opened and re-generated on other computers.

#### PlayerBall.cs

The PlayerBall.cs is a code file which contains custom logic. By default this file contains only empty functions, but these can be filled in to customize initialization, every-frame logic, destruction, and content loading. This file is often referred to as the _custom code_ file. In a typical game, a lot of your game's code is written in screen and entity custom code files.

#### PlayerBall.Generated.cs

PlayerBall.Generated.cs is a file which is generated by the FlatRedBall Editor mirroring the contents of the JSON (glej) file. Any changes to the JSON file, whether through the FlatRedBall Editor or by manually editing the contents of the JSON file, results in the PlayerBall.Generated.cs being re-generated.

The contents of this file are re-generated if any change is made to the Player entity, or if the FlatRedBall editor is re-opened. In other words, generated files are re-generated by the FRB Editor, so any changes made directly to the generated file should be considered temporary. In practice this file can be used to help debug, or to perform temporary tests, but final changes should either be made in the JSON file or in custom code.

Generated files can optionally be included in version control. By default FlatRedBall excludes generated files since they can be re-generated from the corresponding JSON files. Of course, if the project is cloned to a new computer then the project must be opened in the FlatRedBall Editor to re-create all generated files. If this is problematic (such as if the development team includes individuals who do not open the FlatRedBall Editor), then the generated code files can be added to version control. Keep in mind that doing so may result in a larger version history.

### Conclusion

At this point our project has a PlayerBall Entity which is ready to be used in a game. Of course, we haven't yet created an instance of the newly-created Entity, so if you run your game you won't see it (yet). The next tutorial creates a Screen which contains our PlayerBall Entity.
