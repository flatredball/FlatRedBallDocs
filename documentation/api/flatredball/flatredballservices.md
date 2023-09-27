## Introduction

FlatRedBallServices is a static class which is responsible for initializing the FlatRedBall Engine, performing managed behavior, and drawing. Although managed behavior and drawing is technically handled by manager classes, the FlatRedBallServices exposes methods which initiate these behaviors. The FlatRedBallServices class also provides methods for loading and unloading assets from memory. It standardizes the process of loading assets both from file and through the content pipeline and provides simple methods to organize and unload content selectively. The FlatRedBallServices also provides access to common game elements such as the Game class itself, the Owner [Control](http://msdn.microsoft.com/en-us/library/system.windows.forms.control.aspx), and other classes.

## Creating a FlatRedBall Application

The following 3 lines are required to add the FlatRedBall Engine to an XNA template:

    // in Initialize
    FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

    // in Update
    FlatRedBallServices.Update(gameTime);

    // in Draw
    FlatRedBallServices.Draw();

For more information see the tutorial for [Creating a FlatRedBall XNA Project](/frb/docs/index.php?title=Creating_a_FlatRedBall_XNA_Project "Creating a FlatRedBall XNA Project").

## FlatRedBallServices.Load

The generic Load method standardizes the loading of common FlatRedBall objects. The signature for the method is as follows:

    FlatRedBallServices.Load<Type>(string objectName, string contentManagerName)

The Load method can be used to load both FlatRedBall and XNA types. For more information on the Load method, see the [Load page](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load "FlatRedBall.FlatRedBallServices.Load"). For more information on the contentManagerName, see the [FlatRedBall Content Manager wiki entry](/frb/docs/index.php?title=FlatRedBall_Content_Manager "FlatRedBall Content Manager").

## Random Numbers

To generate random numbers the FlatRedBallServices class exposes an instance of the [System.Random](http://msdn2.microsoft.com/en-us/library/system.random.aspx) class. The following code creates a random int between 1 and 6; similar to a 6-sided die.

    // The first argument is inclusive, the second is exclusive
    int value = FlatRedBallServices.Random.Next(1, 7);

The following code creates a random number between 0 and 10 inclusive:

    float randomNumber = (float)(FlatRedBallServices.Random.NextDouble() * 10);

The NextDouble returns a double value between 0 and 1. The code above multiplies it by 10 to get a value between 0 and 10. This value is a double, so the value must be converted to a float if it is to be used for a float variable.

## Exiting FlatRedBall

To exit an application, call the Game's Exit method. This can be accessed through FlatRedBallServices:

    FlatRedBallServices.Game.Exit();

## 
