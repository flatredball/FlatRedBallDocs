# Setup

To use Spine in your project, you must do the following high level steps. Each step will be explained in detail below:

1. Link your game project against FlatRedBall Source
2. Link your game project against the Spine
3. Load the Spine shader (.fx) file

You can use Spine purely in code, or you can use Spine in the FlatRedBall Editor by adding the Spine plugin. The FlatRedBall Editor plugin enables adding Spine files (skeleton and atlas) to your FlatRedBall project. The plugin generates code for loading these files.

To use the Spine plugin, you must also install the SpinePlugin .plug file.

### Linking to Source

The first step is to link your FlatRedBall project to source. To link your game to FlatRedBall Source, see the [Building FlatRedBall From Source page](../flatredball-source.md#adding-flatredball-source-to-a-game-project-using-the-frb-editor).

Once you have linked your game to FlatRedBall Source, you need to link your game to FlatRedBall.Spine.MonoGame.DesktopGL. As of January 15, 2024, MonoGame DesktopGL is the only platform that supports FlatRedBall.Spine. New platforms will likely be added over time. If you are planning on targeting a new platform, make a request on Discord.

To add FlatRedBall.Spine to your project:

1. Clone the repository for FlatRedBall.Spine [https://github.com/flatredball/FlatRedBall.Spine](https://github.com/flatredball/FlatRedBall.Spine)
2. Open your project in Visual Studio
3. Right-click on your Solution in the Solution Explorer
4. Select Add -> Existing Project...
5. Navigate to the folder where you cloned FlatRedBall.Spine and select `<FlatRedBall.Spine Root>/Source/FlatRedBall.Spine.MonoGame.DesktopGL.csproj`
6. Expand your game project and right-click on Dependencies, then select **Add Project Reference...**
7. Check FlatRedBall.Spine.MonoGame.DesktopGL to link this library in your game project's dependencies, then click **OK**.

Your project should now link to FlatRedBall.Spine.MonoGame.DesktopGL.csproj.

<figure><img src="../.gitbook/assets/15_06 53 53.png" alt=""><figcaption><p>SpineTest game linking FlatRedBall.Spine.MonoGame.DesktopGL</p></figcaption></figure>

After adding the reference, be sure to save your project. You can do this by selecting the File->Save All option in Visual Studio, or by pressing CTRL+SHIFT+S in Visual Studio. Alternatively, you can run your game which saves the .csproj.

This step is important because the .csproj modifications must be saved so the FRB Editor can re-load the .csproj. Forgetting this step can result in the library not being linked.

### Adding FlatRedBall.Spine Plugin

Although it is not necessary, using the FlatRedBall.Spine plugin is recommended as it can reduce the amount of code necessary to work with Spine. To install the FlatRedBall.Spine plugin:

1. Download the SpinePlugin.plug file from the Releases page [https://github.com/flatredball/FlatRedBall.Spine/releases](https://github.com/flatredball/FlatRedBall.Spine/releases)
2. Select **Plugin->Install Plugin** in FlatRedBall
3. We recommend selecting "For User" so the plugin is installed globally, but you can do it for project if you do not want other projects to use this plugin.
4. Use the ... button to locate and select the SpinePlugin.plug file, then click OK
5. Restart the FlatRedBall Editor

Once you have restarted FlatRedBall, you should see Spine listed in the installed plugin. Select **Plugins -> Manage Plugins,** and scroll down to make sure the plugin has installed.

<figure><img src="../.gitbook/assets/15_07 25 10.png" alt=""><figcaption><p>Spine Plugin in FlatRedBall</p></figcaption></figure>

### Alternative - Adding FlatRedBall.Spine Plugin from Source

Alternatively you can clone the Spine plugin if you prefer to build from source and diagnose problems. To do this:

1. Clone the FlatRedBall.Spine repository [https://github.com/flatredball/FlatRedBall.Spine](https://github.com/flatredball/FlatRedBall.Spine/releases). If you clone both FRB and this repository to the same root Github location, then the file links will work correctly
2. Open SpinePlugin/SpinePlugin.sln
3. Build->Rebuild the plugin

The latest plugin .dll will be built and also copied over to the Glue output folder.

### Loading the Spine Shader

The SpineShader is required to render Spine. To load the Spine Shader:

1. Download SpineEffect.fx file from the Releases page [https://github.com/flatredball/FlatRedBall.Spine/releases](https://github.com/flatredball/FlatRedBall.Spine/releases)
2.  Add the SpineEffect.fx file to GlobalContent by drag+dropping the file into your Global Content Files folder in FlatRedBall\


    <figure><img src="../.gitbook/assets/image (142).png" alt=""><figcaption><p>SpineEffect.fx in Global Content Files</p></figcaption></figure>
3. Open Game1.cs and add the following code in Initialize after `GeneratedInitialize();`:

```csharp
FlatRedBall.Spine.SpineManager.Initialize(
    graphics.GraphicsDevice, 
    GlobalContent.SpineEffect);
```

### Troubleshooting

The type or namespace name 'Spine' does not exist in the namespace 'FlatRedBall' (are you missing an assembly reference?)

If you are missing a Spine reference in FlatRedBall, then you may not have saved the .csproj after adding a reference to the Spine project. To fix this:

1. Right-click on your game project's Dependencies and select Add Project Reference
2.  Check if the FlatRedBall.Spine.MonoGame.DesktopGL (or appropriate project for your target platform) is selected. \


    <figure><img src="../.gitbook/assets/image (23).png" alt=""><figcaption><p>Deselected FlatRedBall.Spine.MonoGame.DesktopGL project reference</p></figcaption></figure>
3. If not, check the project, click ok, then save you project. At this point you can build/run your game and this also saves your .csproj.
