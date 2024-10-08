# File Build Tools

### Introduction

File Build Tools are runnable files (.exe or .bat) which take command line arguments and are used to convert files from one format into another format. Usually the conversion is made from a file format that is native to a particular 3rd party application (such as a .psd in Photoshop) to either a standard file format or a format understood by the FlatRedBall Game Engine (such as a .png or a .scnx).

### How to add a new File Build Tool

To add a new File Build Tool:

1.  Click the Settings->File Build Tools menu item

    ![](../../../.gitbook/assets/2017-01-img\_58902130439d7.png)
2.  Click "Add new build tool"\


    <figure><img src="../../../.gitbook/assets/migrated_media-AddNewBuildToolButton.PNG" alt=""><figcaption></figcaption></figure>
3.  Add the source and destination extensions of whatever your file build tool supports. For example, the source might be "psd" and the destination might be "png".

    <figure><img src="../../../.gitbook/assets/migrated_media-AddSourceAndDestinationTypes.PNG" alt=""><figcaption></figcaption></figure>
4.  Click the BuildTool text field, then click the browse button

    <figure><img src="../../../.gitbook/assets/migrated_media-BuildToolSelectionButton.png" alt=""><figcaption></figcaption></figure>
5. Select your build tool in the file window
6. Click OK

### File Build Tool Details

File build tools are command-line applications which can convert a file from one format to another. File build tools require at least one parameter - the source file (the file to be converted). To help understand how file build tools are used by Glue, consider a simple with the following values:

* BuildTool = "BuildTool.exe"
* IsBuildToolAbsolute = false
* SourceFileType = "source"
* DestinationFileType = "dest"
* IncludeDestination = true
* SourceFileArgumentPrefix = ""
* DestinationFileArgumentPrefix = ""
* ExternalArguments = ""

The values above specify that the build tool accepts a file with a "dest" extension, and it produces a file with a "source" extension. For this example, also consider a Glue file with the absolute path of "c:/folder/file.source". Building this file with the above variables would produce the following command:

```
BuildTool.exe "c:/folder/file.source" "c:/gameproject/content/file.dest"
```
