## Introduction

UWP (which stands for Universal Windows Platform) is a project type which can run on Windows desktop, tablets, and Xbox One.

## Installing MonoGame 3.7

As of August 2023, FlatRedBall UWP requires MonoGame 3.7. To install this:

1.  Go to <https://community.monogame.net/t/monogame-3-7-1/11173>
2.  Install [MonoGame 3.7.1 for VisualStudio](https://github.com/MonoGame/MonoGame/releases/download/v3.7.1/MonoGameSetup.exe)

## Xbox One

### There was a mismatch between the processor architecture of the project being built "AMD64" ...

If running on Xbox One, you may see the following error:

``` wrap:true
There was a mismatch between the processor architecture of the project being built "AMD64" and the processor architecture of the reference "FlatRedBallUwp", "x86". This mismatch may cause runtime failures. Please consider changing the targeted processor architecture of your project through the Configuration Manager so as to align the processor architectures between your project and references, or take a dependency on references with a processor architecture that matches the targeted processor architecture of your project.
```

To solve this:

1.  Open the Visual Studio Dev Console
2.  Browse to the libraries/uwp/debug folder where the FlatRedBall dlls are stored
3.  Run the following command: corflags flatredballuwp.dll /32BITREQ-

Alternatively, you can create a new build of the FlatRedBall UWP engine for 64-bit by building from source.
