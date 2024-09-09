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
