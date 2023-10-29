## Introduction

The IgnoreKeyForOneFrame method marks the argument key as being ignored for the rest of the current frame. This is useful if your project has two live objects which are checking for a particular key, but you only want one of them to receive the key press.

## Code Example

In this example we will consider a game screen which uses the Escape key to show a pause menu. Once the pause menu is visible, the Escape key will close it. We will assume that the Pause menu is an instance inside the Screen which has a Visible property (ImplementsIVisible in Glue). Code may look like this:

    // In CustomActivity in GameScreen.cs (the custom code file)
    if(InputManager.Keyboard.KeyPushed(Keys.Escape) && PauseMenuInstance.Visible == false)
    {
       // The pause menu is not up, so let's show it then prevent anything else from using the Escape key
       PauseMenuInstance.Visible = true;
       InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
    }

    // In CustomActivity in PauseMenu.cs (the custom code file)
    if(InputManager.Keyboard.KeyPushed(Keys.Escape) && this.Visible == true)
    {
       this.Visible = false;
       InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
    }

The code should consume the Escape key by calling IgnoreKeyForOneFrame to prevent both pieces of code from executing in the same frame.
