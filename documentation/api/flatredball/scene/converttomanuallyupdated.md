## Introduction

This method converts all contained [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel.md "FlatRedBall.Graphics.Model.PositionedModel") to be manually-updated. This can be used to greatly improve performance of your game if your Scene does not have any kind of every-frame activity such as velocity, color rates, or attachments.

This method can be called after the Scene is added to managers using [AddToManagers](/frb/docs/index.php?title=FlatRedBall.Scene.AddToManagers.md "FlatRedBall.Scene.AddToManagers").
