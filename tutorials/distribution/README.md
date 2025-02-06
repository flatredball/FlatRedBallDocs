# Distribution

### Introduction

FlatRedBall games are distributed similar to any other app for a given platform. In some cases (such as iPhone and Android), a dedicated store exists for distribution. In other cases such as PC games, distribution can be done in a number of ways.

### Distributing Windows (Desktop GL) Games

The DesktopGL platform provides the most flexibility for distribution.

#### Distributing Debug Builds

The easiest way to distribute your game is to package it in a .zip file. When you build your game in Visual Studio, the output window displays the location where the built files are located:

![](../../.gitbook/assets/2021-07-img_60ef661acb76b.png)

Note that if you are building your game in Glue, the output directory may differ. The location will be displayed in the Build tab when you build and run your game in Glue:

![](../../.gitbook/assets/2021-07-img_60ef6658f2d1a.png)

To distribute this game, navigate to the folder where the game is built, select all files, and zip them. You may want to exclude .pdb files, as they can increase the size of your zip file.

![](../../.gitbook/assets/2021-07-img_60ef66dc4d0a1.png)

This zip file can be sent to others such as testers or friends.

#### Distributing Release Build

To create a release build, switch your build configuration to Release. If you are linked against prebuilt .dlls or NuGet packages and you would like to include FlatRedBall release packages, see the [Release Build](release-build.md) page.

<figure><img src="../../.gitbook/assets/image (7).png" alt=""><figcaption><p>Switch to Release build</p></figcaption></figure>

Verify that you can build and run your game.

Next, right-click on your game and select the Publish item.

<figure><img src="../../.gitbook/assets/11_10 12 16.png" alt=""><figcaption><p>Publish item</p></figcaption></figure>

Select Folder unless you know how to publish to the other options.

Once you finish publishing, you can zip the project.

### Distributing FlatRedBall Web Games

To distribute a FlatRedBall Web project:

1. Open your project in Visual Studio
2. Switch your project to Release build
   1. If you are linking FlatRedBall nuget packages, instead consider linking to FlatRedBall Source so you can build the engine in release mode. FlatRedBall nuget packages distribute in debug configuration.
3.  Select **Build** -> **Publish YourProjectName**\


    <figure><img src="../../.gitbook/assets/image (5) (1) (1) (1).png" alt=""><figcaption><p>Publish menu command</p></figcaption></figure>
4. If asked, select the option to publish to a Folder unless you are familiar publishing with the other options
5. Confirm the folder where you would like to publish, then click **Finish**
6.  Click the Publish button on the Publish tab\


    <figure><img src="../../.gitbook/assets/image (6) (1).png" alt=""><figcaption><p>Click the Publish button</p></figcaption></figure>
7. Wait for your project to finish building

After the project finishes building, click the **Navigate** link.&#x20;

<figure><img src="../../.gitbook/assets/image (9).png" alt=""><figcaption><p>Navigate link i nthe Publish tab</p></figcaption></figure>

The project can be uploaded to any location through FTP. For information on uploading to itch.io, see the itch.io [distribution page](itch.io.md).
