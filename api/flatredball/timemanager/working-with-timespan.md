## Introduction

The TimeManager returns all of its time in seconds. If you are working with code that accepts TimeSpans, then you may need to create a new TimeSpan from the TimeManager's properties. The following code creates a TimeSpan that marks how much time has passed since last frame:

    TimeSpan timeSpan = 
        new TimeSpan((long)(TimeManager.SecondDifference * (double)TimeSpan.TicksPerSecond));
