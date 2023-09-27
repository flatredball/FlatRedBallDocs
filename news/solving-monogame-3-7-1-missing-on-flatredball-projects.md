Recently a new version of FlatRedBall was released targeting .NET 6.0. This version has a lot of benefits as explained in a [previous blog post](/news/flatredball-moves-to-net-6-and-much-more.md), but it does introduce one problem for games targeting MonoGame 3.7.1. You may notice an error that says Could not load the project \<project location\> because MonoGame 3.7.1 files are missing.

![](/media/2022-10-img_6352864d98eb5.png)

Fortunately this can be solved fairly easily. To do so:

1.  Locate your .csproj file on disk
2.  Open the .csproj file in a text editor
3.  Look for and remove the following lines in the .csproj:

Near the top of the file:

    <Import Project="$(MSBuildExtensionsPath)\MonoGame\v3.0\MonoGame.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\MonoGame\v3.0\MonoGame.Common.props')" />

Usually in the middle of the file:

    <MonoGameContentReference Include="content\Content.mgcb" />

Near the end of the file:

    <Import Project="$(MSBuildExtensionsPath)\MonoGame\v3.0\MonoGame.Content.Builder.targets" />

## Why is this happening?

It seems as if the version of MSBuild tied to Visual Studio 2022 does not understand the MonoGame content pipeline files. Fortunately, these aren't needed for most projects because the FlatRedBall Editor automatically handles the building of content pipeline files (such as .wav and .ogg) using the external MonoGame Content Builder. Therefore, the lines shown above are only needed for projects which manually maintain content pipeline files themselves - usually not the case for FlatRedBall projects.

 
