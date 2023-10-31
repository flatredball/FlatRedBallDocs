## Introduction

The AsyncLoadingState property tells you the state that a Screen can be in regarding async loading. The available values are:

-   NotStarted - Async loading has not started at all. This is the default value, and this value will never change if you never call StartAsyncLoad
-   LoadingScreen - This value is set as soon as StartAsyncLoad is called. This value will remain as the current AsyncLoadingState until the Screen finishes loading the next Screen asynchronously.
-   Done - This value is set if the async loading is complete.

## Using AsyncLoadingState

AsyncLoadingState is most often used to prevent navigation until async loading is finished. Once a Screen begins loading the next Screen asynchronously, it should not have its IsActivityFinished set to true until AsyncLoadingState is set to Done.

One common application of asynchronous loading is in response to a user clicking on a button. For example, a main menu may have two buttons: Play and Options. For this example we'll say that both Play and Options have their own Screen. Therefore, you may have the following events:

    void OnPlayClick(IWindow window)
    {
       if(this.AsyncLoadingState == FlatRedBall.Screens.AsyncLoadingState.NotStarted)
       {
           this.StartAsyncLoad(typeof(PlayScreen).FullName);
       }
    }
    void OnOptionsClick(IWindow window)
    {
       if(this.AsyncLoadingState == FlatRedBall.Screens.AsyncLoadingState.NotStarted)
       {
           this.StartAsyncLoad(typeof(OptionsScreen).FullName);
       }
    }

Notice that each event only performs its StartAsyncLoad**only if** async loading hasn't already started. This prevents the user from clicking one button, then quickly clicking another one - or from double-clicking the same button.

Async loading will be performed in the background. You can check the status of the async load by looking at the AsyncLoadingState. If it is set to AsyncLoadingState.Done then the async loading is complete and you can progress to the next screen:

    // This would be done in CustomActiity or some function called from CustomActivity in your Screen:
    if(this.AsyncLoadingState == FlatRedBall.Screens.AsyncLoadingState.Done)
    {
       // This signals that this Screen is done and the next Screen should load up
       this.IsActivityFinished = true;
    }
