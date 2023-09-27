## Introduction

Instructions are objects which store a value that will be set to a particular property at a given time. In other words, Instructions can be used to do something at some fixed time in the future.

These are useful for creating cut scenes and performing predictable behavior without explicitly holding on to references to update objects every frame.

Instructions can be used to:

-   Set fields or properties
-   Call methods
-   Perform any custom code that you write

## Usage

FlatRedBall objects which implement the [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") interface are designed to store and execute instructions - as long as they belong to a manager which performs this behavior automatically. However, Instructions can operate on any object - not just [IInstructables](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable").

For more information, see the [IInstructable wiki entry](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable").

## How Instructions work under the hood

In most cases simply creating a new instance of an instruction and adding it to a managed [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") like a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") or [PositionedModel](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel "FlatRedBall.Graphics.Model.PositionedModel") is all that's needed. The engine will handle executing the instruction then cleaning it up afterwards. But if you're looking to work more with instructions you might be asking how instructions are executed and where what happens to them after execution.

### Instructions and automatic execution in FlatRedBall

As far as implementation in the FlatRedBall Engine, Instructions can exist in one of two locations:

1.  Inside a [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable")
2.  Inside the [InstructionManager](/frb/docs/index.php?title=FlatRedBall.Instructions.Instructions.InstructionManager&action=edit&redlink=1 "FlatRedBall.Instructions.Instructions.InstructionManager (page does not exist)")

The best place to put an instruction is in an [IInstructable's](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") Instructions property. If this [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") is managed by the engine, then you don't have to worry about doing anything to execute or remove the Instructions. It all happens automatically.

Another benefit of putting an Instruction in an [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") is that "ownership" of instructions is defined. This will make more sense when we discuss the second option of putting Instructions in the [InstructionManager](/frb/docs/index.php?title=FlatRedBall.Instructions.Instructions.InstructionManager&action=edit&redlink=1 "FlatRedBall.Instructions.Instructions.InstructionManager (page does not exist)").

If you are dealing with an object which is not an [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable") (such as [Screens](/frb/docs/index.php?title=Screen "Screen"), then you can use the [InstructionManager](/frb/docs/index.php?title=FlatRedBall.Instructions.Instructions.InstructionManager&action=edit&redlink=1 "FlatRedBall.Instructions.Instructions.InstructionManager (page does not exist)") to store and execute your instructions appropriately. The [InstructionManager](/frb/docs/index.php?title=FlatRedBall.Instructions.Instructions.InstructionManager&action=edit&redlink=1 "FlatRedBall.Instructions.Instructions.InstructionManager (page does not exist)") exposes a property called [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.InstructionManager.Instructions "FlatRedBall.Instructions.InstructionManager.Instructions") which holds and can execute instructions. While this is convenient, we don't recommend putting Instructions in this list if they can be added to an [IInstructable](/frb/docs/index.php?title=FlatRedBall.Instructions.IInstructable "FlatRedBall.Instructions.IInstructable"). The reason for this is the [InstructionManager](/frb/docs/index.php?title=FlatRedBall.Instructions.Instructions.InstructionManager&action=edit&redlink=1 "FlatRedBall.Instructions.Instructions.InstructionManager (page does not exist)") only exposes one list, so if you have multiple objects which use Instructions, all of their Instructions will be mixed into the same list. This can make management and debugging more difficult.

### Manually executing and destroying Instructions

To understand how to manually work with Instructions, the first thing to keep in mind is that Instructions only do whatever is in their Execute method. For example, the following code creates an instruction that will set the X of the given PositionedObject to 5 in 10 seconds:

    Instruction<PositionedObject, float> instruction = 
       new Instruction<PositionedObject, float>(
                   objectInstance, "X", 5, 
                   TimeManager.CurrentTime + 10));

At this point, the Instruction can manually be executed, and it can be done so multiple times over and over:

    instruction.Execute();
    // it's still valid, we can do it again
    instruction.Execute();
    // we can do this over and over - the Instruction does not destroy or invalidate itself
    instruction.Execute();

So, the question is then - how do you destroy an Instruction? Well, you actually don't have to do anything - unless of course you've written a custom Instruction that requires cleanup.

In other words, simply let the object fall out of scope, or remove it from the list(s) that it belongs to, and it'll be gone.

Of course, if you want to test time, you can compare the [TimeManager's](/frb/docs/index.php?title=FlatRedBall.TimeManager "FlatRedBall.TimeManager") CurrentTime to the Instruction's TimeToExecute:

    if(instruction.TimeToExecute <= TimeManager.CurrentTime)
    {
        instruction.Execute();
    }

The [InstructionList](/frb/docs/index.php?title=FlatRedBall.Instructions.InstructionList "FlatRedBall.Instructions.InstructionList") is a class designed especially to handle lists of Instructions and it provides a number of methods which can simplify manual management of Instructions. For more information, see the [InstructionList entry](/frb/docs/index.php?title=FlatRedBall.Instructions.InstructionList "FlatRedBall.Instructions.InstructionList").

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
