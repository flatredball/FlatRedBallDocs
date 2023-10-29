## Introduction

The Sprites member in a Scene provides access to the contained Sprites.

## Accessing the Sprites

You can simply loop through the Sprites to make changes. For example, the following code sets all contained Sprites' Alpha to 0:

    for(int i = 0; i < SceneInstance.Sprites.Count; i++)
    {
        SceneInstance.Sprites[i].Alpha = 0;
    }

## Getting the dimensions of your Scene

Scenes do not have an inherent width or height because they are just a collection of visual elements. To get the width or height you can loop through all contained visual elements to calculate the minimum and maximum values. For example, a Scene with only Sprites could have its min and max values calculated as such:


    float minX = float.PositiveInfinity;
    float maxX = float.NegativeInfinity;

    float minY = float.PositiveInfinity;
    float maxY = float.NegativeInfinity;

    for(int i = 0; i < sceneInstance.Sprites.Count; i++)
    {
      minX = System.Math.Min(minX, sceneInstance.Sprites[i].X - sceneInstance.Sprites[i].Width / 2.0f);
      maxX = System.Math.Max(maxX, sceneInstance.Sprites[i].X + sceneInstance.Sprites[i].Width / 2.0f);

      minY = System.Math.Min(minY, sceneInstance.Sprites[i].Y - sceneInstance.Sprites[i].Height / 2.0f);
      maxY = System.Math.Max(maxY, sceneInstance.Sprites[i].Y + sceneInstance.Sprites[i].Height / 2.0f);
    }
