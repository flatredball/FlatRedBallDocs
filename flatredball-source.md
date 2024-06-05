# 🏗️ Building FlatRedBall From Source

### Building FlatRedBall from source is not required to use FlatRedBall.&#x20;

Most users do not need to follow the steps outlined in this section. New users are encouraged to skip this and head over to the Tutorials section. If you would like to build FlatRedBall to do more advanced debugging, contribute to the project, or out of pure curiosity then feel free to continue through this section.

This section discusses the following:

* How to build the FlatRedBall Editor from source (this is also available in binary format on the downloads page)
* How to add FlatRedBall source code to your project through the FlatRedBall Editor
* How to add FlatRedball source code to your project manually (if not using the FlatRedBall Editor)

If you are interested in using FlatRedBall in a code-only project, see the [Code-Only](tutorials/code-only-project-tutorial/) Projects page.

### Introduction

Currently all development is being done on the NetStandard branch, so if you would like to build FlatRedBall Glue form source, we recommend pulling the **NetStandard** branch. The FlatRedBall Game Engine and Tools are all open source:

* [FlatRedBall on Github](https://github.com/vchelaru/FlatRedBall)

If you plan on using FlatRedBall FNA, be sure that you include all submodules when pulling FlatRedBall. This may automatically happen if you are using some github clients (such as github for desktop), but you may need to perform additional configuration if using a client that doesn't pull submodules by default (such as Rider).

FlatRedBall uses Gum UI including at runtime. This is also open source and can be found on Githhub:

* [Gum on Github](https://github.com/vchelaru/Gum)

Both repositories should be cloned to the same folder to make linking easier.

### Downloading FlatRedBall Source

The easiest way to download and keep FlatRedBall source up to date is to use a Github client such as Github for Desktop. To download source using Github for Desktop:

1. Install Github for Desktop
2.  Select File -> Clone Repository

    <div align="left" data-full-width="true">

    <img src="media/2021-08-img_6112a86031125.png" alt="">

    </div>
3. Select the URL tab
4. Enter the FlatRedBall url: https://github.com/vchelaru/FlatRedBall. Keep the default folder as **FlatRedBall**
5. Click the Clone button\
   ![](media/2021-08-img\_6112a90f42a84.png)
6.  Switch to the appropriate branch. The default branch is NetStandard

    ![](media/2022-11-img\_636b193cd624c.png)

After FlatRedBall is cloned, you will have a local copy on your machine.

![](media/2021-08-img\_6112a93e335de.png)

### Downloading Gum Source

You will also need to download Gum source, as FlatRedBall games which link against source also reference Gum files. To do this (assuming Github for Desktop):

1. Select File -> Clone Repository
2. Select the URL tab
3. Enter the Gum source: https://github.com/vchelaru/Gum . Keeping the default folder is recommended, but if not, be sure to use the same root as the FlatRedBall clone above.

### Adding FlatRedBall Source to a Game Project using the FRB Editor

To add the FRB source to your project:

1. Open your project in the FlatRedBall Editor
2.  Select the **Project** -> **Link Game to FRB Source** menu item

    <div align="left">

    <img src="media/2023-07-img_64b5303d1f0e2.png" alt="">

    </div>
3.  The **Add FRB Source** tab appears, showing a text box for FlatRedBAll and Gum root folders. If your current project is also a Git project which is cloned to the same folder as FlatRedBall and Gum, then the FRB Editor attempts to fill in the file paths.

    <div align="left">

    <img src="media/2023-07-img_64b531293eff9.png" alt="">

    </div>
4. If your paths are blank or incorrect, use the ... button to select the file paths for each repository.
5. If you are planning to use Gum Skia, check the option
6. Click **Link to Source**
7. After your project is linked, the **Add FRB Source** tab will disappear

Your game project should not directly reference the FlatRedBall Source.

![](media/2023-07-img\_64b5319f1f491.png)

### Adding FlatRedBall Source to a Game Project Manually

If you would like to use the engine source in your game project:

1. Open your game project in Visual Studio
2. Expand the game project in the solution explorer
3. Expand the References item
4.  Find the **FlatRedBall** entry. This is the reference to the prebuilt-dll

    <div align="left">

    <img src="media/2017-02-img_5892095362770.png" alt="">

    </div>
5. Press the Delete key to remove this reference
6. Right-click on the solution
7. Select **Add -> Existing Project...**
8.  Navigate to the location of the FlatRedBall .csproj file for your given platform. For example, for PC, add **\<FlatRedBall Root>\Engines\FlatRedBallXNA\FlatRedBall\FlatRedBallDesktopGL.csproj**

    ![](media/2021-08-img\_6112a9f5767f4.png)
9. Click Open to add the project to your game's solution
10. Right-click on your game's **References** item and select **Add Reference...**
11. Click the "Projects" category
12. Check the FlatRedBallDesktopGL project (or whichever FlatRedBall project used for the given platform)
13. Click OK

    ![](media/2017-02-img\_58920a8e61d75.png)
14. Build and run your project

### Building the FlatRedBall Editor (Glue)

Verify that you have .NET 6 SDK installed [https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.309-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.309-windows-x64-installer)

To build the FlatRedBall Editor (also referred to as Glue):

1. Download the FlatRedBall repository (either clone it or download the .zip file from Github) following the steps above
2.  Download the [Gum repository](https://github.com/vchelaru/Gum) following the steps above. Make sure to download it to the same folder where you downloaded the FlatRedBall repository, and name the folder Gum. See below for an example. If you do not do this, you will have reference errors when opening the solution.

    ![](media/2016-11-img\_583909d260b0c.png)
3.  Open the file **\<FlatRedBall Root>\FRBDK\Glue\Glue with All.sln.**

    ![](media/2021-08-img\_6112b22407f6b.png)
4.  To rebuild Glue with all plugins, select **Build** -> **Build Solution** in Visual Studio. You must **Build or Rebuild** the first time you run FlatRedBall. If you make further changes to any plugins, you must either build the entire solution, or build the project that contains the plugin. Simply building the GlueFormsCore project, or pressing F5 to build and run Glue, will not build all plugins.\\

    <figure><img src=".gitbook/assets/image (4) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>
5. Set **GlueFormsCore** as the **StartUp Project**

<figure><img src=".gitbook/assets/image (7) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

6. Building the solution creates an .exe from which the FRB editor can be run. You can find this .exe at \<your git repo location>\FlatRedBall\FRBDK\Glue\Glue\bin\Debug\GlueFormsCore.exe. Alternatively, you can start up the FRB editor from Visual Studio. Doing so in **Debug Mode** allows you to see error messages in case the FRB editor throws an exception.

<figure><img src=".gitbook/assets/image (128).png" alt="" width="563"><figcaption></figcaption></figure>

For Rider users, you will need to set GlueFormsCore as the project to run in the Configuration dialog.\
\
![](<.gitbook/assets/image (3) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png>)\\

<figure><img src=".gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

<figure><img src=".gitbook/assets/image (4) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

It's important that Gum and FlatRedBall are checked out to the same folder. For example, you may have:

* c:/MyDocuments/FlatRedBall
* c:/MyDocuments/Gum

### Troubleshooting

#### Gum Project References Broken

The Glue project references Gum projects, so the two project folders must be in the same root folder. To verify:

1. Open **Glue with All.sln**
2. Open the Solution Explorer
3. Expand the GumProjects folder

If the references are correct, your window should look similar to the following image:

![](media/2020-04-img\_5e9098ba3d6ef.png)

If your references are broken, then you may see something similar to the following image:

<figure><img src="media/2020-04-img_5e9098e234103.png" alt=""><figcaption></figcaption></figure>

Notice that the projects are marked as **unloaded**. To solve this make sure that both of the projects (FlatRedBall and Gum) are in the same root folder. If you unzipped the files, then they may need to be moved up one folder.

#### Microsoft.Windows.UI.Xaml.CSharp.targets was not found...

When opening the project, you may get a message which states:

```
The imported project "C:\Program Files (x86)\MSBuild\Microsoft\WindowsXaml\v14.0\8.1\Microsoft.Windows.UI.Xaml.CSharp.targets" was not found. Confirm that the path in the <Import> declaration is correct, and that the file exists on disk. C:\Program Files (x86)\MSBuild\Microsoft\WindowsXaml\v14.0\Microsoft.Windows.UI.Xaml.CSharp.targets
```

For information on how to solve this problem, see the following link: [http://www.c-sharpcorner.com/UploadFile/8a67c0/visual-studio-2015-feature-shared-project-part-2/](http://www.c-sharpcorner.com/UploadFile/8a67c0/visual-studio-2015-feature-shared-project-part-2/)

####
