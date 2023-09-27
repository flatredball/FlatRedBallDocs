## Introduction

The SizeOrOrientationChanged event is an event which is raised whenever the resolution of the screen is changed, or if the orientation changes. This allows your game to react to the resolution change as necessary. For example, Windows 8 applications can be docked, and when this occurs the screen space for the application changes. This event is not raised when a Windows Desktop app's restore button is clicked (after being maximized), so Windows Desktop apps should use the

## Code Example

In this example you may detect if the user has docked the game, and if the aspect ratio is smaller than some value (indicating that the dock is narrow), then you may want to pause the game.

    // In Game1.cs Initialize() function
    // Do this *after* FlatRedBallServices.Initialize.
    FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += HandleSizeOrOrientationChanged;

    // Define the HandleSizeOrOrientationChanged function which will handle this event
    private static void HandleSizeOrOrientationChanged(object sender, EventArgs e)
    {
        int newWidth = FlatRedBallServices.GraphicsOptions.ResolutionWidth;
        int newHeight = FlatRedBallServices.GraphicsOptions.ResolutionHeight;

        float newAspectRatio = newWidth / (float)newHeight;

        // This can be game-specific.  In this case we'll say anything narrower
        // than an aspect ratio of 1.0 is too narrow, and the game will pause
        const float requiredAspectRatioToRun = 1.0f;

        if(newAspectRatio < requiredAspectRatioToRun)
        {
            // Do your logic here to pause the game and show an appropriate message
        }
        else
        {
            // You can unpause the game here (if it's paused) and hide things as necessary
        }

    }
