# Generated Code

### Introduction

One of the primary technologies that the FRB Editor uses to function is it creates generated code. Some game projects may include more generated code than hand-written code.

This section discusses the details of how generated code works. The details of generated code may be useful to you during development if:

* You have encountered a bug related to generated code
* You are interested in debugging generated code
* You are interested in creating FlatRedBall Editor plugins which generate code

### How can I see generated code?

If you are using Visual Studio then you can view all generated code in Visual Studio. All Screens and Entities will have at least one generated file.

Assuming that you have an Entity called MyEntity:

1. Open your project in Visual Studio
2. Expand the "Entities" folder in your project
3. Look for your entity (MyEntity.cs)
4. Expand the entity and you should see another file called MyEntity.Generated.cs
5. Double-click this file to see the generated code

![GeneratedEntityCsFile.png](../media/migrated\_media-GeneratedEntityCsFile.png)

FlatRedBall also generates a file called GlobalContent.Generated.cs which is not associated with any particular Screen/Entity. It is responsible for loading and providing access to all files added through the Global Content Files item in the FRB Editor.

This file is located in your project as well, but it is not embedded under any other files:

![GlobalContentGenerated.png](../media/migrated\_media-GlobalContentGenerated.png)
