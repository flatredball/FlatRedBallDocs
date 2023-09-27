## Introduction

The view of your game is determined by the position of the main Camera. You can change your current view with the mouse, keyboard, and with the SpriteEditor's GUI.

## Left handed vs. right handed

Unfortunately different versions of FlatRedBall use a different coordinate system. The SpriteEditor uses FlatRedBall MDX, which uses a "left handed" system, while FlatRedBall XNA and FlatSilverBall use a "right handed" system. What does this mean for you?

As far as the Camera is concerned, this means you need to invert your Z value if you are manually setting the value when moving between the different coordinate systems. In other words, the default Camera position in the SpriteEditor is (0,0,-40). The default in FlatRedBall XNA and FlatSilverBall is (0,0,40).

## Scene Camera

The scene camera displays the visible bounds of the scene at a particular Z value. The scene camera can help give you an indication of how large objects should be and is very useful when designing levels and menus.

To turn on the scene camera, bring up the Camera window by clicking on the Camera Properties button. In the list box, select the Scene Camera, then click the toggle button. The bounds may actually match the SpriteEditor bounds, so you may have to zoom out (mouse wheel or - button on keyboard) to see the bounds.
