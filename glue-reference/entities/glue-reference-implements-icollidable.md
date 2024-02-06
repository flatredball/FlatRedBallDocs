# Implements ICollidable

### Introduction

Entities which can collide with other entities or environments (such as terrain in a platformer) can have their ImplementsICollidable property set. Setting this property to true simplifies writing collision code and makes your code more resistant to changes made to collision objects in Glue.

### Creating an ICollidable Entity

When creating a new Entity, Glue will give you the option to mark it as ICollidable. The most common approach is to add a shape on the entity when creating it. For example, if the AxisAlignedRectangle check box is checked, Glue will automatically check the ICollidable check box.

![](../../media/2021-02-img\_60390a9d377a3.png)

### Making an Existing Entity an ICollidable Entity

If an entity is already created but not yet marked as a ICollidable, it can be marked as ICollidable in its **Properties** tab. ![ImplementsICollidable.png](../../media/migrated\_media-ImplementsICollidable.png) When marking an existing entity as ICollidable, be sure that your entity has a collidable object, such as a circle.

![](../../media/2021-02-img\_6039252b279e9.png)

For more information on the ICollidable interface as defined in FlatRedBall, see the [ICollidable](../../frb/docs/index.php) page. For more information on colliding Entities and using ImplementsICollidable, see [this page](broken-reference).

### Code Examples

Assuming that you are dealing with instances of entities which implement ICollidable, you can call CollideAgainst, CollideAgainstMove, and CollideAgainstBounce between them regardless of the shapes that they use for collision. The benefit of this is that you no longer have to explicitly access the collision objects in an Entity - you can write the code the same regardless of the shape type, and you do not have to change your code if you end up changing your shape objects in Glue.

#### CollideAgainst Example

CollideAgainst is useful when you only need to detect if two things are touching, but the objects do not need to be re-positioned in response to the collision. For example, the following code shows how to perform collision between a ship and a list of enemy bullets:

```lang:c#
foreach(var bullet in EnemyBullets)
{
    if(PlayerInstance.CollideAgainst(bullet))
    {
        bullet.Destroy();
        PlayerInstance.TakeDamage();
    }
}
```

#### CollideAgainstMove Example

CollideAgainstMove can be used to collide two objects, and re-position them according to their masses, as shown in the following code:

```
float firstMass = 1;
float secondMass = 1;
FirstBallInstance.CollideAgainstMove(SecondBallInstance, firstMass, secondMass);
```

Notice that the code above did not have to access the specific shape(s) in FirstBallInstance or SecondBallInstance to perform the collision.
