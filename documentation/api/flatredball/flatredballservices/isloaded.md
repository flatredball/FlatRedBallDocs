## Introduction

The IsLoaded method can tell you if a certain piece of content is already loaded and cached in RAM. Simple games (especially games which use Glue) usually do not need to worry about this - Glue can handle content loading and unloading intelligently. However, if you are using custom loading code, especially if you are loading content without using FlatRedBall methods (such as creating Textures dynamically or from a memory stream), you may want to cache the loaded content in a FlatRedBall ContentManager, then use the IsLoaded method to check if it has already been cached to prevent recreating the same content multiple times.

## Usage

The IsLoaded method returns a bool whether the content is already loaded or not. To use this method you simply call IsLoaded passing in the key (also often referred to as "name") of the object you're looking for as well as the ContentManager name:

    bool isLoaded = FlatRedBallServices.IsLoaded<Texture2D>("redball.bmp", ContentManagerName);

Note that the type of the content must be used as a generic type to the IsLoaded method. The reason for this is because two pieces of content may have the same name (for example a Scene and a Texture2D may both be named "SpaceShip"). The generic argument allows FlatRedBall to distinguish between the two.
