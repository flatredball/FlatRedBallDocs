## Introduction

The Random property in FlatRedBallServices provides access to a global random number generator. This property is of the standard [System.Random](http://msdn.microsoft.com/en-us/library/system.random.aspx) type.

## How to get Random Integers

The following code shows how to get a number between 0 and 3. Notice that the call is exclusive, meaning whatever number you pass in will not be part of the range. Therefore to get a number between 0 and 3, we pass 4.

    // Returns {0, 1, 2, or 3}
    int randomNumber = FlatRedBallServices.Random.Next(4);

The Next function with a single integer value has an implied lower bound of 0. You can also explicitly define the lower bound. For example, to get a number between 3 and 7 (possible values being 3, 4, 5, 6, 7), you would do the following:

    // 3 is inclusive, 8 is exclusive, so possible values are {3, 4, 5, 6, or 7}
    int randomNumber = FlatRedBallServices.Random.Next(3, 8);

## How to get Random Floats

The Between function is the easiest way to get a random number. The following example shows how to get a random number between 0 and 100, where both 0 and 100 are possible values:

``` lang:c#
float randomValue = FlatRedBallServices.Random.Between(0, 100);
```

You can also use the NextDouble method, which is a standard function on the .NET Random object. The NextDouble method provides a random number between 0 and 1. This number can then be modified to get any range of random numbers. For example, to get a float between 0 and 100, you would do the following:

    // Gets a number between 0 and 100...
    float randomNumber = (float)FlatRedBallServices.Random.NextDouble() * 100;
    // ...which may be used to position an object:
    MyCharacter.X = randomNumber;

## How to Perform an Action at a Certain Percentage Chance

Using Random.Between function can be used to perform code a certain percentage of time. The following example shows how to perform an action 15% of the time

    var percent = 15;
    var randomNumber = FlatRedBallServices.Random.Between(0, 100);
    var shouldPerformAction = percent <= randomNumber;
    if(shouldPerformAction)
    {
      // do the action here
    }

## How to get Random Objects in a List

The In function returns a random object in the list. For example, the following code gets a random enemy in a list called EnemyList:

``` lang:c#
var enemy = FlatRedBallServices.Random.In(EnemyList);
```

The MultipleIn function returns a new list populated randomly by selecting items from the original list. The returned list will not return duplicates unless the original list contains duplicates. For example, the following code shows how to get 3 enemies from a list called EnemyList:

``` lang:c#
var randomEnemies = FlatRedBallServices.Random.MultipleIn(EnemyList, 3);
```

     
