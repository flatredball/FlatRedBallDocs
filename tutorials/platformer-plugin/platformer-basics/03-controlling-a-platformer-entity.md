# Controlling a Platformer Entity

### Introduction

This tutorial covers how to read input to move a platformer entity. We will also be creating a level to test out our platformer entity. To create a level and collision, we will be using a Tiled level. For more information on working with Tiled, see the [Tiled](../../../tiled-plugin/) documentation.

Note - if you created your Platformer project using the wizard, feel free to skip this tutorial. This tutorial is only needed if you are manually creating your game.

### Adding a Collision Relationship

The previous tutorial created a GameScreen which contains two TileShapeCollections:

* SolidCollision
* CloudCollision

By default each is associated with a standard tile from the tileset included in our Level1Map.tmx. However, these collisons do not have any affect on our player since we haven't told the player to collide with them.

To set up collision between our PlayerList and SolidCollision:

1. Expand **GameScreen** Objects
2. Drag+drop the **PlayerList** onto the **SolidCollision** to create a relationship

<figure><img src="../../../.gitbook/assets/11_06 11 55.gif" alt=""><figcaption><p>Creating a Player vs SolidCollision CollisionRelationship</p></figcaption></figure>

Since our Player is marked as a Platformer entity, the FlatRedBall editor assumes that the PlayerVsSolidCollision relationship should use platformer physics. You can verify that this is the case by selecting the PlayerVsSolidCollision object and clicking on the Collision tab.

Now the player will collide with the level.

![PlayerVsSolidCollision using Platformer Solid Collision](<../../../.gitbook/assets/11\_06 13 50.png>)

### Controlling the Entity with Input

By default the platformer entity already supports a default set of controls. To see this, select the Player entity, then select the **Entity Input Movement** tab.

![Player uses Gamepad with Keyboard Fallback by default](<../../../.gitbook/assets/11\_06 15 36.png>)

By default the platformer will be controllable with a plugged-in Xbox Gamepad. If no Gamepad is detected, then the entity can be controlled with WASD and Space.

<figure><img src="../../../.gitbook/assets/11_06 17 12.gif" alt=""><figcaption><p>Player moving with the gamepad or keyboard</p></figcaption></figure>

Note - the animation above shows a game that is using the CameraControllingEntity to position the camera in the center of the map. If you are not using the CameraControllingEntity, then you can manually position the camera in your GameScreen by changing the `Camera.Main.X` and `Camera.Main.Y` variables in `CustomInitialize`. Also, note that the Player is inside of the map. You can modify the player's starting X and Y values either in code or by selecting the Player1 object in GameScreen and changing its X and Y values.

If you want to override which input is used to move the player, you can change the controls in code. For example, to change the character to jump with the Enter key and to move with the arrow keys:

1. Go to GameScreen.cs
2. Modify the CustomInitialize function to contain the following input assignment code:

```csharp
void CustomInitialize()
{

    Player1.JumpInput = InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.Enter);

    Player1.HorizontalInput = InputManager.Keyboard.Get1DInput(
        Microsoft.Xna.Framework.Input.Keys.Left, Microsoft.Xna.Framework.Input.Keys.Right);
}
```

The code above added keyboard controls so that the Player can be moved horizontally with the A and D keys and jumps using the space bar.

### Conclusion

Now our platformer character reacts to input and collides with the environment. We can change the environment by opening Level1Map at any time and painting new tiles. The next tutorial takes a deeper look at the control values.
