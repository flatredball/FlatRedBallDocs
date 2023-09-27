-   -   Work In Progress\*\*

Creating a custom content pipeline for your title can make the process of content creation much easier.

## What is the Content Pipeline?

In a nutshell, the content pipeline takes game assets, and compiles them into a game ready format. The kicker is that the content creator does not have to do any work to get it into the game (save for adding the file to XNA Game Studio).

![Content pipeline.jpg](/media/migrated_media-Content_pipeline.jpg)

The flow of content goes like this:

1.  The content file is added to XNA Game Studio Express
2.  An importer and processor are selected. There are usually defaults, but you can change them if other importers and processors are available for that content type.
3.  When you compile your project, all content files are run through their assigned importers and processors.
4.  The Importer takes care of loading the file's data and getting it ready to process.
5.  The Processor manipulates the imported data (if needed)
6.  The Writer takes care of serializing the data into a custom XNA format (.xnb)
7.  At runtime, the game requests the asset using a ContentManager, which in turn uses that type's Reader to load the run-time type.

XNA Game Studio allows you to specify any number of custom content pipeline processors in the game project's property pages: ![Content pipeline properties.png](/media/migrated_media-Content_pipeline_properties.png)

## Project Structure

So what are all the pieces involved in making this come together you may ask?

1.  First, you start by structuring your project to have three projects: -MyGame.exe -MyGame.Library.dll -MyGame.Content.dll
2.  Second, you set a reference to *MyGame.Library.dll* from both the game's executable, and the content assembly. This is because the the library assembly holds both the runtime type of your content, and the reader to deserialize the data from XNA's custom file format.

## Content Assembly

### Intermediate Type

like xna's dom

### Importer

### Processor

### Writer

Joel Martinez [http://codecube.net](http://codecube.net)
