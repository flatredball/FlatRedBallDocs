# layer

### Introduction

Each Camera has a list of Layers which can be used to draw objects which should only appear on one Camera. This is commonly used for HUD elements such as score and health. By default each Camera has one [Layer](../../../../frb/docs/index.php) (no code necessary to add this). Therefore, if using only one [Layer](../../../../frb/docs/index.php), then no layer instantiation is necessary. To create additional layers, see the [Camera's AddLayer method](../../../../frb/docs/index.php).

### Code Example

The following code creates two [Sprites](../../../../frb/docs/index.php), each which represents a player. The code splits the view into two screens and adds a [Text](../../../../frb/docs/index.php) object displaying which player's view is shown on the Camera layer. Notice that only one [Text](../../../../frb/docs/index.php) appears in each camera although there are two [Text](../../../../frb/docs/index.php) objects. The bool value can be changed to compare the behavior of Camera-layered [Text](../../../../frb/docs/index.php) and regular [Text](../../../../frb/docs/index.php).

```
string contentManagerName = "ContentManager";
// Create a 2nd camera:
SpriteManager.Cameras.Add(new Camera(contentManagerName));

// There are 2 cameras now.  One at index 0, one at index 1
// Make them split screen.
SpriteManager.Cameras[0].SetSplitScreenViewport(
   Camera.SplitScreenViewport.LeftHalf);
SpriteManager.Cameras[1].SetSplitScreenViewport(
   Camera.SplitScreenViewport.RightHalf);

// Create our "players"
Sprite player1 = SpriteManager.AddSprite("redball.bmp");
player1.X = -2;

// to distinguish player 1 from player 2
player1.ColorOperation = ColorOperation.Modulate;
player1.Green = 1;
player1.Red = 0;

Sprite player2 = SpriteManager.AddSprite("redball.bmp");
player2.X = 2;

// Now create the labels.
// This is included so that the two behaviors can easily be compared.
bool onCameraLayers = true;

Text player1Text;
Text player2Text;

if (onCameraLayers)
{
    player1Text = TextManager.AddText("Player 1", 
       SpriteManager.Cameras[0].Layer);
    player2Text = TextManager.AddText("Player 2", 
       SpriteManager.Cameras[1].Layer);
}
else
{
    player1Text = TextManager.AddText("Player 1");
    player2Text = TextManager.AddText("Player 2");
}

player1Text.AttachTo(SpriteManager.Cameras[0], true);
player1Text.RelativeY = 5;

player2Text.AttachTo(SpriteManager.Cameras[1], true);
player2Text.RelativeY = 5;

// Move the cameras so they can see the Player:
SpriteManager.Cameras[0].X = player1.X;
SpriteManager.Cameras[0].Y = player1.Y;

SpriteManager.Cameras[1].X = player2.X;
SpriteManager.Cameras[1].Y = player2.Y;
```

![CameraLayers.png](../../../../media/migrated_media-CameraLayers.png)
