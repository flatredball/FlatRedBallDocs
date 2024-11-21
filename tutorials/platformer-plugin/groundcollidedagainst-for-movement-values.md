# GroundCollidedAgainst and Movement Values

### Introduction

The GroundCollidedAgainst property can be used to detect the type of terrain that a platformer entity is standing on. This property, along with the standard ItemsCollidedAgainst property, can be used to perform complex logic in response to collision after all collision for a frame has been resolved. The most common use of the GroundCollidedAgainst property is to assign movement values.

{% hint style="info" %}
The GroundCollidedAgainst property is only available for gluj version 22 and newer. For more information see the [FileVersion (.gluj)](../../glue-reference/glujglux.md) page. New FlatRedBall projects use this version, but some of the samples linked in the Platformer tutorials may not have this value available.
{% endhint %}

### Code Example - Setting GroundMovement According to GroundCollidedAgainst

Typically a platformer game will have collision relationships between the Player and various TileShapeCollections. For example, the following screenshot shows collision relationships between the Player and a number of TileShapeCollections.

![](../../.gitbook/assets/2022-12-img\_639e3fcf67694.png)

Whenever the player collides with one of these TileShapeCollections, the GroundCollidedAgainst property will be updated. Some games may have multiple TileShapeCollections represent one type of terrain (such as Ice and IceCloud), so all collision should be resolved before determining the terrain type. In such a situation, the Player entity can have properties for determining the ground type as shown in the following code snippet:

```
public bool IsOnIce => GroundCollidedAgainst.Contains(nameof(GameScreen.IceCollision)) 
    || GroundCollidedAgainst.Contains(nameof(GameScreen.IceCloudCollision));
public bool IsOnSticky => GroundCollidedAgainst.Contains(nameof(GameScreen.StickyCollision));
```

These properties enable the assignment of movement values, such as GroundMovement, in CustomActivity as shown in the following code snippet:

```
if (IsOnIce)
{
    this.GroundMovement = PlatformerValuesStatic[DataTypes.PlatformerValues.IceGround];
}
else if(IsOnSticky)
{
    this.GroundMovement = PlatformerValuesStatic[DataTypes.PlatformerValues.StickyGround];
}
else if(IsInWater)
{
    this.GroundMovement = PlatformerValuesStatic[DataTypes.PlatformerValues.WaterGround];
}
else
{
    this.GroundMovement = PlatformerValuesStatic[DataTypes.PlatformerValues.Ground];
}
```

Similar logic could be performed to assign AirMovement and AfterDoubleJump. Consider that the code above requires that the GameScreen has its collision objects exposed publicly. To verify this is the case, select the object in the FlatRedBall Editor and check its HasPublicProperty value.

![](../../.gitbook/assets/2022-12-img\_639e412b7745d.png)
