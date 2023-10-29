## Introduction

AddReferencedFileToGlobalContent adds the argument file to the Global Content Files tree node. The second parameter determines whether the folders relative to GlobalContent are prefixed on the name, which may be necessary if a project has multiple files with the same name in different folders.

## Code Example

    // Assuming the file is already on-disk in the GlobalContent folder
    // and that it is named redball.bmp:
    string fileName = "redball.bmp";

    GlueCommands.GluxCommands.AddReferencedFileToGlobalContent(fileName , false);
