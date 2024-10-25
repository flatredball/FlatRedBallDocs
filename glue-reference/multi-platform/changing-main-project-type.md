# Changing Main Project Type

### Introduction

Typically a new platform can be added to an existing FlatRedBall project by using synced projects. However, if you want to upgrade your main project you need to do so manually. This document provides high-level steps for upgrading.&#x20;

{% hint style="info" %}
Upgrading the main project is an advanced topic requiring understanding of FlatRedBall project structure. This document provides high-level steps for upgrading your project. Before beginning, you should create a backup of your project or push a working copy to version control (such as Git).

Also, if you do run into problems as you work through these steps, please ask for help on Discord. The maintainers will be happy to help you with your upgrade process while updating this document to be easier to follow.
{% endhint %}

### Before Updating

Before beginning the upgrade process, please follow these steps:

1. As mentioned above, create a backup of your project.
2. Upgrade your project to the latest .dlls (or NuGet packages). If you are using source, consider upgrading your project to the latest source.
3. Upgrade your .gluj (or .glux) to the latest version if possible. If not possible, note the version that you are on, as you may need to downgrade your newly-created project. For more information see the [File Version (.gluj)](../glujglux.md) page.
4. Verify that your project runs after performing this upgrade to avoid confusion about whether something is broken due to the new project type.

### Creating a New Project

The next step is to create a new project:

1. Open the FlatRedBall Editor and select to create a new project
2. Enter the new project name
3. Select the desired project type
4. Check the option for Custom Namespace and enter the namespace of your old project. This will make it much easier to copy existing code into your newly created project
5. if your old project is linked to source, select the option to link this new project to source
6. Uncheck the option to run the wizard to prevent adding unnecessary code and content files

If you did not upgrade your project to the latest gluj version, you should open your gluj file and downgrade it. After saving the file, close and re-open the FlatRedBall Editor to verify that it has generated content correctly. If your version is old enough, you may have duplicate classes, with some using .Generated.cs suffix and some with the .cs suffix. You should delete duplicate files if needed.&#x20;

### Copying Files

Once you have a new project running correctly, you can copy existing files. The following files should be copied from the old project to the new project

* Your old project's .gluj file (be sure to change the name to the new project name)
* Your old project's EntityPerformance.json file (if it exists)
* The entire Content folder except the Shader.fx and Shader.xnb files - these are platform specific and are part of the original template
* The entire contents of the Entities (code) folder
* The entire contents of the Screens (code) folder
* The entire Forms folder
* The entire GlueSettings folder
* The entire GumRuntimes folder
* Any custom code outside of the folders mentioned above
* Any additional files such as icons or cursors

### Modifying Code Files

You may need to modify the following code files:

1. Compare your two Game1.cs, and copy code to the new file as necessary
2. Modify your csproj to include any `<DefineConstants>` included in the old project. Exclude any constants that are not related to the new platform.
3. Make any changes needed to your code if necessary if you have changed .NET versions or platforms

