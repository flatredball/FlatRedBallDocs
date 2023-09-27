## Introduction

The Camera class inherits from the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") class, so it can use the AttachTo function. For general information on AttachTo, see the [PositionedObject.AttachTo](/frb/docs/index.php?title=FlatRedBall.PositionedObject.AttachTo "FlatRedBall.PositionedObject.AttachTo") page.

## Attaching a Camera to another object

The simplest way to have the Camera follow an object is to attach the Camera to the object. However, if you do this, you will need to make sure to have the Camera's RelativeZ be a positive value so that the Camera isn't at the same Z value as the object it is attached to. For example, the following code attaches a Camera to a PlayerInstance - which is assumed to be a PositionedObject:

    SpriteManager.Camera.AttachTo(PlayerInstance, true);
    SpriteManager.Camera.RelativeX = 0;
    SpriteManager.Camera.RelativeY = 0;
    SpriteManager.Camera.RelativeZ = 40;

## AttachTo vs. Manual Camera Following

Attaching a Camera to another PositionedObject (like an Entity instance) is the easiest way to have the Camera follow on object; however, it is rather limited in its movement. Most modern, professional games do not attach the Camera to the player. The reason is this results in an unnatural form of movement. Rather, most modern games will do the following:

-   Perform smoothing in the movement - often the Camera may lag behind player actions
-   Looking ahead towards where the player is facing
-   Adjusting to prevent the "end of the world" from being seen
-   Scripted movement such as zooming out or moving on game events like when entering a new environment or when a boss appears

Therefore, attaching the Camera to an object is a good initial following implementation, but you should consider replacing this with a more advanced implementation as your game moves further along.
