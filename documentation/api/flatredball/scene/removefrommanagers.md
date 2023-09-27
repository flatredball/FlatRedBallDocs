## Introduction

The RemoveFromManagers method will remove all contained objects from their respective FlatRedBall managers. Calling this method will result in all contained objects no longer being rendered and no longer being updated.

RemoveFromManagers will also clear out the Scene.

## Preventing clearing the Scene

If you do not want the Scene to be cleared when calling RemoveFromManagers, you can first make it one-way. For example:

    SceneInstance.MakeOneWay();
    SceneInstance.RemoveFromManagers();

For more information see the [MakeOneWay page](/frb/docs/index.php?title=FlatRedBall.Scene.MakeOneWay.md "FlatRedBall.Scene.MakeOneWay").
