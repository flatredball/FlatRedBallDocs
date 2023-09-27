## Introduction

The CurrentScreenSecondsSince method returns how many seconds have passed since the argument time according to the current screen time. This is the preferred method of detecting how long time has passed since it takes into consideration screen pausing and the TimeManager's TimeFactor property.

## Code Example: Spawning an Enemy on a Timer

The following code can be used to create an enemy once every 5 seconds.

    // At class scope, define a variable to keep track of when the last spawn occurred
    double lastEnemySpawn;

    void CustomActivity(bool firstTimeCalled)
    {
       var frequencyInSeconds = 5;
       if(TimeManager.CurrentScreenSecondsSince(lastEnemySpawn) >= frequencyInSeconds)
       {
          var enemy = Factories.EnemyFactory.CreateNew();
          // adjust the enemy, such as setting its position here
          lastEnemySpawn = TimeManager.CurrentScreenTime;
       }
    }
