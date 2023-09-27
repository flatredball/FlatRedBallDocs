## Introduction

If you have never used the AddManualSprite method, then you have most likely worked with "automatically updated" [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). In fact, most objects which are added to managers are automatically updated, so the concept of whether something is updated or not may not have even been a consideration. While automatic updating or "management" is very convenient, it can also be inefficient - especially if situations with a large number of objects which do not need every-frame updates. One common example of unnecessary updating is when Sprites are used as "environment" such as tiles in a tile map. In these situations the Sprites are initially set, but after the initial positioning the Sprites will never move. Therefore, every-frame updates are unnecessary. In these situations manual [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") can be used to reduce the overhead of each instance. The AddManualSprite method creates a Sprite which will not have its update called automatically. While this improves performance, **any update(s) must be followed by a call to SpriteManager.ManualUpdate(spriteToUpdate). Without this call the changes will not be visible.**

## Code Example

The following code example shows a performance difference between manually and automatically updated [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). The performance numbers are recorded on a laptop which does not have a powerful graphics card. Therefore, computers with more powerful graphics cards may see more drastic changes in numbers between the two types of [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite")

Add the following using statement:

    using FlatRedBall.Graphics;

Add the following at class scope:

    Text text;

Do one of the following two:

Add the following to Initialize after initializing FlatRedBall to create a group of automatically updated Sprites:

     IsFixedTimeStep = false;
     graphics.SynchronizeWithVerticalRetrace = false;

     int numberOfSprites = 4000;
     for (int i = 0; i < numberOfSprites; i++)
     {
         // This will add automatically updated Sprites
         Sprite sprite = SpriteManager.AddSprite("redball.bmp");
         SpriteManager.Camera.PositionRandomlyInView(sprite, 45, 80);
     }

     text = TextManager.AddText("");

OR...

Add the following to Initialize after initializing FlatRedBall to create a group of manually updated Sprites:

     IsFixedTimeStep = false;
     graphics.SynchronizeWithVerticalRetrace = false;

     int numberOfSprites = 4000;
     for (int i = 0; i < numberOfSprites; i++)
     {
         Sprite sprite = SpriteManager.AddManualSprite("redball.bmp");
         SpriteManager.Camera.PositionRandomlyInView(sprite, 45, 80);
         // Since the Sprite has been "changed" by the 
         // PositionRandomlyInView, it must be updated
         SpriteManager.ManualUpdate(sprite);
     }

     text = TextManager.AddText("");

Add the following to Update to display frame time:

    text.DisplayText = TimeManager.SecondDifference.ToString();

Automatically Updated: ![AutomaticallyUpdatedSprites.png](/media/migrated_media-AutomaticallyUpdatedSprites.png) Manually Updated: ![ManuallyUpdatedSprites.png](/media/migrated_media-ManuallyUpdatedSprites.png)

## Related Articles

-   [FlatRedBall.SpriteManager.ConvertToManuallyUpdated](/frb/docs/index.php?title=FlatRedBall.SpriteManager.ConvertToManuallyUpdated "FlatRedBall.SpriteManager.ConvertToManuallyUpdated") - Can be used to convert an already-created object to be manually updated.
-   [Manually updated objects tutorial](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects "FlatRedballXna:Tutorials:Manually Updated Objects") - Discusses details of manually updated objects.
