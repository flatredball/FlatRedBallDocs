## Introduction

The ColorOperation enumeration defines possible color operations which can be used by an [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") to modify its appearance. For more information, see the [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") wiki entry.

## ColorOperation Values

The following table lists color operations and supported platforms:

|                                                                                                                                                              |                        |     |     |         |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------|-----|-----|---------|
| ColorOperation                                                                                                                                               | PC (XNA and DesktopGL) | UWP | iOS | Android |
| [Modulate](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.Modulate.md "FlatRedBall.Graphics.ColorOperation.Modulate")                         | X                      | X   | X   | X       |
| [Texture](/documentation/api/flatredball/flatredball-graphics/flatredball-graphics-coloroperation/texture/.md)                                               | X                      | X   | X   | X       |
| [Color](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.Color.md "FlatRedBall.Graphics.ColorOperation.Color")                                  | X                      | X   | X   | X       |
| ColorTextureAlpha                                                                                                                                            | X                      | X   | X   | X       |
| Add                                                                                                                                                          | X                      |     |     |         |
| Subtract                                                                                                                                                     | X                      |     |     |         |
| InverseTexture                                                                                                                                               | X                      |     |     |         |
| Modulate2X                                                                                                                                                   | X                      |     |     |         |
| Modulate4X                                                                                                                                                   | X                      |     |     |         |
| [InterpolateColor](/frb/docs/index.php?title=FlatRedBall.Graphics.ColorOperation.InterpolateColor.md "FlatRedBall.Graphics.ColorOperation.InterpolateColor") | X                      |     |     |         |

 
