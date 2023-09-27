## Introduction

The FlatRedBall.Content.dll library provides the functionality for converting various FlatRedBall file types to .xnb files which can be loaded at runtime.

## Step by step

The following steps cover how to add a .scnx file to your project, load it from XNB at run time, then add the instance to the engine for management. Keep in mind that the process for adding any content is almost identical.

1.  First, you will need a .scnx to load. I will use the official FlatRedBall splash screen which can be found [here](/frb/docs/images/2/2e/SplashScreen.zip.md "SplashScreen.zip").
2.  Next, create folders for the scene. It is common to create folders to hold assets in FlatRedBall XNA projects. Right click on your Content project which is embedded in your project (this should be present in all XNA projects), select Add-\>New Folder. Name the new folder Scenes. **The "Content" project should automatically exist in your project. It will have been created when you first made the FRB XNA template**. If not you may not be using FlatRedBall XNA. In that case, there is no built-in content pipeline support, so you may have to create your own. ![EmptyScenesInContent.png](/media/migrated_media-EmptyScenesInContent.png)
3.  Navigate to the folder containing your .scnx file. Drag the .scnx file to your Content/Scenes folder in the Solution Explorer. The File should appear in your solution explorer. ![SceneInScenesFolder.png](/media/migrated_media-SceneInScenesFolder.png)
4.  The folder where your .scnx was unzipped should also have a Frblogo.png file. Also drag this into the Scenes folder where your .scnx was dragged to in the last step. ![FrbLogoInScenesFolder.png](/media/migrated_media-FrbLogoInScenesFolder.png)
5.  When you build your project, the .scnx file will be converted to a .xnb file. This .xnb is what your game will load at runtime. Any files that the .scnx references will also become .xnb files (like the FrbLogo.png file). However, the Content Pipeline for Scenes knows to search for any textures that the .scnx references and automatically convert them to .xnb files. Therefore, we need to make sure that Visual Studio **does not** to convert the .png to a .xnb. Otherwise we will end up with duplicate .xnb files. To tell Visual Studio to not do anything with FrbLogo.png, right click on FrbLogo.png in your Solution Explorer and select Properties. ![RightClickProperties.png](/media/migrated_media-RightClickProperties.png)
6.  Set the "Build Action" to None and verify that the "Copy to Output Directory" is set to "Do not copy". ![FrbLogoProperties.png](/media/migrated_media-FrbLogoProperties.png)
7.  Build your project.
8.  Add the following code to your Initialize after FlatRedBallServices.Initialize:

&nbsp;

    Scene scene = FlatRedBallServices.Load<Scene>(@"Content\Scenes\SplashScreen");
    scene.AddToManagers();

Press F5 to run the application.![SplashScreen.png](/media/migrated_media-SplashScreen.png)

## Associated Pipeline Classes

If you drag a file into Visual Studio from an explorer window (as shown above) then the ContentImporter and ContentProcessor will automatically be selected for you. However, if you are adding files another way and need to select the ContentImporter/ContentProcessor, the following table may help:

|           |                             |                              |
|-----------|-----------------------------|------------------------------|
| File Type | ContentImporter             | ContentProcessor             |
| .achx     | AnimationChainArrayImporter | AnimationChainArrayProcessor |
| .emix     | EmitterImporter             | EmitterProcessor             |
| .nntx     | NodeNetworkImporter         | NodeNetworkProcessor         |
| .scnx     | SceneFileImporter           | SceneFileProcessor           |
| .shcx     | ShapeCollectionImporter     | ShapeCollectionProcessor     |
| .srgx     | SpriteRigImporter           | SpriteRigProcessor           |

## Debugging

If you've followed the steps above but you are experiencing problems (such as a crash at runtime), then try the following steps:

-   **Check for the output files** - When using the content pipeline, you will be creating one or more file(s) ending in the XNB extension. Any XNB file will have the same (or very similar) name as the original content file. For example, if you are loading "splashScreen.scnx", then you will generate a file called "splashScreen.xnb". Remember, the folder structure of your project will be the same in your build folder. Therefore, if you're building on the PC in Debug mode, and if your scene is located in "Content\Scenes", then you should have the following file:

&nbsp;

    <your project location>\bin\x86\Debug\Content\Scenes\splashScreen.xnb

-   **Check for FlatRedBall.Content** - If you are attempting to build FlatRedBall types, then you must have the FlatRedBall.Content referenced in your content project. To check for this, expand your Content folder, then expand your References and make sure that this library is linked. The default template should have this library referenced, but this may have become unreferenced if you are having problems with content building.![ReferencedFlatRedBallContent.png](/media/migrated_media-ReferencedFlatRedBallContent.png)

## Additional Information

-   [FlatRedBallServices wiki entry](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.md "FlatRedBall.FlatRedBallServices") - Includes information on the Load method.
-   [FlatRedBall Content Manager wiki entry](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager") - Includes information on loading using content managers.
