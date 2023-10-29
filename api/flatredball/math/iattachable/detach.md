## Introduction

The Detach method is called on a child IAttachable to detach it from its Parent. Calling Detach has two effects:

1.  Sets the calling IAttachable's ParentAsIAttachable (or Parent if using a PositionedObject) to null.
2.  Removes the calling IAttachble from its parent's ChildrenAsIAttachables list (or Children if using a PositionedObject).

## Usage

Assuming that childObject is attached to something, you can detach its follows:

    childObject.Detach();
