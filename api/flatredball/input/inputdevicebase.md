# InputDeviceBase

InputDeviceBase is a base class for implementing a custom InputDevice. The InputDeviceBase provides default implementation for all IInputDevice properties, allowing derived classes to override only some of the available properties. The InputDeviceBase class can also be instantiated to create an IInputDevice-implementing instance which returns 0 and false for all properties.

InputDeviceBase can be used in the following situations:

1. To wrap input which is read from some input hardware which is not natively supported by FlatRedBall, such as a custom game controller.
2. To remap controls, such as to change the default horizontal and veritcal movement on a keyboard from WASD to arrow keys.
3. To implement AI on a top down or platformer entity. For an example on how to perform this, see the [Enemy Input Logic](../../../tutorials/platformer-plugin/enemy-movement/03-enemy-input-logic.md) tutorial.

### Code Example - Simple InputDeviceBase Implementation

You can inherit from InputDeviceBase to create an InputDevice which only returns some of hte properties. Unlike implementing the IInputDevice interface, inheriting from InputDeviceBase does not require you to fill in every property.&#x20;

For example, the following code is a class which always returns X=1 for the default 2D Input - in other words an input device simulating holding right on the analog stick continually:

```csharp
internal class ExampleInputDevice : InputDeviceBase
{
    protected override float GetDefault2DInputX() => 1;
}
```
