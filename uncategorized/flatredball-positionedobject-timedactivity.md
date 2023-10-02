# flatredball-positionedobject-timedactivity

### Introduction

The TimedActivity method is a method used by PositionedObjects (and objects which inherit from PositionedObject such as [Sprite](../frb/docs/index.php)) to perform common every-frame logic. The TimedActivity method performs the following:

* Adjusts position by velocity and acceleration
* Adjusts velocity by acceleration
* Adjusts rotation by rotation velocity
* Adjusts velocity by drag (linear representation)
* Calls [TimedActivityRelative](../frb/docs/index.php).
* Adjusts RealVelocity and RealAcceleration if [KeepTrackOfReal](../frb/docs/index.php) is set to true.

TimedActivity is automatically called for you on any PositionedObject that is part of a manager, so you will normally not need to call this method manually.

### TimedActivity Signature

The TimedActivity signature is as follows:

```
public override void TimedActivity(float secondDifference, double secondDifferenceSquaredDividedByTwo, float secondsPassedLastFrame)
```

The arguments are used as follows:

* secondDifference - this is the amount of time that has passed since last frame. Internally FlatRedBall uses [TimeManager.SecondDifference](../frb/docs/index.php)
*   secondDifferenceSquaredDividedByTwo - this is a value used to apply acceleration. Internally FlatRedBall uses:

    ```
    (TimeManager.SecondDifference * TimeManager.SecondDifference)/2.0
    ```
* secondsPassedLastFrame - this is the amount of time that passed between two frames ago and last frame. This is used to calculate ["real" values](../frb/docs/index.php). Internally FlatRedBall uses [TimeManager.LastSecondDifference](../frb/docs/index.php)

### When to manually call TimedActivity

TimedActivity is called automatically by the engine so you will not need to call it in most cases. However, there are some cases where you may need to:

* If you have a PositionedObject which has either been removed from the engine or made manually updated, you may need to call this method manually if you would logic mentioned above to be applied (like Velocity).
* If you would like to simulate more time passing in a single frame. The first argument indicates the amount of time that you would like applied in TimedActivity.
* If you are performing unit tests and need to perform logic that would normally be performed by the engine on PositionedObjects.

### Manually calling TimedActivity

TimedActivity may need to be manually called if you would like to simulate more time being passed in your frame. For example, you may be working on a game and you want to "fast-forward" time by 5 seconds to see where an object will end up. The TimedActivity method can accomplish this. The following code will move a PositionedObject forward in time by 5 seconds:

```
// the amount of time to fast-forward by
float secondDifference = 5; 
// This is a number used to apply acceleration accurately
double secondDifferenceSquaredDividedByTwo = (secondDifference * secondDifference) / 2.0;
// This is used to calculate "real" values.  We'll pass 0 for this example, assuming real values are not needed
float secondsPassedLastFrame = 0;
// Assuming myPositionedObject is a valid PositionedObject:
myPositionedObject.TimedActivity(secondDifference, secondDifferenceSquaredDividedByTwo, secondsPassedLastFrame);
```

### TimedActivity and Drag

The example shown above will result in perfectly accurate positioning **if** [**Drag**](../frb/docs/index.php) **is 0**. The reason for this is because [Drag](../frb/docs/index.php) is a linear approximation. Normally this linear approximation is sufficiently accurate; however, large values for secondDifference can result in inaccurate and even confusing behavior. It is even possible, given a large enough secondDifference, for [Drag](../frb/docs/index.php) to reverse the velocity of an object.

If you are using [Drag](../frb/docs/index.php) and want to manually call TimedActivity, you should either:

1. Manually apply [Drag](../frb/docs/index.php) (see the [Drag](../frb/docs/index.php) page for information on how to do this)
2. Call TimedActivity in a loop rather than all at once, as shown below.

### Calling TimedActivity in a loop

Calling TimedActivity in a loop simulates the way that FlatRedBall calls TimedActivity once per frame. This can make [Drag](../frb/docs/index.php) behave properly. The following code shows how to call TimedActivity, simulating a game that runs at 30 frames per second:

```
int framesPerSecond = 30;
float secondDifference = 1/(float)framesPerSecond;
double secondDifferenceSquaredDividedByTwo = (secondDifference * secondDifference) / 2.0;
float secondsPassedLastFrame = 0;
int numberOfSteps = framesPerSecond * 5; // we'll still simulate 5 seconds of activity
for(int i = 0; i < numberOfSteps; i++)
{
   myPositionedObject.TimedActivity(secondDifference, secondDifferenceSquaredDividedByTwo, secondsPassedLastFrame);
}
```

Of course calling this method multiple times (150 in the example above) takes much more processing time than simply calling the method once with a larger secondDifference.

### TimedActivity in objects inheriting PositionedObject

If you have a class which is inheriting from PositionedObject, then you may want to override the TimedActivity method. Doing this will allow you to write custom code which will be run automatically every frame if your object is added to the SpriteManager. In a Glue environment, code added to TimedActivity will be called prior to the custom code for a given frame.

Since this code is called by the SpriteManager during the FlatRedBall.Update call, your code may execute before or after TimedActivity for other engine-managed objects. In other words, if you require that other FlatRedBall types have finished applying properties such as velocity and acceleration for a given frame before your code is applied, you should not use TimedActivity for custom logic.

The following code is an example of what TimedActivity might look like in a class that inherits from PositionedObject:

```
public override void TimedActivity(float secondDifference, double secondDifferenceSquaredDividedByTwo, float secondsPassedLastFrame)
{
    base.TimedActivity(secondDifference, secondDifferenceSquaredDividedByTwo, secondsPassedLastFrame);
    // Custom code can be added here
}
```
