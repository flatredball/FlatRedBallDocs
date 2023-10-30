# neoforce-tutorials-creating-a-simple-project

### Creating a new project

Once you have installed Neoforce Controls, the next step is to create an empty XNA project. Of course, Neoforce does not require FlatRedBall, but we will be using FlatRedBall in this tutorial. For more information on how to get FlatRedBall set up, check out the [FlatRedBall Tutorials](../frb/docs/index.php).

To create a new project, simply open Visual Studio, and select File->"New Project..." and select FlatRedBall XNA. Remember, at the time of this writing, Neoforce Controls only works with XNA, so you won't be able to use Neoforce Controls with FlatSilverBall or FlatRedBall MDX.

### Referencing Neoforce

Before adding any Neoforce code, you will need to reference the Neoforce DLL. To do this:

1. Right-click on your project's "Properties" folder.
2. Select "Add Reference".
3. Click the "Browse" tab.
4. Navigate to C:\Program Files\Tom Shane\Neoforce Controls\Bin and select "TomShane.Neoforce.Controls.dll". If you are using Windows 7, you may need to navigate to "C:\Program Files (x86)\Tom Shane\Neoforce Controls\Bin".
5. Click the "OK" button.

Now your project is referencing the necessary .dll to begin adding Neoforce elements.

### Adding the necessary calls

Just like FlatRedBall, Neoforce has a number of required calls. To make Neoforce active, perform the following in your Game class:

Add the following using statement:

```
using TomShane.Neoforce.Controls;
```

Add the following at class scope:

```
// Neoforce GUI manager
Manager manager;
```

Add the following to Initialize:

```
// Manager setup -- we use default skin and do not 
// register manager as a component
manager = new Manager(this, graphics, "Default", false);
manager.Initialize();
```

**Very important:** Place the initialization code for Neoforce Controls **before** the call to FlatRedBallServices.InitializeFlatRedBall(this, graphics)! You may get some purple screen flickering otherwise.

Add the following to Update:

```
manager.Update(gameTime);
```

Add the following to Draw after FlatRedBallServices.Draw:

```
// This needs to be called after FRB's Draw method so that the UI appears on top.
manager.Draw(gameTime);
```

At this point Neoforce is added to your application an is fully functional...but since we haven't added any controls, you don't see anything on screen.

### Adding a control

Now we'll add a simple control to the project to show how it works. To do so, add the following code to your Initialize method **after calling manager.Initialize()**:

```
window = new Window(manager);
window.Init();
window.Text = "My First Neoforce Window";
window.Top = 150; // this is in pixels, top-left is the origin
window.Left = 250;
window.Width = 350;
window.Height = 350;
manager.Add(window);
```

![NeforceWindow.png](../media/migrated_media-NeforceWindow.png)

### A note about Neoforce coordinates

If you are familiar with FlatRedBall's coordinate system (especially the default 3D coordinate system in FRB XNA and MDX), you will need to keep a few things in mind when using Neoforce Controls:

* The top-left of the screen is the origin
* Positive Y is down, not up
* Each unit is 1 pixel. Therefore, the bottom-right corner of a default view is (800, 600)
* The location of a Control (the base class of Neoforce objects such as Windows) is defined by its Top and Left properties. These (obviously) define the top-left of the object. The location of the Control does not define its center, as does the location of most objects in FlatRedBall.
