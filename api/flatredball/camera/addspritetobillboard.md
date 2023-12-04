# AddSpriteToBillboard

### Introduction

To "billboard" a Sprite means to adjust its rotation so that it is always facing the Camera. Billboarded sprites are only needed for games with a 3D camera. Note that billboarded sprites typically not used for UI because UI and HUD should be handled by Gum.

Games like Doom used a billboard effect on enemies and items. Mario 64 also used a billboard effect on its trees. This effect is evident when running around billboarded Sprites. &#x20;

<figure><img src="../../../media/migrated_media-N64_super_mario_64_start.jpg" alt=""><figcaption></figcaption></figure>

The AddSpriteToBillboard tells the calling Camera to hold a reference to the argument [Sprite](../sprite/) and adjust its rotation every frame so that it faces the Camera.

### Usage

```csharp
// Assuming mySprite is a valid Sprite:
Camera.Main.AddSpriteToBillboard(mySprite);
```

### Billboarding and Rotation

Billboarding is implemented by modifying the argument [Sprite's](../../../frb/docs/index.php) Rotation values. Therefore, a billboarded [Sprite](../../../frb/docs/index.php) cannot be rotated on its X or Y axes. In other words, billboarding overwrites RotationX and RotationY values. Changing any rotation or rotation velocity values on the X or Y will not have any impact on billboarded [Sprites](../../../frb/docs/index.php). Billboarded Sprites can still be rotated on the Z axis.

### Billboarding and Attachment

Both billboarding and attachments modify the rotation of [PositionedObjects](../../../frb/docs/index.php). To resolve this conflict, you are responsible for deciding which should take precedence. If you'd like the attachment to be dominant, you should not make a [Sprite](../../../frb/docs/index.php) billboarded. If, on the other hand, you still want your [Sprite](../../../frb/docs/index.php) to be billboarded, but it should have an attachment, set the [ParentRotationChangesRotation](../../../frb/docs/index.php) property to false. For more information, see the [ParentRotationChangesRotation article](../../../frb/docs/index.php).
