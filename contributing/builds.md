# Builds

### Introduction

FlatRedBall builds are produced primarily using Github Actions. At the time of this writing, there are two github files:

* Engine.yml
* glue.yml

Both can be found in the workflows folder:

{% embed url="https://github.com/vchelaru/FlatRedBall/tree/NetStandard/.github/workflows" %}

These are explicitly invoked currently, and should only be invoked when it is time to make a new FRB release.

### Releases

To make a new (monthly) release:

1. Run tests - make sure that FRB Editor can open a variety of projects and that they run okay. Also create new platformer and top down projects to make sure they work okay.
   1. Kid Defense
   2. Cranky Chibi Cthulhu
   3. Battlecrypt Bombers
   4. [Automated Test Project](automated-test-project.md)
2. Run [Engine.yml](https://github.com/vchelaru/FlatRedBall/actions/workflows/Engine.yml) and wait for it to finish successfully
3. Run Glue.yml and wait for it to finish successfully
4. [Download latest FRBDK and run Glue](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip) - make sure the file version is what you expect
5. Make a new platformer project and check the version on the .csproj - make sure the file version is what you expect
6. Create a new release on Github including all the changes since last release
7. Create an announcement post on Discord including the # of changes and highlight the big changes
8. Copy the info to Twitter

### Engine.yml

The Engine.yml file is responsible for the following actions:

* Increasing the version number - this is not pushed to the repository but is set to the current date and minute locally on the github action. For example, running this on April 2nd, 2024 would set the versions to `2024.4.2.123` where the last number (123) is the total minutes of the current time. This allows multiple builds to run in a single day without producing conflicting verison numbers.
* Build all versions of FRB in both release and debug
* Publish relevant nuget packages
* Upload newest templates

### Glue.yml

* Change version numbers (see above in Engine.yml for details)
* Build Glue
* Zip and upload FRBDK.zip

#### Gum Automatic Builds (MonoGame Gum)

Team City has an automated build which runs whenever anything is pushed (assuming Vic's desktop is turned on). This attempts to build Gum (the tool) and the .NET 6 libraries use for MonoGameGum. If the builds succeeds it also attempts to upload a new nuget package. Note that this will not upload a new NuGet if the version number is not manually increased first. Also note, this DOES NOT currently upload a new Gum tool - this must be done manually (see steps below).

To create the nuget packages, follow these steps:

1. Open MonoGameGum.sln in Visual Studio - this links MonoGame/Kni Gum and the projects it depends on. It is at \<GumRoot>\MonoGameGum.sln
2.  Double-click GumCommon and change its Version to the {year}.{month}.{day}.{build}, where build is 1 if it's the first build of the day.\


    <figure><img src="../.gitbook/assets/image (83).png" alt=""><figcaption><p>Setting GumCommon's Version number</p></figcaption></figure>
3. Repeat this for GumDataTypesNet6, MonoGameGum, ToolsUtilitiesStandard, and KniGum. Be sure to use the same version for all.
4. Save the files and push the commit

If Vic's computer is on, it will automatically build. If not, Vic must open it and manually run a build.

#### Troubleshooting Gum Automatic Builds

Vic has noticed that sometimes the build will fail due to the referenced ColorPicker not being available. If the same .sln (in the build folder indicated in TeamCity logs) is opened and built in VS 2019, the manual build works. Then if TeamCity is run again, all works. This is a hacky workaround.

#### Gum Builds

Currently Gum uses XNA and .NET 4.7.1. This will not build using dotnet build (not sure why). Therefore, Gum must be built and uploaded manually. We could eventually automate this through TeamCity until Gum (maybe?) gets updated to modern .NET. Until then the steps are:

1. Open Gum locally in Visual Studio
2.  Open Gum AssemblyInfo.cs and set AssemblyVersion and AssemblyFileVersion using the date-based format.\


    <figure><img src="../.gitbook/assets/image (318).png" alt=""><figcaption><p>AssemblyVersion and AssemblyFileVersion in AssemblyInfo.cs</p></figcaption></figure>
3. Rebuild Gum
4. Navigate to the location where Gum is built
5. Go up one folder so that you are in the Debug folder, and you see the Data folder
6. Right-click on Data and Zip it. This will produce a .zip that has a Data folder inside - this matches the expected folder structure from previous builds so make sure this is the case
7. Rename this Gum.zip
8. Manually upload this to FlatRedBall's Files folder using sftp to /home/frbfiles/files.flatredball.com/content/Tools/Gum/Gum.zip
9. Create a new release on Github - see the previous releases for examples

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
