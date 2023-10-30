# 02-input-device

### Introduction

This tutorial provides information on how to change the input device used by the entity. By default the entity uses the first Xbox game pad if one is available, otherwise the entity uses the keyboard. Sometimes this functionality is not desired, such as if the game supports multiple players or AI-controlled entities.

### IInputDevice

The Top Down entity code interacts with the IInputDevice interface, which provides a standard set of values for controlling game objects. Both the Xbox360GamePad and Keyboard implement this interface, so if the default implementation for this interface meets your game's needs, you can use these objects as-is. Otherwise, your game can implement its own IInputDevice to change how the top down entity is controlled. First we'll look at how to customize the input to use different keyboard keys.

### Changing Input Keys

As mentioned earlier, our Player entity defaults to using an Xbox gamepad if one exists. If not, it uses the keyboard. Even though we won't customize this code, we can see its implementation by looking in Player.Generated.cs and searching for InitializeInput.

![](../../../../media/2021-03-img\_6043fa97cd7aa.png)

Ultimately, these calls make their way to calling CustomInitializeTopDownInput. Since this is a partial method, we need to add it ourselves to our Player if we want to customize the input. To do this:

1. Go to **Player.cs**
2. Add the following code to the **Player.cs** file

&#x20;

```
partial void CustomInitializeTopDownInput()
{
 this.MovementInput = InputManager.Keyboard.Get2DInput(
    Microsoft.Xna.Framework.Input.Keys.J, // Key for left movement
    Microsoft.Xna.Framework.Input.Keys.L, // Key for right movement
    Microsoft.Xna.Framework.Input.Keys.I, // Key for up movement
    Microsoft.Xna.Framework.Input.Keys.K);// Key for down movement
}
```

The player will now move around with the IJKL keys (rather than the default WASD). Note that this will also override input even if you have an Xbox gamepad plugged in. If this is not desired, we can change the input if it's using the keyboard. This is an example of how to keep the input device, but only change the movement code conditionally:

```
partial void CustomInitializeTopDownInput()
{
 if(this.InputDevice is Keyboard keyboard)
 {
   this.MovementInput = keyboard.Get2DInput(
     Microsoft.Xna.Framework.Input.Keys.J, // Key for left movement
     Microsoft.Xna.Framework.Input.Keys.L, // Key for right movement
     Microsoft.Xna.Framework.Input.Keys.I, // Key for up movement
     Microsoft.Xna.Framework.Input.Keys.K);// Key for down movement
 }
}
```

This code could contain further updates to change desired input based on other input devices such as Xbox360GamePad.

### Changing Input Device

The code in the section above modifies which keys are used from the keyboard. It could be expanded to also handle other input devices like Xbox gamepads. However, instead of changing which keys are used when using the keyboard, you may want to change which input device is being used by your player. This is typically done in the GameScreen. This allows the GameScreen to initialize input, especially if your game allows the player to pick which input device to use. For example, to force the player to always use an Xbox gamepad, modify the following code in the GameScreen's **CustomInitialize**:

```
void CustomInitialize()
{
 // Forces the player to use the first Xbox gamepad:
 Player1.InitializeTopDownInput(InputManager.Xbox360GamePads[0]);
}
```

### Creating Multiple Players

If your game followed the previous tutorials, then your GameScreen has a PlayerList with a single Player named Player1. In this setup, the GameScreen will always have at least 1 player, but can have more. A quick way to support multiplayer without any UI is to detect the number of Xbox gamepads plugged in. If more than 1 is plugged in, we can create additional players very easily. The following code will create one player per Xbox gamepad plugged in. Notice that we only create additional players if we have two or more gamepads since the first player is automatically created.

```
void CustomInitialize()
{
 var connectedGamepads = InputManager.Xbox360GamePads
   .Where(item => item.IsConnected)
   .ToArray();

 for(int i = 0; i < connectedGamepads.Length; i++)
 {
   // By default the FlatRedBall project includes one instance of a player, so we don't
   // need to create one for index 0
   if(i > 1)
   {
     // create the player:
     var player = new Player();
     PlayerList.Add(player);
   }
   PlayerList[i].InitializeTopDownInput(connectedGamepads[i]);
 }
}
```

To see more than one player you must have at least two gamepads plugged in to your computer. Also, keep in mind that the players will initially overlap so you must move one to see both. 

<figure><img src="../../../../media/2020-09-2021\_March\_06\_163127.gif" alt=""><figcaption></figcaption></figure>

 &#x20;
