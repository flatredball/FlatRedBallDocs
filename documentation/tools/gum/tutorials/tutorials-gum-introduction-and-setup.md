## Introduction

Gum is an open source, general purpose, platform-agnostic UI layout tool. Although Gum itself is not built to be used with any game engine in particular, FlatRedBall provides full support for the Gum tool. In fact, Gum is so well integrated into FlatRedBall that it is used to perform layouts of FlatRedBall's built-in UI system: FlatRedBall.Forms. For information on using Gum as a standalone UI tool for any type of project, see the [Gum documentation](https://vchelaru.github.io/Gum/).

## Downloading Gum

The first step in using Gum is to download the project. If you have downloaded the FRBDK.zip file from the main downloads page on this site, you already have Gum in the \<unzipped FRBDK location\>/Gum/Data/Gum.exe. You can also get Gum as a standalone [downloaded here](/content/Tools/Gum/Gum.zip). You will also need to install the [XNA 4.0 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=20914) on your machine to run Gum. Remember the location for Gum.exe**, we'll need it later.**

## Gum projects

For this tutorial we will be adding a Gum project through the FlatRedBall Editor.

### Option 1 - Adding Gum Projects in the FlatRedBall Wizard

If you have created your project using one of the project types in the wizard, then your project is already including Gum.

![](/media/2023-01-img_63bf79f7b197b.png)

You can verify that you have a Gum project by looking for GumProject.gumx in Global Files.

![](/media/2023-01-img_63bf7a5903f2d.png)

## Option 2 - Gum Toolbar Button

If you do not want to run the Glue wizard, or if your project already has Screens or Entities (the Glue wizard only appears for completely empty projects), you can add Gum through the toolbar button

1.  Click the Gum toolbar button or the Add Gum Project quick action. Notice that the Gum icon in the toolbar has a + icon to indicate that this button adds a new project.

    ![](/media/2023-01-img_63bf7ababc300.png)

2.  When asked, select the option to **Include Forms Controls (Recommended)**

    ![](/media/2021-03-img_604417b7e19a7.png)

**Troubleshooting Missing Gum Options:** If you do not see any of the options shown above, you can verify that the plugin has installed correctly and that it is running through the [Manage Plugins Window](/frb/docs/index.php?title=Glue:Reference:Menu:Plugins:Manage_Plugin "Glue:Reference:Menu:Plugins:Manage Plugin").

  Also, you will see a button in the toolbar for opening the Gum project. ![](/media/2019-03-img_5c78b2870eb69.png)

## Editing the Gum Project

The .gumx project (which means Gum XML) is the root project. It can be opened in Gum. If you have the file association set up for the .gumx file with Gum, you can click the Gum icon or double-click the .gumx file to open Gum. This is the same icon which was previously used to add a new Gum project.

![](/media/2019-03-img_5c78b2870eb69.png)

Setting up file associations is recommended since it makes opening Gum much faster.

**Don't associate Launcher.exe with your files:** Instead, associate Gum.exe to gum file formats (gumx, gucx, gusx)  Launcher.exe exists when running Gum manually to check for prerequisites.

Once you open up the .gumx file in Gum, you should see a screen like this: ![EmptyGum.PNG](/media/migrated_media-EmptyGum.PNG)

## Learning to use Gum

Gum is a very powerful tool with lots of functionality. This tutorial assumes that you are familiar with using the tool. If you're not, then you will want to take a look at the usage guide for Gum, which can be [found here](https://flatredball.gitbook.io/gum/). You should take some time to familiarize yourself with the tool, as the tutorials in this series will focus specifically on how to use Gum with Glue and FlatRedBall.

## Conclusion

If you've gotten this far then you have a Gum project which is ready to be used with Glue. Next, we'll cover some of the basics of working with Gum in Glue. -- [2. Screens in Gum -\>](/documentation/tools/gum/tutorials/tutorials-gum-screens-in-gum.md)
