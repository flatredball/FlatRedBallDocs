## Introduction

IsMouseVisible can be set to true to display the mouse cursor. This value defaults to false which means the mouse will be invisible when it is over the game window.

## Code Example

The following code shows how to make the mouse cursor visible. It assumes the code is written in Game1.cs, so it uses "this":

    this.IsMouseVisible = true;

If not in the Game1.cs, this can be accessed through FlatRedBallServices:

    FlatRedBallServices.Game.IsMouseVisible = true;
