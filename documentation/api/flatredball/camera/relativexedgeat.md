## Introduction

The RelativeXEdgeAt and RelativeYEdgeAt methods can provide the distance in world coordinates from the center of the screen to the edge of the screen at a given Z position.

## Understanding RelativeXEdgeAt and RelativeYEdgeAt

If your game is using a 3D camera, then objects in the game world are viewed with a 3D perspective. The result of having a perspective view is that objects which are far from the camera will appear smaller than objects which are close to the camera. The amount that is visible in the world is controlled by the Camera's [FieldOfView](/frb/docs/index.php?title=FlatRedBall.Camera.FieldOfView "FlatRedBall.Camera.FieldOfView") property: ![FieldOfView.png](/media/migrated_media-FieldOfView.png) Notice that the further away an object is from the camera (the further to the right on the picture above) the smaller portion of the visible area it will take. In other words,observe the redball Sprite in the image above. You'll notice that it takes up very little space relative to the view height (the distance between the top and the bottom lines). But what happens if the Sprite comes closer to the Camera? ![SpriteMovedClose.png](/media/migrated_media-SpriteMovedClose.png) At this point the Sprite is so close that it touches the top and the bottom of the view boundaries. In other words, this would result in the Sprite being as large as the entire screen. It's important to notice that in world coordinates the Sprite actually didn't change size. Instead, it just changed how close it was to the Camera, making it appear larger. We can then apply this knowledge to draw another conclusion. When far away, the Sprite was very small. So small that we could have stacked numerous Sprites on top of each other. Let's say that the Sprite has a ScaleY of 1, meaning it is 2 units tall. If we were able to stack 5 Sprites on top of each other at the original distance, then we'd be able to approximate the view height to about 10 units:

    heightOfEachSprite * numberOfSpritesThatFitOnScreen = viewHeight

But at a closer distance to the Camera, we can only fit one Sprite. That means that in the second image, the horizontal view height is only 2 units. This relationship of having a smaller view height (and width) holds linearly. That means that at two times the distance, the view height and width double. At half the distance the view height and width are also cut in half. To take it to the limits, that also means that at an infinite number of units away, the view is also infinitely wide and tall. That's not really practical, but it can help your realize that as you move far away from the Camera, more and more can be seen. The other end of the limit is at 0 units away from the Camera. At 0 units away (the point where the lines meet in our images above, the distance between the top and bottom line is 0. That means that at 0 units from the camera nothing is visible. Since RelativeXEdgeAt and RelativeYEdgeAt measure the distance from the center of the screen to the edge of the Screen (which is half of the distance from one edge to the other) then they also linearly follow this relationship. Therefore, if the Z value that you pass to these methods is further away, you will get a greater number, while if it's closer to the Camera you'll get a smaller number. Passing a Z value that is equal to the Camera's Z value will return a value of 0.

## Code Example

When the Camera shows a 3D view, then the minimum and maximum visible X an Y values depend on the distance away from the Camera. The following code uses the RelativeXEdgeAt and RelativeYEdgeAt to determine the distance of the edges of the screen relative to the center of the camera. These values are used to size a Sprite so it takes up the entire screen.

     Sprite sprite = SpriteManager.AddSprite("redball.bmp");
     sprite.X = SpriteManager.Camera.X;
     sprite.Y = SpriteManager.Camera.Y;

     sprite.ScaleX = SpriteManager.Camera.RelativeXEdgeAt(sprite.Z);
     sprite.ScaleY = SpriteManager.Camera.RelativeYEdgeAt(sprite.Z);

![SpriteSizedToScreen.png](/media/migrated_media-SpriteSizedToScreen.png) ![CameraDiagram.png](/media/migrated_media-CameraDiagram.png) In general, the edges of the camera at a given Z can be found by the following code:

     Camera camera = SpriteManager.Camera;
     float zPosition = 0; // Default Z value for all placed objects

     float leftEdge   = camera.X - camera.RelativeXEdgeAt(zPosition);
     float rightEdge  = camera.X + camera.RelativeXEdgeAt(zPosition);
     float bottomEdge = camera.Y - camera.RelativeYEdgeAt(zPosition);
     float topEdge    = camera.Y + camera.RelativeYEdgeAt(zPosition);
