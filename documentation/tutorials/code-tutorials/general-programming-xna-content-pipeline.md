## Introduction

A content pipeline is (in the case of XNA) code which converts a raw asset such as a .png image file or .fbx model file to a runtime-loadable file. Content pipelines can be used to eliminate unnecessary information from the raw asset, introduce game-specific information, and potentially speed up load times.

## Compile-Time Vs. Runtime

There are two parts to a content pipeline. One is the compile-time code which converts the raw asset to a loadable (or processed) asset. The second part is the code which loads the processed asset and converts it to a runtime type. The compile-time code is executed when compiling the application - once for every asset of the particular type being loaded. The runtime code is executed for every object that is loaded.

## Compile-Time Components

The following image shows an outline of steps that a raw file takes to become a processed file (.xnb in XNA). ![ContentPipelineCompileTime.png](/media/migrated_media-ContentPipelineCompileTime.png) The following sections explain each step in the compile-time pipeline.

### Saved Raw Asset

The saved raw asset is usually a file that is created in a 3rd party application (such as Maya creating a .FBX or Photoshop creating a .PNG) or a game tool (such as the SpriteEditor creating a .SCNX). This file will be converted to a .XNB file through the compile-time content pipeline code.

### Content Importer

Class which inherits from Microsoft.Xna.Framework.Content.Pipeline.ContentImporter\<T\> responsible for loading the raw asset file and creating the intermediary class. If following the [FlatRedBall file type pattern](/frb/docs/index.php?title=FlatRedBall_File_Types.md "FlatRedBall File Types"), this intermediary class would be a "Save" class. The content importer's Import method takes a file name and returns an instance of the intermediary class.

### Intermediary Class

This is a class which represents an intermediary state - between the raw asset and the raw and processed file. Depending on the raw asset being stored, the intermediary class may have the following characteristics:

-   If loaded from a tool which XML Serializes its files, then this could be the class that was used to serialize out the XML file.
-   This may be a "Save" object if following the [FlatRedBall file type pattern](/frb/docs/index.php?title=FlatRedBall_File_Types.md "FlatRedBall File Types"). This means that the class has methods for serializing to XML, deserializing from XML, converting to a runtime object, and being created from a runtime object.

This class may also include ExternalReferences to other files. For example, a file defining the layout of a level may include references to the image files to use for textures.

### Content Processor

The processor is a class which takes an instance of the intermediary class and performs any processing. The most common type of processing is to create ExternalReferences to other files used by the current object. Other types of processing may include setting additional properties based off of processor parameters.

### Content Writer

The content writer is an object which takes an instance of the intermediary class after it has been run through the content processor and writes the data out to a .xnb file. The Write method is responsible for writing the .XNB file. The method is defined as follows:

    protected override void Write(ContentWriter output, IntermediaryClass value)

The contentWriter is a BinaryWriter which can write to the contents of a .XNB file. The most common methods used to write are Write and WriteExternalReference.

### .XNB (processed) File

This is a (usually) binary file which results from the compile-time content pipeline. .XNB files are placed relative to the executable (usually \<project\>/bin/x86/debug) and are usually in the Content folder or a sub-folder of Content. .XNB files can be thought of as "compiled content" just as .EXE or .DLL files are compiled code. Therefore, when published a game may only need .EXE, .DLL, and .XNB files to run.

## Runtime Components

The runtime portion of the content pipeline is responsible for loading a .XNB file and converting it to an instance of a runtime class. Examples of runtime classes include the Texture2D and Scene classes. The following image shows an outline of steps that a XNB file takes to become an instance of a runtime class. ![ContentPipelineRuntime.png](/media/migrated_media-ContentPipelineRuntime.png) The following sections explain each step in the runtime pipeline.

### .XNB (processed) File

The .XNB is loaded by name (without the .XNB extension) during runtime. If using FlatRedBall, the [FlatRedBallService's Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices#FlatRedBallServices.Load.md "FlatRedBall.FlatRedBallServices") method is used to initiate a load and create a runtime class instance. For example, assuming there was a file MyScene.scnx in the Content/Scenes folder which was compiled into a .XNB, the following code would create the Scene at runtime:

    Scene myScene = FlatRedBallServices.Load<Scene>(@"Content/Scenes/MyScene", "ContentManagerName");

### Content Reader

The content reader is responsible for reading the .XNB file and creating an instance. The ContentReader's Read method reads the XNB and returns the new instance. It is defined as follows:

    protected override FlatRedBall.Scene Read(ContentReader input, RuntimeClass instance)

The ContentReader reads in the contents of the XNB, usually one property or field at a time. The reader should read the contents in the same order that they have been written, and any property that is written by the ContentWriter should be read by the ContentReader. Not reading properties can result in the reader being offset from expected data causing a runtime crash.

### Runtime Class Instance

The runtime class is the class that is used in the game. Examples include XNA's Model or Texture2D classes and FlatRedBall's Scene or AnimationChainList classes.

## Additional Reading

The following article discusses the XNA Content Pipeline in more detail: [XNA Content Pipeline on Ziggyware](http://www.ziggyware.com/readarticle.php?article_id=69)
