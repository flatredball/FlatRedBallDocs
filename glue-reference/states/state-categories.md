# State Categories

### Introduction

State Categories can be thought of as folders for states. State Categories are used for a number of reasons:

* To organize similar states into categories
* To allow multiple states to be set at the same time (if not sharing variables between states)
* To create multiple state types for more expressive code (if not sharing variables between states)
* To enable including and excluding particular variables from assignment

State categories will appear as folders in the tree view, and can contain any number of States. &#x20;

<figure><img src="../../.gitbook/assets/26_07 06 44.png" alt=""><figcaption><p>Categorized states</p></figcaption></figure>

Note that categorized cannot be added inside of other categories.

### Adding a State Category

To add a state category:

1. Expand a Screen or Entity that you want to add a category to
2. Right-click on the States item
3.  Select **Add State Category**\
    &#x20;

    <figure><img src="../../.gitbook/assets/26_07 07 25.png" alt=""><figcaption><p>Right click Add State Category item</p></figcaption></figure>
4. Enter the name for the new category. By convention, categories should have the suffix "Category"
5. Click **OK**

### Including and Excluding Variables in Categories

By default a category categories do not set any variables. Any variable that should be set by the category must be explicitly added.

To exclude or exclude variables, click the **...** button in the State Data tab and use the **<<** and **>>** buttons to include and exclude variables.&#x20;

<figure><img src="../../.gitbook/assets/26_07 12 06.gif" alt=""><figcaption></figcaption></figure>

#### Excluding Variables Prevents Accidental Assignment

Excluding variables has two benefits:

1. Simplifies the grid so only relevant variables are displayed
2. Removes unnecessary assignment of variables when a state is set

### State Categories as StateData

StateData is the concept of treating states similar to CSV data. FlatRedBall supports treating States as CSV data by providing a CSV-like interface when selecting a category, as shown in the following image:

![](../../.gitbook/assets/2020-06-img\_5ee783d044f32.png)

For an in-depth discussion of State Data, including how to exclude variables from inclusion, see the [State Data blog post](https://flatredball.com/news/introducing-state-data/).
