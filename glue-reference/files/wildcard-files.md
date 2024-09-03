# Wildcard Files

### Introduction

FlatRedBall supports wildcard files in the .gluj file. Wildcard enable the automatic adding of files to your FlatRedBall project based in their location on disk. This can make managing a large number of files much easier than manually managing the files.

{% hint style="info" %}
&#x20;At the time of this writing wildcard files are only supported in Global Content, but future versions of FlatRedBall may expand this.
{% endhint %}

### Example: Using Wildcards to Add Texture PNG Files

The easiest way to add a Wildcard entry in the FlatRedBall is to first add a single file to your project which has all of the desired settings. Once this file has been added, it can be converted to a wildcard entry. For example, consider the following project which has a single file added to Global Content Files named **TextureFile.png**:

![TextureFile.png in Global Content Files](../../media/2022-12-img\_63a460bc8807b.png)

Currently, wildcard entries must be manually converted by editing the FlatRedBall project (.gluj) in a text editor. To do this:

1.  Open the folder location of the project

    ![Click the Folder Icon to open the project's folder](../../media/2022-12-img\_63a461f26d21f.png)
2.  Open your game's .gluj file in a text editor such as Visual Studio Code

    ![Right-click on the .gluj to see open options](../../media/2022-12-img\_63a4631990f89.png)
3.  Locate the file entry of the file in your project. It should appear under the GlobalFiles section.

    ![TextureFile.png in GlobalFiles in the project's .gluj](../../media/2022-12-img\_63a4635b0e205.png)
4.  Change the file's Name property to be a wildcard file.

    ![Name changed to be a wildcard](../../media/2022-12-img\_63a4638d16705.png)
5. Save the file in the text editor

After you save the file .gluj the FlatRedBall Editor displays the file with a wildcard (\*) icon to indicate that it is added as a wildcard file.

![File displayed as a wildcard file](../../media/2022-12-img\_63a463bfdc1d2.png)

Now you can add new files to disk and they automatically appear in the FlatRedBall Editor (assuming they match the wildcard pattern).

![Multiple files added using wildcards](../../media/2022-12-img\_63a46434e8daa.png)

### Wildcards and Valid Names

Be careful - wildcard files are added automatically even if their name violates the naming convention of FlatRedBall. In other words, normally files cannot contain spaces or dashes, but FlatRedBall adds these files to your project even if the file names contain invalid characters. For example, if you copy and paste a file, Windows automatically appends " - Copy" to the name of the file, and this appears in the FlatRedBall Editor.

![Files with invalid characters such as dashes and spaces are still added to the FlatRedBall project if their wildcard pattern matches](../../media/2022-12-img\_63a467ad19194.png)

The code generator attempts to remove invalid characters when generating the GlobalContent code.

![FlatRedBall removes invalid characters when generating properties for files added through wildcard patterns](../../media/2022-12-img\_63a467d9136ce.png)

Of course, since characters are either removed (such as spaces) or converted to valid C# property characters (such as underscores), it is possible to have multiple properties with the same name resulting in a compile error. We recommend keeping your file names named as valid C# properties.

### Valid Wildcard Patterns

FlatRedBall supports a number of wildcard patterns for adding files to your projects. The following examples explain the possible wildcard patterns:

* `Name": "GlobalContent/*.png` - Add all files in the GlobalContent folder with the PNG extension
* `Name": "GlobalContent/*.*` - Add all files in the GlobalContent folder with any extension
* `Name": "GlobalContent/*` - Add all files in the GlobalContent folder with any extension. Note that this is the same as `Name": "GlobalContent/*.*`.
* `Name": "GlobalContent/**/*.png` - Add all files in the GlobalContent folder and any subfolder of GlobalContent with the PNG extension
* `Name": "GlobalContent/**/*.*` - Add all files in the GlobalContent folder and any subfolder of GlobalContent with any extension

### Wildcards and Explicit Additions in Global Content

If a file is both included in Global Content Files explicitly and also through a wildcard, then the file appears twice in the FRB Editor and this produces an error. For example, consider a project with the file MyTexture.png added to the GlobalContent folder through a wildcard and also explicitly added. The JSON for the project might look like this:

```json
    {
      "Name": "GlobalContent/MyTexture.png",
      "IsSharedStatic": true,
      "DestroyOnUnload": false,
      "HasPublicProperty": true,
      "RuntimeType": "Microsoft.Xna.Framework.Graphics.Texture2D",
      "ProjectsToExcludeFrom": []
    },
    {
      "Name": "GlobalContent/*.png",
      "IsSharedStatic": true,
      "DestroyOnUnload": false,
      "HasPublicProperty": true,
      "RuntimeType": "Microsoft.Xna.Framework.Graphics.Texture2D",
      "ProjectsToExcludeFrom": []
    }
```

This results in the file appearing twice in the FRB Editor, and in an error appearing in the Errors tab.

![Duplicate files result in errors in the Errors tab](../../media/2023-09-img\_64f32d3a335a3.png)

If wildcards are needed, then the explicitly-added file must be removed. It can be removed by editing the .gluj, or by removing it through the tree view in FRB. If your project needs an explicitly-added file while also using wildcards, then you must organize your content in such a way as to exclude the explicitly-added file from the wildcard pattern, such as by adding all wildcard files to a subfolder.

### Wildcards and Explicit Additions in Screens and Entities

As mentioned above, adding the same file to Global Content Files using wildcards and explicit addition results in an error. However, adding the same file to Global Content Files using a wildcard pattern but also adding the file to a Screen or Entity explicitly is perfectly valid. This is allowed because wildcard additions behave the same as explicit additions, and FlatRedBall allows the same file to be added to both Global Content Files and a Screen or Entity.

For example, the following image shows the same file added to both an entity and Global Content Files.

<figure><img src="../../.gitbook/assets/image.png" alt=""><figcaption><p>TextureFile.png added to Entity1 and also Global Content Files using a wildcard pattern</p></figcaption></figure>

The example above adds all PNGs to Global Content Files using the following entry in the .gluj file:

```json
"GlobalFiles": [
    {
      "Name": "**/*.png",
      "IsSharedStatic": true,
      "IncludeDirectoryRelativeToContainer": true,
      "DestroyOnUnload": false,
      "HasPublicProperty": true,
      "RuntimeType": "Microsoft.Xna.Framework.Graphics.Texture2D",
      "ProjectsToExcludeFrom": []
    }
  ],
```

This approach for handling files is very useful if your game includes files which are spread out throughout the Content folder and its subfolders, yet you would like to have all files loaded up-front when the game first launches. For example, if additional files are added to an screen or entity, the files automatically appear in Global Content Files.

<figure><img src="../../.gitbook/assets/03_06 28 27.gif" alt=""><figcaption><p>Adding files to Entities automatically adds the files to Global Content Files if using a wildcard pattern that matches the new file</p></figcaption></figure>
