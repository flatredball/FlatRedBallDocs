# AnimationController

### Introduction

The AnimationController class enables a game project to define animation logic using a modular approach as compared to a long chain of if/else if statements. The AnimationController was initially created to enable generated code to define animations while still allowing custom code to inject new animation behavior. Since its creation, the AnimationController has grown in capability, and it is currently the recommended way to create animation-assigning logic.

### AnimationController Benefits

To help explain the benefit of using the AnimationController, consider the following code. It is typical code for controlling the animation for a character that can walk or stand idle in two directions (left and right)

```csharp
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

Although the logic for setting the animationToSet is fairly simple, it suffers from not being very modular. That is, whether to assign the idle animations depends on the logic for whether to set the walking animations and whether the player is taking damage. Larger projects may want to organize logic for different types of animation assignment, or even take advantage of code generation for animation assignments. AnimationControllers provide a standard way to separate your animation code into modular pieces of code.

### Using AnimationLayer for Animation Logic

We can think of the code above as being organized into three layers. The top layer (the layer which has the first opportunity to set the animation) sets the taking damage animations. If it the top layer does not set an animation, then the if-check for setting the walk animations is performed. Finally if neither of the first two blocks set animations (which happens when the player is not taking damage and is walking less than 1 unit per second), then the bottom layer can set the idle animation. Games may have animations organized into multiple layers, where each layer has higher priority than layers underneath. For example the code above may would have the following layers:

* TakeDamageAnimations
* RunAnimations
* IdleAnimations

In plain English this can be represented as:

> If the player is taking damage, show damage animations. Otherwise... If the player is running, show the run animations. Otherwise... Show the Idle animations

Using an AnimationController is similar to writing a series of if/else if statements, but each layer can be independently defined in its own function, making the code more modular. For example, the above code could be rewritten using an AnimationController as shown in the following code:

```csharp
AnimationController controller;

void CustomInitialize()
{
    // assuming this.Sprite is a valid sprite. The argument tells the controller
    // what visual object to animate
    controller = new AnimationController(this.Sprite);

    // Layers are added in order of low->high priority
    var idleLayer = controller.AddLayer();
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

    var runningLayer = controller.AddLayer();
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

    var damageLayer = controller.AddLayer();
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
}

void CustomActivity(bool firstTimeCalled)
{
    controller.Activity();
}
```

The order in which the AnimationLayer instances are added controls the priority. The first layer added has the opportunity to set an animation. If its `EveryFrameAction` returns a non-null value, then that layer's animation is assigned. If the layer returns null, then the next layer's `EveryFrameAction` will be performed, and so on.

### Modifying Layer Order

The code above which introduces how to add layers using AddLayer may seem similar to a similar if/else-if block. In fact, the order that AddLayer is called controls the priority of animations, so the AddLayer calls must be performed in this particular order. However, the benefit of the AnimationController is that layers can be added, removed, and reordered.

The AnimationController exposes its Layers property which can be used to perform any standard list operation. For example, consider a game where a certain type of enemy entity plays an animation when standing still and reloading. For this example we will assume that the derived enemy inherits from the base entity, and that the base animation logic should still apply. However, this derived enemy will check if it is reloading, and if so then it will play its reloading animation.

In this case the reloading animation has higher priority than the idle animations, but lower priority than walking and taking damage. To inject the animation, the following code may be added to the derived entity's CustomInitialize:

```csharp
void CustomInitialize()
{
    var reloadLayer = new AnimationLayer();
    reloadLayer.EveryFrameAction = () =>
    {
        if(IsReloading)
        {
            if(this.Direction == Direction.Left)
            {
                return "ReloadLeft";
            }
            else
            {
                return "ReloadRight";
            }
        }
        return null; 
    }
    // We can insert the layer at the desired index to control priority:
    controller.Insert(1, reloadLayer);
}
```

Note that this code assumes that the controller is either public or protected so that the derived entity can access it. This may be done in custom code by modifying the controller definition, or if the AnimationController is added through the FlatRedBall entity, then its ExposedInDerived property can be set to true.

Also, this code uses the Insert method with a _magic number_ for the sake of simplicity, but a typical game may assign the Name property on layers, and find the index of the `"Idle"` AnimationLayer to dynamically insert the new reload layer at the correct index.
