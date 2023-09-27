## Introduction

AnimationChainListSaves are the ["save"](/frb/docs/index.php?title=Tutorials:Save_Classes.md "Tutorials:Save Classes") object type for [AnimationChainLists](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChainList.md "FlatRedBall.Graphics.Animation.AnimationChainList"). AnimatiohChainListSaves can be used to create and load .achx files. For general information on common FlatRedBall types, see the [FlatRedBall File Types](/frb/docs/index.php?title=FlatRedBall_File_Types.md "FlatRedBall File Types") wiki entry.

The AnimationChainListSave class is a standardized way to save an [AnimationChainList](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChainList.md "FlatRedBall.Graphics.Animation.AnimationChainList"). Using the AnimationChainListSave class has the following benefits:

1.  Requires very little code to use
2.  Resulting files are 100% compatible with the FRBDK or any other application that can load .achx files.

## Loading a .achx file

You can load load a AnimationChainListSave as follows:

    AnimationChainListSave saveInstance = AnimationChainListSave.FromFile("fileName.achx");

## Saving a .achx file

The following code saves a .achx file named MyAnimationChainList.achx. It assumes that animationChainList is a valid [AnimationChainList](/frb/docs/index.php?title=FlatRedBall.Graphics.Animation.AnimationChainList.md "FlatRedBall.Graphics.Animation.AnimationChainList").

Add the following using statements:

    using FlatRedBall.Content.AnimationChain;
    using FlatRedBall.Graphics.Animation;

Assumes animationChainList is a valid AnimationChainList:

     AnimationChainListSave save =
        AnimationChainListSave.FromAnimationChainList(animationChainList);
     string fileName = "MyAnimationChainList.achx";
     save.Save(fileName);

### Saving a loaded AnimationChainListSave

Of course, you can save a loaded AnimationChainListSave:

    string fileName = "fileName.achx";
    // load it
    AnimationChainListSave saveInstance = AnimationChainListSave.FromFile(fileName);
    // and save it
    saveInstance.Save(fileName);

Of course, the code above does nothing; however, you can do things to the saveInstance between the load and save calls:

     string fileName = "fileName.achx";
    // load it
    AnimationChainListSave saveInstance = AnimationChainListSave.FromFile(fileName);
    foreach(AnimationChainSave chainSave in saveInstance.AnimationChains)
    {
       // Do whatever to the chainSave
       // You can even loop through the frames:
       foreach(AnimationFrameSave frameSave in chainSave.Frames)
       {
           // do whatever you want to frames
       }
    }
    // and save it
    saveInstance.Save(fileName);

In fact, you can do pretty much anything to an AnimationChainListSave instance and it will result in a valid .achx file when saving it out. This enables you to easily create tools to create and modify .achx files.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
