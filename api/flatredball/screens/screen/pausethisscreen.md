# PauseThisScreen

### Introduction

PauseThisScreen can be used to implement pausing. In many cases, this function will effectively provide pause implementation for games.

### Example Usage - Pausing With the Keyboard

The following code shows how to pause and unpause the screen using a gamepad's Start button.

```csharp
void CustomInitialize()
{
    // start spinning the sprite
    SpriteInstance.RotationZVelocity = 3;
}

void CustomActivity(bool firstTimeCalled)
{
    FlatRedBall.Debugging.Debugger.Write("IsPaused: " + this.IsPaused);
    if (InputManager.Xbox360GamePads[0].ButtonPushed(Xbox360GamePad.Button.Start))
    {
        if(IsPaused)
        {
            UnpauseThisScreen();
        }
        else
        {
            PauseThisScreen();
        }
    }
}
```

When the game is paused, the Sprite automatically stops rotating and resumes when the game is unpaused.

<figure><img src="../../../../media/2022-10-28_19-44-16.gif" alt=""><figcaption></figcaption></figure>

### Applying Movement After Pause

When a Screen is paused, the underlying engine logic does not stop. Rather, the velocity of all objects is stopped and stored in instructions. When the screen is unpaused, all velocity values are re-applied. This means that if a velocity is changed after a screen is paused, the object which has been given velocity (or acceleration) will continue to operate while everything else remains paused. Furthermore, whenever a Screen is paused, its CustomActivity continues to be called every frame even while paused. Therefore, you can perform additional logic after a pause.

### Example - Applying Movement After Pause

The following code assumes an Entity named Ball. Clicking the cursor creates a new Ball which falls. Pressing the Space toggles pause. Notice that pausing the game will pause all existing entities, but new entities created after a pause will fall normally.

```csharp
void CustomInitialize()
{
    FlatRedBallServices.Game.IsMouseVisible = true;
}

void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryClick)
    {
        var position = cursor.WorldPosition.ToVector3();
        var ball = BallFactory.CreateNew(position);
        ball.YAcceleration = -50;
    }

    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        if(this.IsPaused)
        {
            UnpauseThisScreen();
        }
        else
        {
            PauseThisScreen();
        }
    }
}
```

<figure><img src="../../../../media/2022-10-28_19-51-13.gif" alt=""><figcaption></figcaption></figure>
