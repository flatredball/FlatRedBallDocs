## Introduction

The Start method is a method which sets the first Screen in the execution of your game. After Start is called, a typical FlatRedBall game will always have one screen active. In other words, the [CurrentScreen](/frb/docs/index.php?title=FlatRedBall.Screens.ScreenManager.CurrentScreen.md "FlatRedBall.Screens.ScreenManager.CurrentScreen") property will always be non-null.

The Start method is typically called in Game1.cs. If using Glue, the Start call is automatically added for you in a project, and it is automatically updated whenever the "StartUp Screen" is changed. The Start call usually does not need to be written or modified if using Glue.

A typical Start call looks like:

    FlatRedBall.Screens.ScreenManager.Start(typeof(GameName.Screens.GameScreen));
