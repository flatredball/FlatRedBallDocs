## Introduction

PropertyCollections are a method of encapsulating a group of property values. Using PropertyCollections can simplify and make code more readable.

## Using PropertyCollections

The following example creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and sets its properties through a PropertyCollection.

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    PropertyCollection propertyCollection = new PropertyCollection();
    propertyCollection.Add("ScaleX", 5.0f);
    propertyCollection.Add("RotationZ", (float)Math.PI / 8.0f);

    propertyCollection.ApplyTo(sprite);

![SpriteWithChangedProperties.png](/media/migrated_media-SpriteWithChangedProperties.png)

## Lack of Type Conversion in PropertyCollections

Unlike assigning properties using regular code the values assigned to properties through PropertyCollections must match the type exactly. For example the following code is acceptable:

    // Assuming someSprite is a valid Sprite.
    someSprite.XVelocity = 3;

The value of 3 is an integer value, as opposed to 3.0f, but the compiler casts the value to a float without any problem. However, the following code would result in a crash:

    // Assuming someSprite is a valid Sprite and propertyCollection is a valid PropertyCollection
    propertyCollection.Add("XVelocity", 3);  // OH NO, 3 is an int!
    propertyCollection.ApplyTo(someSprite);  // This will throw an assert.

Instead, XVelocity must be explicitly given a float:

    // Assuming someSprite is a valid Sprite and propertyCollection is a valid PropertyCollection
    propertyCollection.Add("XVelocity", 3.0f);  // Whew, 3.0f is a float.
    propertyCollection.ApplyTo(someSprite);  // This will now work fine.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
