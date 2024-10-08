# StaticMethodInstruction

**Note** - StaticMethodInstruction is now marked as obsolete in favor of using [DelegateInstruction](delegateinstruction.md) and [Call](iinstructable/call.md).

### Introduction

StaticMethodInstructions can be used to call methods belonging to static classes. This class is useful for calling methods belonging to FlatRedBall manager classes like the [SpriteManager](../../../frb/docs/index.php).

### Creating a StaticMethodInstruction

The following code creates an instruction that will add a Sprite to the scene after 2 seconds. [Instructions](../../../frb/docs/index.php) can be added to the [InstructionManager](../../../frb/docs/index.php) to be executed automatically. Add the following using statements:

```
using System.Reflection;
using FlatRedBall.Instructions;
```

Add the following to Initialize after initializing FlatRedBall:

```
MethodInfo methodInfo = typeof(SpriteManager).GetMethod("AddSprite", new Type[]{ typeof(string)});

StaticMethodInstruction addingSprite = new StaticMethodInstruction(
    methodInfo, new object[]{"redball.bmp"}, TimeManager.CurrentTime + 2);

InstructionManager.Instructions.Add(addingSprite);
```

![SpriteAddedThroughInstruction.png](../../../.gitbook/assets/migrated\_media-SpriteAddedThroughInstruction.png)

Did this article leave any questions unanswered? Post any question in our [forums](../../../frb/forum.md) for a rapid response.
