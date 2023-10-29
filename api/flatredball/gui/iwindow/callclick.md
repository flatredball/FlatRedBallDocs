## Introduction

The CallClick method forces the implementing IWindow to raise its Click event. This can be used to test clicking events or to allow other input or logic to simulate a button click.

## Code Example

The following calls click when the space bar is pressed.


    bool wasSpacePushed = InputManager.Keyboard.KeyPushed(Keys.Space);

    if(wasKeyPushed)
    {
       WindowInstance.CallClick();
    }
