# Adding FlatRedBall to a MonoGame/FNA Project

### Introduction

FlatRedBall can be added to any MonoGame/XNA project with only three lines of code. This tutorial describes the process of adding FlatRedBall to a project created from a MonoGame/XNA template.

### Downloading .dll Files

First we'll download the FlatRedBall .dll files. Note that FlatRedBall provides different files depending on the platform you are targeting.

1. Go to the [prebuilt file location](http://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/SingleDlls/).
2.  Select your platform

    ![](../../.gitbook/assets/2018-10-img\_5bbb6fec05e77.png)
3.  Select **Debug** or **Release.** You may want to start with Debug, then grab the release .dlls when you are ready to test your game for release.

    ![](../../.gitbook/assets/2018-10-img\_5bbb7036d4f9c.png)
4.  Download the .dll for FlatRedBall, and the associated .pdb file if you would like additional debugging information.

    ![](../../.gitbook/assets/2018-10-img\_5bbb70c0eeb35.png)

    Note that the folder will include other files, which may be needed if you would like to add FlatRedBall.Forms to your project. However if you are interested in only the core FlatRedBall functionality, you will only need the single .dll.

### Referencing Files

Most FlatRedBall platforms only require a single - the engine .dll. Add this file to your existing game project's references.

1. Open your project in **Visual Studio**
2. Expand the game project in the **Solution Explorer**
3. Right-click on the **References** item
4.  Select **Add Reference**...

    ![](../../.gitbook/assets/2018-10-img\_5bbb72137e780.png)
5. Select the **Browse** category
6.  Click the **Browse...** button

    ![](../../.gitbook/assets/2018-10-img\_5bbb725ed1603.png)
7. Navigate to where you have downloaded the .dll in the previous steps and select it to add it to your project.

### Adding Code

Now that your project is referencing FlatRedBall, add the following code: In Game1.Initialize:

```
FlatRedBall.FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);
```

In Game1.Update:

```
FlatRedBall.FlatRedBallServices.Update(gameTime);
```

In Game1.Draw:

```
FlatRedBallServices.Draw();
```

### Note about Clearing Screen

The default template includes code for clearing the screen in the Draw method. FlatRedBall automatically clears the screen for you, so having the call outside of FlatRedBall is redundant. You can choose if you want FlatRedBall to clear the screen, or if you want your own code to clear the screen.

#### Clearing the Screen with FlatRedBall

FlatRedBall automatically clears the screen, so you can remove any code that performs clearing for you, such as:

```
//GraphicsDevice.Clear(Color.CornflowerBlue);
```

#### Clearing the Screen with Custom Code

If you want to clear the screen in your own code, you can tell FlatRedBall to not clear the screen by setting the main camera's background color to transparent:

```lang:c#
protected override void Initialize()
{
    ...
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);
    // Set the camera's background to transparent so it doesn't clear the screen:
    FlatRedBall.Camera.Main.BackgroundColor = Microsoft.Xna.Framework.Color.Transparent;
```
