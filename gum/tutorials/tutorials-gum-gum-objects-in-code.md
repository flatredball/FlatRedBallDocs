# tutorials-gum-gum-objects-in-code

### Introduction

So far we've covered how to create a new Gum project in your FlatRedBall project and how to add Gum screens to your FlatRedBall screens. This gets us a considerable amount of functionality already, but it's very likely that you'll need to interact with Gum objects in code. For example, you may use code to dynamically set the visibility of certain UI elements according to the game's state. This tutorial will explain how to work with the GraphicalUiElement in code - the class that is at the heart of Gum.

### Gum Runtime Types in Code

If you've been following along the previous tutorials, then you should have a Screen that has two Gum objects: a Text and a ColoredRectangle. For this tutorial will make some modifications to the ColoredRectangle in our custom code in MainMenu. To make it easy to access Gum objects, the every Gum screen is loaded into a strongly-typed object which can be accessed in your FlatRedBall Screen's custom code using the GumScreen property. Keep in mind that GumScreen is a generated property which standardizes access to the Gum screen. You can also access the Gum screen through the name of the file - MainMenuGum in this case. For example, we can change the Y value of the ColoredRectangleInstance and move it along the X axis in CustomActivity by modifying MainMenu.cs as shown in the following snippet:

1. Open your Visual Studio project
2. Navigate to MainMenu.cs (which will be in your Screens folder in Visual Studio)
3. Modify CustomInitialize so it looks like this:

&#x20;

```
void CustomInitialize()
{
    GumScreen.ColoredRectangleInstance.Y = 250;
}
```

Similarly, objects from Gum can be modified in CustomActivity. You can modify your MainMenu's CustomActivity so it looks like this:

```
void CustomActivity(bool firstTimeCalled)
{
    GumScreen.ColoredRectangleInstance.X += .1f;
}
```

![MovingColoredRectangleFromGum.png](../../../../media/migrated\_media-MovingColoredRectangleFromGum.png)

### Alternative Option 1 - Getting a Gum Object in FlatRedBall Editor

You can also add a reference to the ColoredRectangleInstance in the FlatRedBall Editor. This is not necessary since you already have a strongly-typed reference in code through GumScreen. However, it is still possible if you prefer to have access to the object in the FlatRedBall Editor.

1. Open or bring Glue into focus
2. Expand **Screens**
3. Expand **MainMenu**
4. Expand **Files**
5. Drag+drop the .gusx file onto the **Objects** item
6. Use the dropdown next to **Source Name:** to select **ColoredRectangleInstance**
7. Click **OK**



<figure><img src="../../../../media/2016-01-2019-02-28\_22-30-55.gif" alt=""><figcaption></figcaption></figure>

 Note that the **Source Name:** drop down contains all instances in your Gum project. We selected the **ColoredRectangleInstance** for this example, but you could select any instance. Note that the ColoredRectangle in the FlatRedBall Editor is not a new ColoredRectangle instance - it is a reference to the ColoredRectangle inside the MainMenuGum screen.

### Alternative Option 2 - Getting Objects by Name

Alternatively, you can access an object purely in code through its name. Doing so requires interacting with the instance in its base type (GraphicalUiElement) or casting the object. While this introduces some inconvenience (and can potentially cause crashes if you perform casting incorrectly), it can be useful for UI which is dynamic. For example, the following shows how to acciess the ColoredRectangleInstance purely in code. This code could be added to MainMenu.cs to get a reference to the ColoredRectangleInstance from the MainMenuGum screen:

```
ColoredRectangleRuntime ColoredRectangleInstance;
void CustomInitialize()
{
 ColoredRectangleInstance = GumScreen.GetGraphicalUiElementByName("ColoredRectangleInstance")
   as ColoredRectangleRuntime;
}
```

Notice that we use the name **ColoredRectangleInstance**. This needs to match the name of the instance in the Gum screen exactly, including capitalization:

![](../../../../media/2021-03-img\_604b8ddb7fffd.png)

Also, notice that we use the type **ColoredRectangleRuntime**. We did this because the type in code should match the type in your Gum project. FlatRedBall automatically generates classes for every type in your Gum project, but it will always append **Runtime** to the end of the name. Therefore, the type **ColoredRectangle** in Gum becomes **ColoredRectangleRuntime** in code.

![](../../../../media/2021-03-img\_604b97ecbcab8.png)

### Incrementing Score

The example above shows how to move the rectangle. For this example we will modify the Text object to display score. We will increment the score whenever the player presses the space bar. This is just a simple example to show how to show a score. A real game may increase the score on an event such as when a bullet hits an enemy. We will access the TextInstance purely in code - but if you are more comfortable using the drag+drop approach to access the Text object, feel free to do that instead. To display a score, modify the MainMenu code:

```
int score = 0;
void CustomInitialize()
{
 GumScreen.TextInstance.Text = score.ToString();
}

void CustomActivity(bool firstTimeCalled)
{
 if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
 {
   score++;
   GumScreen.TextInstance.Text = score.ToString();
 }
}
```



<figure><img src="../../../../media/2016-01-2021\_March\_07\_080847.gif" alt=""><figcaption></figcaption></figure>

 Notice that the TextIntance property matches the exact name in Gum:

![](../../../../media/2021-03-img\_604b8fae4c068.png)

### Gum Coordinate System

I've you've spent some time in Gum you may notice that the coordinate system in Gum behaves differently than the coordinate system in FlatRedBall. By default (0,0) is located at the center of the screen in FlatRedBall, but (0,0) represents the top-left corner of the screen in Gum. Also, increasing the Y value of an object will move it up in FlatRedBall, but increasing the Y value of a Gum object will move it down. You can try this by modifying your code to change the Y of the ColoredRectangleInstance in CustomActivity. When used with FlatRedBall, Gum objects will behave identically to how they behave in the Gum tool. This not only applies to Y positioning but as we will see in later tutorials with position and width unit types as well.

### Conclusion

This tutorial has shown how to access objects from Gum in code. FlatRedBall generates objects which we can edit in code with full compile-time protection and Visual Studio IntelliSense. The next tutorial will show you how to use UI events (such as Click) on Gum components. [<- 2. Screens in Gum](tutorials-gum-screens-in-gum.md) -- [4. Events on Gum Objects ->](tutorials-gum-events-on-gum-objects.md)
