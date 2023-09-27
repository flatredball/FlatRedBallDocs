## Introduction

Tile based movement is a control system common in classic RPGs like Dragon Warrior and many of the early Final Fantasy games. While it was used in some very early games, tile based movement is not as simple as free movement which can be applied as follows:

    object.XVelocity = InputManager.XBoxController[0].LeftStick.Position.X;
    object.YVelocity = InputManager.XBoxController[0].LeftStick.Position.Y;

Tile based movement can be applied in a variety of ways, but the most common is using instructions. The following code creates a tile map and a keyboard-controlled [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which moves using tile based movement.

Add the following using statements: using FlatRedBall; using FlatRedBall.Instructions; using FlatRedBall.ManagedSpriteGroups;

Add the following code in initialize:

    Sprite blueprint = new Sprite();
    // Give the tiles a ColorOperation to make them look different
    blueprint.ColorOperation = FlatRedBall.Graphics.ColorOperation.Modulate;
    blueprint.Green = 1;
    blueprint.Red = .5f;
    blueprint.Texture =
        FlatRedBallServices.Load<Texture2D>("redball.bmp");

    SpriteGrid spriteGrid = new SpriteGrid(SpriteManager.Camera,
        SpriteGrid.Plane.XY, blueprint);

    spriteGrid.XLeftBound = -10;
    spriteGrid.XRightBound = 10;
    spriteGrid.YTopBound = 10;
    spriteGrid.YBottomBound = -10;

    spriteGrid.PopulateGrid();

    Sprite character = SpriteManager.AddSprite("redball.bmp");
    character.CustomBehavior += TileBasedMovement;

Add the following at class scope:

    public void TileBasedMovement(Sprite sprite)
    {
        // default for SpriteGrids
        float tileSize = 2;
        float timeToTake = .5f;

        if (sprite.Instructions.Count == 0)
        {
            if (InputManager.Keyboard.KeyDown(Keys.Left))
            {
                InstructionManager.MoveToAccurate(sprite,
                    sprite.X - tileSize, sprite.Y, 0, timeToTake);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.Right))
            {
                InstructionManager.MoveToAccurate(sprite,
                    sprite.X + tileSize, sprite.Y, 0, timeToTake);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.Up))
            {
                InstructionManager.MoveToAccurate(sprite,
                    sprite.X, sprite.Y + tileSize, 0, timeToTake);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.Down))
            {
                InstructionManager.MoveToAccurate(sprite,
                    sprite.X, sprite.Y - tileSize, 0, timeToTake);
            }
        }
    }

![TileBasedMovement.png](/media/migrated_media-TileBasedMovement.png)
