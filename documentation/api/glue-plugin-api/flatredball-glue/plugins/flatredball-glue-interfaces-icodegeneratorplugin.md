## Introduction

The ICodeGeneratorPlugin interface allows you to create plugins that generate code. Not only can these plugins create new code files, but you can also insert your own code into the .Generated.cs file that is created by Glue normally. Injecting custom code into the .Generated.cs file is done through the use of [ElementComponentCodeGenerator](/frb/docs/index.php?title=FlatRedBall.Glue.CodeGeneration.ElementComponentCodeGenerator&action=edit&redlink=1.md "FlatRedBall.Glue.CodeGeneration.ElementComponentCodeGenerator (page does not exist)").

## Adding a custom class to your project

This tutorial will show you how to create a custom class in your code. The ICodeGeneratorPlugin is written to react to when an IElement (Screen or Entity) is regenerated. If you are looking to make a plugin that generates code unrelated to any IElement, the code here can be used as an example; however, the ICodeGeneratorPlugin interface may not be very useful. First you will need to create a .cs file for your plugin. To do this:

-   Add a new .cs file to your plugin template named MyCodeGenerator
-   Add the following using statements:

&nbsp;

    using FlatRedBall.Glue.Plugins.Interfaces;
    using FlatRedBall.Glue;
    using FlatRedBall.IO;
    using System.ComponentModel.Composition;
    using FlatRedBall.Glue.SaveClasses;
    using FlatRedBall.Glue;

-   Add the following code above your class declaration:

&nbsp;

    [Export(typeof(ICodeGeneratorPlugin))]

-   Add the following code after the class declaration:

&nbsp;

     : ICodeGeneratorPlugin

-   Click on the "ICodeGeneratorPlugin" then press CTRL + . (that's the period key) and select "Implement interface 'ICodeGeneratorPlugin'". You should have stubs for all of the methods and properties for this plugin now.

Next we'll clean up the stubs:

-   Delete the contents of the CodeGenerationStart method. We'll fill this in after cleaning everything else up
-   Replace the exception in the getters for CodeGeneratorList and CodeGenerator with

&nbsp;

    return null;

-   Replace the exception in the FriendlyName getter with

&nbsp;

    return "My code generator"

-   Replace the exception in Version with

&nbsp;

    return new Version()

-   Delete the exception in StartUp
-   Replace the exception in ShutDown with

&nbsp;

    return true

Now let's modify the CodeGenerationStart method. First, we'll add an if-statement to return (do nothing) if the IElement is a Screen. The code we're about to write will only work on Entities. To do this, add this in your CodeGenerationStart method:

    if (element is ScreenSave)
    {
        return; // we only want to generate this for Entities
    }

Next we'll create a ICodeBlock and use that to generate our code. ICodeBlock is an interface that Glue uses to simplify code generation.

    ICodeBlock code = new CodeDocument();
    code
        .Namespace(ProjectManager.GetElementNamespace(element))
            .Class("public partial", element.ClassName, "")
                .Function("void", "MoveToTheRight", "")
                    .Line("this.X++;")
                .End()
            .End()
        .End();

Now that we have this code written, let's add the file to the project and save it to disk. To do this, append the following code after the code that fills the StringBuilder:

    GlueCommands.ProjectCommands.CreateAndAddPartialFile(element, "MyCode", code.ToString());

The CreateAndAddPartialFile will add the .cs file that we pass to the project. This code can be called over and over - the file will only be added to the Project if it isn't already there. This code will be called for every Entity in your project. The result is that every Entity will have a .Generated.MyCode.cs file which will contain a method called MoveRight. Of course, this method doesn't do anything very useful; however, this shows how you can create your own code files with methods that can do virtually anything.

## Adding code to the default .Generated.cs file

The example above shows how to create a brand new file and generate code. You may want to add code directly in the .Generated.cs file (the one that Glue creates for every Screen and Entity). This section will show you how to do this. For the sake of keeping the tutorial shorter, we'll assume that you already have a class that implements and exports the ICodeGeneratorPlugin interface as shown above. The first step is to create a class that inherits from the [ElementComponentCodeGenerator](/frb/docs/index.php?title=FlatRedBall.Glue.CodeGeneration.ElementComponentCodeGenerator&action=edit&redlink=1.md "FlatRedBall.Glue.CodeGeneration.ElementComponentCodeGenerator (page does not exist)") class:

-   Add a new file to plugin template and call it CodeGenerationComponent
-   Add the following using statements:

&nbsp;

    using FlatRedBall.Glue.CodeGeneration;
    using FlatRedBall.Glue.SaveClasses;

-   Add the following code after the class name to make it implement ElementComponentCodeGenerator:

&nbsp;

    : ElementComponentCodeGenerator

-   Add the stub for the GenerateActivity method:

&nbsp;

    public override ICodeBlock GenerateActivity(ICodeBlock codeBlock, FlatRedBall.Glue.SaveClasses.IElement element)
    {

    }

-   Add the following code inside GenerateActivity to create logic to move the Entity to the right when the space bar is pressed:

&nbsp;

    if (element is EntitySave)
    {
        codeBlock
            .If("InputManager.Keyboard.KeyPushed(Keys.Space)")
                .Line("this.X++;")
            .End();
    }

    return codeBlock;

Next we'll return to the ICodeGeneratorPlugin-implementing class (which was MyCodeGenerator).

-   Add the following field to MyCodeGenerator:

&nbsp;

    CodeGenerationComponent mCodeGenerationComponent = new CodeGenerationComponent();

-   Add the following code to the contents of the CodeGenerator property:

&nbsp;

    return mCodeGenerationComponent;

Now the class will generate the code that is in the AppendLine methods inside every Entity.
