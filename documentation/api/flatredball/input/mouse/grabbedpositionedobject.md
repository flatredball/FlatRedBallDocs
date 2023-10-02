## GrabbedPositionedObject

The Mouse class provides functionality for grabbing and moving any object which implements the PositionedObject class. This includes common FlatRedBall types like [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [Text,](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") as well as entities created in Glue. The following code creates 9 [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and allows the user to click and drag to control the [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). This code can be added to any FlatRedBall Screen

``` lang:c#
public partial class YourScreenName
{
    SpriteList spriteList = new SpriteList();

    void CustomInitialize()
    {

        FlatRedBallServices.Game.IsMouseVisible = true;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Sprite sprite = new Sprite();
                sprite.ColorOperation = FlatRedBall.Graphics.ColorOperation.Color;
                sprite.Red = 1;
                sprite.Width = 50;
                sprite.Height = 50;
                sprite.X = x * 110;
                sprite.Y = y * 110;

                SpriteManager.AddSprite(sprite);

                spriteList.Add(sprite);
            }
        }
    }

    void CustomActivity(bool firstTimeCalled)
    {
        if (InputManager.Mouse.ButtonPushed(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
        {
            // See which Sprite the mouse is over
            Sprite spriteOver = null;

            foreach (Sprite sprite in spriteList)
            {
                // IsOn3D assumes the default camera if no camera argument is passed
                // The call can also be made by passing a camera as follows:
                // InputManager.Mouse.IsOn3D<Sprite>(sprite, false, anyCameraInstance)
                if (InputManager.Mouse.IsOn3D<Sprite>(sprite, false))
                {
                    spriteOver = sprite;
                    break;
                }
            }
            InputManager.Mouse.GrabbedPositionedObject = spriteOver;
        }

        if (InputManager.Mouse.ButtonReleased(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
        {
            InputManager.Mouse.GrabbedPositionedObject = null;
        }
    }

    ...
```

[![](/media/2016-01-2019-04-06_22-18-14.gif)](/media/2016-01-2019-04-06_22-18-14.gif) Setting the GrabbedPositionedObject does the following:

1.  Stores the reference in the GrabbedPositionedObject property
2.  Stores offset variables - this is the difference between the GrabbedPositionedObject's position and the cursor's world coordinates.
3.  Updates the GrabbedPositionedObject's position every frame using the Mouse's world coordinates and the offset values. This is performed automatically - there is no need to manually manage positions when using GrabbedPositionedObject.

## GrabbedPositionedObject and Parents

In the example above the Sprites do not have any parents so they can be grabbed and moved freely by the cursor. It is common to have Sprites as part of Glue entities, in which case the Sprite is attached to the entity. If the GrabbedPositionedObject has a non-null Parent, then it cannot be moved. In this situation it is more common to grab (and move) the parent entity.  
