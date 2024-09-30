# Double Jump

### Introduction

This tutorial explores how to add double jump to a platformer character. It covers how to add an extra jump (double jump), infinite jumping, or a limited number of jumps in the air.

### Double Jump Variables

Double jumping is a feature in many platforms which gives the player more control over player movement. Players can use double jumping to remain in the air for a longer period of time, to reach areas higher than possible with a single jump, and improve horizontal movement precision. Entities which support double jumping require two sets of values - the movement values before double jump and the movement values to apply after double jump. Platformer entities automatically receive a platformer values called **Air** which are the **before double jump** variables, so we need to create a new set of values. To do this:

1. Select your platformer entity (Player)
2. Expand the drop-down next to the **Add Movement Type** button
3.  Select **Default Air Control** option

    ![Default Air Control button adds a new set of movement values for air movement](<../../../.gitbook/assets/01\_06 30 57.png>)
4.  Change the name of the new values to **AfterDoubleJump**

    ![Set the Movement Type name to AfterDoubleJump](../../../.gitbook/assets/2021-03-img\_60578788d5cb5.png)

### Changing Values

Now that we have a set of values for after double jump, we need to tell our game to use these new values for double jump:

1. Select the platformer entity
2. Click the Variables tab
3.  Change the **After Double Jump** value dropdown to the name of the new set of values we just created (**AfterDoubleJump**)

    ![Use AfterDoubleJump for the After Double Jump variable](<../../../.gitbook/assets/01\_06 36 55.png>)

Finally we need to change the **Jump Speed** value on the **Air** movement values to be greater than zero. This is the velocity which will be applied when performing a double jump.

![Set the Air Jump Speed to a value larger than 0 to enable double jumping](<../../../.gitbook/assets/01\_06 40 55.png>)

Now the platformer entity (Player) supports double jumping.

<figure><img src="../../../.gitbook/assets/01_06 41 44.gif" alt=""><figcaption><p>The player performign double jumps</p></figcaption></figure>

### Infinite Double Jumps

We can also support infinite double jumps by either setting the AfterDoubleJump Jump Speed value to greater than zero, or by setting the AfterDoubleJump variable to be Air. This results in the character being able to jump indefinitely which can be useful if implementing swimming or abilities like the flying racoon power-up in Super Mario Bros 3.

<figure><img src="../../../.gitbook/assets/2021-03-2021_March_21_122535.gif" alt=""><figcaption><p>Infinite double jump allows the player to tap the button to fly</p></figcaption></figure>

### Limiting Jump Count

As shown above, the platformer entity can support a single double jump by making the **AfterDoubleJump** variables have a **Jump Speed** of 0. By increasing the **Jump Speed** to greater than 0, then the platformer entity can jump infinitely similar to flying or swimming. It is also possible to limit the number of jumps, but this requires custom code.

For this example we will use the two movement types from the previous sections: **Air** and **AfterDoubleJump**. To limit the number of jumps, make sure that **AfterDoubleJump** has a **Jump Speed** value of 0.

Next we will conditionally assign the Air value in code `AirMovement` value in code according to the number of jumps the player has performed since touching the ground.

To do so, open your platformer entity's code file (Player.cs) and modify the code as shown in the following snippet:

```csharp
public partial class Player
{
    int currentNumberOfJumps = 0;

    private void CustomInitialize()
    {
        this.JumpAction += HandleJump;
    }

    private void HandleJump()
    {
        currentNumberOfJumps++;

        if(currentNumberOfJumps < 5)
        {
            // Assign air, which allows continual jumps
            AfterDoubleJump = PlatformerValuesStatic["Air"];
        }
        else
        {
            // assign AfterDoubleJump, which has a Jump Velocity of 0 so 
            // the player can't jump again
            AfterDoubleJump = PlatformerValuesStatic["AfterDoubleJump"];
        }
    }

    private void CustomActivity()
    {
        if(IsOnGround)
        {
            currentNumberOfJumps = 0;
        }

        FlatRedBall.Debugging.Debugger.Write($"Current number of jumps: {currentNumberOfJumps}");
    }

    private void CustomDestroy()
    {
    }

    private static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}

```

Now our platformer entity can jump 5 times, as controlled by a variable in HandleJump.

<figure><img src="../../../.gitbook/assets/01_07 19 33.gif" alt=""><figcaption><p>Player jumping with a limited (5) number of jumps</p></figcaption></figure>
