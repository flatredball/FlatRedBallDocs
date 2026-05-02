# Gum

### Gum Runtimes (NuGet Packages)

Gum's repository includes a GitHub Action yaml file which builds and uploads NuGet packages. This DOES NOT currently upload a new Gum tool - this is a separate process (see below).

To upload a new NuGet packages, follow these steps:

1. Go to GitHub Gum actions: [https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml](https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml)
2. Click Run workflow.
3. Select the branch (probably main), check both options for publishing
4. Enter the new version name such as 2026.5.2.1. The format is `year.month.day.build` where build only increments if multiple builds happened in the same day. Note that if you are releasing a preview build, then append -preview.1. See [https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab](https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab) for examples

### Gum Tool

Experimental:

1. Run /gum-monthly-release in Claude and give it the URL for the release



Old:

To release Gum tool:

1. Run the **Build and Release Gum Tool** action
   1. Run a **prerelease** build
2. Create new release notes on GitHub including
   1. Screenshots for new features
   2. Breaking changes
3. Create migration doc on gitbook
4. Run the action to release the Gum tool
5. Copy the release notes onto the new release
6. Add a new page in the Gum Upgrade section explaining how to upgrade this version. If no changes are needed, explain that the upgrade can happen without any changes.&#x20;
7. Announce on FRB discord
8. Announce on MonoGame discord
9. Announce on MGE discord
10. Announce on Kni discord
11. Announce on twitter
12. Announce on Blue Sky
13. Post on [https://community.monogame.net/](https://community.monogame.net/)

This file is used when creating FlatRedBall builds, so Gum must first be built and uploaded to the FlatRedBall FTP prior to running the FlatRedBall Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
