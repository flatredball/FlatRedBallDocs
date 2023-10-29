# setproperty

### Introduction

The SetProperty method can be used to assign any property on a GraphicalUiElement by the name of the property. This method is used internally to apply states, but it can also be used to perform scripting or assign state values without access to code generated types.

### Code Example - Assigning Position

The following code assigns the Y value of a ColoredRectangle according to keyboard input.

```
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
    {
        GumScreen.ColoredRectangleInstance.SetProperty("Y", 10.0f);
    }
    if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
    {
        GumScreen.ColoredRectangleInstance.SetProperty("Y", 80.0f);
    }
}
```

[![](../../../../media/2022-01-08\_22-28-18.gif)](../../../../media/2022-01-08\_22-28-18.gif)

### Code Example - Assigning States

SetProperty allows the assignment of states by state name. This is useful when writing code which should apply to any type of Gum object as long as it contains the required category and states. This example assumes a component with a Size category containing two states: Big and Small.

![](../../../../media/2022-01-img\_61da73189b5bd.png)

This will automatically generate an enumeration and property in the component:

![](../../../../media/2022-01-img\_61da7364c4507.png)

If you are writing code where you do not have access to the specific types, the state category can still be assigned using SetProperty as shown in the following code. Notice that the variable name does not use the prefix "Current", so the variable assigned is simply "SizeState":

```
var keyboard = InputManager.Keyboard;

if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
{
    GumScreen.ComponentWithStatesInstance.SetProperty("SizeState", "Big");
}
if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
{
    GumScreen.ComponentWithStatesInstance.SetProperty("SizeState", "Small");
}
```

[![](../../../../media/2022-01-08\_22-39-04.gif)](../../../../media/2022-01-08\_22-39-04.gif) &#x20;
