# statistics

### Introduction

Statistics is a field of mathematics that can you predict the result of a system that includes random numbers. It can also help you select coefficients to use to create desired random behavior.

### Normal Distribution

The normal distribution describes a very common, naturally occurring distribution where the most common values appear near the average. Values which are further from the average are less likely.

One example of a normal distribution is the the average height of people. The average height is 5'8", and this is not just a numerical average, but there are actually more people who are 5'8" than any other height.

![HeightOfPeople.png](../../.gitbook/assets/migrated\_media-HeightOfPeople.png)

People who deviate extremely from the average (people over 7 feet tall or under 5 feet tall) tend to be rare.

### Simulating Normal Distributions

In some cases a normal distribution is desired, but perfect accuracy is not needed. For example, if you are creating a particle system, you may want the size of most particles to be around some desired number with some variability in the sizes.

If a precise normal curve is not needed, the shape of a normal curve can be easily approximated.

#### Even Distribution

A random number generator will return an even distribution of results. In this type of distribution, any number within the range is just as likely to occur as any other number.

![EvenDistribution.bmp](../../media/migrated\_media-EvenDistribution.png)

This can be achieved as follows:

```
public float GetRandomNumber(float minValue, float maxValue)
{
   float range = maxValue - minValue;

   float valueToReturn = minValue + (float)FlatRedBallServices.Random.NextDouble() * 
      range;

   return valueToReturn;
}
```

#### Two Value Distribution

A very rough approximation can be achieved through a "two value distribution". A two value distribution is where two random numbers are added together, then the result is returned. The range of each of the values that is added together should be half of the desired range such that the resulting value still lies between the min and max.

![TwoValueDistribution.png](../../.gitbook/assets/migrated\_media-TwoValueDistribution.png)

Notice that this distribution is shaped like a triangle - the sides are perfectly flat. While this doesn't quite get the curved sides of a normal curve, it does result in the most common values lying near the average. Values further from the average become less and less likely, eventually having a 0 probability at the min and max values.

This can be achieved as follows:

```
public float GetTwoValueRandomNumber(float minValue, float maxValue)
{
   // Half the range
   float range = (maxValue - minValue)/2.0f;

   // Apply the range twice
   float valueToReturn = minValue + 
       (float)FlatRedBallServices.Random.NextDouble() * range +
       (float)FlatRedBallServices.Random.NextDouble() * range;

   return valueToReturn;
}
```

#### Three Value Distribution

While a two value distribution gets close, a normal distribution can be approximated even more closely with three values. A three value range results in a curved normal-like distribution.

![ThreeValueDistribution.png](../../.gitbook/assets/migrated\_media-ThreeValueDistribution.png)

This distribution be achieved similar to the two value code above:

```
public float GetThreeValueRandomNumber(float minValue, float maxValue)
{
   // Make the range one third
   float range = (maxValue - minValue)/3.0f;

   // Apply the range three times
   float valueToReturn = minValue + 
       (float)FlatRedBallServices.Random.NextDouble() * range +
       (float)FlatRedBallServices.Random.NextDouble() * range + 
       (float)FlatRedBallServices.Random.NextDouble() * range;

   return valueToReturn;
}
```
