## Introduction

This walkthrough looks at the FlatRedBall Multiplayer Platformer project and explains the important details of creating a (local) multiplayer game similar to games like Contra III. \[embed\]https://youtu.be/YHfTVFZHj4E?t=85\[/embed\] The sample project can be downloaded from Github: <https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/MultiplayerPlatformerDemo> [![](/wp-content/uploads/2021/05/2021_April_30_161604.gif.md)](/wp-content/uploads/2021/05/2021_April_30_161604.gif.md) We will be referring to the MultiplayerPlatformerDemo as *this demo* and *the demo* throughout this walkthrough.

## Selecting and Storing Join Status

Local multiplayer games provide a variety of ways to join. Older games on the Super Nintendo assumed that if you selected two players, you would use the first and second controller without checking that the controllers were actually connected. More modern games, especially on the PC, check the connected status of controllers and allow players to join and leave. Joining and leaving can be performed on a dedicated page, or can be performed dynamically allowing players to join and leave mid-game. For simplicity, this demo only allows players to join and leave in a dedicated screen. Conceptually, the process for joining has the following steps:

1.  A page displays UI to tell the user which controllers are connected. Players can connect controllers and press buttons to join.
2.  The values for which players have joined must be stored somewhere which is accessible by both the GameScreen and the screen for joining/leaving. These values cannot be instance values on a screen.
3.  The GameScreen must inspect these values and create Player instances (using a Factory) for every joined player. The correct gamepad must be assigned.

We will take a deep dive into these concepts throughout this walkthrough.

## CharacterJoiningScreen

The demo includes a Screen called CharacterJoiningScreen. This screen does not inherit from the GameScreen - it is not a level. Rather, it is a screen which contains only Gum UI and logic.

![](/media/2021-04-img_608c8b75b6b3f.png)

It is marked as the startup screen to give players a chance to join/leave the game before starting Level1.

![](/media/2021-04-img_608c8b9a89076.png)

The CharacterJoiningScreen uses Gum and the MVVM pattern to make the UI update according to the join state stored in the ViewModel. The UI does not participate in the logic of the game - it only displays the values stored in the underlying view model objects. The state is stored in the CharacterJoiningScreen's ViewModel object.

    public partial class CharacterJoiningScreen
    {
        CharacterJoiningScreenViewModel ViewModel => CharacterJoiningScreenGum.BindingContext as
            CharacterJoiningScreenViewModel;

The code modifies this ViewModel in a few different places.

### Initialization

The ViewModel object is instantiated and assigned as the BidingContext to the Gum screen in CustomInitialize. Notice that we instantiate the ViewModel and assign it initially, but thereafter we use the ViewModel property. Once the ViewModel is instantiated and assigned as the Gum UI BindingContext, we can initialize it based on the connected state of the controllers and whether the player had already joined.

    for(int i = 0; i < ViewModel.IndividualJoinViewModels.Length; i++)
    {
        if(InputManager.Xbox360GamePads[i].IsConnected)
        {
            if(GameScreen.PlayerJoinStates[i] == GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.Joined)
            {
                ViewModel.IndividualJoinViewModels[i].JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.Joined;
            }
            else
            {
                ViewModel.IndividualJoinViewModels[i].JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.PluggedInNotJoined;
            }
        }
    }

Notice that if a controller is connected, we check the GameScreen.PlayerJoinStates to see if the player should be fully joined, or plugged in but not yet joined. This demo uses a static object in the GameScreen to store the joined status. Since the values are static, they are not reset when moving between screens. Larger games may store this information in a dedicated object such as a singleton which also stores profile information like inventory and experience points.

### Controller (GamePad) Connected/Disconnected

This screen needs to respond to Xbox360GamePads being connected and disconnected. The InputManager provides a **ControllerConnectionEvent** event which we can subscribe to in CustomInitialize:

    InputManager.ControllerConnectionEvent += HandleControllerConnectionEvent;

The HandleControllerConnectionEvent method checks if the Xbox360GamePad was connected or disconnected and sets the ViewModel values accordingly.

    private void HandleControllerConnectionEvent(object sender, InputManager.ControllerConnectionEventArgs e)
    {
        var individualVm = ViewModel.IndividualJoinViewModels[e.PlayerIndex];
        if (e.Connected)
        {
            if(individualVm.JoinState == GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.NotPluggedIn)
            {
                individualVm.JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.PluggedInNotJoined;
            }
        }
        else // disconnected
        {
            individualVm.JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.NotPluggedIn;
        }
    }

As mentioned earlier, Gum is bound to the view model, so changing these values automatically updates the Gum visuals. We won't discuss this in much depth in this guide.

### GamePad Activity

The demo checks each gamepad for button presses. The following buttons are considered:

-   A button - joins if the player isn't already joined
-   B button - unjoins if already joined
-   Start button - moves to Level1 if the Xbox360GamePad represents a player who has already joined

Buttons cannot be pushed on an Xbox360GamePad so we don't need to check the connected status when looping through the InputManager list.

    var gamepads = InputManager.Xbox360GamePads;

    for(int i = 0; i < gamepads.Length; i++)
    {
        var gamePad = gamepads[i];
        var viewModel = ViewModel.IndividualJoinViewModels[i];
        if (gamePad.ButtonPushed(Xbox360GamePad.Button.A))
        {
            if(viewModel.JoinState == GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.PluggedInNotJoined)
            {
                viewModel.JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.Joined;
            }
        }
        if(gamePad.ButtonPushed(Xbox360GamePad.Button.B))
        {
            if (viewModel.JoinState == GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.Joined)
            {
                viewModel.JoinState = GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.PluggedInNotJoined;
            }
        }
        if(gamePad.ButtonPushed(Xbox360GamePad.Button.Start))
        {
            if(viewModel.JoinState == GumRuntimes.IndividualJoinComponentRuntime.JoinCategory.Joined)
            {
                StartLevel();
            }
        }
    }

## Storing Joined Values

As mentioned earlier, the values must be stored in variables which are not instance variables in any of the screens (either CharacterJoiningScreen or GameScreen). Instead, these values are stored as static values in the GameScreen.

    public static IndividualJoinComponentRuntime.JoinCategory[] PlayerJoinStates
    { 
        get; 
        private set; 
    } = new IndividualJoinComponentRuntime.JoinCategory[4];

These values are used to instantiate players in the GameScreen's CustomInitialize:

    for(int i = 0; i < PlayerJoinStates.Length; i++)
    {
        if(PlayerJoinStates[i] == IndividualJoinComponentRuntime.JoinCategory.Joined)
        {
            var player = Factories.PlayerFactory.CreateNew(160 + 16 * i, -260);
            player.SetIndex(i);
            player.InitializePlatformerInput(InputManager.Xbox360GamePads[i]);
        }
    }

This for loop in CustomInitialize is solely responsible for creating Players. Notice that the GameScreen does not automatically create any Player instances through Glue.

![](/media/2021-04-img_608c959c738b7.png)

Therefore, if the PlayerJoinStates are not assigned, then the game will begin without any Players. The CharacterJoiningScreen is responsible for assigning these values, and it does so right before moving into a level.

    private void StartLevel()
    {
        for(int i = 0; i < ViewModel.IndividualJoinViewModels.Length; i++)
        {
            GameScreen.PlayerJoinStates[i] = ViewModel.IndividualJoinViewModels[i].JoinState;
        }

        MoveToScreen(typeof(Level1));
    }

If using the Glue Wizard, then the PlayerList will automatically have a collision relationship set up between the PlayerList and SolidCollision. We recommend always creating collision relationships with lists rather than individual objects (such as Player1) so that moving to a multiplayer game is easy.

![](/media/2021-04-img_608c9681075b9.png)

If your game includes more collision relationships, you will want to make sure that they always include the PlayerList.

## Assigning Player Index

Each player in the demo can be controlled by a separate Xbox360GamePad and is colored uniquely based on player index. Since FlatRedBall only supports four Xbox360GamePad instances, the demo is coded to handle up to four players. The game pad and index are assigned in the GameScreen's CustomInitialize method where each Player is assigned. The following snippet shows just the creation of the players inside the loop:

    var player = Factories.PlayerFactory.CreateNew(160 + 16 * i, -260);
    player.SetIndex(i);
    player.InitializePlatformerInput(InputManager.Xbox360GamePads[i]);

The SetIndex method notifies the player of their index. In a full game the player's index could be used for many reasons such as separate score display, game stats, and experience point awarding. This game is simpler so it only changes which AnimationChain is used, resulting in each player being drawn as a different color.

    public void SetIndex(int index)
    {
        switch(index)
        {
            case 0:
                SpriteInstance.AnimationChains = PlatformerAnimations;
                break;
            case 1:
                SpriteInstance.AnimationChains = p2animations;
                break;
            case 2:
                SpriteInstance.AnimationChains = p3animations;
                break;
            case 3:
                SpriteInstance.AnimationChains = p4animations;
                break;
        }
    }

We also call InitializePlatformerInput which is a method provided automatically by the Player's generated code since it is marked as a Platformer character. This method assigns the input device which tells the Player which input device to read for platformer movement. It also results in the Player's CustomInitializeInputDevice method being called, where the run button is assigned.

    partial void CustomInitializePlatformerInput()
    {
        if(InputDevice is Keyboard asKeyboard)
        {
            RunInput = asKeyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.R);
        }
        else if(InputDevice is Xbox360GamePad asGamepad)
        {
            RunInput = asGamepad.GetButton(Xbox360GamePad.Button.X);
        }
    }

### Animation Naming

The Player code includes an AnimationController which sets the current animation based on input and collision state. This code assigns names like CharacterWalkLeft and CharacterJumpRight, but it does not consider whether the Player is index 0, 1, 2, or 3. This code applies regardless of index because each of the animations have the same names. This approach is a common way to reduce code when displaying multiple player indexes or enemy types. Once a standard set of animations has been decided upon, the code can be written against this common set and it will work regardless of the .achx file used.

![](/media/2021-05-img_608c9bd1c64bb.png)

## Conclusion

This walkthrough has shown how a typical FlatRedBall multiplayer game is created, including setting whether a player has joined, using this value to create players, and assigning input device and animations according to player index.    
