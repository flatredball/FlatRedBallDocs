\<

## Introduction

Game1CodeGenerator is a base class for code generators which inject code into Game1.Generated.cs. It provides the following methods for derived classes to override:

-   GenerateClassScope
-   GenerateInitialize
-   GenerateUpdate
-   GenerateDraw

## Creating a Game1CodeGenerator-Inheriting Class

Typically Game1CodeGenerator instances are associated with a specific plugin. Therefore, typical steps for creating a new Game1CodeGenerator-inheriting class are:

1.  Add a new class to your plugin.
2.  Inherit from Game1CodeGenerator
3.  Override the desired methods. For example, to add code to the game's initialization, override GenerateInitialize.

The following shows an example of an empty Game1CodeGenerator-inheriting class:

    public class ExampleGame1CodeGenerator : Game1CodeGenerator
    {
      public override void GenerateClassScope(ICodeBlock codeBlock)
      {
        codeBlock.Line("// add fields and properties here which should live in Game1");
      }

      public override void GenerateInitialize(ICodeBlock codeBlock)
      {
        codeBlock.Line("// add code here which should run when the game is initialized");
      }
    }

## Instantiating a Game1CodeGenerator

As mentioned above, Game1CodeGenerators are typically associated with plugins. Therefore, it is common to instantiate and register a code generator in a plugin's StartUp method as shown in the following code snippet

    public class MainExamplePlugin : PluginBase
    {
      ...
      public override void StartUp()
      {
        var exampleCodeGenerator = new ExampleGame1CodeGenerator();
        // This adds the code generator to Glue's internal list, and associates
        // the code generator with this plugin. This code generator will automatically
        // generate whenever Game1 is generated, and will be removed if the plugin is shut down.
        this.RegisterCodeGenerator(exampleCodeGenerator);
      }
    }

Typically, Glue will generate Game1 whenever a project is loaded. A plugin can forcefully generate Game1 generated code as well using the following code:

    GlueCommands.Self.GenerateCodeCommands.GenerateGame1();
