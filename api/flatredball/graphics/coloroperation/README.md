# ColorOperation

### Introduction

The ColorOperation enumeration defines possible color operations which can be used by an [IColorable](../../../../frb/docs/index.php) to modify its appearance. For more information, see the [IColorable](../../../../frb/docs/index.php) wiki entry.

### ColorOperation Values

The following table lists color operations and supported platforms:

| ColorOperation                          | PC (DesktopGL) | iOS | Android | Web |
| --------------------------------------- | -------------- | --- | ------- | --- |
| [Modulate](modulate.md)                 | X              | X   | X       | X   |
| [Texture](texture.md)                   | X              | X   | X       | X   |
| [Color](color.md)                       | X              | X   | X       | X   |
| ColorTextureAlpha                       | X              | X   | X       | X   |
| [Add](add.md)                           | X              |     |         |     |
| Subtract                                | X              |     |         |     |
| InverseTexture                          | X              |     |         |     |
| Modulate2X                              | X              |     |         |     |
| Modulate4X                              | X              |     |         |     |
| [InterpolateColor](interpolatecolor.md) | X              |     |         |     |

