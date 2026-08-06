# Multi-Platform

FlatRedBall supports developing games on multiple platforms. As of the time of this writing the following platforms are supported:

* Desktop (MonoGame, FNA)
  * Windows
  * Mac
  * Linux
* Android (MonoGame)
* iOS (MonoGame)
* Consoles (FNA and Native AOT compilation)
* Web (Kni)

{% hint style="warning" %}
**Android and iOS projects cannot currently be created.** Those engines target `net8.0-android` and `net8.0-ios`, whose workloads have reached end of life and are no longer available on the build machines, so the engines are not built or published and both options have been removed from the New Project and New Synced Project windows. The [Android](glue-how-to-create-a-flatredball-android-project/README.md) and [iOS](glue-reference-ios/README.md) pages are kept for reference and for whenever those projects are retargeted. Existing Android and iOS projects are unaffected — their NuGet packages are still published.
{% endhint %}

### Selecting Platforms

Your project's platform is selected when first creating a new project. A newly-created project selects a primary platform, which defines the primary project.&#x20;

<figure><img src="../../.gitbook/assets/image (89).png" alt=""><figcaption></figcaption></figure>

The primary project should be a desktop-based project (either MonoGame .NET Desktop GL or FNA at the time of this writing) even if you intend to target other platforms such as Android or consoles. Selecting a Desktop project as the primary project provides a number of benefits:

* Superior debugging
* C# Edit-and-continue
* FlatRedBall Editor Live Edit support
* Faster compilation and deployment
* Ability to add new platforms at any time

### Adding Additional Platforms Using Synced Projects

FlatRedBall provides the concept of _synced projects_ - these are projects which are created by the FlatRedBall Editor which are kept synced with the primary project. In other words, whenever a new Entity, Screen, or file is added through the FlatRedBall Editor, the synced project is updated to include the same code and content files. The FRB Editor also updates the files as necessary for each platform. For example, on PC a file may be set to copy to the output folder, while on Android it is set to an Android Asset.

Files which are manually added to a project (either synced or primary) are considered platform-specific and are not automatically synced. Of course, you are free to link these files manually through Visual Studio.

For more information on creating a synced project, see the [Synced Project](../menu/project/view-projects.md#new-synced-project) page.

### Conditional Compilation Symbols

FlatRedBall attempts to be as cross platform as possible. From time to time you may encounter code which is only available on one platform, especially if you are using 3rd party nuget packages. Therefore, you may need to exclude certain code from platforms.&#x20;

For example, the following code could be used to perform logic which is specific to web or desktop:

```csharp
#if DESKTOP_GL
DoDesktopGlSpecificLogic();
#endif

#if WEB
DoWebSpecificLogic
#endif
```

The following compilation symbols are available:

* ANDROID
* FNA (not a platform, but can still be checked)
* DESKTOP\_GL
* IOS
* WEB

You can also add your own conditional compilation symbols to the .csproj, and may are available automatically through .NET such as `NET8_0_OR_GREATER`
