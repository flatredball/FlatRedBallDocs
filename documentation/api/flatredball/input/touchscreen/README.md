## Introduction

The TouchScreen class provides information about the physical touch screen on devices which provide one. This class can be used on Android, iOS, and touch-enabled Windows RT apps. An instance of the TouchScreen class is automatically instantiated and available through the InputManager, so you do not need to instantiate your own. For more information, see the [TouchScreen page](/frb/docs/index.php?title=FlatRedBall.Input.InputManager.TouchScreen&action=edit&redlink=1 "FlatRedBall.Input.InputManager.TouchScreen (page does not exist)").

**Note:**This class does not work for touch screens for Windows 7. Touch screens for Windows 7 are not exposed to the XNA API. You will need to read touch screen input manually. For more information, see this link: [http://blogs.msdn.com/b/shawnhar/archive/2010/09/09/touch-input-on-windows-in-xna-game-studio-4-0.aspx](http://blogs.msdn.com/b/shawnhar/archive/2010/09/09/touch-input-on-windows-in-xna-game-studio-4-0.aspx)

## Common Usage

The FlatRedBall TouchScreen provides a thin wrapper and access to the underlying [GestureSamples](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.input.touch.gesturesample.position.aspx) provided by XNA. If you are comfortable using the XNA-provided GestureSample class, you can set the TouchScreen's [ReadsGestures](/frb/docs/index.php?title=FlatRedBall.Input.TouchScreen.ReadsGestures "FlatRedBall.Input.TouchScreen.ReadsGestures") property to false. Otherwise, you will want to loop through the [LastFrameGestures](/frb/docs/index.php?title=FlatRedBall.Input.TouchScreen.LastFrameGestures "FlatRedBall.Input.TouchScreen.LastFrameGestures") list and perform actions appropriately.

## TouchScreen Members

-   [FlatRedBall.Input.TouchScreen.LastFrameGestures](/frb/docs/index.php?title=FlatRedBall.Input.TouchScreen.LastFrameGestures "FlatRedBall.Input.TouchScreen.LastFrameGestures")
-   [FlatRedBall.Input.TouchScreen.ReadsGestures](/frb/docs/index.php?title=FlatRedBall.Input.TouchScreen.ReadsGestures "FlatRedBall.Input.TouchScreen.ReadsGestures")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
