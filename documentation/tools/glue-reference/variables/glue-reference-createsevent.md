## Introduction

Variables in entities and screens can have events which are raised whenever the variable is changed. These events can be used to broadcast changes (such as in the case of INotifyPropertyChanged) or to perform other custom logic such as updating a health bar when health changes.

## Example : Adding an Event to a Variable by Drag+Dropping

To add an event to a variable:

1.  Expand your Screen or Entity's **Objects** folder

2.  Drag+drop the variable onto the Events folder [![](/media/2016-01-10_06-31-21.gif)](/media/2016-01-10_06-31-21.gif)

3.  Open your project in Visual Studio

4.  Look for the Events file for your Screen or Entity, which will be named **ScreenOrEntityName.Events.cs**. In this example, the file is named **FanRight.Events.cs**.

    ![](/media/2022-11-img_636cfe6e5f44b.png)

5.  Add code to the event to respond to the variable change.

## 

## Example : Assigning Additional Event Handlers

When a variable event is created, an event handler is automatically added. In the example above, the handler is named **OnAfterForceVelocityXSet**. You can also manually create event handlers purely in custom code. By drag+dropping the variable onto the Events folder, the Variable's **CreatesEvent** property is set to true.

![](/media/2022-11-img_636cffc3410e9.png)

This results in two events being created:

-   Before\<VariableName\>Set - for example **BeforeForceVelocityXSet**
-   After\<VariableName\>Set - for example **AfterForceVelocityXSet**

These can be seen in generated code:

![](/media/2022-11-img_636d003e0486b.png)

Notice that the **Before** event is an Action which takes a float. This argument contains the new value, enabling the handler to decide how to respond to the new value before it has been assigned. These can be handled in custom code. For example, the following code could be used to print out that the variable is being assigned:

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

 
