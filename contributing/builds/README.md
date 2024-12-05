# Builds (Releases)

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
   4. [Automated Test Project](../automated-test-project.md)
2. Run [Engine.yml](https://github.com/vchelaru/FlatRedBall/actions/workflows/Engine.yml) and wait for it to finish successfully
3. Run Glue.yml and wait for it to finish successfully
4. [Download latest FRBDK and run Glue](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip) - make sure the file version is what you expect
5. Make a new platformer project and check the version on the .csproj - make sure the file version is what you expect
   1. Note for December 2024 (or whatever release is after November 2024) - the November release had missing Gum font builder exe. Vic tested this on Nov 13 and was unable to reproduce it when running locally. More diagnostics have been added, so if the font builder exe is missing, check the logs to see if it was zipped.
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
