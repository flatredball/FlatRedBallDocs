# ICodeBlock

### Introduction

ICodeBlock is the base interface used to generate code in the FlatRedBall Editor. Typically code generation is performed in methods which have received an ICodeBlock, although plugins may also create their own ICodeBlock for fully-generated files.

ICodeBlocks provide the following benefits:

* Handling of indentation and curly brackets
* Generation of common code structures such as methods and properties
* Fluent interface which can implify the creation of blocks of code with various levels of indentation

### Code Example: Adding Code to an ICodeBlock

The most common place to interact with an ICodeBlock is by creating a class that inherits from `ElementComponentCodeGenerator` `Game1CodeGenerator`

For example, the following code shows how to add code to an entity's Initialize method:

```csharp
class MyCustomCodeGenerator : ElementComponentCodeGenerator
{
    public override ICodeBlock GenerateInitialize(ICodeBlock codeBlock, IElement element)
    {
        codeBlock.Line("// This is a comment");
        codeBlock.Line("var someVariable = 4;");

        codeBlock.If("someValue == 123")
                .Line("DoSomething();")
            .End()
            .Else()
                .Line("DoSomethingElse();");
        return codeBlock;
    }
}
```

The code above would produce code similar to the following block:

```csharp
// This is a comment
var someVariable = 4;
if(somevalue == 123)
{
    DoSomething();
}
else
{
    DoSomethingElse();
}
```

### Code Example: Creating a CodeDocument

If you need to create a full code file without an existing ICodeBlock, you can use the `CodeDocument` class to create a new document. The `CodeDocument` class is an ICodeBlock which has no indents, but which can call any of the extension methods to add new code.

For example, the following could be used to create a string that defines a new class:

```csharp
var document = new CodeDocument();

document.Line("using System;");
document.Line("using System.Collections.Generic;");
document.Line("using System.Linq;");

var classBlock = document.Class("public", "MyClass");


classBlock.Line("int health;");

classBlock.Property("public int", "Health")
    .Get()
        .Line("return health;")
    .End()
    .Set()
        .Line("health = value;")
        .Line("ReactToHealthChanged();")
    .End();

var methodBlock = classBlock.Function("private void", "ReactToHealthChanged");

methodBlock.Line("Console.WriteLine(\"Health changed to \" + health);");


var entireFile = document.ToString();

// do something with entireFile, like save it to disk
```

This produces code similar to the following block:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class MyClass
{
    int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            ReactToHealthChanged();
        }
    }
    
    public void ReactToHealthChanged()
    {
        Console.WriteLine("Health changed to " + health);
    }
}
```

Notice that blocks do not need to be explicltly ended. Calling End() returns the parent block, allowing for fluent interfaces, but it is not required. Calling ToString() on a block resolves all brackets and returns a properly indented block of code.
