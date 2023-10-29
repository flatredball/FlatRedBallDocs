# setting-gum-animationchain-achx-in-code

### Introduction

Gum objects support playing .achx animations. This enables the use of the familiar AnimationEditor to create texture-based animations for Gum objects. Note that AnimationChain animations are used to change texture or texture coordinates. These are typically used for animated characters in 2D games. AnimationChain animations cannot change the size, orientation, or other common Gum properties.

### Note About Glue Version

Glue Version 12 introduces automatic calling of AnimateSelf on the top-level Gum screen. If your Glue project is using an earlier version than version 12, you will need to explicitly add the following to your CustomActivity:

```
GumScreen.AnimateSelf();
```

For more information on Glue versions, see the [gluj/glux page](../../glue-reference/glujglux.md).

### Setting Animations

For this example we will assume a Sprite named SpriteInstance.

![](../../media/2022-02-img\_621bdf9420500.png)

This Sprite is contained in a page named MainMenuGum which is assumed to be inside a FlatRedBall Screen named MainMenu.

![](../../media/2022-02-img\_621bdfc9e687d.png)

We can set the Sprite to be animated using the following code in CustomInitialize:

```
var gumSprite = GumScreen.SpriteInstance;

gumSprite.Animate = true;
gumSprite.CurrentChainName = "CharacterWalkRight";
// The SourceFile property is a Texture2D, but we can also set it to
// a file path which will resolve to an animation using the SetProperty method.
gumSprite.SetProperty("SourceFile", "../Screens/MainMenu/PlatformerAnimations.achx");
gumSprite.TextureAddress = Gum.Managers.TextureAddress.Custom;
```

The Gum Sprite now animates when running the game. [![](../../media/2022-02-27\_13-39-06.gif)](../../media/2022-02-27\_13-39-06.gif)
