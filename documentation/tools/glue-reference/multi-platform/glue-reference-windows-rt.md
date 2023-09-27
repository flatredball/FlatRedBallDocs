## Introduction

Windows RT apps are fully supported by the FlatRedBall engine and Glue. This means that users are able to create apps and distribute them on the Windows Store, and they will run on Windows RT devices.

## Visual Studios

It is recommended that you upgrade your version of Visual Studios to [Visual Studios 2013 Community](http://www.visualstudio.com/en-us/news/vs2013-community-vs.aspx). Make sure you also upgrade your version of XNA. You can get the download [here](https://msxna.codeplex.com/releases).

## Requirements

To create a Windows RT project you must be running Windows 8 or newer. You must also create an account to deploy Windows RT apps, but this is free. Visual Studio will ask you to create/renew your account if it is out of date.

## Creating a Windows RT Project

To create a Windows RT project:

1.  Open Glue
2.  Select File-\>"New Project"
3.  Select "Windows RT"
4.  Enter the name of the project
5.  Click "Make My Project!"

![NewWindowsRtProject.gif](/media/migrated_media-NewWindowsRtProject.gif)

## Windows RT vs. Desktop code differences

Windows RT projects reference ".NET for Windows Store apps" which is a subset of the full .NET framework. This means that some code must be changed to run on Windows RT.

-   General changes: [http://msdn.microsoft.com/en-us/library/br230302.aspx](http://msdn.microsoft.com/en-us/library/br230302.aspx)
-   System.Diagnostic.Process: [http://stackoverflow.com/questions/12765699/whats-the-equivalent-of-the-system-diagnostic-process-on-winrt-c](http://stackoverflow.com/questions/12765699/whats-the-equivalent-of-the-system-diagnostic-process-on-winrt-c)

## Creating Demo Builds for the Windows RT app

The directions for generating a test build which will install and run on a Windows 8 machine can be found [here](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn263241.aspx?f=255&MSPPError=-2147217396). To run the app on Windows RT from Visual Studio (requires a RT device and a non-RT device), see [this link](http://blogs.msdn.com/b/dsvc/archive/2012/10/26/windows-rt-windows-store-app-debugging.aspx). To install a appxupload file on an RT tablet, see [this link](https://msdn.microsoft.com/en-us/library/windows/apps/bg126232.aspx).

## Publishing the Windows RT app

The requirements for publishing your game to the Windows store can be found [here](https://msdn.microsoft.com/en-us/library/windows/apps/hh694062.aspx?f=255&MSPPError=-2147217396). The steps to publish your game to the Windows store can be found [here](http://blogs.msdn.com/b/cdnstudents/archive/2012/11/30/publishing-windows-8-app-to-the-windows-store-how-to.aspx).
