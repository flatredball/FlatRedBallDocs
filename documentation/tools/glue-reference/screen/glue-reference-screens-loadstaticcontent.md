## Introduction

LoadStaticContent is a generated method which is automatically called when a Screen/Entity is created. By default this method does not ever need to be called manually; however it can be called manually to preload content. If an Entity is part of a Screen in Glue, then its LoadStaticContent is automatically called. If the Entity is either not part of the Screen, or if it is going to be created by custom code then the LoadStaticContent can be called in custom code to pre-load the content. LoadStaticContent internally calls [CustomLoadStaticContent](/frb/docs/index.php?title=Glue:Reference:Screens:CustomLoadStaticContent "Glue:Reference:Screens:CustomLoadStaticContent").

## When to call LoadStaticContent

As mentioned above, LoadStaticContent may be needed to load content that is owned by a Screen or Entity without instantiating the Screen/Entity. For example, you may need to display a sprite that shows what a character looks like in a menu screen, but instantiating and adding the character may be difficult because of dependencies. In this case you may be able to call LoadStaticContent, then access the files in the Entity. Keep in mind that LoadStaticContent loads content necessary to instantiate a Screen or Entity. Therefore whenever a Screen or Entity is instantiated, LoadStaticContent is called. Since this automatic calling is performed when an Entity is instantiated, your code typically does not need to call this method.

## Calling LoadStaticContent multiple times

LoadStaticContent can be called multiple times, and as long as the same **contentManagerName** is used, subsequent calls will not reload the content. For example:

    SpaceShip.LoadStaticContent(ContentManager); // <- Will load content, assuming this is the first time it's being called
    SpaceShip.LoadStaticContent(ContentManager); // <- Will not load any additional content, since ContentManager has already been used once
    SpaceShip.LoadStaticContent("OtherContentManager"); // <- Will load content. Content will be loaded twice, once in ContentManager, once in "OtherContentManager"

## contentManagerName argument

The contentManagerName argument specifies which content manager to use to load the content. The content manager is used to cache content so that subsequent calls to LoadStaticContent do not re-load any assets (unless the content manager is unloaded). Typically the argument should be the caller's content manager (if it is a Screen or Entity). For example, the following code would be used in a Screen to load content for an Entity called Character.

    static void CustomLoadStaticContent(string contentManagerName)
    {        
        Character.LoadStaticContent(contentManagerName);
        ...

## This type has been loaded with a global content manager, then loaded with a non-global. This can lead to a lot of bugs

Calling LoadStaticContent with a [global content manager](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.GlobalContentManager "FlatRedBall.FlatRedBallServices.GlobalContentManager") will load the Screen/Entity into the global content manager. This content will never be unloaded. If a Screen/Entity is loaded into a global content manager, then later into a non-global content manager, then generated code will throw an exception. The two reasons for this exception are:

1.  Loading in global content manager, then non-global results in two times as much memory being used for content. Since the global content is already in memory, there is no reason to use non-global content for a Screen/Entity that has used global content.
2.  Entities and Screens which do not use global content will set their file references to null after their respective content managers are unloaded. However, if entities use global content, then file references are not set to null. This conflict of behavior may result in global content being nulled-out, causing difficult-to-debug crashes in your game.
