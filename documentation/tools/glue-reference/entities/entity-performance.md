## Introduction

The Entity Performance tab provides options for improving the runtime performance (reducing CPU usage) for an entity. This tab is only needed for games which include a very large number of entities (typically many hundreds or thousands of instances). Common types of entities which benefit from this tab are enemies and bullets.

## Entity Performance Concepts

Entities and objects within entities, such as Sprites, inherit from the PositionedObject class and have default engine-level functionality for applying velocity, rotation, acceleration, drag, and attachments. Although this functionality does not take much time to perform on a single entity, some games may include thousands of entities. In this case, the number of update calls may impact a game's framerate. If a game includes entities which are completely static (do not move after being created), then every instance of this type of entity can be converted to *manually updated*, which means that engine-level updates are disabled. Manually updated entities have minimal resource requirements, allowing games to instantiate tends of thousands of instances at once. Entities generate a ConvertToManuallyUpdated method which converts the entity itself and any contained objects to manually updated. In many cases entities require some of the automatic update logic provided by the engine, but not all. For example, a Bullet entity which moves along a straight line after being created requires velocity to be applied every frame, but does not require acceleration, drag, rotational velocity, or attachment logic. This mixed-case is very common, and this is the case where the Entity Performance tab can be used. By default, entities are fully-managed by the engine. For example, the following image shows a Bullet entity and its default Entity Performance tab.

![](/media/2021-05-img_60aa7355745ea.png)

Notice that the entity itself has its own management settings, and each object within the entity (SpriteInstance and CircleInstance) also have their own management settings.

![](/media/2021-05-img_60aa7392e52b5.png)

As mentioned before, these settings provide all management functionality, but also have the highest performance requirements.

## Modifying Managed Properties

The Entity Performance tab provides a visual interface for selecting which properties are managed. Since every game is different, it does not provide any standard presets, but rather exposes all possible values. An entity which does not require all properties to be managed every frame can use the **Select Managed Properties** option.

![](/media/2021-05-img_60aa87843872a.png)

For example, a Bullet entity which requires only velocity values can check just the XVelocity and YVelocity properties. Note that most entities do not require ZVeocity movement, so that option is left unchecked in the following image:

![](/media/2021-05-img_60aa87c3ab1f5.png)

## Generation and EntityPerformance.json

Changes to an entity's managed properties or changes to managed properties on an object inside of an entity result in code generation and storage of these properties in a EntityPerformance.json file. The EntityPerformance.json is necessary to re-generate the code whenever an entity changes, so it should be included in a game's version control repository. The generated code for an entity includes the management of all properties selected the **Select Managed Properties** option is checked. For example, the following code is generated for the Bullet entity using the options shown above:

    public virtual void Activity () 
    {
        
        this.Position.X += this.Velocity.X * FlatRedBall.TimeManager.SecondDifference;
        this.Position.Y += this.Velocity.Y * FlatRedBall.TimeManager.SecondDifference;
        CustomActivity();
    }

Of course, if custom code modifies the entity (such as by re-adding it to be managed by the engine), this generated code can result in double-management. The symptom of this is that an object may move twice as fast, animate twice as fast, or have other variables such as drag applied twice in one frame.
