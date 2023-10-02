# app-icon

### Introduction

By default FlatRedBall templates display the FlatRedBall icon or the MonoGame icon depending on platform. This article discusses how to add icons to your project.

### Desktop GL Windows

A Desktop GL application needs 2 files:

1. .ico - used to display the .exe icon
2. .bmp - used to display the icon on the Windows taskbar

To change the icon on your game's .exe:

1. Open the folder where your .csproj is located. This is the same folder as your Glue file (.glux)
2. Locate **Icon.ico**
3. Open the Icon.ico to edit it, or replace it with an existing .ico file. Note that the file must still be called Icon.ico.

![](../../../media/2020-12-img\_5fc8f4d8bb1a8.png)

If you have changed your .ico file you may still see the old icon in Windows Explorer. Windows caches .ico files so you need to clear the cache. For more information see the following link: [https://neosmart.net/wiki/clear-icons-cache/](https://neosmart.net/wiki/clear-icons-cache/) To change the icon in the taskbar and on the window:

1. Open the folder where your .csproj is located
2. Create or replace an Icon.bmp file
3. If not already added:
   1. Add the Icon.bmp to your Visual Studio game project - verify that the file is in the root of the folder
   2. Mark the Icon.bmp file as an Embedded Resource

For more information, see this GitHub discussion: [https://github.com/MonoGame/MonoGame/issues/5411](https://github.com/MonoGame/MonoGame/issues/5411) Additional info for DesktopGL: [https://github.com/MonoGame/MonoGame/issues/8035#issuecomment-1557429524](https://github.com/MonoGame/MonoGame/issues/8035#issuecomment-1557429524) And... https://github.com/MonoGame/MonoGame/pull/8036 &#x20;
