## Introduction

The Instructions member in an IInstructable represents all of the instructions which have been created and added to the IInstructable. Instructions can be added to the InstructionList a number of ways:

1.  Through a direct add, such as by calling:

        ObjectInstance.Instructions.Add(SomeInstruction);

2.  Through InstructionManager helper methods, such as by calling:

        InstructionManager.MoveToAccurate(ObjectInstance...

3.  Through the "fluent instruction" for instructions, such as by calling:

        ObjectInstance.Set("X").To(3.0f).After(1.0f);

## Clear

Instructions.Clear will remove all instructions which are held by an object. Clear can be used to cancel any existing instructions. For example, the following code will set an IInstructable to move to the X value ater 3 seconds, but then cancel that instruction and move it instead after 2 seconds.


    // This will set X to 4.0f after 3 seconds
    ObjectInstance.Set("X").To(4.0f).After(3);
    // This will cancel the movement:
    ObjectInstance.Instructions.Clear();
    // This will set the X to 5.0f after 2 seconds:
    ObjectInstance.Set("X").To(5.0f).After(2);
