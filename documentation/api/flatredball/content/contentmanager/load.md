# load

### Introduction

The Load  method is used to obtain a reference to an object which is created from a file on disk. Common examples of are Texture2D  (usually from a .png file), SoundEffect  (usually from a .wav file), and AnimationChainList  (usually from a .achx file). The Load  method caches a file when successfully loaded, and subsequent calls to the Load  method will return the cached reference.

### Texture2D

The Load method can be used to load a Texture2D  from an image file.

#### Exceptions

```lang:default
System.InvalidOperationException: This image format is not supported ---> System.ArgumentException: Handle must be valid. Parameter name: array
```

This exception can occur if your game is attempting to load a texture that is larger than is supported on the hardware running your game. For example, at the time of this writing many Android devices support 4096x4096 textures, but phones which only support 2048x2048 are still somewhat common. If the phone does not support loading the texture due to dimensions the app will throw a System.InvalidOperationException .
