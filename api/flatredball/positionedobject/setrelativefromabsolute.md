# setrelativefromabsolute

### Introduction

This method can be used to "update" relative values (rotation and position) of a child [PositionedObject](../../../../frb/docs/index.php) after modifying its absolute rotation or position values.

### Details

Although child absolute values are considered read-only (see [this page](../../../../frb/docs/index.php#Remember.2C_child_absolute_values_are_read-only)), this does not necessarily mean that the actual variable itself is read-only. Rather, before drawing occurs, the absolute values of all children are overwritten by their attachment logic. However, prior to drawing occurring, absolute values can be set and reset and used \*within that same frame\*. We can take advantage of this behavior by modifying the absolute values, then using those values to update the child's relative values so that the overwriting that occurs later will not end up changing the absolute values. In other words, we can use the SetRelativeFromAbsolute to reposition a child object in absolute space, then make those changes "stick".

### Code Example

This example creates two [Sprites](../../../../frb/docs/index.php) and attaches one to the other. The child will then be repositioned in absolute coordinates, then SetRelativeFromAbsolute will be called to modify its relative values so that the child remains in the position that it was placed: Add the following using statements:

```
using FlatRedBall.Graphics;
```

Add the following to Initialize after initializing FlatRedBall:

```
 Sprite parent = SpriteManager.AddSprite("redball.bmp");

 Sprite child = SpriteManager.AddSprite("redball.bmp");
 child.AttachTo(parent, false);

 // At this point, both child and parent have a position of (0,0,0)
 child.X = 9;
 child.Y = 10;
 // Right now the child really is positioned at (9,10,0).  If we did nothing more
 // the child would remain at this position until it is drawn, at which point
 // it would get repositioned back to (0,0,0) according to its parent's absolute
 // values and its own relative values...
 // BUT NOT SO FAST!  We can quickly modify the relative values right now before
 // any drawing occurs to change the relative values:
 child.SetRelativeFromAbsolute();
 // Now the child has the same absolute value (9,10,0), plus its relative values
 // have been modified so that it will stay in that same spot.
```

![SetRelativeFromAbsolute.png](../../../../media/migrated_media-SetRelativeFromAbsolute.png)

### Another way to think about it...

This code essentially makes the absolute values temporarily writable. The end result is the same as:

1. Detaching a child
2. Repositioning the child
3. Reattaching the child and passing true as the second (changeRelative) value
