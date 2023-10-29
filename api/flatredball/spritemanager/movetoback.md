# movetoback

### Introduction

The MoveToBack and MoveToFront methods can be used to control the order that Layers are drawn. Layers will, by default, draw in the order that they are added to the engine. If you are using Glue, Layers are drawn top-to-bottom. More information on Layer ordering in Glue can be found [here](../../../../frb/docs/index.php).

### Code Example

The following code creates three layers, then moves the first Layer to the "front" so that it is drawn on top of the other two. Without calling MoveToFront, the Layer would be drawn behind the other two as opposed to in front.

```
Layer layer1 = SpriteManager.AddLayer(); // This is drawn first (behind the other two)
Layer layer2 = SpriteManager.AddLayer(); // This is drawn second (between the other two)
Layer layer3 = SpriteManager.AddLayer(); // This is drawn last (in front of the other two)

SpriteManager.MoveToFront(layer1); // This makes layer1 drawn last (in front of the other now
```
