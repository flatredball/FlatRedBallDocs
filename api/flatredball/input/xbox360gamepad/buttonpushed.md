# ButtonPushed

### Introduction

The ButtonPushed method returns whether a particular button was pushed. A "push" is defined as occurring when a button is not down the previous frame, but is down the current frame.

### Code Example - Checking ButtonPushed

The following code might be used to cause an Entity to jump when the A button is pushed:

```csharp
if(InputManager.Xbox360GamePads[0].ButtonPushed(Button.A))
{
   this.Jump();
}
```

Alternatively check the ButtonPosition.

```csharp
if(InputManager.Xbox360GamePads[0].ButtonPushed(ButtonPosition.FaceDown))
{
   this.Jump();
}
```
