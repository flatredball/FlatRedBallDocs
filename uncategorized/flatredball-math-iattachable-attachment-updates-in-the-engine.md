## Introduction

Attachments are an effective way to keep one [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") in a given position or rotation relative to another [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). However, attachments do not immediately modify children positions. This article will discuss when attachments are applied by the engine, exceptions to this rule, and how this behavior can be modified.

## Engine Flow

The following diagram shows a high-level view of the execution of a FlatRedBall game.

![HighLevelFlow.png](/media/migrated_media-HighLevelFlow.png)

Attachment code is executed in three places:

-   FlatRedBallServices.Update - RelativeVelocity is applied to modify RelativePosition and RelativeAcceleration is applied to modify RelativeVelocity and RelativePosition. Although Relative values change in this call, they are not used to modify absolute values yet.
-   Game-Specific Update - Game-specific code creates attachments and modifies relative values. Modifying relative values does not result in absolute values being modified yet.
-   FlatRedBallServices.Draw - Just prior to drawing, all relative values are applied and absolute values are updated.

The important thing to note is that relative values do not immediately modify absolute values. For performance reasons, absolute values are modified according to relative values only once per frame.

## Forcing Updates

Although the engine automatically updates absolute values according to relative values just before drawing, it may be necessary to perform this update in game-specific code. If so, the [ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md.ForceUpdateDependencies "FlatRedBall.PositionedObject.ForceUpdateDependencies") method can be called. See the [ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md.ForceUpdateDependencies "FlatRedBall.PositionedObject.ForceUpdateDependencies") code.
