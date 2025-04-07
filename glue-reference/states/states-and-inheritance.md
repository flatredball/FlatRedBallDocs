# States and Inheritance

### Introduction

State behavior can be a little confusing when combined with inheritance. This article discusses how states and inheritance work together and things you should be aware of in your project when using States with Screens/Entities that inherit from other Screens/Entities.

### States Categories Create Classes

Every category in your project creates a class in generated code. For example, consider a Bullet entity with a category BulletAppearance.

<figure><img src="../../.gitbook/assets/07_06 40 56.png" alt=""><figcaption><p>BulletAppearance category</p></figcaption></figure>

The generated includes a class called BulletAppearance with properties matching the variables assigned in the FRB Editor.

<figure><img src="../../.gitbook/assets/07_06 43 01.png" alt=""><figcaption></figcaption></figure>

```csharp
public class BulletAppearance
{
    public string Name;
    public float BulletLifeDuration;
    public string AnimationName;
    public float SideBulletRadius;
    public float SideBulletRotationSpeed;
    public int MaxBullets;
    ...
```

### Derived Categories

If a category is added to a derived screen or entity, FlatRedBall checks if the same-named category exists in the base screen or entity. We can name a category the same in a derived class to create a derived state class in code.

For example, if we create an entity named BulletDerived and add a Category named BulletAppearance, we get a derived BulletAppearance class in code.

<figure><img src="../../.gitbook/assets/07_06 51 57.png" alt=""><figcaption><p>BulletAppearance category in BulletDerived</p></figcaption></figure>

```csharp
public class BulletAppearance : Entities.Bullet.BulletAppearance
{
    public string Name;
    ...
```

The derived entity incudes a property that is of the derived type, so derived instances can assign this property in code.

```csharp
private BulletAppearance mCurrentBulletAppearanceState = null;
public new Entities.BulletDerived.BulletAppearance CurrentBulletAppearanceState
{
    get
    {
        return mCurrentBulletAppearanceState;
    }
    set
    {
        mCurrentBulletAppearanceState = value;
        ...
```

###
