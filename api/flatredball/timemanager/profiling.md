# Profiling

### Introduction

While there are a number of ways to profile your game to improve its performance, one of the simplest (and often very effective) ways to do this is to simply measure the amount of time code takes to run. The TimeManager provides methods which can be helpful in accomplishing this. Note that measuring code using the TimeManager is considered a \*low level\* form of profiling your game.

### TimeSection

The TimeManager provides accurate, low-level timing which can be used for profiling your code. The TimeSection methods both times and records the results of the timing. The information recorded through TimeSection can be retrieved through GetTimedSection. The following code creates 280 Sprites and performs a brute-force all vs. all Move collision. This inefficient method is so that the code takes a significant amount of time to execute.

Add the following at class scope:

```
 SpriteList mSpriteList = new SpriteList();

 double mLastTimeReported;
 double mReportFrequency = 3; // how many seconds between reports  
```

Add the following in Initialize after initializing FlatRedBall:

```
 for (int i = 0; i < 280; i++)
 {
     Sprite sprite = SpriteManager.AddSprite("redball.bmp");

     Circle circle = ShapeManager.AddCircle();
     sprite.SetCollision(circle);

     mSpriteList.Add(sprite);
 }
```

Use the following in Update method (entire method shown):

```
 protected override void Update(GameTime gameTime)
 {
     // perform the report before calling FlatRedBallServices.Update
     if (TimeManager.CurrentTime - mLastTimeReported > mReportFrequency)
     {
         bool showTotalTime = true;

         System.Console.Write(TimeManager.GetTimedSections(showTotalTime) + "\n\n");
         mLastTimeReported = TimeManager.CurrentTime;
     }

     FlatRedBallServices.Update(gameTime);
     Screens.ScreenManager.Activity();


     TimeManager.TimeSection("Start Collision");

     // Perform an inefficient brute force check
     foreach (Sprite sprite1 in mSpriteList)
     {
         foreach (Sprite sprite2 in mSpriteList)
         {
             if (sprite1 != sprite2)
             {
                 sprite1.CollideAgainstMove(sprite2, .5f, .5f);
             }
         }
     }

     TimeManager.TimeSection("End Collision");

     base.Update(gameTime);
 }
```

![TimeSectionOutput.png](../../../.gitbook/assets/migrated\_media-TimeSectionOutput.png)

### SumTimeSection

TimeSections are a great way to measure how much time has passed between two pieces of code. TimeSection calls can follow one after another to measure multiple sections of code; however, there is one area where TimeSection is not very effective. Consider the following example:

```
TimeManager.TimeSection("Before Entity Management");

for(int i = 0; i < mEntities.Count; i++)
{
    mEntities[i].PerformAI();

    mEntities[i].PerformPhysics();

    mEntities[i].CheckForDeath();
}

TimeManager.TimeSection("Entity Management");
```

Assume that the above code is called every frame, and based off of a TimeSection that is "wrapping" the above block of code you determine that this piece of code is what is greatly slowing your project down. The problem is you don't know which part is actually slowing things down. Sure, you could guess, but that's not what profiling is all about! And if you put TimeSection calls after every call in the loop, you'd end up with a lot of TimeSections; 3 \* mEntities.Count to be exact. This information would not be very helpful. To identify which of the three calls is taking up the most time, you can use the "sum" timing methods available in the TimeManager. The general pattern is:

```
TimeManager.StartSumTiming(); // called to initiate sum timing
// First area of code to time
TimeManager.SumTimeSection("First area of code");
// Second area of code to time
TimeManager.SumTimeSection("Second area of code");
// etc
// More SumTimeSections if necessary
string result = TimeManager.GetSumTimedSections(); // called to end sum timing
```

The methods work essentially the same as TimeSection calls except that sum sections with the same name are added together. For example, the above code would be modified as follows to get the time each section took:

```
TimeManager.StartSumTiming();

for(int i = 0; i < mEntities.Count; i++)
{
    mEntities[i].PerformAI();

    TimeManager.SumTimeSection("Time spent in PerformAI");

    mEntities[i].PerformPhysics();

    TimeManager.SumTimeSection("Time spent in PerformPhysics");

    mEntities[i].CheckForDeath();

    TimeManager.SumTimeSection("Time spent in CheckForDeath");
}

string result = TimeManager.GetSumTimedSections();
```

Result would have 3 entries - each would report how much time has been spent inside each of the methods. Again, keep this in mind whenever timing pieces of code that fall inside of a loop - even if your loop is outside of the method where your timing methods lie. However **be sure to put your StartSumTiming call outside of any loops or else your information on previous loops may get overwritten!**

### Tracking down expensive code

In many situations you will find that a relatively small number of areas of code take up the majority of your frame time. Using the TimeManager methods can help you track down which areas of code are taking the most amount of time. A common approach is to measure time at a very high level, then dive deeper once you find which method is causing problems. For example, consider a situation where a Screen is slowing down your game. You may want to do do initial tests as shown above to determine if the show-down is occurring in the Draw calls or in the Update calls. We'll assume that you have done this and you've determined that the Update calls are very slow and you think they could be improved. Since you know the slow-down is in Update, and you also know the Screen that is causing the slow-down, you would be able to see which method in the Screen's CustomActivity is causing problems. For example, your code may look like:

```
void CustomActivity(bool firstTimeCalled)
{
   PerformAiActivity;

   PerformCameraMovementActivity();

   PerformCollisionActivity();

   CheckForEndOfLevel();

}
```

One of the benefits of keeping logic out of your Activity class is it can help you isolate performance problems very quickly:

```
void CustomActivity(bool firstTimeCalled)
{
   TimeManager.TimeSection("Start of Activity");

   PerformAiActivity;
   TimeManager.TimeSection("Ai Activity");

   PerformCameraMovementActivity();
   TimeManager.TimeSection("Camera Activity");

   PerformCollisionActivity();
   TimeManager.TimeSection("Collision Activity");

   CheckForEndOfLevel();
   TimeManager.TimeSection("End of level checking");
}
```

This kind of diagnostic will often give you a very clear indication of where the problem lies. For example, you may find that 95% of the time spent in activity is in just one of those functions. If this is the case, then it is clear that you should remove or comment out the TimeSection calls shown above, navigate to the method that took the most time, and divide that up with TimeSection calls.
