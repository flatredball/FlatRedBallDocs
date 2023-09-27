## Introduction

Handle is a pointer that can be used to retrieve the Form representing the game window. This can be used for logic such as restricting the game's minimum width and height.

## Code Example

``` default
Form gameWindowForm = (Form)Form.FromHandle(FlatRedBallServices.Game.Window.Handle);
```
