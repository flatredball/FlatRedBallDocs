## Introduction

The LateBinder class is a class which provides efficient, standardized access to properties and fields through reflection. In other words, the LateBinder can be used to get and set values on objects using their string names. The LateBinder is very effective when writing tools and performing high-level actions on objects.

## Code Example

The following code sets the X, Y, and Z properties of a Sprite using the LateBinder:

Add the following using statements:

    using FlatRedBall.Instructions.Reflection;

Assuming mSprite is a valid Sprite:

    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "X", 1.0f);
    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "Y", 1.0f);
    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "Z", 1.0f);

## Why use the LateBinder?

If you are familiar with .NET then you may already be comfortable using the built-in methods for getting and setting values for reflection. Syntactically, the LateBinder may not appear to provide much in the way of convenience:

    // Through LateBinder:
    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "X", 1.0f);
    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "Y", 1.0f);
    LateBinder<Sprite>.Instance.SetProperty<float>(mSprite, "Z", 1.0f);

    // Through Reflection:
    Type type = typeof(Sprite);
    type.GetProperty("X").SetValue(mSprite, 1.0f, null);
    type.GetProperty("Y").SetValue(mSprite, 1.0f, null);
    type.GetProperty("Z").SetValue(mSprite, 1.0f, null);

The LateBinder is most effective in situations where a particular property must be read or set multiple times. It caches off the getters and setters for properties and uses these delegates to invoke the properties on any subsequent calls, making it **very fast**. Keep in mind that the LateBinder does quite a bit of work internally when a property is read or set for the very first time. Therefore, if you measure the speed of the LateBinder when first calling GetValue or SetValue, you will notice a significant cost in speed. However subsequent calls usually take about 10% of the amount of time as using the raw reflection calls.

Also, using the LateBinder is also effective for performing reflection in a cross-platform manner. The LateBinder will attempt to cache off delegates if possible, but it will fall back to regular reflection calls on platforms which don't support the faster method (such as the 360).

### Using the LateBinder for the first time on a property

The LateBinder provides efficient reflection because it dynamically creates instances for given types of objects and also dynamically retrieves their getters and setters for arguments when GetProperty and SetProperty are called. The initial instantiation and retrieval is slow compared to even raw reflection calls. If you are particularly sensitive to performance, you may want to consider calling GetProperty or SetProperty (depending on what you will be using) for each property you plan on setting in your Screen's Initialize (or CustomInitialize if using Glue) method. This will get the slower instantiation out of the way so the LateBinder will be very efficient every time you use it.

## GetValue Method

The GetValue method allows you to get the value of a variable using reflection by passing in a string. For example, you could get the X value form a Sprite by either hard-coding the value or by using the latebinder:

    float valueFromHardcode = spriteInstance.X;
    float valueFromLateBinder = (float)LateBinder<Sprite>.Instance.GetValue(spriteInstance, "X");

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
