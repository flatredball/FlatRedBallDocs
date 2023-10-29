## Introduction

The Set method is an extension method for IInstructables which simplifies the creation of property and field setting instructions. Using the Set method enables the creation of instructions which will automatically be added to the calling IInstructable's InstructionList.

**Note:** This is an extension method. To use this, you will need to add:

    using FlatRedBall.Instructions;

## Code Example

The following code can be used to change a Sprite's X value to 4 after 1 second:

    // Make sure to set the value to 4.0f and not 4 or 4.0 - the type matters and it must be a float
    spriteInstance.Set("X").To(4.0f).After(1);

Since all Entities in Glue are also IInstructables, then any public property can be set on an Entity through reflection:

    this.Set("SomeIntValue").To(3).After(2);

**Note:** Instructions should only set public fields and properties. The reason for this is because some platforms (such as Windows Phone) only allow the setting of public properties.
