# Inheriting from the Sprite Class

In general it is not recommended to inherit from the Sprite class. This can reslt in cluttered interfaces and improper instantiation of objects. Instead, we recommend using the [Entity pattern](../../../../frb/docs/index.php#Entity\_Tutorials) for your game objects. However, if you are sure that inheriting from the Sprite class is the only solution to your problem, you can do so by instantiating an object using your derived class, then adding it to the [SpriteManager](../../../../frb/docs/index.php). Assuming DerivedSprite is a class which inherits from the Sprite class, the following code can be used to add a newly created instance of the derived class to the [SpriteManager](../../../../frb/docs/index.php) and assign its texture.

```
DerivedSprite derivedSprite = new DerivedSprite();
derivedSprite.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
SpriteManager.AddSprite(derivedSprite);
```
