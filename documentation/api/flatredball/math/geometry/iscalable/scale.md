## Introduction

Scale is a common measurement of size in the FlatRedBall Engine. Most sizable objects implement the [IScalable](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.IScalable "FlatRedBall.Math.Geometry.IScalable") interface and have ScaleX and ScaleY variables. This includes the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") class. Scale measures the distance from the center of an object to its edge. Therefore, the following relationships exist:

    width = object.ScaleX * 2;
    leftEdge = object.X - object.ScaleX;
    rightEdge = object.X + object.ScaleX;

In other words, ScaleX is half of width and ScaleY is half of height. ![ScaleDiagram.png](/media/migrated_media-ScaleDiagram.png)

## 

### Textures and Size

FlatRedBall can be rendered using a 2D or 3D camera. Games using a 2D camera typically render their sprites according to the size of their source texture (using the TextureScale property). Games using a 3D camera may not rely on a texture's size. In this case, scale values may be manually set. Therefore, two [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which reference textures of different size or aspect ratios may have sizes completely unrelated to their texture. Fortunately, sprite's Texture property exposes its dimensions so if you desire to control the size of a Sprite according to its texture, you can set the X and Y scales according to the size of the texture. The following code creates three [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") - one with a default ScaleX and ScaleY of 1, one with its size relative to the size of its source texture, and one drawn drawn to-the-pixel.

    Sprite defaultScaleSprite = SpriteManager.AddSprite(@"Assets\Scenes\frblogo.png");
    defaultScaleSprite.Y = 8;

    // The size is relative to its source texture.  Increase
    // sizeCoefficient to increase size.
    float sizeCoefficient = .02f;
    Sprite correctAspectRatio = SpriteManager.AddSprite(@"Assets\Scenes\frblogo.png");
    correctAspectRatio.Y = 0;
    correctAspectRatio.ScaleX = correctAspectRatio.Texture.Width * sizeCoefficient;
    correctAspectRatio.ScaleY = correctAspectRatio.Texture.Height * sizeCoefficient;

    // This makes the Sprite drawn to-the-pixel.
    Sprite pixelPerfectSprite = SpriteManager.AddSprite(@"Assets\Scenes\frblogo.png");
    pixelPerfectSprite.Y = -11;
    float pixelsPerUnit = SpriteManager.Camera.PixelsPerUnitAt(pixelPerfectSprite.Z);
    pixelPerfectSprite.ScaleX = .5f * pixelPerfectSprite.Texture.Width / pixelsPerUnit;
    pixelPerfectSprite.ScaleY = .5f * pixelPerfectSprite.Texture.Height / pixelsPerUnit;

![LogoWithDifferentScales.png](/media/migrated_media-LogoWithDifferentScales.png)

## Sizing and Positioning Objects

When first creating a level in FlatRedBall, it may seem as if there is nothing to help you indicate how large objects should be. You may be asking "How big should my character be?" or "How do I determine how large objects in my game should be?" What follows are a few suggestions to help you size your objects.

### Identify the Most Influential Objects

One of the most common approaches is to identify an object as the determining factor for the scale of the other objects. This object (or group of objects) will be used as a reference point when scaling other objects. Two common choices are the player-controlled character and the tile size of the level. The character is a good choice because often times levels are built around the size of the character. Areas must be tall enough for the character to walk through, pits must be the right size so that players can jump over them, and ledges must be low enough so the player can jump up or grab onto them. Using the character as the reference object for scale is generally recommended in games where the player and environment will interact frequently, like in platformers. Another option is to decide on a tile size for the level. The tile size will determine the size of most Sprites used in the level. In this case, objects will generally be scaled to fit with the size of the rest of the level. For example, in a top down role playing game (RPG), the character is usually one or two tiles tall.

### Use Unit Sizes

Although the SpriteEditor provides a lot of support in assembling levels without having to manually set size and position values, it is very helpful to use scales that are whole numbers - especially for tilemaps. That is, when creating a tilemap, consider having your Sprites have a scale of 1. This makes the math very simple - all objects will be exactly 2 units away from neighbors. This will also help you position objects when you manually have to place them. Furthermore, moving on a tilemap with a unit size simplifies code and can help optimize pathfinding.

### Look at Visible Area

The visible screen area can help you decide how large objects should be. In code, the visible area can be determined as follows:

    Camera camera = SpriteManager.Camera;

    float leftBound = camera.X - camera.RelativeXEdgeAt(absoluteZValue);
    float rightBound = camera.X + camera.RelativeXEdgeAt(absoluteZValue);

    float topBound = camera.Y + camera.RelativeYEdgeAt(absoluteZValue);
    float bottomBound = camera.Y - camera.RelativeYEdgeAt(absoluteZValue);

Of course, adding a Sprite and running the code can give you a visual indication of the size. Another good option is to run the SpriteEditor, add a Sprite, and turn on the camera bounds, as explained [here](/frb/docs/index.php?title=SpriteEditor_Camera "SpriteEditor Camera").

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
