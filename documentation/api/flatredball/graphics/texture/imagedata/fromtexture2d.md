# fromtexture2d

### Introduction

FromTexture2D creates an ImageData object, filled with data from a Texture2D instance. It's important to note that the ImageData is a copy of the Texture2D, so making changes to the ImageData will not change the source Texture2D.

### Code Example

The following code shows how to create an ImageData instance from a Texture2D instance, then loop through each pixel:

```lang:c#
FlatRedBall.Graphics.Texture.ImageData imageData = 
    FlatRedBall.Graphics.Texture.ImageData.FromTexture2D(TextureFile);

for(int x = 0; x < imageData.Width; x++)
{
    for(int y = 0; y < imageData.Height; y++)
    {
        var pixel = imageData.GetPixelColor(x, y);
        // do something with the pixel color here:
    }
}
```

&#x20;
