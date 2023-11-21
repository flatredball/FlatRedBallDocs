# Events

### Introduction

The FRB Editor supports the addition of events to screens and entities. The most common types of events include:

* Responding to a variable changing. For more info see the [Variable Event page](../variables/glue-reference-createsevent.md).
* Responding to collision (on a CollisionRelationship)

Other objects such as IWindows can also expose events, but these are less common.

The only type of event which requires using the FlatRedBall Editor is variable events. All other events can be performed purely in code. CollisionRelationship events are often defined in the FlatRedBall Editor since doing so provides a single place to see all responses to a collision.

### Variable Example

Variable events allow for custom code to react to a variable being assigned. To add an event for a variable:

1. Create a variable on your entity
2. Drag+drop the variable onto the Events folder

<figure><img src="../../.gitbook/assets/21_09 36 56.gif" alt=""><figcaption><p>Drag+drop event</p></figcaption></figure>

This creates an event in the Event.cs file for the container. For example, if the event is created in the Player entity, then the event handler is added to Player.Event.cs.

<figure><img src="../../.gitbook/assets/image (12).png" alt=""><figcaption><p>Event Handler in Visual Studio</p></figcaption></figure>

### IWindow Example

Note that IWindows are not used as often in modern FlatRedBall development due to the introduction of FlatRedBall.Forms. However, the following example does show how events can be used for custom implementations of IWindow. The events available to a screen, entity, or object depend on the respective container's properties. For example, if an entity implements IWindow (for more information, see the [Implements IWindow page](../../documentation/tools/glue-reference/entities/glue-reference-implements-iwindow.md)), the entity will have additional events available.

![](../../media/2017-01-img\_58786a3627e38.png)

![](../../media/2017-01-img\_58786b063be83.png)

![](../../media/2017-01-img\_58786aaa970d7.png)

### Editing Event Code

Every event in Glue creates a corresponding method in your code project which can be edited in Visual Studio. For example, consider the example of a **GameScreen** which has an event **ResolutionOrOrientationChanged**:

![](../../media/2019-05-img\_5cdd690195452.png)

The presence of this event will result in 2 new code files:

1. GameScreen.Event.cs
2. GameScreen.Generated.Event.cs

![](../../media/2019-05-img\_5cdd696141dcb.png)

As usual, the file with Generated in the name is a generated file which should not be edited because Glue may overwrite any manual changes. The non-generated file (GameScreen.Event.cs) can be freely edited to modify the logic associated with a given event.

![](../../media/2019-05-img\_5cdd6a103d870.png)
