# New Project

### Introduction

The **New Project** menu item is used to show the new project window. **File->New Project** does the same thing as clicking the **Create New Project** quick action.

<figure><img src="../../../.gitbook/assets/image (2) (1).png" alt=""><figcaption><p>The New Project menu item is the same as the Create new Project quick action</p></figcaption></figure>

Clicking either option shows the New Project window.

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1).png" alt=""><figcaption><p>New Project Window</p></figcaption></figure>

### Project Name

Project Name sets the name of your project. This value sets:

* Your .sln and .csproj file names
* Your default namespace
* The name of the built .exe file

This should not have spaces, or any characters which would be invalid in a C# namespace.

### Platform

The Platform dropdown determines which platform your project targets. Typically this should be one of the Desktop projects (either MonoGame or FNA). Additional platforms (such as mobile) can be added as synced projects. You can select one of the mobile or web projects if you are testing these platforms, or if you do not intend to ever target desktop.

When the project is created, the Platform that you select determines the template that FlatRedBall downloads. Note that when you create a new project, the latest template (from the most recent monthly build) is downloaded.

#### Select Local Project...

If you would like to create a project from a local folder, you can select the **Select Local Project...** option.

<figure><img src="../../../.gitbook/assets/image (2) (1) (1).png" alt=""><figcaption><p>Select Local Project dropdown option</p></figcaption></figure>

This option is usually for advanced scenarios and contributors of FlatRedBall. You may want to select this option in the following situations:

1. If you are adding a new platform to FlatRedBall and are testing this new platform in the FlatRedBall Editor.
2. If you are making a modification to one of the existing templates which has not yet been built to a monthly release (such as upgrading to a new version of .NET)
3. If you have created a custom template for new projects which includes code or libraries common for your particular workflow

If this option is selected, an open file dialog appears allowing you to select a folder which contains the root (.sln) of the desired starting template. Note that you can use this option to select any folder in the Templates folder if you have cloned FlatRedBall. As mentioned above, this is useful if you are making changes to template files and would like to test those in FlatRedBall.

<figure><img src="../../../.gitbook/assets/image (4) (1).png" alt=""><figcaption><p>Open file dialog selecting the FlatRedBallDesktopFnaTemplate folder</p></figcaption></figure>

The folder that you have selected appers in the Platform dropdown.

<figure><img src="../../../.gitbook/assets/image (355).png" alt=""><figcaption><p>Custom template location in the New Project window</p></figcaption></figure>

### Use local copy if available

This option contols whether to attempt to use a previously-downloaded .zip for the selected project rather than to download a new version. This option is useful if:

1. Your computer is offline so a download would fail
2. You are testing the creation of many projects and would like to speed up the process. This option skips the downloading of new projects which can be time consuming.
