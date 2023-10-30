# 05-double-jump

### Introduction

The default set of values do not include support for double jump, but these can be added in Glue with no additional code needed. This tutorial explores how to add double jump to a platformer character.

### Double Jump Variables

Double jumping is a feature in many platforms which gives the player more control over player movement. Players can use double jumping to remain in the air for a longer period of time, to reach areas higher than possible with a single jump, and improve horizontal movement precision. Entities which support double jumping require two sets of values - the movement values before double jump and the movement values to apply after double jump. Platformer entities automatically receive a platformer values called **Air** which are the **before double jump** variables, so we need to create a new set of values. To do this:

1. Expand the drop-down next to the **Add Control Values** button
2.  Select **Default Air Control** option

    ![](../../../../media/2021-03-img\_605785f3a0714.png)
3.  Change the name of the new values to **AfterDoubleJump**

    ![](../../../../media/2021-03-img\_60578788d5cb5.png)

### Changing Values

Now that we have a set of values for after double jump, we need to tell our game to use these new values for double jump:

1. Select the platformer entity
2. Click the Variables tab
3.  Change the **After Double Jump** value dropdown to the name of the new set of values we just created (**AfterDoubleJump**)

    ![](../../../../media/2021-03-img\_6057905aea13f.png)

Finally we need to change the **Jump Speed** value on the **Air** movement values to be greater than zero. This is the velocity which will be applied when performing a double jump.

![](../../../../media/2021-03-img\_605790f178ded.png)

Now the entity supports double jumping. 

<figure><img src="../../../../media/2021-03-2021\_March\_21\_123132.gif" alt=""><figcaption></figcaption></figure>



### Infinite Double Jumps

We can also support infinite double jumps by either setting the AfterDoubleJump Jump Speed value to greater than zero, or by setting the AfterDoubleJump variable to be Air. This results in the character being able to jump indefinitely which can be useful if implementing swimming or abilities like the flying racoon power-up in Super Mario Bros 3. 

<figure><img src="../../../../media/2021-03-2021\_March\_21\_122535.gif" alt=""><figcaption></figcaption></figure>

   &#x20;
