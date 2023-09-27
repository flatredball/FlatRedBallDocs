## Introduction

This tutorial series will show you how to create a simple but complete pong clone. In this part of the series you will learn to organize the game in Screens (create a menu screen, add a popup screen), add a pause mode to the game and make mouse based collision detection.

## Adding a new Screen

Since the game is nearly feature-complete after the [second part of this tutorial series](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:FlatRedPong_Tutorial_-_Part_2 "FlatRedBallXna:Tutorials:FlatRedPong Tutorial - Part 2"), you should attach more importance to how your code is organized. At the moment everything is placed in a single code file. Thatâ€™s fine for the beginning but will be a pain when your project grows. Furthermore there should be a frame to the game. The game should start with a menu screen where you can start the game. After finishing the game, the menu screen should appear again. To convert the game into a Screen you need to learn how to create Screens. You will learn that in the following tutorial chapter â€œCreate a templateâ€?: [Screen:How to use Screens](/frb/docs/index.php?title=Screen:How_to_use_Screens "Screen:How to use Screens") After downloading the template, create a new Screen named GameScreen and add it to your project.

**Note:** If you at a new screen for the first time, it may be added to your projects root directory. The template added a new directory called â€œScreensâ€? to your project. You should move your newly created file GameScreen.cs there also. **Note:** If you had to move the file, the generated Namespace could be wrong. The Namespace should be

      namespace FlatRedPong.Screens

You may need to change it.

## Converting the game to GameScreen

After creating the new GameScreen class, move all logic from the game to the new class. First you should copy all class variables (the Sprites, scores, texts, game over flag) to the top of the new class. Next move all the initialization code from the Initialize()method of the game to the Initialize()method of the GameScreen.

**Be careful:** If you add a new screen for the first time, it may be added to your projects root directory. The template added a new directory called â€œScreensâ€? to your project. You should move your newly created file GameScreen.cs there also.

Your games Initialization() method should be very short by now:

    protected override void Initialize()
    {
     // Initialize FRB
     FlatRedBallServices.InitializeFlatRedBall(this, graphics);
       
     // Set Camera to orthogonal
     SpriteManager.Camera.Orthogonal = true;
     base.Initialize();
    }

Now move all the update logic from the games Update() method to the GameScreens Activity() method. Your games Update() method should also be very short:

    protected override void Update(GameTime gameTime)
    {
     FlatRedBallServices.Update(gameTime);
     FlatRedBall.Screens.ScreenManager.Activity();
       
     base.Update(gameTime);
    }

Since the method performing all the update tasks is called Activity() in the Screen class, the call to base.Update(gameTime) in the game over handling must be changed to base.Activity(firstTimeCalled). Also copy all the created private methods over to the screen class:

-   HandleInput()
-   CheckCollisions()
-   SetSpriteCollision(Sprite sprite)

**Note:** If your code does not compile you may have to add some using statements at the top of your code. By pressing \<Shift\> + \<Alt\> + \<F10\> when your cursor is on the unknown type you can let Visual Studio do thos work for you.

Now our game screen is complete. We just need to add it to the ScreenManager. Add the following code to the games Initialize() method:

    // Add Screen
    ScreenManager.Start(typeof(GameScreen).FullName);

You also have to clean up your objects since you use the Screen. But this is managed by the Screen class. Just add all your Sprites and Texts to a specific list:

    this.mSprites.Add(ball);
    this.mSprites.Add(leftPaddle);
    this.mSprites.Add(rightPaddle);
    this.mSprites.Add(scoreSpriteLeft);
    this.mSprites.Add(scoreSpriteRight);
    this.mTexts.Add(gameOverText);

You should place these statements into the Initialize() method of the GameScreen to the according blocks in the code. The objects in these lists will be destroyed when the Screen is destroyed. Compile and run the code. When everything was moved correctly the game should work in the same way as before. But your code is more organized now. ![Screen FlatRedPong Tut2 1.png](/media/migrated_media-Screen_FlatRedPong_Tut2_1.png)

## Adding a menu screen

Create another Screen named MenuScreen and add it to your project. You will need a background and a button graphics. Again you can create your own graphics or you take these: ![YellowButton.png](/media/migrated_media-YellowButton.png) ![Flp Background.png](/media/migrated_media-Flp_Background.png) In the menu Screen there will be two buttons:

-   Start new game
-   Exit game

There will also be a tip text for each button which explains what it does. Add the following variables at class Scope:

    Camera camera;
    Sprite background;
    Sprite exitButton;
    Sprite newGameButton;
    Text exitButtonText;
    Text newGameButtonText;
    Text tipText; 

Now initialize these variables in the Initialize() method:

    // Set Camera 
    camera = SpriteManager.Camera;

    // Show mouse cursor
    FlatRedBallServices.IsWindowsCursorVisible = true;

    // Initialize the sprites
    // Initialize background sprite
    background = SpriteManager.AddSprite(@"Content\Background");
    background.ScaleX = 0.5f * background.Texture.Width / camera.PixelsPerUnitAt(background.Z);
    background.ScaleY = 0.5f * background.Texture.Height / camera.PixelsPerUnitAt(background.Z);
    this.mSprites.Add(background);

    // Initialize exitButton sprite
    exitButton = SpriteManager.AddSprite(@"Content\Button");
    exitButton.Position = new Vector3(camera.AbsoluteRightXEdgeAt(exitButton.Z) / 2,
     camera.AbsoluteBottomYEdgeAt(exitButton.Z) + 2f, 0);
    exitButton.ScaleX = 0.5f * exitButton.Texture.Width /
     camera.PixelsPerUnitAt(exitButton.Z);
    exitButton.ScaleY = 0.5f * exitButton.Texture.Height /
     camera.PixelsPerUnitAt(exitButton.Z);
    SetSpriteCollision(exitButton);
    this.mSprites.Add(exitButton);

    // Initialize newGameButton sprite
    newGameButton = SpriteManager.AddSprite(@"Content\Button");
    newGameButton.Position = new Vector3(camera.AbsoluteRightXEdgeAt(newGameButton.Z) / 2,
     camera.AbsoluteBottomYEdgeAt(newGameButton.Z) + 5f, 0);
    newGameButton.ScaleX = 0.5f * newGameButton.Texture.Width /
     camera.PixelsPerUnitAt(newGameButton.Z);
    newGameButton.ScaleY = 0.5f * newGameButton.Texture.Height / 
     camera.PixelsPerUnitAt(newGameButton.Z);
    SetSpriteCollision(newGameButton);
    this.mSprites.Add(newGameButton);

    // Initialize the text
    // Exit Button
    exitButtonText = TextManager.AddText("Exit");
    exitButtonText.Position = new Vector3(camera.AbsoluteRightXEdgeAt(exitButtonText.Z) / 2,
     camera.AbsoluteBottomYEdgeAt(exitButtonText.Z) + 2f, 0);
    exitButtonText.HorizontalAlignment = HorizontalAlignment.Center;
    exitButtonText.Scale = .5f;
    exitButtonText.Spacing = .65f;
    exitButtonText.ColorOperation = ColorOperation.Modulate;
    exitButtonText.Red = 0f;
    exitButtonText.Green = 0f;
    exitButtonText.Blue = 0f;
    exitButtonText.Font = new BitmapFont(@"Content\Kristen_32", 
     @"Content\Kristen_32.fnt", FlatRedBallServices.GlobalContentManager);
    this.mTexts.Add(exitButtonText );

    // New Game Button
    newGameButtonText = TextManager.AddText("New Game");
    newGameButtonText.Position = new Vector3(camera.AbsoluteRightXEdgeAt(newGameButtonText.Z) / 2, 
     camera.AbsoluteBottomYEdgeAt(newGameButtonText.Z) + 5f, 0);
    newGameButtonText.HorizontalAlignment = HorizontalAlignment.Center;
    newGameButtonText.Scale = .5f;
    newGameButtonText.Spacing = .65f;
    newGameButtonText.ColorOperation = ColorOperation.Modulate;
    newGameButtonText.Red = 0f;
    newGameButtonText.Green = 0f;
    newGameButtonText.Blue = 0f;
    newGameButtonText.Font = new BitmapFont(@"Content\Kristen_32",
     @"Content\Kristen_32.fnt", FlatRedBallServices.GlobalContentManager);
    this.mTexts.Add(newGameButtonText);

    // Button Text Tip
    tipText = TextManager.AddText(String.Empty);
    tipText.Position = new Vector3(camera.AbsoluteLeftXEdgeAt(tipText.Z) + 2,
     camera.AbsoluteBottomYEdgeAt(tipText.Z) + 3.5f, 0);
    tipText.HorizontalAlignment = HorizontalAlignment.Left;
    tipText.Scale = .35f;
    tipText.Spacing = .4f;
    tipText.ColorOperation = ColorOperation.Modulate;
    tipText.Red = 1f;
    tipText.Green = 1f;
    tipText.Blue = 1f;
    tipText.Font = new BitmapFont(@"Content\Kristen_32", @"Content\Kristen_32.fnt",
     FlatRedBallServices.GlobalContentManager);
    this.mTexts.Add(tipText);

Nothing really new here. The sprites and text are initialized, the position, collision and color are set and the objects are added to mSprites and mTexts list for automatic removal.

**Note:** You may copy the method SetSpriteCollision(Sprite sprite) from the GameScreen to the MenuScreen. A better way to do this task is to create a class MyScreen (derived from Screen) and implement the method there. All special Screens (like GameScreen) will derive from MyScreen. Another way of centralize a method like this is to create a static helper class.

Since the new screen should be seen on startup, you have to add it to the ScreenManager in the games Initialize() method:

    // Add Screen
    // ScreenManager.Start(typeof(GameScreen).FullName);
    ScreenManager.Start(typeof(MenuScreen).FullName);

Compile and run the code. You will see the new menu screen on startup. ![Screen FlatRedPong Tut3 1.png](/media/migrated_media-Screen_FlatRedPong_Tut3_1.png) Now some logic is needed in the screen. First the game should be started again. Add the following code to the Activity() method:

    // Check mouse collision
    // Check collisions
    CheckCollisions();

As you can see, the update handling will be put in an own method again. Create the method:

    private void CheckCollisions()
    {
     // Reset mouse over effect
     exitButtonText.Red = 0f;
     newGameButtonText.Red = 0f;
     tipText.DisplayText = String.Empty;

    // Mouse collision check
    // Is Mouse on any button?
    if (InputManager.Mouse.IsOn(exitButton.CollisionAxisAlignedRectangle))
    {
      // Mouse over effect
      exitButtonText.Red = 1f;
      tipText.DisplayText = "Exit Game";

      // Is left button pressed?
      if (InputManager.Mouse.ButtonPushed(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
      {
       ExitGame();
      }
    }

    if (InputManager.Mouse.IsOn(newGameButton.CollisionAxisAlignedRectangle))
    {
      // Mouse over effect
      newGameButtonText.Red = 1f;
      tipText.DisplayText = "Start a new Game";

      // Is left button pressed?
      if (InputManager.Mouse.ButtonPushed(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
      {
       StartGame();
      }
     }
    }

Lets take a look at the code. First all variables that will be set later are reset. Then it will be checked if the mouse â€œis onâ€? the exit buttons collision rectangle. If it is, the text color of the â€œExit Gameâ€? text is set to red. Furthermore a display text for the tip text is set. Since the mouse is on the exit button it is checked if the left mouse button is pressed. If it is, the method ExitGame() is called which should return to the menu screen. The same handling is performed for the â€œNew Gameâ€? button, but another tip text is set and the method StartGame() is called which should move to the game screen. Add the both methods called above at the end of the MenuScreen class:

    private static void ExitGame()
    {
     // End the game
     FlatRedBallServices.Game.Exit();
    }

This method calls the games Exit() method using the FlatRedBallServices class.

    private void StartGame()
    {
     // Start game screen
     this.IsActivityFinished = true;
     MoveToScreen(typeof(GameScreen).FullName);
    }

This method sets the MenuScreens property IsActivityFinished to true and calls the method MoveToScreen(â€¦) to proceed to the GameScreen. Compile and run the code. When you hover the mouse over the buttons you will see the text color of the button will turn red. Furthermore will there be a tip text next to the buttons. When you click on the button â€œExitâ€? the game will exit. Clicking the button â€œNew Gameâ€? will start a new game. ![Screen FlatRedPong Tut3 2.png](/media/migrated_media-Screen_FlatRedPong_Tut3_2.png)

## Adding Pause Function

The last action of this part of the tutorial is to add another Screen to the game. This screen handles a paused game. Pressing the keys â€œPâ€? or â€œEscapeâ€? will pause the game. You will need a background graphics. Again you can create your own graphics or take the one below: ![Flp Pause.png](/media/migrated_media-Flp_Pause.png) I added the complete text of the screen to the image. So there are not many objects around in the screen.

**Note:** The Image has a semi transparent gradient from the center to all borders. This will have the effect that you can still see the paddles, ball and score when game pauses.

The initialisation is accordingly simple:

    // Set Camera 
    camera = SpriteManager.Camera;

    // Hide mouse cursor
    FlatRedBallServices.IsWindowsCursorVisible = false;

    // Initialize background sprite
    background = SpriteManager.AddSprite(@"Content\Pause");
    background.ScaleX = 0.5f * background.Texture.Width /   camera.PixelsPerUnitAt(background.Z);
    background.ScaleY = 0.5f * background.Texture.Height /  camera.PixelsPerUnitAt(background.Z);
    this.mSprites.Add(background); 

**Note:** If you copied the code for MenuScreen and PauseScreen, then you will set the property

     FlatRedBallServices.IsWindowsCursorVisible

To have them work properly, you have to add some more lines of code: Game.Initialize():

     // Generally hide windows mouse cursor reactivate it per screen
     FlatRedBall.Gui.GuiManager.IsUIEnabled = true;
     FlatRedBallServices.IsWindowsCursorVisible = false;

This will disable the FRBs own mouse cursor. GameScreen.Initialize():

     // Hide mouse cursor
     FlatRedBallServices.IsWindowsCursorVisible = false;

This will hide the mouse cursor in the game.

Since the PauseScreen will be used as a â€œPopupScreenâ€?, you need to clean it up on your own:

    public override void Destroy()
    {
     SpriteManager.RemoveSprite(background);
     base.Destroy();
    }

Now the PauseScreen can be called if the defined keys are pressed during the game. Add the following code at the end of the Activity(â€¦) method of the GameScreen:

    // Handle pause mode
    HandlePauseMode();
    if (!pause)
    {
     // Handle Input
     HandleInput();
     // Check collisions
     CheckCollisions();
    }

The collision checks and the input handling is only done, if not in pause mode. You have to add the variable â€œpauseâ€? on class scope (itâ€™s a bool type). Before the pause flag is checked, the method HandlePauseMode() is called. The method looks like this:

    private void HandlePauseMode()
    {
     if (!pause)
     {
      // Check for pause
      if (InputManager.Keyboard.KeyPushed(Keys.Escape) || InputManager.Keyboard.KeyPushed(Keys.P))
      {
        pause = true;
      }
      
      // Handle popup screen for pause
      if (pause)
      {
       if (pauseScreen == null)
       {
        pauseScreen = LoadPopup(typeof(PauseScreen).FullName, true) as PauseScreen;
       }
       PauseGame();
       return;
      }
      }
      else
      {
      // Check for pushed keys
      // Continue
      // Key: Space
      if (InputManager.Keyboard.KeyPushed(Keys.Space))
      {
        // Back to game
        ContinueGame();
        pauseScreen.IsActivityFinished = true;
        pauseScreen = null;
      }
      // Exit
      // Key: Escape
      if (InputManager.Keyboard.KeyPushed(Keys.Escape))
      {
        // Back to menu
        pause = false;
        pauseScreen.IsActivityFinished = true;
        pauseScreen = null;
        MoveToScreen(typeof(MenuScreen).FullName);
      }
     }
    }

There are two parts in this method:

1.  Game is running

    Then the keys â€œPâ€? and â€œEscapeâ€? are checked. When they are pressed, pause flag is set. If pause is set afterwards, the PauseScreen will be loaded as a Popup and the game is paused by calling the method PauseGame().

2.  Game is paused

    The keys â€œSpaceâ€? and â€œEscapeâ€? are checked. When â€œSpaceâ€? is pressed, the method ContinueGame() is called to continue the game. When â€œEscapeâ€? is pressed, the PauseScreen is set to null and the MenuScreen is called using the MoveToScreen(â€¦) method

How you can see, the whole pause logic is in the game, including the PauseScreen logic. To pause the game the ball is stopped. To continue the game, the balls velocity will be reset. Letâ€™s take a look at the two methods:

    private void PauseGame()
    {
     // Stop ball movement and save it
     ballVelocity = ball.Velocity;
     ball.Velocity = Vector3.Zero;
     pause = true;
    }

To pause the game, the balls velocity is stored in a new class variable. Then the velocity of the ball is set to 0 and the pause flag is set to true.

    private void ContinueGame()
    {
     // Reset ball movement
     ball.Velocity = ballVelocity;
     ballVelocity = Vector3.Zero;
     pause = false;
    }

To continue the game, the balls velocity reset from the class variable. Then the pause flag is set to false. The initialization of the save variable is not necessary, but good style. You need to define the variable ballVelocity of type Vector3 at class scope. Compile and run the code. Now we have a comfortable, pausable pong game! ![Screen FlatRedPong Tut3 3.png](/media/migrated_media-Screen_FlatRedPong_Tut3_3.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
