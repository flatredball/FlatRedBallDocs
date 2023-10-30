# tutorials-controlling-an-entity

### Introduction

So far we have a basic structure for our game: an Entity with graphical representation, a Screen, and an instance of our Entity in our Screen. This tutorial requires writing code.

### How will we control our Entity?

Before implementing code to control your Entity you will need to decide how to control an Entity. For this tutorial we will implement controls using Xbox 360 controllers as well as keyboard (in case Xbox 360 controllers are not available). We will use FlatRedBall's input interfaces so that our game code doesn't need to consider which input device is using after initial setup.

### Defining Control Interfaces

First we'll need to define which controls are needed in our game. Our PlayerBall will require the following input:

* Movement in the X and Y coordinates - also known as "2D input"
* Input for executing a boost. Boosts temporarily increase the player's speed when executed for a short amount of time. The user does not need to hold the input down, simply pressing the button/key is enough.

We'll want to write the PlayerBall so that it will work with any input device, whether that's Xbox 360 controller, Keyboard, or any other device. To add code to PlayerBall, open PlayerBall.cs in Visual Studio. This will be located in your project's Entities folder.![PlayerBallInVS.png](../../../media/migrated_media-PlayerBallInVS.png)

Modify the **PlayerBall.cs** file so it contains two input properties as follows:

```
public partial class PlayerBall
{
    public I2DInput MovementInput { get; set; }
    public IPressableInput BoostInput { get; set; }
    ...
```

Next we will add code to move the player ball - we'll worry about the boost later. Notice that there are four methods in PlayerBall.cs:

* CustomInitialize
* CustomActivity
* CustomDestroy
* CustomLoadStaticContent

CustomActivity gets called every frame, so we can use it method to respond to controller input and modify our PlayerBall appropriately.

Add the following code in the CustomActivity method in **PlayerBall.cs**:

```
private void CustomActivity()
{
    float movementSpeed = 10;
    if (MovementInput != null)
    {
        this.XVelocity = MovementInput.X * movementSpeed;
        this.YVelocity = MovementInput.Y * movementSpeed;
    }
}
```

At this point we have written fully-functional code for moving the ball according to its MovementInput; however, we haven't assigned the MovementInput yet. We'll do this next.

### Assigning Movement Input

The MovementInput and BoostInput were intentionally created as public properties so that they could be assigned by the GameScreen. The GameScreen will contain logic for deciding which input device to use.

To assign the input interfaces, open **GameScreen.cs** in the Screens folder and modify the CustomInitialize method as follows:

```
public partial class GameScreen
{

    void CustomInitialize()
    {
            PlayerBallInstance.MovementInput =
                InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
            PlayerBallInstance.BoostInput = InputManager.Keyboard.GetKey(Keys.B);
    }
        ...
```

For more information on the Keyboard class, see [the Keyboard page](../../../frb/docs/index.php).

### Cleaning up the code

**Clean code is very important.** This is something we stress at FlatRedBall for all developers making any kind of game regardless of size. Therefore, this tutorial (and others in the future) will discuss how code can be improved to be cleaner and more flexible.

The code we wrote above has a number of problems:

* The velocity (which was set to 10) is set right in the method where it's used. In this case the velocity value is considered "data" and its application is considered "logic". The separation of data from logic is a fundamental concept in keeping game projects maintainable.
* The game includes logic in the CustomActivity method. We encourage no logic, only method calls in the standard "Custom" methods. For more information, click [here.](../../../frb/docs/index.php#CustomActivity_and_CustomInitialize_methods_should_contain_no_logic)

### Separating Data from Logic using Glue Variables

Glue provides a number of ways to separate data from logic. The simplest of these is to create variables. To add a variable to the PlayerBall entity:

1. In Glue, expand your **PlayerBall Entity**
2. Right click on **PlayerBall's** Variables tree item and select "Add Variable"
3. Click the "Create a new variable" option
4. Verify that "float" is the "Type"
5. Enter the name "MovementSpeed" and click the OK button
6. Verify "Variables" is selected and set MovementSpeed to 100

![AddMovementSpeedVariable.gif](../../../media/migrated_media-AddMovementSpeedVariable.gif)

Finally, return to the movement code **inside PlayerBall.cs** and change the code to:

```
private void CustomActivity()
{
    if (MovementInput != null)
    {
        this.XVelocity = MovementInput.X * MovementSpeed;
        this.YVelocity = MovementInput.Y * MovementSpeed;
    }
}
```

If we run the game now we can control the player with the W, A, S, and D keys:

![MovingBeefballWithKeyboard.gif](../../../media/migrated_media-MovingBeefballWithKeyboard.gif)

### Adding Xbox360 Controls

The benefit of using the input interfaces (I2DInput and IPressableInput) is that the input device being used can be set or changed without any code changes in the entity. For example, we can modify the GameScreen to optionally use an Xbox 360 controller if it is available, otherwise it will fall back to the keyboard. To add support for keyboard and Xbox 360 controls, open **GameScreen.cs** and Modify CustomActivity as follows:

```
void CustomInitialize()
{
    if (InputManager.Xbox360GamePads[0].IsConnected)
    {
        PlayerBallInstance.MovementInput =
            InputManager.Xbox360GamePads[0].LeftStick;
        PlayerBallInstance.BoostInput =
            InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A);
    }
    else
    {
        PlayerBallInstance.MovementInput =
            InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
        PlayerBallInstance.BoostInput = InputManager.Keyboard.GetKey(Keys.B);
    }
}
```

For more information on Xbox360GamePad, see [the Xbox360GamePad page](../../../frb/docs/index.php).

### Cleaning CustomActivity and CustomInitialize

Finally, we will clean up CustomActivity. In general, we encourage keeping the Custom methods free of logic so that it is clear what an Entity/Screen is doing when initialized and when destroyed without having to mentally translate code into concept. Open **PlayerBall.cs** and replace the CustomActivity with the following:

```
private void CustomActivity()
{
    MovementActivity();
}
```

Then define MovementActivity in **PlayerBall.cs** file:

```
private void MovementActivity()
{
    if (MovementInput != null)
    {
        this.XVelocity = MovementInput.X * MovementSpeed;
        this.YVelocity = MovementInput.Y * MovementSpeed;
    }
}
```

Similarly, we'll want to clean up the CustomInitialize method in **GameScreen.cs**:

```
void CustomInitialize()
{
    AssignInput();
}
```

We'll implement the AssignInput method in **GameScreen.cs**:

```
private void AssignInput()
{
    if (InputManager.Xbox360GamePads[0].IsConnected)
    {
        PlayerBallInstance.MovementInput =
            InputManager.Xbox360GamePads[0].LeftStick;
        PlayerBallInstance.BoostInput =
            InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A);
    }
    else
    {
        PlayerBallInstance.MovementInput =
            InputManager.Keyboard.Get2DInput(Keys.A, Keys.D, Keys.W, Keys.S);
        PlayerBallInstance.BoostInput = InputManager.Keyboard.GetKey(Keys.B);
    }
}
```

### Conclusion

Now we have a PlayerBall Entity which is cleanly written, has speed which can be customized through Glue, and can be moved with the game pad or keyboard. The next tutorial will cover defining collision in the GameScreen.

[<- Creating a Screen](../../../frb/docs/index.php) -- [Creating the Screen Collision ->](../../../frb/docs/index.php)
