# SetScaleXRatioToY

### Introduction

SetScaleXRatioToY and SetScaleYRatioToX are two methods which can be used to adjust either the ScaleX or ScaleY values on a Sprite such that its aspect ratio (width to height ratio) matches the source Texture's aspect ratio. SetScaleXRatioToY will modify ScaleX and keep ScaleY constant. SetScaleYRatioToX will modify ScaleY and keep ScaleX constant.

### Code Example

The following creates a large redball Sprite. The ScaleY is set, then the ScaleY is set through the SetScaleXRatioToY method. Add the following to initialize after initializing FlatRedBall:

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
sprite.ScaleY = 10;
sprite.SetScaleXRatioToY();
```

![SetScaleXRatioToY.png](../../../.gitbook/assets/migrated\_media-SetScaleXRatioToY.png)
