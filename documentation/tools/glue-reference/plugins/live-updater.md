## Introduction

The Live Updater plugin provides an interface for changing variables on objects while the game is running. It can be helpful in debugging runtime logic, tuning variables, and testing scenarios which might otherwise require restarting the project.

## Installing Live Updater

Installing the Live Updater requires installing a Glue plugin and installing a NuGet package in Visual Studio.

### 1. Installing Glue Plugin

The plugin can be obtained from GlueVault: [http://www.gluevault.com/plug/93-live-updater](http://www.gluevault.com/plug/93-live-updater)

### 2. Installing NuGet Package

The Live Updater requires installing a nuget package. To do so:

-   In Visual Studio, select Tools -\> NuGet Package Manager -\> Package Manager

    ![](/media/2016-04-img_571ea13434798.png)

-   Type in the following command: \`Install-Package OcularPlane.Networking.WcfTcp.Host\`

    ![](/media/2016-04-img_571ea649cd583.png)

## Viewing Runtime Objects

Once installed, Glue will display two new tabs:

1.  A tab displaying all objects available at runtime
2.  A tab displaying the properties of the selected runtime object

![](/media/2016-04-img_571ea1fb28db5.png)

When your game is running (either through Glue or Visual Studio), the Runtime Objects list will fill up with all objects. Objects contained in a [PositionedObjectList](/documentation/api/flatredball/flatredball-math/flatredball-math-positionedobjectlist/.md) added through Glue will contain dynamically-created objects (such as enemy bullets):

![](/media/2016-04-img_571ea2e8f191b.png)

Selecting one of the runtime objects will display its variables in real time:

![](/media/2016-04-img_571ea3340de95.png)

Changes to variables will be immediately applied in your game.
