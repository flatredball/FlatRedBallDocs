## Introduction

Glue can be used in another program (such as a simple command-line application) to perform content builds on your project. Note that this will not build your code - you still need to use Visual Studio or some other building application to compile your project into a .exe (or whatever extension is created for your project depending on its platform).

## Code Example

The following code shows how to use Glue to generate code and copy/build content without opening the actual Glue application:

You first need to add a reference to Glue.exe in your project you are wanting to run Glue code gen from.

Add the following using statements:

    using FlatRedBall.Glue.AutomatedGlue;
    using FlatRedBall.Glue;

Add this code in your project to make it load the Glue project:

    //Start up Glue
    AutoGlue.Start();

    //Load Your Project.  This also generates all code
    ProjectManager.LoadProject("C:\FlatRedBallProjects\TestProject\TestProject\TestProject.csproj");

This is all that is needed. If you are writing a command line application, your application can exit after executing this code.
