# Linking FNA

### Introduction

By default FlatRedBall projects link pre-built binary files including prebuilt FNA libraries. You may want to link your FlatRedBall project to FNA source for improved debuggability or to contribute back to FNA.

This document includes the required steps for linking your game to FNA.

### Linking Your Game to FRB Source

Before you link your game to FNA, you must first link your game to FRB source. If you do not do this, then the FlatRedBall.FNA nuget package will include FNA which results in the FNA libraries being included twice.

Follow the steps outlined here to link your game to source: [Linking your Game to FlatRedBall Source](../flatredball-source.md#adding-flatredball-source-to-a-game-project-using-the-frb-editor).

Once you have finished these steps, your solution should include your game project and all FlatRedBall source projects.

<figure><img src="../.gitbook/assets/image (352).png" alt=""><figcaption><p>A game named FnaTest4 linking all FlatRedBall FNA source projects</p></figcaption></figure>

{% hint style="info" %}
FNA is a submodule of the FlatRedBall repository so be sure you clone FlatRedBall recursively to get FNA.
{% endhint %}

### Linking Latest Native Libraries

By default FlatRedBall templates include FNA binaries which are marked as copy if newer. These can be found in your game's csproj at the root level:

<figure><img src="../.gitbook/assets/image (353).png" alt=""><figcaption><p>FNA native libraries in a game</p></figcaption></figure>

These are marked as copy if newer:

<figure><img src="../.gitbook/assets/image (354).png" alt=""><figcaption><p>One of the FNA files marked as Copy if newer</p></figcaption></figure>

If you would like to update these to the latest version, you can:

1. Download the latest daily files from [https://github.com/FNA-XNA/fnalibs-dailies/actions](https://github.com/FNA-XNA/fnalibs-dailies/actions)
2. Unzip the folder for x64
3. Copy the files into your game project

The latest .dll files will now be copied to your bin folder whenever the game is built.
