# glue-reference-createnew

### Introduction

The CreateNew function is used to create a new instance of the Entity corresponding to the calling factory. In simple cases, the only requirement is simply calling this method an a new instance will be created and available for use in your code. For information on CreateNew in the context of a tutorial, see [this page](../../../../frb/docs/index.php#Using_the_Factory_in_code).

### Code Example

This code assumes that your project has an Entity called "Enemy" and that it has a corresponding Factory:

```
Enemy newEnemy = EnemyFactory.CreateNew();
newEnemy.X = 4;
newEnemy.Y = 3;
// newEnemy can be used in any other valid Entity code
```

### Code Example: Conditionally Creating Entities

Usually entities which are created with factories are created on some condition. Examples include:

* Reacting to input. For example, the player presses a button to shoot a bullet.
* Reacting to a collision event. For example, the player collides with a trigger to spawn an item.
* Reacting to time condition. For example, an enemy spawner creates an enemy once every 10 seconds.

The following code shows how to create a bullet whenever the user presses the space bar.

```
if(InputManager.Keyboard.KeyPused(Keys.Space))
{
   var bullet = Factories.BulletFactory.CreateNew();
   bullet.X = Player.X;
   bullet.Y = Player.Y;
   bullet.XVelocity = 100;
}
```

### Passing a Layer

The CreateNew method also takes a Layer argument. This layer specifies which Layer the created object should be a part of. Entities are usually created in Screen custom code or in the custom code of other Entities.

#### Passing a Layer in Screen custom code

If you are creating an Entity through a Factory in a Screen, then you can pass the Layer which you would like the newly-created Entity to be a part of in the CreateNew method. This will usually be a Layer which is a part of the Screen (usually created through Glue). The following code assumes a Layer called HudLayer:

```
CoinIcon newIcon = CoinIconFactory.CreateNew(HudLayer);
```

#### Passing a Layer in an Entity

If the Entity that is being instantiated through the Factory is to be on the same Layer as the Entity calling the code, then the [LayerProvidedByContainer](../../../../frb/docs/index.php) can be used:

```
Button newButton = ButtonFactory.CreateNew(this.LayerProvidedByContainer);
```

If this is not the case, then the creating Entity must have reference to the Layer which is to be used. You may need to set this reference up purely in custom code.

### You must first initialize the factory to use it

If you are calling CreateNew you may see an exception indicating that you must call Initialize before using the factory. ![CreateNewException.PNG](../../../../media/migrated_media-CreateNewException.PNG). If you are seeing this exception it means that the factory that you are trying to use when calling CreateNew has not yet been initialized. If you've used factories before then you may be thinking "I never had to call Initialize before, why do I have to now?" Initialize will automatically be called for you if you are using a Screen which contains a list of the given Entity type, and if that list was created through Glue. In other words, if you have an Entity called Bullet, and a factory called BulletFactory, then BulletFactory will automatically be initialized if your game is currently in a Screen which has a list of Bullets added to it in Glue. If you do not have a list of the given object type, but you want to instantiate that object at runtime, then you will manually need to call Initialize on the factory. For more information about Initialize, see [this page](../../../../frb/docs/index.php).
