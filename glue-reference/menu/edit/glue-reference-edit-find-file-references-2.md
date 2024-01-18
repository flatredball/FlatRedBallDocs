# Find File References

### Introduction

The "Find File References..." item lets you search your entire project's content files for references to a particular file. For example, if you search for a specific .png file, Glue will return all files (.scnx, .emix, .achx, and so on) that reference this file. This feature can be helpful in debugging and replacing file references.

### Example

To find file references:

1. Click Edit->Find File References...\
   ![FindFileReferences.png](../../../media/migrated\_media-FindFileReferences.png)
2. Enter the file name you are searching for. You need to include the extension of the file, but not the path. For example, "MyImage.png" is valid, "MyImage" is not, and "Content/Entities/MyImage.png" is not valid.\
   ![EnterNameForFileSearch.png](../../../media/migrated\_media-EnterNameForFileSearch.png)
3. You will see a popup that shows you which files are referencing the file you entered.![FilesFoundFromSearch.png](../../../media/migrated\_media-FilesFoundFromSearch.png)
