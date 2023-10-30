# getallfilesindirectory

### Introduction

GetAllFilesInDirectory is a method which can be used to get all files in a given directory and its sub-directories. The overloads for this method provide constraints such as the number of levels deep to search, and limitations on the file types.

### Overloads

```
public static List<string> GetAllFilesInDirectory(string directory)
public static List<string> GetAllFilesInDirectory(string directory, string fileType)
public static List<string> GetAllFilesInDirectory(string directory, string fileType, int depthToSearch)
public static void GetAllFilesInDirectory(string directory, string fileType, int depthToSearch, List<string> arrayToReturn)
```

The following call:

```
List<string> result = GetAllFilesInDirectory(directoryName);
```

is equivalent to calling:

```
List<string> result = GetAllFilesInDirectory(directoryName, "", int.MaxValue)
```

An empty string as the fileType will return all contained files.

### Code Example

The following code creates a [ListBox](../../../../../frb/docs/index.php) to display all .jpg files which exist in the c:\Projects directory. If you do not have this directory on your computer, you will need to change the directory variable. Keep in mind that if the depth variable is large, or if the argument directory has a lot of files and sub-directories, this call can take a long time to execute. Add the following using statements:

```
using FlatRedBall.IO;
using FlatRedBall.Gui;
```

Add the following to Initialize after initializing FlatRedBall:

```
GuiManager.IsUIEnabled = true;
IsMouseVisible = true;

ListBox listBox = GuiManager.AddListBox();
listBox.ScaleX = 33;
listBox.ScaleY = 25;

string directory = @"c:\Projects";
string fileType = "jpg"; // could be empty for all files
int depth = 3; // the number of folders deep to search

List<string> allFiles = FileManager.GetAllFilesInDirectory(
    directory, fileType, depth);

foreach (string s in allFiles)
{
    listBox.AddItem(s);
}
```

![GetAllFilesInDirectory.png](../../../../../media/migrated_media-GetAllFilesInDirectory.png)
