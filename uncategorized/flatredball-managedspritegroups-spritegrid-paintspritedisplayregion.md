# flatredball-managedspritegroups-spritegrid-paintspritedisplayregion

### Introduction

The PaintSpriteDisplayRegion method can be used to apply permanent texture coordinates to the Sprite found at the argument position. Calling this method will permanently modify the Sprite's texture coordinates, just like the [PaintSprite](../frb/docs/index.php#SpriteGrids\_and\_Textures) method permanently modifies the texture at the argument location. In other words, [Sprites](../frb/docs/index.php) which are painted by a display region will always show that display region even if the [Camera](../frb/docs/index.php) moves the [Sprite](../frb/docs/index.php) off screen, then back on.

However, this only works on sprites that are currently in view. If you are trying to change the texture coordinates of a sprite that is not in view, you must use the DisplayRegionGrid.PaintGridAtPosition method instead.

### Code Example

The following code creates a SpriteGrid then paints the center [Sprites](../frb/docs/index.php) so that it only shows the top/left corner of the redball graphic. This technique can be used to paint SpriteGrids with parts of a Texture2D. One common example of such an implementation is when SpriteGrids represent tile maps and all terrain textures are located in one file.

```
Sprite blueprintSprite = new Sprite();
blueprintSprite.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

SpriteGrid spriteGrid = new SpriteGrid(SpriteManager.Camera, SpriteGrid.Plane.XY,
    blueprintSprite);

spriteGrid.XLeftBound = -10;
spriteGrid.XRightBound = 10;
spriteGrid.YTopBound = 10;
spriteGrid.YBottomBound = -10;

spriteGrid.PopulateGrid();

// We'll paint the Sprite so it shows the top-left
// of the red ball:
FloatRectangle floatRectangle = new FloatRectangle(
    0,   // top
    .5f, // bottom
    0,   // left
    .5f);// right

spriteGrid.PaintSpriteDisplayRegion(
    0, 0, 0, ref floatRectangle);
```

![SpriteDisplayRegion.png](../media/migrated\_media-SpriteDisplayRegion.png)
