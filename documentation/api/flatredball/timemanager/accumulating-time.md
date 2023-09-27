## Introduction

If you are working on a game which requires actions to be performed at a particular time, you may be inclined to implement an accumulation or decrementing implementation for your timing. In other words, if you want something to happen in 5 seconds, you might write code as follows:

     // in some initialiation
     double amountOfTimeLeft = 5;

     // in update
     amountOfTimeLeft -= TimeManager.SecondDifference;

     if(amountOfTimeLeft <= 0)
     {
        // Time's up!  Do whatever action
     }

We generally recommend not implementing this type of solution in your code because it can lead to timing bugs due to the inaccuracy of numerical operations. Also, this makes your code a little less flexible for additional functionality such as [pausing your game](/frb/docs/index.php?title=FlatRedBall.Instructions.InstructionManager.PauseEngine "FlatRedBall.Instructions.InstructionManager.PauseEngine"). Whenever possible we recommend reducing the number of operations it takes to get to a particular value by using base time values and using those in operations. To clarify, this article will present a number of common scenarios, then show the proper way to achieve the desired functionality. For comparison, we'll also show an improper way of implementing the desired functionality.

## If using Glue

If you are using Glue, then the Screen class has a lot of timing and pausing functionality built in. See [this page](/frb/docs/index.php?title=Glue:Reference:Screens:PauseAdjustedCurrentTime "Glue:Reference:Screens:PauseAdjustedCurrentTime") for a current time value that can be used which considers paused time.

## Performing activity at time

If you are interested in performing a particular task at a certain time - such as setting a property or calling a method, you may want to look at some of the classes in the FlatRedBall.Instructions namespace. Specifically:

-   FlatRedBall.Instructions.IInstructable
-   FlatRedBall.Instructions.Instruction
-   FlatRedBall.Instructions.InstructionManager
-   FlatRedBall.Instructions.MethodInstruction

However, you may still want to perform an action at a certain time without the use of instructions.

### Proper

The proper way is to store a value and use that value in all of your comparisons. For example:

    // define timeToExecute outside of any functions:
    double timeToExecute;

     // Do this at the point where you want to set the time, like in CustomInitialize.  
     // In this case, the event will happen in 5 seconds. 
     timeToExecute = TimeManager.CurrentTime + 5;

     // Now test in some update or activity function
     if(TimeManager.CurrentTime >= timeToExecute)
     {
        // Perform Action
     }

### Improper

It is improper to accumulate a value and test that against a time:

     timeThatHasPassed = 0;

     // testing in update
     timeThatHasPassed += TimeManager.SecondDifference;

     if(timeThatHasPassed >= 5)
     {
         // Perform Action
     }

### Extra notes

Similarly, it is improper to store a value to decrement the value every frame and test against 0. The reason is because you'll get more accurate results if you only perform an operation once (timeToExecute = TimeManager.CurrentTime + 5) instead of multiple times (timeThatHasPassed += TimeManager.SecondDifference).

## Dividing a time period

You may want to perform an action at a given interval, or according to some value set in data. If you are going to store these values in an array of doubles or [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction "FlatRedBall.Instructions.Instruction"), you may need to calculate these values up front.

### Proper

The proper way to do this is to calculate every value based off of an initial time rather than off of the previous time. For example, consider a situation where you have a period of time that you want to subdivide into twenty events. The incrementing should be done at an integer level to avoid accumulation error.

     int numberOfDivisions = 20;
     double amountOfTimeToDivide = 100.0;

     double[] divisionTimes = new double[numberOfDivisions];

     for(int i = 0; i < numberOfDivisions; i++)
     {
        divisionTimes[i] = amountOfTimeToDivide / (double)i;
     }

### Improper

It is improper to calculate the amount of time that you should divide by outside of the loop and increment by that value:

     int numberOfDivisions = 20;
     double amountOfTimeToDivide = 100.0;

     double[] divisionTimes = new double[numberOfDivisions];

     double currentTime = 0;
     double timeIncrement = amountOfTimeToDivide / (double)numberOfDivisions;

     for(int i = 0; i < numberOfDivisions; i++)
     {
        divisionTimes[i] = currentTime;
        currentTime += timeIncrement;
     }

### Additional notes

The second method might seem like a better way to mark the times because it only requires one division, making it appear like it's superior from an performance point of view. Whether this is true or not doesn't really matter because this code is very error prone. Not only will values which fall later in the divisionTimes array be less accurate because of the numerous += operations performed on a double, but it's also possible to have an out-of-bounds error in the improper code if the values happen to be rounded down and a 21st value is added in the array. It's far more accurate to increment integers then perform a division only one time per divisionTimes value.
