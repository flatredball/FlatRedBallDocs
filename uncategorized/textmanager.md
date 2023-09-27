## Introduction

The TextManager is a static class which handles [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object addition, removal, and common behavior. The TextManager has many of the same methods (in concept) as the [SpriteManager](/frb/docs/index.php?title=FlatRedBall.SpriteManager "FlatRedBall.SpriteManager"). The TextManager is automatically instantiated by FlatRedBall so you do not need to create an instance yourself.

## Text Object

The TextManager provides numerous methods for for working with the [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object. The following sections provide code samples for working with [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text")-related methods.

## Text Addition

Most AddText methods both instantiate a new [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object as well as add it to TextManager for management.

The following methods instantiate and add a [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object to the SpriteManager:

    Text text = TextManager.AddText("FlatRedBall Rocks!"); // uses default font

Custom [BitmapFonts](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont "FlatRedBall.Graphics.BitmapFont") can be used when creating [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") objects as well.

    BitmapFont bitmapFont = new BitmapFont("textureFile.png", "fontFile.txt", "content manager name");
    Text text = TextManager.AddText("Text with custom font", bitmapFont);

For information see the [BitmapFont wiki entry](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont "FlatRedBall.Graphics.BitmapFont").

#### Adding Text and Layers

[Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") objects can also be added to [Layers](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer").

     // Layers must be created through the SpriteManager
     Layer layer = SpriteManager.AddLayer();

     Text text = TextManager.AddText("I'm on a layer.", layer);

For more information, see the [Layer wiki entry](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer") and the [AddToLayer method](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.AddToLayer "FlatRedBall.Graphics.TextManager.AddToLayer").

## Text Removal

The RemoveText methods remove [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") objects from the engine as well as any [two-way](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList#Two_Way_Relationships "FlatRedBall.Math.AttachableList") [AttachableLists](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList "FlatRedBall.Math.AttachableList") (such as [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList")) that the [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object belong to. For more information, see the [RemoveText page](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.RemoveText "FlatRedBall.Graphics.TextManager.RemoveText").

## TextManager Members

-   [FlatRedBall.Graphics.TextManager.AddText](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.AddText "FlatRedBall.Graphics.TextManager.AddText")
-   [FlatRedBall.Graphics.TextManager.ConvertToAutomaticallyUpdated](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.ConvertToAutomaticallyUpdated&action=edit&redlink=1 "FlatRedBall.Graphics.TextManager.ConvertToAutomaticallyUpdated (page does not exist)")
-   [FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated&action=edit&redlink=1 "FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated (page does not exist)")
-   [FlatRedBall.Graphics.TextManager.FilterTexts](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.FilterTexts "FlatRedBall.Graphics.TextManager.FilterTexts")
-   [FlatRedBall.Graphics.TextManager.GetWidth](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.GetWidth "FlatRedBall.Graphics.TextManager.GetWidth")
-   [FlatRedBall.Graphics.TextManager.InsertNewLines](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.InsertNewLines&action=edit&redlink=1 "FlatRedBall.Graphics.TextManager.InsertNewLines (page does not exist)")
-   [FlatRedBall.Graphics.TextManager.RemoveText](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.RemoveText "FlatRedBall.Graphics.TextManager.RemoveText")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
