## Introduction

This walkthrough looks at the FlatRedBall DialogBoxDemo project and explains important details of implementing a dialog box in response to talking to NPCs. Platformers may include dialog boxes to display conversations between characters either as part of a cutscene (such as in Mega Man X) or in response to player input (such as in Castlevania 2). \[embed\]https://youtu.be/wd2NqblSmIY?t=326\[/embed\] The sample project can be downloaded from Github: <https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/DialogBoxDemo> [![](/wp-content/uploads/2021/05/2021_May_01_160053.gif.md)](/wp-content/uploads/2021/05/2021_May_01_160053.gif.md) This walkthrough will refer to the DialogBoxDemo as *this demo* and *the demo*.

## Main Concepts

This demo includes a number of important concepts which combine to create NPCs which the player can talk to using a talk button (X on the Xbox360 GamePad) to display unique dialog.

-   Dialog is dialog as defined in a CSV file. This file could also be used to support multiple languages, but this demo only includes English.
-   NPCs are placed in the Level1Map file through Tiled. NPCs can be moved and their dialog can change by making changes in Level1Map.
-   The DialogBox object from FlatRedBall Forms is used to display dialog. It is displayed in response to collision (player talk collision vs NPC) and button presses.

## CSV Dialog

A typical game which supports NPC dialog may have hundreds or even thousands of pages of dialog. While it is possible to write the dialog directly into the C# code, maintaining this dialog can be very difficult. This is especially true if the game is being developed with a dedicated writing team, or if the game supports multiple languages. To address both of these considerations, FlatRedBall provides a standard way to store and access dialog. The demo includes a CSV file called LocalizationDatabase.csv which contains all dialog. This is added to **Global Content Files** so that the dialog can be accessed throughout the entire project, and it is marked as IsDatabaseForLocalizing.

![](/media/2021-05-img_608efd44ac48e.png)

For detailed information about how to create a localization database, see the [IsDatabaseForLocalizing page](/documentation/tools/glue-reference/files/glue-reference-files-isdatabaseforlocalizing/.md). The LocalizationDatabase.csv file includes two columns. The leftmost column is the string ID - this is how code accesses the text in the CSV. The second column is the text for the string ID in English (as the column name indicates).

![](/media/2021-05-img_608efdd6b78eb.png)

Additional columns can be added for games which support multiple languages. Similarly, additional rows can be added to support more NPCs. We separate each page of text with a newline. The English text for T_Npc2 and T_Npc3 both have two pages. Even if the game includes a single language, it must be told whether to display this language or whether it should display the string IDs. This is done in the initialization for GameScreen. A game with more screens may set the CurrentLanguage property in the first screen which is shown (such as a splash screen) or even in Game1. Also, if the game supports multiple languages, this property would change if the user changes the current language in a settings page.

    void CustomInitialize()
    {
        LocalizationManager.CurrentLanguage = 1;
        Map.Z = -3; 
    }

Notice that the first column (Id) is index 0, so English is index 1. The text contained in this file is accessed through the **LocalizationManager.Translate** method whenever we display dialog boxes. We will return to this code later in the walkthrough to examine how the DialogBox works, but for now we'll highlight the call to Translate in **GameScreen.Event.cs ShowDialogBox**.

    private async Task ShowDialogBox(IInputDevice inputDevice, string stringId)
    {
        currentDialogBox = new DialogBox();
        currentDialogBox.IsFocused = true;
        var pages = LocalizationManager.Translate(stringId).Split('\n');

        var asGamepad = inputDevice as Xbox360GamePad;

        // Prevents the push that brought this up from advancing the first dialog
        asGamepad?.Clear();

        currentDialogBox.AdvancePageInputPredicate = () =>
        {
            return inputDevice.DefaultPrimaryActionInput.WasJustPressed ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.X) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.A) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.B) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.Y) == true;
        };

        await currentDialogBox.ShowDialog(pages);

        currentDialogBox = null;
    }

The call to Translate passes in stringId which will be one of the IDs (T_Npc1, T_Npc2, or T_Npc3) depending on which NPC the player has talked to. For example, calling Translate with the string "T_Npc1" results in the string "Hi, I'm just hanging out over here." being returned. The returned string is then split according to the newline character ('\n') to create an IEnumerable\<string\> where each string is a separate page. The pages are passed to the currentDialogBox.ShowDialog call.

## Npc in Glue

The demo includes an entity called Npc which represents a character in the game which the player can talk to. These NPCs are entities similar to the Player entity. Specifically, they are marked as platformer entities and collide with the level's solid collision.

![](/media/2021-05-img_608f02e32f03e.png)

 

![](/media/2021-05-img_608f0300ca7c6.png)

It's worth noting that the Npc instances do not move in this game, so they could have been implemented as static entities with no collision. A full game may include NPCs which walk around a level, follow the player, or move in response to cinematic sequences. Therefore, they have been created as platformer entities so that they can be fully functional if a larger game calls for it. NPCs should not respond to input, so we mark the input device as None in Glue.

![](/media/2021-05-img_608f0354bd88b.png)

We must assign an input device to avoid NullReferenceExceptions from being thrown, so we do so in the Npc's CustomInitialize code by calling InitializePlatformerInput.

    private void CustomInitialize()
    {
        InitializePlatformerInput(new InputDeviceBase());

        animationController = new AnimationController(SpriteInstance);
        var idleLayer = new AnimationLayer();
        idleLayer.EveryFrameAction = () =>
        {
            return "CharacterIdle" + DirectionFacing;
        };
        animationController.Layers.Add(idleLayer);
    }

As shown in the code above, the demo also creates an AnimationController so that the Npc faces left or right in response to its **DirectionFacing** property. As we'll see later, we use this so the Npc faces the Player when dialog is shown. As mentioned earlier, each Npc includes its own dialog. This dialog is assigned in Tiled, but to support this we must create a variable in Glue so the Npc entity includes a DialogId variable.

![](/media/2021-05-img_608f095cc4303.png)

This variable is defined in Glue, but set in Tiled.

## Npc in Tiled

Npc instances can be added to levels through Tiled. To do this, a Tile must have its **Type** set to **Npc**. We use one of the tiles in the standard tileset.

![](/media/2021-05-img_608f09e24c794.png)

Any instance of this tile in Level1Map will result in an Npc instance at runtime.

![](/media/2021-05-img_608f0a5158aff.png)

Notice that the instances are on an object layer rather than a tile layer. This allows the setting of properties on each instance. For example, the selected tile in the screenshot above has a DialogId of T_Npc1. This must match one of the entries in the localization CSV file mentioned earlier. When the Level1Map is loaded, Npc instances are created automatically and added to their respective list (in this case NpcList) in GameScreen. The DialogId variable is also assigned automatically and it can be used to display dialog, as is done in GameScreen.Event.cs where the ShowDialogBox method is called.

    async void OnPlayerListTalkCollisionVsNpcListCollisionOccurred (Entities.Player first, Entities.Npc second)
    {
        if(first.TalkInput.WasJustPressed && currentDialogBox == null)
        {
            if(first.X < second.X)
            {
                second.DirectionFacing = HorizontalDirection.Left;
            }
            else
            {
                second.DirectionFacing = HorizontalDirection.Right;
            }
            foreach(var player in PlayerList)
            {
                player.InputEnabled = false;
            }

            var playerGamepad = first.InputDevice as Xbox360GamePad;

            if(playerGamepad != null)
            {
                GuiManager.GamePadsForUiControl.Clear();
                GuiManager.GamePadsForUiControl.Add(playerGamepad);
            }

            await ShowDialogBox(first.InputDevice, second.DialogId);

            foreach (var player in PlayerList)
            {
                player.InputEnabled = true;
            }
        }
    }

## Player vs Npc Collision

For dialog to appear, two things must occur:

1.  The Player must push the Talk button.
2.  The Player must be close to the NPC. The Player entity includes an AxisAlignedRectangleInstance named TalkCollision specifically to test proximity.

If both occur, then dialog should be displayed.

### TalkInput

The TalkInput is defined in the Player.cs file. The platformer generated code does not automatically add an input object for talking, so the demo adds it in custom code and assigns it in CustomInitializePlatformerInput.

    public IPressableInput TalkInput { get; private set; }
    ...
    partial void CustomInitializePlatformerInput()
    {
        if(InputDevice is Keyboard asKeyboard)
        {
            RunInput = asKeyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.R);
            TalkInput = asKeyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.R);
        }
        else if(InputDevice is Xbox360GamePad asGamepad)
        {
            RunInput = asGamepad.GetButton(Xbox360GamePad.Button.X);
            TalkInput = asGamepad.GetButton(Xbox360GamePad.Button.X);
        }
    }

The demo uses the same input for running and talking, but this could be any button. The TalkInput property must also be public so that we can inspect whether it has been pressed when colliding with the Npc.

### PlayerListTalkCollisionVsNpcList Collision Relationship

As mentioned earlier, the Player includes an AxisAlignedRectangle named TalkCollision. This is excluded from the iCollidable collision so that it does not bump into walls or keep the player on a ledge.

![](/media/2021-05-img_608f11bc9aab6.png)

A collision relationship specifically checking the TalkCollision vs the NpcList is included in the GameScreen.

![](/media/2021-05-img_608f12068d3b3.png)

This is handled in an event in GameScreen.Event.cs.

    async void OnPlayerListTalkCollisionVsNpcListCollisionOccurred (Entities.Player first, Entities.Npc second)
    {
        if(first.TalkInput.WasJustPressed && currentDialogBox == null)
        {
            if(first.X < second.X)
            {
                second.DirectionFacing = HorizontalDirection.Left;
            }
            else
            {
                second.DirectionFacing = HorizontalDirection.Right;
            }
            foreach(var player in PlayerList)
            {
                player.InputEnabled = false;
            }

            var playerGamepad = first.InputDevice as Xbox360GamePad;

            if(playerGamepad != null)
            {
                GuiManager.GamePadsForUiControl.Clear();
                GuiManager.GamePadsForUiControl.Add(playerGamepad);
            }

            await ShowDialogBox(first.InputDevice, second.DialogId);

            foreach (var player in PlayerList)
            {
                player.InputEnabled = true;
            }
        }
    }

Notice that this collision relationship event may trigger every frame, but we only want to perform the dialog box logic if there isn't already a dialog box active, and if the user has just pressed the TalkInput. We could have also manually performed the CollisionRelationship logic in CustomActivity to reduce the number of collision checks, but games like this will typically have a small number of NPCs so the overhead of checking collision every frame is negligible. As mentioned earlier, we manually set the DirectionFacing on the Npc to turn the Npc towards the player. We also temporarily disable Player input so that players cannot move while the dialog is displayed. Notice that the event is an async method, and that we await the DialogBox. Code using the async/await pattern is not very common in FlatRedBall, but it can be very useful when displaying UI using FlatRedBall.Forms. Awaiting the ShowDialogBox method allows us to turn input off and on in a single method without continually checking if the DialogBox is displayed and without callbacks. The ShowDialogBox method displays the dialog box by calling ShowDialog. The ShowDialog method is responsible for the following whether dealing with the DialogBox type or any other FlatRedBall.Forms type:

1.  Displaying new instances of the DialogBox - specifically adding the visuals to FlatRedBall and allowing the Cursor and Xbox360GamePad logic to be performed on the control
2.  Displaying the pages of text as passed in to this method
3.  Removing the DialogBox completely from the engine - both display and logic

 

    private async Task ShowDialogBox(IInputDevice inputDevice, string stringId)
    {
        currentDialogBox = new DialogBox();
        currentDialogBox.IsFocused = true;
        var pages = LocalizationManager.Translate(stringId).Split('\n');

        var asGamepad = inputDevice as Xbox360GamePad;

        // Prevents the push that brought this up from advancing the first dialog
        asGamepad?.Clear();

        currentDialogBox.AdvancePageInputPredicate = () =>
        {
            return inputDevice.DefaultPrimaryActionInput.WasJustPressed ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.X) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.A) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.B) == true ||
                asGamepad?.ButtonPushed(Xbox360GamePad.Button.Y) == true;
        };

        await currentDialogBox.ShowDialog(pages);

        currentDialogBox = null;
    }

If awaited, the ShowDialog call will not return until all pages have been shown. Since the game uses gamepads, we provide a custom AdvancePageInputPredicate which specifies how text is advanced. In this case, we progress a page of text whenever the A, X, B, or Y buttons are pressed, and only for the InputDevice for the player that talked to the NPC. This would matter if the game were to be expanded to support multiple players.

## Conclusion

This walkthrough has covered how to add a dialog box to NPCs. Each NPC defines its own set of dialog using a CSV file which can also be used to support multiple languages.
