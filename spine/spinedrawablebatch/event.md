# Event

### Introduction

Spine supports events which can be handled in code. Events are defined in Spine which can include parameters of different types such as ints, floats, and strings.

<figure><img src="../../.gitbook/assets/image (5) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Events in Spine</p></figcaption></figure>

These events can be handled in code by subscribing to a SpineDrawableBatch's Event event, or through the FlatRedBall Editor.

### Subscribing to Events in FRB Editor

To subscribe to an event in FRB Editor:

1. Create a SpineDrawableBatch object in your Entity
2. Drag+drop the SpineDrawableBatch into the Events folder
3. Change the name if desired, then press OK

<figure><img src="../../.gitbook/assets/16_18 45 11 (1).gif" alt=""><figcaption><p>Drag+Drop SpineDrawableBatch on Event Window</p></figcaption></figure>

The new event can be handled in the Events.cs file of your Entity. For example, if your Entity is named Soldier, the event is in Soldier.Event.cs.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Spine Event in Soldier.Event.cs file</p></figcaption></figure>

### Subscribing to SpineDrawableBatch.Event in Code

The Event event is can be subscribed to just like any event in C#. To do so, simply use the `+=` operator to add a handler to the Event, as shown in the following code snippet:

```csharp
private void CustomInitialize()
{
    SpineDrawableBatch.Event += HandleSpineDrawableBatchEvent;
}

private void HandleSpineDrawableBatchEvent(TrackEntry trackEntry, Event e)
{
    // Handler logic goes here...
}

```

### Event Parameter

When a Spine event is raised it may have parameters which are passed. The parameter type can differ per event type, so the Event class that is passed to the handler contains the information.

You can decide the meaning of each paramter in your game. For example, you may decide to award points when a particular event occurs by reading the `e.Int` value.
