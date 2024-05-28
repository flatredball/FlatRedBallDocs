# Multi-Platform

FlatRedBall supports developing games on multiple platforms. As of the time of this writing the following platforms are supported:

* Desktop
  * Windows
  * Mac
  * Linux
* Android
* iOS
* Consoles (Switch, Xbox) through the use of FNA and Native AOT compilation

### Selecting Platforms

Your project's platform is selected when first creating a new project. A newly-created project selects a primary platform, which defines the primary project.&#x20;

<figure><img src="../../.gitbook/assets/image (2) (1) (1).png" alt=""><figcaption></figcaption></figure>

The primary project should be a desktop-based project (either MonoGame .NET Desktop GL or FNA at the time of this writing) even if you intend to target other platforms such as Android or consoles. Selecting a Desktop project as the primary project provides a number of benefits:

* Superior debugging
* C# Edit-and-continue
* FlatRedBall Editor Live Edit support
* Faster compilation and deployment
* Ability to add new platforms at any time

### Adding Additional Platforms Using Synced Projects

FlatRedBall provides the concept of _synced projects_ - these are projects which are created by the FlatRedBall Editor which are kept synced with the primary project. In other words, whenever a new Entity, Screen, or file is added through the FlatRedBall Editor, the synced project is updated to include the same code and content files. The FRB Editor also updates the files as necessary for each platform. For example, on PC a file may be set to copy to the output folder, while on Android it is set to an Android Asset.

Files which are manually added to a project (either synced or primary) are considered platform-specific and are not automatically synced. Of course, you are free to link these files manually through Visual Studio.

