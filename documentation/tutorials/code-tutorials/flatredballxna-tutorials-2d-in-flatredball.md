## Introduction

FlatRedBall is a 2.5D game engine. This means that it falls somewhere between 2D and 3D. While this provides many benefits like being able to create 2D games with 3D graphics and hardware acceleration, some things like pure 2D graphics require a little bit of work. Fortunately FlatRedBall is built to handle these situations and pure 2D scenes can be created with just a few lines of code.

## Aren't Sprites 2D?

The answer to this question is tricky. From one point of view, yes, [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") are pure 2D objects because they don't have any depth. They are simply flat planes which can display a texture or pure color. However, [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") can also be positioned in 3D space, rotated in 3D, and scaled. Furthermore, by default Sprites do not resize themselves according to the [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") they reference. Therefore, if a Sprite's ScaleX or ScaleY properties are not changed, the Sprite will be the same size if it references a 16x16 pixel [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") or a 1024x1024 pixel [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D"). Although a Sprite's [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") does not control Sprite Scale values, it is possible to set the Sprite's Scale to be based off of its referenced [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D"), as is mentioned below.

## Creating a 2D Camera

While it's not necessary, the simplest way to create a pure 2D scene is to create, or rather, set the properties of the already-created [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") so that it displays a pure 2D scene. The first step is to set the camera's Orthogonal property to true. Once this is done the camera's OrthogonalWidth and OrthogoalHeight should be set to match the widow's dimensions. The following code accomplishes this:

    SpriteManager.Camera.Orthogonal = true;
    SpriteManager.Camera.OrthogonalWidth = FlatRedBallServices.ClientWidth;
    SpriteManager.Camera.OrthogonalHeight = FlatRedBallServices.ClientHeight;

Also, the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") has a built-in method for performing the above code:

    bool moveCornerToOrigin = true; // makes the bottom left of the screen 0,0
    SpriteManager.Camera.UsePixelCoordinates(moveCornerToOrigin);

Remember, in the first code where the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") orthogonal values are manually set the center of the screen remains at X = 0, Y = 0. In the second set of code if the moveCornerToOrigin bool is true, the bottom left of the screen is X = 0, Y = 0. Keep this in mind when creating your Sprites.

## Coordinate Systems

FlatRedBall XNA and FlatSilverBall use what's called a "[right-handed](http://en.wikipedia.org/wiki/Cartesian_coordinate#Orientation_and_handedness)" coordinate system. In the default setup, that means that positive X points right, positive Y points up, and positive Z points out of the screen. FlatRedBall MDX uses a "[left-handed](http://en.wikipedia.org/wiki/Cartesian_coordinate#Orientation_and_handedness)" coordinate system. To keep things simple, the only axis that is inverted is the Z, so X and Y point in the same direction, but Z inverts so that positive Z points into the screen.

### Why not use a Top-Left oriented coordinate system?

Some game engines use the top-left of the screen as their origin. Usually when this is the case, positive Y points down. FlatRedBall doesn't implement this system. There are a number of reasons why we don't do this:

-   It is not the common mathematical coordinate system. Classes which teach how to graph points, lines, and curves introduce a coordinate system which has positive Y pointing upward. If you remember your early math courses you will remember this too.
-   Inverting the Y would require special-case code in the engine since it's built for 3D. If a mathematical inverse of the coordinate system is performed, then the positions of all objects flip. That means that the positions of the top vertices of a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") would also be flipped with the bottom. That means it's not just positions that invert. All objects would also appear upside-down. But we don't want to seem like whiners - this is also for your benefit. If positive Y remains up, then you can easily convert your game from a 2D to 3D if you decide you like features of 3D (or vice versa).
-   Inverted coordinates can be implemented using [Extension Methods](http://msdn.microsoft.com/en-us/library/bb383977.aspx). While the Position and X,Y,Z values cannot be overridden, methods like SetInvertedPosition could be implemented to do conversion so that code to set positions can behave like an inverted coordinate system.
-   An inverted coordinate system is usually implemented when the screen (or other canvas) is what objects are positioned relative to. The reason this is the case is because of how western written language is read - left to right and top to bottom. English, for example, is read from top left to bottom right, and most computer programs are built for this. If you re-size an instant-message window or a text document you'll see that word wrapping is performed according to the top-left being the origin (unless you're using a program that is built to handle both styles). All but the simplest FlatRedBall games require a moving camera, so things are not positioned relative to the top-left of the screen but rather relative to each other in world space. Since the visible screen is no longer the basis for positioning, we might as well follow a more mathematically recognizable system.

## Setting a Sprite's Scale

Now that the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") properties are set for a 2D scene all that is left is to resize any [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to match their texture coordinate. If you are not familiar with the concept of scale, see the [IScalable wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.IScalable.md "FlatRedBall.Math.Geometry.IScalable"). If you are familiar with scale, then recall that ScaleX equals half of the width. That means if we want a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to be 32 units wide, its ScaleX should be set to 16. The following code creates a Sprite, sets its width and height relative to its [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D"), then repositions it so that it is in screen.

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    sprite.ScaleX = sprite.Texture.Width / 2.0f;
    sprite.ScaleY = sprite.Texture.Height / 2.0f;

    // Move the Sprite up and to the right so it's in the screen
    sprite.X = sprite.ScaleX;
    sprite.Y = sprite.ScaleY;

![PixelSprite.png](/media/migrated_media-PixelSprite.png) Prior to this block of code I called SpriteManager.Camera.UsePixelCoordinates(true) which makes the origin the bottom left of the screen. Therefore the above image shows the Sprite at the bottom left of the screen. Finally, rather than manually using the [Texture'a](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") Width and Height properties, the Sprite's PixelSize property can be set to automatically set the Scale according to the referenced [Texture's](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") dimensions. The following code accomplishes the same as the previous block:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    sprite.PixelSize = .5f;

    // Move the Sprite up and to the right so it's in the screen
    sprite.X = sprite.ScaleX;
    sprite.Y = sprite.ScaleY;

## Determining Pixel Coordinates

See the [MathFunctions wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.MathFunctions.md "FlatRedBall.Math.MathFunctions").

## Is Zooming Possible?

One of the benefits of using a 3D [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") setup is that it very easy to simulate "zooming" by simply changing the Z value of the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera"). When the UsePixelCoordinates method is called, the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") view is made orthogonal. In other words, changing the Z value of the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera") does not impact the visible size of objects. However, zooming is still possible by changing the OrthogonalWidth and OrthogonalHeight properties manually. This will allow for "zooming" but parallax and other "depth" effects will not be visible.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
