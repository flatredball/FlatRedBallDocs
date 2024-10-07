# Automated Test Project

### Introduction

FlatRedBall includes an automated test project which can be used to verify that your changes have not broken existing projects. This project should be run to verify changes and should also be run prior to monthly releases.

### How to Run the Automated Test Project

1. Clone the FlatRedBall Repository
2. Build/Run Glue from source
3.  Open the Automated Test Project in Glue. It can be found here: \<FlatRedBall>\Tests\GlueTestProjectDesktopGl\GlueTestProjectDesktopGl.sln\


    <figure><img src="../.gitbook/assets/image.png" alt=""><figcaption><p>Autoamted Test Project in the FRB Editor</p></figcaption></figure>
4. After it has finished generating, open the project in Visual Studio
5. Rebuild the project
6. Run the project
7. Wait for it to finish - it will automatically exit

<figure><img src="../.gitbook/assets/07_07 50 13.gif" alt=""><figcaption><p>Automated test project running</p></figcaption></figure>

If you have an exception, then the project has encountered a failure.

### Automated Test Project Details

At the time of this writing the Automated Test Project is an older project. Specifically it is using:

* .NET 4.7.1
* MonoGame 3.7.0
* glux (xml) [Version 2](../glue-reference/glujglux.md)

This is intentional since a number of projects are using modern FlatRedBall versions. For example, at the time of this writing projects are tested by games such as Cranky Chibi Cthulhu and Kid Defense. By contrast, older projects are rarely opened so it is far more likely that these projects may break in response to changes made in Glue or FlatRedBall.

Therefore, this project provides testing coverage which is not offered by modern projects.

Newer projects may be added in the future, but this process is somewhat involved since these new projects should not be synced projects - instead they should be standalone projects, and they should only be added if we have decided to retire a version of FlatRedBall, or if the new project is being added specifically to test a paritcular platform or version (such as FlatRedBall Web).
