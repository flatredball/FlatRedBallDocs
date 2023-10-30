# 03-currentmovement

### Introduction

The CurrentMovement property controls the values used by the top down entity in response to input values. This value can be changed according to various conditions in your game such as:

* Collision with different terrain (such as walking through mud)
* Responding to power-ups (such as collecting a power-up which increases speed)
* Responding to special moves or input which changes the character's movement variables (such as holding down a run button)

### Defining Movement Values

Movement values can be defined in Glue or code. If your game has a limited set of movement values, these can be defined in Glue. To define a movement value in Glue:

1. Select the entity
2. Click the **Entity Input Movement** tab
3. Verify that your entity is using the **Top Down** option for **Input Movement Type**
4.  Click the **Add Control Values** button

    ![](../../../../media/2021-03-img_6044126bc1b1e.png)
5. Modify the newly-added movement values as necessary

The **Top Down** tab displays all movement values for the selected entity.

![](../../../../media/2020-10-img_5f9870a558060.png)

### Assigning Movement Values

You can assign the current movement values in code through the CurrentMovement propety. For example, the following code assigns the movement to FastMovement or Default depending on the state of an Xbox360GamePad:

```lang:c#
var gamepad = InputManager.Xbox360GamePads[0];
if(gamepad.ButtonDown(Xbox360GamePad.Button.B))
{
    this.CurrentMovement = TopDownValues[DataTypes.TopDownValues.FastMovement];
}
else
{
    this.CurrentMovement = TopDownValues[DataTypes.TopDownValues.Default];
}
```

&#x20;
