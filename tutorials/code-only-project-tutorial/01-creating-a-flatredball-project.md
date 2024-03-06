# Creating a FlatRedBall Project

### Introduction

This tutorial will walk you through installing and creating an empty FlatRedBall project.

### Downloading FlatRedBall

Before you can begin to create your game, you may want to download the FlatRedBall Editor. Download and installation instructions can be found on our [Downloads Page](01-creating-a-flatredball-project.md#downloading-flatredball). Keep in mind that the download page focuses on Windows. If you are running on a Linux or Mac machine, then your installation steps will differ.

We recommend using the FlatRedBall Editor, however, you can create FlatRedBall games without the FlatRedBall Editor. If you would like to skip using the FlatRedBall Editor, you can go do so by installing the .NET SDK (as shown below).

### Creating a New Project Using the FlatRedBall Editor

Once installed, you can create a new FlatRedBall project using the FlatRedBall Glue Editor. Don't worry, you only need to use the editor to create the project. Once the project has been created, you don't have to use it anymore. If you've downloaded and unzipped the FRBDK.zip file, then you should already have Glue on your machine. Unzip the file, open the XNA 4 Tools folder, and run GlueFormsCore.exe.

<figure><img src="../../media/2020-06-img_5ed717015ee58.png" alt=""><figcaption></figcaption></figure>

Once you the FlatRedBall editor, you can create a new project. To create a new Project:

1.  Select **File**-> **New Project**

    ![](../../media/2021-07-img\_60fca048b4f9f.png)
2. Enter a name for the **Project Name.**
3. Select your platform.
4.  Uncheck **Open New Project Wizard**. This way the project will remain empty

    ![](../../media/2021-10-img\_6163ab93aed48.png)

After your project is created, you can open the project folder in the editor using the folder icon:

![](../../media/2021-10-img\_616d84d75ed54.png)

To find your new project solution file (.sln), navigate up a folder from the location opened by Glue. Alternatively you can navigate to the folder displayed in the new project window and open the .sln from the Windows Explorer. That's it; now you won't have to open the FRB editor anymore.

### Alternative - Creating a New Project Without FlatRedBall Editor

If you would like to avoid using the FlatRedBall Editor completely, or if you are running on Linux or Mac, then you can directly download a project template .zip file. To do this:

1. Go to [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/ZippedTemplates/](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/ZippedTemplates/)
2. Select your target platform. For example, if developing for desktop select [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/ZippedTemplates/FlatRedBallDesktopGlNet6Template.zip](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/ZippedTemplates/FlatRedBallDesktopGlNet6Template.zip)
3. Download and unzip the file to your machine
4. Open the .sln in Visual Studio or Visual Studio Code (see below for Visual Studio Code instructions)

#### Using FlatRedBall with Visual Studio Code

Visual Studio is not a requirement for using FlatRedBall. You can write, compile, and run FlatRedBall projects using Visual Studio code. To do so:

1. Install Visual Studio
2. Install Visual Studio C# Dev Kit [https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit\&ssr=false#overview](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit\&ssr=false#overview)
3. Make sure you have .NET SDK 6 installed

Open the folder where the .sln is located for your project.

![](../../media/2023-08-img\_64d8e28919fe6.png)

Select the folder where you have unzipped your project earlier.

![](../../media/2023-08-img\_64d8e2d376c20.png)

If asked, check **Yes, I trust the authors**.

![](../../media/2023-08-img\_64d8e207f1e75.png)

### Alternative - Adding FlatRedBall to your MonoGame Project

If you have an existing MonoGame project, you can add FlatRedBall with the following steps:

1. Open your MonoGame project in Visual Studio
2. Add FlatRedBall refernece to your projectx
   1.  If targeting Desktop GL, you can add FlatRedBall through the FlatRedball NuGet package\\

       <figure><img src="../../.gitbook/assets/image (13).png" alt=""><figcaption><p>FlatRedBall DesktopGL NuGet Package</p></figcaption></figure>
   2. If targeting other platforms, you will need to manually add the FlatRedBall .dlls to your project:
      1. Download the .dll for the project you are working on from this folder: [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/SingleDlls/](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/SingleDlls/)
      2. Save the .dll to a location relative to your project, such as a Libraries folder
      3. Link your game project to the newly-downloaded .dll
3. Modify `Game1` so it contains the following calls:

In Initialize before `base.Initialize()`:

```csharp
FlatRedBallServices.InitializeFlatRedBall(this, _graphics);
```

In Update before `base.Update(gameTime)`:

```csharp
FlatRedBallServices.Update(gameTime);
```

In Draw before `base.Draw(gameTime)`:

```csharp
FlatRedBallServices.Draw();
```

FlatRedBall requires a shader file for rendering. You need to add this to your project. To do this:

1. Download the compiled shader XNB file from: [https://github.com/vchelaru/FlatRedBall/blob/NetStandard/Templates/FlatRedBallDesktopGlNet6Template/FlatRedBallDesktopGlNet6Template/Content/shader.xnb](https://github.com/vchelaru/FlatRedBall/blob/NetStandard/Templates/FlatRedBallDesktopGlNet6Template/FlatRedBallDesktopGlNet6Template/Content/shader.xnb)
2. Save this to your Content folder in your project
3. Add this file to your Visual Studio project (.csproj)
4. Mark the file as **Copy if newer**

<figure><img src="../../.gitbook/assets/image (14).png" alt=""><figcaption><p>shader.xnb set to Copy if newer</p></figcaption></figure>

### Running Your FlatRedBall Project With Visual Studio

To run your newly-created project:

1. Double-click the .sln file to open it in Visual Studio
2. Once your project opens, click the **Start** button in Visual Studio

<figure><img src="../../media/2017-09-img_59bff6110e49e.png" alt=""><figcaption></figcaption></figure>

Your project will compile and run, displaying an empty (black) screen.

![](../../media/2017-09-img\_59bff64728002.png)

### Running your Project Without Visual Studio

If you would like to run your project without Visual Studio, you can use the dotnet build command line, but you must first install the .NET 6 SDK. [https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.308-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.308-windows-x64-installer) Once you have installed it, you can run the dotnet command to build your project. To build your project

1. Open a command window (like Windows PowerShell)
2. Go to the folder where your .sln is located
3. Type the command `dotnet build YourSolutionFile.sln`

This will produce a .exe which you can then run.
