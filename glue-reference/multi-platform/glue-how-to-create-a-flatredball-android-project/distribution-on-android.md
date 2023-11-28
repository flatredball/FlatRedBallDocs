## Introduction

Android builds can be distributed using a digital store (such as Google or Android), or can be manually distributed by distributing a .apk.

Before you perform any distribution, you must create a release build of your app.

## Creating a Release Build

The following will walk you through creating a release build. Release builds can be created for any FlatRedBall Android project, including synced Glue projects. This walkthrough assumes that you have an Android project which you have been able to successfully deploy to device through Xamarin Studio or Visual Studio.

### Switching to a Release Build

If using Xamarin Studio, change the configuration to release:

![XamarinRelease.png](/media/migrated_media-XamarinRelease.png)

Release builds are required for distributed .apk files.

### Linking the Release FlatRedBall DLLs

Distributed builds also require linking against the release build of FlatRedBall. If using the .dll files which are distributed with the FlatRedBall templates (default), then your project will already have the release files downloaded.

These can be found in your project's Libraries folder:

![ReleaseAndDebug.PNG](/media/migrated_media-ReleaseAndDebug.PNG)

To link the release files in Xamarin Studio:

1.  Right-click on your game project's References
2.  Select "Edit References..."
3.  Select the ".Net Assembly" tab
4.  Un-check the FlatRedBallAndroid.dll file
5.  Click the "Browse..."
6.  Navigate to the \<project folder\>/Libraries/Android/Release folder
7.  Select FlatRedBallAndroid.dll and click Open
8.  Verify that the release build of FlatRedBall is added and click OK

![VerifyReleaseAndroidDll.png](/media/migrated_media-VerifyReleaseAndroidDll.png)

Once this library has been added, build and run your project to make sure everything is working fine.

### Setting Supported Architecture

The project needs to specify the architectures it will support. Unless you are concerned about file size, you should support all architectures. To do so:

1.  Right-click on your project
2.  Select "Options"
3.  Select the "Android Build" option
4.  Click the "Advanced" tab
5.  Check the desired supported architectures:

![SupportedReleaseArchitectures.PNG](/media/migrated_media-SupportedReleaseArchitectures.PNG)

### Creating an APK

The .apk file is what you need to distribute to test it on other phones. In Xamarin Studio:

1.  Select "Project" -\> "Create Android Package..."
2.  Enter a name in the "File:" text box for the desired .apk file name
3.  Click OK

### Distributing the APK File

Once the .apk file has been created it can be distributed through any digital means, such as google drive, drop box, or sending the file through email.

## Android Linking

Xamarin's Android compiler includes a feature which allows selective inclusion of libraries, classes, and members. This feature can reduce the size of a game, but also can introduce crashes which can be difficult to diagnose - at least unless you know what to look for.

The most common type of crash occurs when deserializing XML files, such as emitter .emix files. If your program runs fine in debug but crashes in release, then it may be related to Xamarin's linking behavior. You can verify that this is the case by looking at the output window. For example, the following error appears when trying to load a .emix file.

    There was an error reflecting type 'FlatRedBall.Content.Particle.EmitterSaveList'. ---> 
    System.InvalidOperationException: There was an error reflecting field 'emitters'. ---> 
    System.InvalidOperationException: There was an error reflecting type 'FlatRedBall.Content.Particle.EmitterSave'. ---> 
    System.InvalidOperationException: There was an error reflecting field 'ParticleBlueprint'. ---> 
    System.InvalidOperationException: There was an error reflecting type 'FlatRedBall.Content.Particle.ParticleBlueprintSave'. ---> 
    System.InvalidOperationException: FlatRedBall.Content.Particle.ParticleBlueprintSave cannot be serialized because it does not have a default public constructor

One way to solve this problem is to adjust the linking behavior, which can be done as follows:

1.  Right-click on the project in the Solution Pad
2.  Select "Options"
3.  Select the "Android Build" category
4.  Click the "Linker" tab
5.  Change "Link all assemblies" to either "Link SDK Assemblies only" or "Don't link"
6.  Try running again and see if the crash occurs

The downside to this solution is that these will increase the size of your APK file.

For more information on linking, [see this article](http://developer.xamarin.com/guides/android/advanced_topics/linking/).
