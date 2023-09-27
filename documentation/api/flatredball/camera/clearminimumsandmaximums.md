## Introduction

ClearMinimumsAndMaximums removes all minimum and maximum X and Y values from the calling Camera.

## Code Example

The following code will set the minimum and maximum values on the Camera, then undo that setting, allowing the Camera to be positioned anywhere:

    // Sets the minimum and maximum X values...
    Camera.Main.MinimumX = 0;
    Camera.Main.MaximumX = 1000;

    // ... and this code undoes it:
    Camera.Main.ClearMinimumsAndMaximums();
