# flatredball-input-inputmanager-inputreceiver

### Introduction

The InputReceiver property is a property which can be assigned on the InputManager to identify that a particular object (which must implement the [IInputReceiver](../../../../frb/docs/index.php) interface) should receive keyboard input. This property can be used to prevent multiple objects from receiving keyboard input. This is useful if multiple game objects respond to keyboard input - such as a a text box and a character in a platformer.

### Setting InputReceiver

The InputReceiver can be assigned through custom code. For example, the following might be an event executed when an Entity in Glue is clicked:

```
// assuming that "this" is the container of the click event, and that it implements the IInputReceiver interface:
FlatRedBall.Input.InputManager.InputReceiver = this;
```

### Preventing double input

For information on how to prevent input, see the [IInputReceiver](../../../../frb/docs/index.php) page.
