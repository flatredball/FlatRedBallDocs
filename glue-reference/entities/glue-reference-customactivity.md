# CustomActivity

### Introduction

The CustomActivity function is called once per frame (unless the entity is paused). This method is private so it cannot be directly called, but it is called by an entity's Activity function. This method is usually called automatically by generated code.

### Typical CustomActivity Logic

CustomActivity is used to perform every-frame logic in your entities. Not all entities need to have CustomActivity logic. For example, a bullet may have its Velocity set upon creation, and it may get destroyed through collision events in the GameScreen. In this case, the bullet may not need any CustomActivity.

However, more complex entities, such as a Player or Enemy, may need additional logic in CustomActivity. The following list includes common types of logic which might be added to an Entity's CustomActivity:

* Shooting bullets in response to input
* Custom movement beyond what is handled by top-down or platformer generated code, such as dashing
* Changing movement variables, such as assigning Water movement
* Timing-based logic, such as ending an invulnerability state after a certain amount of time
* Playing sound effects, such as step sounds if moving
* Playing special effects or particles
* Performing AI or pathfinding

### Automatic CustomActivity Calls

Entity instances have their CustomActivity called automatically if any of the following are true:

*   The entity is created directly in the FlatRedBall Editor\


    <figure><img src="../../.gitbook/assets/image (340).png" alt=""><figcaption><p>Player1 is added directly to a Screen so its CustomActivity is called automatically</p></figcaption></figure>
*   The entity is added to a list which is part of a Screen in the FlatRedBall Editor\


    <figure><img src="../../.gitbook/assets/image (341).png" alt=""><figcaption><p>BulletList is part of the GameScreen, so any Bullet added to BulletList has its CustomActivity called automatically</p></figcaption></figure>

{% hint style="info" %}
Usually entity instances (such as bullets) which are created while the game is running are created using factories which automatically place the newly-created instance in its list.
{% endhint %}

### Order of CustomActivity calls

If an entity instance is added to the FlatRedBall Editor directly, or is added to a list which was created in the FlatRedBall Editor, then its CustomActivity is called automatically. Entity CustomActivity is called before a Screen's CustomActivity.

### Destroy in CustomActivity

Entities are free to destroy themselves in the CustomActivity call. For example, if a bullet should only survive for 10 seconds, the following logic may exist:

```csharp
double timeCreated;

void CustomInitialize()
{
    timeCreated = TimeManager.CurrentScreenTime;
}

void CustomActivity()
{
    if(TimeManager.CurrentScreenSecondsSince(timeCreated) > BulletLifeInSeconds)
    {
        Destroy();
    }
}
```

When calling Destroy, keep in mind that the entity may be needed in situations outside of typical usage in GameScreen. For example, at some point in the future you may decide to have a screen where the user can view all of the different types of bullets that can be shot when the player is upgraded. In this screen you may want to display the bullet. As written the bullet would automatically destroy itself after BulletLifeInSeconds, which may not make sense in this particular screen. Therefore, consider whether the logic that you are writing in CustomActivity should be active whenever a bullet is alive, or only in certain screens.

#### Destroying other Entities

An entity should not destroy other entities in CustomActivity. Typically this type of destruction should belong in the _owner_ of the entities, which is usually the GameScreen.&#x20;

Destroying other entities can also cause crashes in your application if the type of entity being destroyed is of the same type as the current entity. This happens because of how list activity is performed. The following code shows how the BulletList is iterated through in the GameScreen's Generated code:

```csharp
for (int i = BulletList.Count - 1; i > -1; i--)
{
    if (i < BulletList.Count)
    {
        // We do the extra if-check because activity could destroy any number of entities
        BulletList[i].Activity();
    }
}
```

Although the code above performs a bounds check, it is possible that instances are removed such that the same instance has its Activity called multiple times per frame. FlatRedBall's generated code checks for multiple Activity calls per frame and throws an exception if this is detected.

If an entity must destroy other entity instances, a flag or event should be used so that this destruction can be performed in the GameScreen (or owning screen).
