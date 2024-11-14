# Creating a Plugin Project

### Introduction

This tutorial provides instructions for creating a Glue plugin class project.

### Obtaining Source

Before creating a plugin, be sure that you have downloaded the FlatRedBall and Gum repositories, and that you have successfully built and run the FlatRedBall Editor from source. For more information see the [Building FlatRedBall From Source page](../../flatredball-source/).

### Creating a new SLN

Whether you create a new .sln depends on whether you plan on making a plugin that will be part of the main FlatRedBall repository. If your plugin is intended to be part of the FlatRedBall repository, please discuss your plans in Discord to make sure it will be accepted as a core library. If you are not sure if you want to include it in the main FRB repository, or if you intend this to be separate from the FRB repository, then you create your own .sln. Keep in mind that you do not need to create a new .sln for every plugin you are developing - it may be convenient to have multiple plugins in one .sln file. To create a new .sln file:

1. Open Visual Studio. If you are using a different IDE such as Rider, you will need to modiyf the steps.
2.  Select the option to create a new project\


    <figure><img src="../../.gitbook/assets/image (202).png" alt=""><figcaption><p>Create a new project in Visual Studio</p></figcaption></figure>
3.  Select Class Library and click Next\


    <figure><img src="../../.gitbook/assets/image (203).png" alt=""><figcaption><p>Select Class Library in Visual Studio</p></figcaption></figure>
4.  Enter a name and location for your new project and click Next\


    <figure><img src="../../.gitbook/assets/image (204).png" alt=""><figcaption><p>Selecting Project name and Location</p></figcaption></figure>
5.  Select .NET 6.0 as the Framework - this is the current .NET version used in the FlatRedBall Editor as of January 2024, but it will likely change in the future. Click Create.

    <figure><img src="../../.gitbook/assets/image (205).png" alt=""><figcaption><p>Select .NET Version</p></figcaption></figure>

### Linking Glue Libraries

To link the necessary Glue libraries in your project:

1. Right-click on the Solution
2. Select Add -> Existing Project
3. Navigate to the folder where you have cloned the FlatRedBall Respository. For example, it may be at C:\Users\YourUserName\Documents\GitHub\FlatRedBall
4. Select the PluginLibraries.csprojj file located at \<FlatRedBall Root>/FRBDK/Glue/PluginLibraries/PluginLibraries.csproj

Once this is added to your project, add the PluginLibraries as a dependency to your plugin project. You may notice that your project has a warning in the projects node in the Solution Explorer. To solve this problem, double-click your csproj and modify it:

1. Set the TargetFramework to `net6.0-windows`
2. Add the `<UseWPF>true</UseWPF>` tag in teh same PropertyGroup.

For example, after the modifications your .csproj may look like the following csproj:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net6.0-windows</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
	<UseWPF>true</UseWPF>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\..\FlatRedBall\FRBDK\Glue\PluginLibraries\PluginLibraries.csproj" />
  </ItemGroup>
</Project>
```

Now you have a project that is ready to go as a plugin project! Next we'll create our first plugin class.
