# Builds (Releases)

### Introduction

FlatRedBall builds are produced primarily using Github Actions. At the time of this writing, there are two github files:

* Engine.yml
* glue.yml

Both can be found in the workflows folder:

{% embed url="https://github.com/vchelaru/FlatRedBall/tree/NetStandard/.github/workflows" %}

These are explicitly invoked currently, and should only be invoked when it is time to make a new FRB release. Both accept `workflow_dispatch` and can be triggered with the `gh` CLI (`gh workflow run Engine.yml -f IsBeta=true`, `gh workflow run glue.yml`) instead of the Actions UI.

### Releases

To make a new (monthly) release:

1. If a new Gum tool version is needed in this release, publish it first: run Gum's [Build and Release Gum Tool workflow](https://github.com/vchelaru/Gum/actions/workflows/build-and-release.yml) with a full release. FRBDK bundles whatever GitHub currently reports as Gum's **latest** release (`releases/latest/download/Gum.zip`) - Gum is released on GitHub only, no FTP step involved.
2. Run tests - make sure that FRB Editor can open a variety of projects and that they run okay.
   1. New platformer project
   2. Kid Defense
   3. Cranky Chibi Cthulhu
   4. Battlecrypt Bombers
   5. [Automated Test Project](../automated-test-project.md)
3. Run [Engine.yml](https://github.com/vchelaru/FlatRedBall/actions/workflows/Engine.yml) with `IsBeta=true` first and wait for it to finish successfully; optionally sanity-check the beta NuGet packages before proceeding.
4. Run Engine.yml again with `IsBeta=false` and wait for it to finish successfully - this is the real NuGet publish and template upload.
5. Run Glue.yml and wait for it to finish successfully.
6. [Download latest FRBDK and run Glue](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip) - make sure the file version is what you expect.
7. Make a new platformer project and check the version on the .csproj - make sure the file version is what you expect.
8. Create a new release on Github including all the changes since last release
9. Create an announcement post on Discord including the # of changes and highlight the big changes
10. Copy the info to Twitter

### Engine.yml

The Engine.yml file is responsible for the following actions:

* Increasing the version number - this is not pushed to the repository but is set to the current date and minute locally on the github action. For example, running this on April 2nd, 2024 would set the versions to `2024.4.2.123` where the last number (123) is the total minutes of the current time. This allows multiple builds to run in a single day without producing conflicting verison numbers.
* Takes an `IsBeta` input (boolean). Beta only bumps NuGet/csproj versions (`-beta` suffix) and skips template upload; a non-beta run also copies engine DLLs to the templates and uploads them.
* Builds 5 platforms (Web/Kni, iOS, Android, FNA, DesktopGL) in both Debug and Release. Only the Debug build of each is currently published to NuGet - Release is built and kept as a workflow artifact only.
* Publish relevant nuget packages
* Upload newest templates

### Glue.yml

* Change version numbers (see above in Engine.yml for details)
* Build Glue
* Downloads Gum's latest GitHub release (`Gum.zip`) and bundles it into FRBDK - this is why step 1 above matters
* Zip and upload FRBDK.zip
