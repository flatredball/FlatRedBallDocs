# Setup

To use Spine in your project, you must do the following:

1. Link your project against FlatRedBall Source
2. Link your project against the Spine

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
6. Link FlatRedBall.Spine.MonoGame.DesktopGL in your game project's dependencies.

Your project should now link to FlatRedBall.Spine.MonoGame.DesktopGL.csproj.

<figure><img src="../.gitbook/assets/15_06 53 53.png" alt=""><figcaption><p>SpineTest game linking FlatRedBall.Spine.MonoGame.DesktopGL</p></figcaption></figure>

### Adding FlatRedBall.Spine Plugin

Although it is not necessary, using the FlatRedBall.Spine plugin is recommended as it can reduce the amount of code necessary to work with Spine. To install the FlatRedBall.Spine plugin:

1. Download the SpinePlugin.plug file from the Releases page [https://github.com/flatredball/FlatRedBall.Spine/releases](https://github.com/flatredball/FlatRedBall.Spine/releases)
2. Select **Plugin->Install Plugin** in FlatRedBall
3. Use the ... button to locate and select the SpinePlugin.plug file, then click OK
4. Restart FlatRedBall&#x20;

Once you have restarted FlatRedBall, you should see Spine listed in the installed plugin. Select **Plugins -> Manage Plugins,** and scroll down to make sure the plugin has installed.

<figure><img src="../.gitbook/assets/15_07 25 10.png" alt=""><figcaption><p>Spine Plugin in FlatRedBall</p></figcaption></figure>

