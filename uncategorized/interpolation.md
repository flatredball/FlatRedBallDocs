## Introduction

Generally speaking, interpolation is the method of determining or estimating one point by using a set of other known points. In game programming, interpolation is often used to perform "smooth" transitions between one state to another. This transition could be in terms of position, color, rotation, scale, or any other numerical value.

## A Simple Example

Consider a situation where you are would like a Sprite to move from one position to another. Instead of having the Sprite immediately snap to its desired location, you'd like to have it slide in smoothly.

This is an example of interpolation. Initially the Sprite is at its first position (let's say that's X = 0), and after a given amount of time you'd like it to be at its ending position (let's say that's X = 100). To make the math simple, let's say that this movement should occur over the course of one second. Given this information you can calculate the position of the Sprite at any time in the animation.

Of course, if you are familiar with the FlatRedBall Engine, then you may know that the solution is simply to set the Velocity value (to 100 in this case). But, how exactly does Velocity work, and also, how could we determine the Position of a Sprite at a given time, like .7 seconds after the movement begins?

### Velocity (Rate of change)

Using velocity is one way to accomplish interpolation. Most FRB objects have either a velocity or rate value, so this is one way to easily accomplish interpolation without any explicit management of your objects.

Velocity or rate of change is most often used to describe interpolation of positions. That is, if you want an object to move from one position to another, you need to calculate its velocity. Fortunately, this is a relatively easy calculation. It is as follows:

    velocity = distanceToTravel/amountOfTime

Or in a more concrete example, if you wanted to move from X = 6 to X = 12 in 7 seconds, then:

     distanceToTravel = 12 - 6;

     amountOfTime = 7;

     velocity = distanceToTravel / amountOfTime

or

    velocity = 6 / 7

or

    velocity = .85714f;

This assumes that velocity and amountOfTime both use the same unit of measuring time, such as the second. In FRB, all velocities are measured per second. The following formula calculates the distance to travel:

    distanceToTravel = endingPosition - startingPosition

Be sure to subtract the startingPosition from the endingPosition and not the other way.

This formula must be performed for each axis if moving in 2 or 3 dimensions. Fortunately, with movement, each axis is independent. That is, the XVelocity can be calculated first, then YVelocity, then ZVelocity. There is no need to consider one when calculating the others.

### Values at time t

Interpolation always depends on two variables (at least). In a two variable situation, one is independent while the other is dependent. For example, when using the previous position example, we can pick any time and ask about the X value at that given time. It's perfectly ok to say "What is the X .5 seconds after the object starts moving?" Considering the object will only move for 1 second, it isn't very useful to ask questions about the state of the object when more than one second has passed. However, the time that we choose doesn't depend on the current X value. On the other hand, the X value is determined by the amount of time that has passed since the object started moving creation. Because the X value depends on the amount of time that has passed, it is a dependent variable.

When discussing interpolations or equations which depend on time, it is common to abbreviate the variable representing time as "t". More accurately, t represents the amount of time that has passed from the initial state or condition. To return to the sliding object example, the object starts moving at t = 0. It finishes moving when t = 1 (again, assuming t is measured in seconds).

Since we know the inital conditions, we know the following:

    When t = 0, X = 0
    when t = 1, X = 100

But what about when t equals another value? One that may be obvious right away is:

    When t = .5, Fade = 50

This may make sense because .5 if halfway between 0 and 1, and 50 is halfway between 0 and 100. Another way to look at it is to realize that as t moves from 0 to 1, the value of X is a weighted average. At t = .5, the value is weighted 50% at t = 0, 50% at t = 1. The general formula for a linear interpolation is as follows:

value = startingValue \* (1 - percentageToEnd) + endingValue \* percentageToEnd

And percentageToEnd is:

percentageToEnd = (t - startingT)/(endingT - startingT)

You can see that as t moves closer to the endingT, then percentage to end increases and eventually becomes 1. In this case, the startingValue is multiplied by a value that approaches 0, while the endingValue is multiplied by a value which that approaches 1. If this confuses you, try running a few examples on paper.

## Curved Interpolation I

Although "curved interpolation" may not be a formal term for what I am going to describe, I use it because it's very descriptive for what it is used. Using velocity, it is possible and not too difficult to write a method which takes a series of points and sets the velocity of an object at the appropriate times so that it moves through all of the points. If the object is a Sprite, then it can be done with relatively little code and no management using instructions. However, there are times when a curved path is more desirable. To accomplish this, the acceleration values (or acceleration instructions) can be used.

Just like linear interpolation, curved interpolation is axis independent. If you can do it on one axis, then you can extend it to 2 or 3 dimensions.

I'll begin with a basic example. Consider a situation where you want a particlar object to move from one position to another in a given amount of time. However, rather than moving at a constant speed and stopping once it arrives at its destination, you want the object to speed up and speed down, resulting in a "smooth" movement.

Keep this problem in the back of your mind as I present another situation. Let's say you have to drive 60 miles. To simplify it, we'll say the starting location (in miles) is x = 0 and the ending location is x = 60. Furthermore, let's say you had to be there in one hour. How fast would you drive? It's not to difficult to calculate the answer of 60 miles per hour. However, is this the only answer? What if you went faster for part of the trip? Then you could slow down a bit and still make it in one hour. In fact, it's impossible to make the trip with a constant velocity assuming you start the trip with the car parked or not moving. You can't hit the gas and instantly go 60, then instantly stop when you arrive.

Since you can slow down at any time during the trip and make up for it by going faster at another time, there are an infinite number of "ways" to drive the 60 miles. However, if you are to make the trip in exactly one hour, there is one thing that is constant - your average speed over the hour driven must be 60 miles per hour. That is, you could go 90 miles per hour for half of the time, then 30 miles per hour for the other half. The average would be:

.5 \* 90 + .5 \* 30 = 60

The first step to understanding the method of curved interpolation that I'm going to describe is to realize that you can change the velocity of an object during the interpolation as long as the average remains constant. No matter how you look at it, if you are to go from one point to another in a given amount of time (as long as distance and velocity is signed), your average speed will be constant.

We've seen that if you move one speed for half of the time, then another speed for the other half of the time, then the resutling average speed is the average of the two speeds moved - which makes sense. We could further "segment" the movement into 3 speeds. If a car drove 20 mph for 1/3 of an hour, 60 mph for 1/3 of an hour, and 90 mph for 1/3 of an hour, the resulting average speed is:

20\*.3 + 60 \* .3 + 90 \* .3 = 56.667

To approach a more realistic scenario, if a car is increasing speed (accelerating) at a linear rate, then the average velocity is the average of the starting and ending velocity for that period of time. Keep in mind this is **only** the case when accelerating at a constant rate.

![AverageSpeed.png](/media//migrated_media/AverageSpeed.png)

So if the image above was a graph of a car accelerating linearly from 0 to 60 mph, during the time it spent accelerating, it would have travelled the same distance as a car going a constant 30 mph for the same amount of time. We can generalize this to the following:

averageVelocity = (startingVelocity + endingVelocity) / 2.0

or

averageVelocity = startingVelocity \* .5 + endingVelocity \* .5

Using some simple algebra, it's possible to determine the ending velocity if the average velocity and the starting velocity is known. That is, if a car were traveling at 80 mph and was to travel 60 miles in one hour, if it were to linearly decelerate, what would its ending velocity be? The formula tells us:

endingVelocity = averageVelocity \* 2 + - startingVelocity

or

endingVelocity = 60 \* 2 - 80

or

endingVelocity = 40

You can verify that this is the case by averaging the starting velocity and ending velocity to see that it does indeed equal 60.

![AverageSpeed2.png](/media//migrated_media/AverageSpeed2.png)

With the knowledge presented so far, we can already solve a common problem - decelerating an object to rest at a given position in a certain amount of time. For a pracical example, consider a menu system which has a cursor that the user can move from one item to the next. When the user pushes a direction, you would like the cursor to move to the next selectable position, but you'd like the cursor to slow down as it approaches its destination and stop on the menu item. Again, I'll present the example using only one axis, but the exact same can be done for both X and Y to have the object move around in 2 dimensions.

Our two known variables are ending velocity which will be 0 and time, which we will use as 1 second for simplicity. All that is left then is to calculate the starting velocity and the acceleration. The following code moves the cursor from the currentMenuItem's X value to the nextMenuItem's X in the given amount of time.

     // set the number of seconds to take and the ending velocity
     float secondsToTake = 1; // 1 second
     float endingVelocity = 0;
     
     // remember, destination - starting position is the distance
     float distanceToTravel = nextMenuItem.X - currentMenuItem.X;

     // average velocity is distance/time
     float averageVelocity = distanceToTravel/secondsToTake;

     // reordering the formula to solve for starting velocity
     float startingVelocity = 2 * averageVelocity - endingVelocity;

     // now we know the starting velocity, ending velocity, and amount of time to take,
     // so the acceleration can be calculated based on that
     cursor.XAcceleration = (startingVelocity - endingVelocity)/secondsToTake;

     // and of course, set the velocity
     cursor.XVelocity = startingVelocity;

     // assuming that the only instructions used are for movement, clear old ones so
     // the user can interrupt cursor movement at any time:
     cursor.InstructionArray.Clear();

     // This isn't really part of the interpolation, but it's good practice to make sure
     // the object stops where it needs to.
     cursor.InstructionArray.Add( 
        new X( cursor, nextMenuItem.X, TimeManager.CurrentTimeAfterXSeconds( secondsToTake)));
     // keep it from moving on
     cursor.InstructionArray.Add( 
        new XVelocity( cursor, 0, TimeManager.CurrentTimeAfterXSeconds( secondsToTake)));
     // keep it from continuing to accelerate
     cursor.InstructionArray.Add( 
        new XAcceleration( cursor, 0, TimeManager.CurrentTimeAfterXSeconds( secondsToTake)));

## Curved Interpolation II

The example in the Curved Interpolation I section provides a method of slowing down or speeding up objects predictably. However, there are a few limitations when using this method.

Consider the relationship between starting velocity, ending velocity, and average velocity. The average velocity, by name, is the average of the starting and ending velocity. One property of averages is that when averaging two numbers, the average can not be greater or less than both numbers. It must always fall between the two numbers unless they equal eachother - in which case, all three numbers will be equal. Graphically, this means that the average must at some point cross the line that connects the starting and ending velocities, as is shown above in the two images.

This presents a problem if the average velocity is not between the starting and ending. For example, if a car is to drive from one position to another, and it must start and end the trip parked, then its starting and ending velocities will be 0. However, the average of 0 and 0 is (you guessed it) 0. But if the car is to move during its trip, its velocity must be greater than 0 at some point.

Another problem which is related is that the curved interpolation described in the previous section has a constant acceleration. That is, if an object is speeding up, it cannot also be slowing down at the same time.

The following graphic shows a situation where the object is to be in rest at both the starting and ending positions, but it must travel a distance.

![InterpolationProblem.png](/media//migrated_media/InterpolationProblem.png)

Fortunately, we can simply extend a little on what we know so far to solve this problem easily. Consider the following example. A car begins its trip at 0 mph, and linearly accelerates to 60 mph in a certain amount of time. Since the acceleration is linear, we know that the average speed of that trip is 30 mph. Now consider the opposite - a car begins its trip at 60 mph and ends its trip at 0 mph, also linearly accelerating (or decelerating) in the exact same amount of time. Again, in this situation, the average velocity is also 30 mph.

What is interesting about this is that if take two trips which both took the exact same amount of time and combine them into one trip, then the average velocity for the new two-in-one trip is the average of the average times of the other two trips. That is, the 0 to 60 trip averaged 30 mph, and the 60 to 0 trip also averaged 30 mph. Therefore, putting one right after the other will also average 30 mph, as shown in the following graph:

![CombinedTrip.png](/media//migrated_media/CombinedTrip.png)

Observe that this graph shows the solution to our previous problem - that is, the starting and ending velocities are both less than the required average velocity. By inserting a "midpoint" velocity and splitting up the trip into two trips, we are able to meet the required average velocity without changing the start or end velocities. In fact, by splitting up a trip into two trips, any problem can be solved regardless of starting velocity, ending velocity, or amount of time to take on the trip (which sets the required velocity).

The math behind this may seem like it is compliated, but we are simply going to combine two formulas together to create one final formula. First, I'll begin with some formulas that are familar. I will break the interpolation into two trips: trip1 and trip2. When discussing the entire trip, I will use the entireTrip variable or prefix.

     entireTripAverageVelocity = (endX - startX)/entireTripSecondsToTake

     trip1AverageVelocity = (trip1StartVelocity + trip1EndVelocity) / 2.0

     trip2AverageVelocity = (trip2StartVelocity + trip2EndVelocity) / 2.0

As stated before, the entire trip's average velocity is the average of the average velocity of the other two trips assuming the two trips are of equal time. What a mouthful!

    entireTripAverageVelocity = (trip1AverageVelocity + trip2AverageVelocity)/2.0

Also, keep in mind that the velocity at the end of trip1 is the same as the velocity at the beginning of trip2, so the following is true:

    midpointVelocity = trip1EndVelocity = trip2StartVelocity

In our formulas, the trip1StartVelocity, trip2EndVelocity, and entireTripAverageVelocity are all determined. The variable that we need to calculate is the midpointVelocity.

Since the average velocity of the entire trip is the average of the average of the two trips, we know the following:

    entireTripAverageVelocity = ((trip1StartVelocity + trip1EndVelocity) / 2.0 +
     (trip2StartVelocity + trip2EndVelocity) / 2.0) / 2.0

Now, that's a little ugly, so let's simplify it

    entireTripAverageVelocity = (trip1StartVelocity + trip1EndVelocity +
     trip2StartVelocity + trip2EndVelocity) / 4.0

Since we know that the midpoint velocity is equal to trip 1's end and trip 2's start:

    entireTripAverageVelocity = (trip1StartVelocity + 2*midpointVelocity + trip2EndVelocity) / 4.0

As mentioned before, the value we need to calculate is midpointVelocity. With some algebra, we can get the following equation:

     entireTripAverageVelocity = midpointVelocity / 2.0 + (trip1StartVelocity + trip2EndVelocity) / 4.0

     midpointVelocity = 2*endTripAverageVelocity - (trip1StartVelocity + trip2EndVelocity) / 2.0

And finally, to replace endTripAverageVelocity:

    midpointVelocity = 2*(endX - startX)/entireTripSecondsToTake -
     (trip1StartVelocity + trip2EndVelocity) / 2.0

With this method, it is possible to create a series of "trips" using instructions to move between points. Keep in mind that the axes are independent, so this can be performed on both the X and Y axes to create 2D movement - even on the Z axis for 3D movement. Using non-zero velocities for end points when connecting interpolations together allows for the creation of curved paths similar to splines.

## Curved Movement III

As mentioned previously, using this technique, it is possible to create curved path movements using simple acceleration and velocity settings. Perhaps the most exciting aspect of this method is that it doesn't require advanced knowledge of math. So far, we've accomplished speeding up and slowing down from point to point in a predictable amount of time with the use of simple averages.

In Curved Movement II, we discused the ability to move from one point to another by speeding up and slowing down. However, this method works for all situations. That is, the exact same method can be used for situations where the average velocity is greater than both the start and end, where it is between the start and end velocities, and even where the average velocity is less than both the start and end velocities. Therefore, regardless of the starting and ending points, velocities at these points, or the amount of time that the trip should take, this method will calculate the required acceleration settings initially and at the midpoint.

Or rather, with the list of a few point coordinates and time, this method could be used to construct a curved path.

To begin, consider the following points.

![3Points.png](/media//migrated_media/3Points.png)

To move between these points, we have a few options. The first is simple linear interpolation. To do this, calculate the differences in X and Y and set the velocities so that the object moves between the points correctly. As discussed in the previous sections, we can calculate the required average velocity to get between one point to the next, calculate what the midpoint velocity will have to be, then set the accelerations at the given time. However, this method is still not what would be considered curved movement. If the velocities at each point is 0, the object will speed up as it moves away from the previous point and slow down as it approaches the next point, but the path followed is the same path as a linear interpolation, as shown in the following image.

![3PointLinear.png](/media//migrated_media/3PointLinear.png)

The key to curved movement is to set a velocity at the points so that the object doesn't stop when reaching each point. One simple way to determine the velocity at a given point is to look at the previous and next points and calculate the required velocity if the object were to move directly from the previous to the next point. That is, the velocity to move from t = 0 to t = 2 would be set as the velocity at t = 1. Running the formula using this velocity gives the following result.

![CurvedMovement.png](/media//migrated_media/CurvedMovement.png)

Obviously, you will only be able to use this method to calculate velocities at points which are not endpoints. This method is great for creating curved movement through a set of points, but it is not a requirement. Any velocity can be set at points. Doing so will allows for deformation of the curve, as shown in the following image.
