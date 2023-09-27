## Introduction

The Clone method is a generic method which can be used to create new instances of objects which inherit from PositionedObjects. Since it is generic, the Clone method can be used on types that inherit from the PositionedObject class, like [Entities](/frb/docs/index.php?title=Entity.md "Entity").

## Code Example

The following creates a custom PositionedObject class called WeightedObject. It manually creates one WeightedObject, then creates a clone of it. The output [Text](/frb/docs/index.php?title=Text.md "Text") shows that the WeightedObject has been properly cloned. Add the following using statement:

    using FlatRedBall.Graphics;

Define your WeightedObject class:

    public class WeightedObject : PositionedObject
    {
        // We'll make it public so 
        // our code is shorter
        public float Weight;

        public override string ToString()
        {
            return "Position:" + Position + "  Weight:" + Weight;
        }
    }

Add the following to Initialize after initializing FlatRedBall

    WeightedObject firstObject = new WeightedObject();
    // Modify the Position - an inherited member
    firstObject.Position = new Vector3(1, 2, 3);
    // Now modify Weight - a member we created ourselves
    firstObject.Weight = 20;

    // Now let's make a second object:
    WeightedObject secondObject = firstObject.Clone<WeightedObject>();

    TextManager.AddText(secondObject.ToString());

![PositionedObjectClone.png](/media/migrated_media-PositionedObjectClone.png)

## What does Clone actually copy?

The Clone method clones your PositionedObject, but there are a few details to keep in mind. First, the Clone method calls the MemberwiseClone method, which is a method that exists for all objects in .NET. This method performs a "shallow" copy. What that means is that if your object has a member that is a reference (for example, to another [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite")), then the newly-cloned object will share the exact same reference. It will not create a new [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") instance for it to reference as a member. All value members (such as float or int) will be copied and each object will have its own value data. There are a few exceptions. The PositionedObject will create new instances for:

-   ListsBelongingTo
-   Children
-   Instructions

The new clone will have new lists for the properties mentioned above, and they will be empty.

## Cloning Reference Objects

If you are creating an object which includes other referenced objects (such as Sprites, Texts, or any collision Shapes), then you will need to manually clone the objects and re-attach these objects. We recommend encapsulating this logic in a Clone method as follow:

    // Assuming this method is inside an object named MyEntity that has mVisibleRepresentation and mCircle objects:
    public MyEntity Clone()
    {
        MyEntity newEntity = this.Clone<MyEntity>();

        // manually clone all of the Entities
        newEntity.mVisibleRepresentation = mVisibleRepresentation.Clone();
        newEntity.mCollision = mCollision.Clone();

        // The newly-cloned instances will not be attached to "this", so do that
        // Don't change the relative - we'll want to use the original values
        bool changeRelative = false;
        newEntity.mVisibleRepresentation.AttachTo(newEntity, changeRelative);
        newEntity.mCollision.AttachTo(newEntity, changeRelative);

        return newEntity;
    }

FlatRedBall objects like Sprites and collision Shapes provide Clone methods which can be used to simplify cloning. If your object contains other reference objects then you will either:

-   Need to add a Clone method to those objects if you have written them yourself.
-   Manually instantiate a new object for the new PositionedObject instance in the Clone method and set any variables that should be set.
