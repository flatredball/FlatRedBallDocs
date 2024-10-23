# LoadedAtRuntime

### Introduction

The LoadedAtRuntime property can be used to tell FlatRedBall whether to load a particular file when its Screen or Entity is created. By default the LoadedAtRuntime property is set to true, which means that an instance of a runtime object for the given file will be created. For example, if a PNG file is added to a Screen, then that Screen will contain a Texture2D instance.

![](../../.gitbook/assets/2023-06-img\_6491c586e85be.png)

If this value is set to false, then generated code will not contain a property for that file, nor will it automatically load the file. However, the file will still be part of the project, so you can load it and work with it in custom code.

### Common Usage

There are a number of reasons to set LoadedAtRuntime to false.

#### Custom handling of a File

LoadedAtRuntime is often set if a file is to be used in a custom way. For example, your game may include JSON files which you want to handle in custom code. LoadedAtRuntime can be set to false in projects which load file formats which are not natively understood by FlatRedBall (such as custom audio, texture, or model formats).

#### Selectively loading content

You can use LoadedAtRuntime if you want to selectively load files at runtime. For example, you may add multiple files to a Screen, but only load one of them depending on the state of the game.

This approach of handling files was more popular in the past, but modern FlatRedBall games typically use derived screens (typically level screens deriving from GameScreen) to conditionally load content.

### LoadedAtRuntime=false vs. LoadedOnlyWhenReferenced=true

The LoadedAtRuntime and LoadedOnlyWhenReferenced properties may seem to do similar things, and you may be wondering when to use one or the other. This section will discuss why both properties exist and why to use them.&#x20;

By default LoadedAtRuntime=true and LoadedOnlyWhenReferenced=false. This means that a file will always be loaded whenever its containing Screen/Entity is loaded.&#x20;

LoadedOnlyWhenReferenced=true can be used to either delay the loading of a file, or not load it at all depending on certain conditions in your game. For example, a particular texture for a Sprite may not be used if the player does not pick to use that specific file type. LoadedAtRuntime=false tells FlatRedBall that you want a particular file to be added to Visual Studio, and that the file should be available to your program at runtime, but only through the file system. FlatRedBall will not generate any code to load the file at all. This means that custom code is in charge of loading the file completely, and that custom code can decide what to load the file into. For example, if FlatRedBall generates code to load a .achx file, then it must be loaded into an AnimationChainList. If LoadedAtRuntime is set to false, it can be loaded into a different type like AnimationChainListSave, or even loaded into a string or some other custom type.
