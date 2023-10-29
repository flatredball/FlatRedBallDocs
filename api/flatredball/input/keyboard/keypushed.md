## Introduction

The KeyPushed method returns whether the argument key was pressed this frame. This value will only return true for one frame when the key is first pushed.

## Code Example

The following code will test to see if the Enter key has been pushed:

    if(InputManager.Keyboard.KeyPushed(Keys.Space))
    {
       // do something...
    }
