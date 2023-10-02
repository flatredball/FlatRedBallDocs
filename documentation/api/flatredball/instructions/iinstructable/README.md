# iinstructable

### Introduction

The IInstructable interface specifies that an object can store instructions in an InstructionList. Most FlatRedBall classes which implement the IInstructable interface have managers which handle [Instruction](../../../../../frb/docs/index.php) execution. [Instructions](../../../../../frb/docs/index.php) allow the setting of properties at a predetermined time in the future without any explicit management.

### Using Instructions

The FlatRedBall Engine provides a generic [Instruction](../../../../../frb/docs/index.php) which can be used to set any property. The following code moves a Sprite in a square when the space bar is pushed.

```
// Add this using statement
using FlatRedBall.Instructions;

// Declare the Sprite instance at class scope
Sprite sprite;

// Replace Initialize with the following:
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

    base.Initialize();

    sprite = SpriteManager.AddSprite("redball.bmp");
}

// Replace Update with the following.
protected override void Update(GameTime gameTime)
{
    FlatRedBallServices.Update(gameTime);

    if (InputManager.Keyboard.KeyPushed(Keys.Space) && 
        sprite.Instructions.Count == 0)
    {
        float secondsToTake = 4.0f;
        float squareWidth = 10;

        float velocity = squareWidth * 4.0f / secondsToTake;

        // Move right.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "XVelocity", velocity, 
                TimeManager.CurrentTime + 0));

        // Stop moving to the right.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "XVelocity", 0, 
                TimeManager.CurrentTime + secondsToTake / 4.0f));
        // Move down.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "YVelocity", -velocity, 
                TimeManager.CurrentTime + secondsToTake / 4.0f));

        // Stop moving down.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "YVelocity", 0, 
                TimeManager.CurrentTime + 2 * secondsToTake / 4.0f));
        // Move left.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "XVelocity", -velocity, 
                TimeManager.CurrentTime + 2 * secondsToTake / 4.0f));

        // Stop moving left;
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "XVelocity", 0, 
                TimeManager.CurrentTime + 3 * secondsToTake / 4.0f));
        // Move up.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "YVelocity", velocity, 
                TimeManager.CurrentTime + 3 * secondsToTake / 4.0f));

        // Stop moving up at the end.
        sprite.Instructions.Add(
            new Instruction<Sprite, float>(
                sprite, "YVelocity", 0, 
                TimeManager.CurrentTime + 4 * secondsToTake / 4.0f));
    }

    base.Update(gameTime);
}
```

### Calling instructions on the object that will be modified

Instructions must be called on the object that will be modified. You cannot use the "dot" operator to set properties of embedded items. For example, the following is not valid:

```
// assume myScene is a valid Scene
Instruction instructionToExecute = 
    new Instruction<Scene, float>(   // NO NO NO - this is setting a property on a Sprite, not Scene
                myScene, 
                "Sprites[0].YVelocity", // NO NO NO - No [] or . allowed
                velocityToSet, 
                timeToExecuteAt);
```

Instead you should pass the instance as the first argument and have the property as the second argument:

```
Instruction instructionToExecute = 
    new Instruction<Sprite, float>(   
                myScene.Sprites[0], 
                "YVelocity",
                velocityToSet, 
                timeToExecuteAt);
```

### InstructionManager

The [InstructionManager](../../../../../frb/docs/index.php) provides methods for performing common behavior on different objects. See the [InstructionManager wiki entry](../../../../../frb/docs/index.php) for more information.

### IInstructable Members

* [FlatRedBall.Instructions.IInstructable.Call](../../../../../frb/docs/index.php)
* [FlatRedBall.Instructions.IInstructable.Instructions](../../../../../frb/docs/index.php)
* [FlatRedBall.Instructions.IInstructable.Set](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
