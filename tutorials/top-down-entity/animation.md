# Animation

### Introduction

The FRB Editor provides built-in support for animations. Simple games can implement animation with no code. More complex games can customize the default animations both in the FRB Editor and code.

This guide explores animations for top-down entities.

### Default Implementation

If your game was created using the New Project Wizard then you should already have a Player entity that is fully animated.

We can see the animations used by the player by expanding the Player's Objects folder, selecting the SpriteInstance, and looking at its Animation Chains variable. Notice that this variable is set to the .achx file in its Files folder.

<figure><img src="../../.gitbook/assets/20_07 55 33.png" alt=""><figcaption><p>Player SpriteInstance with its Animation Chains variable assigned</p></figcaption></figure>

The SpriteInstance and .achx file in the Player entity are just like any other Sprite and .achx file - they an be modified as desired. This tutorial won't cover the details of modifying a .achx file. For more information on working with Animation Chains, see the [Animation Editor](../../glue-gluevault-component-pages-animationeditor-plugin/) page.

### Selecting Animations

If we run the game, the Player is animated - it displays idle and walk animations in each of the four directions.

<figure><img src="../../.gitbook/assets/20_08 00 56.gif" alt=""><figcaption><p>Animated Player</p></figcaption></figure>

We can view the setup for animations by selecting the Player Entity, clicking on Entity Input Movement, and selecting the Animation item.

<figure><img src="../../.gitbook/assets/20_08 31 09.png" alt=""><figcaption><p>Animations for the Player entity</p></figcaption></figure>

This section controls which animations are displayed on the Player's sprite.

Each row defines one set of animations, and the condition for when those animations play. Animations at the bottom of the list play if their condition evalutes to true. In other words, Idle animations always play unless the Walk conditions are satisfied.&#x20;

The next section covers each variable.

### Animation Name and Is Direction Facing Appended

Animation Name is the variable that determines which animation to play if the conditions in a given row are fulfilled. The Animation Name property uses a dropdown which lets you pick animations from the referenced .achx.

<figure><img src="../../.gitbook/assets/20_08 47 07.png" alt=""><figcaption><p>Dropdown for picking animation</p></figcaption></figure>

Notice that the names in this dropdown do not match the names in the referenced .achx.

<figure><img src="../../.gitbook/assets/20_08 48 20.png" alt=""><figcaption><p>Animation names for walking and idle</p></figcaption></figure>

If the Is Direction Facing Appended checkbox is checked, then FRB automatically assumes that animations will have Up, Down, Left, and Right versions, where the direction is appended. Therefore, FRB strips off these directions and only displays the animation name (removing duplicates).

This means that if you wanted to add additional animations to the .achx, or if you wanted to create a brand new .achx, every animation should have 4 versions, one for each direction. For example, you might add:

* AttackUp
* AttackDown
* AttackLeft
* AttackRight

### Notes

Notes have no impact at runtime. You can add any notes that might help in development.

### Min Velocity Absolute and Max Velocity Absolute

These values restrict when an animation can play depending on the player's current speed relative to the ground. If these values are null, then here are no velocity-based restrictions on when an animation can play.

Min Velocity Absolute can set the minimum speed for an animation to play. For example, by default the Player has a minimum velocity set for when the Walk animation plays.

<figure><img src="../../.gitbook/assets/image.png" alt=""><figcaption><p>Min Velocity Absolute set to 5, which means this animation only plays if moving faster than 5 pixels per second</p></figcaption></figure>

### Min Movement Input Absolute and Max Movement Input Absolute

These values specify min and max bounds for when to play the animation. These rely on the input for the character which has an absolute value of 0 - 1.

### Animation Speed Assignment

The Animation Speed Assignment is used to optionally set the animation speed based on input or velocity.

* ForceTo1 forces the animation speed to 1
* NoAssignment removes all assignment of animation speed so it can be modified in custom code
* BasedOnVelocityMultiplier multiplies the specified value by the current velocity. Usually the specified value is less than 1.0f.
* BasedOnMaxSpeedRatioMultiplier multiplies the ratio of the entity's speed (current speed / max speed) by the specified value. Usually the specified value is 1.0f.
* BasedOnInputMultiplier sets the animation speed based on movement input values which which are between 0 and 1.

