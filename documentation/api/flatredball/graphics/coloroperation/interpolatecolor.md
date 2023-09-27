## Introduction

The InterpolateColor ColorOperation can be used to blend a Sprite to a particular color. The Alpha value on the IColorable is used to perform the blending, so IColorables which use the InterpolateColor ColorOperation must rely on only their texture for transparency.

## Code Example

    Camera.Main.UsePixelCoordinates();

    for (int i = 0; i < 10; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("Content/Bear.png");
        sprite.TextureScale = 1;
        sprite.X = -200 + 40 * i;

        sprite.ColorOperation = ColorOperation.InterpolateColor;
        sprite.Red = 1;
        sprite.Green = 0;
        sprite.Blue = 0;
        // The maximum value for 'i' in this loop is 9, so let's make that full alpha 
        sprite.Alpha = i / 9.0f;
    }

![InterpolateColorOperation.PNG](/media/migrated_media-InterpolateColorOperation.PNG)
