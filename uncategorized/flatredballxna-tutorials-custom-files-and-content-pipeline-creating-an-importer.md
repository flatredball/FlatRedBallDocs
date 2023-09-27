## Introduction

In the [last article](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_%22SaveContent%22_Class "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a "SaveContent" Class") we created a class called LevelSaveContent which can load from a XML Level file and will be able to be used to write binary Level information. The logic to perform these tasks will be written in this and the following three tutorials.

This tutorial introduces the Importer class, which is responsible for loading and returning a LevelSaveContent instance.

## Creating an Importer

The Importer will be placed in the ContentPipelineProject. The following sections outline the steps for creating an Importer.

### Add LevelImporter

-   Right click on ContentPipelineProject in the Solution Explorer.
-   Select "Add"-\>"Class...".
-   Select the "XNA Game Studio 3.0" under Categories.
-   Highlight the "Content Importer" template.
-   Name the new class LevelImporter.
-   Click the "Add" button.

### Modify the LevelImporter

Now your ContentPipelineProject includes the LevelImproter.cs file. The modifications to customize it for loading a LevelSaveContent instance are fairly straightforward:

Change the TImport to LevelSaveContent:

    using TImport = ContentPipelineProject.LevelSaveContent;

Change the ContentImporter arguments:

    // We'll assume the extension for the level is .levx.
    [ContentImporter(".levx", DisplayName = "Level Importer", DefaultProcessor = "LevelProcessor")]

Change the contents of the Import method:

    public override TImport Import(string filename, ContentImporterContext context)
    {
        return LevelSaveContent.FromFile(filename);
    }

## Next Steps

At this point our content pipeline can import XML files (which use the extension .levx). The next step is to process the loaded LevelSaveContent instance. This specifically means creating the ExternalReferences.
