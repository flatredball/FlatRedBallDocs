# PlayAnimation

### Introduction

PlayAnimation provides simple support for playing a Spine animation. More complex animations can be controlled by accessing the AnimationState object.

### Code Example - Playing an Animation

To play an animation, pass the name of the animation as a string, as shown in the following code:

```csharp
private void CustomActivity()
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        SpineDrawableBatch.PlayAnimation("SomeAnimation");
    }
}
```
