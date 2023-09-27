## Introduction

The RotationMatrix property is a property that represents the full rotation of an IRotatable. The information contained in RotationMatrix combines the information of [FlatRedBall.Math.IRotatable.RotationX](/frb/docs/index.php?title=FlatRedBall.Math.IRotatable.RotationX&action=edit&redlink=1 "FlatRedBall.Math.IRotatable.RotationX (page does not exist)"), [FlatRedBall.Math.IRotatable.RotationY](/frb/docs/index.php?title=FlatRedBall.Math.IRotatable.RotationY&action=edit&redlink=1 "FlatRedBall.Math.IRotatable.RotationY (page does not exist)"), and [FlatRedBall.Math.IRotatable.RotationZ](/frb/docs/index.php?title=FlatRedBall.Math.IRotatable.RotationZ&action=edit&redlink=1 "FlatRedBall.Math.IRotatable.RotationZ (page does not exist)").

## Vector Components

The Matrix object contains numerous Vector3 properties which can be used to extract direction values. For example, the following code can be used to move a car forward in 2D space, assuming that the un-rotated car faces up:

    CarInstance.Velocity = CarInstance.RotationMatrix.Up * CarInstance.Speed;

For a more-complete example, check the Rock Blaster tutorial, specifically [this page](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-main-ship-behavior.md "Tutorials:Rock Blaster:Main Ship Behavior").
