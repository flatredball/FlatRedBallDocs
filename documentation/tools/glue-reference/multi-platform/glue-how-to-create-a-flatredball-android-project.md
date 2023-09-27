## Introduction

FlatRedBall supports game development on Android devices. This section will show you how to make FlatRedBall Android games.

## Prerequisites

FlatRedBall Android game development requires a Windows PC just like regular PC game development. Since FlatRedBall requires using the C# programming language, FlatRedBall Android development requires using the Xamarin compiler, which is freely available when installing Visual Studio.

## Primary Android vs. synced Android projects

FlatRedBall supports creating a primary Android project as well as a synced Android project. A primary Android project refers to creating a single solution file (.sln) is created. This solution file can be opened in Xamarin Studio or in Visual Studio. A synced Android project refers to creating two solution files - one for PC and one for Android. The PC project is developed as a regular FlatRedBall PC (desktop) project in Visual Studio. The FlatRedBall Editor generates an Android project, and keeps it in sync with the PC project automatically. Benefits to creating a primary Android project:

-   Shorter initial setup
-   Less hard drive memory usage
-   Simpler file structure

Benefits to creating a synced Android project:

-   Superior debugging support on PC platforms when compared to Android debugging
-   Faster execution of a project as compared to deploying to an emulator or physical device
-   Allows multiple team members to develop and run the project without installing Xamarin
-   Improved iteration speed through edit-and-continue and automatic content reloading at runtime.

For more information on synced projects, see the [synced project page](/frb/docs/index.php?title=Glue:Reference:Menu:File:New_Synced_Project "Glue:Reference:Menu:File:New Synced Project").

## Creating a primary Android project

Creating an Android project is essentially identical to creating any other platform:

1.  Open the FlatRedBall Editor
2.  Select **File**-\>**New Project**
3.  Enter a project name
4.  Set the **Platform** to **Android**
5.  Click **Create project!**

![](/media/2022-03-img_6235dcc952264.png)

Select the desired project type in the wizard, or close the wizard to begin with an empty project. Click the Visual Studio icon to open the project in Visual Studio:

![](/media/2022-03-img_6235dd408496f.png)

Now that the project is in Visual Studio, you can develop an Android game the same as if you were making a PC game, including using Glue. To launch the game:

1.  Open your Android emulator of choice (such as the Xamarin Android Player)
2.  Verify that the **Play** button in Visual Studio has the desired emulator selected. Note that if a physical Android device is connected to your computer and is set up for debugging, then Visual Studio will detect it as a deployment option.
3.  Press the Play button

![](/media/2016-11-img_581ac5bb6021e.png)

  ![RunningGenymotion.png](/media/migrated_media-RunningGenymotion.png)

## Creating a synced Android project

Synced Android projects are created just like any other synced project. The first step is to create a regular Windows Desktop project. Once the project is created a new synced Android project can be created as follows:

1.  Open Glue
2.  Select **Project**-\>**View Projects**
3.  Click the **New Synced Project** button
4.  Select the **Android** option
5.  Enter a project name
6.  Click **Make my project!**

[![](/wp-content/uploads/2016/01/2019-04-08_07-55-31.gif)](/wp-content/uploads/2016/01/2019-04-08_07-55-31.gif) The project will take a moment to download and be created, but once it is, you will see the Android project listed in the Androids project list. Since your Glue project now has multiple platforms, you can choose which project to open through the Projects tab.

![](/media/2019-04-img_5cab537d772c4.png)

## Releasing an Android Project

To create an Android APK, whether for internal testing or for final release, see the [Microsoft release documentation](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows).

## Troubleshooting

Unfortunately deploying to Android can be fickle at times, and sometimes no errors are provided.

### App crashes immediately

If your app crashes immediately without a call stack, then you may want to try the following:

-   Does the app work on Android hardware? Sometimes an app will not work on emulator but will work on hardware
-   Have you tried creating a Xamarin Forms project? Xamarin Forms projects can be created with templates which are maintained by Xamarin, so they are likely to eliminate common problems in template setup. If a Xamarin Forms project doesn't work, then that might mean that prerequisites are not properly installed.

### The imported project ...\Xamarin.Android.CSharp.targets was not found

This happens on newer versions of .NET. To fix this:

1.  Locate where your Xamarin targets are installed. This is usually located in the Visual Studio directory. For example: C:\Program Files\Microsoft Visual Studio\2022\Community\Msbuild
2.  Copy the Xamarin folder from this location into the location reported in the error dialog.
3.  Restart the FlatRedBall Editor

![](/media/2022-12-img_63b0c60e2d31f.png)

 
