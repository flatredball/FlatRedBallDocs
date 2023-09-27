## Introduction

The ContentReader is essentially a class that mirror's the ContentWriter. It reads from the XNB file (binary file) and uses the data to create a Save class. This Save class can then be used to create a runtime instance using the To\<RuntimeType\> method.

FlatRedBall provides an ObjectReader class which simplifies the reading of a XNB. It reduces the reading to one line, just like the ObjectWriter reduces the writing of the SaveContent instance to one line.

## Adding the ContentContentReader

The following sections outline the steps for creating a ContentReader which we'll call LevelReader.

### Add LevelReader

-   Right click on FromFileProject in the Solution Explorer.
-   Select "Add"-\>"Class...".
-   Select the "XNA Game Studio 3.0" under Categories.
-   Highlight the "Content Type Reader" template.
-   Name the new class LevelReader.
-   Click the "Add" button.

### Modify the LevelReader

The Reader class is a very simple class to create using the ObjectReader. Make the following modifications to your LevelReader class:

Add the following using statement:

    using FlatRedBall.Content;

Change the TRead type:

    using TRead = FromFileProject.LevelSave;

Modify the Read method as follows:

    protected override TRead Read(ContentReader input, TRead existingInstance)
    {
        return ObjectReader.ReadObject<TRead>(input);
    }

## Content Pipeline Complete!

Once you've created this file, the content pipeline is complete. In fact, you've created a type that not only works with the content pipeline, but also supports from-file loading.

The next tutorial will show how to use the newly-created classes to create, load, and save Levels.
