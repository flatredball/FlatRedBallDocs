# Effect (.fx, .fxb)

Shader Effect Files (.fx) can be added to FlatRedBall projects. At runtime this produces an Effect object which can be used to perform custom rendering. FlatRedBall FNA projects require extra steps to use FX files as explained below.

### Creating a Post Processing Effect File

FlatRedBall can import existing .fx files, but also provides a standard way to create effect files for post processing. The easeist way to add a post processing effect file to your project is to use the Add File dialog:

1. Right-click on the Files folder where you would like to add your .fx file (such as Global Content Files or GameScreen) and select **Add File** -> **New File**
2. Select **Effect (.fx)** as the file type
3. Check the **Post Processing Shader** option
4. Verify that the **Include YourFileName.cs Post Process File** option is checked
5. Select the type of shader you would like to use. For example, **Saturation**.
6. Enter a name for your new effect file, such as **SaturationEffect.**
7. Click OK

<figure><img src="../../../.gitbook/assets/11_16 10 34.png" alt=""><figcaption><p>New file window creating an effect file</p></figcaption></figure>

This creates the following files in your project:

1. The .fx file. This is a text file using the HLSL syntax which you can edit
2. The .xnb file (if you are using MonoGame or targeting Web)
3. The accompanying PostProcess file
4. A FullscreenEffectWrapper.cs file. This file is only created one time when the first post processing effect is added

<figure><img src="../../../.gitbook/assets/image (1).png" alt=""><figcaption><p>New files for effects</p></figcaption></figure>

If you intend to use the effects as they are when created, you do not need to work with these files. However, these files can also serve as a starting point for your own shaders so you may be interested in locating them.

Once a shader has been added, you can add it to the global effect list. If your shader is part of Global Content Files, the addition can be perfomed in Game1. The following code shows how to add the shader to post processing in Game1.

```csharp
// Add this after GeneratedInitialize() in Game1.cs
var postProcess = new SaturationEffect(GlobalContent.SaturationEffect);
Renderer.GlobalPostProcesses.Add(postProcess);
Renderer.CreateDefaultSwapChain();

```

If you need more control you can manually create a SwapBuffer as shown in the following block of code:

```csharp
// Add this after GeneratedInitialize() in Game1.cs
var postProcess = new SaturationEffect(GlobalContent.SaturationEffect);
var cameraData = CameraSetup.Data;
Renderer.SwapChain = new FlatRedBall.Graphics.PostProcessing.SwapChain(
    FlatRedBallServices.Game.Window.ClientBounds.Width,
    FlatRedBallServices.Game.Window.ClientBounds.Height);
    
FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += (_,_) =>
{
    Renderer.SwapChain.UpdateRenderTargetSize(
        FlatRedBallServices.Game.Window.ClientBounds.Width,
        FlatRedBallServices.Game.Window.ClientBounds.Height);
};
    

```

If your shader is part of a screen such as GameScreen, you can add it in the Screen's CustomInitialize. Note that if you add it in the Screen's CustomInitialize, you should also remove it in CustomDestroy. The following code shows how an affect might be added through GameScreen.

```csharp
public partial class GameScreen
{
    SaturationEffect SaturationPostProcess;
    private void CustomInitialize()
    {
        if(Renderer.SwapChain == null)
        {
            // Only create the SwapChain once just in case this was already
            // created earlier (like if this screen is restarted)
            Renderer.CreateDefaultSwapChain();
        }
        
        SaturationPostProcess = new SaturationEffect(GameScreen.SaturationEffect);
        SaturationPostProcess.Saturation = 0;
        Renderer.GlobalPostProcesses.Add(SaturationPostProcess);
    }

    private void CustomActivity(bool firstTimeCalled)
    {
    }

    private void CustomDestroy()
    {
        Renderer.GlobalPostProcesses.Remove(SaturationPostProcess);
    }

    private static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

Note that by using a SwapChain, FlatRedBall internally creates and assigns a RenderTarget when performing rendering, so you should not manually create and assing a RenderTarget prior to drawing FlatRedBall.

### Effect Files in MonoGame

Effect files require the use of the MonoGame Content Pipeline. If you are using the FlatRedBall Editor, this is automatically handled for you. You can verify that this is the case by checking the UseContentPipeline property.

<figure><img src="../../../.gitbook/assets/image (211).png" alt=""><figcaption><p>Effect file using content pipeline</p></figcaption></figure>

### Effect Files in FNA

FNA does not provide a content pipeline, and use of XNA Content Pipeline is discouraged because it does not function in newer versions of Visual Studio.

Instead, FNA recommends compiling shader files in the fxc.exe tool which is available as part of the Windows SDK.

The fxc.exe program can also be downloaded directly from the FlatRedBall repository: [https://github.com/vchelaru/FlatRedBall/tree/NetStandard/FRBDK/PrebuiltTools/fxc](https://github.com/vchelaru/FlatRedBall/tree/NetStandard/FRBDK/PrebuiltTools/fxc)

fxc.exe can be used to build effect files which can be consumed by FNA (and FlatRedBall FNA) using syntax similar to the following command:

```
"fxc.exe" /T fx_2_0 ShaderFile.fx /Fo ShaderFile.fxb
```

In the command above, `ShaderFile.fx` is the input file and `ShaderFile.fxb` is the output file. FlatRedBall recommends using the extension fxb as the output file.

Once an .fxb file is built, it can be added to FlatRedBall just like any other file (by drag+dropping it into the FlatRedBall Editor) and it will be loaded into a standard Effect object.
