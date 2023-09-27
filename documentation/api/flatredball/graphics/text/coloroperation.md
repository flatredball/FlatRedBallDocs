## Introduction

The Text class implements the [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") interface. This gives the Text object lots of flexibility in controlling how it will appear.

For information that is general to all [IColorables](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable"), see the [IColorable page.](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable")

## Default Behavior

By default the Text class has the following [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") properties:

| Property                                                                                                                 | Value              |
|--------------------------------------------------------------------------------------------------------------------------|--------------------|
| [ColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.md "FlatRedBall.Graphics.ColorOperation") | ColorTextureAlpha  |
| Red                                                                                                                      | 1 (255 in FRB MDX) |
| Green                                                                                                                    | 1 (255 in FRB MDX) |
| Blue                                                                                                                     | 1 (255 in FRB MDX) |

Notice that the [ColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.md "FlatRedBall.Graphics.ColorOperation") is "ColorTextureAlpha". This means that the Texture will control the transparency (of course, also considering the Text's Alpha property), but the color is controlled purely by the Red, Green, and Blue properties.

Therefore, by default, the Text object will completely ignore color information from its source Texture and use **only** the three color components that are set.

This can be easily changed, of course. If you want to set the color of your text from its source texture (as might be the case when doing outlined text), consider changing the [ColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.md "FlatRedBall.Graphics.ColorOperation") to Texture or Modulate depending on the effect you are interested in achieving.
