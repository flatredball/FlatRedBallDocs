# flatredball-source

Currently all development is being done on the NetStandard branch, so if you would like to build FlatRedBall Glue form source, we recommend pulling the **NetStandard** branch. The FlatRedBall Game Engine and Tools are all open source:

* [FlatRedBall on Github](https://github.com/vchelaru/FlatRedBall)

FlatRedBall uses Gum UI including at runtime. This is also open source and can be found on Githhub:

* [Gum on Github](https://github.com/vchelaru/Gum)

Both repositories should be cloned to the same folder to make linking easier.

### Downloading FlatRedBall Source

The easiest way to download and keep FlatRedBall source up to date is to use a Github client such as Github for Desktop. To download source using Github for Desktop:

1. Install Github for Desktop
2.  Select File -> Clone Repository

    ![](media/2021-08-img\_6112a86031125.png)
3. Select the URL tab
4. Enter the FlatRedBall url: https://github.com/vchelaru/FlatRedBall. Keep the default folder as **FlatRedBall**
5. Click the Clone button ![](media/2021-08-img\_6112a90f42a84.png)
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
2.  Select the **Project** -> \*\*Link Game to FRB Source \*\*menu item

    ![](media/2023-07-img\_64b5303d1f0e2.png)
3.  The \*\*Add FRB Source \*\*tab appears, showing a text box for FlatRedBAll and Gum root folders. If your current project is also a Git project which is cloned to the same folder as FlatRedBall and Gum, then the FRB Editor attempts to fill in the file paths.

    ![](media/2023-07-img\_64b531293eff9.png)
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

    ![](media/2017-02-img\_5892095362770.png)
5. Press the Delete key to remove this reference
6. Right-click on the solution
7. Select **Add -> Existing Project...**
8.  Navigate to the location of the FlatRedBall .csproj file for your given platform. For example, for PC, add \*\*\<FlatRedBall Root>\Engines\FlatRedBallXNA\FlatRedBall\FlatRedBallDesktopGL.csproj \*\*

    ![](media/2021-08-img\_6112a9f5767f4.png)
9. Click Open to add the project to your game's solution
10. Right-click on your game's **References** item and select **Add Reference...**
11. Click the "Projects" category
12. Check the FlatRedBallDesktopGL project (or whichever FlatRedBall project used for the given platform)
13. Click OK

    ![](media/2017-02-img\_58920a8e61d75.png)
14. Build and run your project

### Building Glue

#### Prequisites

Verify that you have .NET 6 SDK installed [https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.309-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.309-windows-x64-installer)   The Glue solutions (.sln files) reference the FlatRedBall engine, so you do not have to open the FlatRedBall engine .sln files first. To build Glue, follow these steps:

1. Download the FlatRedBall repository (either clone it or download the .zip file from Github)
2.  Download the [Gum repository](https://github.com/vchelaru/Gum). Make sure to download it to the same folder where you downloaded the FlatRedBall repository, and name the folder Gum. See below for an example.

    ![](media/2016-11-img\_583909d260b0c.png)
3.  Open the file **\<FlatRedBall Root>\FRBDK\Glue\Glue with All.sln.**

    ![](media/2021-08-img\_6112b22407f6b.png)
4. Verify that your build configuration is Debug, x86
5. Build the project

It's important that Gum and FlatRedBall are checked out to the same folder. For example, you may have:

* c:/MyDocuments/FlatRedBall
* c:/MyDocuments/Gum

### GlueWithGum.sln

The "GlueWithGum.sln" solution includes Glue and the Gum plugin. If you run Glue from Visual Studio, you must first "Build Solution" so that the Gum plugin gets built. Simply debugging (pressing F5) does not build the Gum plugin.

### Troubleshooting

#### Microsoft.Windows.UI.Xaml.CSharp.targets was not found...

When opening the project, you may get a message which states:

```
The imported project "C:\Program Files (x86)\MSBuild\Microsoft\WindowsXaml\v14.0\8.1\Microsoft.Windows.UI.Xaml.CSharp.targets" was not found. Confirm that the path in the <Import> declaration is correct, and that the file exists on disk. C:\Program Files (x86)\MSBuild\Microsoft\WindowsXaml\v14.0\Microsoft.Windows.UI.Xaml.CSharp.targets
```

For information on how to solve this problem, see the following link: [http://www.c-sharpcorner.com/UploadFile/8a67c0/visual-studio-2015-feature-shared-project-part-2/](http://www.c-sharpcorner.com/UploadFile/8a67c0/visual-studio-2015-feature-shared-project-part-2/)

####

&#x20; &#x20;
