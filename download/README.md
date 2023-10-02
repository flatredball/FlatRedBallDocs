# download

### Prerequisites

#### 1 - Visual Studio 2022 or Newer

[https://visualstudio.microsoft.com/vs/community/](https://visualstudio.microsoft.com/vs/community/) Although it is possible to make games without Visual Studio, doing so without Visual Studio requires advanced knowledge of MSBuild. We recommend downloading and installing Visual Studio. Note - if you plan on using a different IDE such as Rider, then you will need to install the .NET 6 SDK. At a minimum you will need to install **.NET desktop development**.

![](../media/2021-08-img\_610caaac075b7.png)

####

#### 2. XNA 4.0 Redistributable

[https://www.microsoft.com/en-us/download/details.aspx?id=27598](https://www.microsoft.com/en-us/download/details.aspx?id=27598) Although this is not required to build and run FlatRedBall games, it is required to use Gum, which is the preferred FlatRedBall UI tool.

#### 3. .NET 6 SDK

[https://dotnet.microsoft.com/en-us/download/dotnet/6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

![](../media/2023-03-img\_6415bcb385f79.png)

Visual Studio 2022 (as of version 17.5.1) installs .NET SDK 7.0 which has a bug preventing projects from being loaded in the FlatRedBall Editor. Therefore, you will need to manually install .NET 6 SDK.

### Downloading FlatRedBall

The most common approach to making FlatRedBall games is to use the FlatRedBall Editor. The Editor can be downloaded from a pre-built .zip file, or it can be built from source. New users should expand **Downloading Pre-Built FlatRedBall**. \[frb\_toggle title="Downloading Pre-Built FlatRedBall"]

### Downloading and Running FlatRedBall

1. Download the latest zip file from [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip](../content/FrbXnaTemplates/DailyBuild/FRBDK.zip)
2. Unzip the file after downloading
3. Go to the folder where the .zip file unzipped to (by default called FRBDK)
4. Open the Run FlatRedBall.bat file (double click it)

![](../media/2023-07-img\_64b932f820fb5.png)

If you see the **Windows protected your PC** dialog, click **More info** -> **Run Anyway**

![](../media/2023-07-img\_64b938bddd912.png)

The FlatRedBall Editor should appear.

![](../media/2022-12-img\_639d07e85b8d9.png)

\[/frb\_toggle] \[frb\_toggle title="Building and Running FlatRedBall From Source"]

### Download Source

####

### 1  - FlatRedBall NetStandard branch

[https://github.com/vchelaru/FlatRedBall/tree/NetStandard](https://github.com/vchelaru/FlatRedBall/tree/NetStandard)

*   If you simply want to get the latest source, you can download the .zip file from Github. Be sure to use the NetStandard branch

    ![](../media/2020-04-img\_5e9090ee03fd4.png)
*   If you would rather always be connected to source, you can clone the source to your machine using command line or any Git client

    ![](../media/2020-04-img\_5e90918a30dcb.png)

#### 2 - Gum (master branch)

[https://github.com/vchelaru/Gum](https://github.com/vchelaru/Gum)

* Just as above, download the Gum zip or clone the source to your machine.

### Building Gum

You can either use Gum file associations to point to a prebuilt Gum.exe, or you can build Gum locally to use the most up-to-date code. To build Gum:

1. Open the Gum project located at \<Gum Root Directory>/Gum.sln
2.  Verify that your configuration is Debug and x86

    ![](../media/2023-01-img\_63c0a48ce7355.png)
3.  Set Gum as the Startup project

    ![](../media/2023-01-img\_63c0a4c232125.png)
4. Build -> Rebuild Solution
5. Launch Gum to makes sure it runs

### Building FlatRedBall (Glue)

To build the FlatRedBall Editor (also referred to as Glue):

1.  Open Glue at **\<Git Root Directory>/FlatRedBall/FRBDK/Glue/Glue with All.sln**. Note that this includes all plugins as well, so building this will give you a fully-featured Glue.

    ![](../media/2020-04-img\_5e88de0c12613.png)
2.  To rebuild Glue with all plugins, select **Build** -> **Build Solution** in Visual Studio. Simply building the Glue project or running Glue will not build all plugins.

    ![](../media/2020-04-img\_5e88de8708323.png)
3.  Set **GlueFormsCore** as the **StartUp Project**

    ![](../media/2020-04-img\_5e88dee2ddb7c.png)

    1.  For Rider users, you will need to set GlueFormsCore as the project to run in the Configuration dialog. ![](https://cdn.discordapp.com/attachments/819954682029277185/1059153024741818469/image.png)

        ![](../media/2023-01-img\_63b1bbc5166d9.png)

        ![](../media/2023-01-img\_63b1bbcfa6175.png)
4.  Launch Glue from Visual Studio

    ![](../media/2023-01-img\_63b1b63c992f6.png)
5.  Glue should now be running

    ![](../media/2023-01-img\_63b1b711b3416.png)

### Troubleshooting

#### Gum Project References Broken

The Glue project references Gum projects, so the two project folders must be in the same root folder. To verify:

1. Open **Glue with All.sln**
2. Open the Solution Explorer
3. Expand the GumProjects folder

If the references are correct, your window should look similar to the following image:

![](../media/2020-04-img\_5e9098ba3d6ef.png)

If your references are broken, then you may see something similar to the following image: ![](../media/2020-04-img\_5e9098e234103.png) Notice that the projects are marked as **unloaded**. To solve this make sure that both of the projects (FlatRedBall and Gum) are in the same root folder. If you unzipped the files, then they may need to be moved up one folder. \[/frb\_toggle]

#### Additional Troublshooting

Having problems opening or running FlatRedBall projects? Check out the [Troubleshooting Page](../uncategorized/troubleshooting-installation.md).

### Advanced Options

Here's some more options on getting or updating FlatRedBall:

* [Setup for FlatRedBall Android](../documentation/tools/glue-reference/multi-platform/glue-how-to-create-a-flatredball-android-project/android-setup.md)
* [Building FlatRedBall from source](../flatredball-source.md)
* [FlatRedBall DLLs (binaries)](../flatredball-dlls.md)
* [Installing XNA (for AnimationEditor, Gum, and older projects)](../visual-studio-2019-xna-setup.md)

&#x20;

### Gum Download

* [Gum](../content/Tools/Gum/Gum.zip)
