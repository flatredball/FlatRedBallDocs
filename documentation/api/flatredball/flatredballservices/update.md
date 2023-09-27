## Introduction

FlatRedBallServices.Update performs all non-drawing FlatRedBall updates. This includes:

-   Updating all managed object positions, velocities, rotations, and other velocity/rate variables
-   Reading input
-   Performing instructions

This method should be called in the Game's Update function, prior to any custom activity.
