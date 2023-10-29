## Introduction

The Initialize method is responsible for preparing the FlatRedBall engine for execution. It should be called prior to interaction with any FlatRedBall managers. This function is automatically called in all FlatRedBall templates and Glue projects so you do not need to manually call this unless you are adding FlatRedBall to an existing XNA project.

## Code Example

    // "this" refers to the Game instance, which is by default called Game1
    FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);
