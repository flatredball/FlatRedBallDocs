## Introduction

The Initialize method can be used to reset the PositionedObject variables back to their default state. Specifically, the Initialize method resets:

-   Position (absolute and relative)
-   Velocity (absolute and relative)
-   Acceleration (absolute and relative)
-   All ["real" values](/frb/docs/index.php?title=FlatRedBall.PositionedObject#Real_Velocity_and_Acceleration "FlatRedBall.PositionedObject")
-   Rotation (absolute and relative)
-   Rotation Velocity (absolute and relative)
-   Attachments (detach from parents)
-   Attachment properties ([ParentRotationChangesPosition](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesPosition "FlatRedBall.Math.IAttachable.ParentRotationChangesPosition") and [ParentRotationChangesRotation](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesRotation "FlatRedBall.Math.IAttachable.ParentRotationChangesRotation"))
-   Instructions
-   Name
-   List membership **(see below for more information)**

## Method Signature

The signature for Initialize is as follows:

    public virtual void Initialize()
    public virtual void Initialize(bool clearListsBelongingTo)

Arguments:

-   bool clearListsBelongingTo - Whether the object should clear its [ListsBelongingTo](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ListsBelongingTo&action=edit&redlink=1 "FlatRedBall.PositionedObject.ListsBelongingTo (page does not exist)") property. If this property is not specified, then the default value is true.

## The dangers of clearListsBelongingTo

The FlatRedBall Engine depends on the two-way relationship that exists between [IAttachables](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable "FlatRedBall.Math.IAttachable") (an interface of the PositionedObject) and two-way lists that the [IAttachable](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable "FlatRedBall.Math.IAttachable") belongs to. Calling the no-argument version of Initialize, or passing **true** as the argument will result in the the PositionedObject breaking its two-way relationships with other objects, **but it will not be removed from those lists**. Let's look at a simple example where this can cause errors. The following code creates a PositionedObject, adds it to the SpriteManager for management, initializes, then attempts to remove it:

    PositionedObject positionedObjectInstance = new PositionedObject();
    SpriteManager.AddPositionedObject(positionedObjectInstance);

    // This will clear the PositionedObject's ListsBelongingTo.  This means that the PositionedObject will
    // no longer know that it belongs to the engine, so it will not be able to remove itself from the engine.
    positionedObjectInstance.Initialize(); 

    // This call will not do anything!
    SpriteManager.RemovePositionedObject(positionedObjectInstance);

    // If you want to test it, try this:
    if(SpriteManager.ManagedPositionedObjects.Contains(positionedObjectInstance))
    {
        throw new Exception("The PositionedObject wasn't removed!");
    }

To avoid the bug shown above, you should either:

1.  Initialize before adding to the SpriteManager
2.  Pass **false** as the argument to Initialize
