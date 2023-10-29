## Introduction

The FrameToFrame method returns the shortest absolute distance between two frame indexes. This value may be negative and considers looping. Example Assuming you have created an AnimationChain named "ac" with 6 AnimationFrames (the last at index 5), FrameToFrame returns the following values:

|                       |        |                                                                                                                                           |
|-----------------------|--------|-------------------------------------------------------------------------------------------------------------------------------------------|
| Call                  | Result | Explanation                                                                                                                               |
| ac.FrameToFrame(1, 2) | 1      | The closest distance from 1 to 2 is 1 frame.                                                                                              |
| ac.FrameToFrame(2, 1) | -1     | The closest distance from 2 to 1 is -1. This value is negative because you must move "backward" to get from 2 to 1                        |
| ac.FrameToFrame(1, 5) | -2     | The closest distance considering looping to get from 1 to 5 is -2. That is first going from 1 to 0, then 0 to 5 (the last frame)          |
| ac.FrameToFrame(0, 3) | 3      | Although 0 is both 3 and -3 frames away from index 3, FrameToFrame doesn't wrap if the direct difference is equally short as the wrapped. |
