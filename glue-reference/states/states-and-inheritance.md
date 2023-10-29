## Introduction

States are very powerful, but their behavior can be a little confusing when combined with inheritance. This article discusses how states and inheritance work together and things you should be aware of in your project when using States with Screens/Entities that inherit from other Screens/Entities.

## States are enums

For starters we should lay the programming foundation that States are enums. In other words, when you create a new State, you add a new entry to an enum in your code. For example, if you have created an Entity with the following four States:

-   Disabled
-   Enabled
-   Highlighted
-   Invisible

The generated code will create this enum:

    public enum VariableState
    {
        Uninitialized, // This exists so that the first set call actually does something
        Enabled,
        Disabled,
        Highlighted,
        Invisible
    }

## State values cannot be added in derived objects

The fact that States use enums is very important to the discussion of inheritance. Enums do not have a sense of inheritance - you can not inherit one enum from another (this is a C# language rule). Therefore, if you define a set of variables in the base class - that's it! You can't add or remove from them in a derived object.

## Accessing state in derived custom code

Of course, the CurrentState property is public:

    public VariableState CurrentState
    {
        get
        {
            return mCurrentState;
        }
        set
        {
            mCurrentState = value;
            switch(mCurrentState)
            {
                         ...

This means that the derived object can set its CurrentState just the same way the base class:

    this.CurrentState = VariableState.Invisible;
