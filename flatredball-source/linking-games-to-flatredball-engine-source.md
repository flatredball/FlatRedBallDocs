# Linking Games to FlatRedBall Engine Source

### Adding FlatRedBall Source to a Game Project using the FRB Editor

To add the FRB source to your project:

1. Make sure you have already cloned the **FlatRedBall** and **Gum** repositories. We recommend using Github for Desktop and cloning to the default location so that your game and FlatRedBall are sibling folder sin the same parent folder.&#x20;
2. Open your project in the FlatRedBall Editor
3.  Select the **Project** -> **Link Game to FRB Source** menu item\


    <figure><img src="../.gitbook/assets/image.png" alt=""><figcaption><p>Link game to FRB source menu item</p></figcaption></figure>
4.  The **Add FRB Source** tab appears, showing a text box for FlatRedBall and Gum root folders. If your current project is also a Git project which is cloned to the same folder as FlatRedBall and Gum, then the FRB Editor attempts to fill in the file paths.\


    <figure><img src="../.gitbook/assets/image (1).png" alt=""><figcaption><p>Add FRB Source tab in the FRB Editor adds all necessary projects to your game's solution</p></figcaption></figure>


5. If your paths are blank or incorrect, use the ... button to select the file paths for each repository. Select the root folder for where Gum and FRB repositories.
6. If you are planning to use Gum Skia, check the option
7. Click **Link to Source**
8. After your project is linked, the **Add FRB Source** tab will disappear

Your game project should now directly reference the FlatRedBall Source.

<figure><img src="../.gitbook/assets/image (2).png" alt=""><figcaption><p>FlatRedBall projects linked in a game project</p></figcaption></figure>

#### Game Project Location and FlatRedBall Source

The FlatRedBall Editor attempts to link FlatRedBall source regardless of the location of your projects relative to source. We strongly recommend keeping your project in the same directory (such as C drive) as FlatRedBall source. Otherwise, projects will be linked using absolute paths which makes your project far less portable. By using absolute paths others who clone your project must have the same exact folder structure as you do or the project will not build and run.

Furthermore, Github for Desktop always clones projects to the same directory: `C:\YouserUerName\Owner\Documents\GitHub\YourProjectName`

We recommend keeping these defaults for all repositories - your game and FlatRedBall. By using default locations others can clone the engine and game without needing ot make modifications to their defaults.

### Adding FlatRedBall Source to a Game Project Manually

If you would like to use the engine source in your game project:

1. Open your game project in Visual Studio
2. Expand the game project in the solution explorer
3. Expand the References item
4.  Find the FlatRedBall entries. This is the reference to the prebuilt-dll. Note that these may be direct references or NuGet packages depending on which version of FlatRedBall you are using, so be sure to check under both **Assemblies** and **Packages**. Press the Delete key on all references as mentioned below:\


    <figure><img src="../.gitbook/assets/image (3).png" alt=""><figcaption></figcaption></figure>

    1. FlatRedBall DesktopGL:
       1. FlatRedBallDesktopGLNet6
       2. FlatRedBall.Forms.DesktopGlNet6
       3. GumCore.DesktopGlNet6
       4. SkiaInGum
       5. StateInterpolation.DesktopNet6
    2. FlatRedBall FNA:
       1. FlatRedBall.FNA
       2. FlatRedBall.Forms.FNA
       3. GumCore.FNA
       4. StateInterpolation.FNA
5. Right-click on the solution
6. Select **Add -> Existing Project...**
7.  Navigate to the location of the FlatRedBall .csproj file for your given platform. For example, for PC, add **\<FlatRedBall Root>\Engines\FlatRedBallXNA\FlatRedBall\FlatRedBallDesktopGL.csproj**\


    <figure><img src="../.gitbook/assets/image (5).png" alt=""><figcaption></figcaption></figure>
8. Click Open to add the project to your game's solutionComment
9. Right-click on your game's **References** item and select **Add Reference...**&#x43;omment
10. Click the "Projects" categoryComment
11. Check the FlatRedBallDesktopGL project (or whichever FlatRedBall project used for the given platform)Comment
12. Repeat the process for the other librariesComment
13. Click OK\


    <figure><img src="../.gitbook/assets/image (6).png" alt=""><figcaption></figcaption></figure>
14. Build and run your project

