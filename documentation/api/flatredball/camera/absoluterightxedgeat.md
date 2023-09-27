## Introduction

The "absolute edge" methods return the edge of the visible area at a given Z. There are four such methods:

1.  AbsoluteRightXEdgeAt
2.  AbsoluteLeftXEdgeAt
3.  AbsoluteTopYEdgeAt
4.  AbsoluteBottomYEdgeAt

## Z value argument

The absolute functions take a single argument - the Z value where the absolute values should be calculated. The reason this is necessary is because 3D cameras (by definition) use perspective. Therefore, the edge of the Camera changes as you move further away from the Camera. If you are positioning an object along the edges of the Camera, you will most likely want to use the Z of the object you are positioning as the argument to absolute functions. For an example, see the code in the section below.

## Code Example

The following code creates four Circles. Each one is colored differently to help identify it.

     Camera camera = Camera.Main;

     Circle rightCircle = ShapeManager.AddCircle();
     rightCircle.X = camera.AbsoluteRightXEdgeAt(0);
     rightCircle.Y = camera.Y;
     rightCircle.Color = Color.Red;

     Circle leftCircle = ShapeManager.AddCircle();
     leftCircle.X = camera.AbsoluteLeftXEdgeAt(0);
     leftCircle.Y = camera.Y;
     leftCircle.Color = Color.Green;

     Circle topCircle = ShapeManager.AddCircle();
     topCircle.X = camera.X;
     topCircle.Y = camera.AbsoluteTopYEdgeAt(0);
     topCircle.Color = Color.Yellow;

     Circle bottomCircle = ShapeManager.AddCircle();
     bottomCircle.X = camera.X;
     bottomCircle.Y = camera.AbsoluteBottomYEdgeAt(0);
     bottomCircle.Color = Color.Blue;

![AbsoluteEdges.png](/media/migrated_media-AbsoluteEdges.png)

## Detecting if an object is on screen

The edge values can be used to check if on screen. For example, the following code checks if a character's point is on screen. Since visual objects are usually larger than a single pixel, an additional buffer can be added.

``` lang:c#
float buffer = 16; // base this on the size of your object

bool isOnScreen = Character.X < Camera.Main.AbsoluteRightEdgeAt(0) + buffer &&
    Character.X > Camera.Main.AbsoluteLeftEdgeAt(0) - buffer &&
    Character.Y < Camera.Main.AbsoluteTopEdgeAt(0) + buffer &&
    Character.Y > Camera.Main.AbsoluteBottomEdgeAt(0) - buffer;
```

Note that the buffer value above may be required if your object does not have a Width property (such as if your object is an entity). If your object has a Width and Height property, like a Sprite, you can use that value as shown in the following code:

``` lang:c#
// This code assumes the Sprite is not rotated
float halfWidth = SpriteInstance.Width/2.0f;
float halfHeight = SpriteInstance.Height/2.0f;

bool isOnScreen = Character.X < Camera.Main.AbsoluteRightEdgeAt(0) + halfWidth &&
    Character.X > Camera.Main.AbsoluteLeftEdgeAt(0) - halfWidth &&
    Character.Y < Camera.Main.AbsoluteTopEdgeAt(0) + halfHeight &&
    Character.Y > Camera.Main.AbsoluteBottomEdgeAt(0) - halfHeight ;
```

 

## Edge values and attachments

If your Camera is attached to another object, you may need to call [FlatRedBall.Camera.ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.Camera.ForceUpdateDependencies.md "FlatRedBall.Camera.ForceUpdateDependencies") before asking the Camera for its absolute edge values. For example:

     Camera camera = Camera.Main;

     camera.ForceUpdateDependencies();
     float rightEdge = camera.AbsoluteRightXEdgeAt(0);
