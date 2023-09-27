## Introduction

FlatRedBall offers a variety of file types for storing content information. While these file types are useful in a variety of situations, it is sometimes necessary to create new file types for custom data, or to combine information into a single file. In either case a custom file format is necessary. If your file links other files which need to be loaded through the content pipeline, then you may want to make content pipeline files for your format as well.

## Solutions Provided by This Tutorial

For those of you who are familiar with writing your own content saving/loading code, you may be wondering what benefits are to be gained by following the patterns proposed in the following set of tutorials. The following lists some of these benefits:

-   Eliminates Maintenance - XML serialization and FlatRedBall's ObjectReader and ObjectWriter classes all work through reflection. Therefore, modifying the "Save" class (explained in the first tutorial) results in a change to the format without any work on your end. In other words, there are no loose dependencies between your code and the data.
-   Automatic Versioning - Using XML as your file format is a great idea because it versions very well. That is, if a new field or property is added, old files will still load just fine. There's no reason to worry about versioning and the binary files created by the content pipeline because those are files which are overwritten - the XML file is all that matters as far as supporting old formats.
-   Easy debugging - Following this pattern enables the FlatRedBall team to help you debug your code much easier. This is a pattern which we've used for a long time and we understand it well.
-   Simplifies new content pipeline writing - Our ObjectReader and ObjectWriter class work with most Save classes. Therefore, once you've written your actual Save class, the rest is almost all written for you. The ObjectReaders and Writers even handle ExternalReferences!

## Subsections

The following sections provide information on how to create a custom file format and a content pipeline.

1.  [Setting up your projects](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Setting_up_your_projects.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Setting up your projects")
2.  [Creating a Runtime Class](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_Runtime_Class.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a Runtime Class")
3.  [Creating a "Save" class](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_%22Save%22_class.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a "Save" class")
4.  [Creating a "SaveContent" Class](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_%22SaveContent%22_Class.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a "SaveContent" Class")
5.  [Creating an Importer](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_an_Importer.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating an Importer")
6.  [Creating a Processor](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_Processor.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a Processor")
7.  [Creating a Writer](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_Writer.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a Writer")
8.  [Creating a Reader](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Creating_a_Reader.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Creating a Reader")
9.  [Using the Level Classes](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline:Using_the_Level_Classes.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline:Using the Level Classes")
