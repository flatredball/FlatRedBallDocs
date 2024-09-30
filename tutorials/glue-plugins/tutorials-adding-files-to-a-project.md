# Adding Code Files to a Game Project

### Introduction

This tutorial will cover how to add files to a project using FlatRedBall plugins. We will be adding .cs files to a project when the project is initially loaded.

### Creating a project

The first step is to create a Glue Plugin project. To do this:

1. Launch the NewProjectCreator through the start menu.
2. Select "Glue Plugin Template"
3. Enter the project name
4. Select the location
5. Click "Make my project!"

### Adding files to projects

Next we'll add files that we want added to our project. To do this:

1. Create one or more files that you would like to include through your plugin
2. Add these files into your plugin project
3. For each file in your project, right-click and select "Properties"
4. Change "Build Action" to "Embedded Resource"

![BuildActionEmbeddedResource.png](../../.gitbook/assets/migrated\_media-BuildActionEmbeddedResource.png)

### Editing the PluginBase-inheriting Class

Once you've added the files you want to include we'll write the code to include these files in projects that Glue is managing. First, add an instance of a CodeBuildItemAdder:

```csharp
// add the following using statements:
using FlatRedBall.Glue.VSHelpers;
using System.Reflection;

// Add the following at class scope:
CodeBuildItemAdder mItemAdder;
```

Next we'll write the code to add the "Embedded Resource" files to the project managed by Glue. Add the following code to your plugin class' StartUp method:

```csharp
mItemAdder = new CodeBuildItemAdder();
mItemAdder.Add("StateInterpolationPlugin.Back.cs");
mItemAdder.Add("StateInterpolationPlugin.Bounce.cs");
```

The code above is pulled from a project where the project name is StateInterpolationPlugin, and the files Back.cs and Bounce.cs were added directly in the project (as opposed to being added in a folder). If the files are added in a folder (such as MyFolder) then you will need to change the file names (such as "StateInterpolationPlugin.MyFolder.Back.cs"). After making the "Add" calls, we need to tell the CodeBuildItemAdder where to save the files in the project that it is going to modify. To do this, add the following call:

```csharp
mItemAdder.OutputFolderInProject = "DesiredOutputFolder";
```

This will result in the files being placed in a folder called "DesiredOutputFolder". Finally we'll need to tell Glue that these files should be added to the project. To do this:

```csharp
// Add the following code to your StartUp method:
this.ReactToLoadedGlux += HandleGluxLoad;

// Implement the HandleGluxLoad method as follows:
Assembly assembly = Assembly.GetExecutingAssembly();
mItemAdder.PerformAddAndSave(assembly);
```

### Troubleshooting

If your files do not show up, you can troubleshoot the process as follows:

1. Look at the output window of Glue - if your plugin has crashed then Glue will display a callstack
2. Put try/catch statements around relevant code, such as PerformAddAndSave, and see the exception message for more information on what might be happening
3. Select [Plugins->Manage Plugins](../../frb/docs/index.php) to see all plugins and investigate any failures which may have occurred.

### Conclusion

That's all there is to it. Now all of the code items marked as Embedded Resource and added to the CodeBuildItemAdder will be added to any project loaded with Glue when the plugin is installed.
