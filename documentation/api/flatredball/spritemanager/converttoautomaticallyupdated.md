## Introduction

ConvertToAutomaticallyUpdated can be used to convert an object back to an automatically updated object. This is useful for objects which typically do not move (so they shouldn't be automatically updated), but which may move from time to time. ConvertToAutomaticallyUpdated can be called on [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject").

## Code Example

The following shows how an entity can implement its own ConvertToAutomaticallyUpdated in custom code:

    public void ConvertToAutomaticallyUpdated()
    {
       // Convert the entity itself:
       SpriteManager.ConvertToAutomaticallyUpdated(this);
       
       // Convert any Sprites:
       SpriteManager.ConvertToAutomaticallyUpdated(BodySprite);

       // Text objects may need to be converted too:
       TextManager.ConvertToAutomaticallyUpdated(HealthText);

    }
