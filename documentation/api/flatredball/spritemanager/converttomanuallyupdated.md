## Introduction

The ConvertToManuallyUpdated method allows for the conversion of an automatically updated object to a manually updated object. Objects can be made manually updated so that they are still rendered by the engine, but automatic updates won't be performed. This can be done to improve performance. At the time of this writing, the following types can be converted to manually updated objects:

-   [FlatRedBall.Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite")
-   [FlatRedBall.PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") (this includes [Entities in Glue](/frb/docs/index.php?title=Glue.md "Glue"))

For information on manually updated objects, see [this tutorial](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects.md "FlatRedballXna:Tutorials:Manually Updated Objects").

## What does converting to manually updated do?

Converting a Sprite or PositionedObject to a manually updated disables the application of:

-   Velocity
-   Acceleration
-   Drag
-   RotationZVelocity
-   RelativeVelocity

Furthermore, the engine assumes that manually updated Sprites will not change very often. Therefore, it pre-calculates the vertices needed for rendering and caches them. If a Sprite does actually get updated, then it will need to have these vertices re-calculated. This can be performed through the [ManualUpdate](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.ManualUpdate "FlatRedBall.SpriteManager.ManualUpdate") method.

## Moving Manually-Updated Sprites

If a Sprite is moving and it is manually updated, then it will not visually reflect the movement unless:

-   [ManualUpdate](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.ManualUpdate "FlatRedBall.SpriteManager.ManualUpdate") is called
-   The Sprite is converted back to being an automatically updated Sprite using [ConvertToAutomaticallyUpdated](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.ConvertToAutomaticallyUpdated "FlatRedBall.SpriteManager.ConvertToAutomaticallyUpdated")

## When to convert

In short, an object should be manually updated if it does not need automatic updates. This can improve performance. For more information, see [the manually updated objects tutorial](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects.md "FlatRedballXna:Tutorials:Manually Updated Objects").

## Related Information

-   [FlatRedBall.SpriteManager.AddManualSprite](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.AddManualSprite "FlatRedBall.SpriteManager.AddManualSprite")
-   [FlatRedBall.SpriteManager.ConvertToAutomaticallyUpdated](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager.ConvertToAutomaticallyUpdated "FlatRedBall.SpriteManager.ConvertToAutomaticallyUpdated")
