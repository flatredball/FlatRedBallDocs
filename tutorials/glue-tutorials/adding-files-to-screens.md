# adding-files-to-screens

### Inroduction

Once you've created Screens and Entities, the next step is to define what goes in those Screens and Entities. This is often called "content". Before we get to how we add content, let's talk a little bit about what contentis and why it's so important.

### Understanding data

What exactly is "content"? Content refers to files which are often created by applications other than code-writing applications (like Visual Studio), and which are not "compiled". Although, lately with the introduction of content pipelines, this not-compiled condition is not always the case. Of course, in FlatRedBall most content can be either "compiled" or loaded from the raw file.

However, there are a few other characteristics that content has which are worth noting:

* Often content does not define structure or systems. This means that content often fills in "options" for objects which are defined in code. For example, Sprites are objects which are defined in code in FlatRedBall, but the Texture that they display is often created through an image file (like a .png). This .png is considered content.
* Content can be standardized, allowing for multiple editing tools. For example, there are many applications that can create .png files. This standardization also allows for standardized viewers. You can easily view what a .png looks like without loading it in FlatRedBall because Windows has a built-in image viewer.
* Content can be more abstract, or higher level. This means that content can be created by individuals who may not understand exactly how the content works in the game. For example, a game background .png can be created by an artist with a tablet - they don't need to understand how the .png is loaded at runtime or how it is used by the rendering system.
* Content can be safer than code. Code that loads content can put in checks to make sure that the content is valid before loading the game. An out-of-place semicolon can make an entire project not run, but it is (at least conceptually) possible to create a content system that can warn users when invalid content is detected, and even continue with defaults when invalid content is found.

While it is possible to completely define objects such as Sprites in code, this requires programming knowledge. It also results in projects which are difficult to visualize, difficult to maintain, and more susceptible to bugs. Therefore, Glue encourages the definition of objects using content. More specifically, this is done by providing convenient ways to add, edit, and reference new files.

### Adding a Scene to your Screen

We'll begin with perhaps the most common type of content - a Scene used as a background in a Screen. To add a Scene:

1. Expand your Screen in the tree view in Glue
2. Right-click on Files
3. Select Add File->New File![GlueAddNewFile.png](../../../media/migrated_media-GlueAddNewFile.png)
4. A new window will appear. Select "Scene (.scnx)" and enter the name "LevelBackground" as the new file name.![GlueEnterNewFileInfo.png](../../../media/migrated_media-GlueEnterNewFileInfo.png)
5. The new file will appear under your Screen's Files tree item![GlueNewFileInTreeView.png](../../../media/migrated_media-GlueNewFileInTreeView.png)

At this point you've created an empty file which will be automatically loaded by your Screen. You've also added the file to your project. In other words, simply doing this means your file is already part of the project. Now all you need to do is edit the file.

### Setting up File Associaton

Glue provides quick access to any file that is part of the project. To open a file, you can simply double-click it in the list on the right. If you have installed FlatRedBall from the installer available on our [downloads page](../../../frb/docs/index.php), then you probably have all of the FlatRedBall types associated to appropriate FlatRedBall tools through Windows file association. Therefore, you may not need to do anything in this step. However, there are a few reasons why you may still want to manually set your file associations:

1. There are multiple tools which can edit a given file type. For example, Scene files (.scnx) can be edited by the SpriteEditor, TileEditor, and ModelEditor. You may want to pick one over the other depending on the type of project you are working on, or the type of content you are creating. In some cases you may even want to switch back and forth between different applications in a given project.
2. You may be using a "developer version" of FlatRedBall instead of the publicly-available version. If this is the case, you probably want to associate your file formats with the tools found in your developer directory (either the T drive or your specific project's directory).
3. You may have created your own tools to work with FlatRedBall's file format. In this case you will want to select your custom tool's .exe.

If you feel you need to set up custom file associations, the following steps will show you how:

1. Click on Settings->File Associations![GlueFileAssociationsMenu.png](../../../media/migrated_media-GlueFileAssociationsMenu.png)
2. The File Associations window will appear![GlueFileAssociationsWindow.png](../../../media/migrated_media-GlueFileAssociationsWindow.png)
3. At first all files will be associated with "\<DEFAULT>". This means that files will open with whatever application is associated with this file format through Windows. If you have set up the associations already between the files used by the FRBDK, then you can leave these values to \<DEFAULT>.
4. To set Glue-specific associations between files and applications, click the drop-down next to one of the file types and select "New Application..."![GlueNewAssociationApplication.png](../../../media/migrated_media-GlueNewAssociationApplication.png)
5. As you add applications, Glue remembers them, and they will always be listed in the combo box for easy switching.
6. Navigate to the location where the given tool you want to use is located. If you want to manually set the association to the location where the FRBDK was installed, this is likely in \<Program Files>\FlatRedBall\FRBDK\\. You will want to pick the SpriteEditor.exe for the .scnx assocation.![GlueAssociateScnx.png](../../../media/migrated_media-GlueAssociateScnx.png)

### Editing Files

Once you have set up the association between file types and FRBDK applications, you can open the editors for these files through Glue. To do this, simply double-click the file. In this case, double-click your .scnx file under your Screen's Files to open the SpriteEditor.

![SpriteEditorShot.png](../../../media/migrated_media-SpriteEditorShot.png)

Since this tutorial covers Glue, we won't go into the details of how to work with any of the other FRBDK tools. However, if you would like to learn more, check [this page](../../../frb/docs/index.php), and specifically for the SpriteEditor you can check [this page](../../../frb/docs/index.php).

To create our level, let's add some Sprites to the scene.

![SimpleScene.png](../../../media/migrated_media-SimpleScene.png)

Finally, you need to save your scene. To save your scene in the SpriteEditor:

1. Click File->Save Scene.
2. The file name should already be entered in the file window, so simply click OK.
3. \*\*VERY IMPORTANT:\*\*When you save your .scnx file, the SpriteEditor checks to see if any referenced files (such as image files and .achx files) are referenced relative to the .scnx you are saving. If not, you will see a window that tells you which files are not relative, then asks you want you want to do. **In most cases you will want to make sure all files are copied locally.**![MakeTexturesRelative2.png](../../../media/migrated_media-MakeTexturesRelative2.png)

Once you save your Scene (.scnx file), you can close the SpriteEditor.

### Referenced Files

If you've worked with FlatRedBall in the past and have added files like .achx or .scnx files to your project, you may have been annoyed with the task of having to add every referenced file to your project. Fortunately, Glue takes care of this for you automatically. Every file that is referenced by your .scnx will automatically be added to your project for you. That means you can simply edit the .scnx file and Glue will take care of the rest.

### Seeing it in action

Now that we have a Screen that references a Scene, and now that we've added some Sprites to our Scene, we can test our project out. To do this:

1. Select Project->"View in Visual Studio"![GlueViewInVisualStudioMenu.png](../../../media/migrated_media-GlueViewInVisualStudioMenu.png)
2. Visual Studio will open with your project.
3. Select Debug->"Start Debugging"![VSStartDebugging.png](../../../media/migrated_media-VSStartDebugging.png)
4. Your project should load up and your Screen will become active - resulting your Scene being loaded![GlueTutorialRunning.png](../../../media/migrated_media-GlueTutorialRunning.png)

### Custom Tools for Scenes

By default Glue will open the .scnx file in the SpriteEditor. FlatRedBall offers other tools to edit .scnx files (such as the TileEditor). The .scnx file format is also an XML file format which means anyone can easily create their own custom .scnx editors.

For information on how to use the TileEditor, check [this tutorial](../../../frb/docs/index.php).

### Wrapping it up

Congratulations, you have just loaded content in your new project and displayed it on screen. While this may not seem like a big accomplishment, there is a LOT of stuff going on behind the scenes in your new project. At this point you can easily modify the .scnx through the SpriteEditor (or any other application that supports .scnx editing) and these changes will appear in game.

Now that we have a background, let's get to adding Entities.

[To the next tutorial ->](../../../frb/docs/index.php)
