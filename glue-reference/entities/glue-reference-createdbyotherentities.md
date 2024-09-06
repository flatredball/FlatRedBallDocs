# CreatedByOtherEntities

The CreatedByOtherEntities property controls whether a Factory is created for a given Entity. The name "CreatedByOtherEntities" suggests that an entity may be created in the CustomActivity of another entity, such as a Bullet being created in the Player's CustomActivity in response to a button press. Despite its name, Factories are not limited to use inside other entities - the can (and often are) used inside screens as well as entities.

CreatedByOtherEntities defaults to true for Entities which have been created using the default configuration. This value can be changed at any time to modify whether a Factory class is created for the given Entity.

![CreatedByOtherEntities in the Properties tab](<../../.gitbook/assets/06\_05 59 20.png>)

Setting this property to true does the following:

* FlatRedBall generates a factory for the Entity type which includes a CreateNew for creating new Entity instances.
* FlatRedBall automatically adds any newly-created instance of the given Entity to any PositionedObjectLists created in any Screens in Glue.
* FlatRedBall displays an additional property "PooledByFactory" for enabling pooling to reduce post-load memory allocation.

For more information on Factories, see the [Factories page](../factory/).
