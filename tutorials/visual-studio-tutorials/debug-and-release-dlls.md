## Introduction

FlatRedBall templates include both debug and release builds of FlatRedBall. By default FlatRedBall projects reference the Debug .dlls. When projects reference the Debug .dlls, they incur some performance penalty, but in exchange FlatRedBall provides better error reporting. The Release .dlls can be referenced when a game is going to be released, or when testing performance.

## DLL Locations

FlatRedBall Debug .dll files can be found in: \<.csproj Location\>/Libraries/\<Platform\>/Debug/ FlatRedBall Release .dll files can be found in: \<.csproj Location\>/Libraries/\<Platform\>/Release/

## Changing to Debug or Release

Changing your game to use Debug or Release can be done through Visual Studio. The libraries which need to be changed depend on the platform for a specific project. For synced projects, each Visual Studio project must be changed individually. For this example we will change a DesktopGL project to use Release .dlls:

1.  Open your project in Visual Studio

2.  Expand the References node under your project. Note which references are here which need to be replaced. In our case **FlatRedBallDesktopGL** is the only one.

    ![](/media/2017-09-img_59b14b2d216f1.png)

3.  Right-click on **FlatRedBallDesktopGL** and select **Remove**

4.  Right-click on **References** and select **Add Reference...**

5.  Click on the **Browse** category on the left of the **Reference Manager** window

6.  Click the **Browse...** button

7.  Navigate to the **Release** libraries folder (as indicated above in the DLL Locations section)

8.  Select the required FlatRedBall .dll file - in this case **FlatRedBallDesktopGL.dll**

9.  Click **Add**

10. Click **OK** in the **Reference Manager**

Note: Visual Studio 2017 has a bug where the wrong .dll is displayed in the properties window. You can verify that your project is referencing the correct .dll by opening the .csproj file in a text editor and searching for the library reference.

![](/media/2017-09-img_59b152226a138.png)
