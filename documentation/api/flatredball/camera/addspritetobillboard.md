## Introduction

To "billboard" a Sprite means to adjust its rotation so that it is always facing the Camera. Games like Doom used a billboard effect on enemies and items. Mario 64 also used a billboard effect on its trees. This effect is evident when running around billboarded Sprites. ![N64 super mario 64 start.jpg](/media/migrated_media-N64_super_mario_64_start.jpg) The AddSpriteToBillboard will tell the calling Camera to hold a reference to the argument [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and adjust its rotation every frame so that it faces the Camera.

## Usage

    // Assuming mySprite is a valid Sprite:
    SpriteManager.Camera.AddSpriteToBillboard(mySprite);

## Billboarding and Rotation

Billboarding is implemented by modifying the argument [Sprite's](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") Rotation values. Therefore, a billboarded [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") cannot be rotated on its X or Y axes. In other words, billboarding overwrites RotationX and RotationY values. Changing any rotation or rotation velocity values on the X or Y will not have any impact on billboarded [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). Billboarded Sprites can still be rotated on the Z axis.

## Billboarding and Attachment

Both billboarding and attachments modify the rotation of [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject"). To resolve this conflict, you are responsible for deciding which should take precedence. If you'd like the attachment to be dominant, you should not make a [Sprite](/frb/docs/index.php?title=Sprite "Sprite") billboarded. If, on the other hand, you still want your [Sprite](/frb/docs/index.php?title=Sprite "Sprite") to be billboarded, but it should have an attachment, set the [ParentRotationChangesRotation](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesRotation "FlatRedBall.Math.IAttachable.ParentRotationChangesRotation") property to false. For more information, see the [ParentRotationChangesRotation article](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesRotation "FlatRedBall.Math.IAttachable.ParentRotationChangesRotation").
