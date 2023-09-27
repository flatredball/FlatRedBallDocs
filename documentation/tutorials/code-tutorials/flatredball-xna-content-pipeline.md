## Introduction

Larger game projects generally do not load raw assets such as .png or .x files in their final version. Instead of loading from-file, many final projects load content through a "content pipeline". To simplify the process of creating a content pipeline, Microsoft has included content pipeline support for XNA. While the necessity of a content pipeline can be the topic of debate, Microsoft has not provided from-file loading of some content, so depending on the game you're making using the content pipeline might be a necessity. The purpose of a content pipeline is to convert raw assets to a file format which is understandable by the runtime game libraries. This can reduce disk usage and speed up load times. It can also protect your assets from users directly opening them up and copying or modifying them.

## Extensions

When loading from-file, you will include the extension of the file you're loading. When loading through the content pipeline, you do not include the extension. For example:

    // The Sprite's texture is created from-file:
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    // The Sprite's texture is created through the content pipeline:
    Sprite sprite = SpriteManager.AddSprite("redball");

This goes for any file type, so keep this in mind. That is, if loading a model through the content pipeline, remove the ".x" or ".fbx". If loading a Scene, remove the ".scnx".

## Subsections

-   [Using the FlatRedBall XNA Content Pipeline](/frb/docs/index.php?title=FlatRedBall_XNA_Content_Pipeline:Using_the_FlatRedBall_XNA_Content_Pipeline.md "FlatRedBall XNA Content Pipeline:Using the FlatRedBall XNA Content Pipeline")
-   [External References in the Content Pipeline](/frb/docs/index.php?title=FlatRedBall_XNA_Content_Pipeline:External_References_in_the_Content_Pipeline.md "FlatRedBall XNA Content Pipeline:External References in the Content Pipeline")

## Additional Links

-   [Adding files to your project](/frb/docs/index.php?title=Tutorials:Adding_files_to_your_project.md "Tutorials:Adding files to your project") - A discussion of from-file loading, content pipeline loading, and "Content" loading.
-   [Managing Files](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Managing_Files.md "FlatRedBallXna:Tutorials:Managing Files") - Read this for more information on how to manage files in FlatRedBall.
-   [Custom files and the content pipeline](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Files_and_Content_Pipeline.md "FlatRedBallXna:Tutorials:Custom Files and Content Pipeline")
-   [XNA Content Pipelines](/frb/docs/index.php?title=General_Programming:XNA:Content_Pipeline.md "General Programming:XNA:Content Pipeline")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
