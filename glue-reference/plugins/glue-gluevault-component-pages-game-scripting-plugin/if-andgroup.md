## Introduction

The AndGroup method allows you to combine multiple if statements into one. For example, the following would only start the game if 5 seconds have passed and if two players have joined:

``` lang:c#
If.AndGroup();
    If.HaveAllPlayersJoined();
    If.TimeHasPassed(5);
If.EndGroup();
Do.StartGame();
```

Note that the tabs above are optional, but have been added to separate the AndGroup from the contained If's.
