## Introduction

The SetColor method can be used to set all 3 components of a Text's color values. The end result of calling this function is the same as setting the individual components. In other words:

    TextInstance.SetColor(0, 1, .5f);

is the same as:

    TextInstance.Red = 0;
    TextInstance.Green = 1;
    TextInstance.Blue = .5f;

For more information on how the Red, Green, and Blue colors impact rendering, see the [IColorable page](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable").
