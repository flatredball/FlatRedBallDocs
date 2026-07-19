# Gum

### Gum Runtimes (NuGet Packages)

Gum's repository includes a GitHub Action yaml file which builds and uploads NuGet packages. This DOES NOT currently upload a new Gum tool - this is a separate process (see below).

To upload a new NuGet packages, follow these steps:

1. Go to GitHub Gum actions: [https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml](https://github.com/vchelaru/Gum/actions/workflows/dotnet-nuget.yaml)
2. Click Run workflow.
3. Select the branch (probably main), check both options for publishing
4. Enter the new version name such as 2026.5.2.1. The format is `year.month.day.build` where build only increments if multiple builds happened in the same day. Note that if you are releasing a preview build, then append -preview.1. See [https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab](https://www.nuget.org/packages/Gum.MonoGame/#versions-body-tab) for examples

### Gum Tool



1. **Generate release notes.** In Claude Code, from the Gum repo, run `/gum-monthly-release`. It will ask three things up front:&#x20;
   1. **New release tag** — the tag you'll cut, using the convention `Release_<Month>_<DD>_<YYYY>` based on the day you run the release Action (e.g. `Release_May_31_2026`). The release does **not** need to exist yet; this name only titles the draft and the changelog link.&#x20;
   2. **Previous-release boundary** — paste the URL (or tag) of the most recent published release. That's what gets diffed against `main`. It already has a tag, which is all the diff needs.&#x20;
   3. **Breaking-changes migration doc URL** — link the GitBook migration doc if there are breaking changes this month; otherwise say there are none and the Breaking Changes section is omitted.
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

FlatRedBall's `glue.yml` build downloads Gum's **latest GitHub release** (`Gum.zip` asset) and bundles it into FRBDK - Gum is no longer uploaded to the FlatRedBall FTP. If a new Gum tool version is needed in the FRB release, publish it on GitHub first (see above) before running FlatRedBall's Github Actions, otherwise FRBDK will bundle whatever Gum release currently happens to be "latest." This may be okay depending on if Gum has important new features.
