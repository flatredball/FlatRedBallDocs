## Introduction

The IClickable interface requires implementation to specify a HasCursorOver method, which is typically used for clicking or grabbing an object. Since the IClickable interface works with the Cursor object, it can be used with a physical mouse, touch screen, or any other input device which maps to the Cursor object. Although GUI elements are the most common type of IClickables, other objects such as clickable elements can implement IClickable. Examples include board pieces in a match-three game or units in a real time strategy game. IClickable is a base interface for [IWindow](/frb/docs/index.php?title=FlatRedBall.Gui.IWindow "FlatRedBall.Gui.IWindow"). IWindow extends IClickable by adding input-based events.

## IClickable Entities

Glue entities can be marked as IClickable, which results in Glue generating IClickable-implementing code. For more information, see the [Entity IClickable](/documentation/tools/glue-reference/entities/glue-reference-implements-iclickable.md) page.
