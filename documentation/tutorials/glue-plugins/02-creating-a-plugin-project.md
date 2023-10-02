# 02-creating-a-plugin-project

### Introduction

This tutorial provides instructions for creating a simple Glue plugin. This is the first step in creating any new plugin.

### Obtaining Source

The easiest way to create Glue plugins is to use download and develop your plugin in a solution which includes Glue source. Instructions for downloading Glue source can be found on the following page: http://flatredball.com/flatredball-source/ Before continuing you will want to make sure you can build and run Glue from source (**Glue with All.sln**).

### Creating a new SLN

Whether you create a new .sln depends on whether you plan on making a plugin that will be part of the main FlatRedBall repository. If you do intend to do so, please discuss your plans in Discord to make sure it will be accepted as a core library. If you are not sure if you want to include it in the main FRB repository, or if you intend this to be separate from the FRB repository, then you should create a copy of the .sln. Keep in mind that you do not need to create a new .sln for every plugin you are developing - it may be convenient to have multiple plugins in one .sln file. To create a new .sln file:

1.  Open the folder where **Glue with All.sln** is located - on my machine this is located at **C:\Users\Victor\Documents\FlatRedBall\FRBDK\Glue**

    ![](../../../media/2023-01-img\_63b47242dcefd.png) The name Glue with All means that all plugins are currently part of this .sln.
2. Create a copy of **Glue with all.sln** in the same folder
3.  Rename the newly-created file to indicate the plugin you are developing. For example, I will name mine **Glue with TutorialPlugin.sln**

    ![](../../../media/2023-01-img\_63b4728413a0f.png)

### Creating a Plugin Project

Now that we have a .sln file to hold our plugin, we can create a new .csproj (project) file. To add a new .csproj to your newly-created .sln file:

1. Open the newly-created .sln file (mine is called **Glue with TutorialPlugin.sln**)
2.  Collapse the projects in the solution explorer - this will make it easier to add new projects

    ![](../../../media/2018-02-img\_5a7f0d5c0c1f5.png)
3.  You can choose how you prefer to organize your plugin. Common approaches include adding a new folder for your plugin at the root of the solution, or adding your plugin to the existing Plugins folder. For this tutorial I will create a new folder at the root of the solution called Tutorial. Right-click on the solution and select **Add** -> **New Solution Folder**

    ![](../../../media/2018-02-img\_5a7f0e76ee93f.png)
4.  Name the folder **Tutorial**

    ![](../../../media/2018-02-img\_5a7f0ebc176c7.png)

Larger plugin projects may contain multiple projects, so creating  a folder for your plugin is a good way to keep the projects organized. Next we'll create a new .csproj file for the plugin:

1.  Right-click on the **Tutorial** folder and select **Add** -> **New Project**

    ![](../../../media/2018-02-img\_5a7f0f6177819.png)
2.  Select the **Class Library (not .NET Framework)** category

    ![](../../../media/2023-01-img\_63b472ef08e0b.png)
3.  Name your plugin something like **TutorialPlugin**

    ![](../../../media/2023-01-img\_63b47314c3d19.png)
4.  Verify that you are targeting .NET 6.0. This is the current version of the FlatRedBall Editor as of 2023, but it will likely change in the future

    ![](../../../media/2023-01-img\_63b4734808217.png)

After clicking **OK**, the project will appear in the **Solution Explorer.** ![](../../../media/2018-02-img\_5a7f24bd2c492.png)

### Adding Project References

Tutorial projects must reference FlatRedBall and Glue libraries to be able to make changes to Glue at runtime. Most plugins also require referencing a few other libraries for displaying UI. Fortunately you can solve this by adding a single project reference. To add the project reference:

1. Expand the newly-created **TutorialPlugin** project in the **Solution Explorer**
2. Right-click on the \*\*Dependencies \*\*item and select **Add Project Reference...**
3.  Check Plugin Libraries:

    ![](../../../media/2023-04-img\_644d173f66308.png)

The library should also target Windows:

1. Right-click on the plugin library and select Properties
2.  Change the Target OS to Windows

    ![](../../../media/2023-01-img\_63b474f814127.png)

&#x20; Glue plugins typically often require a set of libraries for WPF development, as Glue plugins can host WPF controls. To add these libraries:

1. Double-click your project file to open it as a text file in Visual Studio
2. Add the following to your PropertyGroup tag:

&#x20;

```
 <UseWindowsForms>true</UseWindowsForms>
 <UseWPF>true</UseWPF>
```

![](../../../media/2023-01-img\_63b4758c7d999.png)

&#x20; Now you have a project that is ready to go as a plugin project! Next we'll create our first plugin class.
