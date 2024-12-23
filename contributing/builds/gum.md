# Gum

### MonoGame Gum (NuGet Packages)

Team City has an automated build which runs whenever anything is pushed (assuming Vic's desktop is turned on). This attempts to build Gum (the tool) and the .NET 6 libraries use for MonoGameGum. If the builds succeeds it also attempts to upload a new nuget package.&#x20;

The automated build will not upload a new NuGet if the version number is not manually increased first. Also note, this DOES NOT currently upload a new Gum tool - this must be done manually (see steps below).

To upload a new NuGet packages, follow these steps:

1. Open MonoGameGum.sln in Visual Studio - this links MonoGame/Kni Gum and the projects it depends on. It is at \<GumRoot>\MonoGameGum.sln
2.  Double-click GumCommon and change its Version to the {year}.{month}.{day}.{build}, where build is 1 if it's the first build of the day.\


    <figure><img src="../../.gitbook/assets/image (83).png" alt=""><figcaption><p>Setting GumCommon's Version number</p></figcaption></figure>
3. Repeat this for GumDataTypesNet6, MonoGameGum, ToolsUtilitiesStandard, and KniGum. Be sure to use the same version for all.
4. Save the files and push the commit

If Vic's computer is on, it will automatically build. If not, Vic must open it and manually run a build.

#### Troubleshooting Gum Automatic Builds

Vic has noticed that sometimes the build will fail due to the referenced ColorPicker not being available. If the same .sln (in the build folder indicated in TeamCity logs) is opened and built in VS 2019, the manual build works. Then if TeamCity is run again, all works. This is a hacky workaround.

### Gum Tool

Currently Gum uses XNA and .NET 4.7.1. This will not build using dotnet build (not sure why). Therefore, Gum must be built and uploaded manually. We could eventually automate this through TeamCity until Gum (maybe?) gets updated to modern .NET. Until then the steps are:

1. Open Gum locally in Visual Studio
2.  Open Gum AssemblyInfo.cs and set AssemblyVersion and AssemblyFileVersion using the date-based format. Notice that there's only 3 numbers unlike the versions for nuget packages.\


    <figure><img src="../../.gitbook/assets/23_07 47 02.png" alt=""><figcaption><p>AssemblyVersion and AssemblyFileVersion in AssemblyInfo.cs</p></figcaption></figure>
3. Rebuild the entire solution (not just the Gum project)
4. Navigate to the location where Gum is built
5. Go up one folder so that you are in the Debug folder, and you see the Data folder
6. Right-click on Data and Zip it. This will produce a .zip that has a Data folder inside - this matches the expected folder structure from previous builds so make sure this is the case
7. Rename this Gum.zip
8. Manually upload this to FlatRedBall's Files folder using sftp to /home/frbfiles/files.flatredball.com/content/Tools/Gum/Gum.zip
9. Create a new release on Github - see the previous releases for examples
10. Announce on FRB discord
11. Announce on MonoGame discord
12. Announce on MGE discord
13. Announce on twitter

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
