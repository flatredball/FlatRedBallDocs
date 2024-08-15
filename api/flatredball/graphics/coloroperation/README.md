# ColorOperation

### Introduction

The ColorOperation enumeration defines possible color operations which can be used by an [IColorable](../../../../frb/docs/index.php) to modify its appearance. For more information, see the [IColorable](../../../../frb/docs/index.php) wiki entry.

### ColorOperation Values

The following table lists color operations and supported platforms:

| ColorOperation                                     | PC (DesktopGL) | iOS | Android | Web \* |
| -------------------------------------------------- | -------------- | --- | ------- | ------ |
| [Modulate](../../../../frb/docs/index.php)         | X              | X   | X       |        |
| [Texture](texture.md)                              | X              | X   | X       | X      |
| [Color](../../../../frb/docs/index.php)            | X              | X   | X       |        |
| ColorTextureAlpha                                  | X              | X   | X       |        |
| Add                                                | X              |     |         |        |
| Subtract                                           | X              |     |         |        |
| InverseTexture                                     | X              |     |         |        |
| Modulate2X                                         | X              |     |         |        |
| Modulate4X                                         | X              |     |         |        |
| [InterpolateColor](../../../../frb/docs/index.php) | X              |     |         |        |

&#x20;\* As of August 15 the only color operation supported is Texture. These will likely be expanded in future versions of FlatRedBall Web.
