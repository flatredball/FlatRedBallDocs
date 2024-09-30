# Health Part 2

### Introduction

The last tutorial created a functional HealthBar and added it to the Player entity. This tutorial will add a Health variable to the Player entity and will update the HealthBar so it displays the health.

### Health Variable

First we'll define a Health variable that will keep track of how much health each Player has left. At this point you might expect that we will add the Health variable as a Glue variable in the Player Entity. However, the Health variable will be defined in the Player.cs code file rather than in Glue. Let's take a moment and discuss why this variable should not be a Glue variable.

#### When to create Glue variables

Variables belong in Glue if they are:

* Variables which are used as coefficients in code which will never change throughout the life of the project - such as the MovementSpeed on the BulletEntity
* Variables which are tunnel to variables on FlatRedBall types - such as the Score variable in the Hud Entity tunneling in to the DisplayText property on a Text object
* Variables which need to be modified in Glue States or Events - such as the Texture of the Sprite on the Rock Entity. Notice that this also falls under the category of being a variable tunneling to a FlatRedBall type variable.
* Variables which define the starting state of another variable. The "starting state variable" should not change; however, the variable that it sets may change after it is set.

Let's look at each condition and see how it relates to the Health variable:

* The Health variable is not a coefficient for logic. It will not be used to control the behavior of any game objects. Furthermore, the Health variable will change as the Player takes damage from rocks.
* The Health variable is a new variable which is not directly tied to any FlatRedBall type variable.
* We will not modify the Health variable through any states or events - it will only be modified when we detect collision.
* The Health value will need a starting value, however it will change throughout the life of the project. However, we will need a starting value for the Health variable.

### Creating StartingHealth

As indicated above, we will need a variable to define the starting value of the Health variable. To create this variable:

1. Select the **Player** entity
2. Click the **Variables** tab
3. Click the Add **New Variable** button
4. Set the **Type** to **int**
5. Enter the name **StartingHealth**
6. Click **OK**
7. Set the value of **StartingHealth** to 6

![](../../.gitbook/assets/2021-03-img\_604e1be1ebb24.png)

### Defining and setting Health

Now we can define the Health variable in the **Player.cs** file. To do this open Player.cs in Visual Studio and add the following code to the Player class:

```csharp
int health;
public int Health
{
    get
    {
        return health;
    }
    set
    {
        health = value;
        if(health <= 0)
        {
            Destroy();
        }
    }
}
```

Next we'll need to set the Health value to the StartingHealth value. To do this, add the following code in **CustomInitialize** in the Player.cs file:

```csharp
Health = StartingHealth;
```

### Modifying Health

Now we have a Health value which is functional - in other words it destroys the Player when it reaches 0. Next we'll modify the Health value when the Player collides with a Rock. To do this, open GameScreen.Event.cs and find the **OnPlayerListVsRockListCollisionOccurred** function. Locate the following line in the deepest if-statement:

```csharp
 player.Destroy();
```

Remove this line and replace it with:

```csharp
 player.Health--;
```

We'll also want to remove the following line:

```csharp
 rock.Destroy();
```

Replace it with:

```csharp
 rock.TakeHit(); // so the rock doesn't die completely.
```

You can also remove the comment about "Eventually we'll want to do something like..." If you now play the game you'll notice that when the Player collides with a Rock, the rock breaks apart. The Player also takes damage and if 6 rocks are collided with the Player is destroyed. Keep in mind that additional Rocks are created whenever a larger rock is destroyed, so the Player may actually collide with multiple Rocks and appear to be destroyed before 6 collisions have occurred.

### Updating the HealthBar

Now that we have a Health value we need to update the HealthBar according to the current Health value. To do this, modify the Player Health property as shown in the following code snippet:

```csharp
int health;
public int Health
{
 get
 {
  return health;
 }
 set
 {
  health = value;

  // Multiply the value by 100 so that full health is 100%
  HealthBarRuntimeInstance.PercentFull = 100 * Health / (float)StartingHealth;

  if (health <= 0)
  {
   Destroy();
  }
 }
}
```

If the Player takes damage now. the HealthBar updates to show how much health the player has left.

![](../../.gitbook/assets/2021-03-img\_604e2256cdb5a.png)

### Conclusion

Our game is becoming more and more playable with each tutorial; however, there is a severe bug present in our game - an accumulation bug occurring due to Entities being dynamically created and not destroyed. If you play the game and survive long enough you will see the frame rate slowly drop. Fortunately this problem is easy to solve. The next tutorial will show how to check for an accumulation of Entities and how to remove them.
