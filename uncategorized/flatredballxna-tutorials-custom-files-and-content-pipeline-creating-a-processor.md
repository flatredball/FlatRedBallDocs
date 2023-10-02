# flatredballxna-tutorials-custom-files-and-content-pipeline-creating-a-processor

### Introduction

The Processor is the second of four content pipeline classes. The Processor is responsible for creating the ExternalReferences. Processors can also perform other tasks and even take arguments from the user, but this tutorial will not this advanced behavior.

### Creating a Processor

The following sections outline the steps for creating a Processor which we'll call LevelProcessor.

#### Add LevelProcessor

* Right click on ContentPipelineProject in the Solution Explorer.
* Select "Add"->"Class...".
* Select the "XNA Game Studio 3.0" under Categories.
* Highlight the "Content Processor" template.
* Name the new class LevelProcessor.
* Click the "Add" button.

#### Modify the LevelProcessor

Add the following using statements:

```
using FlatRedBall;
using FlatRedBall.Content;
using FlatRedBall.Content.Math.Geometry;
```

Change both the TInput and TOutput to LevelSaveContent:

```
using TInput = ContentPipelineProject.LevelSaveContent;
using TOutput = ContentPipelineProject.LevelSaveContent;
```

Change the ContentProcessor attribute:

```
[ContentProcessor(DisplayName = "Level Processor")]
```

Modify the Process method so it processes the argument LevelSaveContent:

```
public override TOutput Process(TInput input, ContentProcessorContext context)
{
    string fileName = input.SceneFileName;

    // In some cases the processor for a given type provides a shortcut method
    // for creating an external reference...
    input.Scene = SceneFileProcessor.CreateAndBuildExternalReference(fileName, context);
        
    // ...in other cases the ContentProcessorContext must be used
    input.ShapeCollection = 
        new ExternalReference<FlatRedBall.Content.Math.Geometry.ShapeCollectionSave>(
            input.ShapeCollectionFileName);

    input.ShapeCollection = context.BuildAsset<ShapeCollectionSave, ShapeCollectionSave>(
        input.ShapeCollection, typeof(ShapeCollectionProcessor).Name);

    return input;
}
```

### Using Processors

Notice that the Process method processes each of the two fields in LevelSaveContent differently. The Scene property is simply set to the return value of the [SceneFileProcessor's](../frb/docs/index.php) static CreateAndBuildExternalReference method. The ShapeCollection property, on the other hand, is processed created and built directly in the function.

This code is written this way to exemplify how content is built. The creation of the ShapeCollection property shows how to build content. All that is needed to build the content is the name of the processor (in this case the [ShapeCollectionProcessor](../frb/docs/index.php)). Using the ContentProcessorContext's BuildAsset method, any external reference can be built as long as the external reference has an associated ContentProcessor.

In some cases, however, the ContentProcessor provides a one-liner which will take care of instantiating and building the content, as is the case with the [SceneFileProcessor](../frb/docs/index.php). Not all processors have such a method, so understanding how to build the content using the ContentProcessorContext is a good idea. Of course, as FlatRedBall continues to improve, it is likely that more processors will provide shortcut methods like the SceneFileProcessor. If in doubt, ask on the forums!

### Next Steps

Now that our content can be imported and processed, the last step is to write out the processed content.
