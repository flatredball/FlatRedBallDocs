## Introduction

Many game types include collidable areas which deal damage over time to characters or enemies within the area. This type of behavior can be accomplished in Glue with a little setup. This post shows how to implement damage over time using standard entities.

## Damage Over Time vs. Simple Collision

The simplest situation for damage dealing collision is where the entity dealing the damage is destroyed upon collision. For example, many *shmup* games include bullets which are destroyed upon collision with the player.

![](/media/2020-11-img_5fbd7de1be7f9.png)

  Entities which deal damage over time are not destroyed upon collision. These entities require special logic for more complex behavior. Specifically, these entities must:

-   Check collision with other entities to deal damage
-   Define how frequently damage is dealt (such as once per second)
-   Must only deal damage according to the defined frequency, despite the fact that collision may occur every frame
-   Must be eventually destroyed

## Checking Collision

Checking collision between damage-dealing entities and entities which can receive damage is no different than other collision - a relationship with a collision event handler is all that is needed. For example, the code might look something like this:

``` lang:c#
void CustomInitialize()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        PlayerInstance, this.DamageAreaList);
    relationship.CollisionOccurred += HandlePlayerVsDamageAreaCollision;
}

private void HandlePlayerVsDamageAreaCollision(Player player, DamageArea damageArea)
{
    ...
}
```

In the code above, the PlayerInstance is assumed to be a single entity which can receive damage and the DamageAreaList is a Glue list of entities which can deal damage. Of course, both the Player and DamageArea entities are assumed to implement the ICollidable interface.

## Defining Damage Frequency

Damage frequency may be defined on the entity itself as a simple variable, or may be defined in a more complex structure such as a data state or CSV. In the simplest case, a variable can be added as a static variable to the damage-dealing entity.

![](/media/2019-05-img_5ccfbcc3cdd5c.png)

## Dealing Damage by Frequency

The most complicated part is writing the code to deal damage according to a set timer. When writing this code we must keep a few considerations in mind:

-   Each entity which may receive damage should keep track of its own values for when it received damage
-   An entity may be colliding with multiple damage-dealing areas, and should receive damage from each according to its own damage dealing frequency
-   An entity may move in or out of a damage dealing area at any time, so every-frame collision is necessary even if damage isn't dealt every frame

![](https://cdn.wikimg.net/strategywiki/images/b/bc/Diablo_firewalls_screenshot.jpg) To support this functionality, any entity which may receive damage will need to keep track of the last time it receives damage, and only allow damage to be dealt if enough time has passed since the last time damage was dealt. This can be accomplished using a Dictionary which associates the damage dealing entities with the last time damage was dealt, as shown below:

``` lang:c#
public partial class Player
{
    Dictionary<DamageArea, double> damageAreaLastDamage =
        new Dictionary<DamageArea, double>();
    ...
```

In this case, the Player is responsible for reporting whether it can receive damage. This can be done in a function similar to what is shown below:

``` lang:c#
public bool ShouldTakeDamage(DamageArea damageArea)
{
    if(damageAreaLastDamage.ContainsKey(damageArea) == false)
    {
        // This is the first time the player has collided with this
        // damage area, so deal damage and record the time in the damageAreaLastDamage
        // dictionary.
        damageAreaLastDamage.Add(damageArea, CurrentTime);

        // Remove the damage area from the dictionary when it is destroyed or else
        // the Player may accumulate a large collection of damage areas, resulting in
        // an accumulation memory leak.
        damageArea.Destroyed += () => damageAreaLastDamage.Remove(damageArea);
        return true;
    }
    else
    {
        // See when the last time damage was dealt...
        var lastDamage = damageAreaLastDamage[damageArea];

        // ... has enough time passed?
        if(FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(lastDamage) > DamageArea.SecondsBetweenDamage)
        {
            // If so, update the last damage time.
            damageAreaLastDamage[damageArea] = CurrentTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}
```

The code above uses the Dictionary to determine if the player should take damage from a DamageArea. Note that when a DamageArea is first added to the Dictionary, its Destroy event is subscribed to so that it can be removed. This is important or else the Player would accumulate DamageArea instances over time. The code above requires that the DamageArea implements a Destroyed event. Fortunately this is easy to add, as shown in the following code:

``` lang:c#
public partial class DamageArea
{
    public event Action Destroyed;
    ...
    private void CustomDestroy()
    {
        Destroyed?.Invoke();
    }
    ...
```

The TryTakeDamage method must be called whenever collision has occurred. It will return whether damage is actually dealt. This should be called from the collision handler in the screen, as shown below:

``` lang:c#
private void HandlePlayerVsDamageAreaCollision(Player player, DamageArea damageArea)
{
    if(player.ShouldTakeDamage(damageArea))
    {
       // deal damage to the player
       // show whatever effects
    }
}
```

## Destroying the Collision Area

Collision areas typically last a set amount of time. Since we have subscribed to the Destroy event in the code above, we don't need to do anything beyond calling Destroy on the collision area after a set amount of time. We can use the built-in Call extension method to call Destroy, as shown below:

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    var cursor = FlatRedBall.Gui.GuiManager.Cursor;

    // this would be some kind of if-check to determine if collision
    // areas should be created...it could even be inside of another entity
    // if using factories
    {
        var entity = new DamageArea();
        
        this.DamageAreaList.Add(entity);

        // 3 in this case is a hardcoded value, but might normally
        // be a Glue variable
        entity.Call(entity.Destroy).After(3);
    }
}
```

## Try It Yourself!

The code shown above is pulled from a simple demo project. You can download it and give it a try yourself here: [TakeDamageDemo.zip](http://files.flatredball.com/content/Tutorials/Blogs/TakeDamageDemo.zip) To see it in action, run the app and click the mouse to place a damage area. Each damage area deals 10 HP of damage every second. This is visualized with rising text from the player (white circle). [![](/wp-content/uploads/2019/05/2019-05-05_23-10-48.gif)](/wp-content/uploads/2019/05/2019-05-05_23-10-48.gif) Also, the project can be opened in Glue and modified easily, so download it and give it a try today!
