# Owner

### Introduction

The Owner is a Control that the FlatRedBall Engine renders to. This property is available only on the PC since the Xbox 360 does not render to a Control.

### Eliminating the Border

The following code will result in a game window without any borders. Keep in mind that without the borders the close button will not be present, so you will need to close your application through Visual Studio, through the Task Manager, or by adding close code in your application.

Add the following using statement:

```
using System.Windows.Forms;
```

Add the following to initialize after initializing FlatRedBall:

```
((Form)FlatRedBallServices.Owner).FormBorderStyle = FormBorderStyle.None;
```

![NoBorderGame.png](../../../.gitbook/assets/migrated\_media-NoBorderGame.png)

### Reacting to Form Closing

The Owner can be casted to a Form, and the form provides a number of useful properties and events. The following code can be used to react to the user using the mouse to press on the X close button.

Add the following to Initialize after initializing FlatRedBall:

```
Form ownerAsForm = ((Form)FlatRedBallServices.Owner);
ownerAsForm .Closing += new System.ComponentModel.CancelEventHandler(GameForm_Closing);
```

Add the following at class scope:

```
private void GameForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
{
    // The following line cancels the close.
    e.Cancel = true;

    // Now you can do whatever you want like as the user if he's sure
    // To manually close, you can use the following line of code:
    // FlatRedBallServices.Game.Exit();
}
```

### Detecting Active Form

Some applications, such as tools, should only have their logic called if they are active. In other words, if the user clicks a different window (such as a web browser or instant messenger window), then the game should skip certain logic. The following code detects whether the game's Form is active:

```
if(System.Windows.Forms.Form.ActiveForm == (Form)FlatRedBallServices.Owner)
{
   // The current form is active, so do whatever here.
}
```
