# methodinstruction

### Introduction

MethodInstructions are a way of calling a method at some time in the future. They can simplify the creation of effects and animation in game development. The [DelegateInstruction](../../../../frb/docs/index.php) provides the same functionality for simple cases.

### Using Method Instructions

There are a few things to remember when using MethodInstructions:

1. While MethodInstructions can be manually executed, the easiest way to use them is to add them to an [IInstructable](../../../../frb/docs/index.php) that is being managed such as a [Sprite](../../../../frb/docs/index.php). This way you don't have to manually watch for instructions to call them. The manager takes care of it for you!
2. MethodInstructions cannot call static methods. You'll see in the following example that SpriteManager.RemoveSprite needs to be wrapped in another method. Another alternative is to create a [StaticMethodInstruction](../../../../frb/docs/index.php).

The following code creates an effect that could be used for explosions when the user presses the space bar. The code does the following things:

* When the user presses the space bar, the code creates 8 instructions to create explosion [Sprites](../../../../frb/docs/index.php). The creation of these [Sprites](../../../../frb/docs/index.php) is delayed and controlled by the last argument of the MethodInstruction constructor.
* These instructions are added to the [InstructionManager](../../../../frb/docs/index.php) since there is no object around to "own" these Instructions.
* When a Sprite is created its properties are set and another MethodInstruction is created to remove the Sprite after 1 second.

Add the following using statement:

```
using FlatRedBall.Instructions;
using FlatRedBall.Input;
```

Add the following code to Update:

```
if (InputManager.Keyboard.KeyPushed(Keys.Space))
{
    for (int i = 0; i < 8; i++)
    {
        // This code uses "CreateExplosionSprite" which is the name of the
        // method to call.
        InstructionManager.Instructions.Add(
            new MethodInstruction<Game1>(
               this, // Instance to Game1
               "CreateExplosionSprite", // Method to call
               new object[0], // Argument List
               TimeManager.CurrentTime + i / 25.0f)); // When to call
    }
}
```

Add the two methods which will be used as MethodInstructions:

```
public void CreateExplosionSprite()
{
     Sprite sprite = SpriteManager.AddSprite("redball.bmp");
     sprite.ScaleXVelocity = 3;
     sprite.ScaleYVelocity = 3;

     sprite.AlphaRate = -1;

     // Give it a random position
     sprite.X = (float)(FlatRedBallServices.Random.NextDouble() * 3 - 1.5f);
     sprite.Y = (float)(FlatRedBallServices.Random.NextDouble() * 3 - 1.5f);

     sprite.Instructions.Add(
         new MethodInstruction<Game1>(
            this, // Instance to Game1
            "RemoveSprite", // Method to call
            new object[] { sprite }, // Argument List
            TimeManager.CurrentTime + 1)); // When to call

}

public void RemoveSprite(Sprite sprite)
{
    // Since we can't call static methods with MethodInstruction
    // we have to wrap this in an instance method.
    SpriteManager.RemoveSprite(sprite);
}
```

![MethodInstructions.png](../../../../media/migrated\_media-MethodInstructions.png)

### "arguments" argument

The third argument to the MethodInstruction constructor is an argument list. This argument list is an object array (object\[]) which stores the arguments.

For example, if you were calling a function called SetSpriteScaleAtTime which had the following signature:

```
public void SetSpriteScaleAtTime(Sprite sprite, float newScale, double timeToSet)
```

You may create an argument list as follows:

```
Sprite mySprite = SpriteManager.AddSprite("redball.bmp");
float newScale = 5;
double timeToSet = TimeManager.CurrentTime + 3;
object[] arguments = new object[]{mySprite, newScale, timeToSet};
```

### Using MethodInfo

MethodInstructions attempt to call methods using reflection. They obtain the method to call using the name of the method. However, if the method that you want to call has multiple overloads then you will need to supply a MethodInfo to tell which version of the method you want to call.

For example, let's say you are working with an [AxisAlignedRectangle](../../../../frb/docs/index.php) instance and you want to call CollideAgainst using a MethodInstruction. The following code can be used to call CollideAgainst against a Circle:

```
Type typeToCollideAgainst = typeof(Circle);
MethodInfo methodInfo = typeof(AxisAlignedRectangle).GetMethod(
    "CollideAgainst", 
    new Type[] { typeToCollideAgainst });

double whenToExecute = TimeManager.CurrentTime + 4;

FlatRedBall.Instructions.MethodInstruction mi = 
    new FlatRedBall.Instructions.MethodInstruction<AxisAlignedRectangle>(
            callingRectangle, 
            methodInfo,
            new object[] { circleToCallAgainst }, 
            whenToExecute);
```

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
