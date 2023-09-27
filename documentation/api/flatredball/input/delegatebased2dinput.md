## Introduction

The DelegateBased2DInput  class allows creating a custom I2DInput  implementation without creating a custom class. This is especially useful if creating a class which will satisfy multiple input interfaces, such as a custom controller implementation.

## Code Example

The following code shows how to create a 2D Input that uses the Keyboard's arrow keys:

    Func<float> xFunc = () =>
    {
        if(InputManager.Keyboard.KeyPushed(Keys.Left))
        {
            return -1;
        }
        else if(InputManager.Keyboard.KeyPushed(Keys.Right))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    };

    Func<float> yFunc = () =>
    {
        if(InputManager.Keyboard.KeyPushed(Keys.Down))
        {
            return -1;
        }
        else if(InputManager.Keyboard.KeyPushed(Keys.Up))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    };

    I2DInput input = new DelegateBased2DInput(xFunc, yFunc, () => 0, () => 0);

    // Now the input object can be used anywhere

 
