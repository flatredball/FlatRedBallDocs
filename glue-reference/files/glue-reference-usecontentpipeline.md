## Introduction

The UseContentPipeline property on files controls whether a file is loaded using the content pipeline. By default files do not use the content pipeline - they load "from file".

## What is the content pipeline?

Files which are added to Glue (such as .scnx and .png) are considered "raw" files. These are files which generally use a standard file format which can be edited in a variety of applications. For example, .png files can be opened in any image editing software. The .scnx file format is a simple XML file which can be opened in many of the FRBDK tools as well as in any text editor. Content pipeline files are "processed" when the program builds to create .xnb files. These files often are smaller and load faster in your game. There is also a small security benefit to using the .xnb file format. Therefore you may want to use the content pipeline on your files prior to shipping your game.

## Why should I not always use the content pipeline?

If .xnb files are smaller, faster, and safer you may wonder why Glue offers a from-file option...and why it defaults to from-file. The first reason is build time. By default files which are built as from-file do not have to built when the game is built - they are simply copied to the output directory. This process is **much faster** than using the content pipeline. Another reason is not all files support a content pipeline option. For example, Gum and Tiled plugins produce files which are loaded "raw" and currently do not support using the content pipeline. The recommended approach is to use from-file loading whenever possible throughout development, and switch to using the content pipeline near the end of development for file formats which support it.

## Switching to the content pipeline

To switch to the content pipeline:

1.  Select a file in your project
2.  Change the "UseContentPipeline" property to True ![UseContentPipeline.png](/media/migrated_media-UseContentPipeline.png)

Your game will now load this file from content pipeline.

**Note:** Not all file formats support using the content pipeline. Also, not all platforms support the content pipeline.

## Content pipelines and dependencies

Many files (like .scnx files) depend on other files (like .png files). When you switch between using the content pipeline or loading "from file", dependent files must also be modified in your Visual Studio project. Glue will handle this for you - you just have to set whether the file in Glue is part of the content pipeline or not and Glue will automatically manage your content project for you.
