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

If a category is added to a derived screen or entity, FlatRedBall checks if the same-named category exists in the base screen or entity. If the derived category matches the name of a category in the base, then this category is created as a derived class from the base category. Derived categories can be used to add additional states to the base.

For example, consider a base entity Bullet and a derived entity named BulletDerived each with a category named BulletAppearance.

<figure><img src="../../.gitbook/assets/07_06 51 57.png" alt=""><figcaption><p>BulletAppearance category in BulletDerived</p></figcaption></figure>

BulletDerived defines a class named BulletAppearance which inherits from the base BulletAppearance class.

```csharp
public class BulletAppearance : Entities.Bullet.BulletAppearance
{
    public string Name;
    ...
```

The derived entity includes a property that is of the derived type, so derived instances can assign this property in code.

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

The derived entity can add additional states to the category, but it cannot overwrite existing states. If a new state is added with the same name as a state in the base class, FlatRedBall marks it as an error by coloring the name text.

<figure><img src="../../.gitbook/assets/08_06 29 52.png" alt=""><figcaption><p>Derived category with a state that has the same name as a state in the base category is marked as an error</p></figcaption></figure>

