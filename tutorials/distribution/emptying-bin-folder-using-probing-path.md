# emptying-bin-folder-using-probing-path

### Introduction

By default FlatRedBall games are built to a **bin** folder which contains the game .exe file, referenced .dlls, and content. If you plan on distributing your game as a .zip file, users may be overwhelmed by the number of files after unzipping.

![](../../../media/2019-02-img_5c68f25cd7489-293x300.png)

This can be solved using the `probing` tag in the app.config file. This guide shows how to use `probing` to move your game's files into a data folder. Note for .NET 6 users - if your game targets .NET 6 and you include .dlls for .NET 6 so that the user does not need to install the runtimes, this method will not work.

### Setting the probing Tag

First, we'll need to decide the name of the sub-folder we want to use for our libraries and data. A common name is **data**. To add this:

1. Open your project in Visual Studio
2. Open the `app.config` file.
3. Add the `probing` tag with the folder name as shown in the following snippet

```lang:c#
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2"/>
  </startup>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <probing privatePath="data;"/>
    </assemblyBinding>
  </runtime>
</configuration>
```

The example above tells the app to look in a **data** folder for referenced libraries. Note that when picking a folder, you will want to pick one that doesn't already exist in your project's folder structure.

### Moving Files to data

Now that the `probing` tag has been added, the game will look in the **data** folder for any libraries. Note that the game will continue to look in the main folder as well, so you are not required to move the libraries and content into the **data** folder until you are ready to distribute your game. Once you are ready, you will want to move every file into the **data** folder except for the main executable and the config file. Make sure to include your game's content folder and any of the files/folders required by MonoGame such as the **x86** and **x64** folders.

![](../../../media/2019-02-img_5c69b776bb535.png)

Once the files have been moved, the only remaining files will be the executable, the config file, and the data folder.

![](../../../media/2019-02-img_5c69b7f753479.png)

At this point there are only two files left in the root folder, but we can further simplify the folder by hiding the config file:

1. Right-click on the .config file
2.  Select **properties**

    ![](../../../media/2019-02-img_5c69b87990362.png)
3.  Check the **Hidden** property

    ![](../../../media/2019-02-img_5c69b8d4cd440.png)
4. Click OK

Now the config file will be hidden. Note that if your settings are to show hidden files you may still see the file (with a half-transparent icon).

![](../../../media/2019-02-img_5c69b981563ae.png)

&#x20;
