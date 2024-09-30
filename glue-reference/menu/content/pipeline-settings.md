# pipeline-settings

### Introduction

The Content Pipeline Settings menu item opens the Content Pipeline tab in Glue. This tab controls settings for content pipeline behavior in Glue.

![](../../../.gitbook/assets/2017-10-img\_59dd8fb600f11.png)

This plugin is still in the early stages. Additional options may be added in the future to control how content is built.

### Load all PNGs using Content Pipeline

This checkbox controls whether all PNGs in the project will be loaded using the content pipeline. By default this value is false. Checking this value will perform the following actions:

* Glue will build all PNGs into .XNB files in a special folder depending on the project type. Each project will have a separate folder with XNBs
* Glue will change all PNG references for all projects to point to the built XNB files
* Glue will generate aliases for all PNGs so that no code changes are required when referencing the PNGs

### Benefits and Costs of using Content Pipeline

Using the content pipeline for PNG files has some benefits, but these benefits also have some downsides. Fortunately, your project can switch switch between using the content pipeline and loading PNG's directly at any point simply by checking or unchecking the **Load all PNGs using Content Pipeline** checkbox.

#### Benefits of Using the Content Pipeline

The biggest benefit of using the Content Pipeline is that image files loaded from XNB will load faster compared to using PNGs. Note that the slower-loading of PNGs is a FlatRedBall-specific cost. Readers who are using MonoGame without using FlatRedBall may not see speed improvements when moving to XNB loading. The reason for the improved load time is because FlatRedBall performs extra processing when loading PNG files so Texture2Ds include _premultiplied_ _alpha_. If a Texture2D is loaded from a content pipeline XNB, no additional processing is necessary. This additional processing can result in a significant load time increase - in some cases more than doubling the amount of time a screen takes to load. Content Pipeline XNBs may also use hardware compression (depending on the platform), which results in Texture2D instances using less video memory, and rendering more quickly due to improved caching.

#### Costs of Using the Content Pipeline

When using the Content Pipeline, PNG files must be converted to XNB files. This conversion is performed whenever a PNG is changed (either when saved locally or when downloaded through version control). Large projects with multiple platforms may take some time (such as over 1 minute) to process all XNB files. Some platforms do not compress image XNBs, which means a corresponding XNB may take more space on disk than the original PNG. Fortunately, this is not as important on some platforsm such as Android because the .apk file itself is zipped.

### Content Pipeline and File Names

Typically FlatRedBall loads files using extensions, such as: var texture = FlatRedBallServices.Load\<Texture2D>("myImage.png"); However, in XNA/MonoGame, files loaded through the content pipeline do not use an extension. For example, to load a texture from a .XNB file (a processed content file), the extension would be omitted, as shown in the following code: var texture = FlatRedBallServices.Load\<Texture2D>("myImage"); The content pipeline settings in Glue are intended to be swapped without requiring any changes to custom or generated code. Therefore, even when using the content pipeline, the code must be able to load a file with its extension, such as "myImage.png". To resolve this, Glue generates a method called SetFileAliases . This method will associate the file with its extension with the file without its extension. Internally when FlatRedBall is told to load a file, it will check if that file exists in the FileAliases list, and if so, it will use the alias. Therefore, any code written which may reference a file by extension does not need to change when switching to the content pipeline.
