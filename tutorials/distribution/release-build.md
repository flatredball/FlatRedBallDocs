# Release Build

### Introduction

By default FlatRedBall templates build the debug configuration. These templates are distributed with release and debug versions of the libraries being used in the project. Therefore, to switch between release and debug you should also switch which set of libraries you are referencing. The steps to switch between debug and release depend on whether the application is linking to prebuilt binaries or source.

### Example - Switching DesktopGL Template to Release with Prebuilt Binaries

To switch a DesktopGL template to release:

1. Open your project in Visual Studio
2.  Change the configuration from **Debug** to **Relese**

    ![](../../.gitbook/assets/2021-01-img\_5fef809f8a9da.png)
3. Expand your project in the **Solution Explorer**, and expand the **References** item
4.  Right-click on one of the FlatRedBall projects and select Properties

    ![](../../.gitbook/assets/2021-01-img\_5fef817fa879f.png)
5. In the Properties window, find the location where the FlatRedBall library is located![](../../.gitbook/assets/2021-01-img\_5fef81e0a1f88.png)
6.  Once the properties window is open, identify all of the libraries which are being being referenced out of your game's Libraries folder.

    In the case of DesktopGL these are:

    1. FlatRedBall.Forms
    2. FlatRedBallDesktopGL
    3. GumCoreXnaPc
    4. StateInterpolation
7.  Remove these references from your project by right clicking and selecting **Remove**

    ![](../../.gitbook/assets/2021-01-img\_5fef8294a5593.png)
8.  After you removed the references, right-click on your project and select **Add Reference...**

    ![](../../.gitbook/assets/2021-01-img\_5fef80ec558e6.png)
9.  Click the **Browse...** button

    ![](../../.gitbook/assets/2021-08-img\_6110006f1ee25.png)
10. Navigate to your project's folder. Select the **Libraries/DesktopGL/Release** folder
11. Add the libraries which were removed in the previous step from the Release folder
12. Click OK

If you are going to build your game in Debug mode, you should link Debug FlatRedBall .dlls. Similarly, if you are going to build your game in Release, you should link Release FlatRedBall .dlls. Mixing Debug and Release may result in compile errors, as FlatRedBall provides additional classes and members in Debug mode which code generation relies upon for improved diagnostics.

### Example - Switching to Release With Source

If your project links to FlatRedBall Source, then you only need to switch the configuration of your project:

![](../../.gitbook/assets/2022-10-img\_633c713f68695.png)

All libraries should switch to release automatically.
