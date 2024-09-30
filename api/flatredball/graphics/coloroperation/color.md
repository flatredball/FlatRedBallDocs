# Color

The ColorOperation.Color option makes the drawn object completely ignore its Texture and use only the color. For objects like Sprites, this results in a colored quad (no texture). Alpha is ignored completely as well, so even if the Sprite's Texture has transparency, it will appear as a solid rectangle when using this color operation. Sprites that use .Color do not need to have a Texture. Therefore, the following code is acceptable:

```cpp
sprite.ColorOperation = ColorOperation.Color;
sprite.Red = 1;
```

![ColorOperationDotColor.png](../../../../.gitbook/assets/migrated\_media-ColorOperationDotColor.png)
