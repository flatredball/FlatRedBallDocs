# Creating a FlatRedBall Project

### Introduction

This tutorial is an introduction to making games with FlatRedBall. It covers using the FlatRedBall Editor and writing code in C#. The FlatRedBall Editor is a program which helps with the creation and organization of game projects. We'll be exploring its features by creating a game called Beefball - a multiplayer competitive game similar to [air hockey](https://en.wikipedia.org/wiki/Air\_hockey). When finished our game will have two circles, each movable with either the keyboard or an gamepad, and a smaller circle which each player can use to earn points.

### Opening FlatRedBall

The first step in any game project is to open up the FlatRedBall Editor. If you've downloaded and unzipped the FRBDK.zip file, then you should already have this on your machine. Unzip the file, and double-click **Run FlatRedBall.bat.**

![Run FlatRedBall batch file](../../.gitbook/assets/2023-08-img\_64cbd09e989f7.png)

If you haven't yet downloaded the FRBDK.zip file, you can get it from the [Download page](../../).

### Creating a new project

Once you open the editor, you can create a new project. To create a new Project:

1.  Select **File** -> **New Project**

    ![File -> New Project Menu](../../.gitbook/assets/2022-01-img\_61d256005734c.png)
2. Enter **Beefball** for the **Project Name.**
3. Leave **Desktop GL** as the platform. Our game targets this platform because it is easy to debug. Creating the project for a desktop platform is recommended even if the game is intended to run on non-desktop platforms (such as Android). Additional platforms can be added at any time.
4.  Uncheck **Open New Project Wizard**. We'll make Beefball "from scratch".

    ![Uncheck the New Project Wizard](../../.gitbook/assets/2023-07-img\_64a8393f6368b.png)
5. (Optional) Change the location of the project. By default the project is created in **Documents\FlatRedBallProjects**.
6. Click the **Create Project!** button to create the project.

The latest FlatRedBall template is downloaded, so your project runs against the newest version available. Now that you've made a project, FlatRedBall remembers this and automatically open it for you next time it is started.

### FlatRedBall Editor and Visual Studio

FlatRedBall Editor is a tool meant to work hand-in-hand with Visual Studio. It is not a replacement for Visual Studio, meaning you will be doing work in both Visual Studio and the editor. It is quite common to develop FlatRedBall games with both Visual Studio and the FRB Editor open at the same time.

### Opening and Running your project

FlatRedBall projects automatically create a Visual Studio project too. To open the project in Visual Studio, click the Visual Studio icon as show in the following image:

![Screenshot of Glue showing the Beefball project loaded with the Open Project in Visual Studio button highlighted.](../../.gitbook/assets/2016-01-2022-03-12-09\_15\_09-Beefball-Open-Project.png)

FlatRedBall uses the windows default file association for your .sln file. If you would like to change this association, you can right-click on the .sln file in Windows Explorer to change the default file association.

You can also open the project in visual studio by opening the .sln file. The project folder can be opened by clicking the folder icon in the task bar. This opens the location of the .csproj file, which is one folder below the .sln file. The following animation shows how to navigate to the solution:

<figure><img src="../../.gitbook/assets/2016-01-03_08-09-28.gif" alt=""><figcaption><p>Opening the Visual Studio project from disk</p></figcaption></figure>

When you double-click the .sln file you may see a window like this:

<figure><img src="../../.gitbook/assets/migrated_media-VSVersionSelector.PNG" alt=""><figcaption><p>Application selection window</p></figcaption></figure>

If so you should select the version of Visual Studio that is compatible with the type of project you are running. At the time of this writing, Visual Studio 2022 Community is the most common version to use with FlatRedBall. Once Visual Studio is open, you can run your project by pressing the "start" button, or by pressing F5.

<figure><img src="../../.gitbook/assets/migrated_media-PlayButtonInVisualStudio.png" alt=""><figcaption><p>Start button in Visual Studio</p></figcaption></figure>

Your game should run if all prerequisites have been properly installed. You should see a blank game

![Blank FlatRedBall game](../../.gitbook/assets/2020-07-img\_5f07b32cc4a28.png)

### Conclusion

That was easy! So far you have a fully-functional game using FlatRedBall. The next tutorial covers making our first Entity.
