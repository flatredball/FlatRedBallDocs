## Introduction

The ForceUpdateDependencies for the Camera performs all of the same functionality as the [PositionedObject's ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies "FlatRedBall.PositionedObject.ForceUpdateDependencies") call, but it also does a few extra things. Specifically, it updates the mins and maxes of the camera, and recalculates its View and Project matrices. For information on ForceUpdateDependencies as it relates to [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") in general, see the [PositionedObject's ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies "FlatRedBall.PositionedObject.ForceUpdateDependencies") page.

## When to call Camera.ForceUpdateDepenencies

If you are writing a game where you need to perform logic based off of the Camera's position or edge values, then you need to call ForceUpdateDependencies prior to asking the Camera for any of these values **if the Camera is attached to another object**. Games often need to know a Camera's position in custom code. Consider the following examples:

1.  You may be developing a top-down game which shows arrows on the edge of the screen to indicate where off-screen enemy units are located. The positioning of these units requires math using the Camera's position.
2.  The calculation of the visible [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") in a [SpriteGrid](/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteGrid "FlatRedBall.ManagedSpriteGroups.SpriteGrid") requires up-to-date Camera position values.
3.  Your game may be a 3D game which uses a 2D [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer "FlatRedBall.Graphics.Layer") for HUD. The 2D elements in your game may be based off of the 3D position of elements in the world (this is a more complex case).

If your Camera is attached to another object, you will need to call ForceUpdateDependencies to make sure that all values are up-to-date.

## Order of calls

The order of calls matters in your game. The following code gives an example of how you would want to structure your Screen's CustomActivity if you plan on using the Camera's positioning:

    void CustomActivity(bool firstTimeCalled)
    {
        // First we perform any logic that may modify the Camera's position
        // If your Camera-modifying position is being done in an Entity, and
        // if that Entity is part of the Screen and you are using Glue, then the
        // Entity's CustomActivity will have already been called for the frame by
        // the time the Screen's CustomActivity is called.  Therefore, by this point
        // the only code that will modify the Camera will be in any Custom code you call
        CameraPositionModifyingLogic();
        
        SpriteManager.Camera.ForceUpdateDependencies();
       
        LogicThatDependsOnTheCamerasPosition();
        
    }

## View and Project matrices

As mentioned above, if you are translating between 3D and 2D coordiantes, you may still need to call ForceUpdateDepencies even if you are only updating the Camera's position manually. The reason for this is because you may end up using the Camera's matrices for calcualting the translations, and these are only updated when the Camera's dependencies are updated. Therefore, if you are experiencing unexpected behavior when translating between 3D and 2D (or 2D and 3D), then you should try calling ForceUpdateDependencies.
