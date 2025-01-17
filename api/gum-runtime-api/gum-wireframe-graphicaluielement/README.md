# GraphicalUiElement

### Introduction

The GraphicalUiElement is the base class for all Gum runtime objects. In other words, all Gum components, screens, and standard elements inherit from this class when running in a FlatRedBall project. The GraphicalUiElement class provides functionality for positioning, parenting, sizing, and layout logic. Every Screen and Component in a Gum project will create a class in your Visual Studio project that inherits from GraphicalUiElement.

### GraphicalUiElement as IWindow

All GraphicalUiElement instances implement the IWindow interface, which means that they can be used just like other FlatRedBall UI elements. For example, all GraphicalUiElements have a Click event which can be subscribed to. For more information on the IWindow interface, see [the IWindow page](../../flatredball/gui/iinputreceiver/iwindow/).
