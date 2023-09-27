## Introduction

This article explains how to change the animation of your character according to player input. This assumes that you are familiar with how to create Entities, use the FlatRedBall InputManager to read input, and how to add AnimationChains to Entities. This tutorial continues what is set up in the tutorial on [how to add animated characters](/frb/docs/index.php?title=Glue:How_To:Add_Animated_Characters "Glue:How To:Add Animated Characters").

## Adding a CurrentChainName variable

The first step is to create a CurrentChainName variable:

1.  Expand your Character Entity
2.  Right-click on Variables
3.  Select "Add Variable"
4.  Select "Tunnel a variable in a contained object"
5.  Select "Sprite" as your object (or whatever your Character's Sprite is named)
6.  Select "CurrentChainName" as the Variable
7.  Enter "ChainName" as the Alternative Name ![CurrentChainNameNewVariable.PNG](/media/migrated_media-CurrentChainNameNewVariable.PNG)

At this point you can set the default value of ChainName and you should be able to see your animations play in GlueView.

## Creating States

Next create states for each of the walking directions. To do this:

1.  Right-click on States and select "Add State Category". We will use categories to organize our states.
2.  Enter the name "Animation" for the new category and click OK
3.  Right-click on the new category and add a state called "WalkUp"
4.  Repeat the above step to also create "WalkDown", "WalkLeft", and "WalkRight"

Select each of the new States and set the ChainName variable to the appropriate value. ![SettingAnimationInStates.png](/media/migrated_media-SettingAnimationInStates.png)

**Why create states for AnimationChains?** You can also directly set your Sprite's CurrentChainName as follows in custom code:

    this.Sprite.CurrentChainName = "WalkLeft";

If this is possible why do we go through the trouble of creating states? There are two reasons:

1.  States result in the creation of enumerations. This means that you will have auto-complete to help you out when you do the actual implementation of code. This is a good verification that your code is working well, and will give you compile-time checks against errors.
2.  It provides a "layer of abstraction" between the logic and the actual content. This means that the artist will be free to make changes to the .achx and as long as these changes are also made in Glue, no code changes are needed.

## Setting states in code

You can set the animation in code by adding the following in the CustomActivity method inside Character.cs:

    const float WalkSpeed = 20;
    if (InputManager.Keyboard.KeyDown(Keys.Up))
    {
        this.CurrentAnimationState = Animation.WalkUp;
        this.XVelocity = 0;
        this.YVelocity = WalkSpeed;
    }
    else if (InputManager.Keyboard.KeyDown(Keys.Down))
    {
        this.CurrentAnimationState = Animation.WalkDown;
        this.XVelocity = 0;
        this.YVelocity = -WalkSpeed;
    }
    else if (InputManager.Keyboard.KeyDown(Keys.Left))
    {
        this.CurrentAnimationState = Animation.WalkLeft;
        this.XVelocity = -WalkSpeed;
        this.YVelocity = 0;
    }
    else if (InputManager.Keyboard.KeyDown(Keys.Right))
    {
        this.CurrentAnimationState = Animation.WalkRight;
        this.XVelocity = WalkSpeed;
        this.YVelocity = 0;
    }
    else 
    {
        this.XVelocity = 0;
        this.YVelocity = 0;
    }

![AnimatedCharacterInGame.PNG](/media/migrated_media-AnimatedCharacterInGame.PNG)

**Note:** If your Character appears really large, you may want to change your [camera settings](/frb/docs/index.php?title=Glue:Reference:Menu:Settings:Camera_Settings "Glue:Reference:Menu:Settings:Camera Settings") to be 2D.
