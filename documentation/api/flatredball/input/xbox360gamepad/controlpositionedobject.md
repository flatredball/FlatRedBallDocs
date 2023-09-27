## Introduction

The ControlPositionedObject method is a shortcut method which can be used to quickly add control logic for PositionedObjects using a Xbox360GamePad. The ControlPositionedObject method modifies the Velocity values of a PositionedObject. Therefore, consider the following:

-   Acceleration will not have any impact on a PositionedObject that is being controlled by ControlPositionedObject
-   ControlPositionedObject sets Velocity even if the left analog stick is not being touched (it will set it to 0).
-   ControlPositionedObject on Entities which contain shapes will break CollideAgainstBounce calls since CollideAgainstBounce modifies velocity, but the modified velocity will be overridden by ControlPositionedObject. If using CollideAgainstBounce, consider using [ControlPositionedObjectAcceleration](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.ControlPositionedObjectAcceleration&action=edit&redlink=1.md "FlatRedBall.Input.Xbox360GamePad.ControlPositionedObjectAcceleration (page does not exist)").
-   ControlPositionedObject provides control for X, Y, and Z (using the shoulder buttons).

**Note:** ControlPositionedObject is a method which can be very useful for new programmers, for prototypes, and for simple games. However, most games require more custom controls over their objects. Therefore, you may find that you will need to replace ControlPositionedObject with custom movement code as your project expands. If so, don't worry - you're not doing anything wrong.

## Code Example

Assuming MyEntity is a valid PositionedObject instance:

    const float magnitude = 10;
    InputManager.Xbox360GamePads[0].ControlPositionedObject(MyEntity, magnitude);

## Implementation Details

The following code is the code used in the engine to implement ControlPositionedObject. You can use and modify this code if you'd like to customize how the logic is applied:

           public void ControlPositionedObject(PositionedObject positionedObject, float velocity)
           {
               positionedObject.XVelocity = this.LeftStick.Position.X * velocity;
               positionedObject.YVelocity = this.LeftStick.Position.Y * velocity;

               if (ButtonDown(Button.LeftShoulder))
                   positionedObject.ZVelocity = velocity;
               else if (ButtonDown(Button.RightShoulder))
                   positionedObject.ZVelocity = -velocity;
               else
                   positionedObject.ZVelocity = 0;
           }
