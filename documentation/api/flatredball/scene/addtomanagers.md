## Introduction

The AddToManagers method adds all contained elements in the calling Scene to their appropriate managers. Since a Scene can contain [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite"), [Text objects](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text"), and [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel"), this method can add objects to more than one manager. This method is most often called after a Scene is loaded through [FlatRedBallServices](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.md "FlatRedBall.FlatRedBallServices").

## Method Signatures

### public void AddToManagers()

Adds the contained elements to their respective managers so they draw in the regular non-layered space.

### public void AddToManagers(Layer layer)

Adds the contained elements to their respective managers for management and to the argument [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer.md "FlatRedBall.Graphics.Layer") for drawing.
