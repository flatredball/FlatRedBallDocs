# Gum

### Gum Runtimes (NuGet Packages)

Gum's repository includes a GitHub Action yaml file which builds and uploads NuGet packages. If the build succeeds and if the NuGet numbers are new, then new NuGet packages are uploaded.

The automated build will not upload a new NuGet if the version number is not manually increased first. Also note, this DOES NOT currently upload a new Gum tool - this is a separate process (see below).

To upload a new NuGet packages, follow these steps:

1. Create a new branch like `ReleaseCode_2025_11_30` . This is `ReleaseCode_YYYY_MM_DD`.
2. Open AllLibraries.sln in Visual Studio - this links MonoGame/FNA/Kni Gum and the projects it depends on. It is at \<GumRoot>\MonoGameGum.sln
3.  Double-click GumCommon and find the version. Copy this, then do a global find/replace to update all versions to the latest version.\
    \
    \
    <br>

    <figure><img src="../../.gitbook/assets/image (83).png" alt=""><figcaption><p>Setting GumCommon's Version number</p></figcaption></figure>

    at the time of this writing, 8 projects will be updated.
4. Save the files and push the commit
5. Run the github action on this branch, it's faster than merging first, so you don't have to wait
6. Merge the commit to `Master`

### Gum Tool

Currently Gum uses .NET 4.7.1. This will not build using dotnet build (not sure why). Therefore, Gum must be built and uploaded manually. We could eventually automate this through TeamCity until Gum (maybe?) gets updated to modern .NET. Until then the steps are:

1. Open Gum locally in Visual Studio
2.  Open Gum AssemblyInfo.cs and set AssemblyVersion and AssemblyFileVersion using the date-based format. Notice that there's only 3 numbers unlike the versions for NuGet packages.<br>

    <figure><img src="../../.gitbook/assets/23_07 47 02.png" alt=""><figcaption><p>AssemblyVersion and AssemblyFileVersion in AssemblyInfo.cs</p></figcaption></figure>
3. Rebuild the entire solution (not just the Gum project)
4. Navigate to the location where Gum is built
5. Go up one folder so that you are outside of the Debug folder
6. Create a Data folder if one doesn't exist and copy the Debug folder into it
7. Right-click on Data and Zip it. This will produce a .zip that has a Data/Debug folder inside - this matches the expected folder structure from previous builds so make sure this is the case. This may change in the future.
8. Rename this Gum.zip
9. Manually upload this to FlatRedBall's Files folder using sftp to /home/frbfiles/files.flatredball.com/content/Tools/Gum/Gum.zip
10. Create a new release on Github - see the previous releases for examples
11. Add a new page in the Gum Upgrade section explaining how to upgrade this version. If no changes are needed, explain that the upgrade can happen without any changes.&#x20;
12. Announce on FRB discord
13. Announce on MonoGame discord
14. Announce on MGE discord
15. Announce on Kni discord
16. Announce on twitter
17. Announce on Blue Sky

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
