## Introduction

CollideAgainstMoveSoft performs the following logic:

1.  It checks to see if two AxisAlignedRectangles are overlapping
2.  If so, it adjusts the velocity of the caller and the argument AxisAlignedRectangles according to how much the two shapes overlap each other and according to the separation velocity.

Since this function adjusts the velocity of the caller and the argument, then your code must not explicitly set Velocity on either of the two objects or else your code will overwrite the Velocity values set by this function.

## Understanding CollideAgainstMoveSoft

CollideAgainstMoveSoft adjusts the velocities of the two involved objects according to the strength of the separation (the last parameter in the function) as well as how far the two overlap.

A physical example of this would be to have magnets with the same charge (so they repel) on ice. If they are sufficiently far away then the repulsion is essentially 0, but as they get closer the amount increases. The math behind how this works is not physically identical to magnetic attraction and repulsion, but the concepts are similar.

## Code Example

The following code assumes 2 AxisAlignedRectangles are created:

1.  AxisAlignedRectangleInstance1
2.  AxisAlignedRectangleInstance2

It assumes you are using Glue so the code has been written in CustomActivity in a Screen, but it could be used outside of Glue as well.

    void CustomActivity(bool firstTimeCalled)
    {
        // The higher the drag the less time the
        // rectangles will spend moving when no acceleration
        // is applied to them:
        AxisAlignedRectangleInstance1.Drag = 3;
        AxisAlignedRectangleInstance2.Drag = 3;


        Keyboard keyboard = InputManager.Keyboard;
        // Increase acceleration to make the rectangle movement
        // more responsive, but you may also want to increase 
        // the drag if increasing this:
        const float acceleration = 400;
        keyboard.ControlPositionedObjectAcceleration(AxisAlignedRectangleInstance1, acceleration);

        // Increasing this value makes the rectangles push off
        // of each other more.  Making this a smaller value will
        // result in the rectangles pushing less and being able to
        // overlap more.
        const float separationValue = 25;
        AxisAlignedRectangleInstance1.CollideAgainstMoveSoft(AxisAlignedRectangleInstance2,
            1, 1, separationValue);
    }
