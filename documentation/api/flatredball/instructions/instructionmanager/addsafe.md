# addsafe

### Introduction

The AddSafe method is a thread-safe way to add instructions to the engine. Typically "add" calls cannot be made on managers; however, the AddSafe method allows adding instructions from any thread.

### Code Example

The AddSafe method takes an [Instruction](../../../../../frb/docs/index.php) argument. The following code shows how to call AddSafe assuming you have a valid [Instruction](../../../../../frb/docs/index.php).

```
// Assumes instructionToAdd is a valid Instruction
InstructionManager.AddSafe(instructionToAdd);
```

### AddSafe and calling code on the primary thread

The AddSafe method can be called with an action to execute. This makes calling code on the primary thread easy:

```lang:c#
InstructionManager.AddSafe( ()=>
{
   // Do whatever you need to here
});
```

As mentioned above, objects cannot be added to managers on secondary threads. The following shows how to add a Sprite on the primary thread

```
InstructionManager.AddSafe(()=>SpriteManager.AddSprite("redball.bmp"));
```

**Code may execute next frame**

Since the InstructionManager only performs instruction execution one time per frame, your code may execute after instructions have been processed that frame. This means that your code may not execute until next frame.
