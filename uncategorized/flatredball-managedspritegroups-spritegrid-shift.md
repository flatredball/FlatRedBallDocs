## Introduction

The Shift member shifts all visible Sprites, the Blueprint, and all contained data in the SpriteGrid by the argument amount. This method **does not** shift the bounds of the SpriteGrid. This method can be used to simulate scrolling or to reposition the SpriteGrid's seed.

## Code Example

The following code creates a SpriteGrid which appears to scroll because of the every-frame call to Shift.

Add the following using statement:

    using FlatRedBall.ManagedSpriteGroups;

Add the following to Initialize after initializing FlatRedBall:

    Sprite blueprint = new Sprite();
    blueprint.Texture = 
        FlatRedBallServices.Load<Texture2D>("redball.bmp");

    spriteGrid = new SpriteGrid(SpriteManager.Camera, SpriteGrid.Plane.XY, blueprint);

    spriteGrid.PopulateGrid();

Add the following to Update:

    float scrollVelocity = 1;
    spriteGrid.Shift(scrollVelocity * TimeManager.SecondDifference, 0, 0);
    spriteGrid.Manage();

![SimpleSpriteGrid.png](/media/migrated_media-SimpleSpriteGrid.png)
