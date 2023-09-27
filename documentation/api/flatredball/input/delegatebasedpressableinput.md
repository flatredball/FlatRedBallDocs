## Introduction

DelegateBasedPressableInput makes it easy to create a IPressableInput implementation without creating a new class. This is especially useful if creating a class which will satisfy multiple input interfaces, such as a custom controller implementation. The DelegateBasedPressableInput takes three Func\<bool\> arguments to its constructor as shown in the following signature:

``` lang:c#
public DelegateBasedPressableInput(Func<bool> isDown, Func<bool> wasJustPressed, Func<bool> wasJustReleased)
```

## Code Example - Always Pressed

To create a pressable input that is always pressed, you can use the the following code:

``` lang:c#
var alwaysPressed = new DelegateBasedPressableInput(
    () => true,  // isDown
    () => false, // wasJustPressed
    () => false);// wasJustReleased
```

 

 
