# Effect (.fx, .fxb)

Shader Effect Files (.fx) can be added to FlatRedBall projects. At runtime this produces an Effect object which can be used to perform custom rendering. FlatRedBall FNA projects require extra steps to use FX files as explained below.

### Effect Files in MonoGame

Effect files require the use of the MonoGame Content Pipeline. If you are using the FlatRedBall Editor, this is automatically handled for you. You can verify that this is the case by checking the UseContentPipeline property.

<figure><img src="../../.gitbook/assets/image (40).png" alt=""><figcaption><p>Effect file using content pipeline</p></figcaption></figure>

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
