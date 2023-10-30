# testcollision

### Introduction

TestCollision  is a method which is automatically called by the FlatRedBall engine on all IWindow  instances which are part of the GuiManager . The Gum plugin automatically writes code for every Gum runtime to implement the IWindow  interface, and Gum objects are directly or indirectly added to the GuiManager  automatically. In other words, the TestCollision  method is usually not called in game code, but can be used to diagnose problems with UI events not being raised.

### Debugging TestCollision

TestCollision  is part of the GumRuntime.IWindow.cs  file, which is added to all projects which use Gum. Therefore, this can be easily debugged by calling the method and stepping in to see the logic flow. IWindow instances are either directly added to the GuiManager (if it's the root) or indirectly added as a child of a root object. The FlatRedBall code does not directly call TestCollision  on all living UI elements. Rather, it calls it on the top-level, which is then responsible for calling it on its children. Therefore, when testing TestCollision, it's best to begin the test at the top level UI element (ignoring the Screen itself). For example, consider the following image:

![](../../../../media/2017-05-img\_590df177b4381.png)

In this case the top-level object is **ChildStandardContainerInstance**. If testing collision against **ButtonInstance**, then TestCollision  should be called on **ChildStandardContainerInstance** to simulate the engine's behavior. To access the ChildStandardContainerInstance at runtime:

1. Drag+drop the Gum screen file (.gusx) onto the Glue Screen's Objects
2. Use the **Source Name** dropdown to select the desired object (ChildStandardContainerInstance in this case)
3. Click OK 

<figure><img src="../../../../media/2017-05-DragDropGumObject.gif" alt=""><figcaption></figcaption></figure>



To follow the logic:

1. Open Visual Studio
2. Open the Glue screen file which contains the newly-added object (GameScreen.cs in this case)
3. Find the CustomActivity  method
4. Add the following code:

```lang:c#
void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryClick)
    {
        ChildStandardContainerInstance.TestCollision(cursor);
    }
}
```

Now we can add a breakpoint to the TestCollision  call. Notice that the call is wrapped in an if statement. This gives you the chance to position the cursor where you want it before hitting the breakpoint. Without the if statement, the breakpoint would hit immediately, making debugging more difficult.

![](../../../../media/2017-05-img\_590df49498b85.png)
