## Introduction

The IgnoresParentVisibility property controls whether an IVisible instance's visibility is impacted by its parent's visibility. If an IVisible doesn't have a parent, then the IgnoresParentVisibility property has no impact. IgnoresParentVisibility defaults to false, meaning that parent visibility impacts a child's visibility. Setting this value to true makes an IVisible's Visible property ultimately determine whether it appears on screen.

## Code Example

The following example creates four Sprites. Two of the Sprites are parents, two are children of their respective parent. spriteChildB has its IgnoresParentVisibility set to true, meaning it will still be visible desipite its parent being invisible. Since spriteParentA is invisible, spriteChildA will also be invisible.

    Sprite spriteParentA = SpriteManager.AddSprite("redball.bmp");
    Sprite spriteChildA = SpriteManager.AddSprite("redball.bmp");
    spriteParentA.TextureScale = 1;
    spriteChildA.TextureScale = 1;

    spriteChildA.AttachTo(spriteParentA, false);
    spriteChildA.RelativeX = 30;

    Sprite spriteParentB = SpriteManager.AddSprite("redball.bmp");
    Sprite spriteChildB = SpriteManager.AddSprite("redball.bmp");
    spriteParentB.Y = 30;
    spriteParentB.TextureScale = 1;
    spriteChildB.TextureScale = 1;

    spriteChildB.AttachTo(spriteParentB, false);
    spriteChildB.RelativeX = 30;
    spriteChildB.IgnoresParentVisibility = true;

    spriteParentA.Visible = false;
    spriteParentB.Visible = false;

![IgnoreParentVisibilityPic.PNG](/media/migrated_media-IgnoreParentVisibilityPic.PNG)
