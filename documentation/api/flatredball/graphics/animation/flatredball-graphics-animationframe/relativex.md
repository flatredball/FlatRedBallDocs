## Introduction

The RelativeX and RelativeY values in an AnimationFrame can be used to offset an animated object on a per-frame basis. This is useful if the images that are being used for the animation do not line up as desired. The relative values can be set by code or in the AnimationEditor.

## Requirements for use

Simply setting the RelativeX and RelativeY values on an AnimationFrame is not sufficient to change the position of an [IAnimationChainAnimatable](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.IAnimationChainAnimatable "FlatRedBall.Graphics.Animation.IAnimationChainAnimatable") (such as a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). The following conditions must be met:

-   The object (such as the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite")) that is displaying the animation must be attached to another PositionedObject.
-   The [UseAnimationRelativePosition](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.UseAnimationRelativePosition "FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.UseAnimationRelativePosition") property must be true.

If you are using objects created in Glue, then both of the above will usually be true.

## Example

The following code creates an AnimationFrame which displays the four quadrants of a redball.bmp graphic, then displays it in its entirety. The RelativeX and RelativeY values are used to offset the frames which display a single quadrant. Notice that the animated [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") must be attached to an object and that the [Sprite's](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") UseAnimationRelativePosition property must be set to true.

    // Create the animationChain
    AnimationChain animationChain = new AnimationChain();

    // Create the redball texture that will be used
    Texture2D redballTexture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

    // Add the 5 frames
    float frameLength = .1f; // in seconds
    AnimationFrame frame = new AnimationFrame(redballTexture, frameLength);
    animationChain.Add(frame); // this is the "whole ball" image

    frame = frame.Clone(); // same frame time, same texture
    frame.RightCoordinate = .5f;
    frame.BottomCoordinate = .5f;
    frame.RelativeX = -.5f;
    frame.RelativeY = .5f;
    animationChain.Add(frame); // top left quadrant

    frame = frame.Clone();
    frame.LeftCoordinate = .5f;
    frame.RightCoordinate = 1;
    // top and bottom are still the same - 0 and .5f respectively
    frame.RelativeX = .5f;
    // RelativeY still .5f like it should be for this frame
    animationChain.Add(frame); // top right quadrant

    frame = frame.Clone();
    // left and right are set ok from the cloned frame
    frame.TopCoordinate = .5f;
    frame.BottomCoordinate = 1;
    // RelativeX still .5f like it shoudl be for this frame
    frame.RelativeY = -.5f;
    animationChain.Add(frame); // bottom right quadrant

    frame = frame.Clone();
    // top and bottom are set ok from the cloned frame
    frame.LeftCoordinate = 0;
    frame.RightCoordinate = .5f;
    // RelativeY still -.5f like it shoudl be for this frame
    frame.RelativeX = -.5f;
    animationChain.Add(frame); // bottom right quadrant

    Sprite animatedSprite = SpriteManager.AddSprite(animationChain);
    // make sure to have the Sprite use the AnimationFrame's relative values:
    animatedSprite.UseAnimationRelativePosition = true;

    // Set the pixel size so it gets resized:
    // Make sure to use a float!!
    animatedSprite.PixelSize = 1.0f / redballTexture.Width;

    // Normally this'd be added to the SpriteManager,
    // but for this example it's not necessary.
    PositionedObject parent = new PositionedObject();

    animatedSprite.AttachTo(parent, false);

![AnimatedSprite.png](/media/migrated_media-AnimatedSprite.png)
