## Introduction

The DelegateInstruction provides a quick way to call methods at a future time. The DelegateInstruction is similar in function to the [MethodInstruction](/frb/docs/index.php?title=FlatRedBall.Instructions.MethodInstruction.md "FlatRedBall.Instructions.MethodInstruction") class; however, it has a simpler interface and can be easier to use for no-argument or one-argument methods. Note that the AddSafe method can be used to call delegate instructions on the primary thread: [/documentation/api/flatredball/flatredball-instructions/flatredball-instructions-instructionmanager/flatredball-instructions-instructionmanager-addsafe/.md](/documentation/api/flatredball/flatredball-instructions/flatredball-instructions-instructionmanager/flatredball-instructions-instructionmanager-addsafe/.md)

## Example Code

The DelegateInstruction constructor can take a 0-argument and 1-argument method. In the case of the 1-argument, you must pass an object to be passed as the argument. The following code shows how to call Emit on an Emitter in 2 seconds:

    // Assuming emitter is a valid Emitter
    // Notice we use "emitter.Emit" and not "emitter.Emit()" - there are no parenthesis
    // This code will make Emitter call Emit in 2 seconds.
    DelegateInstruction instruction = new DelegateInstruction(emitter.Emit);
    double timeToWait = 2;

    instruction.TimeToExecute = TimeManager.CurrentTime + timeToWait;
    emitter.Instructions.Add(instruction);

## Calling Custom Methods

The DelegateInstruction method can be used to call any method (as long as it has the proper number of arguments). The following code shows how to destroy an object after a 1-second delay when the user presses the space button.

    if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        // Assumes Destroy is a 0-argument method
        DelegateInstruction delegateInstruction = new DelegateInstruction(Destroy);

        delegateInstruction.TimeToExecute = TimeManager.CurrentTime + 1;

        // If this is an IInstructable (all Entities in Glue are):
        this.Instructions.Add(delegateInstruction);
        // If it's not, you can use the InstructionManager:
        InstructionManager.Instructions.Add(delegateInstruction);
    }

## DelegateInstructions and lambda expressions

Lambda expressions can be used with delegate instructions. For example, the following shows how to create a delegate instruction which sets an object's X to 5.

    DelegateInstruction instruction = new DelegateInstruction( () => this.X = 5 );
    instruction.TimeToExecute = TimeManager.CurrentTime + 1;
    this.Instructions.Add(instruction);

 
