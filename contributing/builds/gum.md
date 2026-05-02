# Gum

### Gum Runtimes (NuGet Packages)

Gum's repository includes a GitHub Action yaml file which builds and uploads NuGet packages. This DOES NOT currently upload a new Gum tool - this is a separate process (see below).

To upload a new NuGet packages, follow these steps:

1. Go to GitHub Gum actions: [https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml](https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml)
2. Click Run workflow.
3. Select the branch (probably main), check both options for publishing
4. Enter the new version name such as 2026.5.2.1. The format is `year.month.day.build` where build only increments if multiple builds happened in the same day. Note that if you are releasing a preview build, then append -preview.1. See [https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab](https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab) for examples

### Gum Tool



1. Run /gum-monthly-release in Claude and give it the URL for the release, creating a markdown file
2. Create screenshots for anything that is decided as being important (in the top items)
3. Run the **Build and Release Gum Tool** action using a full release
4. Copy the release notes and screenshots to the release
5. Create/update migration doc on gitbook, or update what's already there
6. Announce on FRB discord
7. Announce on MonoGame discord
8. Announce on MGE discord
9. Announce on Kni discord
10. Announce on twitter
11. Announce on Blue Sky
12. Post on [https://community.monogame.net/](https://community.monogame.net/)

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
