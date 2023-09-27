## Introduction

The ContentWriter is the last step in the build-time content pipeline. The ContentWriter is responsible for taking the processed content object (usually a "SaveContent" object) and creating a XNB file. The XNB extension specifies that the contained data has been processed by the content pipeline and is to be loaded using a reader (the next step). The ContentPipeline will essentially perform a binary serialization on the SaveContent class, writing the result to disk.

Unfortunately, the data in the SaveContent class can't simply be run through a regular binary serializer - the ExternalReferences must be handled differently. That's why we had to put the ExternalInstance and InstanceMember attributes in the LevelSave and LevelSaveContent classes.

## ObjectWriter

Prior to the creation of the ObjectWriter class, writing and maintaining content pipelines was a very time consuming process. Whenever the Save data changed, the ContentWriter would need to be modified so the changes would appear in the generated XNB file. Similarly, the ContentReader - which hasn't been discussed yet - would need to be updated to read the changes effectively.

The ObjectWriter (and ObjectReader) eliminate the need for maintenance of a ContentReader and ContentWriter. They can be thought of as binary serializers which understand how to deal with ExternalReferences. Again, this understanding comes from the ExternalInstance and InstanceMember attributes.

## Adding the ContentWriter

The following sections outline the steps for creating a ContentWriter which we'll call LevelWriter.

### Add LevelWriter

-   Right click on ContentPipelineProject in the Solution Explorer.
-   Select "Add"-\>"Class...".
-   Select the "XNA Game Studio 3.0" under Categories.
-   Highlight the "Content Type Writer" template.
-   Name the new class LevelWriter.
-   Click the "Add" button.

### Modify the LevelWriter

As mentioned above, usage of the ObectWriter makes creation of the LevelWriter very simple.

Change the TWrite to the LevelSaveContent:

    using TWrite = ContentPipelineProject.LevelSaveContent;

Modify the Write method to use the ObjectWriter:

    protected override void Write(ContentWriter output, TWrite value)
    {
        FlatRedBall.Content.ObjectWriter.WriteObject<LevelSaveContent>(output, value);
    }

Modify the GetRuntimeReader method:

    public override string GetRuntimeReader(TargetPlatform targetPlatform)
    {
        return typeof(FromFileProject.LevelReader).AssemblyQualifiedName;
    }

You may get a compile error because the LevelReader is not defined (yet). Don't worry, we'll be defining this in the next tutorial.

## What's next?

At this point our compile-time content pipeline is complete. The final step in the content pipeline is to write a reader. The reader is the class that will read in the LevelSave at runtime and convert it to to the LevelSave class.
