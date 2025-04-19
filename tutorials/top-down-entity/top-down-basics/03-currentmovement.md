# CurrentMovement

### Introduction

The CurrentMovement property controls the values used by the top down entity in response to input. The CurrentMovement property can be assigned in code in response to various conditions in your game such as:

* Collision with different terrain (such as walking through mud)
* Responding to power-ups (such as collecting a power-up which increases speed)
* Responding to special moves or input which changes the character's movement variables (such as holding down a run button)

### Defining Movement Values

Movement values can be defined in the FRB editor or code. If your game has a limited set of movement values, these can be defined in the FRB editor. To do so:

1. Select an entity
2. Click the **Entity Input Movement** tab
3. Verify that your entity is using the **Top Down** option for **Input Movement Type**
4.  Click the **Add Movement Type** button

    ![Add Movement Type button](<../../../.gitbook/assets/18_17 58 02.png>)
5. Modify the newly-added movement values as necessary

The **Top Down** tab displays all movement values for the selected entity.

![All movement values displayed in the FRB Editor](<../../../.gitbook/assets/18_17 59 52.png>)

### Assigning Movement Values

You can assign the current movement values in code through the `CurrentMovement` propety. For example, the following code assigns the movement to `FastMovement` or `Default` depending on the state of an `Xbox360GamePad`:

```csharp
var gamepad = InputManager.Xbox360GamePads[0];
if(gamepad.ButtonDown(Xbox360GamePad.Button.B))
{
    this.CurrentMovement = TopDownValues[DataTypes.TopDownValues.FastMovement];
}
else
{
    this.CurrentMovement = TopDownValues[DataTypes.TopDownValues.Default];
}
```

### Movement Values and Inheritance

Derived entities can override movement values which are defined by their base entity. For example, consider an Enemy entity with two movement types: Idle and Walk.

<figure><img src="../../../.gitbook/assets/18_18 02 26.png" alt=""><figcaption><p>Enemy with movement values</p></figcaption></figure>

A derived entity automatically inherits these movement values as shown in the FRB editor.

<figure><img src="../../../.gitbook/assets/18_18 03 28.png" alt=""><figcaption><p>Inherited values</p></figcaption></figure>

Notice that these values are read-only, but they can be overwritten by checking the **Overwrite Values** radio button.

<figure><img src="../../../.gitbook/assets/18_18 04 23.png" alt=""><figcaption><p>Overwritten walk variable</p></figcaption></figure>

The name of movement types cannot be changed when overwriting values; however derived entities can add additional movement variables which do not exist in their base.

At runtime the derived entity merges the overwritten values with the base values. For example, the Slime enemy has two movement values, but its Walk value has a max speed of 150 instead of 76.

<figure><img src="../../../.gitbook/assets/18_18 08 02.png" alt=""><figcaption><p>MaxSpeed set to the overwritten value of 150</p></figcaption></figure>

{% hint style="info" %}
This merging occurs in the generated code for each entity. For example, the following shows what the code in Enemy.Generated.cs looks like. Notice that it merges the base TopDownValuesStatic with its own values.

```csharp
if (TopDownValuesStatic == null)
{
    {
        // We put the { and } to limit the scope of oldDelimiter
        char oldDelimiter = FlatRedBall.IO.Csv.CsvFileManager.Delimiter;
        FlatRedBall.IO.Csv.CsvFileManager.Delimiter = ',';
        System.Collections.Generic.Dictionary<string, global::TopDownExample.DataTypes.TopDownValues> temporaryCsvObject = new System.Collections.Generic.Dictionary<string, global::TopDownExample.DataTypes.TopDownValues>();
        foreach (var kvp in Entities.Enemy.TopDownValuesStatic)
        {
            temporaryCsvObject.Add(kvp.Key, kvp.Value);
        }
        FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeDictionary<string, global::TopDownExample.DataTypes.TopDownValues>("Content/Entities/Slime/TopDownValuesStatic.csv", temporaryCsvObject, FlatRedBall.IO.Csv.DuplicateDictionaryEntryBehavior.Replace);
        FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
        TopDownValuesStatic = temporaryCsvObject;
    }
}
```
{% endhint %}
