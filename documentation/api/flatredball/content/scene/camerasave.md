## Introduction

The CameraSave class is a class that can store information about a [FlatRedBall.Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera") which can be saved and loaded to/from disk. The CameraSave class appears in the [SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene "FlatRedBall.Content.SpriteEditorScene") class.

## Setting a Camera's properties from a CameraSave instance

The most common use of the CameraSave class is in the [SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene "FlatRedBall.Content.SpriteEditorScene") class.

The following code loads a [SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene "FlatRedBall.Content.SpriteEditorScene") from a .scnx file and sets the default [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera") properties to match the CameraSave.

    // This assumes that Content\MyScene.scnx is a valid .scnx file
    SpriteEditorScene ses = SpriteEditorScene.FromFile(@"Content\MyScene.scnx");
    // We'll use the default Camera:
    Camera cameraToSet = SpriteManager.Camera;
    // Now simply apply the properties as follows:
    ses.Camera.SetCamera(cameraToSet);

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
