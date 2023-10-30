# creating-a-glue-project

### Introduction

This tutorial is an introduction to making games with FlatRedBall. It covers using the FlatRedBall Editor and writing code in C#. The FlatRedBall Editor is a program which helps with the creation and organization of game projects. We'll be exploring its features by creating a game called Beefball - a multiplayer competitive game similar to [air hockey](https://en.wikipedia.org/wiki/Air_hockey). When finished our game will have two circles, each movable with either the keyboard or an Xbox controller, and a smaller circle which each player can use to earn points.

### Opening FlatRedBall

The first step in any game project is to open up the FlatRedBall Editor. If you've downloaded and unzipped the FRBDK.zip file, then you should already have this on your machine. Unzip the file,  and double-click **Run FlatRedBall.bat.**

![](../../../media/2023-08-img_64cbd09e989f7.png)

If you haven't yet downloaded the FRBDK.zip file, you can get it from the [Download page](../../../download.md).

### Creating a new project

Once you open the editor, you can create a new project. To create a new Project:

1.  Select \*\*File \*\*-> **New Project**

    ![](../../../media/2022-01-img_61d256005734c.png)
2. Enter **Beefball** for the **Project Name.**
3. Leave **Desktop GL** as the platform. Our game will target this platform because it is easy to debug. Creating the project for a desktop platform is recommended even if the game is intended to run on non-desktop platforms (such as Android). Additional platforms can be added at any time.
4.  Uncheck **Open New Project Wizard**. We'll make Beefball "from scratch".

    ![](../../../media/2023-07-img_64a8393f6368b.png)
5. (Optional) Change the location of the project. By default the project will be created in **Documents\FlatRedBallProjects**.
6. Click the **Create Project!** button to create the project.

The latest FlatRedBall template will be downloaded, so your project will be running against the newest version available. Now that you've made a project, FlatRedBall will remember this and automatically open it for you next time it is started.

### FlatRedBall Editor and Visual Studio

FlatRedBall Editor is a tool meant to work hand-in-hand with Visual Studio. It is not a replacement for Visual Studio, meaning you will be doing work in both Visual Studio and the editor. It is quite common to develop FlatRedBall games with both Visual Studio and the editor open at the same time.

### Opening and Running your project

FlatRedBall projects automatically create a Visual Studio project too. To open the project in Visual Studio, click the Visual Studio icon as show in the following image:

![Screenshot of Glue showing the Beefball project loaded with the Open Project in Visual Studio button highlighted.](../../../media/2016-01-2022-03-12-09_15_09-Beefball-Open-Project.png)

You can also open the project in visual studio by opening the .sln file. The project folder can be opened by clicking the folder icon in the task bar. This will open the location of the .csproj file, which is one folder below the .sln file. The following animation shows how to navigate to the solution: 

<figure><img src="../../../media/2016-01-03_08-09-28.gif" alt=""><figcaption></figcaption></figure>

 When you double-click the .sln file you may see a window like this:

![VSVersionSelector.PNG](../../../media/migrated_media-VSVersionSelector.PNG) If so you will want to select the version of Visual Studio that is compatible with the type of project you are running. At the time of this writing, Visual Studio 2022 Community is the most common version to use with FlatRedBall. Once Visual Studio is open, you can run your project by pressing the green "play" button, or by pressing F5.

![PlayButtonInVisualStudio.png](../../../media/migrated_media-PlayButtonInVisualStudio.png) Your game should run if all prerequisites have been properly installed. You should see a blank game

![](../../../media/2020-07-img_5f07b32cc4a28.png)

### Conclusion

That was easy! So far you have a fully-functional game using FlatRedBall. The next tutorial will cover making our first Entity. -- [Creating an Entity ->](creating-an-entity.md)
