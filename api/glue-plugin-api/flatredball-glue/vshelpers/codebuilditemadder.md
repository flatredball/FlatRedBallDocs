# codebuilditemadder

### Introduction

The CodeBuildItemAdder provides methods for adding entire .cs files into game projects. Entire files may be needed in projects for a number of reasons:

* As a cross-platform way to embed classes which are needed by a plugin, such as a runtime type for a file
* To create singletons which are used to simplify code generation in each screen or entity
* To provide utility methods to be used in custom code

### Example Usage

The steps for adding code to a project using the CodeBuildItemAdder are:

1.  Add a .cs file to your project as an embedded resource:

    ![](../../../../.gitbook/assets/2016-04-img\_571b83de50fd8.png)
2.  (Optional) Set the namespace to use the $PROJECT\_NAMESPACE$ keyword to indicate that it should match the game project's namespace:

    ```lang:c#
    namespace $PROJECT_NAMESPACE$.OcularPlaneRuntime
    {
    ```
3.  Add the code to embed the class. Embedded resources use the '.' character to separate folders, so if your file in the project is located at MyPlugin/EmbeddedCodeFiles/CodeFile.cs, then your code to add the file would be as shown in the following snippet:

    ```lang:c#
    var adder = new CodeBuildItemAdder();
    adder.OutputFolderInProject = "PluginFiles";
    adder.AddFileBehavior = AddFileBehavior.IfOutOfDate;
    adder.Add("MyPlugin.EmbeddedCodeFiles.CodeFile.cs");
    ```
