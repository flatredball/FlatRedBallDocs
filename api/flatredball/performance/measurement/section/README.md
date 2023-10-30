# section

### Introduction

Section is a class which can be used to measure and report performance in FlatRedBall. It has the following features/benefits:

* Supports a tree structure so that sections can be sub-divided.
* Supports a context system so different sections of code can create sections without requiring managing and passing around references
* Can be serialized to a compact XML file.
* Supports being loaded in the FlatRedBall Profiler.

### Code Example

The following shows the simplest way to time a section and print the result. Add the following using statement:

```
using FlatRedBall.Performance.Measurement;
```

If you add this code to an Update or Activity function it will be called every frame, so you will want to add it to your game's Initialize or a Screen's CustomInitialize:

```
// This starts the timing of the section
Section.GetAndStartContextAndTime("Demo Section");

System.Threading.Thread.Sleep(1000);

// This ends the timing of the section.
// We store off the reference to the created
// section so we can...
Section result = Section.EndContextAndTime();

// ...print it out here:
FlatRedBall.Debugging.Debugger.CommandLineWrite(result);
```

![SectionPrintedOut.PNG](../../../../../media/migrated_media-SectionPrintedOut.PNG) For more information on CommandLineWrite, see the [CommandLineWrite page](../../../debugging/debugger/commandlinewrite.md).
