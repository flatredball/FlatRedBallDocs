# Atlas

### Introduction

The atlas file (with extension .atlas) is produced by Spine. The purpose of an atlas file is to define the coordinates in a PNG file used for different named regions. The atlas file defines both the .png that is used as well as its regions.&#x20;

By default, atlas files are loaded into the runtime type Spine.Atlas.

<figure><img src="../.gitbook/assets/image (3) (1) (1) (1) (1).png" alt=""><figcaption><p>.atlas file loaded as Spine.Atlas</p></figcaption></figure>

### AchxToSpineAtlas.exe

You can produce an .atlas file from a FlatRedBall .achx file by using the AchxToSpineAtlas.exe tool.

At the time of this writing you must build this tool yourself. To do this:

1. Clone the FlatRedBall Repository
2. Open `<FRB Root>\FRBDK\AchxToSpineAtlas\AchxToSpineAtlas.sln`
3. Build the tool which produces a .exe

Once you have built the tool you can use it either in the command line, or you can set up a File Build Tool association.

#### Command Line

To run the tool in the command line, run the .exe with two parameters:

1. The source (.achx) file
2. The destination (.atlas) file

For example, you can run the tool using the following command to build an .atlas file:

```
AchxToSpineAtlas.exe MyCharacter.achx MyCharacter.atlas
```

#### File Build Tools

To use the AchxToSpineAtlas.exe tool as a File Build Tool in FlatRedBall:

1. Open your project in FlatRedBall
2. Select the **Settings -> File Build Tools** menu item
3. Click **Add new build tool**
4. Click the ... button to select the BuildTool. Navigate to where AchxToSpineAtlas.exe is located
5. Set the SourceFileType as `achx` (no period before the extension)
6. Set the DestinationFileType as `atlas`

<figure><img src="../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Setting .achx to .atlas build tools</p></figcaption></figure>

After you click the OK button, FlatRedBall understands that .achx files may be used to build .atlas files.

Note that this change now results in FlatRedBall asking you about the build tool whenever you add a new .achx file.

<figure><img src="../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Dialog asking which builder to use for newly-added .achx files</p></figcaption></figure>

If you are adding a file which you would like to be treated as an AnimationChain, then select the **\<None>** option. For more information on build tools, see the [File Build Tools](atlas.md#file-build-tools) documentation.
