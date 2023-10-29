## Introduction

The SystemCurrentTime property reports the system's current time **right when the method is called**. This differs from the CurrentTime property because the CurrentTime property will not change during a frame; however, the SystemCurrentTime will always be changing continually. For example, consider the following code:

    // In some Activity or Update method
    double currentTime1 = TimeManager.CurrentTime;
    double systemCurrentTime1 = TimeManager.SystemCurrentTime;

    DoSomeStuff();

    double currentTime2 = TimeManager.CurrentTime;
    double systemCurrentTime2 = TimeManager.SystemCurrentTime;

    DoOtherStuff();

    double currentTime3 = TimeManager.CurrentTime;
    double systemCurrentTime3 = TimeManager.SystemCurrentTime;

The code above may produce the results showin the table below. The systemCurrentTime values would be different for every call, while DoSomeStuff would always be the same:

|         |            |                   |
|---------|------------|-------------------|
| Call \# | curentTime | systemCurrentTime |
| 1       | 42         | 42.001            |
| 2       | 42         | 42.0023555        |
| 3       | 42         | 42.005431         |

*These timing values have no meaning - they were picked purely as an example.*

## Profiling Example

If you've ever wondered how long a piece of code takes to run, then the SystemCurrentTime is a great way to measure it. To profile a piece of code, get the SystemCurrentTime before and after the code. For example, if you wanted to measure a method called PerformCollisions you might do something like this:

    double timeBefore = TimeManager.SystemCurrentTime;
    PerformCollisions();
    double timeAfter = TimeManager.SystemCurrentTime;
    double timeMethodTook = timeAfter - timeBefore;

Of course, keep in mind that:

1.  This method is not 100% accurate - it's only as accurate as the system timer it relies on. Measuring something that is very fast, like the allocation of a variable, will likely not give you much information.
2.  This method **may** result in a method call. Method calls can be slow, so again, if you are measuring something very fast, you may not get very accurate information.

In general, this timing becomes more accurate the longer you spend between calls. Once you reach one millisecond (.001) or greater, your results should be fairly accurate.
