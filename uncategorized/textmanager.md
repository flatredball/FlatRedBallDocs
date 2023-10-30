# textmanager

### Introduction

The TextManager is a static class which handles [Text](../frb/docs/index.php) object addition, removal, and common behavior. The TextManager has many of the same methods (in concept) as the [SpriteManager](../frb/docs/index.php). The TextManager is automatically instantiated by FlatRedBall so you do not need to create an instance yourself.

### Text Object

The TextManager provides numerous methods for for working with the [Text](../frb/docs/index.php) object. The following sections provide code samples for working with [Text](../frb/docs/index.php)-related methods.

### Text Addition

Most AddText methods both instantiate a new [Text](../frb/docs/index.php) object as well as add it to TextManager for management.

The following methods instantiate and add a [Text](../frb/docs/index.php) object to the SpriteManager:

```
Text text = TextManager.AddText("FlatRedBall Rocks!"); // uses default font
```

Custom [BitmapFonts](../frb/docs/index.php) can be used when creating [Text](../frb/docs/index.php) objects as well.

```
BitmapFont bitmapFont = new BitmapFont("textureFile.png", "fontFile.txt", "content manager name");
Text text = TextManager.AddText("Text with custom font", bitmapFont);
```

For information see the [BitmapFont wiki entry](../frb/docs/index.php).

**Adding Text and Layers**

[Text](../frb/docs/index.php) objects can also be added to [Layers](../frb/docs/index.php).

```
 // Layers must be created through the SpriteManager
 Layer layer = SpriteManager.AddLayer();

 Text text = TextManager.AddText("I'm on a layer.", layer);
```

For more information, see the [Layer wiki entry](../frb/docs/index.php) and the [AddToLayer method](../frb/docs/index.php).

### Text Removal

The RemoveText methods remove [Text](../frb/docs/index.php) objects from the engine as well as any [two-way](../frb/docs/index.php#Two_Way_Relationships) [AttachableLists](../frb/docs/index.php) (such as [PositionedObjectList](../frb/docs/index.php)) that the [Text](../frb/docs/index.php) object belong to. For more information, see the [RemoveText page](../frb/docs/index.php).

### TextManager Members

* [FlatRedBall.Graphics.TextManager.AddText](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.ConvertToAutomaticallyUpdated](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.FilterTexts](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.GetWidth](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.InsertNewLines](../frb/docs/index.php)
* [FlatRedBall.Graphics.TextManager.RemoveText](../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
