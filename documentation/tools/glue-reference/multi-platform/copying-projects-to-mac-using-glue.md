## Introduction

This tutorial will walk you through the steps of creating a FlatRedBall iOS project on the PC then copying it to the Mac. Note that unlike most other FlatRedBall platforms, FlatRedBall iOS requires commercial software and a computer running OSX along with a computer running Windows.

Specifically, the requirements are:

-   A computer running Windows. This computer will have the typical FlatRedBall installation and will run Glue.
-   A computer running OSX. This computer must have Xamarin.iOS intalled. The steps outlined here will work with the trial version of Xamarin.iOS as well as the full version, but will not work with the Starter (free) version of Xamarin. At least an Indie License is required. For more information about Xamarin licenses see [this link](https://store.xamarin.com/).

## Same-network is preferred

Although this is isn't necessary, the easiest way to develop with Glue for FlatRedBall iOS is to set up your OSX computer so that your Windows computer can access its file system through the network. The Internet has many articles to get this set up. For example: [http://lifehacker.com/247541/how-to-access-a-macs-files-on-your-pc](http://lifehacker.com/247541/how-to-access-a-macs-files-on-your-pc). Be sure to save the credentials on your Windows machine as Glue will need to be able to access the OSX's file system.

Be sure that you can open a Windows Explorer window to view your Mac files on the PC before proceeding. If you cannot, attempt the following:

### Enabling Windows File Sharing

Make sure that Windows file sharing is enabled on your mac. To do this:

1.  Click the Apple icon in the top left of the screen and select "System Preferences"
2.  Select "Sharing" ![SharingWindow.jpg](/media/migrated_media-SharingWindow.jpg)
3.  Click "Options..."
4.  Make sure all check boxes are checked ![SharingOptionsWindow.jpg](/media/migrated_media-SharingOptionsWindow.jpg)
5.  Click Done

### Navigating to the Mac using its IP

1.  Open a Windows explorer window

2.  In the address bar type your Mac's IP as reported in the sharing window. For example, in this picture the IP is 192.168.0.15, so the address bar would have

        \\192.168.0.16

    ![SharingWindow.jpg](/media/migrated_media-SharingWindow.jpg)

3.  You may be asked to log in. Use the login name as specified in the Windows File Sharing screen (including spacing). For example, the username as specified in this window is

        Richard Blaylock

    (including the space) ![SharingOptionsWindow.jpg](/media/migrated_media-SharingOptionsWindow.jpg)

## Creating a FlatRedBall iOS project on Windows

Creating the project for iOS is identical to creating projects for other platforms:

-   Start Glue
-   Select File-\>New Project
-   Select FlatRedBall iOS as the project type
-   Enter the name that you want for your project
-   Click OK

At this point you will have a project which can be compiled and run on OSX. This tutorial shows how to copy iOS projects to Glue as the primary project, but the following tutorial also works if the iOS project is a synced project. For more information on project sync, see [this page](/frb/docs/index.php?title=Glue:Reference:Menu:File:New_Synced_Project "Glue:Reference:Menu:File:New Synced Project").

The next step is to set up Glue to copy the project over to your OSX computer.

## Glue Project Copier

Once you can access the file system on OSX, you can tell Glue to copy the project over to the desired location. To do this:

1.  Click the "Copy Project" tab at the bottom of the Glue screen![CopyProjectTabs.png](/media/migrated_media-CopyProjectTabs.png)
2.  Click the "..." button to select the folder where you'd like to copy the project. You may need to create a new directory. Note that if you navigated to the folder in an earlier step using the IP of the Mac, you can also paste the target directory in the text box rather than clicking the browse button.![ClickDotDotDotCopyProject.png](/media/migrated_media-ClickDotDotDotCopyProject.png)![NetworkBrowseFolder.PNG](/media/migrated_media-NetworkBrowseFolder.PNG)
3.  Once you have selected the folder, click "Copy Projects!". The project will be copied and the progress bar will update to show progress. ![ProjectCopying.png](/media/migrated_media-ProjectCopying.png)

If you have a large project, you may notice that the copy process can be lengthy. Don't worry, the project copier checks the dates on files when performing copying. This means that subsequent copies will go much faster!

## Running the project

At this point the project is fully copied to the OSX computer and it can be run there. This assumes that you have the proper Xamarin software installed.

To do this:

1.  Open Xamarin Studio
2.  Select "Run"-\>"Start Debugging"![XamarinStudioRunStartDebugging.png](/media/migrated_media-XamarinStudioRunStartDebugging.png)
3.  Your program will appear in the iPhone Simulator ![FrbiOSInSimulator.png](/media/migrated_media-FrbiOSInSimulator.png)

## Making changes in Glue

Once you have verified that the project runs in the iPhone simulator, you can develop normally in Glue. After making changes in Glue or on the PC, you can simply copy the project using the Copy Project tab. Unfortunately at the time of this writing, Xamarin Studio does not automatically re-load the project when files have been changed. Therefore, you will need to manually reload the project by right-clicking on the project in the OSX IDE and selecting Reload:![ReloadXamarinStudio.png](/media/migrated_media-ReloadXamarinStudio.png)

## Making changes on OSX

Since the projects are copied from Windows to OSX, if you make changes on the OSX side of things - such as by modifying .cs files, then you will need to migrate those changes back to PC.

This can be done through the Glue plugin by swapping the "Copy From" and "Copy To" folder. Note that the "Custom Folder" radio must be checked to enter a value in the "Copy From" section.

Keep in mind that the entire folder structure is copied when the "Copy Projects!" button is checked, so changes from the "From" folder will overwrite changes in the "To" folder. We recommend taking advantage of version control software to back up your project to prevent unintentional overwriting of data.

![SwappedCopyFromCopyTo.PNG](/media/migrated_media-SwappedCopyFromCopyTo.PNG)
