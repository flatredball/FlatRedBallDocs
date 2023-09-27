## Introduction

This tutorial discusses how to create and perform basic editing on Splines.

## Creating a Spline

To create a Spline:

1.  Click the "Add Spline" button. A new Spline will appear in the Spline list window. It will be selected, causing the properties window to appear.
2.  Click the Points category in the properties window of the selected Spline.
3.  Click the "Add Point" button. This will add a point to the Spline.
4.  Click the "Add Point" button a few more times. Notice that the list window updates to show each point and each point will also be drawn on the Window.

At this point you have created a Spline; however, it doesn't do much yet. It simply defines a straight path.

## Editing Spline Points

There are a number of ways to edit points:

-   Selected Splines show their points as white circles. Click and drag on a circle to change its position.
-   Click on a point in the Points list in the properties window of the selected Spline. A window displaying the properties of the selected point will appear. You can numerically change the position, velocity, or time of the point.

## Viewing Splines

Splines in the SplineEditor show their points as circles. Splines also show red (when selected) or purple (when not selected) squares. These squares define the path as well as define the velocity of an object passing through that part of the Spline.

Each square on a Spline marks .25 seconds since the previous square or circle. Therefore, if squares are further apart then an object moving along the Spline will travel further in the same amount of time. In other words, fewer squares means the object will move faster and more squares will mean an object will move slower.

You can also view the resulting movement of a Spline by pressing the space bar. This will create a Sprite which will move along the Spline. The Spline can even be edited while the moving Sprite is visible and it will react to the changes in real-time!
