# PooledByFactory

### Introduction

The PooledByFactory property on Entities tells Glue that the Factory for the given Entity should perform pooling. For this property to appear, an Entity must have its CreatedByOtherEntities property set to true. More information on CreatedByOtherEntities [can be found here](../../frb/docs/index.php).

**What is pooling?** In programming a "pool" of objects is a group of objects which are instantiated but unused. Whenever a new object is needed, an instance from the pool is returned. Whenever an object is no longer needed, it is returned to the pool - in other words, it's recycled. This allows your game to create and destroy objects without having to allocate memory. This is important for reducing memory allocation, which in turn reduces the number of times that the garbage collector has to run. If your game is experiencing jumps in frame rate you may be suffering from the garbage collector firing frequently, and pooling may help resolve this problem.

### Working with pooled Entities

The first step, as mentioned above, is to set "CreatedByOtherEntities" to true. Once this is done, you will see a "PooledByFactory" property. Setting "PooledByFactory" to true will enable pooling. The syntax to create an object will be:

```
// The factory will be in the Factories namespace
EntityType newInstance = Factories.EntityTypeFactory.CreateNew();
```

This code is identical whether PooledByFactory is true or not. This means that you can switch between PooledByFactory at any point in development. As long as you are using Factories, you will not have to change any code!

#### But what about recycling?

You may be wondering about recycling. The great thing about pooling in Glue is that the PooledByFactory will both modify the Factory code for your Entity as well as the Destroy code for your Entity. To recycle an Entity you simply call Destroy on it, just as you would if you weren't pooling. In other words, there is no code change here either!

### Pooling "gotchas"

Pooling allows your game to use the same Entity instance over and over to eliminate new memory allocation. While this is great for performance, it can cause some very confusing bugs. The following sections will help you prepare your Entity so that it does not suffer from poling-related bugs.

#### Custom variables not set in CustomInitialize

Consider the following code for a Bullet object:

```
// At class scope
double mTimeCreated = TimeManager.CurrentTime;
// CustomActivity:
void CustomActivity()
{
   const float secondsToLast = 3;
   if(TimeManager.SecondsSince(mTimeCreated) > secondsToLast)
   {
      this.Destroy();
   }
}
```

The code simply marks the time when the Bullet is instantiated, then checks to see if more than 3 seconds have passed since it has been instantiated, and if so, the Bullet is destroyed. This code will work without pooling; however, if you turn on pooling the Bullet objects will stop appearing after a few rounds are fired. The reason for this is because the Bullet's mTimeCreated is only set when the Bullet is instantiated. Once it is recycled, its mTimeCreated remains at its old value, and since it has already been destroyed once due to time, then more than 3 seconds have passed since it has been instantiated. The end result is, as soon as it is recycled, it is immediately destroyed and put back in the pool. The solution is to move any instantiation into CustomInitialize:

```
// Now this is set in CustomInitialize
double mTimeCreated;

void CustomInitialize()
{
   mTimeCreated = TimeManager.CurrentTime;
} 
// CustomActivity:
void CustomActivity()
{
   const float secondsToLast = 3;
   if(TimeManager.SecondsSince(mTimeCreated) > secondsToLast)
   {
      this.Destroy();
   }
}
```

Once this change is applied, the Bullet will work as expected. Since this is a common gotcha, we recommend never setting default values to objects outside of CustomIntialize. For non-pooled objects it makes no difference, but if you do decide to switch to a pooled Entity, you will be avoiding possible bugs.

#### Attached Object Values

Another common problem related to pooling is the starting values of objects added to an Entity in Glue. The way that Glue performs attachments depends on the absolute position of attached objects when Initialize is called. For example, if an Entity has a Sprite object, then that Sprite object will be attached to the Entity. The position of the Sprite matters - if it is moved to the right in the .scnx that it comes from, then it will be attached with an offset. The reason this matters regarding pooling is because pooled objects often move. This means that when a pooled object is destroyed, the Sprite attached to the Entity (or any other object attached to the Entity for that matter) will not be in its original position. This is a very common problem regarding pooling, and it can be difficult to solve. Fortunately, Glue can help. If you have switched an Entity to be pooled, you can tell it to reset its attached objects as follows:

1. Right-click on the Entity
2. Select "Add Reset Variables For Pooling". This option is only available if "PooledByFactory" is set to True![AddResetVariablesForPooling.png](../../.gitbook/assets/migrated\_media-AddResetVariablesForPooling.png)
3. You will be asked for a confirmation. Click "Yes".

Your contained objects will now have reset variables. If you'd like to view what has been reset, you can do the following:

1. Select an object inside your pooled Entity
2. Right-click on the object and select "Edit Reset Variables"![EditResetVariables.png](../../.gitbook/assets/migrated\_media-EditResetVariables.png)

A window will appear showing the variables that are being reset for the given object:![EditResetVariablesWindow.png](../../.gitbook/assets/migrated\_media-EditResetVariablesWindow.png) These variables are automatically set by Glue to capture the most common cases of variables which should be reset. You can also view the result of these variables in code by opening the Generated code. You will notice:

1. A set of static variables which store the values to reset
2. The setting of these static variables in Initialize (Initialize is only called once for a Pooled object)
3. The setting of instance variables according to the static variables in "AddToManagersBottomUp" which is called whenever an instance is created or pooled.

Keep in mind that Glue only adds variables to existing objects. If you ever add a new object (such as a collision object) to an Entity that is pooled and which has already had its reset variables set, you will need to right-click on the Entity and select "Add Reset Variables For Pooling" to tell Glue to add reset variables for your newly-created object.

#### Pooling and Inheritance

For information on how factories, pooling, and inheritance all work together see the [Factory Initialize method page](../../frb/docs/index.php).
