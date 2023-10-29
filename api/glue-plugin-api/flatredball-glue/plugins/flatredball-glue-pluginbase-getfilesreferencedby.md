## Introduction

The GetFilesReferencedBy delegate is a delegate which can be used to provide custom file reference logic. Custom file reference logic is useful if you are working with files which are not natively supported by Glue. Glue natively supports a number of files like .scnx, .achx, and .emix. If you are working with a file format which references other files, you can create a plugin which handles the GetFilesReferencedBy delegate.

## Delegate Type

The delegate is defined as:

    Action<string, EditorObjects.Parsing.TopLevelOrRecursive, List<string>>

Lets look at the three parameters:

-   string (first parameter) - this is the absolute file name which the plugin should handle. Usually plugins handle only a specific file format, so you may need to first look at the extension of the first argument to see if you should even handle it.
-   EditorObjects.Parsing.TopLevelOrRecursive - Whether the search should be top-level or recursive. If your file format references files which may reference other files, and if a recursive check is called for, you should perform deep reference gathering.
-   List\<string\> - The list to fill. If your plugin does not handle the file which has been passed in, then you do not need to make any changes to this list. You should not clear the list as multiple plugins may handle a single file.
