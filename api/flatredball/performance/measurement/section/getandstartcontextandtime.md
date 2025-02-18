# GetAndStartContextAndTime

### Introduction

The GetAndStartContextAndTime method can be used to create a new Section instance for timing. If called multiple times, then the newly-created section is added as a child of the section created on the previous GetAndStartContextAndTime call.

### Code Example

The following code shows how to create multiple sections. This code intentionally sleeps the thread to keep the sample as simple as possible.

```csharp
using FlatRedBall.Performance.Measurement;

void CustomInitialize()
{
    var section = Section.GetAndStartContextAndTime("Top Level");
    SlowFunction1();
    SlowFunction2();
    Section.EndContextAndTime();

    var result = section.ToStringVerbose();
}

private void SlowFunction1()
{
    Section.GetAndStartContextAndTime("Function 1");
    System.Threading.Thread.Sleep(1000);
    Section.EndContextAndTime();
}
private void SlowFunction2()
{
    Section.GetAndStartContextAndTime("Function 2");
    System.Threading.Thread.Sleep(2000);
    Section.EndContextAndTime();
}
```

This code produces the following string in the result variable:

```csharp
<Name: Top Level Time: 3.009174
  <Name: Function 1 Time: 1.002565>
  <Name: Function 2 Time: 2.000252>
>
```

Notice that GetAndStartContextAndTime is static. This method, along with EndTimeAndContext, can be called from the static Section class, so your code does not have to keep track of the created sections. However, the top-level section is used to report the timing information using ToStringVerbose, so the code above preserves a reference to the return value for the first GetAndStartContextAndTime call.

### Section and TimeManager

Section internally uses the TimeManager's Stopwatch class to perform timing. Therefore, to use GetAndStartContextAndTime, you must either:

* Call this method after FlatRedBallServices.InitializeFlatRedBall
* Manually call TimeManager.InitializeStopwatch
