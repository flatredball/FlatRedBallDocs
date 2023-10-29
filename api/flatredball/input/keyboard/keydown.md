## Introduction

The KeyDown method is a method which returns whether a particular key is being held down. This method will return true if a key is pressed, and will continue to return true until the key has been released. This method can be used to perform every-frame actions such as setting the velocity of a character if the key is pressed.

## Code Example

The following code will move a Sprite to the right if the Right arrow key is down:

    // assumes SpriteInstance is a valid Sprite, and that it is not attached to anything:
    if(FlatRedBall.Input.Keyboard.KeyDown(Keys.Right))
    {
        // This will move it 10 units per second
        Sprite.X += TimeManager.SecondDifference * 10;
    }
