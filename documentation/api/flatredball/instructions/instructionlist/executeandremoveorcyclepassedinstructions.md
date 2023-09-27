## Introduction

The ExecuteAndRemoveOrCyclePassedInstructions will execute instructions which should be executed based off of the current time, then either remove or cycle any executed instructions. This method allows manual execution of [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction "FlatRedBall.Instructions.Instruction") without requiring the user to write the logic of time testing and cycling.

This method is used internally by the FlatRedBall Engine so calling it will guarantee behavior which matches the engine's behavior regarding [Instruction](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction "FlatRedBall.Instructions.Instruction") management.

## Code Example

Assuming that instructionList is a valid instance, the following code can be called every frame to execute and remove [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction "FlatRedBall.Instructions.Instruction") from the instructionList:

    // You can use the TimeManager's CurrentTime as default:
    instructionList.ExecuteAndRemoveOrCyclePassedInstructions();
    // Or you can supply your own time:
    double overridingTime = 4.52f;
    instructionList.ExecuteAndRemoveOrCyclePassedInstructions(overridingTime);
