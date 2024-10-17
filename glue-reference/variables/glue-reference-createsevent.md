# CreatesEvent

### Introduction

Variables in entities and screens can have events which are raised whenever the variable is changed. These events can be used to broadcast changes (such as in the case of INotifyPropertyChanged) or to perform other custom logic such as updating a health bar when health changes.

### Example : Adding an Event to a Variable by Drag+Dropping

To add an event to a variable:

1. Expand your Screen or Entity's **Objects** folder
2. Drag+drop the variable onto the Events folder

<figure><img src="../../.gitbook/assets/2016-01-10_06-31-21.gif" alt=""><figcaption></figcaption></figure>

3. Open your project in Visual Studio
4.  Look for the Events file for your Screen or Entity, which will be named **ScreenOrEntityName.Events.cs**. In this example, the file is named **FanRight.Events.cs**.

    ![](../../.gitbook/assets/2022-11-img\_636cfe6e5f44b.png)
5. Add code to the event to respond to the variable change.

### Example : Assigning Event Handlers

![](../../.gitbook/assets/2022-11-img\_636cffc3410e9.png)



* Before\<VariableName>Set - for example **BeforeForceVelocityXSet**
* After\<VariableName>Set - for example **AfterForceVelocityXSet**

These can be seen in generated code:

![](../../.gitbook/assets/2022-11-img\_636d003e0486b.png)

Notice that the **Before** event is an Action which takes a float. This argument contains the new value, enabling the handler to decide how to respond to the new value before it has been assigned. These can be handled in custom code. For example, the following code could be used to print out that the variable is being assigned:

```csharp
private void CustomInitialize()
{
    BeforeForceVelocityXSet += HandleBeforeForceVelocityXSet;
    AfterForceVelocityXSet += HandleAfterForceVelocityXSet;
}

private void HandleBeforeForceVelocityXSet(float newValue)
{
    FlatRedBall.Debugging.Debugger.Write($"About to set value to {newValue}");
}

private void HandleAfterForceVelocityXSet(object sender, EventArgs e)
{
    FlatRedBall.Debugging.Debugger.Write($"Just assigned value to {ForceVelocityX}");
}
```

### Static Events (IsSharedStatic)

If a variable's IsShared is set to true, then the variable is generated as a static variable in code. This means that its events must also be static. If a variable with IsShared set to true generates an event, the following occurs:

* All events are static
* If the variable is drag+dropped onto the Events node, the event handler method is generated as static
* A static constructor is added to generated code for the owning Screen/Entity. This may conflict with static constructors if you have added one in custom code
* The event is subscribed in the static constructor, so it will always be active
* The event is never unsubscribed. By contrast instance events are unsubscribed when the owning Screen/Entity are destroyed

As mentioned above, if your Screen/Entity already has a static constructor, adding a static event in the FRB editor will result in a conflicting static constructor.

Also note that even if an event is raised for a Screen/Entity, that does not mean that the content has been loaded for that entity. The content will only have been loaded if an instance of the Screen/Entity has been created, or if the content has been loaded explicitly through a LoadStaticContent method call.

