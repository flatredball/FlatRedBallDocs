## Introduction

The MakeAbsolute method takes a relative file name and makes it absolute. If the file is a content file, then the relative path is considered relative to the content project. If the file is a code file, then the relative path is considered relative to the code project.

## Code Example

The following will obtain the absolute folder for the currently-selected element (Screen or Entity):

    var currentElement = GlueState.Self.CurrentElement;

    if(currentElement != null)
    {
        var elementNode = GlueState.Self.Find.ScreenTreeNode(screen);

        var folderNode = elementNode.FilesTreeNode;

        string relativePath = folderNode.GetRelativePath();

        bool isContent = true;

        string absolutePath = GlueCommands.Self.ProjectCommands.MakeAbsolute(
            relativePath, isContent);

        // do something with absolutePath here:
    }
