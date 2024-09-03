# Web

### Introduction

FlatRedBall supports web projects using Blazor Web Assembly and WebGL. Web projects use C# just like other FlatRedBall platforms. Web projects can use the FlatRedBall Editor, almost all FlatRedBall features, and support synced projects.

### Creating a FlatRedBall Web Project

FlatRedBall Web projects can be created as standalone (primary) projects, or as synced projects. For more information on how to create a synced project, see the [View Projects](../menu/project/view-projects.md) page. In other words, you can create a new project (File -> New Project) or you can add a new web synced project.

Whether you create a new project or use a synced project, you can select Web as the target for your new project.

<figure><img src="../../.gitbook/assets/image (1) (1).png" alt=""><figcaption><p>New project window with Web as the selected platform type</p></figcaption></figure>

Once you have created a Web project you can use the FlatRedBall Editor as if it's a regular Desktop project. For known limitations see the section below.

To run your project:

1.  Open the project in Visual Studio\


    <figure><img src="../../.gitbook/assets/image (1) (1) (1).png" alt=""><figcaption><p>Open project in Visual Studio</p></figcaption></figure>
2.  Press the button to begin debugging your project in Visual Studio\


    <figure><img src="../../.gitbook/assets/image (2).png" alt=""><figcaption><p>Start debugging button in Visual Studio</p></figcaption></figure>


3.  A browser should appear running your game project\


    <figure><img src="../../.gitbook/assets/image (3).png" alt=""><figcaption><p>FlatRedBall running in a browser</p></figcaption></figure>

### Known Limitations

As of August 2024 FlatRedBall Web is a new platform. The following are known limitations of the platform. Over time more limitations will be discovered, while some may be solved. For more information please check the FlatRedBall Discord server.

#### Gamepad

* Switch controllers are not supported. Xbox One controllers have been tested and work correctly
* Setting controller vibration is not supported

#### Audio

* The user must interact with the browser before audio plays

#### File IO

* Local saving and loading of files cannot be performed with the standard System.IO.File operations

#### Camera/Resolution

* The browser determines the size of the game. Unlike regular DesktopGL projects, FlatRedBall cannot forcefully change the browser size. Of course, FlatRedBall properly reacts to resolution changes on a browser including maintaining the internal resolution and aspect ratio.

#### Graphics

* Some color operations such as Add and ColorTextureAlpha are currently not implemented, although future versions of FlatRedBall Web may address this.

#### Debugging

* Exceptions often do not break in the debugger, so you may need to watch the browser for exceptions in the debugger console (CTRL+SHIFT+i in Chrome)
