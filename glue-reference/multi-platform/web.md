# Web

### Introduction

FlatRedBall supports web projects using Blazor Web Assembly and WebGL. Web projects use C# just like other FlatRedBall platforms. Web projects can use the FlatRedBall Editor, almost all FlatRedBall features, and support synced projects.

FlatRedBall Web uses the Kni framwork, which is an XNA-like framework supporting Blazor WASM projects. Fortunately, this means that FlatRedBall and XNA code should work the same on Web as on other platforms, reducing the amount of code changes needed when migrating from other platforms to Web.

### Installing Kni

Before creating a FlatRedBall Web project, you must install Kni. The latest binaries can be found on the Kni release page: [https://github.com/kniEngine/kni/releases](https://github.com/kniEngine/kni/releases)

<figure><img src="../../.gitbook/assets/image (343).png" alt=""><figcaption><p>Download KniSdkSetup exe for the latest version</p></figcaption></figure>

### Creating a FlatRedBall Web Project

FlatRedBall Web projects can be created as standalone (primary) projects, or as synced projects. For more information on how to create a synced project, see the [View Projects](../menu/project/view-projects.md) page. In other words, you can create a new project (File -> New Project) or you can add a new web synced project.

Whether you create a new project or use a synced project, you can select Web as the target for your new project.

<figure><img src="../../.gitbook/assets/image (13).png" alt=""><figcaption><p>New project window with Web as the selected platform type</p></figcaption></figure>

Once you have created a Web project you can use the FlatRedBall Editor as if it's a regular Desktop project. For known limitations see the section below.

To run your project:

1.  Open the project in Visual Studio\


    <figure><img src="../../.gitbook/assets/image (14).png" alt=""><figcaption><p>Open project in Visual Studio</p></figcaption></figure>
2.  Press the button to begin debugging your project in Visual Studio\


    <figure><img src="../../.gitbook/assets/image (15).png" alt=""><figcaption><p>Start debugging button in Visual Studio</p></figcaption></figure>


3.  A browser should appear running your game project\


    <figure><img src="../../.gitbook/assets/image (16).png" alt=""><figcaption><p>FlatRedBall running in a browser</p></figcaption></figure>

### Debugging

FlatRedBall Web projects can be debugged in a number of ways:

* To output to the browser console, use `System.Console.WriteLine` just like a normal console application. Note that output from this method appears in both the browser's console as well as Visual Studio's output window.
* Breakpoints should function the same as normal FlatRedBall projects; however, as of .NET 8 at times stepover will step over a large block of code or may even freeze the application. This may be improved in future versions of .NET.

#### Exceptions in Update

Exceptions in the Update of your game (which includes all generated and CustomActivity calls) may not result in Visual Studio breaking on exceptions. Instead, this can result in your game displaying a purple window. To solve this problem you can wrap your Game's Update call in a try/catch. If you are concerned about modifying your game for other platforms, you can do this only in web, as shown in the following block of code:

```csharp
// In Game1.cs
        protected override void Update(GameTime gameTime)
        {
#if WEB
            try
            {
#endif
                FlatRedBallServices.Update(gameTime);
                FlatRedBall.Screens.ScreenManager.Activity();
                GeneratedUpdate(gameTime);
                base.Update(gameTime);
#if WEB
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
#endif
        }
```

You can place a breakpoint in the catch block to also stop execution when an exception occurs.

#### Cannot read properties of null (reading 'getAttribute')

This exception can occur when running FlatRedBall Web projects.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Unhandled exception in JavaScript</p></figcaption></figure>

You can disable JavaScript exceptions to silence this error.&#x20;

<figure><img src="../../.gitbook/assets/27_10 39 51.png" alt=""><figcaption><p>If these are enabled, turn them off</p></figcaption></figure>

If you do encounter this problem, you can press F5 or continue execution and the game will run normally. This exception will not cause any problems for deployed games.

### Known Limitations

As of August 2024 FlatRedBall Web is a new platform. The following are known limitations of the platform. Over time more limitations will be discovered, while some may be solved. For more information please check the FlatRedBall Discord server.

#### Gamepad

* Switch controllers are not supported. Xbox One controllers have been tested and work correctly
* Setting controller vibration is not supported

#### Audio

* The user must interact with the browser before audio plays. We recommend a loading/title screen that asks the user to click to continue
* MediaPlayer.MediaStateChanged is not implemented when a song automatically loops. This issue can be tracked here: [https://github.com/kniEngine/kni/issues/2182](https://github.com/kniEngine/kni/issues/2182)

#### File IO

* Local saving and loading of files cannot be performed with the standard System.IO.File operations

#### Camera/Resolution

* The browser determines the size of the game. Unlike regular DesktopGL projects, FlatRedBall cannot forcefully change the browser size. Of course, FlatRedBall properly reacts to resolution changes on a browser including maintaining the internal resolution and aspect ratio.

#### Debugging

* Exceptions often do not break in the debugger, so you may need to watch the browser for exceptions in the debugger console (CTRL+SHIFT+i in Chrome)
