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

To release Gum tool:

1. Create new release notes on GitHub including
   1. Screenshots for new features
   2. Breaking changes
2. Create migration doc on gitbook
3. Run the action to release the Gum tool
4. Copy the release notes onto the new release
5. Add a new page in the Gum Upgrade section explaining how to upgrade this version. If no changes are needed, explain that the upgrade can happen without any changes.&#x20;
6. Announce on FRB discord
7. Announce on MonoGame discord
8. Announce on MGE discord
9. Announce on Kni discord
10. Announce on twitter
11. Announce on Blue Sky

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
