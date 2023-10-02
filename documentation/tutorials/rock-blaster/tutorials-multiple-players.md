# tutorials-multiple-players

### Introduction

This tutorial will cover how to add multiple players to the GameScreen. Fortunately we have programmed almost everything to support multiple MainShips from the beginning, so this tutorial will not require too much work.

### Detecting number of players

Most games include two requirements for a new player to join the game:

1. A controller must be connected for the player
2. The player must perform some action (such as pressing a button in a join screen)

To keep the tutorial shorter than it would otherwise be, we will assume that if a controller is connected, then the player intends to play. If you are developing a game which you intend to distribute to others, you should consider giving the player more freedom such as being able to drop out of a game and to require explicit action to join.

### Adding additional players

To add additional players we will detect how many controllers are connected, and create additional players as necessary. To do this:

1. Open GameScreen.cs in Visual Studio
2. Find the **CustomInitialize** function
3. Modify this function as shown in the following code snippet:

&#x20;

```
void CustomInitialize()
{
 this.TextInstance.Text = "0";
 AddAdditionalShips();
}
```

Next we'll need to implement AddAdditionalShips. Add the following function to GameScreen.cs:

```
private void AddAdditionalShips()
{
 // We assume that the first player (player at index 0) 
 // is already part of the game. Let's start with index 1:
 for (int i = 1; i < InputManager.Xbox360GamePads.Length; i++)
 {
  var gamePad = InputManager.Xbox360GamePads[i];
  if (gamepad.IsConnected)
  {
   var player = new Player();
   player.SetPlayerIndex(i);
   player.TurningInput = gamepad.LeftStick.Horizontal;
   player.ShootingInput = gamepad.GetButton(Xbox360GamePad.Button.A);
   PlayerList.Add(player);
  }
 }

 const float spacingBetweenPlayers = 60;
 const float startingX = -90;
 // Reposition all players
 for (int i = 0; i < PlayerList.Count; i++)
 {
  PlayerList[i].X = -startingX + i * spacingBetweenPlayers;
 }
}
```

Now that we're calling SetPlayerIndex, we'll need to make a public function for it

1. Open Player.cs in Visual Studio
2. Add the following to Player.cs:

&#x20;

```
public void SetPlayerIndex(int index)
{
 switch (index)
 {
  case 0:
   this.SpriteInstance.Texture = MainShip1;
   break;
  case 1:
   this.SpriteInstance.Texture = MainShip2;
   break;
  case 2:
   this.SpriteInstance.Texture = MainShip3;
   break;
  case 3:
   this.SpriteInstance.Texture = MainShip4;
   break;
 }
}
```

![RockBlasterDifferentShipTextures.png](../../../media/migrated\_media-RockBlasterDifferentShipTextures.png)

### Conclusion

Now each ship will use a different texture so that players will be able to tell each other apart. The next tutorial will improve on the way player death is handled by adding the concept of player health and a health bar. [<- 09. Hud](tutorials-hud.md) -- [11. Health ->](tutorials-health.md)
