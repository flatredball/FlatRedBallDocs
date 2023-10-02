# introducing-state-data

Although States have been available in Glue for a long time (about as long as Variables themselves), they have fallen out of style in modern FlatRedball development. Meanwhile the feature set for CSVs has continued to advance, and this file format has become the preferred way to define game data and to organize variables. If we list the benefits of CSVs we can see why they're so common:

* Easy to define in standard spreadsheet programs (Excel, Libre Office, Google Docs) or Glue's CSV plugin
* Variables can be compared across rows (far more difficult to do with states)
* Support reloaded at runtime to speed up iteration during development
* Can be replaced and loaded dynamically, allowing for post-release updates
* Cells can contain struct definitions (X = 3, Y = 4, Z = 2)
* Support base row types and inheritance
* Support list variables

Although these features are great for game development, states also have some unique benefits:

* Automatic state variable definition based on variables in a screen or entity
* Automatic creation of a "current" variable, which will assign variables on the containing screen or entity when assigned
* GlueView support for previewing
* Awareness of CSV options, file contents (such as referencing an animation in a .achx file), and typed other state options

Developers who wanted to define and organize variables had to choose which set of benefits were more important...at least until today! The latest version of Glue ships with a new embedded plugin which I'm calling _State Data_. This name was selected to suggest a system that combines the best of states with CSV data.

### State Categories as Data

Any state category can be used with the State Data plugin, whether existing or new. To see it in action, we can look at an entity called Enemy with the following variables:

* X
* Y
* Z
* Health
* AttackDamage
* Animation

![](../media/2018-06-img\_5b2323aae5013.png)

Some things to keep in mind:

* X, Y, and Z are exposed variables, automatically added by Glue when the Enemy entity was first created
* Health and AttackDamage are new variables added after the enemy was created. They are both simple _int_ variables
* Animation is a tunneled variable - it's the AnimationChains property on the contained SpriteInstance object

Once a state category is created, the State Data plugin provides a new tab for adding and editing states:

![](../media/2018-06-img\_5b23247aafa0e.png)

Now creating new states is as easy as filling in a spreadsheet: [![](../media/2018-06-2018-06-14\_20-41-05.gif)](../media/2018-06-2018-06-14\_20-41-05.gif) Notice that whenever a new row is added, a new state appears under the category.

![](../media/2018-06-img\_5b2327963591b.png)

And as mentioned earlier, values which have discrete options appear as dropdowns. For example, the Animation variable displays available .achx files.

![](../media/2018-06-img\_5b2328af9d21c.png)

### Excluding Variables

By default state categories include all variables. This is convenient for quick state creation, but sometimes entities define variables which should not be in a state. The State Data plugin introduces the ability to exclude variables from states. The **...** button can be clicked to expand the variable management UI where variables can be excluded from a state. In this case, the X, Y, and Z variables should not be part of the EnemyData. [![](../media/2018-06-2018-06-14\_22-06-07.gif)](../media/2018-06-2018-06-14\_22-06-07.gif)

### Working With States in Code

States can be assigned on an entity in code using the generated variables. In fact, although states now have far more functionality, not much has changed syntactically. For example, an entity can assign its own state, just like before:

![](../media/2018-06-img\_5b23294fbf914.png)

However, now each state can be inspected, allowing variables to be used without the instantiation of an entity:

![](../media/2018-06-img\_5b2329a6699b5.png)

And once a state is assigned, all variables are automatically applied to the entity; there's no need to write variable assignment handlers and hookup (like is necessary with CSVs).

![](../media/2018-06-img\_5b232a5967208.png)

### Breaking Changes

These new features require some changes to the underlying generated code. We can see that instead of a simple enumeration, state categories now generate a class:

![](../media/2018-06-img\_5b232ab3703a9.png)

While most code will work the same as before (such as assignments and comparisons), a few things will no longer work and may require you to manually change your custom code.

#### Switch Statements

Switch statements require const values, and could be used with the old implementation of states since each value was an enumeration. Since each state is now an instance of a data class, switch statements are no longer allowed. Therefore, switch statements need to be converted to if/else if statements.

```lang:c#
if(this.CurrentEnemyData == EnemyData.Skeleton)
{
    // Perform Skeleton logic
}
else if(this.CurrentEnemyData == EnemyData.Goblin)
{
    // Perform Goblin logic
}
```

#### Undefined is now null

The previous implementation of states provided an Undefined  value for all states. The new implementation allows null values. Therefore, any checks or assignments using Undefined  should now use null  instead.

```lang:c#
if(this.CurrentEnemyState == null)
{
    // do logic according to null value
}
```

#### Base and Derived Entities/Screens Have Separate States

This may change in future versions of Glue, but currently states are not shared across base and derived classes. Therefore, if you assign a state on a base entity, the derived entity may still have a null value for its same-named state. As this feature settles and is used more internally, it may evolve to support shared states across inherited entities.

#### State Data as a CSV Replacement?

At this point it's too early to say whether state data will replace CSVs. This first release introduces some much-needed features, making states once-again relevant for game dev, but they will need to continue to expand to completely replace CSVs. I expect that State Data will continue to grow over the coming months, adopting more features from the already-mature CSV technology.

#### Give it a Shot!

The current version of Glue fully supports everything you see above, so if you're looking to define data for your game, a simple Glue update is all you need.
