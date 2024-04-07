# Android

### Introduction

FlatRedBall supports creating games which run on Android devices. Aside from Android-specific capabilities, FlatRedBall Android development is nearly identical to developing games for other platforms. As of April 2024 FlatRedBall Android projects use .NET 8 which provides access to a much wider set of features and nuget packages compared to the previous Xamarin-based version.

### Prerequisites

FlatRedBall Android game development requires a Windows PC just like regular PC game development as well as Visual Studio 2022 or newer.

### Primary Android vs. synced Android projects

As mentioned in the [Multi-Platform](../) page, the recommended approach for creating full game projects  is to create a primary desktop project with a synced Android project. However, if you are evaluating FlatRedBall, or creating a small test project, you may want to create a primary Android project. Both approaches are discussed below.

### Creating a primary Android project

Creating an Android project is essentially identical to creating any other platform:

1. Open the FlatRedBall Editor
2. Select **File**->**New Project**
3. Enter a project name
4. Set the **Platform** to **Android .NET**
5. Click **Create project!**

![The New Project window for creating an Android project](<../../../.gitbook/assets/07\_09 03 11.png>)

Select the desired project type in the wizard, or close the wizard to begin with an empty project. Click the Visual Studio icon to open the project in Visual Studio:

![Open the project in Visual Studio](../../../media/2022-03-img\_6235dd408496f.png)

Now that the project is in Visual Studio, you can develop an Android game the same as if you were making a PC game, including using the FRB Editor. To launch the game:

1. Select the target device
   1. If you have a physical phone, you can connect it to your computer. You need to enable your phone for development by turning on developer mode. For more information see the Microsoft page for setting up an Android device: [https://learn.microsoft.com/en-us/dotnet/maui/android/device/setup?view=net-maui-8.0](https://learn.microsoft.com/en-us/dotnet/maui/android/device/setup?view=net-maui-8.0)
   2. If you do not have a physical phone, or if you prefer to use an Android emulator, see the following page on how to set up an Android emulator: [https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/?view=net-maui-8.0](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/?view=net-maui-8.0)
2. Verify that the **Play** button in Visual Studio has the desired emulator or device selected. Note that if a physical Android device is connected to your computer and is set up for debugging, then Visual Studio will detect it as a deployment option.\

3. Press the Play button

![Emulator running and showing up in Visual Studio](../../../media/2016-11-img\_581ac5bb6021e.png)

![FlatRedBall project running in an emulator](../../../media/migrated\_media-RunningGenymotion.png)

### Creating a synced Android project

Synced Android projects are created just like any other synced project. The first step is to create a regular Windows Desktop project. Once the project is created a new synced Android project can be created as follows:

1. Open FlatRedBall
2. Select **Project**->**View Projects**
3. Click the **New Synced Project** button
4. Select the **Android** option
5. Enter a project name
6. Click **Make my project!**

<figure><img src="../../../.gitbook/assets/07_09 11 15.gif" alt=""><figcaption><p>Creating a new Android Synced Project</p></figcaption></figure>

The project will take a moment to download and be created, but once it is, you should see the Android project listed in the Androids project list. Since your FlatRedBall project now has multiple platforms, you can choose which project to open through the Projects tab.

![Synced Android project](<../../../.gitbook/assets/07\_09 12 21.png>)

### Releasing an Android Project

To create an Android APK, whether for internal testing or for final release, see the [Microsoft release documentation](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows).

### Troubleshooting

Unfortunately deploying to Android can be fickle at times, and sometimes no errors are provided.

#### App crashes immediately

If your app crashes immediately without a call stack, then you may want to try the following:

* Does the app work on Android hardware? Sometimes an app will not work on emulator but will work on hardware
* Have you tried creating a .NET MAUI? MAUI projects can be created with templates which are part of Visual Studio, so they are likely to eliminate common problems in template setup. If a MAUI project doesn't work, then that might mean that prerequisites are not properly installed.
