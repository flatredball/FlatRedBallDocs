## Introduction

The GetPositionAfterTime function will return the position of an object given a set start position, an initial velocity value, and a constant acceleration value (constant during the movement time). Note that this function does not consider an object's [Drag](/documentation/api/flatredball/flatredball-positionedobject/flatredball-positionedobject-drag/.md) value, so if a PositionedObject has a non-zero Drag, the results of this function will not match actual behavior.

## Code Example

The following code will calculate where an object will be given the set values:

    // Assume MyCharacter is a valid PositionedObject (like an Entity from Glue)

    double timeInSeconds = 1; // how far into the future to calculate the movement

    Vector3 positionAfterTime = MathFunctions.GetPositionAfterTime(
       ref MyCharacter.Position,
       ref MyCharacter.Velocity,
       ref MyCharacter.Acceleration,
       timeInSeconds);

## Code Example - Determining Stopping Distance

Entities (including entities using the Top-Down plugin or the Platformer plugin) can slow down using acceleration. Your game may require calculating the distance that the entity will take to slow down. The following example shows how to calculate the distance it will take to slow down from full speed using the Top-Down plugin.

``` lang:c#
var timeToSlowDown = 3;
var maxSpeed = player.MaxSpeed;
var accelerationValue = -maxSpeed/timeToSlowDown;

// create the temporary vectors:
var position = new Vector3(0,0,0);
var velocity = new Vector3(maxSpeed, 0,0);
var acceleration = new Vector3(accelerationValue, 0,0);

var positionAfterTime = MathFunctions.GetPositionAfterTime(
  ref position,
  ref velocity,
  ref acceleration,
  timeToSlowDown);

var stoppingDistance = positionAfterTime.X;
```

 
