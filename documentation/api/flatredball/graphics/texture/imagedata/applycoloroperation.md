## Introduction

ApplyColorOperation is a method which can be used to modify an ImageData using the same ColorOperation and Red,Green,Blue values that are present in the [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable "FlatRedBall.Graphics.IColorable") interface which is implemented by common FlatRedball objects such as [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text"). ApplyColorOperation modifies the data stored in an ImageData permanently - it cannot be undone.

## Code Example

ApplyColorOperation can be used to modify a texture so that when rendered normally, it will appear the same as a Sprite with the same ColorOperation and Red/Green/Blue values. The following code shows a texture being rendered using a Modulate color operation:

     Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
     
     ImageData imageData = ImageData.FromTexture2D(texture);
     
     float red = 0;
     float green = .5f;
     float blue = .5f;
     float alpha = 1;
     
     imageData.ApplyColorOperation(ColorOperation.Modulate, red, green, blue, alpha);
     
     Texture2D modified = imageData.ToTexture2D();
     
     Sprite sprite = SpriteManager.AddSprite(modified);
     
     Sprite originalSprite = SpriteManager.AddSprite("redball.bmp");
     originalSprite.X = 2;
     
     SpriteManager.Camera.BackgroundColor = Color.White;

![ImageDataApplyColorOperation.png](/media/migrated_media-ImageDataApplyColorOperation.png)
