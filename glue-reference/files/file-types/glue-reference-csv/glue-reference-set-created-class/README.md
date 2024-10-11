# SetCreatedClass

### Introduction

By default Glue creates a new class in the DataTypes namespace for every CSV in your project. For example, consider a game where each enemy can have multiple types of attacks. Each enemy might store the attack information in its own CSV file. In this example the CSV files would be called:

1. SoldierAttackData.csv
2. OgreAttackData.csv
3. SlimeAttackData.csv
4. ZombieAttackData.csv

We will assume that each CSV file has the same columns, and we would like to have the same code handle enemy attacks regardless of which type of enemy is performing the attack. However, by default Glue will create four classes - one for each CSV. To solve this problem, we can create a common class to be used by all CSV files. This can be done by right-clicking on each of the CSV files and selecting the **Set Created Class** option.

### Example - Enemy AttackData

This example uses enemy entities which each provide their own attack data in CSV files. Each CSV has its **Created Class** set to Enemy Data.

![](../../../../../.gitbook/assets/2021-05-img\_60a665dd427c4.png)

A new class can be added in the **Created Class** window.

![](../../../../../.gitbook/assets/2021-05-img\_60a66625c9b94.png)

Once added, classes appear in the list below.

![](../../../../../.gitbook/assets/2021-05-img\_60a6665cd57e5.png)

This class can be used for the current CSV by selecting the class and clicking the **Use This Class** button.

![](../../../../../.gitbook/assets/2021-05-img\_60a66712159cc.png)

Once a class is added, Glue generates a file for this in the DataTypes folder.

![](../../../../../.gitbook/assets/2021-05-img\_60a6675f34450.png)

The four CSVs specified above will deserialize into AttackData Dictionaries or Lists.

### Platformer Values

Glue automatically creates a class called PlatformerValues if a game includes platformer entities. Every entity will store its platformer values in instances of the common PlatformerValues class. Removing this class can cause compile errors.

### Additional Information

* [Glue:Reference:Files:Set Created Class:Generate Data Class](../../../../../frb/docs/index.php)
