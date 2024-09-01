# States

### Introduction

States allow you to modify your object in an organized, type-safe, way. States can also be previewed when the game is running in edit mode, speeding up iteration. States are a lightweight alternative to using inheritance, and can even be used to change a Screen or Entity multiple times. States can exist on any Screen or Entity, and appear under the States folder in the FRB Editor tree view.&#x20;

Although states can be added as either categorized or uncategorized states, categorized states are the most common, and avoid confusion which can be caused by uncategorized state.

The following image shows a **PowerUp** entity with a **PowerUpCategory** containing three states.

![PowerUp entity with 3 categorized states](<../../.gitbook/assets/26\_06 37 11.png>)

### Adding States

The FRB Editor provides two different ways to add states. The preferred method is using the State Data tab. The second way is using the right-click menu. The two can both be used, so you don't have to pick which to use; that said, using the State Data method can be easier, so it is recommended.

Before you can add states, you must first add a state category. For information on how to add a state category, see the [State Categories](state-categories.md) page.

#### State Data

Once a category has been created, states can be added in the State Data tab.

![PowerUpCategory showing the State Data tab](<../../.gitbook/assets/26\_06 39 37.png>)

New states can be added by entering names in the left-most column. Adding a new name creates a new state.

<figure><img src="../../.gitbook/assets/26_06 40 32.gif" alt=""><figcaption></figcaption></figure>

By default, variables do not appear in the State Data tab (and are not accessible by states in the category). You must explicitly add variables which you would like to edit in your state. Conceptually, this makes sense considering categories are usually built to only modify a subset of variables.

For example, consider a variable which tunnels into a Sprite's CurrentChainName - which we'll call "Animation" to keep the name short:

<figure><img src="../../.gitbook/assets/image (57).png" alt=""><figcaption><p>Animation variable in a PowerUp entity</p></figcaption></figure>

To make this variable accessible to the PowerUpCategory, drag+drop the variable onto the category. Doing so results in the variable appearing in the State Data grid.

<figure><img src="../../.gitbook/assets/26_06 50 15.gif" alt=""><figcaption><p>Drag+drop a variable onto a State category to have it show up in the State Data grid</p></figcaption></figure>

Variables can be added and removed from the **State Data** tab for a given category as an alternative way to include and exclude variables.

<figure><img src="../../.gitbook/assets/26_06 51 43.gif" alt=""><figcaption><p>Variables can be included and excluded from categories</p></figcaption></figure>

#### Right-Click Menu

States can also be added through the right-click menu on a category.

<figure><img src="../../media/2016-01-2021_March_20_112411.gif" alt=""><figcaption></figcaption></figure>

This method is the _old way_ of adding states. It is still supported, but it is a little more cumbersome compared to using _state data_. States added this way will still appear in the State Data tab.

### Setting States in Code

Every state category generates a class which is embedded in the screen or entity containing the state. By default states can only be assigned inside the entity or screen defining the state. For example, if the **PowerUp** entity defines a state category named **PowerUpCategory**, then states can be assigned in code.

![](../../media/2021-03-img\_605635c67dd65.png)

Assigning the state will apply all variables set in the state in the FRB Editor.

### Conditional Logic Based on State

The state can be compared against the values which are assigned to perform logic. For example, the following code could be written to perform logic based on the state of the power up.

```csharp
if(this.CurrentPowerUpCategoryState == PowerUpCategory.FirstState)
{
  // Do logic for first state
}
else if(this.CurrentPowerUpCategoryState == PowerUpCategory.SecondState)
{
  // Do logic for second state
}
// and so on...
```
