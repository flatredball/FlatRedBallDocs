## Introduction

WriteAutomaticallyUpdatedObjectInformation provides information about the automatically updated objects in the FlatRedBall Engine. Including a large number of automatically updated objects can be a common performance problem in FlatRedBall games, so this method is very useful in helping you diagnose and solve these problems.

## Usage

The WriteAutomaticallyUpdatedObjectInformation can be called at any point in your application. To do so, add the following line of code:

    FlatRedBall.Debugging.Debugger.WriteAutomaticallyUpdatedObjectInformation();

Note that if you prefer to use a different display method than the Text drawn by the Debugger, you can also call GetAutomaticallyUpdatedObjectInformation . For more information on how to use WriteAutomaticallyUpdatedObjectInformation, see [this page](/documentation/tutorials/code-tutorials/tutorials-a-walkthrough-on-improving-performance/flatredballxna-tutorials-manually-updated-objects/flatredballxna-tutorials-manually-updated-objects-measuring-automatic-updates/.md "FlatRedballXna:Tutorials:Manually Updated Objects:Measuring Automatic Updates").
