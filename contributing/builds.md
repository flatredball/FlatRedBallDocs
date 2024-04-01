# Builds

### Introduction

FlatRedBall builds are produced primarily using Github Actions. At the time of this writing, there are two github files:

* Engine.yml
* glue.yml

Both can be found in the workflows folder:

{% embed url="https://github.com/vchelaru/FlatRedBall/tree/NetStandard/.github/workflows" %}

These are explicitly invoked currently, and should only be invoked when it is time to make a new FRB release.

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

#### Gum Builds

Currently Gum uses XNA and .NET 4.7.1. It's not clear why, but this will not build using dotnet build. Therefore, Gum is built as follows:

1. Gum is built locally on Vic's machine using TeamCity
2. This build increases the build number and uploads it to the default location: [http://files.flatredball.com/content/Tools/Gum/Gum.zip](http://files.flatredball.com/content/Tools/Gum/Gum.zip)
3. The BuildServerUploader downloads this .zip file and unzips it in the FRBDK output directory as part of its steps.&#x20;
4. The FRBDK is zipped up using the latest Gum.

Therefore, when performing new builds, Gum must first be built and uploaded to the FlatRedBall FTP prior to running the Github Actions. Otherwise, an old Gum will be included in FRBDK. This may be okay depending on if Gum has important new features.
