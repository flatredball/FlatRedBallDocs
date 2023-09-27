## Introduction

States allow you to modify your object in an organized, type-safe, way. States can also be previewed when the game is running in edit mode, speeding up iteration. States are a lightweight alternative to using inheritance, and can even be used to change a Screen or Entity multiple times. States can exist on any Screen or Entity, and appear under the States folder in Glue. States can be added as either categorized or uncategorized states. Categorized states are the most common, and avoid confusion which can be caused by uncategorized state. The following image shows a **PowerUp** entity with a **PowerUpType** category containing three states.

![](/media/2021-03-img_605613d04048a.png)

## 

## Adding States

Glue provides two different ways to add states. The preferred method is using the State Data tab. The second way is using the right-click menu. The two can both be used, so you don't have to pick which to use; that said, using the State Data method can be easier, so it is recommended.

### State Data

Once a category has been created, states can be added in the State Data tab.

![](/media/2021-03-img_60562f9698889.png)

New states can be added by entering names in the left-most column. Adding a new name creates a new state. [![](/wp-content/uploads/2016/01/2021_March_20_112624.gif)](/wp-content/uploads/2016/01/2021_March_20_112624.gif) By default, all variables in the Entity or Screen appear in the **State Data** tab. This includes tunneled variables too. For example, consider a tunneled SpriteInstance Texture variable. [![](/wp-content/uploads/2016/01/2021_March_20_111428.gif)](/wp-content/uploads/2016/01/2021_March_20_111428.gif) This variable will appear as a column in the **State Data** tab.

![](/media/2021-03-img_6056315a35c47.png)

Variables can be added and removed from the **State Data** tab for a given category. It's best to remove variables which aren't used in a category to prevent mistakes. [![](/wp-content/uploads/2016/01/2021_March_20_110432.gif)](/wp-content/uploads/2016/01/2021_March_20_110432.gif)

### Right-Click Menu

States can also be added through the right-click menu on a category. [![](/wp-content/uploads/2016/01/2021_March_20_112411.gif)](/wp-content/uploads/2016/01/2021_March_20_112411.gif) This method is the *old way* of adding states. It is still supported, but it is a little more cumbersome compared to using *state data*. States added this way will still appear in the State Data tab.

## Setting States in Code

Every state category generates a class which is embedded in the screen or entity containing the state. By default states can only be assigned inside the entity or screen defining the state. For example, if the **PowerUp** entity defines a state category named **PowerUpCategory**, then states can be assigned in code.

![](/media/2021-03-img_605635c67dd65.png)

Assigning the state will apply all variables set in the state in Glue.

## Conditional Logic Based on State

The state can be compared against the values which are assigned to perform logic. For example, the following code could be written to perform logic based on the state of the power up.

    if(this.CurrentPowerUpCategoryState == PowerUpCategory.FirstState)
    {
      // Do logic for first state
    }
    else if(this.CurrentPowerUpCategoryState == PowerUpCategory.SecondState)
    {
      // Do logic for second state
    }
    // and so on...

 

## Additional Information

-   [Introduction to States](/frb/docs/index.php?title=Glue:Tutorials:States "Glue:Tutorials:States")
-   [Rock Blaster States Tutorial](/documentation/tutorials/rock-blaster/tutorials-rock-states.md)
-   [States reference](/frb/docs/index.php?title=Glue:Reference#States "Glue:Reference")
