## Is a Screen different than a Scene (.scnx)?

Yes, Screens are different from Scenes, although Scenes are usually used when using Screens. Here are a few differences between the two which may clear things up.

-   [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene") (.scnx) are XML files which are created by the SpriteEditor tool (or other tool that can save to this format). A .scnx file can represent a level, a UI screen, a character, an object in a level, or some kind of template for positioning Sprites or other objects.Screens are code files (.cs in C#) which usually reference .scnx files, but don't necessarily have to.

&nbsp;

-   [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene") are used inside and outside of screens. One Screen may include multiple Scenes, or none at all.

&nbsp;

-   [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene") simply represent an assembly of Sprites, SpriteFrames, SpriteGrids, Text objects, and PositionedModels. Although there are many higher-level methods for loading Scenes and creating functional objects, they at their base level only represent a set of saved objects which can be manipulated in many ways. Screens are a higher-level object which handle asset creation, management, and destruction. Not only do they help manage assets, but can help organize your game and give you a headstart on creating menus.

&nbsp;

-   [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene") are a collection of instances of visible FRB objects. When a Scene is created, it doesn't do anything except just sit there.Screens include behavior in their Initialize and Activity methods which can control the state of the game and the properties of game entities.

&nbsp;

-   [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene.md "FlatRedBall.Scene") are classes which exist in FlatRedBall and are a core part of the engine. There are other classes in FlatRedBall which work directly with Scenes. Since Scenes are part of the engine, they are closed-source. Screens are a common way to format your content and logic. They are provided in the template and are open-source.
