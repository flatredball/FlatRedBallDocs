# 03-creating-animationlayers

### Introduction

Platformer games (such as Super Mario World) include animated characters which play animations in response to input, physics, and collision with the environment. For example, a game like Super Mario World includes a number of animations:

* Idle
* Walk
* Run
* Jump
* Duck
* Look up
* Skid (Trying to turn around when running)

Each of these animations is played in response to logic determining which should play. We can think of each of these animations as having different _priority_ relative to other animations. For example, if the player is pushing the Up direction in Super Mario World, Mario looks upward. This animation has priority over the Idle animation, which plays if the Up is not held. Similarly, the Run animation is played if the player is moving faster than a certain speed, is on the ground, and is holding the run button. If this condition fails, then other animations (such as Walk) perform their logic. The logic to set animations can be performed through standard logic, but FlatRedBall offers a standard animation solution through the [AnimationController](../../../../api/flatredball/graphics/animation/animationcontroller.md) class. This tutorial explores AnimationLayers and [AnimationController](../../../../api/flatredball/graphics/animation/animationcontroller.md) which are used to update the Player animations.

###

### Default Implementation

By default our Player already has an AnimationController. It doesn't appear in the Player object in the FlatRedBall Editor, but it is generated automatically based on the default settings on the Player. AnimationControllers (both in code and in the FlatRedBall Editor) are containers for AnimationLayers. Each AnimationLayer typically maps to a single animation (or two animations - a left and right facing version). By default, our player has animations for idle, walk, fall (in air, moving downward), and jump (in air, moving upward). We can see these layers by selecting the Player, clicking on the **Entity Input Movement** tab, and selecting the **Animation**

![](../../../../media/2023-02-img_63e26f184ed36.png)

Each animation layer plays if its conditions evaluate to true and if the animations below it evaluate to false. Another way to think about this is, entries further down can "overwrite" the current animation if they evaluate to true, with the bottom-most getting the highest priority if it evaluates to true.

### Modifying Animation Layers

Each animation layer defines which animation is played, conditions for playing, and animation speed to play. For example, the CharacterWalk animation plays only if the player has a greater velocity than 1 and if all other animations (CharacterFall and CharacterJump) fail to play.

![](../../../../media/2023-02-img_63e26fe527a06.png)

If we change the Min X Velocity Absolute, we can modify the behavior of the player. For example, if we change the value to 140, the player will only play the walk animation if walking faster than 140 units per second. 

<figure><img src="../../../../media/2021-03-07_08-43-26.gif" alt=""><figcaption></figcaption></figure>

 While this specific example may not be a practical change to the game, it shows how the logic controls whether an animation is played, and how that logic can cascade up through the layers. The following conditions can be used to control whether an animation plays:

* Min X Velocity Absolute - this is the minimum speed that the player must be moving to play the animation. For example, we set the minimum speed to 140 for the CharacterWalk animation, which means the character will only walk if moving faster than 140 units per second. Note that this is _Absolute_ which means the character must be moving either greater than 140 pixels  (to the right) or less than -140 pixels (to the left).
* Max X Velocity Absolute - this is the maximum speed that the player can move to play the animation. For example, setting the maximum speed to 200 means that if the player is moving faster than 200 units (absolute), then the animation will not play.
*   Min Y Velocity - the minimum Y velocity (vertical movement) the player must have to play the animation. For example our player has CharacterJump animation which plays only if the velocity is greater than 0.

    ![](../../../../media/2023-02-img_63e272ccc6ca9.png)
* Max Y Velocity - the maximum Y Velocity (vertical movement) that the player can move to play the animation. If the player is moving faster than this value upward, then animation will no longer play.
* Movement Type - this option restricts an animation to whether the player is on the ground, air, or either. For example, this can be used to restrict animations to only play when in the air, such as the CharacterFall and CharacterJump animations.
*   Movement Name - this option restricts an animation to only play when a particular set of Movement Values are active. This is a dropdown which contains all of the movement values defined in the **Movement Values** section. This is especially effective if you have logic which is already setting the Movement Values in code - such as allowing a user to run when the run button is held.

    ![](../../../../media/2023-02-img_63e2746de5bba.png)
* Custom Condition - This allows the entry of code (such as a bool variable name) to be checked for whether an animation should be played. See the section below for more information on this property.

### Custom Condition

The Custom Condition property is the most flexible solution for setting animations. Typically this is used in combination with a bool field or property in the Player object. For example, the Player may have an IsTired property which would return true if the Player's health is below 10% of the max.

```
public bool IsTired => CurrentHealth / MaxHealth <= .1m;
```

This can be used by the animation layer by entering the **IsTired** variable in the **Custom Condition** text box.

![](../../../../media/2023-02-img_63e2762263a37.png)

This produces generated code which checked IsTired in code. The text entered in Custom Condition is directly copied over so you can add any text there which evaluates to true, although the recommended approach is to encapsulate any logic in a property (as shown above) which is then referenced.

### Animation Name

The Player contains an .achx file (Animation Chain List XML) which defines all available animations for the Player. ![](../../../../media/2023-02-img_63e2772a7e27e.png) This file can be opened in the Animation Editor to view all animations. To open this file, either:

* Double-click the .achx file. The FlatRedBall Editor uses the Windows file association for .achx --or--
* Go to the \<unzipped FRBDK location>/FRBDK/Xna 4 Tools/AnimationEditor/AnimationEditor.exe

![](../../../../media/2023-02-img_63e277bb4069f.png)

Notice that this .achx file happens to include animations which are not used by the Player - that's okay because not all animations must be used, and a single file can be shared by multiple entities. The FlatRedBall Editor scans this file and provides these animations in the dropdown.

![](../../../../media/2023-02-img_63e279776e780.png)

Note that the .achx file contains "Left" and "Right" versions of character animations, but the FlatRedBall Editor only provides the names without Left/Right suffixes. This keeps the Animation Name dropdown smaller and makes it easier to read. This naming convention is encouraged for character animations, and if the **Has Left and Right** checkbox is checked, then only animations with Left and Right suffixes appear in the dropdown. If animations do not have left and right options, then this option can be unchecked. Then the full name of all animations show up in the dropdown.

![](../../../../media/2023-02-img_63e27bf1a89fb.png)

### Animation Speed

The Animation Speed Assignment dropdown provides the animation speed assignment logic. By default, all animations use the ForceTo1 speed, which means the animation plays at the normal speed as defined in the .achx. This dropdown provides a number of options:

* ForceTo1 - the Sprite's AnimationSpeed will be forcefully set to 1, so the animation will play at the same speed as defined in the .achx
* NoAssignment - the Sprite's AnimationSpeed is left untouched. Previous assignments on the AnimationSpeed (either in custom code or through other animation layers) will remain on the Sprite.
* BasedOnVelocityMultiplier - if values are specified, then the **Absolute X Velocity Animation Speed Multiplier** or **Absolute Y Velocity Animation Speed Multiplier** values are multiplied by the Player's runtime velocity to determine the speed. For example, if the X Velocity multiplier is set to .1, then the animation speed plays at full speed if the Player is moving at 10 units per second, and plays at 10 times the speed if the Player is moving at 100 Units per second.
* BasedOnMaxSpeedRatioMultiplier - if these values are specified, the animation speed will be specified based on the speed of the Player relative to the max speed of the current movement value. For example, the Max Speed on the ground is set to 160 units on the Player. If the MaxSpeedXRatioMultiplier value is set to 1, then the animation plays at full speed when the player moves at max speed. If the MaxSpeedXRatioMultiplier is set to 2, then the animation plays at twice full speed when the player moves at max speed.

For example, the CharacterWalk animation can be set to use **BasedOnMaxSpeedRatioMultiplier** with a **Max Speed X Ratio Mutiplier** of 2. This results in the walk animation playing faster based on the movement speed of the player. 

<figure><img src="../../../../media/2021-03-07_09-55-20.gif" alt=""><figcaption></figcaption></figure>



### Creating New Animation Layers

Animation layers can be added in the FlatRedBall Editor. New animations layers can be added through the Add button at the bottom of the animation list.

![](../../../../media/2023-02-img_63e283b2c849d.png)

Also, existing animations can be copied with the copy button.

![](../../../../media/2023-02-img_63e283d21f873.png)

### Conclusion

This guide covers all of the options available when defining animation layers. The next tutorial covers changing the platformer movement values.
