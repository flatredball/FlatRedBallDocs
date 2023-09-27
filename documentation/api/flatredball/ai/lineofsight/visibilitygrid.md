## Introduction

The VisibilityGrid can be used to quickly calculate line of sight between [IViewers](/frb/docs/index.php?title=FlatRedBall.AI.LineOfSight.IViewer&action=edit&redlink=1.md "FlatRedBall.AI.LineOfSight.IViewer (page does not exist)"). The VisibilityGrid is a very efficient class when dealing with a small number of squares. For example, if each IViewer has a radius smaller than 10, visibility updates can be incredibly fast. The larger the radius (in tiles), the slower performance becomes. Visibility calculations require O(n^2) operations where N is the view radius in tiles, so be careful with larger view radii.

## VisibilityGrid and IViewer

The VisibilityGrid can contain any number of IViewers. An IViewer is an object with a position and a view radius. The VisibilityGrid uses this information to calculate what is in view. Therefore, to use a VisibilityGrid, you must create a class that implements the IViewer interface.

## Code Example

The following example shows how to create a simple Sprite IViewer, move it around a grid, and view the resulting visibility.

Create the IViewer class. Normally this would be an Entity, but we're going to just whip something together quickly for this example:

    public class Viewer : IViewer
    {
        public Sprite Sprite
        {
            get;
            set;
        }

        public float WorldViewRadius
        {
            get
            {
                return 5;
            }
            set
            {
                // do nothing, may want to allow a setter in real code.                
            }
        }

        public float X
        {
            get
            {
                return Sprite.X;
            }
            set
            {
                Sprite.X = value;
            }
        }

        public float Y
        {
            get
            {
                return Sprite.Y;
            }
            set
            {
                Sprite.Y = value;
            }
        }

        public float Z
        {
            get
            {
                return Sprite.Z;
            }
            set
            {
                Sprite.Z = value;
            }
        }
    }

Add the following using statements in your Game1.cs file:

    using FlatRedBall.AI.LineOfSight;
    using FlatRedBall.Input;

Add the following at class scope:

    VisibilityGrid visibilityGrid;
    Viewer viewer;

Add the following to Initialize after initializing FlatRedBall:

    float seedX = -15; // this is the left side
    float seedY = -15; // this is the bottom
    float spacing = 1; // the size of each grid space (this means 1X1)
    int gridSizeX = 32; // the number of cells on the X axis
    int gridSizeY = 32; // the number of cells on the Y axis
    visibilityGrid = new VisibilityGrid(seedX, seedY, spacing, 
        gridSizeX, gridSizeY);

    visibilityGrid.Visible = true; // for debugging, this makes the light-blue Sprite show up

    viewer = new Viewer();
    viewer.Sprite = SpriteManager.AddSprite("redball.bmp");
    visibilityGrid.AddViewer(viewer);

Add the following to Update:

    InputManager.Keyboard.ControlPositionedObject(viewer.Sprite);

    if (visibilityGrid.Activity())
    {
        visibilityGrid.UpdateDisplay();
    }

![VisibilityGrid.png](/media/migrated_media-VisibilityGrid.png)

## Adding blockers

You can modify the code above as follows: Add the following after creating the VisibilityGrid:

    visibilityGrid.BlockWorld(3, 3);
    visibilityGrid.BlockWorld(4, 3);
    visibilityGrid.BlockWorld(3, -2);
    visibilityGrid.BlockWorld(5, 0);

    // This will help us see the debug display better:
    FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;

![VisibilityGridWithBlockers.png](/media/migrated_media-VisibilityGridWithBlockers.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
