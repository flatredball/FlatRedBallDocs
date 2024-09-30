# UserApplicationDataForThisApplication

### Introduction

The UserApplicationDataForThisApplication property gives you an absolute path that you can use in your application to save information for the given application. Examples of information you may want to save are:

* Settings for a tool (such as window size)
* Debug information
* Save data (such as the user's profile)

### Why is UserApplicationDataForThisApplication needed?

If your game/application uses an installer to install itself to Program Files or "Program Files (x86)" (on Windows 7) then you will not be able to save files in the same location as the .exe. This is a security feature of later versions of Windows.

The UserApplicationDataForThisApplication gives you a folder which can be saved to without security issues.

### Code Example

The following saves a file called "myFile.txt" which contains the text "Hello World" to the application data folder.

```
string stringToSave = "Hello World";
string locationToSave = FileManager.UserApplicationDataForThisApplication + "myFile.txt";
FileManager.SaveText(stringToSave, locationToSave);
```

![AppData.png](../../../../.gitbook/assets/migrated\_media-AppData.png)
