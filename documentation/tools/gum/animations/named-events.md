## Introduction

Named events can be used to perform custom logic at certain times in an animation. Since named events are created in Gum, the animator can align the performance of logic visually. For example, a Gum animation may be used to move components of a title screen into view. While this animation is playing the game may need to play sound effects and music at certain times. Named events can be used to play music and sound effects at certain times.

## Example

Named events can be added to animations in Gum in the animation window. To add a named event to an existing animation:

1.  Select the animation
2.  Click the **Add Named Event** button
3.  Enter a name for the event
4.  Select the event
5.  Enter a time for the event

![](/media/2017-12-img_5a245ac4d4b0a.png)

Gum animations have an AddAction  method which can be used to add custom actions at certain times: For example, if the screen were accessible in code as GameScreenGumRuntime in a Glue screen, the MakeYellow named event could be reacted to as shown in the following code:

``` lang:c#
void CustomInitialize()
{
    // AddAction can be used to handle the MakeYellow named event
    GameScreenGumRuntime.MoveToLeftAnimation.AddAction("MakeYellow", HandleMakeYellow);
}

// HandleMakeYellow can be used to handle the event:
private void HandleMakeYellow()
{
    
}
```

 
