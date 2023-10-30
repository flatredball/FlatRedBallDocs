# view-projects

### Introduction

The **View Projects** menu item displays the current Visual Studio projects for the current Glue project. Initially only one project will appear in the Projects tab when selecting **View Projects**. The following image shows the Projects tab with a single XNA 4 project named **TownRaiser**:

![](../../../../../media/2017-04-img_58f2c7a997269.png)

### Synced Projects

Synced projects are used to develop multi-platform games. For example, a single Glue project may contain a main PC (XNA 4) project, a synced project for iOS, and a second synced project for Android, as shown in the following image:

![](../../../../../media/2017-04-img_58f2ca34ce257.png)

To open a project, click on the icon for the IDE for a given project. For example, the following icon can be used to open the TownRaiser XNA 4 Project:

![](../../../../../media/2017-04-img_58f2cb4ab5082.png)

### New Synced Project

New platforms can be added to an existing project at any point in development by adding a new synced project. To add a new synced project to an existing Glue project:

1. Open the **Projects** tab
2. Click the **New Synced Project** button
3. The FlatRedBall Project Creator will appear. Select the desired platform (such as **Windows UWP**)
4. Enter a name for the project. Typically the name matches the original project's name with the platform appended. For example, TownRaiserUwp.
5.  Click the **Make My Project!** button.

    ![](../../../../../media/2017-04-img_58f2cd5dbfe44.png)

After creating the new synced project, it will appear in the Projects tab.

![](../../../../../media/2017-04-img_58f2cdedd3206.png)

Since FlatRedBall is designed to be syntactically identical across all platforms, most new synced projects will compile and run with little or no modifications. &#x20;
