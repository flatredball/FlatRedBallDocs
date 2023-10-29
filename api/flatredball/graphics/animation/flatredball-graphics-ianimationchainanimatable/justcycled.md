## Introduction

The JustCycled property is a property which is usually false, but will be set to true when an animation either finishes or cycles. This can be used to perform logic whenever an AnimationChain ends. By default, objects (such as Sprites) which play animations will automatically loop. When this happens, the object begins displaying the first frame in the animation. When this occurs, the JustCycled property will be true. Keep in mind that when this value is set to true, the object will display the first frame of animation that frame. It is possible to prevent this by performing logic (such as destroying the object) when this is true.

## Code Example

The JustCycled property reports whether an object that is displaying an AnimationChain has just reached the end of an animation and has cycled to the beginning. You can perform logic in response this being set to true. The following code assumes MySprite is a valid Sprite. The if statement will trigger when the Sprite completes.

    // assume MySprite is a valid Sprite that is animating
    if(MySprite.JustCycled)
    {
       // code goes here.
    }

## Using JustCycled to play an animation just one time

JustCycled can be used to play an animation once, then stop the animation when it's cycled. For this example we'll use an animating Sprite called MySprite:

    if(MySprite.JustCycled)
    {
       MySprite.Animate = false;
       // The sprite animation will have cycled back to the first frame
       // To keep it at the last frame:
       MySprite.CurrentFrameIndex = MySprite.CurrentChain.Count - 1;
    }

## JustCycled does not change after setting a new AnimationChain

If you are changing which animation an object is showing when JustCycled is set to true, keep in mind that JustCycled will stay true for the entire frame, regardless of whether you change chains in code. For example:

    // This code checks to see if it's time to play the PerformPunch animation
    // by testing if the Sprite has just finished cycling...
    if(sprite.JustCycled && sprite.CurrentChainName == "StartPunch")
    {
        // ... if so, then the PerformPunch animation is set...
        sprite.CurrentChainName = "PerformPunch";
        // ... however, JustCycled is still true at this point...
    }
    // ... which means this if-statement will always evaluate to true immediately
    if(sprite.JustCycled && sprite.CurrentChainName == "PerformPunch")
    {
        // ... and the Sprite will immediately go into the Idle animation
        sprite.CurrentChainName = "Idle";
    }

## JustCycled and CurrentFrameIndex

When JustCycled is true and if the displayed object has its Cycling set to true, then CurrentFrameIndex will be 0 (unless an animation is playing backwards). In a typical setup (in an unmodified FlatRedBall template), the FlatRedBall Engine will perform its logic before custom game logic is executed every frame. This means that if JustCycled is true, custom code will have an opportunity to react to the cycle before the animation visually starts over. For example, consider this code:

    if(SpriteInstance.JustCycled)
    {
       SpriteInstance.Visible = false;
    }
    <pre>

    The code above will hide the Sprite after it has cycled, so the first frame of the animation will not show again.
