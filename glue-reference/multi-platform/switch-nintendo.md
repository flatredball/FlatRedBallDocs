# Switch (Nintendo)

### Introduction

FlatRedBall can be used to develop games for the Nintendo Switch. To develop games for the Nintendo Switch, your game should be using the FNA platform. To deploy to the Nintendo Switch you must:

* Target .NET 7 or newer
* Verify that your project compiles and runs using Native AOT
* Have Nintendo Switch hardware. You must register with the Nintendo Developer Program: [https://developer.nintendo.com/](https://developer.nintendo.com/)

### FNA vs MonoGame

Both FNA and MonoGame can technically be used to develop games for the Nintendo Switch; however, the FNA path has a number of benefits:

1. FNA allows the use of modern .NET versions (7+). MonoGame requires translating code to C++ using BRUTE which does not support modern .NET and C# features.
2. As of December 2023, FlatRedBall has yet to run on the Nintendo Switch. FNA demos have been deployed to switch.
3. The MonoGame team which was responsible for console support has been less active since 2021. The FNA team continues to be active as of December 2023.
4. More games have been deployed to consoles recently using FNA rather than MonoGame as of December 2023.
5. Internally, the FlatRedBall team is testing FNA and will provide support to any games which run into problems with FNA.
