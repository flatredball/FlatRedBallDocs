## Introduction

The IsActive property can tell you if the Game window has focus. This is useful if you are building applications or games which you do not want to receive input if the window is not in focus. For example, if a Game is behind another Window, but the game responds to mouse clicks, the game will receive the mouse clicks by default. To prevent this, an IsActive check can be made.

[link title](http://www.example.com)

## Code Example

The follow code can prevent a particular method from running by performing an "early out" on the code.

     public void SomeMethod()
     {
        // EARLY OUT!!!
        if(!FlatRedBallServices.Game.IsActive)
        {
             return;
        }

        // If we got here that means the game is active, so do things
        // logic logic logic logic logic
     }
