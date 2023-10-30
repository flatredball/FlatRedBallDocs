# sortaxis

### Introduction

The SortAxis property can be set if a factory is associated with a PositionedObjectList which should remain sorted (typically for performance reasons). By default the SortAxis is null, so no sorting will be performed on insertion.

### Code Example

The code example below assumes the following:

*   An entity named **Entity** with the **CreatedByOtherEntities** value set to **True**:

    ![](../../../../media/2017-09-img_59afffd7d749e.png)
*   A screen with an **Enemy** list:

    ![](../../../../media/2017-09-img_59b000338a29c.png)

The following code in the GameScreen.CustomInitialize  method will result in a sorted list of enemies:

```lang:c#
// This tells the factory to insert all newly created Enemies
// so that the EnemyList stays sorted on the X axis
Factories.EnemyFactory.SortAxis = FlatRedBall.Math.Axis.X;

for(int i = 0; i < 20; i++)
{
    var randomX = FlatRedBallServices.Random.Between(0, 100);
    Factories.EnemyFactory.CreateNew(randomX, 0);
}


// now let's output the values to the screen:
string outputValue = "";

foreach(var enemy in EnemyList)
{
    outputValue += enemy.X + "\n";
}

FlatRedBall.Debugging.Debugger.CommandLineWrite(outputValue);
```

This code produces results shown in the following image:

![](../../../../media/2017-09-img_59b001245f7ca.png)

### SortAxis Duration

The SortAxis  property is null by default. It is reset to null whenever the factory has its Destroy  method called. Factories are typically destroyed when a screen is destroyed. Therefore, if SortAxis  is assigned to a non-null value in a Screen (such as in CustomInitialize ), this SortAxis  value will persist until that Screen is destroyed. This behavior allows multiple screens to use different SortAxis  values for the same factory. It also allows the same screen to use different SortAxis  values for different levels to improve partitioning efficiency.

### Why Use SortAxis?

SortAxis results in a factory inserting instances of newly-created entities into the target list so that the list is always sorted. While this increases the amount of time that each individual insert takes, it removes the requirement to call a sort function after-the-fact (which can be expensive on large, unsorted lists) This can provide a small performance boost.
