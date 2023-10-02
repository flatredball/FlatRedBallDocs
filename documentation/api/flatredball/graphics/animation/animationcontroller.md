# animationcontroller

### Introduction

The AnimationController class enables a game project to split up its animation assignment, making code more modular and enabling Glue generated code to inject standard animation code into a game. Without the AnimationController (or similar code structure), animation code tends to reside in a large if/else if block of code. Breaking this code up enables the insertion of standard animation code into a game (such as by Glue).

### AnimationController Benefits

To help explain the benefit of using the AnimationController, consider the following code. It is typical code for controlling the animation for a character that can walk or stand idle in two directions (left and right)

```lang:c#
// Assuming "this" is a character entity
string animationToSet = null;

const float minMovementForWalkAnimation = 1;

if(IsTakingDamage)
{
  if(this.Direction == Direction.Left)
  {
    animationToSet = "TakeDamageLeft";
  }
  else
  {
    animationToSet = "TakeDamageRight";
  }
}
else if(Math.Abs(this.XVelocity) > minMovementForWalkAnimation)
{
  if(this.Direction == Direction.Left)
  {
    animationToSet = "WalkLeft";
  }
  else
  {
    animationToSet = "WalkRight";
  }
}
else
{
  if(this.Direction == Direction.Left)
  {
    animationToSet = "IdleLeft";
  }
  else
  {
    animationToSet = "IdleRight";
  }
}
```

Although the logic for setting the animationToSet is fairly simple, it suffers from not being very modular. That is, the logic for whether to display the idle animations depends on the logic above for whether to set the walking animations and whether the player is taking damage. Larger projects may want to organize logic for different types of animation assignment, or even take advantage of Glue code generation for animation assignments. AnimationControllers provide a standard way to separate your animation code into separate objects.

### Using AnimationLayer for Animation Logic

We can think of the code above as being organized into three layers. The top layer (the layer which has the first opportunity to set the animation) sets the taking damage animations. If it the top layer does not set an animation, then the walk logic is performed. Finally if neither of the first two blocks set animations (which happens when the player is not taking damage and is walking less than 1 unit per second), then the bottom layer can set the idle animation. Games may have animations organized into multiple layers, where each layer has higher priority than layers underneath. For example the code above may would have the following layers:

* TakeDamageAnimations
* RunAnimations
* IdleAnimations

In plain English this can be represented as:

> If the player is taking damage, show damage animations. Otherwise... If the player is running, show the run animations. Otherwise... Show the Idle animations

Using an AnimationController is similar to writing a series of if/else if statements, but each layer can be independently defined in its own function, making the code more modular. For example, the above code could be rewritten using an AnimationController as shown in the following code:

```lang:c#
AnimationController controller;

void CustomInitialize()
{
    // assuming this.Sprite is a valid sprite. The argument tells the controller
    // what visual object to animate
    controller = new AnimationController(this.Sprite);

    // Layers are added in order of low->high priority
    var idleLayer = new AnimationLayer();
    idleLayer.EveryFrameAction = () =>
    {
        if (this.Direction == Direction.Left)
        {
            return "IdleLeft";
        }
        else
        {
            return "IdleRight";
        }
    };
    controller.Layers.Add(idleLayer);

    var runningLayer = new AnimationLayer();
    runningLayer.EveryFrameAction = () =>
    {
        const float minMovementForWalkAnimation = 1;
        if (Math.Abs(this.XVelocity) > minMovementForWalkAnimation)
        {
            if (this.Direction == Direction.Left)
            {
                return "WalkLeft";
            }
            else
            {
                return "WalkRight";
            }
        }
        return null;
    };
    controller.Layers.Add(runningLayer);

    var damageLayer = new AnimationLayer();
    damageLayer.EveryFrameAction = () =>
    {
        if (IsTakingDamage)
        {
            if (this.Direction == Direction.Left)
            {
                return "TakeDamageLeft";
            }
            else
            {
                return "TakeDamageRight";
            }
        }
        return null;
    };
    controller.Layers.Add(damageLayer);




}

void CustomActivity(bool firstTimeCalled)
{
    controller.Activity();
}
```

The order in which the AnimationLayer instances are added controls the priority. The first layer added has the opportunity to set an animation. If its EveryFrameAction returns a non-null value, then that layer's animation is assigned. If the layer returns null, then the next layer's EveryFrameAction will be performed, and so on. &#x20;
