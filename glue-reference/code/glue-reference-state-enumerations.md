## Introduction

Glue creates a custom class for every state category, and a separate class for all uncategorized states. Note that previous versions of Glue used to create enumerations for states, but this behavior was changed in 2018. For details about the change, see the [post about state data](/news/introducing-state-data.md).

## Class Names

The default class for uncategorized states in an entity is VariableState . To prevent naming conflicts, the class is defined inside the generated class for the screen/entity. For example, if a Screen named **GameScreen** includes uncategorized states, then the following qualified class is generated:

``` lang:c#
public class VariableState
{
    public string Name;
    public static VariableState State1 = new VariableState()
    {
        Name = "State1",
    }
    ;
    public static VariableState State2 = new VariableState()
    {
        Name = "State2",
    }
    ;
}
```

The class is an embedded class, so it must be accessed through the screen class. For example, the fully qualified name of the VariableState class would be:

    ProjectNamespace.Screens.GameScreen.VariableState

States will appear in the VariableState class if they are either uncategorized.
