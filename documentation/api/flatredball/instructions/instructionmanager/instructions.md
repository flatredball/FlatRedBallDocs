## Introduction

The Instructions property is an exposed InstructionList which the InstructionManager will check and execute if according to the [TimeManager's](/frb/docs/index.php?title=FlatRedBall.TimeManager.md "FlatRedBall.TimeManager") CurrentTime property. Instructions which do not necessarily belong to an instance, or which are to be executed on an object which does not implement the [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") interface can be added to the InstructionManager's Instructions property for automatic execution.

## Code Example

Instructions can be directly added or removed from the InstructionManager.Instructions  list:

``` lang:c#
// Calls the EndGame method in 10 seconds:
var delegateInstruction = new DelegateInstruction( 
    () => EndGame(), 
    TimeManager.CurrentTime + 10);

InstructionManager.Instructions.Add(delegateInstruction);
```

## Execution Details

The InstructionManager will execute Instructions if the InstructionManager's IsExecutingInstructions property is true (default). The InstructionManager will automatically check the time of instructions and execute them.

## Common Usage

[Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction.md "FlatRedBall.Instructions.Instruction") are a common part of the FlatRedBall game engine, and many FlatRedBall objects implement the [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") interface. If an instruction is instantiated which should operate on an [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable"), then the instruction should be added to the [IInstructable's](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") Instructions property. This suggests that the [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") "owns" the instructions which will operate on it. Having each [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") contain [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction.md "FlatRedBall.Instructions.Instruction") which will operate on it can help improve debugging. Some objects, such as [Screens](/frb/docs/index.php?title=Screen.md "Screen") do not implement the [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable.md "FlatRedBall.Instructions.IInstructable") interface, or are not automatically managed by a manager. It is common practice to place [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction.md "FlatRedBall.Instructions.Instruction") which will operate on these objects in the InstructionManager's Instructions list. Instructions in this list will also automatically be executed, and provide a centralized, easy to use list for instructions. However, in general, use the Instructions property for individual objects if available before using the InstructionManager's Instructions list.

## Clearing all Instructions

You can clear all instructions by simply calling the Clear method on the Instructions object:

    InstructionManager.Instructions.Clear();
