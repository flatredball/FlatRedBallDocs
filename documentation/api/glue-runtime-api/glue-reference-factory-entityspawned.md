## Introduction

The EntitySpawned delegate allows custom code to react to an entity instance being created. For example a game may want to add an Entity to a custom list when spawned.

## Code Example

The following code assigns a custom EntitySpawned delegate which adds any created ball instance to the CustomBallList:

    void CustomInitialize()
    {
        BallEntityFactory.EntitySpawned += ReactToBallSpawn;
    }

    private void ReactToBallSpawn(Entities.BallEntity newObject)
    {
        this.CustomBallList.Add(newObject);
    }
