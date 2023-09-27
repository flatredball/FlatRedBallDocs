## Introduction

The IsOn3D method is a very powerful method that can be used to test if the cursor is over an object. IsOn3D is used by [Glue](/frb/docs/index.php?title=Glue.md "Glue") generated code to test if the Cursor is over an Entity if the Entity implements IClickable or IWindow. The IsOn3D method is very powerful and flexible. It considers:

-   Object position
-   Camera position
-   Object orientation
-   Camera orientation
-   Camera perspective settings
-   Layers

It can be used to check if the cursor is over any of the following objects:

-   Sprite
-   Text
-   AxisAlignedCube
-   Sphere
-   Any other object implementing IPositionable, IScalable, IRotatable

## Code Example

The following code creates a group of Sprites which turn invisible when the cursor moves over them. Add the following at class scope:

    PositionedObjectList<Sprite> mSprites = new PositionedObjectList<Sprite>();

Add the following in Initialize after initializing FlatRedBall:

    for (int i = 0; i < 40; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
        SpriteManager.Camera.PositionRandomlyInView(sprite, 20, 60);
        mSprites.Add(sprite);
    }

Add the following to Update:

    for (int i = 0; i < mSprites.Count; i++)
    {
        Sprite sprite = mSprites[i];

        if (sprite.Visible && GuiManager.Cursor.IsOn3D(sprite))
        {
            sprite.Visible = false;
        }
    }

![CursorIsOn3D.png](/media/migrated_media-CursorIsOn3D.png)

## IsOn3D for clicking UI

The IsOn3D method can be used to detect if the Cursor has clicked on an object. For example, the following code shows how to check if the user has clicked on a Sprite:

    // Assuming spriteInstance is a valid Sprite:
    if(GuiManager.Cursor.PrimaryClick && GuiManager.Cursor.IsOn3D(spriteInstance))
    {
       // The user has clicked on the Sprite, do something
    }

For more information on PrimaryClick, see the [PrimaryClick page](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.PrimaryClick.md "FlatRedBall.Gui.Cursor.PrimaryClick").

## IsOn3D and Layers

The IsOn3D method supports [Layers](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer.md "FlatRedBall.Graphics.Layer") as well. For example, assuming mySprite is a valid Sprite and myLayer is valid Layer:

    bool isCursorOn = GuiManager.Cursor.IsOn3D(mySprite, myLayer);
