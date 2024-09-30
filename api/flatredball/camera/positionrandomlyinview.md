# PositionRandomlyInView

### Introduction

The PositionRandomlyInView sets the Position of a [PositionedObject](../../../frb/docs/index.php) randomly inside the view of the Camera calling the method. This can be used to quickly place one or more objects at a random position in the Camera's view and is commonly used in debugging and simple test applications.

### Example

The following code creates 100 [Sprites](../../../frb/docs/index.php) and places them randomly in the Camera's view. All [Sprites](../../../frb/docs/index.php) are between 20 and 60 units in front of the Camera. Add the following in Initialize after initializing FlatRedBall

```
for (int i = 0; i < 100; i++)
{
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    float minimumDistance = 20;
    float maximumDistance = 60;
    SpriteManager.Camera.PositionRandomlyInView(
        sprite, minimumDistance, maximumDistance);
}
```

![PositionRandomlyInView.png](../../../.gitbook/assets/migrated\_media-PositionRandomlyInView.png)
